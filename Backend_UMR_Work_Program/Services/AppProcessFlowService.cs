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
        private readonly HelpersController _helpersController;
        private readonly PaymentService _paymentService;

        public AppProcessFlowService(IMapper mapper, IConfiguration config, WKP_DBContext dbContext, HelpersController helpersController, PaymentService paymentService)
        {
            _mapper = mapper;
            _config = config;
            _dbContext = dbContext;
            _helpersController = helpersController;
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
                    ConcessionId = app.ConcessionID,
                    FieldId = app.FieldID,
                    TypeOfPayment = TypeOfPaymentId,
                    AmountNGN = AmountNGN,
                    AmountUSD = AmountUSD,
                });

                //update application status
                app.Status = GeneralModel.SentBackToCompany;
                app.UpdatedAt= DateTime.Now;

                _dbContext.Applications.Update(app);    

                await _dbContext.SaveChangesAsync();
                _helpersController.SaveHistory(app.Id, staff.StaffID, GeneralModel.SentBackToCompany, comment);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
