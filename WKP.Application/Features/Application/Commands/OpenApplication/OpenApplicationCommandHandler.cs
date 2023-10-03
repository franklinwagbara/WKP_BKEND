using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Application.Common.Helpers;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.GeneralServices.Interfaces;

namespace WKP.Application.Application.Commands.OpenApplication
{
    public class OpenApplicationCommandHandler : IRequestHandler<OpenApplicationCommand, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppHelper _appHelper;
        private readonly IEmailAuditMessage _emailAuditMessage;

        public OpenApplicationCommandHandler(IUnitOfWork unitOfWork, AppHelper appHelper, IEmailAuditMessage emailAuditMessage)
        {
            _unitOfWork = unitOfWork;
            _appHelper = appHelper;
            _emailAuditMessage = emailAuditMessage;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(OpenApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var staffDesk = await _unitOfWork.DeskRepository
                .GetAsync(
                    (s) => s.DeskID == request.DeskId, 
                    new[]{MyDesk.NavigationProperty.Staff});

                if(staffDesk == null)
                   return Error.NotFound(code: ErrorCodes.NotFound, description: $"Staff Desk with DeskId {request.DeskId} was not found.");
        
                var app = await _unitOfWork.ApplicationRepository.GetApplicationById(staffDesk.AppId);

                if(app is null)
                   return Error.NotFound(code: ErrorCodes.NotFound, description: $"Application Desk with Id {staffDesk.AppId} was not found.");

                var appStatus = await _unitOfWork.AppStatusRepository.GetByAppIdSBUId(app.Id, (int)staffDesk.Staff.Staff_SBU);

                if(appStatus is null)
                   return Error.NotFound(code: ErrorCodes.NotFound, description: $"Application Status with Id {staffDesk.AppId} and SBU {staffDesk.Staff.Staff_SBU} was not found.");
                   
                await _unitOfWork.ExecuteTransaction(async () => 
                {
                    staffDesk.ProcessStatus = _appHelper.IsIncomingDeskStatus(staffDesk.ProcessStatus) ? DESK_PROCESS_STATUS.Processing : staffDesk.ProcessStatus;
                    appStatus.InternalStatus = staffDesk.ProcessStatus;
                    app.Status = _appHelper.IsIncomingDeskStatus(app.Status)? DESK_PROCESS_STATUS.Processing : app.Status;

                    await _unitOfWork.DeskRepository.Update(staffDesk);
                    await _unitOfWork.ApplicationRepository.Update(app);
                    await _unitOfWork.AppStatusRepository.Update(appStatus);
                    await _unitOfWork.SaveChangesAsync();

                    await _emailAuditMessage.LogAudit(
                        $"{staffDesk.Staff.FirstName}, {staffDesk.Staff.LastName} opened application with Reference No. {app.ReferenceNo}.", 
                        staffDesk.Staff.StaffEmail);
                });   

                return new ApplicationResult(staffDesk);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
            
        }
    }
}