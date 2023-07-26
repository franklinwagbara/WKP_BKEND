using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.DTOs;
using Backend_UMR_Work_Program.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Route("api/[controller]")]
    public class FeeController: Controller
    {
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly FeeService _feeService;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        public FeeController(WKP_DBContext context, IConfiguration configuration, IMapper mapper, HelperService helperService, AccountingService accountingService, FeeService feeService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _feeService = feeService;
        }

        [HttpGet("GET_FEES")]
        public async Task<WebApiResponse> GetFees() => await _feeService.GetFees();

        [HttpPost("ADD_FEE")]
        public async Task<WebApiResponse> AddFee([FromBody]FeeDTO fee) => await _feeService.AddFee(fee);

        [HttpGet("GET_OTHER_FEES")]
        public async Task<WebApiResponse> GetOtherFees() => await _feeService.GetOtherFees();

        [HttpDelete("DELETE_FEE")]
        public async Task<WebApiResponse> DeleteFee(int id) => await _feeService.DeleteFee(id);
    }
}
