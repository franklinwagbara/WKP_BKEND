using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using static Backend_UMR_Work_Program.Models.GeneralModel;
using Backend_UMR_Work_Program.DTOs;
using Backend_UMR_Work_Program.Models;

namespace Backend_UMR_Work_Program.Services
{
    public class FeeService
    {
        private readonly IMapper _mapper;
        public WKP_DBContext _context;
        private readonly AppSettings _appSettings;
        public IConfiguration _configuration;
        public IHttpContextAccessor _httpContext;

        public FeeService(
            IMapper mapper,
            WKP_DBContext context,
            IConfiguration configuration,
            IHttpContextAccessor httpAccessor,
            IOptions<AppSettings> appsettings,
            HelperService helperService
            )
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
            _httpContext = httpAccessor;
        }

        public async Task<WebApiResponse> GetFees()
        {
            try
            {
                var fees = await _context.Fees.Include(x => x.TypeOfPayment).AsQueryable().ToListAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = fees, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetOtherFees()
        {
            try
            {
                var fees = await _context.Fees.Include(x => x.TypeOfPayment).Where(x => x.TypeOfPayment.Category == PAYMENT_CATEGORY.OtherPayment).ToListAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = fees, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> AddFee(FeeDTO fee)
        {
            try
            {
                var newFee = await _context.Fees.AddAsync(_mapper.Map<Fee>(fee));
                await _context.SaveChangesAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = newFee.Entity, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> DeleteFee(int id)
        {
            try
            {
                var fee = await _context.Fees.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.Fees.Remove(fee);
                await _context.SaveChangesAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = fee, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
    }
}
