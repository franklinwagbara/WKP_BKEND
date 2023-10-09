using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Common
{
    public class AppStatusHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppStatusHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task UpdateAppStatus(Domain.Entities.Application app, MyDesk desk, staff staff, string InternalStatus, string? MainStatus = null)
        {
            if(app is null || app.Id is 0)
                throw new Exception("AppId can not be null.");

            if(MainStatus is not null)
            {
                app.Status = MainStatus ?? app.Status;
                await _unitOfWork.ApplicationRepository.Update(app);
            }
            
            var appStatus = await _unitOfWork.AppStatusRepository.GetByAppIdSBUId(app.Id, (int)staff.Staff_SBU);
            if (appStatus != null)
            {
                appStatus.Status = MainStatus ?? app.Status;
                appStatus.InternalStatus = InternalStatus;
                appStatus.DeskId = desk != null? desk.DeskID: 0;
                appStatus.UpdatedAt = DateTime.Now;
                await _unitOfWork.AppStatusRepository.Update(appStatus);
            }
            else
            {
                var newStatus = new AppStatus
                {
                    AppId = app.Id,
                    CompanyId = app.CompanyID,
                    FieldId = app.FieldID ?? null,
                    ConcessionId = app.ConcessionID ?? throw new Exception("Concession cannot be null."),
                    SBUId = staff.Staff_SBU,
                    DeskId = desk != null? desk.DeskID: 0,
                    Status = MainStatus ?? app.Status,
                    InternalStatus = InternalStatus
                };
                await _unitOfWork.AppStatusRepository.AddAsync(newStatus);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMainAppStatusOnSubmit(Domain.Entities.Application app, string? Status = null)
        {
            app.Status = Status ?? MAIN_APPLICATION_STATUS.SubmittedByCompany;
            app.SubmittedAt = DateTime.Now;
            app.Submitted = true;

            await _unitOfWork.ApplicationRepository.Update(app);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}