using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.DTOs;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using DocumentFormat.OpenXml.Bibliography;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Syncfusion.XlsIO.Implementation;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_UMR_Work_Program.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    //[ApiController]
    public class PaymentController : Controller
    {
        private readonly WKP_DBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly PaymentService _paymentService;
        private readonly ApplicationService _applicationService;
        public IHttpContextAccessor _httpContext;
        private readonly AppSettings _appSettings;
        private readonly BlobService _blobService;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);
        private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        public PaymentController(WKP_DBContext context, IConfiguration configuration, 
            IMapper mapper, IHttpContextAccessor httpAccessor, 
            IOptions<AppSettings> appsettings, PaymentService paymentService,
            ApplicationService applicationService, 
            BlobService blobService
            )
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _paymentService = paymentService;
            _applicationService = applicationService;
            _appSettings = appsettings.Value;
            _blobService = blobService;
        }

        [HttpGet("GET_PAYMENT_SUMMARY_SUBMISSION")]
        public async Task<WebApiResponse> GetPaymentSummarySubmission() => await _paymentService.GetPaymentSummarySubmission();

        [HttpGet("GET_EXTRA_PAYMENT_SUMMARY_SUBMISSION")]
        public async Task<WebApiResponse> GetExtraPaymentSummarySubmission() => await _paymentService.GetExtraPaymentSummarySubmission();


        [HttpGet("GET_TYPE_OF_PAYMENTS")]
        public async Task<WebApiResponse> Get_Type_Of_Payments() => await _paymentService.GetTypesOfPayments();

        [HttpPost("GENERATE_RRR")]
        public async Task<WebApiResponse> GenerateRRR(int appId, string amountNGN, string serviceCharge, int concessionId, int year, int? fieldId)
        {
            try
            {
                var rrr = await _paymentService.GenerateRRR(
                    appId, 
                    Convert.ToInt32(WKPCompanyNumber), 
                    Convert.ToDecimal(amountNGN), 
                    serviceCharge, concessionId, year,  
                    fieldId, PAYMENT_CATEGORY.MainPayment);

                return new WebApiResponse { Data = rrr, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }

        }

        [HttpPost("GENERATE_EXTRAPAYMENT_RRR")]
        public async Task<WebApiResponse> GenerateExtraPaymentRRR(int appId, string amountNGN, string serviceCharge, int concessionId, int year, int? fieldId)
        {
            try
            {
                var rrr = await _paymentService.GenerateRRR(
                    appId, Convert.ToInt32(WKPCompanyNumber), 
                    Convert.ToDecimal(amountNGN), 
                    serviceCharge, 
                    concessionId, year, fieldId, 
                    PAYMENT_CATEGORY.OtherPayment);
                return new WebApiResponse { Data = rrr, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }

        }

        [HttpPost("CONFIRM_PAYMENT")]
        public async Task<WebApiResponse> ConfirmPayment(int appId)
        {
            var paymentRes = await _paymentService.ConfirmPayment(appId);

            if (paymentRes.ResponseCode != AppResponseCodes.Success)
                return paymentRes;

            var submitRes = await _applicationService.SubmitApplication(appId);

            if (submitRes.ResponseCode != AppResponseCodes.Success)
                return submitRes;

            paymentRes.Message = submitRes.Message;
            return paymentRes;
        }

        [HttpPost("CREATE_USD_PAYMENT_SUBMISSION")]
        public async Task<WebApiResponse> CreateUSDPayment([FromBody] USDPaymentDTO model)
        {
            model.CompanyNumber = (int)WKPCompanyNumber;
            model.CompanyEmail = WKPCompanyEmail;

            return await _paymentService.CreateUSDPayment(model, PAYMENT_CATEGORY.MainPayment);
        }

        [HttpPost("CONFIRM_USD_PAYMENT_SUBMISSION")]
        public async Task<WebApiResponse> ConfirmUSDPayment([FromForm] USDPaymentDTO model)
        {
            model.CompanyNumber = (int)WKPCompanyNumber;
            model.CompanyEmail = WKPCompanyEmail;

            var file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;

            if (file != null)
            {
                model.PaymentEvidenceFileName = file.FileName;
                model.PaymentEvidenceFilePath = await _blobService.UploadFileBlobAsync(
                    "documents", file.OpenReadStream(),
                    file.ContentType, $"PaymentDocuments/{model.PaymentEvidenceFileName}",
                    model.PaymentEvidenceFileName.ToUpper(), (int)WKPCompanyNumber, int.Parse(model.Year.ToString()));

                return await _paymentService.ConfirmUSDPayment(model, PAYMENT_CATEGORY.MainPayment);
            }
            else return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = "File Not Provided.", StatusCode = ResponseCodes.Badrequest };
        }

        [AllowAnonymous]
        [HttpPost("Remita")]
        public async Task<IActionResult> Remita(int id, RemitaResponse model)
        {
            var payment = await _context.Payments.Where(x => x.OrderId == model.orderId).FirstOrDefaultAsync();
            var app = await _context.Applications.Where(x => x.Id == payment.AppId).FirstOrDefaultAsync();
            var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == payment.ConcessionId).FirstOrDefaultAsync();
            var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefaultAsync();

            var paymenRes = await _paymentService.ConfirmPayment(payment.AppId);

            if(paymenRes.ResponseCode != AppResponseCodes.Success)
                return Redirect($"{_appSettings.LoginUrl}/company/payment-failed/{app.YearOfWKP}/{concession.ConcessionName}/{field.Field_Name}/{paymenRes.Message}");

            var submitRes = await _applicationService.SubmitApplication(payment.AppId);

            if (submitRes.ResponseCode != AppResponseCodes.Success)
                return Redirect($"{_appSettings.LoginUrl}/company/payment-failed/{app.YearOfWKP}/{concession.ConcessionName}/{field.Field_Name}/{submitRes.Message}");

            string fieldName = field == null ? "None" : field.Field_Name;

            return Redirect($"{_appSettings.LoginUrl}/company/payment-successfull/{app.YearOfWKP}/{concession.ConcessionName}/{fieldName}");
        }

        [HttpPost("CONFIRM_APPLICATION_PAYMENT_FROM_COMPANY_DESK")]
        public async Task<WebApiResponse> ConfirmApplicationPaymentFromCompanyDesk(int appId)
        {
            try
            {
                var app = await _context.Applications.Where(x => x.Id == appId).FirstOrDefaultAsync();
                var payment = await _context.Payments.Where(x => x.AppId == app.Id && x.IsConfirmed == false).FirstOrDefaultAsync();

                if (payment == null)
                    return new WebApiResponse { ResponseCode = AppResponseCodes.PaymentDoesNotExist, Message = "Application payment details could not be found.", StatusCode = ResponseCodes.Badrequest };

                if (payment.Currency == CurrencyUSD)
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "The account's action is required for payment processing. Kindly reach out to support for assistance.", StatusCode = ResponseCodes.Success };

                var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == payment.ConcessionId).FirstOrDefaultAsync();
                var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefaultAsync();

                var paymenRes = await _paymentService.ConfirmPayment(payment.AppId);

                if (paymenRes.ResponseCode != AppResponseCodes.Success)
                    return new WebApiResponse { ResponseCode = AppResponseCodes.PaymentDoesNotExist, Message = "Could not verify payment.", StatusCode = ResponseCodes.Badrequest };

                var submitRes = await _applicationService.SubmitApplication(payment.AppId);

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = paymenRes.Message, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = e.Message, StatusCode = ResponseCodes.Badrequest };
            }

        }

        [HttpPost("RESUBMISSION_FOR_NO_FEE")]
        public async Task<IActionResult> ReSubmissionForNoFee(int appId)
        {
            var res = await _paymentService.ReSubmissionForNoFee(appId);

            if (res.ResponseCode != AppResponseCodes.Success)
                return Redirect($"{_appSettings.LoginUrl}/company/payment-failed/{0}/{0}/{0}/{res.Message}");

            return Redirect($"{_appSettings.LoginUrl}/company/payment-successfull/{res.Data}");
        }
    }
}
