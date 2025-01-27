using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue = false;
        private WKPContext _context;
        private IDbContextTransaction? _transaction;

        public IAdminCompanyInformationRepository AdminCompanyInformationRepository { get; private set; }
        public IApplicationRepository ApplicationRepository { get; private set; }
        public IDeskRepository DeskRepository { get; private set; }
        public IFeeRepository FeeRepository { get; private set; }
        public IPermitApprovalRepository PermitApprovalRepository { get; private set; }
        public IReturnedApplicationRepository ReturnedApplicationRepository { get; private set; }
        public ISBURepository SBURepository { get; private set; }
        public IStaffRepository StaffRepository { get; private set; }
        public ITypeOfPaymentRepository TypeOfPaymentRepository { get; private set; }
        public IAuditRepository AuditRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IAppProcessFlowRepo AppProcessFlowRepo { get; private set; } 
        public IAppDeskHistoryRepository AppDeskHistoryRepository { get; private set; }
        public IAppSBUApprovalRepository AppSBUApprovalRepository { get; private set; }
        public IAppStatusRepository AppStatusRepository { get; private set; }
        public ITableDetailRepository TableDetailRepository { get; private set; }
        public IAccountDeskRepository AccountDeskRepository { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }
        public ISubmissionRejectionRepository SubmissionRejectionRepository { get; private set;}
        public IAdminCompanyDetailsRepository AdminCompanyDetailsRepository { get; private set; }
        public ICompanyProfileRepository CompanyProfileRepository { get; private set; }

        public UnitOfWork(WKPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
            AdminCompanyInformationRepository = new AdminCompanyInformationRepository(context);
            ApplicationRepository = new ApplicationRepository(context); 
            DeskRepository = new DeskRepository(context);
            FeeRepository = new FeeRepository(context);
            PermitApprovalRepository = new PermitApprovalRepository(context);
            ReturnedApplicationRepository = new ReturnedApplicationRepository(context);
            SBURepository = new SBURepository(context);
            StaffRepository = new StaffRepository(context);
            TypeOfPaymentRepository = new TypeOfPaymentRepository(context);
            AuditRepository = new AuditRepository(context);
            MessageRepository = new MessageRepository(context); 
            RoleRepository = new RoleRepository(context);   
            AppProcessFlowRepo = new AppProcessFlowRepo(context);
            AppDeskHistoryRepository = new AppDeskHistoryRepository(context);
            AppSBUApprovalRepository = new AppSBUApprovalRepository(context);
            AppStatusRepository = new AppStatusRepository(context);
            TableDetailRepository = new TableDetailRepository(context);
            AccountDeskRepository = new AccountDeskRepository(context);
            PaymentRepository = new PaymentRepository(context);
            SubmissionRejectionRepository = new SubmissionRejectionRepository(context);
            AdminCompanyDetailsRepository = new AdminCompanyDetailsRepository(context);
            CompanyProfileRepository = new CompanyProfileRepository(context);
        }

        public DatabaseFacade ContextDatabase() => _context.Database;

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task ExecuteTransaction(Func<Task> func)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                BeginTransaction();
                await func();
                await Commit();
            });
        }

        public async Task<bool> Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                _transaction?.Commit();
                return true;
            }
            catch (System.Exception)
            {
                _transaction?.Rollback();
                return false;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected async virtual Task Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    _transaction?.Dispose();
                    await _context.DisposeAsync();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public async void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            await Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}