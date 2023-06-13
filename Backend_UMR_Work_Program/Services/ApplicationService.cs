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


        public ApplicationService(IMapper mapper, IConfiguration config, WKP_DBContext wKP_DBContext)
        {
            _mapper = mapper;
            _config = config;
            _dbContext = wKP_DBContext;
        }

        public async Task<object> GetSendBackComments(int appId)
        {
            try
            {
                var comments = await _dbContext.ApplicationDeskHistories.Where(x => x.AppId == appId && x.Status == GeneralModel.SentBackToCompany).ToListAsync();
                return comments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
