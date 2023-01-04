﻿using AutoMapper;
using Backend_UMR_Work_Program.Models;
//using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]

    public class ApplicationController : Controller
    {
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        HelpersController _helpersController;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ApplicationController(WKP_DBContext context, IConfiguration configuration, HelpersController helpersController, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _helpersController = new HelpersController(_context, _configuration, _httpContextAccessor, _mapper);
        }
        //private int? WKPCompanyNumber=> 21;
        //private string? WKPCompanyId=> "221";
        //private string? WKPCompanyName => "Name";
        //private string? WKPCompanyEmail => "adeola.kween123@gmail.com";
        //private string? WKUserRole => "Admin";

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);
        private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        [HttpGet("GetDashboardStuff")]
        public async Task<object> GetDashboardStuff()
        {
            try
            {
                var deskCount = 0;
                var getStaff = (from stf in _context.staff
                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                select stf).FirstOrDefault();
                if (getStaff != null)
                {
                    deskCount = await _context.MyDesks.Where(x => x.StaffID == getStaff.StaffID && x.HasWork != true).CountAsync();
                }
                var allApplicationsCount = await _context.Applications.Where(x => x.Status == GeneralModel.Processing).CountAsync();
                var allProcessingCount = await _context.Applications.CountAsync();
                var allApprovalsCount = await _context.PermitApprovals.CountAsync();
                return new
                {
                    deskCount = deskCount,
                    allApplicationsCount = allApplicationsCount,
                    allProcessingCount = allProcessingCount,
                    allApprovalsCount = allApprovalsCount
                };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

        [HttpGet("GetAppsOnMyDesk")]
        public async Task<object> GetAppsOnMyDesk()
        {
            try
            {
                var applications = await (from dsk in _context.MyDesks
                                          join app in _context.Applications on dsk.AppId equals app.Id
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                          join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                          join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          where admin.Id == WKPCompanyNumber && dsk.HasWork != true
                                          select new Application_Model
                                          {
                                              Id= app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.Concession_Held,
                                              FieldName = _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              CompanyName = comp.COMPANY_NAME,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data= applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpGet("All-Applications")] //For general application view
        public async Task<object> AllApplications()
        {
            try
            {
                var applications = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          //join field in _context.COMPANY_FIELDs on app.FieldID equals field.Field_ID
                                          join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          select new Application_Model
                                          {
                                              Id= app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.ConcessionName,
                                              FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              CompanyName = comp.COMPANY_NAME,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data= applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        } 
        [HttpGet("CompanyRejectedApplications")] //For general application view
        public async Task<object> CompanyRejectedApplications()
        {
            try
            {
                var applications = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join cmt in _context.SBU_ApplicationComments on app.Id equals cmt.AppID 
                                          join sbu in _context.StrategicBusinessUnits on cmt.SBU_ID equals sbu.Id
                                          where app.DeleteStatus != true && app.Status == GeneralModel.Rejected && cmt.ActionStatus == GeneralModel.Initiated
                                          select new Application_Model
                                          {
                                              Last_SBU = sbu.SBU_Name,
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              RejectId = cmt.Id,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName =  _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x=> x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                              FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x=> x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              SBU_Comment = cmt.SBU_Comment,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              Status = app.Status,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data= applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        [HttpPost("Resubmit_RejectedApplication")] //For general application view
        public async Task<object> Resubmit_RejectedApplication(int appID, int rejectID)
        {
            try
            {
                var NRejectApp = _context.SBU_ApplicationComments.Where(x => x.AppID == appID && x.Id == rejectID).FirstOrDefault();
                if (NRejectApp != null)
                {
                    NRejectApp.ActionStatus = GeneralModel.Completed;
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var application = await (from app in _context.Applications
                                                  join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                                  join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                                  select new {app, comp, con}).FirstOrDefaultAsync();


                        var getStaff = (from stf in _context.staff where stf.StaffID == NRejectApp.Staff_ID select stf).FirstOrDefault();

                        var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();
                        string subject = $"Company response to rejected WORK PROGRAM application with ref: {application.app.ReferenceNo} ({application.con.Concession_Held} - {application.app.YearOfWKP}).";
                        string content = $"{application.comp.COMPANY_NAME} has responded to rejected WORK PROGRAM application for year {application.app.YearOfWKP}";
                        var emailMsg = _helpersController.SaveMessage(application.app.Id, getStaff.StaffID, subject, content, "Staff");
                        var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                        return new WebApiResponse {ResponseCode = AppResponseCodes.Success, Message = "Application feedback has been sent successfully.", StatusCode = ResponseCodes.Success };

                    }
                }
                return BadRequest(new { message = "Error : Rejected/Commented application could not be found." });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

       [HttpGet("RejectedApplications")] //For general application view
        public async Task<object> RejectedApplications()
        {
            try
            {
                var applications = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join dsk in _context.MyDesks on app.Id equals dsk.AppId into desks
                                          join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          join SBU in _context.StrategicBusinessUnits on desks.OrderByDescending(x=> x.DeskID).FirstOrDefault().FromSBU equals SBU.Id.ToString()
                                          where app.DeleteStatus != true && app.Status == GeneralModel.Rejected
                                          select new Application_Model
                                          {
                                              Last_SBU = SBU.SBU_Name,
                                              Id= app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.ConcessionName,
                                              FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x=> x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              CompanyName = comp.COMPANY_NAME,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data= applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
       
        [HttpPost("ApproveRejection")]
        public async Task<object> ApproveRejection(int SBU_ID, string comment, string[] selectedApps )
        {
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);
                        //get current staff desk
                        var dsk = await _context.MyDesks.Where(x => x.AppId == appId).OrderByDescending(x => x.DeskID).FirstOrDefaultAsync();
                        var get_CurrentStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.StaffID == dsk.StaffID && stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();
                        var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        if (application.FieldID != null)
                        {
                            var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
                        }
                        _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection Approval", "Planning approves SBU rejection to company.");

                        //send mail to staff that initiates rejection
                        string subject = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                        string content = $"Planning approves WORK PROGRAM application rejection to company for year {application.YearOfWKP}.";
                        var emailMsg = _helpersController.SaveMessage(application.Id, get_CurrentStaff.StaffID, subject, content, "Staff");
                        var sendEmail = _helpersController.SendEmailMessage(get_CurrentStaff.StaffEmail, get_CurrentStaff.FirstName, emailMsg, null);
                        //send mail to company
                        string subject2 = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                            string content2 = $"Rejected WORK PROGRAM application for year {application.YearOfWKP} with comment{dsk.Comment}.";
                            var emailMsg2 = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
                            var sendEmail2 = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

                            _helpersController.LogMessages("Rejection of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been pushed successfully.", StatusCode = ResponseCodes.Success };

                        }
                    }
                else
                {
                    return BadRequest(new { message = "Error: No application ID was passed for this action to be completed." });
                }

                return BadRequest(new { message = "Error: No application ID was passed for this action to be completed." });
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return BadRequest(new { message = $"An error occured while rejecting application." + x.Message.ToString() });
            }

        }

        [HttpGet("ViewApplication")] //For specific application view
        public async Task<object> ViewApplication(int appID)
        {
            try
            {
                var application = (from ap in _context.Applications where ap.Id == appID && ap.DeleteStatus != true select ap).FirstOrDefault();

                if (application == null)
                {
                    return BadRequest(new { message = "Sorry, this application details could not be found."});
                }
                var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == application.FieldID).FirstOrDefaultAsync();
                var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == application.ConcessionID).FirstOrDefaultAsync();
                var company = await _context.ADMIN_COMPANY_INFORMATIONs.Where(x => x.Id == application.CompanyID).FirstOrDefaultAsync();
                var appHistory = await (from his in _context.ApplicationDeskHistories
                                        join stf in _context.staff on his.StaffID equals stf.StaffID
                                        join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                        join rol in _context.Roles on stf.RoleID equals rol.id
                                        join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                        select new ApplicationDeskHistory_Model
                                        {
                                            ID = his.Id,
                                            Staff_Name = stf.FirstName + " " + stf.LastName,
                                            Staff_Email = stf.StaffEmail,
                                            Staff_SBU = sbu.SBU_Name,
                                            Staff_Role = rol.RoleName,
                                            Comment = his.Comment
                                        }).ToListAsync();
                var staffDesk = (from dsk in _context.MyDesks
                                 join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                 join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                 join rol in _context.Roles on stf.RoleID equals rol.id
                                 join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                 where dsk.HasWork!= true && stf.ActiveStatus != false && stf.DeleteStatus != true
                                 select new Staff_Model
                                 {
                                     Desk_ID = dsk.DeskID,
                                     Sort = dsk.Sort,
                                     Staff_Name = stf.FirstName +" "+ stf.LastName,
                                     Staff_Email = stf.StaffEmail,
                                     Staff_SBU = sbu.SBU_Name,
                                     Staff_Role = rol.RoleName
                                 }).ToList();
                var documents = await _context.SubmittedDocuments.Where(x => x.CreatedBy == application.CompanyID.ToString() && x.YearOfWKP == application.YearOfWKP).Take(10).ToListAsync();
                var appDetails = new ApplicationDetailsModel
                {
                    Application = application,
                    Field = field,
                    Concession = concession,
                    Company = company,
                    Staff = staffDesk,
                    Application_History = appHistory.OrderByDescending(x => x.ID).Take(3).ToList(),
                    Document = documents
                };
                return new WebApiResponse { Data= appDetails, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

        [HttpGet("ProcessApplication")] //For processing application view
        public async Task<object> ProcessApplication(int appID)
        {
            try
            {
                var application = (from ap in _context.Applications where ap.Id == appID && ap.DeleteStatus != true select ap).FirstOrDefault();

                if (application == null)
                {
                    return BadRequest(new { message = "Sorry, this application details could not be found."});
                }
                var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == application.FieldID).FirstOrDefaultAsync();
                var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == application.ConcessionID).FirstOrDefaultAsync();
                var company = await _context.ADMIN_COMPANY_INFORMATIONs.Where(x => x.Id == application.CompanyID).FirstOrDefaultAsync();
                var appHistory = await (from his in _context.ApplicationDeskHistories
                                        join stf in _context.staff on his.StaffID equals stf.StaffID
                                        join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                        join rol in _context.Roles on stf.RoleID equals rol.id
                                        join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                        select new ApplicationDeskHistory_Model
                                        {
                                            ID = his.Id,
                                            Staff_Name = stf.FirstName + " " + stf.LastName,
                                            Staff_Email = stf.StaffEmail,
                                            Staff_SBU = sbu.SBU_Name,
                                            Staff_Role = rol.RoleName,
                                            Comment = his.Comment
                                        }).ToListAsync();

                var staffDesk = (from dsk in _context.MyDesks
                                 join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                 join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                 join rol in _context.Roles on stf.RoleID equals rol.id
                                 join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                 where admin.Id == WKPCompanyNumber && dsk.AppId == appID && dsk.HasWork != true && stf.ActiveStatus != false && stf.DeleteStatus != true
                                 select new Staff_Model
                                 {
                                     Desk_ID = dsk.DeskID,
                                     Staff_Name = stf.FirstName + " " + stf.LastName,
                                     Staff_Email = stf.StaffEmail,
                                     Staff_SBU = sbu.SBU_Name,
                                     Staff_Role = rol.RoleName,
                                     Sort = dsk.Sort
                                 }).ToList();
                var documents = await _context.SubmittedDocuments.Where(x => x.CreatedBy == application.CompanyID.ToString() && x.YearOfWKP == application.YearOfWKP).Take(10).ToListAsync();
                var appDetails = new ApplicationDetailsModel
                {
                    Application = application,
                    Field = field,
                    Concession = concession,
                    Company = company,
                    Staff = staffDesk,
                    Application_History = appHistory.OrderByDescending(x => x.ID).Take(3).ToList(),
                    Document = documents,
                    SBU = await _context.StrategicBusinessUnits.ToListAsync()
                };
                return new WebApiResponse { Data = appDetails, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

        //year: year, omlName: omlName, fieldName: fieldName
        //public async Task<object> SubmitApplication(string year, int concessionID, int fieldID)
        [HttpPost("SubmitApplication")]
        public async Task<object> SubmitApplication(string year, string omlName, string fieldName)
        {
            try
            {
                int yearID = Convert.ToInt32(year);
                var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Concession_Held.ToLower() == omlName.ToLower() select d).FirstOrDefaultAsync();
                var field = await (from d in _context.COMPANY_FIELDs where d.Field_Name.ToLower() == fieldName.ToLower() || d.Field_ID.ToString() == fieldName select d).FirstOrDefaultAsync();
                var checkApplication = (from ap in _context.Applications
                                        where ap.YearOfWKP == yearID && ap.ConcessionID == concession.Consession_Id
                                         && ap.DeleteStatus != true
                                        select ap).FirstOrDefault();
                if (field != null)
                {
                    checkApplication = (from ap in _context.Applications
                                        where ap.YearOfWKP == yearID && ap.ConcessionID == concession.Consession_Id
                                                        && ap.FieldID == field.Field_ID && ap.DeleteStatus != true
                                        select ap).FirstOrDefault();

                }
                if (checkApplication != null)
                {
                    return BadRequest(new { message = "Sorry, this application details could not be found."});
                }

                Task<List<ApplicationProcessModel>> getApplicationProcess = _helpersController.GetApplicationProccess(GeneralModel.New, 0);

                if (getApplicationProcess.Result.Count <= 0)
                {
                    return BadRequest(new { message = "An error occured while trying to get process flow for this application."});
                }

                Application application = new Application();
                application.ReferenceNo = _helpersController.Generate_Reference_Number();
                application.YearOfWKP = yearID;
                application.ConcessionID = concession.Consession_Id;
                application.FieldID = field?.Field_ID;
                application.CompanyID = (int)WKPCompanyNumber;
                application.CategoryID = _context.ApplicationCategories.Where(x => x.Name == GeneralModel.New).FirstOrDefault().Id;
                application.Status = GeneralModel.Processing;
                application.PaymentStatus = GeneralModel.PaymentPending;
                application.CurrentDesk = getApplicationProcess.Result.FirstOrDefault().StaffId; //to change
                application.Submitted = true;
                application.CreatedAt = DateTime.Now;
                application.SubmittedAt = DateTime.Now;
                _context.Applications.Add(application);

                if (_context.SaveChanges() > 0)
                {
                    string subject2 = $"{year} submission of WORK PROGRAM application for {WKPCompanyName} field - {field?.Field_Name} : {application.ReferenceNo}";

                    foreach (var staff in getApplicationProcess.Result.ToList())
                    {
                        int saveStaffDesk = _helpersController.RecordStaffDesk(application.Id, staff);

                        if (saveStaffDesk > 0)
                        {
                            _helpersController.SaveHistory(application.Id, staff.StaffId, "Submitted", "Application submitted and landed on staff desk");

                            //send mail to staff
                            //var getStaff = (from stf in _context.staff where stf.StaffID == staff.StaffId select stf).FirstOrDefault();
                            var getStaff = (from stf in _context.staff
                                            join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                            where stf.StaffID == staff.StaffId && stf.DeleteStatus != true
                                            select stf).FirstOrDefault();
                            string content2 = $"{WKPCompanyName} have submitted their WORK PROGRAM application for year {year}.";
                            var emailMsg2 = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject2, content2, "Staff");
                            var sendEmail2 = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg2, null);

                            _helpersController.LogMessages("Submission of application with REF : " + application.ReferenceNo, WKPCompanyEmail);

                        }
                        else
                        {
                            return BadRequest(new { message = "An error occured while trying to submit this application to a staff."});
                        }
                    }
                    //send mail to company
                    string subject = $"{year} submission of WORK PROGRAM application for field - {field?.Field_Name} : {application.ReferenceNo}";
                    string content = $"You have successfully submitted your WORK PROGRAM application for year {year}, and it is currently being reviewed.";
                    var emailMsg = _helpersController.SaveMessage(application.Id, (int)WKPCompanyNumber, subject, content, "Company");
                    var sendEmail = _helpersController.SendEmailMessage(WKPCompanyEmail, WKPCompanyName, emailMsg, null);
                    var responseMsg = field != null ? $"{year} Application for field {field?.Field_Name} has been submitted successfully." : $"{year} Application for concession: ({concession.ConcessionName}) has been submitted successfully.";
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMsg, StatusCode = ResponseCodes.Success };

                }
                else
                {
                    return BadRequest(new { message = "An error occured while trying to save this application record."});
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

        [HttpPost("PushApplication")]
        public async Task<object> PushApplication(int deskID, string comment, string[] selectedApps)
        {
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);
                        //get current staff desk
                        var get_CurrentStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();
                        var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();
                        var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        if (application.FieldID != null)
                        {
                            var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
                        }
                       
                        Task<List<ApplicationProcessModel>> getApplicationProcess = _helpersController.GetApplicationProccess(GeneralModel.New, staffDesk.Sort, (int)get_CurrentStaff.Staff_SBU);

                        if (getApplicationProcess.Result.Count > 0)
                        {
                            foreach (var staff in getApplicationProcess.Result.ToList())
                            {
                                int saveStaffDesk = _helpersController.RecordStaffDesk(application.Id, staff);

                                if (saveStaffDesk > 0)
                                {
                                    _helpersController.SaveHistory(application.Id, staff.StaffId, "Moved", comment);
                                    
                                    //update staff desk
                                    staffDesk.HasPushed = true;
                                    staffDesk.HasWork = true;
                                    staffDesk.UpdatedAt = DateTime.Now;
                                    _context.SaveChanges();

                                    //send mail to staff
                                    var getStaff = (from stf in _context.staff
                                                    join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                    where stf.StaffID == staff.StaffId && stf.DeleteStatus != true
                                                    select stf).FirstOrDefault();

                                    string subject = $"Push for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                    string content = $"{WKPCompanyName} have submitted their WORK PROGRAM application for year {application.YearOfWKP}.";
                                    var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");
                                    var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                                    _helpersController.LogMessages("Submission of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been pushed successfully.", StatusCode = ResponseCodes.Success };
                                }
                                else
                                {
                                    return BadRequest(new { message = "An error occured while trying to submit this application to a staff."});
                                }

                            }
                        }
                        else
                        {
                            return BadRequest(new { message = "An error occured while trying to get process flow for this application."});
                        }
                    }
                }
                else
                {
                    return BadRequest(new { message = "Error: No application ID was passed for this action to be completed."});
                }

                return BadRequest(new { message = "Error: No application ID was passed for this action to be completed."});
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return BadRequest(new { message = $"An error occured while pushing application to staff."+ x.Message.ToString()});
            }

        }
        [HttpPost("RejectApplication")]
        public async Task<object> RejectApplication(int deskID, string comment, string[] selectedApps, int SBU_ID)
        {
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);
                        //get current staff desk
                        var get_CurrentStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();

                        var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();
                        var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        if (application.FieldID != null)
                        {
                            var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
                        }

                        if (staffDesk.Sort == 1) //Rejection to company
                        {
                            var getStaff = (from stf in _context.staff where stf.StaffID == staffDesk.StaffID select stf).FirstOrDefault();
                            var NRejectApp = _context.SBU_ApplicationComments.Where(x => x.AppID == appId && x.SBU_ID == getStaff.Staff_SBU && x.ActionStatus == GeneralModel.Initiated);
                            if (NRejectApp == null)
                            {
                                var nReject = new SBU_ApplicationComment()
                                {
                                    SBU_Comment = comment,
                                    SBU_ID = getStaff.Staff_SBU,
                                    Staff_ID = getStaff.StaffID,
                                    ActionStatus = GeneralModel.Initiated,
                                    AppID = appId,
                                    DateCreated = DateTime.Now,
                                };
                                await _context.SBU_ApplicationComments.AddAsync(nReject);
                                if (await _context.SaveChangesAsync() > 0)
                                {
                                    var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();
                                    string subject = $"Comment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                    string content = $"{SBU?.SBU_Name} made comment on your WORK PROGRAM application for year {application.YearOfWKP}. See comment :- " + comment;
                                    var emailMsg = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
                                    var sendEmail = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);
                                }
                            }
                        }
                        else
                        {
                            var prevDesk = (from dsk in _context.MyDesks
                                            join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                            where stf.Staff_SBU == get_CurrentStaff.Staff_SBU && dsk.Sort == staffDesk.Sort - 1 && stf.DeleteStatus != true
                                            select dsk).FirstOrDefault();

                            if (SBU_ID > 0) //planning rejecting back to a particular SBU
                            {
                                 prevDesk = (from dsk in _context.MyDesks
                                                join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                                where stf.Staff_SBU == SBU_ID && dsk.Sort == staffDesk.Sort - 1 && stf.DeleteStatus != true
                                                select dsk).FirstOrDefault();
                            }
                            if (prevDesk != null)
                            {
                                //update staff desk
                                staffDesk.HasPushed = true;
                                staffDesk.HasWork = true;
                                staffDesk.UpdatedAt = DateTime.Now;
                                prevDesk.HasPushed = false;
                                prevDesk.HasWork = false; 
                                prevDesk.UpdatedAt = DateTime.Now;
                                _context.SaveChanges();

                                _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection", comment);

                                //send mail to staff
                                var getStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.StaffID == prevDesk.StaffID && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();

                                string subject = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"{WKPCompanyName} rejected WORK PROGRAM application for year {application.YearOfWKP}.";
                                var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");
                                var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                                _helpersController.LogMessages("Rejection of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been rejected successfully.", StatusCode = ResponseCodes.Success };
                            }
                            else
                            {
                                return BadRequest(new { message = "An error occured while trying to reject this application."});
                            }

                        }
                    }
                }
                else
                {
                    return BadRequest(new { message = "Error: No application ID was passed for this action to be completed."});
                }

                return BadRequest(new { message = "Error: No action was carried out on this application."});
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return BadRequest(new { message = $"An error occured while rejecting application."+ x.Message.ToString()});
            }

        }

        [HttpPost("Old_RejectApplication")]
        public async Task<object> Old_RejectApplication(int deskID, string comment, string[] selectedApps, int SBU_ID)
        {
            var responseMessage = "";
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);
                        //get current staff desk
                        var get_CurrentStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();

                        var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();
                        var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        if (application.FieldID != null)
                        {
                            var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
                        }

                        if (staffDesk.Sort == 1) //Rejection to company
                        {

                            _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection", "Application was rejected to company");

                            //update staff desk
                            staffDesk.HasPushed = true;
                            staffDesk.HasWork = true;
                            staffDesk.UpdatedAt = DateTime.Now;

                            application.Status = GeneralModel.Rejected;
                            _context.SaveChanges();

                            //send mail to staff
                            var getStaff = (from stf in _context.staff
                                            join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                            where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                            select stf).FirstOrDefault();

                            //string subject = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                            //string content = $"{WKPCompanyName} rejected WORK PROGRAM application for year {application.YearOfWKP}.";
                            //var emailMsg = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
                            //var sendEmail = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

                            _helpersController.LogMessages("Rejection of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been rejected successfully.", StatusCode = ResponseCodes.Success };

                        }
                        else
                        {
                            var prevDesk = (from dsk in _context.MyDesks
                                            join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                            where stf.Staff_SBU == get_CurrentStaff.Staff_SBU && dsk.Sort == staffDesk.Sort - 1 && stf.DeleteStatus != true
                                            select dsk).FirstOrDefault();

                            if (SBU_ID > 0) //planning rejecting back to a particular SBU
                            {
                                 prevDesk = (from dsk in _context.MyDesks
                                                join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                                where stf.Staff_SBU == SBU_ID && dsk.Sort == staffDesk.Sort - 1 && stf.DeleteStatus != true
                                                select dsk).FirstOrDefault();
                            }
                            if (prevDesk != null)
                            {
                                //update staff desk
                                staffDesk.HasPushed = true;
                                staffDesk.HasWork = true;
                                staffDesk.UpdatedAt = DateTime.Now;
                                prevDesk.HasPushed = false;
                                prevDesk.HasWork = false; 
                                prevDesk.UpdatedAt = DateTime.Now;
                                _context.SaveChanges();

                                _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection", comment);

                                //send mail to staff
                                var getStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.StaffID == prevDesk.StaffID && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();

                                string subject = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"{WKPCompanyName} rejected WORK PROGRAM application for year {application.YearOfWKP}.";
                                var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");
                                var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                                _helpersController.LogMessages("Rejection of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been rejected successfully.", StatusCode = ResponseCodes.Success };
                            }
                            else
                            {
                                return BadRequest(new { message = "An error occured while trying to reject this application."});
                            }

                        }
                    }
                }
                else
                {
                    return BadRequest(new { message = "Error: No application ID was passed for this action to be completed."});
                }

                return BadRequest(new { message = "Error: No application ID was passed for this action to be completed."});
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return BadRequest(new { message = $"An error occured while rejecting application."+ x.Message.ToString()});
            }

        }
        
        [HttpPost("ApproveApplication")]
        public async Task<object> ApproveApplication(int deskID, string comment, string[] selectedApps)
        {
            var responseMessage = "";
            try
            {
                foreach (var b in selectedApps)
                {
                    string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                    int appId = int.Parse(appID);
                    //get current staff desk
                    var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId ).FirstOrDefault();

                    var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();
                    var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                    var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();

                    //Update Staff Desk
                    staffDesk.HasPushed = true;
                    staffDesk.HasWork = true;
                    staffDesk.UpdatedAt = DateTime.Now;
                    application.Status = GeneralModel.Approved;
                    _context.SaveChanges();

                    var p = _helpersController.CreatePermit(application);

                    responseMessage += "You have APPROVED this application (" + application.ReferenceNo + ")  and approval has been generated. Approval No: " + p + Environment.NewLine;
                    //var staff = _context.staff.Where(x => x.StaffID == int.Parse(WKPCompanyId) && x.DeleteStatus != true).FirstOrDefault();
                    var staff = (from stf in _context.staff
                                 join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                 where stf.StaffID == int.Parse(WKPCompanyId) && stf.DeleteStatus != true
                                 select stf).FirstOrDefault();

                    if (!p.ToLower().Contains("error"))
                    {

                        //string body = "";
                        //var up = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                        //string file = up + @"\\Templates\" + "InternalMemo.txt";
                        //using (var sr = new StreamReader(file))
                        //{
                        //    body = sr.ReadToEnd();
                        //}

                        //send email to staff approver
                        string subject = $"Approval For Application With REF: {application.ReferenceNo}";
                        string content = $"An approval has been generated for application with reference: " + application.ReferenceNo + " for " + field.Field_Name + "(" + Company.NAME + ").";

                        var emailMsg = _helpersController.SaveMessage(appId, staff.StaffID, subject, content, "Staff");
                        var sendEmail = _helpersController.SendEmailMessage(staff.StaffEmail, staff.FirstName, emailMsg, null);

                        _helpersController.LogMessages("Approval generated successfully for field => " + field.Field_Name + ". Application Reference : " + application.ReferenceNo, WKPCompanyEmail);
                        _helpersController.SaveHistory(appId, staff.StaffID, GeneralModel.Approved, staff.StaffEmail + "Final Approval For Application With Ref: " + application.ReferenceNo);

                        responseMessage = "Application(s) has been approved and permit approval generated successfully.";
                    }
                    else
                    {
                        responseMessage += "An error occured while trying to generate approval ref for this application." + Environment.NewLine;

                        //Update My Process
                        staffDesk.HasPushed = false;
                        staffDesk.HasWork = false;
                        staffDesk.UpdatedAt = DateTime.Now;
                        _context.SaveChanges();
                    }
                    return BadRequest(new { message = responseMessage});
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMessage, StatusCode = ResponseCodes.Success };
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.ToString()}");
                return BadRequest(new { message = $"An error occured while approving application(s)."});
            }

        }

        [HttpGet("All-Companies")]
        public async Task<object> AllCompanies()
        {
            try
            {
                var companies = await _context.ADMIN_COMPANY_INFORMATIONs.Where(ap => ap.DESIGNATION != "Admin").ToListAsync();

                return new WebApiResponse { Data = companies, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

        #region Minimum Requirement
        [HttpGet("Get_Planning_Requirement")]
        public async Task<object> Get_Planning_Requirement(string year, string omlName, string fieldName, string actionToDo)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                var getData = await (from d in _context.Planning_MinimumRequirements
                                     where
                                    d.CompanyNumber == WKPCompanyNumber && d.Year == int.Parse(year) &&
                                    d.ConcessionID == concessionField.Result.Concession_ID
                                     select d).FirstOrDefaultAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = getData, StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error : " + ex.Message});
            }
        }

        [HttpPost("Post_Planning_Requirement")]
        public async Task<object> Post_Planning_Requirement([FromBody] Planning_MinimumRequirement model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert : actionToDo;
            try
            {
                #region Saving Field

                model.ConcessionID = concessionField.Result.Concession_ID;
                model.CompanyNumber = WKPCompanyNumber;
                model.Year = int.Parse(year);

                if (action == GeneralModel.Insert)
                {
                    var data = await (from c in _context.Planning_MinimumRequirements where c.CompanyNumber == WKPCompanyNumber && c.ConcessionID == concessionField.Result.Concession_ID && c.Year == int.Parse(year) select c).FirstOrDefaultAsync();

                    if (data != null)
                    {

                        _context.Planning_MinimumRequirements.Remove(data);
                        model.DateCreated = DateTime.Now;

                        await _context.Planning_MinimumRequirements.AddAsync(model);


                        //return BadRequest(new { message = $"Error : This data is already existing and can not be duplicated."});
                    }
                    else
                    {
                        model.DateCreated = DateTime.Now;
                        await _context.Planning_MinimumRequirements.AddAsync(model);
                    }
                }
                else
                {
                    var data = await (from d in _context.Planning_MinimumRequirements
                                      where d.Id.ToString() == id && d.CompanyNumber == WKPCompanyNumber
                                      select d).FirstOrDefaultAsync();

                    if (action == GeneralModel.Update)
                    {
                        if (data == null)
                        {
                            return BadRequest(new { message = $"Error : This details could not be found."});
                        }
                        else
                        {
                            _context.Planning_MinimumRequirements.Remove(data);
                            model.DateCreated = DateTime.Now;
                            await _context.Planning_MinimumRequirements.AddAsync(model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.Planning_MinimumRequirements.Remove(data);
                    }
                }
                save += await _context.SaveChangesAsync();
                #endregion

                if (save > 0)
                {
                    string successMsg = "Data has been " + action + "D successfully.";
                    var allData = await (from d in _context.Planning_MinimumRequirements
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form."});

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});

            }
        }

        [HttpGet("Get_HSE_Requirement")]
        public async Task<object> Get_HSE_Requirement(string year, string omlName, string fieldName, string actionToDo)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);



                var getData = await (from d in _context.HSE_MinimumRequirements
                                     where
                                    d.CompanyNumber == WKPCompanyNumber && d.Year == int.Parse(year) &&
                                    d.ConcessionID == concessionField.Result.Concession_ID
                                     select d).FirstOrDefaultAsync();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = getData, StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error : " + ex.Message});
            }
        }

        [HttpPost("Post_HSE_Requirement")]
        public async Task<object> Post_HSE_Requirement([FromBody] HSE_MinimumRequirement model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");

            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert : actionToDo;
            try
            {
                #region Saving Field

                model.ConcessionID = concessionField.Result.Concession_ID;

                model.CompanyNumber = WKPCompanyNumber;
                model.Year = int.Parse(year);

                if (action == GeneralModel.Insert)
                {
                    var data = await (from c in _context.HSE_MinimumRequirements where c.CompanyNumber == WKPCompanyNumber && c.ConcessionID == concessionField.Result.Concession_ID && c.Year == int.Parse(year) select c).FirstOrDefaultAsync();

                    if (data != null)
                    {

                        _context.HSE_MinimumRequirements.Remove(data);
                        model.DateCreated = DateTime.Now;
                        await _context.HSE_MinimumRequirements.AddAsync(model);

                        //return BadRequest(new { message = $"Error : This data is already existing and can not be duplicated."});
                    }
                    else
                    {
                        model.DateCreated = DateTime.Now;
                        await _context.HSE_MinimumRequirements.AddAsync(model);
                    }
                }
                else
                {
                    var data = await (from d in _context.HSE_MinimumRequirements
                                      where d.Id.ToString() == id && d.CompanyNumber == WKPCompanyNumber
                                      select d).FirstOrDefaultAsync();

                    if (action == GeneralModel.Update)
                    {
                        if (data == null)
                        {
                            return BadRequest(new { message = $"Error : This details could not be found."});
                        }
                        else
                        {
                            _context.HSE_MinimumRequirements.Remove(data);
                            model.DateCreated = DateTime.Now;
                            await _context.HSE_MinimumRequirements.AddAsync(model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_MinimumRequirements.Remove(data);
                    }
                }
                save += await _context.SaveChangesAsync();
                #endregion

                if (save > 0)
                {
                    string successMsg = "Data has been " + action + "D successfully.";

                    var allData = await (from d in _context.HSE_MinimumRequirements
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form."});

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});

            }
        }

        [HttpGet("Get_DecommisioningAbandonment")]
        public async Task<object> Get_DecommisioningAbandonment(string year, string omlName, string fieldName, string actionToDo)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                var getData = await (from d in _context.DecommissioningAbandonments
                                     where
                                    d.CompanyNumber == WKPCompanyNumber && d.Year == int.Parse(year) &&
                                    d.ConcessionID == concessionField.Result.Concession_ID
                                     select d).FirstOrDefaultAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = getData, StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error : " + ex.Message});
            }
        }

        [HttpPost("Post_DecommisioningAbandonment")]
        public async Task<object> Post_DecommisioningAbandonment([FromBody] DecommissioningAbandonment model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert : actionToDo;
            try
            {
                #region Saving Data

                model.ConcessionID = concessionField.Result.Concession_ID;
                model.CompanyNumber = WKPCompanyNumber;
                model.Year = int.Parse(year);

                if (action == GeneralModel.Insert)
                {
                    var data = await (from c in _context.DecommissioningAbandonments where c.CompanyNumber == WKPCompanyNumber && c.ConcessionID == concessionField.Result.Concession_ID && c.Year == int.Parse(year) select c).FirstOrDefaultAsync();

                    if (data != null)
                    {
                        return BadRequest(new { message = $"Error : This data is already existing and can not be duplicated."});
                    }
                    else
                    {
                        model.DateCreated = DateTime.Now;
                        await _context.DecommissioningAbandonments.AddAsync(model);
                    }
                }
                else
                {
                    var data = await (from d in _context.DecommissioningAbandonments
                                      where d.Id.ToString() == id && d.CompanyNumber == WKPCompanyNumber
                                      select d).FirstOrDefaultAsync();

                    if (action == GeneralModel.Update)
                    {
                        if (data == null)
                        {
                            return BadRequest(new { message = $"Error : This details could not be found."});
                        }
                        else
                        {
                            _context.DecommissioningAbandonments.Remove(data);
                            model.DateCreated = DateTime.Now;
                            await _context.DecommissioningAbandonments.AddAsync(model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.DecommissioningAbandonments.Remove(data);
                    }
                }
                save += await _context.SaveChangesAsync();
                #endregion

                if (save > 0)
                {
                    string successMsg = "Data has been " + action + "D successfully.";
                    var allData = await (from d in _context.DecommissioningAbandonments
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form."});

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});

            }
        }

        [HttpGet("Get_Development_Production")]
        public async Task<object> Get_Development_Production(string year, string omlName, string fieldName)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                var getData = await (from d in _context.Development_And_Productions
                                     where
                                    d.CompanyNumber == WKPCompanyNumber && d.Year == int.Parse(year) &&
                                    d.ConcessionID == concessionField.Result.Concession_ID
                                     select d).FirstOrDefaultAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = getData, StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error : " + ex.Message});
            }
        }

        [HttpPost("Post_Development_Production")]
        public async Task<object> Post_Development_Production([FromBody] Development_And_Production model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert : actionToDo;
            try
            {
                #region Saving Data

                model.ConcessionID = concessionField.Result.Concession_ID;
                model.CompanyNumber = WKPCompanyNumber;
                model.Year = int.Parse(year);

                if (action == GeneralModel.Insert)
                {
                    var data = await (from c in _context.Development_And_Productions where c.CompanyNumber == WKPCompanyNumber && c.ConcessionID == concessionField.Result.Concession_ID && c.Year == int.Parse(year) select c).FirstOrDefaultAsync();

                    if (data != null)
                    {
                        return BadRequest(new { message = $"Error : This data is already existing and can not be duplicated."});
                    }
                    else
                    {
                        model.DateCreated = DateTime.Now;
                        await _context.Development_And_Productions.AddAsync(model);
                    }
                }
                else
                {
                    var data = await (from d in _context.Development_And_Productions
                                      where d.Id.ToString() == id && d.CompanyNumber == WKPCompanyNumber
                                      select d).FirstOrDefaultAsync();

                    if (action == GeneralModel.Update)
                    {
                        if (data == null)
                        {
                            return BadRequest(new { message = $"Error : This details could not be found."});
                        }
                        else
                        {
                            _context.Development_And_Productions.Remove(data);
                            model.DateCreated = DateTime.Now;
                            await _context.Development_And_Productions.AddAsync(model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.Development_And_Productions.Remove(data);
                    }
                }
                save += await _context.SaveChangesAsync();
                #endregion

                if (save > 0)
                {
                    string successMsg = "Data has been " + action + "D successfully.";
                    var allData = await (from d in _context.Development_And_Productions
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form."});

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});

            }
        }

        [HttpGet("GET_CONCESSION_FIELD")]
        public async Task<ConcessionField> GET_CONCESSION_FIELD(string omlName, string fieldName)
        {
            try
            {
                var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).FirstOrDefaultAsync();
                var field = await (from d in _context.COMPANY_FIELDs where d.Field_Name == fieldName && d.DeletedStatus != true select d).FirstOrDefaultAsync();

                return new ConcessionField
                {
                    Concession_ID = concession.Consession_Id,
                    Concession_Name = concession.ConcessionName,
                    Consession_Type = concession.Consession_Type,
                    Terrain = concession.Terrain,
                    Field_Name = field?.Field_Name,
                    Field_ID = field?.Field_ID,
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region Configuration
        [HttpGet("GetProcessFlow")]
        public async Task<object> GetProcessFlow()
        {
            try
            {
                var processes = await (from prc in _context.ApplicationProccesses
                                join sbu in _context.StrategicBusinessUnits on prc.SBU_ID equals sbu.Id
                                join role in _context.Roles on prc.RoleID equals role.id
                                where prc.DeleteStatus != true 
                                select new
                                {
                                    Id= prc.ProccessID,
                                    Type = "New",
                                    Sort = prc.Sort,
                                    Role = role.RoleName,
                                    SBU = sbu.SBU_Name,
                                    Process = prc.Sort,
                                }).ToListAsync();
                var roles = await _context.Roles.ToListAsync(); 
                var SBUs = await _context.StrategicBusinessUnits.ToListAsync(); 

               return new
                {
                   Processes = processes,
                   Roles = roles,
                   SBUs = SBUs,
               };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("CreateProcess")]
        public async Task<object> CreateProcess(int roleID, int sbuID, int sort)
        {
            try
            {
                if (roleID <= 0 || sbuID <= 0 || sort <= 0)
                {
                    return BadRequest(new { message = $"Error : Role/SBU/Sort ID was not passed correctly." });
                }

                var process = await (from prc in _context.ApplicationProccesses
                                where prc.RoleID == roleID && prc.SBU_ID == sbuID && prc.Sort == sort && prc.DeleteStatus != true 
                               select prc).FirstOrDefaultAsync();
                if (process != null)
                {
                    return BadRequest(new { message = $"Error : Process is already existing and can not be duplicated." });
                }
                else
                {
                    var nProcess = new ApplicationProccess()
                    {
                        Sort = sort,
                        RoleID = roleID,
                        SBU_ID = sbuID,
                        CreatedAt = DateTime.Now,
                        DeleteStatus = false,
                        CategoryID = 1 //Default for new applications
                    };
                    await _context.ApplicationProccesses.AddAsync(nProcess);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var processes = await (from prc in _context.ApplicationProccesses
                                               join sbu in _context.StrategicBusinessUnits on prc.SBU_ID equals sbu.Id
                                               join role in _context.Roles on prc.RoleID equals role.id
                                               where prc.DeleteStatus != true
                                               select new
                                               {
                                                   Type = "New",
                                                   Sort = prc.Sort,
                                                   Role = role.RoleName,
                                                   SBU = sbu.SBU_Name,
                                                   Process = prc.Sort,
                                               }).ToListAsync();
                        var roles = await _context.Roles.ToListAsync();
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            Processes = processes,
                            Roles = roles,
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this process."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("EditProcess")]
        public async Task<object> EditProcess(int id, int roleID, int sbuID, int sort)
        {
            try
            {
                var process = await (from prc in _context.ApplicationProccesses
                                where prc.ProccessID == id && prc.DeleteStatus != true 
                               select prc).FirstOrDefaultAsync();
                if (process == null)
                {
                    return BadRequest(new { message = $"Error : Process details could not be found or an invalid ID was supplied."});
                }
                else
                {
                    var nProcess = new ApplicationProccess()
                    {
                        Sort = sort,
                        RoleID = roleID,
                        SBU_ID = sbuID,
                        CreatedAt = DateTime.Now,
                        DeleteStatus = false,
                        CategoryID = 1 //Default for new applications
                    };
                    await _context.ApplicationProccesses.AddAsync(nProcess);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var processes = await (from prc in _context.ApplicationProccesses
                                               join sbu in _context.StrategicBusinessUnits on prc.SBU_ID equals sbu.Id
                                               join role in _context.Roles on prc.RoleID equals role.id
                                               where prc.DeleteStatus != true
                                               select new
                                               {
                                                   Type = "New",
                                                   Sort = prc.Sort,
                                                   Role = role.RoleName,
                                                   SBU = sbu.SBU_Name,
                                                   Process = prc.Sort,
                                               }).ToListAsync();
                        var roles = await _context.Roles.ToListAsync();
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            Processes = processes,
                            Roles = roles,
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this process."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("DeleteProcess")]
        public async Task<object> DeleteProcess(int id)
        {
            try
            {
                var process = await (from prc in _context.ApplicationProccesses
                                where prc.ProccessID == id && prc.DeleteStatus != true 
                               select prc).FirstOrDefaultAsync();
                if (process == null)
                {
                    return BadRequest(new { message = $"Error : Process details could not be found or an invalid ID was supplied."});
                }
                else
                {
                    _context.ApplicationProccesses.Remove(process);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var processes = await (from prc in _context.ApplicationProccesses
                                               join sbu in _context.StrategicBusinessUnits on prc.SBU_ID equals sbu.Id
                                               join role in _context.Roles on prc.RoleID equals role.id
                                               where prc.DeleteStatus != true
                                               select new
                                               {
                                                   Type = "New",
                                                   Sort = prc.Sort,
                                                   Role = role.RoleName,
                                                   SBU = sbu.SBU_Name,
                                                   Process = prc.Sort,
                                               }).ToListAsync();
                        var roles = await _context.Roles.ToListAsync();
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            Processes = processes,
                            Roles = roles,
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this process."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }


        [HttpGet("GetSBUs")]
        public async Task<object> GetSBUs()
        {
            try
            {
                var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                return new
                {
                    SBUs = SBUs,
                };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("CreateSBU")]
        public async Task<object> CreateSBU(string name, string code)
        {
            try
            {
                var SBU = await (from sb in _context.StrategicBusinessUnits
                                where sb.SBU_Name.ToLower() == name.ToLower() 
                               select sb).FirstOrDefaultAsync();
                if (SBU != null)
                {
                    return BadRequest(new { message = $"Error : SBU is already existing and can not be duplicated."});
                }
                else
                {
                    var nSBU = new StrategicBusinessUnit()
                    {
                        SBU_Name = name,
                        SBU_Code = code
                    };
                    await _context.StrategicBusinessUnits.AddAsync(nSBU);

                    if (await _context.SaveChangesAsync() > 0)
                    {  
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("EditSBU")]
        public async Task<object> EditSBU(int id, string name, string code)
        {
            try
            {
                var SBU = await (from sb in _context.StrategicBusinessUnits
                                 where sb.SBU_Name.ToLower() == name.ToLower()
                                 select sb).FirstOrDefaultAsync();
                if (SBU == null)
                {
                    return BadRequest(new { message = $"Error : SBU details could not be found or an invalid ID was supplied."});
                }
                else
                {
                    SBU.SBU_Name = name.ToUpper();
                    SBU.SBU_Code = code.ToUpper();
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var SBUs = await (from sb in _context.StrategicBusinessUnits
                                         where sb.SBU_Name.ToLower() == name.ToLower()
                                         select sb).ToListAsync();
                        return new
                        {
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("DeleteSBU")]
        public async Task<object> DeleteSBU(int id)
        {
            try
            {
                var SBU = await (from sb in _context.StrategicBusinessUnits
                                 where sb.Id == id
                                 select sb).FirstOrDefaultAsync();
                if (SBU == null)
                {
                    return BadRequest(new { message = $"Error : SBU details could not be found or an invalid ID was supplied."});
                }
                else
                {
                    _context.StrategicBusinessUnits.Remove(SBU);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var SBUs = await (from sb in _context.StrategicBusinessUnits
                                         where sb.Id == id
                                         select sb).FirstOrDefaultAsync();
                        
                        return new
                        {
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }  
        
        [HttpGet("GetRoles")]
        public async Task<object> GetRoles()
        {
            try
            {
                var Roles = await _context.Roles.ToListAsync();

                return new
                {
                    Roles = Roles,
                };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("CreateRole")]
        public async Task<object> CreateRole(string name)
        {
            try
            {
                var Role = await (from sb in _context.Roles
                                where sb.RoleName.ToLower() == name.ToLower() 
                               select sb).FirstOrDefaultAsync();
                if (Role != null)
                {
                    return BadRequest(new { message = $"Error : Role is already existing and can not be duplicated."});
                }
                else
                {
                    var nRole = new Role()
                    {
                        RoleName = name
                    };
                    await _context.Roles.AddAsync(nRole);

                    if (await _context.SaveChangesAsync() > 0)
                    {  
                        var Roles = await _context.Roles.ToListAsync();

                        return new
                        {
                            Roles = Roles,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this Role."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("EditRole")]
        public async Task<object> EditRole(int id, string name)
        {
            try
            {
                var Role = await (from sb in _context.Roles
                                 where sb.RoleName.ToLower() == name.ToLower()
                                 select sb).FirstOrDefaultAsync();
                if (Role == null)
                {
                    return BadRequest(new { message = $"Error : Role details could not be found or an invalid ID was supplied."});
                }
                else
                {
                    Role.RoleName = name.ToUpper();
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var Roles = await (from sb in _context.Roles
                                         where sb.RoleName.ToLower() == name.ToLower()
                                         select sb).ToListAsync();
                        return new
                        {
                            Roles = Roles,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this Role."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }
        [HttpPost("DeleteRole")]
        public async Task<object> DeleteRole(int id)
        {
            try
            {
                var Role = await (from sb in _context.StrategicBusinessUnits
                                 where sb.Id == id
                                 select sb).FirstOrDefaultAsync();
                if (Role == null)
                {
                    return BadRequest(new { message = $"Error : Role details could not be found or an invalid ID was supplied."});
                }
                else
                {
                    _context.StrategicBusinessUnits.Remove(Role);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var Roles = await (from sb in _context.StrategicBusinessUnits
                                         where sb.Id == id
                                         select sb).FirstOrDefaultAsync();
                        
                        return new
                        {
                            Roles = Roles,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this Role."});
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message});
            }
        }

        #endregion

        #region SBU Report
        [HttpGet("GetSBU_Report")]
        public async Task<object> GetSBU_Report(int appID )
        {

            try
            {
                var application = (from ap in _context.Applications where ap.Id == appID select ap).FirstOrDefault();

                if (application != null)
                {
                    int? fieldID = 0;
                    if (application.FieldID != null)
                    {
                     fieldID = (int)application.FieldID;
                    }
                        var getStaffSBU = (from stf in _context.staff
                                       join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                       where stf.StaffEmail == WKPCompanyEmail
                                       //"allamin.m@dpr.gov.ng" 
                                       select sbu).FirstOrDefault();

                    string year = application.YearOfWKP.ToString();

                    switch (getStaffSBU.SBU_Code)
                    {

                        case "E&P":
                           
                                var geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                                var geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                                var drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                                var drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                                var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                                return new { geoActivitiesAcquisition = geoActivitiesAcquisition, geoActivitiesProcessing = geoActivitiesProcessing, drillEachCost = drillEachCost, drillEachCostProposed = drillEachCostProposed, drillOperationCategoriesWell = drillOperationCategoriesWell };
                           
                            break;
                        case "PLN":
                          
                                var BudgetActualExpenditure = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var BudgetPerformanceExploratory = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var BudgetPerformanceDevelopment = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var BudgetPerformanceProductionCost = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var BudgetPerformanceFacilityDevProjects = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var BudgetProposalComponents = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var BudgetCapexOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                                return new
                                {
                                    BudgetActualExpenditure = BudgetActualExpenditure,
                                    BudgetPerformanceExploratory = BudgetPerformanceExploratory,
                                    BudgetPerformanceDevelopment = BudgetPerformanceDevelopment,
                                    BudgetPerformanceProductionCost = BudgetPerformanceProductionCost,
                                    BudgetPerformanceFacilityDevProjects = BudgetPerformanceFacilityDevProjects,
                                    BudgetProposalComponents = BudgetProposalComponents,
                                    BudgetCapexOpex = BudgetCapexOpex
                                };
                         
                        case "LGL":
                           
                                var LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                return new
                                {
                                    LegalLitigation = LegalLitigation,
                                    LegalArbitration = LegalArbitration
                                };
                           
                        case "HSE":
                          
                                var HSEQuestion = await (from c in _context.HSE_QUESTIONs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEFatality = await (from c in _context.HSE_FATALITIEs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEDesignSafety = await (from c in _context.HSE_DESIGNS_SAFETies where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEInspectionMaintenance = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEInspectionMaintenanceFacility = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSESafetyStudies = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                                var HSEAssetRegister = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEOilSpill = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEAssetRegisterRBI = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                                var HSEAccidentIncidence = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEAccidentIncidenceType = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var accidentModel = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                                           join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                                           where a1.COMPANY_ID == WKPCompanyId && a1.Year_of_WP == year
                                                           && a2.COMPANY_ID == WKPCompanyId && a2.Year_of_WP == year
                                                           select new HSE_ACCIDENT_INCIDENCE_MODEL
                                                           {
                                                               Was_there_any_accident_incidence = a1.Was_there_any_accident_incidence,
                                                               If_YES_were_they_reported = a1.If_YES_were_they_reported,
                                                               Cause = a2.Cause,
                                                               Type_of_Accident_Incidence = a2.Type_of_Accident_Incidence,
                                                               Consequence = a2.Consequence,
                                                               Frequency = a2.Frequency,
                                                               Investigation = a2.Investigation,
                                                               Lesson_Learnt = a2.Lesson_Learnt,
                                                               Location = a2.Location,
                                                               Date_ = a2.Date_
                                                           }).FirstOrDefaultAsync();

                                var HSECommunityDisturbance = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEEnvironmentalStudies = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEWasteManagementType = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEProducedWaterMgt = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEEnvironmentalCompliance = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();


                                var HSEEnvironmentalFiveYears = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSESustainableDev = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEEnvironmentalStudiesUpdated = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEOSPRegistrations = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEProducedWaterMgtUpdated = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEEnvironmentalComplianceChemical = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSECausesOfSpill = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSESustainableDevMOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                                var HSESustainableDevProgramCsr = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                                var HSESustainableDevScheme = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEManagementPosition = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEQualityControl = await (from c in _context.HSE_QUALITY_CONTROLs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEClimateChange = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEWasteManagementSystems = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                                var HSEEnvironmentalManagementSystems = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                                return new
                                {
                                    HSETechnicalSafety = HSETechnicalSafety,
                                    HSESafetyStudies = HSESafetyStudies,
                                    HSEQualityControl = HSEQualityControl,
                                    HSEInspectionMaintenance = HSEInspectionMaintenance,
                                    HSEAssetRegister = HSEAssetRegister,
                                    HSEOilSpill = HSEOilSpill,
                                    HSECausesOfSpill = HSECausesOfSpill,
                                    HSEAssetRegisterRBI = HSEAssetRegisterRBI,
                                    HSEAccidentModel = accidentModel,
                                    HSEAccidentIncidence = HSEAccidentIncidence,
                                    HSEOSPRegistrations = HSEOSPRegistrations,
                                    HSEAccidentIncidenceType = HSEAccidentIncidenceType,
                                    HSECommunityDisturbance = HSECommunityDisturbance,
                                    HSESustainableDevProjProgramCsr = HSESustainableDevProgramCsr,

                                    HSEQuestion = HSEQuestion,
                                    HSEFatality = HSEFatality,
                                    HSEDesignSafety = HSEDesignSafety,
                                    HSEInspectionMaintenanceFacility = HSEInspectionMaintenanceFacility,
                                    HSEEnvironmentalStudies = HSEEnvironmentalStudies,
                                    HSEWasteManagement = HSEWasteManagement,
                                    HSEWasteManagementType = HSEWasteManagementType,
                                    HSEProducedWaterMgt = HSEProducedWaterMgt,
                                    HSEEnvironmentalCompliance = HSEEnvironmentalCompliance,
                                    HSEEnvironmentalFiveYears = HSEEnvironmentalFiveYears,
                                    HSEEnvironmentalStudiesUpdated = HSEEnvironmentalStudiesUpdated,
                                    HSEProducedWaterMgtUpdated = HSEProducedWaterMgtUpdated,
                                    HSEEnvironmentalComplianceChemical = HSEEnvironmentalComplianceChemical,
                                    HSEManagementPosition = HSEManagementPosition,
                                    HSEClimateChange = HSEClimateChange,
                                    HSESafetyCulture = HSESafetyCulture,
                                    HSEOccupationalHealth = HSEOccupationalHealth,
                                    HSEWasteManagementSystems = HSEWasteManagementSystems,
                                    HSEEnvironmentalManagementSystems = HSEEnvironmentalManagementSystems,
                                };                           
                            break;

                        default:
                            return BadRequest(new { message = "Error : User SBU was not specified." });

                    }
                 }
                else
                {
                    return BadRequest(new { message = "Error : Application ID was not passed correctly." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });

            }
        }


        [HttpGet("GetSBU_Report_Old")]
        public async Task<object> GetSBU_Report_Old(int appID )
        {
            var mycon = _configuration["Data:Wkpconnect:ConnectionString"];
            SqlConnection con = new SqlConnection(mycon);
            List<object> Records = new List<object>();

            try
            {
                var application = (from ap in _context.Applications where ap.Id == appID select ap).FirstOrDefault();

                if (application != null)
                {
                    object report = new object();
                  
                    con.Open();

                    if (application.FieldID != null)
                    {
                        var getStaffSBU =  (from stf in _context.staff
                                                 join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                                 join record in _context.SBU_Records on stf.Staff_SBU equals record.SBU_Id
                                                 where stf.StaffEmail == WKPCompanyEmail
                                                 select record).ToList();
                        //var context = new WKP_DBContext();
                        if (getStaffSBU.Count() > 0)
                        {
                            foreach (var record in getStaffSBU) {

                                string sql = $"Select * from {record.Records} where Field_ID = {application.FieldID}";
                                using (var command = _context.Database.GetDbConnection().CreateCommand())
                                {
                                    command.CommandText = sql;
                                    _context.Database.OpenConnection();
                                    using (var result = command.ExecuteReader())
                                    {
                                        DataTable schemaTable = result.GetSchemaTable();

                                        foreach (DataRow row in schemaTable.Rows)
                                        {
                                            foreach (DataColumn column in schemaTable.Columns)
                                            {
                                                Records.Add(String.Format("{0} = {1}",
                                                   row[column].ToString(), row[column].ToString()));
                                            }
                                        }
                                    }
                                }


                            }
                        }
                    }
                    else
                    {
                        SqlCommand ConcessionReport = new SqlCommand("SELECT * FROM [dbo].[BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES] WHERE Field_ID = " + application.ConcessionID);
                        ConcessionReport.CommandType = CommandType.Text;
                        ConcessionReport.Connection = con;
                        SqlDataReader rd = ConcessionReport.ExecuteReader();
                        report = rd.Read() ? rd : report;
                    }

                    return ( report );
                    
                }
                return BadRequest(new { message = "Error : Application ID was not passed correctly." });
            }
            catch (Exception e)
            {
                con.Close();
                return BadRequest(new { message = "Error : " + e.Message });
            }
            finally
            {
                //con.Close();
            }
        }
       
       
        #endregion

    }
}
