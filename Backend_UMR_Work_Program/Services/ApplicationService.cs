using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_UMR_Work_Program.Services
{
    public class ApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly WKP_DBContext _dbContext;
        private readonly HelperService _helperService;


        public ApplicationService(IMapper mapper, IConfiguration config, WKP_DBContext wKP_DBContext)
        {
            _mapper = mapper;
            _config = config;
            _dbContext = wKP_DBContext;
            _helperService = new HelperService(mapper, config, wKP_DBContext);
        }

        public async Task<object> GetSendBackComments(int appId)
        {
            try
            {
                var comments = await _dbContext.ApplicationDeskHistories.Include(x => x.Staff).Include(x => x.Company).Where(x => x.AppId == appId && x.Status != null && x.Status == GeneralModel.SentBackToCompany).OrderByDescending(x => x.ActionDate).ToListAsync();
                return comments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCommentToApplication(int appId, int? staffId, string? status, string comment, string? selectedTables, bool? actionByCompany, int? companyId)
        {
            try
            {
                _helperService.SaveApplicationHistory(appId, staffId, status, comment, selectedTables, actionByCompany, companyId, GeneralModel.AddAComment);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
