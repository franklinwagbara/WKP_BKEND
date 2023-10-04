using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.SendBackApplicationToCompany
{
    public class SendBackApplicationToCompanyCommandHandler :
        IRequestHandler<SendBackApplicationToCompanyCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffNotifier _staffNotifier;
        private readonly ICompanyNotifier _companyNotifier;
        private readonly IAppLogger _logger;
        private readonly Helper _helper;

        public SendBackApplicationToCompanyCommandHandler(IUnitOfWork unitOfWork, IAppLogger logger, Helper helper, IStaffNotifier staffNotifier, ICompanyNotifier companyNotifier)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

            _staffNotifier = staffNotifier;
            _companyNotifier = companyNotifier;
            _helper = helper;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(SendBackApplicationToCompanyCommand request, CancellationToken cancellationToken)
        {
           try
           {
                if(request.SelectedApps is not null)
                {
                    foreach(var sa in request.SelectedApps)
                    {
                        int appId = sa != "undefined"? int.Parse(sa) : 0;
                        var actingStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyNumberWithSBU(request.UserId);
                        var actingStaffDesk = await _unitOfWork.DeskRepository.GetDeskByDeskIdAppIdWithStaff(request.DeskID, appId);
                        var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(appId);

                        string rejectTables = await _helper.getTableNames(request.SelectedTables);

                        await _unitOfWork.ExecuteTransaction(async () => 
                        {
                            if(await _helper.SendBackApplicationToCompany(
                                app.Company, app, actingStaff, request.TypeOfPaymentId, 
                                request.AmountNGN, request.AmountUSD, request.Comment, rejectTables))
                            {
                                actingStaffDesk.Comment = request.Comment;
                                actingStaffDesk.ProcessStatus = APPLICATION_HISTORY_STATUS.ReturnedToCompany;
                                await _unitOfWork.DeskRepository.Update(actingStaffDesk);
                                await _unitOfWork.SaveChangesAsync();

                                await _helper.SaveApplicationHistory(appId, actingStaff.StaffID, 
                                    APPLICATION_HISTORY_STATUS.ReturnedToCompany, 
                                    request.Comment, rejectTables, false, null,
                                    APPLICATION_ACTION.ReturnToCompany);
                                
                                _staffNotifier.Init(actingStaff, app, app.Concession, app.Field);
                                await _staffNotifier.SendReturnNotification();

                                _companyNotifier.Init(app.Company, app, app.Concession, app.Field);
                                await _companyNotifier.SendReturnNotification();
                            }
                        });

                    }
                    
                    return new ApplicationResult(null, "Application(s) has been returned successfully.");
                }
                else 
                    return Error.Validation(code: ErrorCodes.InvalidParameterPassed, description: "Error: No application ID was passed for this action to be completed.");
                
                throw new Exception("Bad request; this action was not processed.");
           }
           catch (Exception e)
           {
                _logger.LogAudit(e.Message, request.UserEmail);
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
           } 
        }
    }
}