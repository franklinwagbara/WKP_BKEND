using Microsoft.EntityFrameworkCore;
using WKP.Domain.DTOs.AccountDesk;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AccountDeskRepository : BaseRepository<AccountDesk>, IAccountDeskRepository
    {
        private readonly WKPContext _context;
        public AccountDeskRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountDeskDTO>> GetAppPaymentsOnStaffDesk(string StaffEmail)
        {
            return await (from accDesk in _context.AccountDesks.Include(x => x.Payment).Include(x => x.Staff)
                                   join app in _context.Applications on accDesk.AppId equals app.Id
                                   where accDesk.Staff.StaffEmail == StaffEmail
                                   select new AccountDeskDTO
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = app.Concession.Concession_Held,
                                       FieldName = app.Field != null ? app.Field.Field_Name : null,
                                       CompanyName = app.Company.COMPANY_NAME,
                                       CompanyEmail = app.Company.EMAIL,
                                       EvidenceFilePath = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFilePath : null,
                                       EvidenceFileName = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFileName : null,
                                       Desk = accDesk,
                                       Payment = accDesk.Payment != null ? accDesk.Payment : null,
                                       Application = app,
                                       Staff = accDesk.Staff,
                                       Concession = app.Concession,
                                       Field = app.Field,
                                       PaymentStatus = accDesk.ProcessStatus,
                                       SubmittedAt = accDesk.CreatedAt
                                   }).ToListAsync();
        }

        public async Task<IEnumerable<AccountDeskDTO>> GetAppPaymentsOnStaffDesk(int StaffId)
        {
            return await (from accDesk in _context.AccountDesks.Include(x => x.Payment).Include(x => x.Staff)
                                   join app in _context.Applications on accDesk.AppId equals app.Id
                                   where accDesk.Staff.StaffID == StaffId
                                   select new AccountDeskDTO
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = app.Concession.Concession_Held,
                                       FieldName = app.Field != null ? app.Field.Field_Name : null,
                                       CompanyName = app.Company.COMPANY_NAME,
                                       CompanyEmail = app.Company.EMAIL,
                                       EvidenceFilePath = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFilePath : null,
                                       EvidenceFileName = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFileName : null,
                                       Desk = accDesk,
                                       Payment = accDesk.Payment != null ? accDesk.Payment : null,
                                       Application = app,
                                       Staff = accDesk.Staff,
                                       Concession = app.Concession,
                                       Field = app.Field,
                                       PaymentStatus = accDesk.ProcessStatus,
                                       SubmittedAt = accDesk.CreatedAt
                                   }).ToListAsync();
        }

        public async Task<IEnumerable<AccountDeskDTO>> GetAppPendingPaymentsOnStaffDesk(string StaffEmail)
        {
            return await (from accDesk in _context.AccountDesks.Include(x => x.Payment).Include(x => x.Staff)
                          join app in _context.Applications on accDesk.AppId equals app.Id
                          where accDesk.Staff.StaffEmail == StaffEmail && accDesk.ProcessStatus == PAYMENT_STATUS.PaymentPending
                          select new AccountDeskDTO
                          {
                              Year = app.YearOfWKP,
                              ReferenceNumber = app.ReferenceNo,
                              ConcessionName = app.Concession.Concession_Held,
                              FieldName = app.Field != null ? app.Field.Field_Name : null,
                              CompanyName = app.Company.COMPANY_NAME,
                              CompanyEmail = app.Company.EMAIL,
                              EvidenceFilePath = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFilePath : null,
                              EvidenceFileName = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFileName : null,
                              Desk = accDesk,
                              Payment = accDesk.Payment != null ? accDesk.Payment : null,
                              Application = app,
                              Staff = accDesk.Staff,
                              Concession = app.Concession,
                              Field = app.Field,
                              PaymentStatus = accDesk.ProcessStatus,
                              SubmittedAt = accDesk.CreatedAt
                          }).ToListAsync();
        }

        public async Task<IEnumerable<AccountDeskDTO>> GetAppPendingPaymentsOnStaffDesk(int StaffId)
        {
            return await (from accDesk in _context.AccountDesks.Include(x => x.Payment).Include(x => x.Staff)
                          join app in _context.Applications on accDesk.AppId equals app.Id
                          where accDesk.Staff.StaffID == StaffId && accDesk.ProcessStatus == PAYMENT_STATUS.PaymentPending
                          select new AccountDeskDTO
                          {
                              Year = app.YearOfWKP,
                              ReferenceNumber = app.ReferenceNo,
                              ConcessionName = app.Concession.Concession_Held,
                              FieldName = app.Field != null ? app.Field.Field_Name : null,
                              CompanyName = app.Company.COMPANY_NAME,
                              CompanyEmail = app.Company.EMAIL,
                              EvidenceFilePath = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFilePath : null,
                              EvidenceFileName = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFileName : null,
                              Desk = accDesk,
                              Payment = accDesk.Payment != null ? accDesk.Payment : null,
                              Application = app,
                              Staff = accDesk.Staff,
                              Concession = app.Concession,
                              Field = app.Field,
                              PaymentStatus = accDesk.ProcessStatus,
                              SubmittedAt = accDesk.CreatedAt
                          }).ToListAsync();
        }

        public async Task<IEnumerable<AccountDeskDTO>> GetAllAppPayments()
        {
            return await (from accDesk in _context.AccountDesks.Include(x => x.Payment).Include(x => x.Staff)
                                   join app in _context.Applications on accDesk.AppId equals app.Id
                                   select new AccountDeskDTO
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = app.Concession.Concession_Held,
                                       FieldName = app.Field != null ? app.Field.Field_Name : null,
                                       CompanyName = app.Company.COMPANY_NAME,
                                       CompanyEmail = app.Company.EMAIL,
                                       EvidenceFilePath = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFilePath : null,
                                       EvidenceFileName = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFileName : null,
                                       Desk = accDesk,
                                       Payment = accDesk.Payment != null ? accDesk.Payment : null,
                                       Application = app,
                                       Staff = accDesk.Staff,
                                       Concession = app.Concession,
                                       Field = app.Field,
                                       PaymentStatus = accDesk.ProcessStatus,
                                       SubmittedAt = accDesk.CreatedAt
                                   }).ToListAsync();
        }

        public async Task<IEnumerable<AccountDeskDTO>> GetAllAppPaymentApprovals()
        {
            return await (from accDesk in _context.AccountDesks.Include(x => x.Payment).Include(x => x.Staff)
                                   join app in _context.Applications on accDesk.AppId equals app.Id
                                   where accDesk.isApproved == true
                                   select new AccountDeskDTO
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = app.Concession.Concession_Held,
                                       FieldName = app.Field != null ? app.Field.Field_Name : null,
                                       CompanyName = app.Company.COMPANY_NAME,
                                       CompanyEmail = app.Company.EMAIL,
                                       EvidenceFilePath = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFilePath : null,
                                       EvidenceFileName = accDesk.Payment != null ? accDesk.Payment.PaymentEvidenceFileName : null,
                                       Desk = accDesk,
                                       Payment = accDesk.Payment != null ? accDesk.Payment : null,
                                       Application = app,
                                       Staff = accDesk.Staff,
                                       Concession = app.Concession,
                                       Field = app.Field,
                                       PaymentStatus = accDesk.ProcessStatus,
                                       SubmittedAt = accDesk.CreatedAt
                                   }).ToListAsync();
        }

        public async Task<int> GetDeskCount(int StaffId)
        {
            return await _context.AccountDesks.Where(x => x.StaffID == StaffId && x.ProcessStatus == PAYMENT_STATUS.PaymentPending).CountAsync();
        }

        public async Task<int> GetProcessingCount(int StaffId)
        {
            return await _context.AccountDesks.Where(x => x.StaffID == StaffId && x.ProcessStatus == PAYMENT_STATUS.PaymentProcessing).CountAsync();
        }

        public async Task<int> GetAllPaymentCounts()
        {
            return await _context.AccountDesks.CountAsync();
        }

        public async Task<int> GetPaymentApprovalCount()
        {
            return await _context.AccountDesks.Where(x => x.isApproved == true).CountAsync();
        }

        public async Task<int> GetPaymentRejectionCount()
        {
            return await _context.AccountDesks.Where(x => x.ProcessStatus == PAYMENT_STATUS.PaymentRejected).CountAsync();
        }

        public async Task<IEnumerable<object>> GetDeskSummary()
        {
            var result = await _context.AccountDesks
                .Include(x => x.Staff)
                .GroupBy(x => x.StaffID)
                .Select(x => new 
                {
                    deskCount = x.Count(
                        x => x.ProcessStatus == PAYMENT_STATUS.PaymentPending
                    ),
                    processingCount = x.Count(
                        x => x.ProcessStatus == PAYMENT_STATUS.PaymentPending
                    ),
                    staff = x.ToList()[0].Staff
                }).ToListAsync();
            return result;
        }

        public async Task<object?> GetPaymentOnDeskByDeskId(int DeskId)
        {
            var result = await _context.AccountDesks
                .Include(x => x.Payment)
                .Include(x => x.Application)
                .Include( x => x.Application.Concession)
                .Include(x => x.Application.Field)
                .Include(x => x.Application.Company)
                .Where(x => x.AccountDeskID == DeskId)
                .Select( s => new 
                {
                    Year = s.Application.YearOfWKP,
                    ReferenceNumber = s.Application.ReferenceNo,
                    ConcessionName = s.Application.Concession != null? s.Application.Concession.ConcessionName: null,
                    FieldName = s.Application.Field != null? s.Application.Field.Field_Name: null,
                    CompanyName = s.Application.Company != null? s.Application.Company.COMPANY_NAME: null,
                    CompanyEmail = s.Application.Company != null? s.Application.Company.EMAIL: null,
                    EvidenceFilePath = s.Payment.PaymentEvidenceFilePath,
                    EvidenceFileName = s.Payment.PaymentEvidenceFileName,
                    Desk = s,
                    Payment = s.Payment,
                    Application = s.Application,
                    Staff = s.Staff,
                    Concession = s.Application.Concession,
                    Field = s.Application.Field,
                    PaymentStatus = s.ProcessStatus,
                    SubmittedAt = s.CreatedAt,
                    CompanyDetails = s
                }).FirstOrDefaultAsync();
            return result;
        }
    }
}