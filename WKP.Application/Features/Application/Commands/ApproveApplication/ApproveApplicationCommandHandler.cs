using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Application.Features.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.ApproveApplication
{
    public class ApproveApplicationCommandHandler : IRequestHandler<ApproveApplicationCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Helper _helper;
        private readonly AppStatusHelper _appStatusHelper;
        private readonly IStaffNotifier _staffNotifier;
        private readonly ICompanyNotifier _companyNotifier;

        public ApproveApplicationCommandHandler(IUnitOfWork unitOfWork, Helper helper, AppStatusHelper appStatusHelper, IStaffNotifier staffNotifier, ICompanyNotifier companyNotifier)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _appStatusHelper = appStatusHelper;
            _staffNotifier = staffNotifier;
            _companyNotifier = companyNotifier;
        }
        public async Task<ErrorOr<ApplicationResult>> Handle(ApproveApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(request.AppId);
                var actingStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyEmail(request.StaffEmail);
                var staffDesk = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(actingStaff.StaffID, request.AppId, true);

                await _unitOfWork.ExecuteTransaction(async () => 
                {
                    string comment = "The Final Approving Authority approves this submission.";
                    //update approval table
                    await _unitOfWork.PermitApprovalRepository.AddAsync(app, app.Company, actingStaff.StaffEmail);

                    await _appStatusHelper.UpdateAppStatus(app, staffDesk, actingStaff, MAIN_APPLICATION_STATUS.Approved, MAIN_APPLICATION_STATUS.Approved);
                    await _helper.SaveApplicationHistory(app.Id, actingStaff.StaffID, APPLICATION_HISTORY_STATUS.FinalApprovingAuthorityApproved, comment, null, false, null, APPLICATION_ACTION.Approve, true);
                    await _helper.UpdateDeskAfterPush(staffDesk, comment, MAIN_APPLICATION_STATUS.Approved);

                    _staffNotifier.Init(actingStaff, app, app.Concession, app.Field);
                    await _staffNotifier.SendFinalApprovalNotification();

                    _companyNotifier.Init(app.Company, app, app.Concession, app.Field);
                    await _companyNotifier.SendFinalApprovalNotification();
                });

                return new ApplicationResult(null, "Submission was successfully approved!");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }
    }
}