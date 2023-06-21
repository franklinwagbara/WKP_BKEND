using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Backend_UMR_Work_Program.Services
{
    public class PaymentService
    {
        private readonly IMapper _mapper;
        public WKP_DBContext _context;
        private readonly AppSettings _appSettings;
        public IConfiguration _configuration;
        public IHttpContextAccessor _httpContext;
        private string BankName;
        private string AccountNumber;
        private string BankCode;
        private string elpsBase;

        public PaymentService(
            IMapper mapper, 
            WKP_DBContext context_DBContext,
            IConfiguration configuration,
            IHttpContextAccessor httpAccessor,
            IOptions<AppSettings> appsettings)        
        {
            _mapper = mapper;
            _context = context_DBContext;
            _configuration = configuration;
            _httpContext = httpAccessor;
            BankName = $"{_configuration.GetSection("Payment").GetSection("BankName")}";
            AccountNumber = $"{_configuration.GetSection("Payment").GetSection("Account")}";
            BankCode = $"{_configuration.GetSection("Payment").GetSection("BankCode")}";
            elpsBase = $"{_configuration.GetSection("Payment").GetSection("BankCode")}";
            _appSettings = appsettings.Value;
        }

        public async Task<bool> AddPayment(AppPaymentViewModel model)
        {
            try
            {
                await _context.Payments.AddAsync(new Payments
                {
                    AppId = model.AppId,
                    AmountNGN = $"{model.AmountNGN}",
                    ConcessionId = model.ConcessionId,
                    AmountUSD = $"{model.AmountUSD}",
                    CompanyNumber = model.CompanyNumber,
                    FieldId = model.FieldId,
                    Status = GeneralModel.PaymentPending,
                    TransactionDate = DateTime.UtcNow.AddHours(1),
                    TypeOfPaymentId = model.TypeOfPayment,
                    AccountNumber = $"{_configuration.GetSection("Payment").GetSection("Account")}",
                });
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<object> GetPaymentSummarySubmission()
        {
            try
            {
                var fees = await _context.Fees.Include(s => s.TypeOfPayment).Where(x => x.TypeOfPayment.Category == GeneralModel.MainPayment).ToListAsync();

                //Check is there is late payment fine
                var isLateFine = await _context.LateSubmission.Where(x => x.Late == true).FirstOrDefaultAsync();

                if (isLateFine != null && isLateFine.Late == true)
                {
                    var lateFee = await _context.Fees.Include(s => s.TypeOfPayment).Where(x => x.TypeOfPayment.Name.Equals(GeneralModel.LateSubmissionFee)).FirstOrDefaultAsync();
                    if (lateFee != null)
                    {
                        fees.Add(lateFee);
                    }
                }

                return fees;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<string> GenerateRRR(int id, decimal amount, string userId, string serviceCharge, decimal amountDue, string filedname = null) 
        {
            var app = await _context.Applications.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(app != null)
            {
                var company = await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.Id.Equals(app.CompanyID));
                var remita = new
                {
                    serviceTyepId = _configuration.GetSection("Payment").GetSection("serviceTypeIf"),
                    categoryName = "WorkProgram",
                    totalAmount = $"{amount}",
                    payerName = company.COMPANY_NAME,
                    payerEmail = userId,
                    serviceCharge,
                    amountDue = $"{amountDue}",
                    orderId = app.ReferenceNo,
                    returnSuccessUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/Payment/Remita",
                    returnFailureUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/Payment/Remita",
                    returnBankPaymenteUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/Payment/Remita",
                    lineItems = new object[]
                    {
                        new
                        {
                            lineItemId = "1",
                            beneficiaryName = BankName,
                            beneficiaryAccount = AccountNumber,
                            BankCode,
                            benficiaryAmount = $"{amount}",
                            deductFrom = "1"
                        }
                    },
                    documentTypes = (string)null,
                    applicationItems = new object[]
                    {
                        new
                        {
                            name = "WorkProgramme",
                            description = $"Payment for {filedname}",
                            group = "Annual WorkProgramme Payment"
                        }
                    }
                };

                var http = new HttpClient();
                http.BaseAddress = new Uri(_appSettings.elpsBaseUrl);

                var resp = await http.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"api/Payments/{company.ELPS_ID}/{_appSettings.AppEmail}/{MyUtils.ElpsHasher(_appSettings.AppEmail, _appSettings.SecreteKey)}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(remita), Encoding.UTF8, "application/json")
                });

                if (resp.IsSuccessStatusCode)
                {
                    var content = await resp.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                        if (dic != null)
                        {
                            var payment = await _context.Payments.Include("PaymentType").FirstOrDefaultAsync(x => x.AppId.Equals(id) && x.PaymentType.Name.Equals("Main"));
                            if (payment != null)
                            {
                                payment.RRR = $"{dic.GetValueOrDefault("rrr").FirstOrDefault()}";

                                app.Status = GeneralModel.PaymentPending;

                                await _context.SaveChangesAsync();

                                return payment.RRR;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
