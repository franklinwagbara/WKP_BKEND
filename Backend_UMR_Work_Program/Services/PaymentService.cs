using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.DTOs;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
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
        private string Bank;
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
            Bank = $"{_configuration.GetSection("Payment").GetSection("Bank").Value}";
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
                    OrderId = model.OrderId,
                    Currency= model.Currency,
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

        public async Task<WebApiResponse> GetPaymentSummarySubmission()
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

                return new WebApiResponse { Data = fees, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
            
        }

        public async Task<WebApiResponse> GetExtraPaymentSummarySubmission(int concessionId, int fieldId)
        {
            try
            {
                var payment = await _context.Payments.Include(x => x.PaymentType).Where(x => x.ConcessionId == concessionId && x.FieldId == fieldId && x.Status == PAYMENT_STATUS.PaymentPending).FirstOrDefaultAsync();

                if(payment == null)
                    return new WebApiResponse { ResponseCode = AppResponseCodes.PaymentDoesNotExist, Message = "Error: Payment detail not found", StatusCode = ResponseCodes.RecordNotFound };

                var fees = await _context.Fees.Include(s => s.TypeOfPayment).Where(x => x.TypeOfPayment.Id == payment.Id).ToListAsync();

                if(fees.Count == 1 && fees[0].TypeOfPayment.Name == TYPE_OF_FEE.NoFee)
                    return new WebApiResponse { Data = null, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
                else
                    return new WebApiResponse { Data = fees, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return new WebApiResponse {ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }

        }

        public async Task<WebApiResponse> GetTypesOfPayments()
        {
            try
            {
                var res = await _context.TypeOfPayments.ToListAsync();
                return new WebApiResponse { Data = res, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
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
                                    payment.IsConfirmed = true;
                                    
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
                                            ServiceCharge = serviceCharge,
                                            Currency = GeneralModel.Currency.NGN
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

        public async Task<bool> DropAppOnAccountDesk(Payments payment)
        {
            try
            {
                var foundOnAccountDesk = await _context.AccountDesks.Where(x => x.PaymentId == payment.Id).FirstOrDefaultAsync();

                if(foundOnAccountDesk != null) { return true; }

                var targetDesk = await _helperService.GetNextAccountDesk();

                targetDesk.AppId = payment.AppId;
                targetDesk.PaymentId = payment.Id;
                targetDesk.isApproved = false;
                targetDesk.LastJobDate = DateTime.Now;
                targetDesk.ProcessStatus = PAYMENT_STATUS.PaymentPending;

                _context.AccountDesks.Add(targetDesk);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<WebApiResponse> ConfirmUSDPayment(USDPaymentDTO model, string? paymentCategory)
        {
            try
            {
                paymentCategory ??= PAYMENT_CATEGORY.MainPayment;

                var app = await _context.Applications.Where(
                    x => x.CompanyID == model.CompanyNumber
                    && x.ConcessionID == model.ConcessionId
                    && x.FieldID == model.FieldId).FirstOrDefaultAsync();

                if (app == null)
                {
                    app = await _helperService.AddNewApplication(
                        model.CompanyNumber, model.CompanyEmail,
                        model.Year, model.ConcessionId,
                        model.FieldId, MAIN_APPLICATION_STATUS.NotSubmitted,
                        PAYMENT_STATUS.PaymentPending, null, false);
                }

                var paymentExist = await _context.Payments.Where(x => x.AppId == app.Id && x.OrderId == app.ReferenceNo).FirstOrDefaultAsync();

                if (paymentExist == null) return new WebApiResponse { ResponseCode = AppResponseCodes.PaymentDoesNotExist, Message = $"This payment record does not exist.", StatusCode = ResponseCodes.Badrequest };

                paymentExist.PaymentEvidenceFileName = model.PaymentEvidenceFileName;    
                paymentExist.PaymentEvidenceFilePath = model.PaymentEvidenceFilePath;

                _context.Payments.Update(paymentExist);
                await _context.SaveChangesAsync();

                //Drop the application on accounts department desk
                await DropAppOnAccountDesk(paymentExist);

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Payment Evidence was successfully uploaded!", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse {ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message}", StatusCode = ResponseCodes.InternalError };
            }

        }
                
        public async Task<WebApiResponse> CreateUSDPayment(USDPaymentDTO model, string? paymentCategory)
        {
            try
            {
                paymentCategory ??= PAYMENT_CATEGORY.MainPayment;

                var app = await _context.Applications.Where(
                    x => x.CompanyID == model.CompanyNumber
                    && x.ConcessionID == model.ConcessionId
                    && x.FieldID == model.FieldId).FirstOrDefaultAsync();

                if (app == null)
                {
                    app = await _helperService.AddNewApplication(
                        model.CompanyNumber, model.CompanyEmail,
                        model.Year, model.ConcessionId,
                        model.FieldId, MAIN_APPLICATION_STATUS.NotSubmitted,
                        PAYMENT_STATUS.PaymentPending, null, false);
                }

                var paymentExist = await _context.Payments.Where(x => x.AppId == app.Id && x.OrderId == app.ReferenceNo).FirstOrDefaultAsync();

                if (paymentExist != null) return new WebApiResponse { Data = new { OrderId = app.ReferenceNo, AccountNumber = AccountNumber, AccountName = BankName, BankName = Bank }, ResponseCode = AppResponseCodes.PaymentAlreadyExists, Message = $"This payment record has already been created.", StatusCode = ResponseCodes.Success };

                var mainPaymentType = await _context.TypeOfPayments.Where(x => x.Category == paymentCategory).FirstOrDefaultAsync();
                var newPayment = new AppPaymentViewModel()
                {
                    AppId = app.Id,
                    CompanyNumber = app.CompanyID,
                    ConcessionId = (int)app.ConcessionID,
                    FieldId = app.FieldID,
                    TypeOfPayment = mainPaymentType.Id,
                    AmountNGN = "",
                    AmountUSD = model.AmountUSD,
                    OrderId = app.ReferenceNo,
                    ServiceCharge = "0",
                    Currency = Currency.USD
                };

                var res = await AddPayment(newPayment);

                return new WebApiResponse { 
                    Data = new { OrderId = app.ReferenceNo, AccountNumber = AccountNumber, AccountName = BankName,  BankName = Bank}, 
                    ResponseCode = AppResponseCodes.Success, Message = "USD Payment was successfully created!", 
                    StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message}", StatusCode = ResponseCodes.InternalError };
            }

        }

        public async Task<WebApiResponse> ReSubmissionForNoFee(int appId)
        {
            try
            {
                var app = await _context.Applications.Where(x => x.Id == appId).FirstOrDefaultAsync();
                var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefaultAsync();
                var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefaultAsync();

                app.PaymentStatus = PAYMENT_STATUS.PaymentCompleted;
                var rApp = await _context.ReturnedApplications.Where(x => x.AppId == appId).FirstOrDefaultAsync();
                _context.ReturnedApplications.Remove(rApp);
                await _context.SaveChangesAsync();

                //return Redirect($"{_appSettings.LoginUrl}/company/payment-successfull/{app.YearOfWKP}/{concession.ConcessionName}/{field.Field_Name}");
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = $"{concession.ConcessionName}/{field.Field_Name}", Message = "Application was successfully resubmitted!", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message}", StatusCode = ResponseCodes.InternalError };
            }

        }

        public bool IsAllPaymentsConfirmed(List<Payments> payments)
        {
            foreach(var p in payments)
            {
                if(p.IsConfirmed == false) return false;
            }

            return true;
        }
    }
}
