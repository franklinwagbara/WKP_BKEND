using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        
        public PaymentController(WKP_DBContext context, IConfiguration configuration, 
            IMapper mapper, IHttpContextAccessor httpAccessor, 
            IOptions<AppSettings> appsettings, PaymentService paymentService,
            ApplicationService applicationService
            )
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _paymentService = paymentService;
            _applicationService = applicationService;
            _appSettings = appsettings.Value;
        }

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        [HttpGet("GET_TYPE_OF_PAYMENTS")]
        public async Task<object> Get_Type_Of_Payments()
        {
            try
            {
                var res = await _context.TypeOfPayments.ToListAsync();
                return new WebApiResponse { Data = res, ResponseCode = AppResponseCodes.Success, Message="Success", StatusCode=ResponseCodes.Success};
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = "Error: " + ex.Message});                
            }
        }

        [HttpGet("GET_PAYMENT_SUMMARY_SUBMISSION")]
        public async Task<object> GetPaymentSummarySubmission()
        {
            try
            {
                var res = await _paymentService.GetPaymentSummarySubmission();
                return new WebApiResponse { Data = res, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        [HttpPost("GENERATE_RRR")]
        public async Task<object> GenerateRRR(int appId, string amountNGN, string serviceCharge, int concessionId, int year, int? fieldId)
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
                return BadRequest(new { message = "Error : " + ex.Message });
            }

        }

        [HttpPost("GENERATE_EXTRAPAYMENT_RRR")]
        public async Task<object> GenerateExtraPaymentRRR(int appId, string amountNGN, string serviceCharge, int concessionId, int year, int? fieldId)
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
                return BadRequest(new { message = "Error : " + ex.Message });
            }

        }

        [HttpPost("CONFIRM_PAYMENT")]
        public async Task<object> ConfirmPayment(int appId)
        {
            var paymentRes = await _paymentService.ConfirmPayment(appId);
            var submitRes = await _applicationService.SubmitApplication(appId);
                
            paymentRes.Message = submitRes.Message;
            return paymentRes;
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
            var submitRes = await _applicationService.SubmitApplication(payment.AppId);
            return Redirect($"{_appSettings.LoginUrl}/company/payment-successfull/{app.YearOfWKP}/{concession.ConcessionName}/{field.Field_Name}");
        }
    }
}
