using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.ReturnAppToStaff
{
    public class ReturnAppToStaffCommandHandler : IRequestHandler<ReturnAppToStaffCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Helper _helper;
        private readonly IStaffNotifier _staffNotifier;

        public ReturnAppToStaffCommandHandler(IUnitOfWork unitOfWork, Helper helper, IStaffNotifier staffNotifier)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _staffNotifier = staffNotifier;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(ReturnAppToStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.SelectedApps is not null)
                {
                    var SBUIds = _helper.ParseSBUIDs(request.SBU_IDs) ?? throw new Exception("No SBU Ids was provided.");

                    foreach(var SA in request.SelectedApps)
                    {
                        int appId = SA != "undefined"? int.Parse(SA): throw new Exception("App Id cannot be 'undefined'");
                        var staffActing = await _unitOfWork.StaffRepository.GetStaffByCompanyNumber(request.CompanyId);
                        var staffDesk = await _unitOfWork.DeskRepository.GetDeskByDeskIdAppIdWithStaff(request.DeskID, appId);
                        var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(appId);
                        var returnedTables = await _helper.getTableNames(request.SelectedTables);

                        if(request.FromWPAReviewer is not true)
                        {
                            await _unitOfWork.ExecuteTransaction(async () => 
                            {
                                await ReturnAppBackToStaff(staffActing, staffDesk, app, request.Comment, returnedTables);

                                //Send notification to both parties
                                //Notify Source Staff
                                _staffNotifier.Init(staffActing, app, app.Concession, app.Field);
                                await _staffNotifier.SendReturnNotification();

                                //Notify Target Staff
                                var targetStaff = await _unitOfWork.StaffRepository
                                                .GetStaffByIdWithSBU((int)staffDesk.FromStaffID);
                                _staffNotifier.Init(targetStaff, app, app.Concession, app.Field);
                            });
                            
                            return new ApplicationResult(null, $"The Application {app.Concession.Concession_Held} has been returned to staff.");
                        }
                        else
                        {
                            await ReturnAppToStaffFromWPAReviewer();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }

        private async Task ReturnAppBackToStaff(staff StaffActing, MyDesk SourceDesk, Domain.Entities.Application App, string Comment, string ReturnedTables)
        {
            var targetDesk = await _unitOfWork.DeskRepository
                .GetDeskByStaffIdAppIdWithStaff((int)SourceDesk.FromStaffID, App.Id);

            targetDesk.HasWork = true;
            targetDesk.UpdatedAt = DateTime.Now;
            targetDesk.Comment = Comment;
            targetDesk.ProcessStatus = APPLICATION_HISTORY_STATUS.ReturnedToStaff;
            await _unitOfWork.DeskRepository.Update(targetDesk);
            await _unitOfWork.SaveChangesAsync();
            await _helper.UpdateDeskAfterReject(SourceDesk, Comment, APPLICATION_HISTORY_STATUS.ReturnedToStaff);
            await _helper.SaveApplicationHistory(App.Id, StaffActing.StaffID, APPLICATION_HISTORY_STATUS.ReturnedToStaff, Comment, ReturnedTables, false, null, APPLICATION_ACTION.ReturnToStaff);
        }
    }
}