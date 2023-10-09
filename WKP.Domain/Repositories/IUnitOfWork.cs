using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WKP.Domain.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        public IAdminCompanyInformationRepository AdminCompanyInformationRepository { get; }
        public IApplicationRepository ApplicationRepository { get; }
        public IDeskRepository DeskRepository { get; }
        public IFeeRepository FeeRepository { get; }
        public IPermitApprovalRepository PermitApprovalRepository { get; }
        public IReturnedApplicationRepository ReturnedApplicationRepository { get; }
        public ISBURepository SBURepository { get; }
        public IStaffRepository StaffRepository { get; }
        public ITypeOfPaymentRepository TypeOfPaymentRepository { get; }
        public IAuditRepository AuditRepository { get; }
        public IMessageRepository MessageRepository { get;}
        public IRoleRepository RoleRepository { get; }
        public IAppProcessFlowRepo AppProcessFlowRepo { get; }  
        public IAppDeskHistoryRepository AppDeskHistoryRepository { get; }
        public IAppSBUApprovalRepository AppSBUApprovalRepository { get; }
        public IAppStatusRepository AppStatusRepository { get; }
        public ITableDetailRepository TableDetailRepository {get; }
        public IAccountDeskRepository AccountDeskRepository { get; }
        public IPaymentRepository PaymentRepository { get; }


        public Task ExecuteTransaction(Func<Task> func);
        DatabaseFacade ContextDatabase();
        void BeginTransaction();
        Task<bool> Commit();
        void Rollback();
        Task<int> SaveChangesAsync();
    }
}