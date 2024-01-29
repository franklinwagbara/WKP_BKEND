using System.Text;
using ErrorOr;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;

namespace WKP.Infrastructure.GeneralServices
{
    public class ElpsService : IElpsService
    {
        private readonly AppSettings _appSettings;
        private readonly IElpsConnect _elpsConnect;
        public ElpsService(IOptions<AppSettings> options, IElpsConnect elpsConnect)
        {
            _appSettings = options.Value;
            _elpsConnect = elpsConnect;
        }

        public async Task<ErrorOr<ElpsCompanyDetail>> GetCompanyDetailsByEmail(string Email)
        {
            try
            {
                if(_appSettings.AppEmail == null)
                    throw new Exception("AppEmail must be provided.");
                
                var url = "api/company/{compemail}/{email}/{apiHash}";
                var secret = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
                var hashValue = secret.GenerateSha512();
                var request = new RestRequest(url, Method.Get);
                request.AddUrlSegment("compemail", Email);
                request.AddUrlSegment("email", _appSettings.AppEmail);
                request.AddUrlSegment("apiHash", hashValue);

                var resultStr = await _elpsConnect.Get(request);
                var result = JsonConvert.DeserializeObject<ElpsCompanyDetail>(resultStr);
                return result;
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + " +++ " + e.StackTrace + " ~~~ " + e.InnerException?.ToString());
            }
        }

        public async Task<ErrorOr<CompanyProfile>> GetCompanyProfile(string Email)
        {
            if (_appSettings.AppEmail == null)
                throw new Exception("AppEmail must be provided.");

            var url = "api/company/{compemail}/{email}/{apiHash}";
            var secret = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
            var hashValue = secret.GenerateSha512();
            var request = new RestRequest(url, Method.Get);
            request.AddUrlSegment("compemail", Email);
            request.AddUrlSegment("email", _appSettings.AppEmail);
            request.AddUrlSegment("apiHash", hashValue);

            var resultStr = await _elpsConnect.Get(request);
            var result = JsonConvert.DeserializeObject<CompanyProfile>(resultStr);
            return result;
        }

