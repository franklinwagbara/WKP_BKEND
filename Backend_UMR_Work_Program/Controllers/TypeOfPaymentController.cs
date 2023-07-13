using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Route("api/[controller]")]
    public class TypeOfPaymentController: Controller
    {
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly TypeOfPaymentService _typeOfPaymentService;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        public TypeOfPaymentController(WKP_DBContext context, IConfiguration configuration, IMapper mapper, TypeOfPaymentService typeOfPaymentService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _typeOfPaymentService = typeOfPaymentService;
        }


        [HttpGet("GET_TYPE_OF_PAYMENTS")]
        public async Task<WebApiResponse> GetTypeOfPayments() => await _typeOfPaymentService.GetTypeOfPayment();
    }
}
