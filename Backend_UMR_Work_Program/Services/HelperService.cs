using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Backend_UMR_Work_Program.Services
{
    public class HelperService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly WKP_DBContext _dbContext;

        public HelperService(IMapper mapper, IConfiguration configuration, WKP_DBContext dbContext)
        {
            _mapper = mapper;
            _config = configuration;
            _dbContext = dbContext;
        }

        public async void SaveApplicationHistory(int appId, int staffId, string status, string comment, string selectedTables)
        {
            try
            {
                var staff = await (from stf in _dbContext.staff where stf.StaffID == staffId select stf).FirstOrDefaultAsync();

                var appDeskHistory = new ApplicationDeskHistory()
                {
                    AppId = appId,
                    StaffID = staffId,
                    Comment = comment == null ? "" : comment,
                    SelectedTables = selectedTables,
                    CreatedAt = DateTime.Now,
                    ActionDate = DateTime.Now,
                };

                await _dbContext.ApplicationDeskHistories.AddAsync(appDeskHistory);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
