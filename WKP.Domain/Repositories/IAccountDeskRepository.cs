using WKP.Domain.DTOs.AccountDesk;
using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IAccountDeskRepository: IBaseRepository<AccountDesk>
    {
        public Task<IEnumerable<AccountDeskDTO>> GetAppPaymentsOnStaffDesk(string StaffEmail);
        public Task<IEnumerable<AccountDeskDTO>> GetAppPaymentsOnStaffDesk(int StaffId);
        public Task<IEnumerable<AccountDeskDTO>> GetAppPendingPaymentsOnStaffDesk(string StaffEmail);
        public Task<IEnumerable<AccountDeskDTO>> GetAppPendingPaymentsOnStaffDesk(int StaffId);
        public Task<IEnumerable<AccountDeskDTO>> GetAllPendingAppPayments();
        public Task<IEnumerable<AccountDeskDTO>> GetAllAppPayments();
        public Task<IEnumerable<AccountDeskDTO>> GetAllAppPaymentApprovals();
        public Task<int> GetDeskCount(int StaffId);
        public Task<int> GetProcessingCount(int StaffId);
        public Task<int> GetAllPaymentCounts();
        public Task<int> GetPaymentApprovalCount();
        public Task<int> GetPaymentRejectionCount();
        Task<IEnumerable<object>> GetDeskSummary();
        Task<object?> GetPaymentOnDeskByDeskId(int DeskId);
    }
}