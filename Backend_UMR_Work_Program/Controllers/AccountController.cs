using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;
using static Backend_UMR_Work_Program.Models.ViewModel;
//using static Backend_UMR_Work_Program.Helpers.GeneralClass;

namespace Backend_UMR_Work_Program.Controllers
{
	// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private Account _account;
		public WKP_DBContext _context;
		public IConfiguration _configuration;
		HelpersController _helpersController;
		IHttpContextAccessor _httpContextAccessor;
		private readonly AppSettings _appSettings;
		WebApiResponse webApiResponse = new WebApiResponse();
		private readonly IMapper _mapper;
		public ElpsUtility _elpsObj;
        private readonly HelperService _helperService;

        public AccountController(WKP_DBContext context, IConfiguration configuration,Account account, IMapper mapper, IOptions<AppSettings> appSettings, ElpsUtility elpsObj, HelperService helperService)
		{
			//_httpContextAccessor = httpContextAccessor;
			_appSettings=appSettings.Value;
			_account = account;
			_context = context;
			_configuration = configuration;
			_mapper = mapper;
			_elpsObj = elpsObj;
            _helperService = helperService;
        }

		[HttpGet("GetElpsStaff")]
		public object GetElpsStaff()
		{
			try
			{
				var encrpt = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
				var apiHash = MyUtils.GenerateSha512(encrpt);
				var request = new RestRequest("api/Accounts/Staff/{email}/{apiHash}", Method.Get);
				request.AddUrlSegment("email", _appSettings.AppEmail);
				request.AddUrlSegment("apiHash", apiHash);

				var client = new RestClient(_appSettings.elpsBaseUrl);

				RestResponse response = client.Execute(request);
				if (response.ErrorException != null)
				{
					webApiResponse.Message = response.ErrorMessage;
				}

				else if (response.ResponseStatus != ResponseStatus.Completed)
				{
					webApiResponse.Message = response.ResponseStatus.ToString();
				}

				else if (response.StatusCode != HttpStatusCode.OK)
				{
					webApiResponse.Message = response.StatusCode.ToString();
				}
				else
				{
					webApiResponse.Data = JsonConvert.DeserializeObject<List<StaffResponseDto>>(response.Content);
					webApiResponse.Message = "SUCCESS";
				}
			}
			catch (Exception ex)
			{
				webApiResponse.Message = ex.Message;
			}

			return webApiResponse;
		}

		[HttpGet("GetData")]
		public object GetData()
		{
			try
			{
				var table = _account.GetData();
				string JSONString = string.Empty;
				JSONString = JsonConvert.SerializeObject(table);
				return JSONString;
			}
			catch (Exception ex)
			{
				return new { message = ex.Message, trace = ex.StackTrace };
			}
		}
		[HttpPost("login-redirect")]
		public async Task<IActionResult> Login([FromForm] LoginParam loginParam)
		{
			var email = loginParam.Email;
			var code = loginParam.Code;
			var login = await _elpsObj.ValidateLogin(email, code, _context, _appSettings, webApiResponse);
			if (login.ResponseCode.Equals("00"))
				return Redirect($"{_appSettings.LoginUrl}/login?id={login.Data}");

			return Json(login);
		}

		[HttpPost("Authenticate")]
		public async Task<IActionResult> Authenticate([FromBody] Logine logine)
		{
			try
			{
				var tokenData = await _account.isAutheticate(logine.email, logine.password);
				string JSONString = string.Empty;
				JSONString = JsonConvert.SerializeObject(tokenData);
				return Ok(tokenData);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		[HttpGet("AuthenticateById")]
		public async Task<IActionResult> AuthenticateById(int Id)
		{
			try
			{
				var tokenData = await _account.AutheticateById(Id);
				string JSONString = string.Empty;
				JSONString = JsonConvert.SerializeObject(tokenData);
				return Ok(tokenData);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}


		[HttpGet("VerifyCompanyCode")]
		public async Task<IActionResult> VerifyCompanyCode(string companyCode)
		{
			try
			{
				var isAvailable = await _account.VerifyCompanyCode(companyCode);
				return Ok(isAvailable);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}


		[HttpPost("CheckNewPinCode")]
		public async Task<IActionResult> CheckNewPinCode(string oldCompanyCode, string email, string newCompanyCode)
		{
			try
			{
				var isAvailable = await _account.CheckNewPinCode(oldCompanyCode, email, newCompanyCode);
				return Ok(isAvailable);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		[HttpGet("GetCompanyResource")]
		public async Task<IActionResult> GetCompanyResource(string companyCode)
		{
			try
			{
				var isAvailable = await _account.GetCompanyResource(companyCode);
				return Ok(isAvailable);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		[HttpPost("CreateCompanyResource")]
		public async Task<IActionResult> CreateCompanyResource([FromBody] CreateUser user)
		{
			try
			{
				var isAvailable = await _account.CheckIfUserExistBeforeCreating(user.companyName, user.companyCode, user.name, user.designation, user.phone, user.email, user.password);
				return Ok(isAvailable);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		[HttpPost("DeleteCompanyResource")]
		public async Task<IActionResult> DeleteCompanyResource(string id, string companyCode)
		{
			try
			{
				var isAvailable = await _account.DeleteUser(companyCode, id);
				return Ok(isAvailable);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		[HttpPost("ReturnPasswordInfo")]
		public async Task<IActionResult> ReturnPasswordInfo(string email)
		{
			try
			{
				var isAvailable = await _account.ReturnPasswordInfo(email);
				return Ok(isAvailable);
			}
			catch (Exception e)
			{
				return Ok(e.Message);
			}
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("ResetPassword")]
		public async Task<WebApiResponse> ResetPassword(string currentPassword, string newPassword)
		{
			try
			{
				string encryptCP = _helperService.Encrypt(currentPassword);
				string email = User.FindFirstValue(ClaimTypes.Email);
				var getUser = (from u in _context.ADMIN_COMPANY_INFORMATIONs where u.EMAIL == email.Trim() && u.PASSWORDS == encryptCP select u).FirstOrDefault();
				if (getUser != null)
				{
					getUser.PASSWORDS = _helperService.Encrypt(newPassword);
					getUser.UPDATED_BY = getUser.Id.ToString();
					getUser.UPDATED_DATE = DateTime.Now.ToString();

					if (await _context.SaveChangesAsync() > 0)
					{

						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Password updated successfully", StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while updating this password.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Unable to fetch user details from Work Program.", StatusCode = ResponseCodes.RecordNotFound };
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
			}
		}

		[HttpPost("Decrypt")]
		public string Decrypt(string text)
		{
			var data = _account.Decrypt(text);
			return data;
		}

	}
}
