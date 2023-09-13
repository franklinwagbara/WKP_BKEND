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

        public UnitOfWork(WKPContext context)
        {
            _context = context;
            AdminCompanyInformationRepository = new AdminCompanyInformationRepository(context);
            ApplicationRepository = new ApplicationRepository(context); 
            DeskRepository = new DeskRepository(context);
            FeeRepository = new FeeRepository(context);
            PermitApprovalRepository = new PermitApprovalRepository(context);
            ReturnedApplicationRepository = new ReturnedApplicationRepository(context);
            SBURepository = new SBURepository(context);
            StaffRepository = new StaffRepository(context);
            TypeOfPaymentRepository = new TypeOfPaymentRepository(context);
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    _context.Dispose();
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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}