using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Syncfusion.XlsIO;
using System.Data;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]

	public class AdminController : Controller
	{
		private Account _account;
		public WKP_DBContext _context;
		public IConfiguration _configuration;
		HelpersController _helpersController;
		IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;
		RestSharpServices _restSharpServices = new RestSharpServices();

		public AdminController(WKP_DBContext context, IConfiguration configuration, HelpersController helpersController, IMapper mapper)
		{
			_context = context;
			_configuration = configuration;
			_mapper = mapper;
			_helpersController = new HelpersController(_context, _configuration, _httpContextAccessor, _mapper);
		}
		private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
		private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
		private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
		private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

		#region Company Codes

		[HttpGet("GET_COMPANYCODES")]
		public async Task<WebApiResponse> Get_CompanyCodes()
		{
			try
			{
				var getCodes = await (from c in _context.ADMIN_COMPANY_CODEs
									  select c).ToListAsync();

				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = getCodes, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		[HttpGet("GET_COMPANYCODE_UPDATE")]
		public async Task<WebApiResponse> Get_CompanyCodeUpdate(int Id)
		{
			try
			{
				var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.Id == Id select c).FirstOrDefaultAsync();

				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = getCode, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		[HttpPost("POST_COMPANYCODESTATUS_UPDATE")]
		public async Task<WebApiResponse> Get_CompanyCodeStatusUpdate(int Id, string Status)
		{
			try
			{
				var getCode = (from c in _context.ADMIN_COMPANY_CODEs where c.Id == Id select c).FirstOrDefault();
				if (getCode != null)
				{
					getCode.IsActive = Status;
					await _context.SaveChangesAsync();

					var getCCode = (from c in _context.ADMIN_COMPANY_CODEs where c.Id == Id select c).FirstOrDefault();
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = getCCode, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : Company code details was not found.", StatusCode = ResponseCodes.Badrequest };
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		//[HttpPost("UPLOAD_COMPANYCODE2"), DisableRequestSizeLimit]
		//public async Task<WebApiResponse> Upload_CompanyCode2(string CompanyName, string CompanyCode)
		//{

		//    try
		//    {
		//        int save = 0;
		//        List<string> companyCodes = new List<string> { CompanyName, CompanyCode };
		//        //List<string> companyCodes = new List<string> { CompanyName, CompanyCode, CompanyEmail };
		//        foreach (var companyCode in companyCodes)
		//        {
		//            var getCode = (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == CompanyCode && c.IsActive == "YES" select c).FirstOrDefault();
		//            if (getCode == null)
		//            {
		//                var company = (from c in _context.ADMIN_COMPANY_INFORMATIONs
		//                               where c.NAME.ToLower() == CompanyName.ToLower() /*|| c.EMAIL.ToLower() == CompanyEmail.ToLower()*/
		//                               select c).FirstOrDefault();
		//                if (company != null)
		//                {
		//                    getCode.CompanyName = CompanyName;
		//                    getCode.Created_by = WKPCompanyEmail;
		//                    getCode.CompanyCode = CompanyCode;
		//                    getCode.IsActive = "YES";
		//                    getCode.Date_Created = DateTime.Now;
		//                    await _context.ADMIN_COMPANY_CODEs.AddAsync(getCode);
		//                    save = await _context.SaveChangesAsync();
		//                }
		//            }
		//        }
		//        if (save > 0)
		//        {
		//            var getCodes = (from c in _context.ADMIN_COMPANY_CODEs select c).ToList();
		//            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = getCodes, StatusCode = ResponseCodes.Success };
		//        }
		//        else
		//        {
		//            return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : Company code details was not found.", StatusCode = ResponseCodes.Badrequest };
		//        }
		//    }
		//    catch (Exception e)
		//    {
		//        return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

		//    }
		//}





		#endregion

		#region Company Code

		[HttpPost("UPLOAD_COMPANYCODE"), DisableRequestSizeLimit]
		public async Task<WebApiResponse> Upload_CompanyCode([FromForm] dynamic dell)
		{
			int save = 0;
			var excelFile = Request.Form.Files[0];
			try
			{
				using (Stream inputStream = excelFile.OpenReadStream())
				{
					using (ExcelEngine excelEngine = new ExcelEngine())
					{
						IApplication application = excelEngine.Excel;
						IWorkbook workbook = application.Workbooks.Open(inputStream);
						IWorksheet worksheet = workbook.Worksheets[0];

						DataTable dt = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
						List<ADMIN_COMPANY_CODE> codeList = new List<ADMIN_COMPANY_CODE>();

						foreach (DataRow row in dt.Rows)
						{


							var Name_of_company = row["CompanyName"].ToString().Replace("'", "").ToUpper().Trim();
							Name_of_company = Regex.Replace(Name_of_company, @"\s+", " ", RegexOptions.Multiline);

							string CompanyCode = row["CompanyCode"].ToString().Replace("'", "").ToUpper().Trim();


							var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == CompanyCode && c.IsActive == "YES" select c).FirstOrDefaultAsync();
							if (getCode == null)
							{
								//var company = (from c in _context.ADMIN_COMPANY_INFORMATIONs
								//               where c.NAME.ToLower() == CompanyName.ToLower() /*|| c.EMAIL.ToLower() == CompanyEmail.ToLower()*/
								//               select c).FirstOrDefault();
								ADMIN_COMPANY_CODE data = new ADMIN_COMPANY_CODE();

								data.CompanyName = Name_of_company;
								data.Created_by = WKPCompanyEmail;
								data.CompanyCode = CompanyCode;
								//data.CompanyNumber = 
								data.IsActive = "YES";
								data.Date_Created = DateTime.Now;
								codeList.Add(data);
							}
						}
						await _context.ADMIN_COMPANY_CODEs.AddRangeAsync(codeList);
						save = await _context.SaveChangesAsync();
						if (save > 0)
						{
							var getCodes = (from c in _context.ADMIN_COMPANY_CODEs select c).ToList();
							return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = getCodes, StatusCode = ResponseCodes.Success };
						}
						else
						{
							return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : Company code may already exist.", StatusCode = ResponseCodes.Badrequest };
						}
					}

				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };
			}

		}


		[HttpGet("GET_COMPANY_CODES")]
		public async Task<WebApiResponse> GetAllCompanyCodes()
		{
			try
			{
				var companycodes = await _context.ADMIN_COMPANY_CODEs.ToListAsync();
				var codeModel = new CompanyCodeModel();
				if (companycodes.Any()) codeModel = _mapper.Map<CompanyCodeModel>(companycodes);

				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = codeModel, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };
			}
		}


		// [HttpGet("UPDATE_COMPANY_CODES")]
		// public async Task<WebApiResponse> UpdateCompanyCodes(int Id)
		// {

		//     try
		//     {
		//         var companycode = _context.ADMIN_COMPANY_CODEs.FirstOrDefault(x => x.Id == Id);

		//         if (companycode != null)
		//         {
		//             var companyCodeModel = _mapper.Map<CompanyCodeModel>(companycode);
		//                 return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Company Code has been updated successfully", Data = companyCodeModel, StatusCode = ResponseCodes.Success };

		//         }
		//     }
		//     catch (Exception e)
		//     {
		//         return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

		//     }

		//     return null;
		// }


		[HttpPut("UPDATE_COMPANY_CODES")]
		public async Task<WebApiResponse> UpdateCompanyCodes(int Id, string name, string status)
		{

			try
			{
				var companycode = _context.ADMIN_COMPANY_CODEs.FirstOrDefault(x => x.Id==Id);

				if (companycode != null)
				{
					companycode.IsActive =status;
					companycode.CompanyName = name;
					companycode.Updated_by = WKPCompanyEmail;
					companycode.Date_Updated= DateTime.Now;

					var companycodeModel = _mapper.Map<CompanyCodeModel>(companycode);

					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Company Code has been updated successfully", Data = companycodeModel, StatusCode = ResponseCodes.Success };
					}
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
			return null;

		}


		[HttpPut("UpdateCompanyCodesFromCompanyInfo")]
		public async Task<WebApiResponse> UpdateCompanyCodesFromCompanyInfo(string email)
		{

			try
			{
				//var Id = 0;
				var companyCode = 0;

				var getCompanyCodes = await _context.ADMIN_COMPANY_CODEs.FirstOrDefaultAsync(x => x.Email==email);

				if (getCompanyCodes != null)
				{
					var getCompanyInfo = await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.EMAIL.ToLower().Trim()==email.ToLower().Trim());

					if (getCompanyInfo != null)
					{
						companyCode=getCompanyInfo.Id;
					}
				}

				getCompanyCodes.CompanyNumber=companyCode;
				_context.ADMIN_COMPANY_CODEs.Update(getCompanyCodes);
				int save = await _context.SaveChangesAsync();
				if (save > 0)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Company Code has been updated successfully", Data = getCompanyCodes, StatusCode = ResponseCodes.Success };
				}
				//}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
			return null;

		}


		#endregion

		#region User Administration
		[HttpGet("GET_ELPS_STAFF")]
		public async Task<WebApiResponse> GetAllElpsStaff()
		{
			var response = _restSharpServices.Response("api/Accounts/Staff/{email}/{apiHash}");

			if (response.Result.ErrorException != null)
			{
				return new WebApiResponse
				{
					Data = _restSharpServices.ErrorResponse(response.Result),
				};
			}
			else
			{
				return new WebApiResponse
				{
					Data = JsonConvert.DeserializeObject<List<LpgLicense.Models.Staff>>(response.Result.Content),
				};
			}
		}

		[HttpGet("GET_USERS")]
		public async Task<WebApiResponse> Get_Users()
		{
			try
			{
				var companyInformation = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
												where c.COMPANY_NAME != GeneralModel.Admin && c.DELETED_STATUS == null
												select c).ToListAsync();
				var staffInformation = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
											  where c.COMPANY_NAME == GeneralModel.Admin && c.DELETED_STATUS == null
											  select c).ToListAsync();
				var userRoles = await _context.ROLES_s.ToListAsync();
				var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

				var returnData = new UserModel()
				{
					companiesList = companyInformation,
					staffList = staffInformation,
					roles = userRoles,
					sbus = SBUs
				};

				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = returnData, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		[HttpGet("GET_COMPANIES")]
		public async Task<WebApiResponse> Get_Companies()
		{
			try
			{
				var companyInformation = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
												where c.COMPANY_NAME != GeneralModel.Admin && c.DELETED_STATUS == null
												select c).ToListAsync();


				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = companyInformation, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		
		//Added by Musa
		[AllowAnonymous]
		[HttpPost("CREATE_USER_NEW")]
		public async Task<WebApiResponse> CreateUserNew([FromBody] ADMIN_COMPANY_INFORMATION_Model userModel)
		{

			try
			{
				var checkUser = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
								 where c.EMAIL.ToLower() == userModel.EMAIL.ToLower() && c.COMPANY_NAME == "Admin" select c).FirstOrDefaultAsync();

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
					data.COMPANY_NAME = "Admin";
					data.NAME = userModel.NAME;
					//data.PASSWORDS = _helpersController.Encrypt(userModel.PASSWORDS);
					data.STATUS_ = "Activated";
					data.ELPS_ID = userModel.ELPS_ID;
					data.Date_Created = DateTime.Now;
					data.Created_by = WKPCompanyEmail;
					await _context.ADMIN_COMPANY_INFORMATIONs.AddAsync(data);
					int save = await _context.SaveChangesAsync();

					var CompanyInfoId = data.Id;



					if (save > 0)
					{
						string companyAccessCode = string.Empty;
repeat:
						var accessCode = GENERATE_ACCESS_CODE(data.COMPANY_NAME);

						var getAccessCodeFromDb = await _context.ADMIN_COMPANY_CODEs.FirstOrDefaultAsync(x => x.CompanyCode==accessCode);

						if (getAccessCodeFromDb == null)
						{
							companyAccessCode=accessCode;
						}
						else
						{
							goto repeat;
						}


						//Added company Code info
						var CompanyInfoCode = new ADMIN_COMPANY_CODE
						{
							Date_Created= DateTime.Now,
							Date_Updated= DateTime.Now,
							Created_by = WKPCompanyEmail,
							CompanyNumber=CompanyInfoId,
							CompanyCode=companyAccessCode,
							Email=userModel.EMAIL.ToLower().Trim(),
							CompanyName= "Admin",
							GUID=Guid.NewGuid().ToString()
						};
						await _context.ADMIN_COMPANY_CODEs.AddAsync(CompanyInfoCode);

						var newCompany = await _context.ADMIN_COMPANY_INFORMATIONs.FindAsync(CompanyInfoId);
						newCompany.COMPANY_ID = companyAccessCode;
						_context.ADMIN_COMPANY_INFORMATIONs.Update(newCompany);



						//add user to staff table
						staff staff = new staff()
						{
							AdminCompanyInfo_ID=data.Id,
							StaffElpsID = userModel.ELPS_ID.ToString(),
							Staff_SBU = userModel.SBU_ID,
							RoleID = userModel.ROLE_ID,
							LocationID = 1,
							StaffEmail = data.EMAIL,
							FirstName = userModel.NAME.Split(",")[0],
							LastName = userModel.NAME.Split(",").Count() > 1 ? userModel.NAME.Split(",")[0] : "",
							CreatedAt = DateTime.Now,
							ActiveStatus = true,
							DeleteStatus = false,
						};

						await _context.staff.AddAsync(staff);
						int saved = await _context.SaveChangesAsync();

						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{userModel.EMAIL} has been added successfully", Data = userModel, StatusCode = ResponseCodes.Success };
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


        ////Added by Musa
        //[HttpPost("CREATE_USER_NEW")]
        //public async Task<WebApiResponse> CreateUserNew([FromBody] ADMIN_COMPANY_INFORMATION_Model userModel)
        //{

        //    try
        //    {
        //        var checkUser = (from c in _context.ADMIN_COMPANY_INFORMATIONs
        //                         where c.EMAIL.ToLower() == userModel.EMAIL.ToLower()
        //                         select c).FirstOrDefault();

        //        if (checkUser != null)
        //        {
        //            bool deleted = checkUser.DELETED_STATUS == "DELETED" ? true : false;
        //            bool activated = checkUser.STATUS_ == "Activated" ? true : false;

        //            string errMsg = $"User details with '{userModel.EMAIL}' is already existing on the portal.";

        //            if (deleted == true)
        //                errMsg = $"User details with '{userModel.EMAIL}' is already existing, but the account has been deleted on the portal, kindly restore account information.";

        //            if (activated != true)
        //                errMsg = $"User details with '{userModel.EMAIL}' is already existing, but the account has been de-activated on the portal, kindly activate account information.";

        //            return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + errMsg, StatusCode = ResponseCodes.Failure };

        //        }
        //        else
        //        {
        //            var data = _mapper.Map<ADMIN_COMPANY_INFORMATION>(userModel);

        //            data.EMAIL = userModel.EMAIL.ToLower();
        //            data.PASSWORDS = _helpersController.Encrypt(userModel.PASSWORDS);
        //            data.STATUS_ = "Activated";
        //            data.Date_Created = DateTime.Now;
        //            data.Created_by = WKPCompanyEmail;
        //            await _context.ADMIN_COMPANY_INFORMATIONs.AddAsync(data);
        //            int save = await _context.SaveChangesAsync();

        //            var CompanyInfoId = data.Id;



        //            if (save > 0)
        //            {
        //                string companyAccessCode = string.Empty;
        //            repeat:
        //                var accessCode = GENERATE_ACCESS_CODE(data.COMPANY_NAME);

        //                var getAccessCodeFromDb = await _context.ADMIN_COMPANY_CODEs.FirstOrDefaultAsync(x => x.CompanyCode == accessCode);

        //                if (getAccessCodeFromDb != null)
        //                {
        //                    companyAccessCode = accessCode;
        //                }
        //                else
        //                {
        //                    goto repeat;
        //                }


        //                //Added company Code info
        //                var CompanyInfoCode = new ADMIN_COMPANY_CODE
        //                {
        //                    Date_Created = DateTime.Now,
        //                    Date_Updated = DateTime.Now,
        //                    Created_by = WKPCompanyEmail,
        //                    CompanyNumber = CompanyInfoId,
        //                    CompanyCode = companyAccessCode,
        //                    Email = userModel.EMAIL.ToLower().Trim(),
        //                    CompanyName = userModel.COMPANY_NAME,
        //                    GUID = Guid.NewGuid().ToString()
        //                };
        //                await _context.ADMIN_COMPANY_CODEs.AddAsync(CompanyInfoCode);

        //                var newCompany = await _context.ADMIN_COMPANY_INFORMATIONs.FindAsync(CompanyInfoId);
        //                newCompany.COMPANY_ID = companyAccessCode;
        //                _context.ADMIN_COMPANY_INFORMATIONs.Update(newCompany);



        //                //add user to staff table
        //                staff staff = new staff()
        //                {
        //                    AdminCompanyInfo_ID = data.Id,
        //                    StaffElpsID = "123456",
        //                    Staff_SBU = userModel.SBU_ID,
        //                    RoleID = userModel.ROLE_ID,
        //                    LocationID = 1,
        //                    StaffEmail = data.EMAIL,
        //                    FirstName = "ADMIN",
        //                    LastName = "STAFF",
        //                    CreatedAt = DateTime.Now,
        //                    ActiveStatus = true,
        //                    DeleteStatus = false,
        //                };

        //                await _context.staff.AddAsync(staff);
        //                int saved = await _context.SaveChangesAsync();

        //                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{userModel.EMAIL} has been added successfully", Data = userModel, StatusCode = ResponseCodes.Success };
        //            }
        //            else
        //            {
        //                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this user.", StatusCode = ResponseCodes.Failure };
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

        //    }
        //}




        [HttpPost("CREATE_USER")]
		public async Task<WebApiResponse> CreateUser([FromBody] ADMIN_COMPANY_INFORMATION_Model userModel)
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
					data.PASSWORDS = _helpersController.Encrypt(userModel.PASSWORDS);
					data.STATUS_ = "Activated";
					data.Date_Created = DateTime.Now;
					data.Created_by = WKPCompanyEmail;
					await _context.ADMIN_COMPANY_INFORMATIONs.AddAsync(data);
					int save = await _context.SaveChangesAsync();

					var CompanyInfoId = data.Id;



					if (save > 0)
					{
						//						string companyAccessCode = string.Empty;
						//repeat:
						//						var accessCode = GenerateAccessCode(data.COMPANY_NAME);

						//						var getAccessCodeFromDb = await _context.ADMIN_COMPANY_CODEs.FirstOrDefaultAsync(x => x.CompanyCode==accessCode);

						//						if (getAccessCodeFromDb != null)
						//						{
						//							companyAccessCode=accessCode;
						//						}
						//						else
						//						{
						//							goto repeat;
						//						}





						//Added company Code info
						//var CompanyInfoCode = new ADMIN_COMPANY_CODE
						//{
						//	Date_Created= DateTime.Now,
						//	Date_Updated= DateTime.Now,
						//	Created_by = WKPCompanyEmail,
						//	CompanyNumber=CompanyInfoId,
						//	CompanyCode=companyAccessCode,
						//	Email=userModel.EMAIL.ToLower().Trim(),
						//	CompanyName=userModel.COMPANY_NAME,
						//	GUID=Guid.NewGuid().ToString()
						//};
						//await _context.ADMIN_COMPANY_CODEs.AddAsync(CompanyInfoCode);

						//add user to staff table
						staff staff = new staff()
						{
							AdminCompanyInfo_ID=data.Id,
							StaffElpsID = "123456",
							Staff_SBU = userModel.SBU_ID,
							RoleID = userModel.ROLE_ID,
							LocationID = 1,
							StaffEmail = data.EMAIL,
							FirstName = "ADMIN",
							LastName = "STAFF",
							CreatedAt = DateTime.Now,
							ActiveStatus = true,
							DeleteStatus = false,
						};

						await _context.staff.AddAsync(staff);
						int saved = await _context.SaveChangesAsync();

						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{userModel.EMAIL} has been added successfully", Data = userModel, StatusCode = ResponseCodes.Success };
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
		//Create a method to Generate AccessCode
		[HttpGet("GENERATE_ACCESS_CODE")]
		public string GENERATE_ACCESS_CODE(string companyName)
		{
			try
			{
				var strIntitials = string.Empty;

				var companyNames = companyName.Split(' ');

				//check if company name has more than one string

				if (companyNames.Length<=1)
				{
					strIntitials= companyName.Substring(0, 4);
				}
				else
				{
					foreach (var item in companyNames)
					{
						strIntitials+= item.Substring(0);
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

		[HttpGet("GET_COMPANY_INFORMATION_BY_ACCESSCODE")]
		public async Task<ADMIN_COMPANY_CODE> GET_COMPANY_INFORMATION_BY_ACCESSCODE(string accessCode)
		{
			try
			{
				var companyInfo = await _context.ADMIN_COMPANY_CODEs.Where(x => x.CompanyCode==accessCode).FirstOrDefaultAsync();
				if (companyInfo != null)
				{
					return companyInfo;
				}
				return null;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

        [HttpGet("GET_STAFF_SBU_ROLE")]
        public async Task<WebApiResponse> GET_STAFF_SBU_ROLE(string email)
        {
            try
            {
				var result = await (from staff in _context.staff
                                   join sbu in _context.StrategicBusinessUnits on staff.Staff_SBU equals sbu.Id
                                   join role in _context.Roles on staff.RoleID equals role.id
                                   where staff.StaffEmail == email && staff.DeleteStatus != true
                                   select new StaffSBURoleModel
                                   {
                                       Staff = staff,
									   SBU = sbu,
                                       Role = role,
                                   }).FirstOrDefaultAsync();

                if (result != null)
                {
					//var data = _mapper.Map<StaffSBURoleModel>(result);

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Success", Data = result, StatusCode = ResponseCodes.Success };
                }
				else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found.", StatusCode = ResponseCodes.Failure };

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("GET_STAFFS")]
        public async Task<WebApiResponse> GET_STAFFS(string email)
        {
            try
            {
                var result = await (from staff in _context.staff
                                    join sbu in _context.StrategicBusinessUnits on staff.Staff_SBU equals sbu.Id
                                    join role in _context.Roles on staff.RoleID equals role.id
                                    where staff.DeleteStatus != true
                                    select new StaffSBURoleModel
                                    {
                                        Staff = staff,
                                        SBU = sbu,
                                        Role = role,
                                    }).ToListAsync();

                if (result != null)
                {
                    //var data = _mapper.Map<StaffSBURoleModel>(result);

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Success", Data = result, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found.", StatusCode = ResponseCodes.Failure };

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("GET_STAFFS_BY_SBU_ROLE")]
        public async Task<WebApiResponse> GET_STAFFS_BY_SBU_ROLE(int SBU_ID, int RoleID)
        {
            try
            {
                var result = await _context.staff.Where<staff>(s => s.Staff_SBU == SBU_ID && s.RoleID == RoleID && s.DeleteStatus != true).ToListAsync();

                if (result != null)
                {
                    //var data = _mapper.Map<StaffSBURoleModel>(result);

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Success", Data = result, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found.", StatusCode = ResponseCodes.Failure };

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("UPDATE_COMPANY_INFORMATION_BY_ACCESSCODE")]
		public async Task<ADMIN_COMPANY_INFORMATION> UPDATE_COMPANY_INFORMATION_BY_ACCESSCODE(ADMIN_COMPANY_CODE companyCode)
		{
			try
			{
				var accessCode = companyCode.CompanyCode;
				var companyId = 0;
				var companyEmail = companyCode.Email;
				var getCompanyNumber = await _context.ADMIN_COMPANY_CODEs.FirstOrDefaultAsync(x => x.CompanyCode==accessCode);

				if (getCompanyNumber != null)
				{
					companyId= (int)getCompanyNumber.CompanyNumber;

					var getCompanyInfo = await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.Id==companyId);


					if (getCompanyInfo != null)
					{
						getCompanyInfo.EMAIL= companyEmail;

					}
					_context.ADMIN_COMPANY_INFORMATIONs.Update(getCompanyInfo);

					var save = await _context.SaveChangesAsync();
					if (save>0)
					{
						return getCompanyInfo;
					}
				}
				return null;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		[HttpGet("GET_UPDATEUSER")]
		public async Task<WebApiResponse> Get_UpdateUser(int id)
		{
			try
			{
				var checkUser = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
									   where c.Id == id
									   select c).FirstOrDefaultAsync();
				if (checkUser == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found.", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					var data = _mapper.Map<ADMIN_COMPANY_INFORMATION_Model>(checkUser);
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Success", Data = data, StatusCode = ResponseCodes.Success };

				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("UPDATE_USER")]
		public async Task<WebApiResponse> UpdateUser(ADMIN_COMPANY_INFORMATION_Model userModel)
		{
			try
			{
				var checkUser = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
									   where c.Id == userModel.Id
									   select c).FirstOrDefaultAsync();

				if (checkUser == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found for {userModel.EMAIL}", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					var data = _mapper.Map<ADMIN_COMPANY_INFORMATION>(userModel);

					data.EMAIL = userModel.EMAIL.ToLower();
					data.PASSWORDS = _helpersController.Encrypt(userModel.PASSWORDS);
					data.STATUS_ = "Activated";
					data.UPDATED_DATE = DateTime.Now.ToString();
					data.UPDATED_BY = WKPCompanyEmail;
					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						//update user to staff table
						var getStaff = (from stf in _context.staff
										where stf.AdminCompanyInfo_ID == data.Id && stf.DeleteStatus != true
										select stf).FirstOrDefault();
						if (getStaff != null)
						{

							getStaff.Staff_SBU = userModel.SBU_ID;
							getStaff.RoleID = userModel.ROLE_ID;
							getStaff.StaffEmail = data.EMAIL;
							//FirstName = "ADMIN",
							//LastName = "STAFF",
							getStaff.UpdatedAt = DateTime.Now;
						};
						int saved = await _context.SaveChangesAsync();

						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"User information has been updated successfully", Data = userModel, StatusCode = ResponseCodes.Success };
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
		[HttpPost("DELETE_USER")]
		public async Task<WebApiResponse> DeleteUser(int Id)
		{
			try
			{
				var checkUser = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
									   where c.Id == Id
									   select c).FirstOrDefaultAsync();
				if (checkUser == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found.", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					checkUser.DELETED_STATUS = "DELETED";
					checkUser.DELETED_DATE = DateTime.Now.ToString();
					checkUser.DELETED_BY = WKPCompanyEmail;
					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						var getStaff = (from stf in _context.staff
										where stf.AdminCompanyInfo_ID == checkUser.Id && stf.DeleteStatus != true
										select stf).FirstOrDefault();
						if (getStaff != null)
						{

							getStaff.DeleteStatus = true;
							getStaff.UpdatedAt = DateTime.Now;
						};
						int saved = await _context.SaveChangesAsync();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"User information has been updated successfully", StatusCode = ResponseCodes.Success };
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
		[HttpPost("RESTORE_USER")]
		public async Task<WebApiResponse> RestoreUser(int Id)
		{
			try
			{
				var checkUser = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
									   where c.Id == Id
									   select c).FirstOrDefaultAsync();
				if (checkUser == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: User information was not found.", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					checkUser.DELETED_STATUS = null;
					checkUser.DELETED_DATE = null;
					checkUser.DELETED_BY = null;
					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						var getStaff = (from stf in _context.staff
										where stf.AdminCompanyInfo_ID == checkUser.Id && stf.DeleteStatus != true
										select stf).FirstOrDefault();
						if (getStaff != null)
						{

							getStaff.DeleteStatus = false;
							getStaff.UpdatedAt = DateTime.Now;
						};
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"User information has been updated successfully", StatusCode = ResponseCodes.Success };
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

		#endregion

		#region Concession Administration

		[HttpGet("GET_CONCESSIONS")]
		public async Task<WebApiResponse> Get_Concessions(string year)
		{
			try
			{
				var data = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs
								  where c.DELETED_STATUS == null
								  select c).GroupBy(x => x.Concession_Unique_ID).Select(x => x.FirstOrDefault()).ToListAsync();
				if (year != null)
				{
					data = data.Where(d => d.Year == year.Trim()).ToList();
				}
				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = data, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		[HttpPost("CREATE_CONCESSION")]
		public async Task<WebApiResponse> CreateConcession([FromBody] ADMIN_CONCESSIONS_INFORMATION_Model concessionModel)
		{
			try
			{
				var checkConcession = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs
											 where c.Concession_Unique_ID.ToLower() == concessionModel.Concession_Unique_ID.ToLower()
											 select c).FirstOrDefaultAsync();
				if (checkConcession != null)
				{
					bool deleted = checkConcession.DELETED_STATUS == "DELETED" ? true : false;
					string errMsg = $"Concession details with '{concessionModel.Concession_Unique_ID}' is already existing on the portal.";

					if (deleted == true)
						errMsg = $"Concession details with '{concessionModel.Concession_Unique_ID}' is already existing, but the information has been deleted on the portal, kindly restore concession information.";

					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + errMsg, StatusCode = ResponseCodes.Failure };

				}
				else
				{
					var company = await (from c in _context.ADMIN_COMPANY_INFORMATIONs
										 where c.COMPANY_NAME.ToLower() == concessionModel.CompanyName.ToLower()
										 select c).FirstOrDefaultAsync();
					if (company != null)
					{
						var data = _mapper.Map<ADMIN_CONCESSIONS_INFORMATION>(concessionModel);
						data.CompanyNumber = company.CompanyNumber;
						data.Company_ID = company.COMPANY_ID;
						data.Date_Created = DateTime.Now;
						data.Created_by = WKPCompanyEmail;
						await _context.ADMIN_CONCESSIONS_INFORMATIONs.AddAsync(data);
						int save = await _context.SaveChangesAsync();
						if (save > 0)
						{
							return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{concessionModel.Concession_Unique_ID} has been added successfully", Data = concessionModel, StatusCode = ResponseCodes.Success };
						}
						else
						{
							return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this concession.", StatusCode = ResponseCodes.Failure };
						}
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "Concession owner/company details was not found.", StatusCode = ResponseCodes.Failure };
					}
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpGet("GET_UPDATECONCESSION")]
		public async Task<WebApiResponse> Get_UpdateConcession(int id)
		{
			try
			{
				var checkConcession = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs
											 where c.Consession_Id == id
											 select c).FirstOrDefaultAsync();
				if (checkConcession == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: Concession information was not found.", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					var data = _mapper.Map<ADMIN_CONCESSIONS_INFORMATION_Model>(checkConcession);
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Success", Data = data, StatusCode = ResponseCodes.Success };

				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		[HttpPost("UPDATE_CONCESSION")]
		public async Task<WebApiResponse> UpdateConcession(ADMIN_CONCESSIONS_INFORMATION_Model concessionModel)
		{
			try
			{
				var checkConcession = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs
											 where c.Consession_Id == concessionModel.Consession_Id
											 select c).FirstOrDefaultAsync();
				if (checkConcession == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: Concession information was not found for {concessionModel.Concession_Unique_ID}", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					var data = _mapper.Map<ADMIN_COMPANY_INFORMATION>(concessionModel);
					data.EMAIL = concessionModel.COMPANY_EMAIL.ToLower();
					data.UPDATED_DATE = DateTime.Now.ToString();
					data.UPDATED_BY = WKPCompanyEmail;
					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Concession information has been updated successfully.", Data = concessionModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this concession.", StatusCode = ResponseCodes.Failure };
					}
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("DELETE_CONCESSION")]
		public async Task<WebApiResponse> DeleteConcession(int Id)
		{
			try
			{
				var checkConcession = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs
											 where c.Consession_Id == Id
											 select c).FirstOrDefaultAsync();
				if (checkConcession == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: Concession information was not found.", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					checkConcession.DELETED_STATUS = "DELETED";
					checkConcession.DELETED_DATE = DateTime.Now.ToString();
					checkConcession.DELETED_BY = WKPCompanyEmail;
					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Concession information has been updated successfully", StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this concession.", StatusCode = ResponseCodes.Failure };
					}
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("RESTORE_CONCESSION")]
		public async Task<WebApiResponse> RestoreConcession(int Id)
		{
			try
			{
				var checkConcession = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs
											 where c.Consession_Id == Id
											 select c).FirstOrDefaultAsync();
				if (checkConcession == null)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: Concession information was not found.", StatusCode = ResponseCodes.Failure };

				}
				else
				{
					checkConcession.DELETED_STATUS = null;
					checkConcession.DELETED_DATE = null;
					checkConcession.DELETED_BY = null;
					int save = await _context.SaveChangesAsync();
					if (save > 0)
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Concession information has been updated successfully", StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this concession.", StatusCode = ResponseCodes.Failure };
					}
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		#endregion

		[HttpGet("GET_COMPANYLIST")]
		public async Task<WebApiResponse> Get_CompanyList()
		{
			try
			{
				var data = await (from c in _context.ADMIN_COMPANY_DETAILs select c).ToListAsync();


				var list = new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = data, StatusCode = ResponseCodes.Success };
				return list;
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		#region Report Editor Section
		[HttpGet("GET_REPORTS")]
		public async Task<WebApiResponse> Get_Reports()
		{
			try
			{
				var data = await _context.ADMIN_WORK_PROGRAM_REPORTs.Where(x => x.Id <= 5).ToListAsync();
				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = data, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}




		[HttpPost("UPDATE_REPORTS")]
		public async Task<WebApiResponse> UpdateReports(List<ADMIN_WORK_PROGRAM_REPORT> reports)
		{
			try
			{
				if (reports == null && reports.Count > 0)
				{
					foreach (var x in reports)
					{
						var checkReport = await (from c in _context.ADMIN_WORK_PROGRAM_REPORTs
												 where c.Id == x.Id
												 select c).FirstOrDefaultAsync();
						if (checkReport == null)
						{
							return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: Report details could not found on the portal.", StatusCode = ResponseCodes.Failure };
						}
						else
						{
							checkReport.Report_Content = x.Report_Content;
							checkReport.Date_Updated = DateTime.Now;
							checkReport.Updated_by = WKPCompanyEmail;
							int save = await _context.SaveChangesAsync();
							if (save > 0)
							{
								var data = _context.ADMIN_WORK_PROGRAM_REPORTs.Where(x => x.Id <= 5).ToList();
								return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Report(s) have been updated successfully.", Data = data, StatusCode = ResponseCodes.Success };
							}
							else
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "An error occured while adding this concession.", StatusCode = ResponseCodes.Failure };
							}
						}
					}
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "Report(s) data is null/empty.", StatusCode = ResponseCodes.Failure };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error: " + "Report(s) data is null/empty.", StatusCode = ResponseCodes.Failure };
				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		#endregion

		#region Parameters Configuration
		[HttpGet("GET_PARAMETERSCONFIGURATION")]
		public async Task<WebApiResponse> Get_ParametersConfiguration()
		{
			try
			{
				var adminCategories = await _context.ADMIN_CATEGORIEs.ToListAsync();
				var dataTypes = await _context.Data_Types.ToListAsync();
				var wellCategories = await _context.ADMIN_WELL_CATEGORIEs.ToListAsync();
				var startEndDate = await _context.ADMIN_WP_START_END_DATEs.ToListAsync();
				var startEndDateUpload = await _context.ADMIN_WP_START_END_DATE_DATA_UPLOADs.ToListAsync();
				var penalties = await _context.ADMIN_WP_PENALTIEs.ToListAsync();
				var emailDays = await _context.ADMIN_EMAIL_DAYs.Where(x => x.Deleted_status == null).ToListAsync();
				var superAdmins = await _context.ROLES_SUPER_ADMINs.Where(x => x.Deleted_status == null).OrderBy(x => x.Date_Created).ToListAsync();
				var presentationCategories = await _context.ADMIN_PRESENTATION_CATEGORIEs.ToListAsync();
				var meetingRooms = await _context.ADMIN_MEETING_ROOMs.ToListAsync();

				var returnData = new parameterConfigModel()
				{
					adminCategories = adminCategories,
					dataTypes = dataTypes,
					wellCategories = wellCategories,
					startEndDate = startEndDate,
					startEndDateUpload = startEndDateUpload,
					penalties = penalties,
					emailDays = emailDays,
					superAdmins = superAdmins,
					presentationCategories = presentationCategories,
					meetingRooms = meetingRooms,
				};

				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = returnData, StatusCode = ResponseCodes.Success };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_CATEGORIES")]
		public async Task<WebApiResponse> Admin_Categories(ADMIN_CATEGORy model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ADMIN_CATEGORIEs.Where(x => x.categories.ToLower() == model.categories.Trim().ToLower()).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.categories} is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ADMIN_CATEGORy()
								{
									categories = model.categories,
									categories_Desc = model.categories_Desc,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ADMIN_CATEGORIEs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ADMIN_CATEGORIEs.Where(x => x.Id == model.Id).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.categories} details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.categories = model.categories;
									checkdata.categories_Desc = model.categories_Desc;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ADMIN_CATEGORIEs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = await _context.ADMIN_CATEGORIEs.ToListAsync();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{model.categories} has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} {model.categories} category.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("DATA_TYPES")]
		public async Task<WebApiResponse> Data_Types(Data_Type model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.Data_Types.Where(x => x.DataType.ToLower() == model.DataType.Trim().ToLower()).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.DataType} is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new Data_Type()
								{
									DataType = model.DataType,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.Data_Types.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.Data_Types.Where(x => x.DataTypeId == model.DataTypeId).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.DataType} details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.DataType = model.DataType;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.Data_Types.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.Data_Types.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{model.DataType} has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} {model.DataType} data type.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_WELL_CATEGORIES")]
		public async Task<WebApiResponse> Admin_Well_Categories(ADMIN_WELL_CATEGORy model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ADMIN_WELL_CATEGORIEs.Where(x => x.welltype.ToLower() == model.welltype.Trim().ToLower()).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.welltype} is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ADMIN_WELL_CATEGORy()
								{
									welltype = model.welltype,
									categories_Desc = model.categories_Desc,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ADMIN_WELL_CATEGORIEs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ADMIN_WELL_CATEGORIEs.Where(x => x.Id == model.Id).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.welltype} details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.welltype = model.welltype;
									checkdata.categories_Desc = model.categories_Desc;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ADMIN_WELL_CATEGORIEs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_CATEGORIEs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{model.welltype} has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} {model.welltype} category.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_START_END_DATES")]
		public async Task<WebApiResponse> Admin_StartEnd_Date([FromBody] ADMIN_WP_START_END_DATE model, string _action)
		{
			try
			{
				int save = 0;


				var startDateString = model.start_date;
				var endDateString = model.end_date;

				var startDate = Convert.ToDateTime(startDateString).Date;
				var endDate = Convert.ToDateTime(endDateString).Date;

				if (endDate < startDate)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: End Date can not be less than Start Date.. ", StatusCode = ResponseCodes.Failure };
				}

				if (endDate < DateTime.Now)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: End Date can not be less than current month. ", StatusCode = ResponseCodes.Failure };
				}


				if (model != null)
				{
					//switch (action)
					//{
					if (_action.ToLower()=="INSERT".ToLower())
					{
						var getdata = _context.ADMIN_WP_START_END_DATEs.Where(x => x.Created_by == WKPCompanyEmail)?.FirstOrDefault();

						if (getdata != null)
						{
							//return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: start & end dates are already existing on the portal. ", StatusCode = ResponseCodes.Failure };

							getdata.start_date = model.start_date;
							getdata.end_date = model.end_date;
							getdata.categories_Desc = model.categories_Desc;
							getdata.Date_Updated = DateTime.Now;
							getdata.Updated_by = WKPCompanyEmail;

							_context.ADMIN_WP_START_END_DATEs.Update(getdata);
							save = await _context.SaveChangesAsync();
						}
						else
						{
							var data = new ADMIN_WP_START_END_DATE()
							{
								start_date = model.start_date,
								end_date = model.end_date,
								categories_Desc = model.categories_Desc,
								Date_Created = DateTime.Now,
								Created_by = WKPCompanyEmail
							};
							await _context.ADMIN_WP_START_END_DATEs.AddAsync(data);
							save = await _context.SaveChangesAsync();

						}
					}

					//break;

					//default:
					//var checkdata = _context.ADMIN_WP_START_END_DATEs.Where(x => x.Id == model.Id).FirstOrDefault();
					//if (checkdata == null)
					//{
					//	return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: start & end dates details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
					//}
					//else
					//{
					//if (action == GeneralModel.Update)
					//{
					//	checkdata.start_date = model.start_date;
					//	checkdata.end_date = model.end_date;
					//	checkdata.categories_Desc = model.categories_Desc;
					//	checkdata.Date_Updated = DateTime.Now;
					//	checkdata.Updated_by = WKPCompanyEmail;
					//}
					//else if (action == GeneralModel.Delete)
					//{
					//	_context.ADMIN_WP_START_END_DATEs.Remove(checkdata);
					//}
					//save = await _context.SaveChangesAsync();

					//}

					//break;
					//}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_WP_START_END_DATEs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"WKP start & end dates have been {_action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					//else
					//{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {_action} start & end dates.", StatusCode = ResponseCodes.Failure };
					//}
				}
				//else
				//{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				//}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_START_END_DATE_DATA_UPLOADS")]
		public async Task<WebApiResponse> Admin_StartEnd_Date([FromBody] ADMIN_WP_START_END_DATE_DATA_UPLOAD model, string _action)
		{
			try
			{
				int save = 0;

				var startDateString = model.start_date;
				var endDateString = model.end_date;

				var startDate = Convert.ToDateTime(startDateString).Date;
				var endDate = Convert.ToDateTime(endDateString).Date;

				if (endDate < startDate)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: End Date can not be less than Start Date.. ", StatusCode = ResponseCodes.Failure };
				}

				if (endDate < DateTime.Now)
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: End Date can not be less than current month. ", StatusCode = ResponseCodes.Failure };
				}



				if (model != null)
				{
					//switch (action)
					//{
					if (_action.ToLower()=="INSERT".ToLower())
					{
						var getdata = _context.ADMIN_WP_START_END_DATE_DATA_UPLOADs.Where(x => x.Created_by == WKPCompanyEmail)?.FirstOrDefault();

						if (getdata != null)
						{
							//return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: start & end data uploads are already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							getdata.start_date = model.start_date;
							getdata.end_date = model.end_date;
							getdata.categories_Desc = model.categories_Desc;
							getdata.Date_Updated = DateTime.Now;
							getdata.Updated_by = WKPCompanyEmail;

							_context.ADMIN_WP_START_END_DATE_DATA_UPLOADs.Update(getdata);
							save = await _context.SaveChangesAsync();

						}
						else
						{
							//var data = new ADMIN_WP_START_END_DATE()
							//{
							//	start_date = model.start_date,
							//	end_date = model.end_date,
							//	categories_Desc = model.categories_Desc,
							//	Date_Created = DateTime.Now,
							//	Created_by = WKPCompanyEmail
							//};

							var data = new ADMIN_WP_START_END_DATE_DATA_UPLOAD()
							{
								start_date=model.start_date,
								end_date=model.end_date,
								categories_Desc=model.categories_Desc,
								Date_Created=DateTime.Now,
								Created_by=WKPCompanyEmail,
							};

							//ADMIN_WP_START_END_DATEs
							await _context.ADMIN_WP_START_END_DATE_DATA_UPLOADs.AddAsync(data);
							save = await _context.SaveChangesAsync();

						}
					}
					//case "INSERT":
					//
					//var getdata = _context.ADMIN_WP_START_END_DATE_DATA_UPLOADs.Where(x => x.start_date == model.start_date && x.end_date == model.end_date).FirstOrDefault();



					//break;

					//default:
					//		var checkdata = _context.ADMIN_WP_START_END_DATEs.Where(x => x.Id == model.Id).FirstOrDefault();
					//if (checkdata == null)
					//{
					//	return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: start & end dates details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
					//}
					//else
					//{
					//	if (_action == GeneralModel.Update)
					//	{
					//		checkdata.start_date = model.start_date;
					//		checkdata.end_date = model.end_date;
					//		checkdata.categories_Desc = model.categories_Desc;
					//		checkdata.Date_Updated = DateTime.Now;
					//		checkdata.Updated_by = WKPCompanyEmail;
					//	}
					//	else if (_action == GeneralModel.Delete)
					//	{
					//		_context.ADMIN_WP_START_END_DATEs.Remove(checkdata);
					//	}
					//	save = await _context.SaveChangesAsync();

					//}

					//break;
					//}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_WP_START_END_DATE_DATA_UPLOADs.ToList();
						//var returnModel = _context.ADMIN_WP_START_END_DATEs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"WKP start & end dates have been {_action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					//else
					//{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {_action} start & end dates.", StatusCode = ResponseCodes.Failure };
					//}
				}
				//else
				//{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				//}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_PENALTIES")]
		public async Task<WebApiResponse> Admin_Penalties(ADMIN_WP_PENALTy model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ADMIN_WP_PENALTIEs.Where(x => x.NO_SUBMISSION == model.NO_SUBMISSION && x.NO_SHOW == model.NO_SHOW).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: penalty config is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ADMIN_WP_PENALTy()
								{
									NO_SHOW = model.NO_SHOW,
									NO_SUBMISSION = model.NO_SUBMISSION,
									categories_Desc = model.categories_Desc,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ADMIN_WP_PENALTIEs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ADMIN_WP_PENALTIEs.Where(x => x.Id == model.Id).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: penalty details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.NO_SHOW = model.NO_SHOW;
									checkdata.NO_SUBMISSION = model.NO_SUBMISSION;
									checkdata.categories_Desc = model.categories_Desc;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ADMIN_WP_PENALTIEs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_WP_PENALTIEs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Penalty has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} penalty.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_EMAIL_DAYS")]
		public async Task<WebApiResponse> Admin_EmailDays(ADMIN_EMAIL_DAY model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ADMIN_EMAIL_DAYs.Where(x => x.Email_.ToLower() == model.Email_.Trim().ToLower() && x.DAYS_ == model.DAYS_ && x.Deleted_status == null).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: admin email days config is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ADMIN_EMAIL_DAY()
								{
									Email_ = model.Email_.ToLower().Trim(),
									DAYS_ = model.DAYS_.Trim(),
									Description = model.Description,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ADMIN_EMAIL_DAYs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ADMIN_EMAIL_DAYs.Where(x => x.SN == model.SN && x.Deleted_status == null).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: start & end dates details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.Email_ = model.Email_.Trim().ToLower();
									checkdata.DAYS_ = model.DAYS_.Trim();
									checkdata.Description = model.Description;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ADMIN_EMAIL_DAYs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_EMAIL_DAYs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Admin email days config have been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} admin email days config.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ROLES_SUPER_ADMINS")]
		public async Task<WebApiResponse> Super_Admins(ROLES_SUPER_ADMIN model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ROLES_SUPER_ADMINs.Where(x => x.Email_.ToLower() == model.Email_.Trim().ToLower() && x.Deleted_status == null).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: super admin email is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ROLES_SUPER_ADMIN()
								{

									Email_ = model.Email_.ToLower().Trim(),
									Role_ = GeneralModel.SuperAdmin,
									Description = model.Description,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ROLES_SUPER_ADMINs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ROLES_SUPER_ADMINs.Where(x => x.SN == model.SN && x.Deleted_status == null).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: super admin details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.Email_ = model.Email_.Trim().ToLower();
									checkdata.Role_ = model.Role_.Trim();
									checkdata.Description = model.Description;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ROLES_SUPER_ADMINs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.ROLES_SUPER_ADMINs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Super admin email has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} super admin email.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		[HttpPost("ADMIN_PRESENTATION_CATEGORIES")]
		public async Task<WebApiResponse> Admin_Presentation_Categories(ADMIN_PRESENTATION_CATEGORy model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ADMIN_PRESENTATION_CATEGORIEs.Where(x => x.categories.ToLower() == model.categories.Trim().ToLower()).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.categories} is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ADMIN_PRESENTATION_CATEGORy()
								{
									categories = model.categories,
									categories_Desc = model.categories_Desc,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ADMIN_PRESENTATION_CATEGORIEs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ADMIN_PRESENTATION_CATEGORIEs.Where(x => x.Id == model.Id).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.categories} details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.categories = model.categories;
									checkdata.categories_Desc = model.categories_Desc;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ADMIN_PRESENTATION_CATEGORIEs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_PRESENTATION_CATEGORIEs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{model.categories} has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} {model.categories} presentation category.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost("ADMIN_MEETING_ROOMS")]
		public async Task<WebApiResponse> Admin_Meeting_Rooms(ADMIN_MEETING_ROOM model, string action)
		{
			try
			{
				int save = 0;
				if (model != null)
				{
					switch (action)
					{
						case "INSERT":
							var getdata = _context.ADMIN_MEETING_ROOMs.Where(x => x.MEETING_ROOM.ToLower() == model.MEETING_ROOM.Trim().ToLower()).FirstOrDefault();
							if (getdata != null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.MEETING_ROOM} is already existing on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								var data = new ADMIN_MEETING_ROOM()
								{
									MEETING_ROOM = model.MEETING_ROOM.Trim().ToUpper(),
									categories_Desc = model.categories_Desc,
									Date_Created = DateTime.Now,
									Created_by = WKPCompanyEmail
								};
								await _context.ADMIN_MEETING_ROOMs.AddAsync(data);
								save = await _context.SaveChangesAsync();

							}
							break;

						default:
							var checkdata = _context.ADMIN_MEETING_ROOMs.Where(x => x.Id == model.Id).FirstOrDefault();
							if (checkdata == null)
							{
								return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: {model.MEETING_ROOM} details could not be found on the portal. ", StatusCode = ResponseCodes.Failure };
							}
							else
							{
								if (action == GeneralModel.Update)
								{
									checkdata.MEETING_ROOM = model.MEETING_ROOM;
									checkdata.categories_Desc = model.categories_Desc;
									checkdata.Date_Updated = DateTime.Now;
									checkdata.Updated_by = WKPCompanyEmail;
								}
								else if (action == GeneralModel.Delete)
								{
									_context.ADMIN_MEETING_ROOMs.Remove(checkdata);
								}
								save = await _context.SaveChangesAsync();

							}

							break;
					}

					if (save > 0)
					{
						var returnModel = _context.ADMIN_MEETING_ROOMs.ToList();
						return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"{model.MEETING_ROOM} has been {action}D successfully", Data = returnModel, StatusCode = ResponseCodes.Success };
					}
					else
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: An error occured while trying to {action} {model.MEETING_ROOM} meeting room.", StatusCode = ResponseCodes.Failure };
					}
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error: model data was not passed correctly.", StatusCode = ResponseCodes.Failure };
				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		#endregion
		#region company concessions and fields management
		[HttpGet("GET_ADMIN_CONCESSIONS_INFORMATIONs")]
		public async Task<object> GET_ADMIN_CONCESSIONS_INFORMATIONs(int companyNumber)
		{
			try
			{
				int companyID = companyNumber > 0 ? companyNumber : int.Parse(WKPCompanyId);
				var companyConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.CompanyNumber == companyID && d.DELETED_STATUS != "true" select d).ToListAsync();
				return new { CompanyConcessions = companyConcessions };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
			}
		}

		[HttpGet("GET_COMPANY_FIELDS")]
		public async Task<object> GET_COMPANY_FIELDS(int companyNumber)
		{
			try
			{
				int companyID = companyNumber > 0 ? companyNumber : int.Parse(WKPCompanyId);
				var concessionFields = await (from d in _context.COMPANY_FIELDs where d.CompanyNumber == companyID && d.DeletedStatus != true select d).ToListAsync();
				return new { ConcessionFields = concessionFields };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
			}
		}
		[HttpGet("GET_CONCESSIONS_FIELDS")]
		public async Task<object> GET_CONCESSIONS_FIELDS(int concessionID)
		{
			try
			{
				var companyFields = await (from d in _context.COMPANY_FIELDs where d.Concession_ID == concessionID && d.DeletedStatus != true select d).ToListAsync();

				return new { CompanyFields = companyFields };
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
			}
		}

		[HttpPost("POST_COMPANY_FIELD")]
		public async Task<WebApiResponse> POST_COMPANY_FIELD([FromBody] COMPANY_FIELD company_field_model, string actionToDo = null)
		{

			int save = 0;
			string action = actionToDo == null ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower();

			try
			{
				#region Saving Field

				if (action == GeneralModel.Insert)
				{
					var companyField = (from d in _context.COMPANY_FIELDs
										where d.Field_Name == company_field_model.Field_Name.TrimEnd().ToUpper()
											  && d.CompanyNumber == int.Parse(WKPCompanyId) && d.DeletedStatus != true
										select d).FirstOrDefault();

					if (companyField != null)
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error : Field ({company_field_model.Field_Name} is already existing and can not be duplicated.", StatusCode = ResponseCodes.Failure };
					}
					else
					{
						company_field_model.CompanyNumber = int.Parse(WKPCompanyId);
						company_field_model.Date_Created = DateTime.Now;
						company_field_model.Field_Name = company_field_model.Field_Name.TrimEnd().ToUpper();
						await _context.COMPANY_FIELDs.AddAsync(company_field_model);
					}
				}
				else if (action == GeneralModel.Update)
				{
					var companyField = (from d in _context.COMPANY_FIELDs
										where d.Field_ID == company_field_model.Field_ID
											  && d.CompanyNumber == int.Parse(WKPCompanyId) && d.DeletedStatus != true
										select d).FirstOrDefault();

					if (companyField == null)
					{
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error : This field details could not be found.", StatusCode = ResponseCodes.Failure };
					}
					else
					{
						company_field_model.Date_Updated = DateTime.Now;
						company_field_model.Field_Name = company_field_model.Field_Name.TrimEnd().ToUpper();
					}
				}
				else if (action == GeneralModel.Delete)
				{
					_context.COMPANY_FIELDs.Remove(company_field_model);
				}

				save += await _context.SaveChangesAsync();
				#endregion

				if (save > 0)
				{
					string successMsg = Messager.ShowMessage(action);
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Failure };

				}
			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		#endregion

	}


}
