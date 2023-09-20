using AutoMapper;
using Backend_UMR_Work_Program.Common.Implementations;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WKP.Application.Features.Application.Commands.SubmitApplication;
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
        private readonly ISender _mediator;

        public AccountingService(
            IMapper mapper,
            WKP_DBContext context_DBContext,
            IConfiguration configuration,
            IHttpContextAccessor httpAccessor,
            IOptions<AppSettings> appsettings,
            HelperService helperService,
            PaymentService paymentService,
            ApplicationService applicationService,
            ISender mediator
            )
        {
            _mapper = mapper;
            _context = context_DBContext;
            _configuration = configuration;
            _httpContext = httpAccessor;
            _helperService = helperService;
            _paymentService = paymentService;
            _applicationService = applicationService;
            _mediator = mediator;
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
                                   join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                   join stf in _context.staff on accDesk.StaffID equals stf.StaffID
                                   where accDesk.StaffID == staff.StaffID
                                   select new
                                   {
                                       Year = app.YearOfWKP,
                                       ReferenceNumber = app.ReferenceNo,
                                       ConcessionName = app.Concession.Concession_Held,
                                       FieldName = app.Field != null ? app.Field.Field_Name : null,
                                       CompanyName = comp.COMPANY_NAME,
                                       CompanyEmail = comp.EMAIL,
                                       EvidenceFilePath = payment != null ? payment.PaymentEvidenceFilePath : null,
                                       EvidenceFileName = payment != null ? payment.PaymentEvidenceFileName : null,
                                       Desk = accDesk,
                                       Payment = payment != null ? payment : null,
                                       Application = app,
                                       Staff = stf,
                                       Concession = app.Concession,
                                       Field = app.Field,
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

        public async Task<IActionResult> ConfirmUSDPayment(int deskId)
        {
            try
            {
                var desk = await UpdatedAccountDeskToConfirmedPayment(deskId);

                var app = await _context.Applications.Include(x => x.Concession).Include(x => x.Field).Include(x => x.Company).Where(x => x.Id == desk.AppId).FirstOrDefaultAsync();

                app.PaymentStatus = PAYMENT_STATUS.PaymentCompleted;
                _context.Applications.Update(app);
                await _context.SaveChangesAsync();

                var typeOfPayment = await _context.TypeOfPayments.Where(x => x.Id == desk.Payment.TypeOfPaymentId).FirstOrDefaultAsync();

                if(typeOfPayment.Category == PAYMENT_CATEGORY.OtherPayment)
                {
                    var returnedApp = await _context.ReturnedApplications.Where(x => x.AppId == app.Id).FirstOrDefaultAsync();
                    _context.ReturnedApplications.Remove(returnedApp);
                    _context.SaveChanges();

                    //send mail to company
                    string subject = $"{app.YearOfWKP} Re-Submission of WORK PROGRAM application for field - {app.Field?.Field_Name} : {app.ReferenceNo}";
                    string content = $"You have successfully Re-Submitted your WORK PROGRAM application for year {app.YearOfWKP}, and it is currently being reviewed.";
                    var emailMsg = _helperService.SaveMessage(app.Id, Convert.ToInt32(app.Company.Id), subject, content, "Company");
                    var sendEmail = _helperService.SendEmailMessage(app.Company.EMAIL, app.Company.COMPANY_NAME, emailMsg, null);
                    var responseMsg = app.Field != null ? $"{app.YearOfWKP} Application for field {app.Field?.Field_Name} has been re-submitted successfully." : $"{app.YearOfWKP} Application for concession: ({app.Concession.ConcessionName}) has been re-submitted successfully.\nIn the case multiple fields, please also ensure that submissions are made to cater for them.";

                    // return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMsg, StatusCode = ResponseCodes.Success };
                    return SuccessResponse.ResponseObject(null, responseMsg, StatusCodes.Status200OK);
                }
                // var submitRes = await _applicationService.SubmitApplication(desk.AppId);
                var submitRes = await _mediator.Send(new SubmitApplicationCommand(desk.AppId));

                return submitRes.Match(
                        res => SuccessResponse.ResponseObject(res.Result, res.Message),
                        errors => FailResponse.ResponseObject(errors[0])
                    );

                // if (submitRes.ResponseCode != AppResponseCodes.Success)
                //     return submitRes;

                // return submitRes;
            }
            catch (Exception e)
            {
                // return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
                return FailResponse.ResponseObject(null, e.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
