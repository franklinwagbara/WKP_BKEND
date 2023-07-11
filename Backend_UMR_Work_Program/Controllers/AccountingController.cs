using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Route("api/[controller]")]
    public class AccountingController: Controller
    {
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly HelperService _helperService;
        private readonly AccountingService _accountingService;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        public AccountingController(WKP_DBContext context, IConfiguration configuration, IMapper mapper, HelperService helperService, AccountingService accountingService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _helperService = helperService;
            _accountingService = accountingService;
        }

        [HttpGet("GET_APP_PAYMENTS_ON_MY_DESK")]
        public async Task<WebApiResponse> GetAppPaymentsOnMyDesk() => await _accountingService.GetAppPaymentsOnMyDesk(WKPCompanyEmail);

        [HttpGet("GET_PAYMENT_ON_DESK")]
        public async Task<WebApiResponse> GetAppPaymentsOnMyDesk(int deskId) => await _accountingService.GetPaymentOnDesk(deskId);

        [HttpGet("CONFIRM_USD_PAYMENT")]
        public async Task<WebApiResponse> ConfirmUSDPayment(int deskId) => await _accountingService.ConfirmUSDPayment(deskId);
    }
}
