using AutoMapper;
using Backend_UMR_Work_Program.Controllers;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using LinqToDB;

namespace Backend_UMR_Work_Program.Services
{
    public class AppProcessFlowService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly WKP_DBContext _dbContext;
        private readonly PaymentService _paymentService;

        public AppProcessFlowService(IMapper mapper, IConfiguration config, WKP_DBContext dbContext, PaymentService paymentService)
        {
            _mapper = mapper;
            _config = config;
            _dbContext = dbContext;
            _paymentService = paymentService;
        }

        public async Task<bool> SendBackApplicationToCompany(ADMIN_COMPANY_INFORMATION Company, Application app, staff staff, int TypeOfPaymentId, string AmountNGN, string AmountUSD, string comment, string[] selectedTables)
        {
            try
            {
                //Add fee for payment by company
                await _paymentService.AddPayment(new AppPaymentViewModel
                {
                    AppId = app.Id,
                    CompanyNumber = Company.Id,
                    ConcessionId = (int)app.ConcessionID,
                    FieldId = app.FieldID,
                    TypeOfPayment = TypeOfPaymentId,
                    AmountNGN = AmountNGN,
                    AmountUSD = AmountUSD,
                });

                //update application status
                app.Status = GeneralModel.APPLICATION_STATUS.SentBackToCompany;
                app.PaymentStatus = GeneralModel.APPLICATION_STATUS.PaymentPending;
                app.UpdatedAt= DateTime.Now;

                _dbContext.Applications.Update(app);   

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> getTableNames(string[] tableIds)
        {
            try
            {
                string RejectedTables = "";
                if (tableIds.Count() > 0)
                {
                    foreach (var id in tableIds)
                    {
                        int tableID = id != "undefined" ? int.Parse(id) : 0;

                        var getSBU_TablesToDisplay = await _dbContext.Table_Details.Where(x => x.TableId == tableID).FirstOrDefaultAsync();

                        if (getSBU_TablesToDisplay != null)
                            RejectedTables = RejectedTables != "" ? $"{RejectedTables}|{getSBU_TablesToDisplay.TableName}" : getSBU_TablesToDisplay.TableName;

                    }
                }

                return RejectedTables;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ApplicationProccess>> GetApplicationProccessByAction(string processAction)
        {
            try
            {
                return await _dbContext.ApplicationProccesses.Where(x => x.ProcessAction == processAction).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
