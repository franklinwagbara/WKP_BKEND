using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend_UMR_Work_Program.Controllers
{
    public class BaseController: Controller
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

        public BaseController(WKP_DBContext context, IConfiguration configuration, IMapper mapper, HelperService helperService, AccountingService accountingService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _helperService = helperService;
            _accountingService = accountingService;
        }
    }
}