        public async Task<ErrorOr<ElpsStaffDetail>> GetStaffDetailByEmail(string Email)
        {
            try
            {
                if(_appSettings.AppEmail == null)
                    throw new Exception("AppEmail must be provided.");
                
                var url = "api/Accounts/Staff/{compemail}/{email}/{apiHash}";
                var secret = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
                var hashValue = secret.GenerateSha512();
                var request = new RestRequest(url, Method.Get);
                request.AddUrlSegment("compemail", Email);
                request.AddUrlSegment("email", _appSettings.AppEmail);
                request.AddUrlSegment("apiHash", hashValue);

                var resultStr = await _elpsConnect.Get(request);
                var result = JsonConvert.DeserializeObject<ElpsStaffDetail>(resultStr);
                return result;
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + " +++ " + e.StackTrace + " ~~~ " + e.InnerException?.ToString());
            }
        }

        public async Task<ErrorOr<ElpsCompanyDetail>> UpdateCompanyDetails(ElpsCompanyModel Model, string Email)
        {
            try
            {
                if (_appSettings.AppEmail == null)
                    throw new Exception("AppEmail must be provided.");

                var url = "api/company/{compemail}/{email}/{apiHash}";
                var secret = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
                var hashValue = secret.GenerateSha512();
                var request = new RestRequest(url, Method.Get);
                request.AddUrlSegment("compemail", Email);
                request.AddUrlSegment("email", _appSettings.AppEmail);
                request.AddUrlSegment("apiHash", hashValue);

                var resultStr = await _elpsConnect.Get(request);
                var result = JsonConvert.DeserializeObject<ElpsCompanyDetail>(resultStr);
                return result;
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + " +++ " + e.StackTrace + " ~~~ " + e.InnerException?.ToString());
            }
        }

        // private readonly AppSettings _appSettings;
        // private readonly IConfiguration _configuration;

        // public ElpsService(IConfiguration configuration)
        // {
        //     _appSettings = new AppSettings();
        //     _configuration = configuration;

        //     _appSettings.elpsBaseUrl = $"{_configuration.GetSection("AppSettings").GetSection("elpsBaseUrl").Value}";
        //     _appSettings.AppEmail = $"{_configuration.GetSection("AppSettings").GetSection("AppEmail").Value}";
        // }

        // public Task UpdateCompanyDetails(ElpsCompanyModel model, string email)
        // {
        // 	var content = CallElps("/api/Company/Edit/", HttpMethod.Put,
        // 		new
        // 		{
        // 			company = model,
        // 			companyMedicals = (string)null,
        // 			companyExpatriateQuotas = (string)null,
        // 			companyNsitfs = (string)null,
        // 			companyProffessionals = (string)null,
        // 			companyTechnicalAgreements = (string)null
        // 		});
        // 	return null;
        // }

        // public Task UpdateCompanyNameAndEmail(ElpsCompanyModel model, string email)
        // {
        // 	// var content = CallElps("/api/Company/Edit/", HttpMethod.Put,
        // 	// 	new
        // 	// 	{
        // 	// 		company = model,
        // 	// 		companyMedicals = (string)null,
        // 	// 		companyExpatriateQuotas = (string)null,
        // 	// 		companyNsitfs = (string)null,
        // 	// 		companyProffessionals = (string)null,
        // 	// 		companyTechnicalAgreements = (string)null
        // 	// 	});
        // 	// if (!string.IsNullOrEmpty(content))
        // 	// {
        // 		var company = model.Stringify().Parse<ElpsCompanyModel>();
        // 		if (company != null)
        // 		{
        // 			var res = UpdateCompanyNameEmail(new
        // 			{
        // 				Name = company.name,
        // 				RC_Number = company.rC_Number,
        // 				Business_Type = company.business_Type,
        // 				emailChange = true,
        // 				CompanyId = company.id,
        // 				NewEmail = email
        // 			});
        // 			// if (!string.IsNullOrEmpty(res))
        // 			// 	return company.Stringify().Parse<object>();
        // 		}
        // 	// }
        // 	return null;
        // }

        // public string UpdateCompanyNameEmail(object model)
        // {
        // 	var content = CallElps("/api/Accounts/ChangeEmail/", HttpMethod.Post, model);
        // 	if (!string.IsNullOrEmpty(content))
        // 		return content;

        // 	return null;
        // }

        private string CallElps(string requestUri, HttpMethod method, object body = null)
        {
            var resp = new HttpResponseMessage();
            if (body != null)
                resp = Utils.Send(
                    _appSettings.elpsBaseUrl,
                    new HttpRequestMessage(method, $"{requestUri}{_appSettings.AppEmail}/{HttpHash()}")
                    {
                        Content = new StringContent(body.Stringify(), Encoding.UTF8, "application/json")
                    }).Result;
            else
                resp = Utils.Send(
                    _appSettings.elpsBaseUrl,
                    new HttpRequestMessage(method, $"{requestUri}{_appSettings.AppEmail}/{HttpHash()}") { }).Result;

            if (resp.IsSuccessStatusCode)
            {
                var result = resp.Content.ReadAsStringAsync().Result;
                //_context.Logs.Add(new Log
                //{
                //    Action = $"HTTP Request - {method.Method}",
                //    Date = DateTime.UtcNow.AddHours(1),
                //    Error = result
                //});
                return result;
            }

            //_context.Logs.Add(new Log
            //{
            //    Action = $"HTTP Request - {method.Method} \n {resp.RequestMessage.Stringify()}",
            //    Date = DateTime.UtcNow.AddHours(1),
            //    Error = resp.ReasonPhrase
            //});

            return null;
        }

        private string HttpHash() => $"{_appSettings.AppEmail}{_appSettings.SecreteKey}".GenerateSha512();

        public Task UpdateCompanyNameAndEmail(ElpsCompanyModel model, string email)
        {
            throw new NotImplementedException();
        }

        Task IElpsService.UpdateCompanyDetails(ElpsCompanyModel model, string email)
        {
            throw new NotImplementedException();
        }
    }
}