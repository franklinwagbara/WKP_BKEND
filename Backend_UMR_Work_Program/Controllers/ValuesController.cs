using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public PaymentController(WKP_DBContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        [HttpGet('GET_TYPE_OF_PAYMENTS')]
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
    }
}
