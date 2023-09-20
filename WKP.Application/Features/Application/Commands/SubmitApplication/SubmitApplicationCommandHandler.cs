using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Application.Features.Common;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.SubmitApplication
{
    public class SubmitApplicationCommandHandler : IRequestHandler<SubmitApplicationCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Helper _helper;
        private IStaffNotifier _staffNotifier;
        private ICompanyNotifier _companyNotifier;
        private AppStatusHelper _appStatusHelper;

        public SubmitApplicationCommandHandler(IUnitOfWork unitOfWork, 
            Helper helper, 
            IStaffNotifier staffNotifier, 
            ICompanyNotifier companyNotifier,
            AppStatusHelper appStatusHelper)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _staffNotifier = staffNotifier;
            _companyNotifier = companyNotifier;
            _appStatusHelper = appStatusHelper;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(SubmitApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(request.AppId);
                var appFlows = (await _unitOfWork.AppProcessFlowRepo.GetAppFlowByAction(PROCESS_CONSTANTS.Submit)).ToList();       

                if(appFlows.Count <= 0) return Error.NotFound(code: ErrorCodes.NotFound, description: "No App Process Configuration found for this operation.");

                //Check if this application has been submitted before
                if(app.Status is not MAIN_APPLICATION_STATUS.NotSubmitted)
                    return Error.Failure(code: ErrorCodes.InternalFailure, 
                        description: $"An application for the Concession {app.Concession.Concession_Held}, and Field Name {app.Field.Field_Name} for the year {app.YearOfWKP} has already been submitted.");
                
                if(app is not null)
                {
                    await _unitOfWork.ExecuteTransaction( async () =>
                    {
                        var staffList = await _helper.GetReviewerStaffs(appFlows);

                        foreach (var staff in staffList)
                        {
                            int FromStaffID = 0; //This value is zero, because, this is company and not a staff
                            int FromStaffSBU = 0; // This value is zero, because, this is company and not a staff
                            int FromStaffRoleID = 0; //This value is zero, because, this is company and not a staff

                            var appFlow = appFlows.Where(p => p.TargetedToRole == staff.RoleID && p.TargetedToSBU == staff.Staff_SBU).FirstOrDefault();

                            var newDesk = await _helper.DropAppOnStaffDesk(
                                app.Id, staff, FromStaffID, FromStaffSBU,
                                FromStaffRoleID, appFlow.ProccessID,
                                MAIN_APPLICATION_STATUS.SubmittedByCompany);

                            await _helper.SaveApplicationHistory(
                                app.Id, staff.StaffID,
                                MAIN_APPLICATION_STATUS.SubmittedByCompany,
                                "Application submitted and landed on staff desk",
                                null, false, null, APPLICATION_ACTION.SubmitApplication
                            );

                            await _appStatusHelper.UpdateAppStatus(app, newDesk, staff, 
                                MAIN_APPLICATION_STATUS.SubmittedByCompany, MAIN_APPLICATION_STATUS.SubmittedByCompany);
                            
                            await _appStatusHelper.UpdateMainAppStatusOnSubmit(app, MAIN_APPLICATION_STATUS.SubmittedByCompany);

                            _staffNotifier.Init(staff, app, app.Concession, app.Field);
                            await _staffNotifier.SendSubmitNotification();
                        }

                        _companyNotifier.Init(app.Company, app, app.Concession, app.Field);
                        await _companyNotifier.SendSubmitNotification();
                    }); 
                    
                    var rspMsg = app.Field != null ? 
                        $"{app.YearOfWKP} Application for field {app.Field?.Field_Name} has been submitted successfully." 
                        : $"{app.YearOfWKP} Application for concession: ({app.Concession?.ConcessionName}) has been submitted successfully.\nIn the case multiple fields, please also ensure that submissions are made to cater for them.";
                    return new ApplicationResult( string.Empty,rspMsg, AppResponseCodes.Success );
                }
                else
                    return Error.Failure(code: ErrorCodes.InternalFailure, description: "An error occurred while trying to submit this application.");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }
    }
}