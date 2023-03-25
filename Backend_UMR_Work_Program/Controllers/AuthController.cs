using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using LpgLicense.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Backend_UMR_Work_Program.Models.ViewModel;

namespace Backend_UMR_Work_Program.Controllers.Authentications
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly WKP_DBContext _context;
        IHttpContextAccessor _httpContextAccessor;
        public IConfiguration _configuration;
        Account _account;
        private readonly AppSettings _appSettings;
        ElpsResponse elpsResponse = new ElpsResponse();
        ElpsServices elpsServices = new ElpsServices();
        RestSharpServices _restService = new RestSharpServices();
        Helpers.Authentications auth = new Helpers.Authentications();
        private readonly IMapper _mapper;
        HelpersController _helpersController;

        public AuthController(WKP_DBContext context, IOptions<AppSettings> appSettings, Account account, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _mapper = mapper;
            _account = account;
            _helpersController = new HelpersController(_context, _configuration, _httpContextAccessor, _mapper);
            _mapper = mapper;
        }




        [HttpPost("UserAuth")]
        public async Task<IActionResult> UserAuth([FromBody] Logine login)
        {
            string email = login?.email;
            string code = login?.code;
            var isSuccess = elpsServices.CodeCheck(email, code);
            try { 
                var log = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


                if (string.IsNullOrWhiteSpace(email))
                {
                    elpsResponse.message = "Oops... No result gotten from ELPS.";
                }
                else
                {
                    // check user on ELPS staff
                    var paramData = _restService.parameterData("staffEmail", email);
                    var response = await _restService.Response("/api/Accounts/Staff/{staffEmail}/{email}/{apiHash}", paramData); // GET

                    if (response.ErrorException != null)
                    {
                        elpsResponse.message = _restService.ErrorResponse(response);
                    }
                    else
                    {
                        var res = JsonConvert.DeserializeObject<LpgLicense.Models.Staff>(response.Content);

                        if (res == null)
                        {
                            // user is not a staff, hence user on ELPS company
                            var paramData2 = _restService.parameterData("compemail", email);
                            var response2 = await _restService.Response("/api/company/{compemail}/{email}/{apiHash}", paramData2); // GET

                            if (response2.ErrorException != null)
                            {
                                elpsResponse.message = _restService.ErrorResponse(response2);
                            }
                            else
                            {
                                var res2 = JsonConvert.DeserializeObject<LpgLicense.Models.CompanyDetail>(response2.Content);

                                if (res2 != null)
                                {

                                    string address = "";

                                    if (res2.registered_Address_Id != null || res2.registered_Address_Id != "0")
                                    {
                                        address = res2.registered_Address_Id;
                                    }
                                    else if (res2.operational_Address_Id != null || res2.operational_Address_Id != "0")
                                    {
                                        address = res2.operational_Address_Id;
                                    }

                                    // check address on ELPS
                                    var paramDatas2 = _restService.parameterData("Id", address);
                                    var addressResponse = await _restService.Response("/api/Address/ById/{Id}/{email}/{apiHash}", paramDatas2); // GET

                                    var _company = (from s in _context.ADMIN_COMPANY_INFORMATIONs where s.ELPS_ID == res2.id select s).FirstOrDefault();

                                    if (_company != null)
                                    {
                                        elpsResponse.message = email + " Company found on local DB.";
                                        elpsResponse.value = _company;

                                        if (addressResponse != null)
                                        {
                                            var add = JsonConvert.DeserializeObject<Address>(addressResponse.Content);

                                            if (add != null)
                                            {
                                                //save address
                                                _company.CompanyAddress = add.address_1;
                                            }
                                        }
                                        _company.COMPANY_NAME = res2.name;
                                        _company.EMAIL = res2.user_Id;
                                        _company.LAST_LOGIN_DATE = DateTime.Now;
                                        _context.Entry(_company).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        elpsResponse.message = email + " This company was not found on WORK PROGRAMME PORTAL.... Creating company now.";

                                        if (await _account.Insert_ADMIN_COMPANY_INFORMATION(res2.name, "CCC", res2.name, "Company", res2.contact_Phone, res2.user_Id, "password", res2.id) > 0)
                                        {
                                        _company = (from s in _context.ADMIN_COMPANY_INFORMATIONs where s.ELPS_ID == res2.id select s).FirstOrDefault();
                                        _company.LAST_LOGIN_DATE = DateTime.Now;
                                            await _context.SaveChangesAsync();
                                        }

                                        else
                                        {
                                            elpsResponse.message = email + " Something went wrong while trying to create your company on WORK PROGRAMME portal. please try again.";
                                        }
                                    }

                                    var concessionInfo = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs where c.COMPANY_EMAIL == email.Trim() select c).FirstOrDefaultAsync();
                                        var contractType = concessionInfo?.Contract_Type ?? "";
                                        var companyName = "Admin";
                                        var role = "Company";
                                        var tokenHandler = new JwtSecurityTokenHandler();
                                        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                                        var tokenDescriptor = new SecurityTokenDescriptor
                                        {
                                            Subject = new ClaimsIdentity(new Claim[]
                                            {
                                            new Claim(ClaimTypes.Name, _company.COMPANY_NAME ?? ""),
                                            new Claim(ClaimTypes.Email, _company.EMAIL ?? ""),
                                            new Claim(ClaimTypes.NameIdentifier, _company.COMPANY_ID ?? ""),
                                            new Claim(ClaimTypes.GivenName, _company?.NAME ?? ""),
                                            new Claim(ClaimTypes.Role, role),
                                            new Claim(ClaimTypes.PrimarySid, _company.Id.ToString() ?? ""),
                                            }),
                                            Expires = DateTime.UtcNow.AddDays(7),
                                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                                        };
                                        var token = tokenHandler.CreateToken(tokenDescriptor);
                                        UserToken tok = new UserToken { CompanyId = _company.COMPANY_ID, CompanyName = companyName, CompanyEmail = _company.EMAIL, CompanyNumber = _company.CompanyNumber, Name = _company.NAME, ContractType = contractType, token = tokenHandler.WriteToken(token), code = 1 };
                                        return Ok(tok);
                                    }
                            }
                        }
                        else
                        {
                            string elpsStaffEmail = res.email.Split('@')[0];

                            var _staff = (from s in _context.staff where (s.StaffEmail.Contains(elpsStaffEmail.Trim()) ||s.StaffElpsID == res.userId) select s).FirstOrDefault();

                            if (_staff != null)
                            {
                                elpsResponse.message = email + " Staff found on local DB.";
                                elpsResponse.value = _staff;

                                _staff.StaffEmail = res.email;
                                _staff.StaffElpsID = res.userId;
                                await _context.SaveChangesAsync();

                                if ((!string.IsNullOrWhiteSpace(_staff.StaffEmail)) && _staff.DeleteStatus == true)
                                {
                                    elpsResponse.message = email + " You have been deleted from this portal. Please contact administrator.";
                                }
                                else if ((!string.IsNullOrWhiteSpace(_staff.StaffEmail)) && _staff.ActiveStatus == false)
                                {
                                    elpsResponse.message = email + " You have been de-activated on this portal. Please contact administrator.";
                                }
                                else
                                {
                                    var role = _context.Roles.Where(r=> r.id == _staff.RoleID).FirstOrDefault();

                                    var tokenHandler = new JwtSecurityTokenHandler();
                                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                                    var tokenDescriptor = new SecurityTokenDescriptor
                                    {
                                        Subject = new ClaimsIdentity(new Claim[]
                                        {
                                            new Claim(ClaimTypes.Name, _staff.FirstName + " "+ _staff.LastName ?? ""),
                                            new Claim(ClaimTypes.Email, _staff.StaffEmail ?? ""),
                                            new Claim(ClaimTypes.NameIdentifier, _staff.StaffElpsID.ToString() ?? ""),
                                            new Claim(ClaimTypes.GivenName, _staff.FirstName + " "+ _staff.LastName ?? ""),
                                            new Claim(ClaimTypes.Role, role.RoleName),
                                            new Claim(ClaimTypes.PrimarySid, _staff.StaffID.ToString() ?? ""),
                                        }),
                                        Expires = DateTime.UtcNow.AddDays(7),
                                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                                    };
                                var companyName = "Admin";

                                var token = tokenHandler.CreateToken(tokenDescriptor);
                                    UserToken tok = new UserToken { CompanyId = _staff.StaffID.ToString(), CompanyName = companyName, CompanyEmail = _staff.StaffEmail, CompanyNumber = _staff.StaffID, Name = _staff.FirstName, ContractType = "Staff", token = tokenHandler.WriteToken(token), code = 1 };
                                    return Ok(tok);
                                }
                            }
                            else
                            {
                                staff staff = new staff()
                                {

                                    StaffElpsID = res.userId.Trim(),
                                    Staff_SBU = 0,
                                    RoleID = 0,
                                    LocationID = 0,
                                    UpdatedBy = 0,
                                    StaffEmail = res.email.Trim(),
                                    FirstName = res.firstName.ToUpper(),
                                    LastName = res.lastName.ToUpper(),
                                    CreatedAt = DateTime.Now,
                                    ActiveStatus = true,
                                    DeleteStatus = false,
                                };

                                _context.staff.Add(staff);
                                int saved = await _context.SaveChangesAsync();

                                int lastStaffID = staff.StaffID;

                                var updateStaff = from s in _context.staff where s.StaffID == lastStaffID select s;
                                updateStaff.FirstOrDefault().CreatedBy = lastStaffID;
                                int save2 = await _context.SaveChangesAsync(); 

                                if (saved > 0)
                                {
                                    elpsResponse.message = email + " Staff successfully created from elps but not active";
                                }
                                else
                                {
                                    elpsResponse.message = email + " Staff not created. Try again later.";
                                }
                            }
                        }
                    }
                }
            return Ok(elpsResponse.message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        //[HttpPost]
        //[Route("log-out")]
        //public async Task<IActionResult> Logout()
        //{
        //    try { 
        //    string publicKey = _configuration.GetSection("ElpsKeys").GetSection("PK").Value.ToString();
        //    var elpsLogoff = ElpsServices._elpsBaseUrl + "Account/RemoteLogOff";
        //    var returnUrl = Url.Action("Index", "Home", null, Request.Scheme);

        //    var frm = "<form action='" + elpsLogoff + "' id='frmTest' method='post'>" +
        //            "<input type='hidden' name='returnUrl' value='" + returnUrl + "' />" +
        //            "<input type='hidden' name='appId' value='" + publicKey + "' />" +
        //            "</form>" +
        //            "<script>document.getElementById('frmTest').submit();</script>";

        //        var log = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //        return Content(frm, "text/html");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ex.Message);
        //    }
        //}





        [HttpGet]
        [Route("log-out")]
        public async Task<IActionResult> Logout()
        {
            var elpsLogOffUrl = $"{_appSettings.elpsBaseUrl}/Account/RemoteLogOff";
            var returnUrl = $"{_appSettings.LoginUrl}";
            var frm = "<form action='" + elpsLogOffUrl + "' id='frmTest' method='post'>" + "<input type='hidden' name='returnUrl' value='" + returnUrl + "' />" + "<input type='hidden' name='appId' value='" + _appSettings.PK + "' />" + "</form>" + "<script>document.getElementById('frmTest').submit();</script>";
            return Content(frm, "text/html");
        }

        [HttpPost("ChangePasswordAction")]
        public async Task<IActionResult> ChangePasswordAction(string email, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            string result = "";
            try { 
            LpgLicense.Models.ChangePassword changePassword = new ChangePassword()
            {
                oldPassword = OldPassword,
                newPassword = NewPassword,
                confirmPassword = ConfirmPassword
            };

            var paramData = _restService.parameterData("useremail", email);
            var response = await _restService.Response("/api/Accounts/ChangePassword/{useremail}/{email}/{apiHash}", paramData, "POST", changePassword); // GET

            if (response.ErrorException != null)
            {
                result = _restService.ErrorResponse(response);
            }
            else
            {
                var res = JsonConvert.DeserializeObject<LpgLicense.Models.ChangePasswordResponse>(response.Content);

                if (res.code == 1)
                {
                    result = "Password Changed";
                }
                else
                {
                    result = "Password not change. " + res.msg;
                }
            }

            //_helpersController.LogMessages("Result for user changing password " + result, _helpersController.getSessionEmail());

            return Json(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
}