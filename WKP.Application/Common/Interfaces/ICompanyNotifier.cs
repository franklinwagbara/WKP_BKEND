using WKP.Domain.Entities;

namespace WKP.Application.Common.Interfaces
{
    public interface ICompanyNotifier
    {
        void Init(
            ADMIN_COMPANY_INFORMATION company,
            Domain.Entities.Application app,
            ADMIN_CONCESSIONS_INFORMATION concession,
            COMPANY_FIELD Field);
        Task SendPushNotification();
        Task SendApprovalNotification();
        Task SendReturnNotification();
        Task SendRejectNotification(); 
    }
}