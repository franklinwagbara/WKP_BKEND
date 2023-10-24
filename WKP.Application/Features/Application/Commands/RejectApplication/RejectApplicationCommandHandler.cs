using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Interfaces;
using WKP.Application.Features.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Commands.RejectApplication
{
    public class RejectApplicationCommandHandler : IRequestHandler<RejectApplicationCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Helper _helper;
        private readonly AppStatusHelper _appStatusHelper;
        private readonly IStaffNotifier _staffNotifier;
        private readonly ICompanyNotifier _companyNotifier;
        
        public RejectApplicationCommandHandler(IUnitOfWork unitOfWork, Helper helper, AppStatusHelper appStatusHelper, IStaffNotifier staffNotifier, ICompanyNotifier companyNotifier)
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _appStatusHelper = appStatusHelper;
            _staffNotifier = staffNotifier;
            _companyNotifier = companyNotifier;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(RejectApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var app = await _unitOfWork.ApplicationRepository.GetAppByIdWithAll(request.AppId);
                var actingStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyEmail(request.StaffEmail);
                var staffDesk = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(actingStaff.StaffID, request.AppId, true);

                await _unitOfWork.ExecuteTransaction(async () => 
                {
                    string comment = request.Comment;
                    //update approval table
                    await _unitOfWork.SubmissionRejectionRepository.AddAsync(app, app.Company, actingStaff.StaffEmail);

                    await _appStatusHelper.UpdateAppStatus(app, staffDesk, actingStaff, MAIN_APPLICATION_STATUS.Rejected, MAIN_APPLICATION_STATUS.Rejected);
                    await _helper.SaveApplicationHistory(app.Id, actingStaff.StaffID, APPLICATION_HISTORY_STATUS.FinalApprovingAuthorityRejected, comment, null, false, null, APPLICATION_ACTION.Reject, true);
                    await _helper.UpdateDeskAfterPush(staffDesk, comment, MAIN_APPLICATION_STATUS.Rejected);

                    _staffNotifier.Init(actingStaff, app, app.Concession, app.Field);
                    await _staffNotifier.SendFinalRejectionNotification(request.Comment);

                    _companyNotifier.Init(app.Company, app, app.Concession, app.Field);
                    await _companyNotifier.SendFinalRejectionNotification(request.Comment);
                });

                return new ApplicationResult(null, "Submission was successfully rejected!");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }
    }
}