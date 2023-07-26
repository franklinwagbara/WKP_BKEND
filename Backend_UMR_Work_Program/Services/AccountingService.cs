using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using LinqToDB;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Syncfusion.XlsIO.Implementation;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Services
{
    public class AccountingService
    {
        private readonly IMapper _mapper;
        public WKP_DBContext _context;
        private readonly AppSettings _appSettings;
        public IConfiguration _configuration;
        public IHttpContextAccessor _httpContext;
        private readonly HelperService _helperService;
        private readonly PaymentService _paymentService;
        private readonly ApplicationService _applicationService;

        public AccountingService(
            IMapper mapper,
            WKP_DBContext context_DBContext,
            IConfiguration configuration,
            IHttpContextAccessor httpAccessor,
            IOptions<AppSettings> appsettings,
            HelperService helperService,
            PaymentService paymentService,
            ApplicationService applicationService
            )
        {
            _mapper = mapper;
            _context = context_DBContext;
            _configuration = configuration;
            _httpContext = httpAccessor;
            _helperService = helperService;
            _paymentService = paymentService;
            _applicationService = applicationService;
        }

        public async Task<WebApiResponse> GetAppPaymentsOnMyDesk(string staffEmail)
        {
            try
            {
                var staff = await _context.staff.Where(x => x.StaffEmail == staffEmail).FirstOrDefaultAsync();

                var desks = await (from accDesk in _context.AccountDesks
                                   join payment in _context.Payments on accDesk.AppId equals payment.AppId into paymentGroup
                                   from payment in paymentGroup.DefaultIfEmpty()
                                   join app in _context.Applications on accDesk.AppId equals app.Id
                                   join conc in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals conc.Consession_Id
                                   join field in _context.COMPANY_FIELDs on app.FieldID equals field.Field_ID into fieldGroup
                                   from field in fieldGroup.DefaultIfEmpty()
                                   join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                   join stf in _context.staff on accDesk.StaffID equals stf.StaffID
                                   where accDesk.StaffID == staff.StaffID
                                   select new
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = conc.ConcessionName,
                                       FieldName = field != null ? field.Field_Name : null,
                                       CompanyName = comp.COMPANY_NAME,
                                       CompanyEmail = comp.EMAIL,
                                       EvidenceFilePath = payment != null? payment.PaymentEvidenceFilePath: null,
                                       EvidenceFileName = payment != null? payment.PaymentEvidenceFileName: null,
                                       Desk = accDesk,
                                       Payment = payment != null ? payment : null,
                                       Application = app,
                                       Staff = stf,
                                       Concession = conc,
                                       Field = field,
                                       PaymentStatus = accDesk.ProcessStatus,
                                       SubmittedAt = accDesk.CreatedAt
                                   }).ToListAsync();

                return new WebApiResponse { Data = desks, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetPaymentOnDesk(int deskId)
        {
            try
            {
                var desks = await (from accDesk in _context.AccountDesks
                                   join payment in _context.Payments on accDesk.AppId equals payment.AppId
                                   join app in _context.Applications on accDesk.AppId equals app.Id
                                   join conc in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals conc.Consession_Id
                                   join field in _context.COMPANY_FIELDs on app.FieldID equals field.Field_ID into fieldGroup
                                   from field in fieldGroup.DefaultIfEmpty()
                                   join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                   join compDetails in _context.ADMIN_COMPANY_DETAILs on comp.EMAIL equals compDetails.EMAIL
                                   join stf in _context.staff on accDesk.StaffID equals stf.StaffID
                                   where accDesk.AccountDeskID == deskId
                                   select new
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = conc.ConcessionName,
                                       FieldName = field.Field_Name,
                                       CompanyName = comp.COMPANY_NAME,
                                       CompanyEmail = comp.EMAIL,
                                       EvidenceFilePath = payment.PaymentEvidenceFilePath,
                                       EvidenceFileName = payment.PaymentEvidenceFileName,
                                       Desk = accDesk,
                                       Payment = payment,
                                       Application = app,
                                       Staff = stf,
                                       Concession = conc,
                                       Field = field,
                                       PaymentStatus = accDesk.ProcessStatus,
                                       SubmittedAt = accDesk.CreatedAt,
                                       CompanyDetails = compDetails
                                   }).FirstOrDefaultAsync();

                return new WebApiResponse { Data = desks, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<AccountDesk> UpdatedAccountDeskToConfirmedPayment(int deskId)
        {
            try
            {
                var desk = await _context.AccountDesks.Where(x => x.AccountDeskID == deskId).FirstOrDefaultAsync();
                var payment = await _context.Payments.Where(x => x.Id == desk.PaymentId).FirstOrDefaultAsync();

                if (desk == null || payment == null)
                    throw new Exception("Payment not on accounts desk.");

                desk.UpdatedAt = DateTime.Now;
                desk.ProcessStatus = PAYMENT_STATUS.PaymentCompleted;
                desk.isApproved = true;

                payment.Status = PAYMENT_STATUS.PaymentCompleted;
                payment.TransactionDate= DateTime.Now;
                payment.TXNMessage = "Confirmed";
                payment.IsConfirmed = true;

                _context.AccountDesks.Update(desk);
                _context.Payments.Update(payment);

                await _context.SaveChangesAsync();

                return desk;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<WebApiResponse> ConfirmUSDPayment(int deskId)
        {
            try
            {
                var desk = await UpdatedAccountDeskToConfirmedPayment(deskId);

                var app = await _context.Applications.Where(x => x.Id == desk.AppId).FirstOrDefaultAsync();

                app.PaymentStatus = PAYMENT_STATUS.PaymentCompleted;
                _context.Applications.Update(app);
                //await _context.SaveChangesAsync();

                var submitRes = await _applicationService.SubmitApplication(desk.AppId);

                if (submitRes.ResponseCode != AppResponseCodes.Success)
                    return submitRes;

                return submitRes;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }
    }
}
