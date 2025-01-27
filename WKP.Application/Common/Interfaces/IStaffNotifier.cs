using WKP.Domain.Entities;

namespace WKP.Application.Common.Interfaces
{
    public interface IStaffNotifier
    {
        void Init(
            staff staff,
            Domain.Entities.Application app,
            ADMIN_CONCESSIONS_INFORMATION concession,
            COMPANY_FIELD Field);
        Task SendPushNotification();
        Task SendApprovalNotification();
        Task SendFinalApprovalNotification();
        Task SendFinalRejectionNotification(string comment);
        Task SendReturnNotification();
        Task SendRejectNotification();
        Task SendSubmitNotification();
        Task SendMoveNotification(bool? isSource = false);
    }
}