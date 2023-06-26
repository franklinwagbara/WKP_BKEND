using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using LinqToDB;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Services
{
    public class WorkProgrammeService
    {
        private readonly IMapper _mapper;
        public readonly WKP_DBContext _context;
        private readonly AppSettings _appSettings;
        public IConfiguration _configuration;
        public IHttpContextAccessor _httpContext;
        private readonly HelperService _helperService;

        public WorkProgrammeService(IMapper mapper, WKP_DBContext context, AppSettings appSettings, IConfiguration configuration, IHttpContextAccessor httpContext, HelperService helperService)
        {
            _mapper = mapper;
            _context = context;
            _appSettings = appSettings;
            _configuration = configuration;
            _httpContext = httpContext;
            _helperService = helperService;
        }

        public async Task<WebApiResponse> CanDeleteConcession(int concessionId)
        {
            try
            {
                var foundConcession = await _context.Applications.Where(x => x.ConcessionID == concessionId).FirstOrDefaultAsync();

                if (foundConcession != null)
                    return new WebApiResponse { Data = new { canDeleteConcession = false }, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
                else return new WebApiResponse { Data = new { canDeleteConcession = true }, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> CanDeleteField(int fieldId)
        {
            try
            {
                var foundConcession = await _context.Applications.Where(x => x.FieldID == fieldId).FirstOrDefaultAsync();

                if (foundConcession != null)
                    return new WebApiResponse { Data = new { canDeleteField = false }, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
                else return new WebApiResponse { Data = new { canDeleteField = true }, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }
    }
}
