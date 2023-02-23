using AutoMapper;
using Backend_UMR_Work_Program.Controllers;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Services
{
	public class ElpsUtility
	{
		//private  = new WKP_DBContext();
		//private readonly AppSettings _appSettings;
		//= new ();
		private readonly IMapper _mapper;
		HelpersController _helpersController;
		public WKP_DBContext _context;
		public IConfiguration _configuration;
		IHttpContextAccessor _httpContextAccessor;
		public ElpsUtility(WKP_DBContext context, IConfiguration configuration, HelpersController helpersController, IMapper mapper)
		{
			_context = context;
			_configuration = configuration;
			//_appSettings=appSettings;
			_mapper = mapper;
			_helpersController = new HelpersController(_context, _configuration, _httpContextAccessor, _mapper);
		}
		public async Task<WebApiResponse> ValidateLogin(string email, string code, WKP_DBContext _context, AppSettings appSettings, WebApiResponse webApiResponse)
		{
			var company = new ADMIN_COMPANY_INFORMATION();
			var staff = new staff();
			var response = new WebApiResponse();
			try
			{
				if (!string.IsNullOrEmpty(code))
				{
					response = GetCompanyDetailByEmail(email, appSettings, webApiResponse);
					if (response.Message == "SUCCESS")
					{
						var companyDetail = (LpgLicense.Models.CompanyDetail)response.Data;

						company = _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefault(x => x.EMAIL == email);


						if (company == null)
						{
							company = new ADMIN_COMPANY_INFORMATION
							{
								EMAIL = email,
								NAME = companyDetail.name,
								PHONE_NO = companyDetail.contact_Phone,
								ELPS_ID = companyDetail.id,
								Created_by = "System",
								Date_Created = DateTime.UtcNow,
								STATUS_ = "Activated",
								COMPANY_NAME = companyDetail.name,
								
							};

							//company = _mapper.Map<ADMIN_COMPANY_INFORMATION>(newModel);

							var OurCompany = _mapper.Map<ADMIN_COMPANY_INFORMATION_Model>(company);
							var result = await CreateUserNew(OurCompany, _context);
							company.Id = (int)result.Data;
							//await _context.ADMIN_COMPANY_INFORMATIONs.AddAsync(company);

						}

						else
						{
							if (!company.EMAIL.ToLower().Equals(email.ToLower()))
							{
								company.EMAIL = email;
								company.COMPANY_NAME = companyDetail.name;
								company.ELPS_ID = companyDetail.id;
							}

							_context.ADMIN_COMPANY_INFORMATIONs.Update(company);
						}
						var save = await _context.SaveChangesAsync();
					}
					else
					{
						response = GetStaff(email, appSettings, webApiResponse);
						if (response.Message == "SUCCESS")
						{
							var elpsstaff = (StaffResponseDto)response.Data;

							//company = _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefault(x => x.EMAIL == elpsstaff.email);

							staff= await _context.staff.FirstOrDefaultAsync(x => x.StaffEmail==elpsstaff.email);

							if (staff != null)
							{
								if (!staff.StaffEmail.ToLower().Equals(email.ToLower()))
								{
									staff.StaffEmail = email;
									staff.FirstName = elpsstaff.firstName;
									staff.LastName = elpsstaff.lastName;
									//staff.pho
								}
								//user.FirstName = staff.firstName;
								//staff.PHONE = elpsstaff();
								_context.staff.Update(staff);
								var save = await _context.SaveChangesAsync();

								company.Id = staff.AdminCompanyInfo_ID.Value;
                                //await _userManager.UpdateAsync(user);
                            }
						}
					}
					if (response.Message.ToLower().Equals("success"))
					{
						response = new WebApiResponse
						{
							ResponseCode = AppResponseCodes.Success,
							Message = "Successful",
							StatusCode = ResponseCodes.Success,
							Data = company.Id
						};
					}
					else
					{
						response = new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Unable to fetch user details from Celps with the email " + email, StatusCode = ResponseCodes.RecordNotFound };
					}
				}
				else
				{
					company= await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.EMAIL.Equals(email));

					if (company != null)
					{

						response = new WebApiResponse
						{
							ResponseCode = AppResponseCodes.Success,
							Message = "Successful",
							Data = new
							{
								UserId = company.EMAIL,
								//UserType = user.UserType,
								ElpsId = company.ELPS_ID,
								//CaCNumber = user?.Company?.CacNumber,
								CompantName = company.COMPANY_NAME,
								CreatedBy = company.Created_by,
								CreatedOn = company.Date_Created,
								//Status = company.STATUS_,
							},
							StatusCode = ResponseCodes.Success
						};
					}
				}
			}
			catch (Exception ex)
			{

				response = new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Internal error occured " + ex.ToString(), StatusCode = ResponseCodes.InternalError };

			}
			return response;
		}

		public static WebApiResponse GetCompanyDetailByEmail(string email, AppSettings _appSettings, WebApiResponse webApiResponse)
		{
			try
			{
				var encrpt = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
				var apiHash = MyUtils.GenerateSha512(encrpt);
				var request = new RestRequest("api/company/{compemail}/{email}/{apiHash}", Method.Get);
				request.AddUrlSegment("compemail", email);
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
					webApiResponse.Message = "SUCCESS";
					webApiResponse.Data = JsonConvert.DeserializeObject<LpgLicense.Models.CompanyDetail>(response.Content);
				}
			}
			catch (Exception ex)
			{
				//_generalLogger.LogRequest($"{"Last Exception =>" + ex.Message}{" - "}{DateTime.Now}", true, directory);

				webApiResponse.Message = ex.Message;
			}
			finally
			{
				//_generalLogger.LogRequest($"{"About to Return with Message => " + webApiResponse.Message}{" - "}{DateTime.Now}", false, directory);

			}
			return webApiResponse;
		}

		public static WebApiResponse GetStaff(string email, AppSettings _appSettings, WebApiResponse webApiResponse)
		{
			try
			{
				var encrpt = $"{_appSettings.AppEmail}{_appSettings.SecreteKey}";
				var apiHash = MyUtils.GenerateSha512(encrpt);
				var request = new RestRequest($"/api/Accounts/Staff/{email}/{_appSettings.AppEmail}/{apiHash}", Method.Get);
				;

				var client = new RestClient(_appSettings.elpsBaseUrl);
				//_generalLogger.LogRequest($"{"About to GetCompanyDetail On Elps with Email => "}{" "}{" - "}{DateTime.Now}", false, directory);
				RestResponse response = client.Execute(request);
				//_generalLogger.LogRequest($"{"Response Exception =>" + response.ErrorException + "\r\nResponse Status =>" + response.ResponseStatus + "\r\nStatus Code =>" + response.StatusCode}{" "}{" - "}{DateTime.Now}", false, directory);
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
					webApiResponse.Data = JsonConvert.DeserializeObject<StaffResponseDto>(response.Content);
					webApiResponse.Message = "SUCCESS";
				}
			}
			catch (Exception ex)
			{
				//_generalLogger.LogRequest($"{"Last Exception =>" + ex.ToString()}{" - "}{DateTime.Now}", true, directory);
				webApiResponse.Message = ex.Message;
			}
			finally
			{
				//_generalLogger.LogRequest($"{"About to Return with Message => " + webApiResponse.Message}{" - "}{DateTime.Now}", true, directory);

			}

			return webApiResponse;
		}


		public async Task<WebApiResponse> CreateUserNew(ADMIN_COMPANY_INFORMATION_Model userModel, WKP_DBContext _context)
		{

			try
			{
				var checkUser = (from c in _context.ADMIN_COMPANY_INFORMATIONs
								 where c.EMAIL.ToLower() == userModel.EMAIL.ToLower()
								 select c).FirstOrDefault();

				if (checkUser != null)
				{
					bool deleted = checkUser.DELETED_STATUS == "DELETED" ? true : false;
					bool activated = checkUser.STATUS_ == "Activated" ? true : false;

					string errMsg = $"User details with '{userModel.EMAIL}' is already existing on the portal.";

					if (deleted == true)
						errMsg = $"User details with '{userModel.EMAIL}' is already existing, but the account has been deleted on the portal, kindly restore account information.";

					if (activated != true)
						errMsg = $"User details with '{userModel.EMAIL}' is already existing, but the account has been de-activated on the portal, kindly activate account information.";

					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + errMsg, StatusCode = ResponseCodes.Failure };

				}
				else
				{
					var data = _mapper.Map<ADMIN_COMPANY_INFORMATION>(userModel);

					data.EMAIL = userModel.EMAIL.ToLower();
					//data.PASSWORDS = _helpersController.Encrypt(userModel.PASSWORDS);
					data.STATUS_ = "Activated";
					data.Date_Created = DateTime.Now;
					data.Created_by = userModel.EMAIL;
					data.NAME = userModel.NAME.Trim();
					data.COMPANY_NAME = userModel.COMPANY_NAME.Trim();
					await _context.ADMIN_COMPANY_INFORMATIONs.AddAsync(data);
					int save = await _context.SaveChangesAsync();

					var CompanyInfoId = data.Id;



					if (save > 0)
					{
						string companyAccessCode = string.Empty;
					repeat:
						var accessCode = GENERATE_ACCESS_CODE(data.COMPANY_NAME);

						var getAccessCodeFromDb = await _context.ADMIN_COMPANY_CODEs.FirstOrDefaultAsync(x => x.CompanyCode == accessCode);

						if (getAccessCodeFromDb == null)
						{
							companyAccessCode = accessCode;
						}
						else
						{
							goto repeat;
						}


						//Added company Code info
						var CompanyInfoCode = new ADMIN_COMPANY_CODE
						{
							Date_Created = DateTime.Now,
							Date_Updated = DateTime.Now,
							Created_by = userModel.EMAIL,
							CompanyNumber = CompanyInfoId,
							CompanyCode = companyAccessCode,
							Email = userModel.EMAIL.ToLower().Trim(),
							CompanyName = userModel.COMPANY_NAME,
							GUID = Guid.NewGuid().ToString()
						};
						await _context.ADMIN_COMPANY_CODEs.AddAsync(CompanyInfoCode);

						var newCompany = await _context.ADMIN_COMPANY_INFORMATIONs.FindAsync(CompanyInfoId);
						newCompany.COMPANY_ID = companyAccessCode;
						_context.ADMIN_COMPANY_INFORMATIONs.Update(newCompany);

						int saved = await _context.SaveChangesAsync();

						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{userModel.EMAIL} has been added successfully", Data = CompanyInfoId, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this user.", StatusCode = ResponseCodes.Failure };
					}
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		public string GENERATE_ACCESS_CODE(string companyName)
		{
			try
			{
				var strIntitials = string.Empty;

				var companyNames = companyName.Split(' ');

				//check if company name has more than one string

				if (companyNames.Length <= 1)
				{
					strIntitials = companyName.Substring(0, 4);
				}
				else
				{
					foreach (var item in companyNames)
					{
						strIntitials += item[0];
					}
				}

				//var rndmize=new Randomize
				var rnd = new Random();

				var firstRndNumber = rnd.Next(0, 9999).ToString().PadLeft(4, '0');


				var accessCaode = strIntitials.ToUpper() + firstRndNumber;


				return accessCaode;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
