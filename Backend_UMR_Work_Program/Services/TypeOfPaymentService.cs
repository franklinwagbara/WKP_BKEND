using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web.Providers.Entities;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Services
{
    public class TypeOfPaymentService
    {
        private Account _account;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        
        public TypeOfPaymentService(WKP_DBContext context, IConfiguration configuration, IMapper mapper, HelperService helperService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<WebApiResponse> GetTypeOfPayment()
        {
            try
            {
                var types = await _context.TypeOfPayments.ToListAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = types, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
    }
}
