using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly PaymentService _paymeService;
        public IHttpContextAccessor _httpContext;
        private readonly AppSettings _appSettings;
        
        public PaymentController(WKP_DBContext context, IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpAccessor, IOptions<AppSettings> appsettings)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _paymeService = new PaymentService(mapper, context, configuration, httpAccessor, appsettings);
        }

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

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
                var res = await _paymeService.GetPaymentSummarySubmission();
                return new WebApiResponse { Data = res, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
    }
}
