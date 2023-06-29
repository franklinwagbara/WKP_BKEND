using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using static Backend_UMR_Work_Program.Models.GeneralModel;

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
        private readonly HelperService _helperService;

        public PaymentService(
            IMapper mapper, 
            WKP_DBContext context_DBContext,
            IConfiguration configuration,
            IHttpContextAccessor httpAccessor,
            IOptions<AppSettings> appsettings,
            HelperService helperService
            )        
        {
            _mapper = mapper;
            _context = context_DBContext;
            _configuration = configuration;
            _httpContext = httpAccessor;
            _helperService = helperService;

            BankName = $"{_configuration.GetSection("Payment").GetSection("BankName").Value}";
            AccountNumber = $"{_configuration.GetSection("Payment").GetSection("Account").Value}";
            BankCode = $"{_configuration.GetSection("Payment").GetSection("BankCode").Value}";
            elpsBase = $"{_configuration.GetSection("Payment").GetSection("elpsBaseUrl").Value}";
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
                    Status = PAYMENT_STATUS.PaymentPending,
                    TransactionDate = DateTime.UtcNow.AddHours(1),
                    TypeOfPaymentId = model.TypeOfPayment,
                    AccountNumber = AccountNumber,
                    ServiceCharge = model.ServiceCharge,
                    OrderId = model.OrderId
                });
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<string> UpdatePaymentAfterRRRGeneration(string rrr, string transactionId, Application app, string orderId)
        {
            try
            {
                var payment = await _context.Payments.Include(
                    x => x.PaymentType)
                    .FirstOrDefaultAsync(
                        x => x.AppId == app.Id && 
                        x.OrderId == orderId);

                //var payment = await _context.Payments.Include(
                //    x => x.PaymentType)
                //    .FirstOrDefaultAsync(
                //        x => x.AppId == app.Id &&
                //        x.PaymentType.Category == GeneralModel.APPLICATION_STATUS.MainPayment);

                if (payment != null)
                {
                    payment.RRR = rrr;
                    payment.TransactionId = transactionId;
                    payment.TransactionDate = DateTime.Now;
                    payment.Currency = Currency.NGN;
                    payment.OrderId = orderId;
                    app.PaymentStatus = PAYMENT_STATUS.PaymentPending;

                    await _context.SaveChangesAsync();
                    return payment.RRR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public async Task<object> GetPaymentSummarySubmission()
        {
            try
            {
                var fees = await _context.Fees.Include(s => s.TypeOfPayment).Where(x => x.TypeOfPayment.Category == PAYMENT_CATEGORY.MainPayment).ToListAsync();

                //Check if there is late payment fine
                var lateFine = await _context.LateSubmission.Where(x => x.Late == true).FirstOrDefaultAsync();

                if (lateFine != null && lateFine.Late == true)
                {
                    var lateFee = await _context.Fees.Include(s => s.TypeOfPayment).Where(x => x.TypeOfPayment.Name.Equals(TYPE_OF_FEE.LateSubmissionFee)).FirstOrDefaultAsync();
                    if (lateFee != null)
                    {
                        if (!fees.Contains(lateFee))
                        {
                            fees.Add(lateFee);
                        }
                    }
                }

                return fees;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<WebApiResponse> ConfirmPayment(int appId)
        {
            try
            {
                var payments = await _context.Payments.Where(p => p.AppId == appId).ToListAsync();
                var payment = payments.Where(p => p.Status == PAYMENT_STATUS.PaymentPending).FirstOrDefault();

                var app = await _context.Applications.Where(a => a.Id == appId).FirstOrDefaultAsync();

                if (payment != null && payment.Status != PAYMENT_STATUS.PaymentCompleted && !string.IsNullOrEmpty(payment.RRR))
                {
                    using (var http = new HttpClient())
                    {
                        http.BaseAddress = new Uri(_appSettings.elpsBaseUrl);

                        var appHash = MyUtils.ElpsHasher(_appSettings.AppEmail, _appSettings.SecreteKey).ToLower();

                        var resp = await http.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/Payment/checkifpaid?id=r{payment.RRR}"));

                        if (resp.IsSuccessStatusCode)
                        {
                            var content = await resp.Content.ReadAsStringAsync();

                            if(content != null)
                            {
                                var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

                                if ((!string.IsNullOrEmpty(dic.GetValueOrDefault("message").ToString()) && dic.GetValueOrDefault("message").ToString().Equals("successful"))
                                   || (!string.IsNullOrEmpty(dic.GetValueOrDefault("status").ToString()) && dic.GetValueOrDefault("status").ToString().Equals("00")))
                                {
                                    payment.Status = PAYMENT_STATUS.PaymentCompleted;
                                    payment.TransactionDate = Convert.ToDateTime(dic.GetValueOrDefault("transactiontime"));
                                    payment.AppReceiptId = dic.GetValueOrDefault("appreceiptid");
                                    payment.TXNMessage = "Confirmed";
                                    
                                    app.PaymentStatus = PAYMENT_STATUS.PaymentCompleted;

                                    _context.Payments.Update(payment);
                                    _context.Applications.Update(app);

                                    await _context.SaveChangesAsync();

                                    return new WebApiResponse
                                    {
                                        ResponseCode = AppResponseCodes.Success,
                                        Data = new
                                        {
                                            AppReference = app.ReferenceNo,
                                            AmmountNGN = payment.AmountNGN.ToString(),
                                            AmmountUSD = payment.AmountUSD.ToString(),
                                            ServiceCharge = payment.ServiceCharge,
                                            RRR = payment.RRR,
                                            TotalAmountNGN = (payment.ServiceCharge + payment.AmountNGN).ToString(),
                                            TotalAmountUSD = (payment.ServiceCharge + payment.AmountUSD).ToString(),
                                            payment.Status,
                                        },
                                        Message = "Payment Confirmation was Successful.",
                                        StatusCode = ResponseCodes.Success
                                    };
                                }
                                else
                                {
                                    return new WebApiResponse
                                    {
                                        ResponseCode = AppResponseCodes.TransactionFailed,
                                        Data = new
                                        {
                                            AppReference = app.ReferenceNo,
                                            AmmountNGN = payment.AmountNGN.ToString(),
                                            AmmountUSD = payment.AmountUSD.ToString(),
                                            ServiceCharge = payment.ServiceCharge,
                                            RRR = payment.RRR,
                                            TotalAmountNGN = (payment.ServiceCharge + payment.AmountNGN).ToString(),
                                            TotalAmountUSD = (payment.ServiceCharge + payment.AmountUSD).ToString(),
                                            payment.Status,
                                        },
                                        Message = "Failed",
                                        StatusCode = ResponseCodes.InternalError
                                    };
                                }
                            }
                        }
                        else
                        {
                            return new WebApiResponse
                            {
                                ResponseCode = AppResponseCodes.TransactionFailed,
                                Data = new
                                {
                                    AppReference = app.ReferenceNo,
                                    AmmountNGN = payment.AmountNGN.ToString(),
                                    AmmountUSD = payment.AmountUSD.ToString(),
                                    ServiceCharge = payment.ServiceCharge,
                                    RRR = payment.RRR,
                                    TotalAmountNGN = (payment.ServiceCharge + payment.AmountNGN).ToString(),
                                    TotalAmountUSD = (payment.ServiceCharge + payment.AmountUSD).ToString(),
                                    payment.Status,
                                },
                                Message = "Failed",
                                StatusCode = ResponseCodes.Badrequest
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Internal error occured " + ex.ToString(), StatusCode = ResponseCodes.InternalError };
            }

            return new WebApiResponse();
        }

        public async Task<string> GenerateRRR(int appId, int companyId, decimal amountNGN, string serviceCharge, int concessionId, int year, int? fieldId = null, string? paymentCategory=null)
        {
            try
            {
                paymentCategory ??= PAYMENT_CATEGORY.MainPayment;

                if (string.IsNullOrEmpty(serviceCharge))
                    serviceCharge = "0";

                var app = await _context.Applications.FirstOrDefaultAsync(x => x.Id.Equals(appId));
                var company = await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.Id.Equals(companyId));

                if (app == null)
                {
                    app = await _context.Applications.FirstOrDefaultAsync(x => x.CompanyID == companyId && x.YearOfWKP == year && x.ConcessionID == concessionId && x.FieldID == fieldId);

                    if (app == null)
                    {
                        app = await _helperService.AddNewApplication(
                            companyId, company.EMAIL, year,
                            concessionId, fieldId, MAIN_APPLICATION_STATUS.NotSubmitted,
                            PAYMENT_STATUS.PaymentPending, null, false
                            ) as Application;
                    }
                }

                if (app != null)
                {
                    string orderId = null;

                    if (paymentCategory == PAYMENT_CATEGORY.OtherPayment)
                        orderId = _helperService.Generate_Reference_Number();
                    else
                        orderId = app.ReferenceNo;

                    var remitaPayload = _helperService.buildRemitaPayload(company, app, amountNGN, serviceCharge,  orderId);

                    using (var http = new HttpClient())
                    {
                        http.BaseAddress = new Uri(_appSettings.elpsBaseUrl);

                        var appHash = MyUtils.ElpsHasher(_appSettings.AppEmail, _appSettings.SecreteKey).ToLower();

                        HttpResponseMessage resp = null;

                        if(paymentCategory == PAYMENT_CATEGORY.MainPayment)
                        {
                            //Generate RRR for main payments
                            resp = await http.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"api/Payments/{company.ELPS_ID}/{_appSettings.AppEmail}/{appHash}")
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(remitaPayload), Encoding.UTF8, "application/json")
                            });
                        }
                        else
                        {
                            //Generate RRR for extra or other payments
                            resp = await http.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"api/Payments/ExtraPayment/{company.ELPS_ID}/{_appSettings.AppEmail}/{appHash}")
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(remitaPayload), Encoding.UTF8, "application/json")
                            });
                        }

                        if (resp.IsSuccessStatusCode)
                        {
                            var content = await resp.Content.ReadAsStringAsync();
                            if (!string.IsNullOrEmpty(content))
                            {
                                var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                                if (dic != null)
                                {
                                    var rrr = await UpdatePaymentAfterRRRGeneration($"{dic.GetValueOrDefault("rrr")}"
                                        , $"{dic.GetValueOrDefault("transactionId")}", app, orderId);

                                    if (rrr != null)
                                    {
                                        return rrr;
                                    }
                                    else
                                    {
                                        var mainPaymentType = await _context.TypeOfPayments.Where(x => x.Category == paymentCategory).FirstOrDefaultAsync();
                                        var newPayment = new AppPaymentViewModel()
                                        {
                                            AppId = app.Id,
                                            CompanyNumber = app.CompanyID,
                                            ConcessionId = (int)app.ConcessionID,
                                            FieldId = app.FieldID,
                                            TypeOfPayment = mainPaymentType.Id,
                                            AmountNGN = amountNGN.ToString(),
                                            AmountUSD = "",
                                            OrderId = orderId,
                                            ServiceCharge = serviceCharge
                                        };

                                        var res = await AddPayment(newPayment);

                                        rrr = await UpdatePaymentAfterRRRGeneration($"{dic.GetValueOrDefault("rrr")}"
                                                , $"{dic.GetValueOrDefault("transactionId")}", app, orderId);

                                        if (res == true && rrr != null)
                                        {
                                            return rrr;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                throw new Exception("Unable to generate RRR.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
