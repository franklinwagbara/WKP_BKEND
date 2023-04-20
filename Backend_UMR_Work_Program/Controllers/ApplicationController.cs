using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Models.Enurations;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
//using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Syncfusion.XlsIO.Implementation;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
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
        //private int? WKPCompanyNumber => 21;
        //private string? WKPCompanyId => "221";
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
					//deskCount = await _context.MyDesks.Where(x => x.StaffID == getStaff.StaffID && x.HasWork != true).CountAsync();
					deskCount = await _context.MyDesks.Where(x => x.StaffID == getStaff.StaffID && x.HasWork == true).CountAsync();
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
				return BadRequest(new { message = "Error : " + e.Message });
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
                                          where admin.Id == WKPCompanyNumber && dsk.HasWork == true
                                          select new Application_Model
                                          {
                                              Id = app.Id,
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
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        [HttpGet("GetStaffDesksBySBUAndRole")]
        public async Task<object> GetAppsOnMyDeskBySBUAndRole(int sbuID, int roleID)
        {
            try
            {
                //var staffs = _context.staff.Where<staff>(s => s.Staff_SBU == sbuID && s.RoleID == roleID).ToList();
                var staffDesks = await (from desk in _context.MyDesks
                                        join staff in _context.staff on desk.StaffID equals staff.StaffID
                                        join app in _context.Applications on desk.AppId equals app.Id
                                        where staff.Staff_SBU == sbuID && staff.RoleID == roleID && desk.HasWork == true
                                        select new DeskStaffAppsModel
                                        {
                                            Staff = staff,
                                            Desk = desk,
                                            Application = app
                                        }).ToListAsync();

                return new WebApiResponse { Data = staffDesks, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        [HttpGet("GetStaffDesksByStaffID")]
        public async Task<object> GetAppsOnMyDeskByStaffID(int staffID)
        {
            try
            {
                //var staffs = _context.staff.Where<staff>(s => s.Staff_SBU == sbuID && s.RoleID == roleID).ToList();
                var staffDesks = await (from desk in _context.MyDesks
                                        join staff in _context.staff on desk.StaffID equals staff.StaffID
                                        join app in _context.Applications on desk.AppId equals app.Id
                                        where staff.StaffID == staffID && desk.HasWork == true
                                        select new DeskStaffAppsModel
                                        {
                                            Staff = staff,
                                            Desk = desk,
                                            Application = app
                                        }).ToListAsync();

                return new WebApiResponse { Data = staffDesks, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                                              Id = app.Id,
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
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                                          where app.DeleteStatus != true && cmt.ActionStatus == GeneralModel.Rejected
                                          && app.CompanyID == WKPCompanyNumber
                                          select new Application_Model
                                          {
                                              Last_SBU = sbu.SBU_Name,
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              RejectId = cmt.Id,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                              FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              SBU_Comment = cmt.SBU_Comment,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              Status = app.Status,
                                              SBU_Tables = cmt.SBU_Tables,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpGet("CompanyRejectedApplication")] //For specific application view
        public async Task<object> CompanyRejectedApplication(string omlName, string fieldName, string year)
        {
            try
            {
                var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.ConcessionName == omlName select d).FirstOrDefaultAsync();
                var application = await (from d in _context.Applications where d.ConcessionID == concession.Consession_Id && d.YearOfWKP == int.Parse(year) && d.CompanyID == WKPCompanyNumber select d).ToListAsync();

                if (fieldName != null)
                {
                    var field = _context.COMPANY_FIELDs.Where(p => p.Field_Name == fieldName).FirstOrDefault();
                    application = application.Where(ap => ap.FieldID == field.Field_ID).ToList();
                }

                var applications = (from app in application
                                    join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                    join cmt in _context.SBU_ApplicationComments on app.Id equals cmt.AppID
                                    join sbu in _context.StrategicBusinessUnits on cmt.SBU_ID equals sbu.Id
                                    where app.DeleteStatus != true && cmt.ActionStatus == GeneralModel.Initiated
                                    select new Application_Model
                                    {
                                        Last_SBU = sbu.SBU_Name,
                                        Id = app.Id,
                                        FieldID = app.FieldID,
                                        RejectId = cmt.Id,
                                        ConcessionID = app.ConcessionID,
                                        ConcessionName = omlName,
                                        FieldName = fieldName,
                                        SBU_Comment = cmt.SBU_Comment,
                                        ReferenceNo = app.ReferenceNo,
                                        CreatedAt = app.CreatedAt,
                                        SubmittedAt = app.SubmittedAt,
                                        Status = app.Status,
                                        YearOfWKP = app.YearOfWKP
                                    }).ToList();
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        //[HttpPost("Resubmit_RejectedApplication")] //For general application view
        //public async Task<object> Resubmit_RejectedApplication(int appID, int rejectID)
        //{
        //	try
        //	{
        //		var NRejectApp = _context.SBU_ApplicationComments.Where(x => x.AppID == appID && x.Id == rejectID).FirstOrDefault();
        //		if (NRejectApp != null)
        //		{
        //			NRejectApp.ActionStatus = GeneralModel.Completed;
        //			if (await _context.SaveChangesAsync() > 0)
        //			{
        //				var application = await (from app in _context.Applications
        //										 join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
        //										 join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
        //										 select new { app, comp, con }).FirstOrDefaultAsync();


        //				var getStaff = (from stf in _context.staff where stf.StaffID == NRejectApp.Staff_ID select stf).FirstOrDefault();

        //				var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();
        //				string subject = $"Company response to rejected WORK PROGRAM application with ref: {application.app.ReferenceNo} ({application.con.Concession_Held} - {application.app.YearOfWKP}).";
        //				string content = $"{application.comp.COMPANY_NAME} has responded to rejected WORK PROGRAM application for year {application.app.YearOfWKP}";
        //				var emailMsg = _helpersController.SaveMessage(application.app.Id, getStaff.StaffID, subject, content, "Staff");
        //				var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

        //				return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Application feedback has been sent successfully.", StatusCode = ResponseCodes.Success };

        //			}
        //		}
        //		return BadRequest(new { message = "Error : Rejected/Commented application could not be found." });

        //	}
        //	catch (Exception e)
        //	{
        //		return BadRequest(new { message = "Error : " + e.Message });
        //	}
        //}

        //[HttpGet("RejectedApplications")] //For general application view
        //public async Task<object> RejectedApplications()
        //{
        //	try
        //	{
        //		var applications = await (from app in _context.Applications
        //								  join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
        //								  join dsk in _context.MyDesks on app.Id equals dsk.AppId into desks
        //								  join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
        //								  join SBU in _context.StrategicBusinessUnits on desks.OrderByDescending(x => x.DeskID).FirstOrDefault().FromSBU equals SBU.Id.ToString()
        //								  where app.DeleteStatus != true && app.Status == GeneralModel.Rejected
        //								  select new Application_Model
        //								  {
        //									  Last_SBU = SBU.SBU_Name,
        //									  Id= app.Id,
        //									  FieldID = app.FieldID,
        //									  ConcessionID = app.ConcessionID,
        //									  ConcessionName = con.ConcessionName,
        //									  FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
        //									  ReferenceNo = app.ReferenceNo,
        //									  CreatedAt = app.CreatedAt,
        //									  SubmittedAt = app.SubmittedAt,
        //									  CompanyName = comp.COMPANY_NAME,
        //									  Status = app.Status,
        //									  PaymentStatus = app.PaymentStatus,
        //									  YearOfWKP = app.YearOfWKP
        //								  }).ToListAsync();

        //		return new WebApiResponse { Data= applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
        //	}
        //	catch (Exception e)
        //	{
        //		return BadRequest(new { message = "Error : " + e.Message });
        //	}
        //}

        //[HttpPost("ApproveRejection")]
        //public async Task<object> ApproveRejection(int SBU_ID, string comment, string[] selectedApps )
        //{
        //    try
        //    {
        //        if (selectedApps != null)
        //        {
        //            foreach (var b in selectedApps)
        //            {
        //                string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
        //                int appId = int.Parse(appID);
        //                //get current staff desk
        //                var dsk = await _context.MyDesks.Where(x => x.AppId == appId).OrderByDescending(x => x.DeskID).FirstOrDefaultAsync();
        //                var get_CurrentStaff = (from stf in _context.staff
        //                                        join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
        //                                        where stf.StaffID == dsk.StaffID && stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
        //                                        select stf).FirstOrDefault();
        //                var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();
        //                var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
        //                var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

        //                if (application.FieldID != null)
        //                {
        //                    var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
        //                }
        //                _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection Approval", "Planning approves SBU rejection to company.");

        //                //send mail to staff that initiates rejection
        //                string subject = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
        //                string content = $"Planning approves WORK PROGRAM application rejection to company for year {application.YearOfWKP}.";
        //                var emailMsg = _helpersController.SaveMessage(application.Id, get_CurrentStaff.StaffID, subject, content, "Staff");
        //                var sendEmail = _helpersController.SendEmailMessage(get_CurrentStaff.StaffEmail, get_CurrentStaff.FirstName, emailMsg, null);
        //                //send mail to company
        //                string subject2 = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
        //                    string content2 = $"Rejected WORK PROGRAM application for year {application.YearOfWKP} with comment{dsk.Comment}.";
        //                    var emailMsg2 = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
        //                    var sendEmail2 = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

        //                    _helpersController.LogMessages("Rejection of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
        //                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been pushed successfully.", StatusCode = ResponseCodes.Success };

        //                }
        //            }
        //        else
        //        {
        //            return BadRequest(new { message = "Error: No application ID was passed for this action to be completed." });
        //        }

        //        return BadRequest(new { message = "Error: No application ID was passed for this action to be completed." });
        //    }
        //    catch (Exception x)
        //    {
        //        _helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
        //        return BadRequest(new { message = $"An error occured while rejecting application." + x.Message.ToString() });
        //    }

        //}

        [HttpGet("ViewApplication")] //For specific application view
        public async Task<object> ViewApplication(int appID)
        {
            try
            {
                var application = (from ap in _context.Applications where ap.Id == appID && ap.DeleteStatus != true select ap).FirstOrDefault();

                if (application == null)
                {
                    return BadRequest(new { message = "Sorry, this application details could not be found." });
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
                                 where dsk.HasWork != true && stf.ActiveStatus != false && stf.DeleteStatus != true
                                 select new Staff_Model
                                 {
                                     Desk_ID = dsk.DeskID,
                                     Sort = (int)dsk.Sort,
                                     Staff_Name = stf.FirstName + " " + stf.LastName,
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
                return new WebApiResponse { Data = appDetails, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                    return BadRequest(new { message = "Sorry, this application details could not be found." });
                }

                var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == application.FieldID).FirstOrDefaultAsync();

                var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == application.ConcessionID).FirstOrDefaultAsync();

                var company = await _context.ADMIN_COMPANY_INFORMATIONs.Where(x => x.Id == application.CompanyID).FirstOrDefaultAsync();



                var appHistory = await (from his in _context.ApplicationDeskHistories
                                        join stf in _context.staff on his.StaffID equals stf.StaffID
                                        join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                        join rol in _context.Roles on stf.RoleID equals rol.id
                                        join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                        where his.AppId == appID
                                        select new ApplicationDeskHistory_Model
                                        {
                                            ID = his.Id,
                                            Staff_Name = stf.FirstName + " " + stf.LastName,
                                            Staff_Email = stf.StaffEmail,
                                            Staff_SBU = sbu.SBU_Name,
                                            Staff_Role = rol.RoleName,
                                            Comment = his.Comment,
                                            Date = his.ActionDate
                                        }).ToListAsync();

                var staffDesk = await (from dsk in _context.MyDesks
                                       join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                       join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                       join rol in _context.Roles on stf.RoleID equals rol.id
                                       join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                       //where admin.Id == WKPCompanyNumber && dsk.AppId == appID && dsk.HasWork != true && stf.ActiveStatus != false && stf.DeleteStatus != true
                                       where admin.Id == WKPCompanyNumber && dsk.AppId == appID && stf.ActiveStatus != false && stf.DeleteStatus != true
                                       select new Staff_Model
                                       {
                                           Desk_ID = dsk.DeskID,
                                           Staff_Email = stf.StaffEmail,
                                           Staff_SBU = sbu.SBU_Name,
                                           Staff_Role = rol.RoleName,
                                           //Sort = (int)dsk.Sort
                                       }).ToListAsync();



                var documents = await _context.SubmittedDocuments.Where(x => x.CreatedBy == application.CompanyID.ToString() && x.YearOfWKP == application.YearOfWKP).Take(10).ToListAsync();

                var getStaffSBU = (from stf in _context.staff
                                   join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                   where stf.StaffEmail == WKPCompanyEmail
                                   select sbu).FirstOrDefault();

                var getSBU_TablesToDisplay = await _context.Table_Details.Where(x => x.SBU_ID.Contains(getStaffSBU.Id.ToString())).ToListAsync();


                var appDetails = new ApplicationDetailsModel
                {
                    Application = application,
                    Field = field,
                    Concession = concession,
                    Company = company,
                    Staff = staffDesk,
                    Application_History = appHistory.OrderByDescending(x => x.ID).ToList(),
                    Document = documents,
                    SBU_TableDetails = getSBU_TablesToDisplay,
                    SBU = await _context.StrategicBusinessUnits.ToListAsync()
                };
                return new WebApiResponse { Data = appDetails, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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

                var applicationProcesses = await _helpersController.GetApplicationProccessByAction(GeneralModel.Submit);


                if (applicationProcesses.Count <= 0)
                {

                    return BadRequest(new { message = "An error occured while trying to get process flow for this application." });
                }

                var app = new Application();


                if (field != null)
                {
                    app = await _context.Applications.Where<Application>(a => a.YearOfWKP == yearID && a.ConcessionID == concession.Consession_Id && a.FieldID == field.Field_ID).FirstOrDefaultAsync();
                }
                else
                {
                    app = await _context.Applications.Where<Application>(a => a.YearOfWKP == yearID && a.ConcessionID == concession.Consession_Id).FirstOrDefaultAsync();

                }

                if (app != null)
                {

                    return BadRequest(new { message = $"Error : An application for the Concession {omlName}, and Field Name {field.Field_Name} for the year {year} has already been submitted." });
                }

                Application application = new Application();
                application.ReferenceNo = _helpersController.Generate_Reference_Number();

                application.YearOfWKP = yearID;

                application.ConcessionID = concession.Consession_Id;
                application.FieldID = field?.Field_ID ?? null;
                application.CompanyID = (int)WKPCompanyNumber;
                application.CurrentUserEmail = WKPCompanyEmail;

                application.CategoryID = _context.ApplicationCategories.Where(x => x.Name == GeneralModel.New).FirstOrDefault().Id;
                application.Status = GeneralModel.Processing;
                application.PaymentStatus = GeneralModel.PaymentPending;

                application.CurrentDesk = applicationProcesses.FirstOrDefault().RoleID; //to change

                application.Submitted = true;
                application.CreatedAt = DateTime.Now;
                application.SubmittedAt = DateTime.Now;

                _context.Applications.Add(application);

                if (_context.SaveChanges() > 0)
                {

                    //Disribute to Reviewers
                    string subject2 = $"{year} submission of WORK PROGRAM application for {WKPCompanyName} field - {field?.Field_Name} : {application.ReferenceNo}";
                    var staffLists = new List<staff>();
                    //var reviewerStaff = new List<staff>();


                    var staffList = await _helpersController.GetReviewerStafff(applicationProcesses);

                    //foreach (var item in applicationProcesses)
                    //{
                    //	staffLists=_context.staff.Where(x => x.Staff_SBU==item.TargetedToSBU && x.RoleID==item.TargetedToRole).ToList();
                    //}
                    foreach (var staff in staffList)
                    {
                        //Get The process Flow
                        var processFlow = _context.ApplicationProccesses.Where<ApplicationProccess>(p => p.TargetedToRole == staff.RoleID && p.TargetedToSBU == staff.Staff_SBU).FirstOrDefault();

                        int FromStaffID = 0; //This value is zero, because, this is company and not a staff
                        int FromStaffSBU = 0; // This value is zero, because, this is company and not a staff
                        int FromStaffRoleID = 0; //This value is zero, because, this is company and not a staff

                        int saveStaffDesk = _helpersController.RecordStaffDesks(application.Id, staff, FromStaffID, FromStaffSBU, FromStaffRoleID, processFlow.ProccessID);

                        if (saveStaffDesk > 0)
                        {
                            _helpersController.SaveHistory(application.Id, staff.StaffID, "Submitted", "Application submitted and landed on staff desk");

                            //send mail to staff
                            //var getStaff = (from stf in _context.staff where stf.StaffID == staff.StaffId select stf).FirstOrDefault();
                            var getStaff = (from stf in _context.staff
                                            join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                            where stf.StaffID == staff.StaffID && stf.DeleteStatus != true
                                            select stf).FirstOrDefault();



                            string content2 = $"{WKPCompanyName} have submitted their WORK PROGRAM application for year {year}.";

                            var emailMsg2 = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject2, content2, "Staff");



                            var sendEmail2 = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg2, null);


                            _helpersController.LogMessages("Submission of application with REF : " + application.ReferenceNo, WKPCompanyEmail);

                        }
                        else
                        {
                            return BadRequest(new { message = "An error occured while trying to submit this application to a staff." });
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
                    return BadRequest(new { message = "An error occured while trying to save this application record." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Error : " + e.Message
                });
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

                        //if (application.FieldID != null)
                        //{
                        //	var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
                        //}


                        var getStaffById = await _helpersController.GetStaffByStaffId(staffDesk.StaffID);

                        var staffId = getStaffById?.StaffID;
                        var staffRoleId = getStaffById?.RoleID;
                        var staffSBUId = getStaffById?.Staff_SBU;
                        var getApplicationProcess = await _helpersController.GetApplicationProccessBySBUAndRole(GeneralModel.Push, (int)staffRoleId, (int)staffSBUId);

                        if (getApplicationProcess.Count > 0)
                        {
                            foreach (var processFlow in getApplicationProcess)
                            {
                                var getStaffByTargetedRoleAndSBUs = await _helpersController.GetStaffByTargetRoleAndSBU((int)processFlow.TargetedToRole, (int)processFlow.TargetedToSBU);

                                var deskTemp = await _helpersController.GetStaffMyDesks(getStaffByTargetedRoleAndSBUs, appId);

                                if (deskTemp != null)
                                {
                                    deskTemp.FromRoleId = processFlow.TriggeredByRole;
                                    deskTemp.FromSBU = (int)processFlow.TriggeredBySBU;
                                    deskTemp.FromStaffID = get_CurrentStaff.StaffID;
                                    deskTemp.ProcessID = processFlow.ProccessID;
                                    deskTemp.AppId = appId;
                                    deskTemp.HasPushed = false;
                                    deskTemp.HasWork = true;
                                    deskTemp.CreatedAt = DateTime.Now;
                                    deskTemp.UpdatedAt = DateTime.Now;
                                    deskTemp.Comment = comment;
                                    deskTemp.LastJobDate = DateTime.Now;
                                    deskTemp.ProcessStatus = STAFF_DESK_STATUS.APPROVED;

                                    _context.Update(deskTemp);
                                }
                                else
                                {
                                    var desk = new MyDesk
                                    {
                                        //save staff desk
                                        StaffID = deskTemp.StaffID,
                                        FromRoleId = processFlow.TriggeredByRole,
                                        FromSBU = (int)processFlow.TriggeredBySBU,
                                        FromStaffID = get_CurrentStaff.StaffID,
                                        ProcessID = processFlow.ProccessID,
                                        AppId = appId,
                                        HasPushed = false,
                                        HasWork = true,
                                        CreatedAt = DateTime.Now,
                                        UpdatedAt = DateTime.Now,
                                        Comment = comment,
                                        LastJobDate = DateTime.Now,
                                        ProcessStatus = STAFF_DESK_STATUS.APPROVED,

                                    };

                                    _context.MyDesks.Add(desk);
                                }

                                var save = await _context.SaveChangesAsync();
                                if (save > 0)
                                {
                                    //var trigeredbyDeskId = await _helpersController.GetDeskIdByStaffIdAndAppId((int)staffId, appId);
                                    //var result = await _helpersController.DeleteDeskIdByDeskId(trigeredbyDeskId);

                                    //update records of approval status coming in from each SBU for workprogram team consumption
                                    if (processFlow.ProcessAction == GeneralModel.Approve) ;


                                    await _helpersController.UpdateDeskAfterPush(staffDesk, comment, STAFF_DESK_STATUS.APPROVED);
                                }

                                _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Approval", comment);


                                //send mail to staff
                                var getStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                where stf.StaffID == deskTemp.StaffID && stf.DeleteStatus != true
                                                select stf).FirstOrDefault();

                                string subject = $"Push for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"{WKPCompanyName} have submitted their WORK PROGRAM application for year {application.YearOfWKP}.";
                                var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");
                                var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                                _helpersController.LogMessages("Submission of application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been pushed successfully.", StatusCode = ResponseCodes.Success };
                            }
                        }
                        else
                        {
                            return BadRequest(new { message = "An error occured while trying to get process flow for this application." });
                        }
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
                return BadRequest(new { message = $"An error occured while pushing application to staff." + x.Message.ToString() });
            }

        }

        [HttpPost("MoveApplication")]
        public async Task<object> MoveApplication(int sourceStaffID, int targetStaffID, string[] selectedApps)
        {
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);

                        var sourceStaff = await _context.staff.Where<staff>(s => s.StaffID == sourceStaffID && s.DeleteStatus != true).FirstOrDefaultAsync();
                        var targetStaff = await _context.staff.Where<staff>(s => s.StaffID == targetStaffID && s.DeleteStatus != true).FirstOrDefaultAsync();

                        var sourceStaffDesk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == sourceStaff.StaffID && d.AppId == appId).FirstOrDefaultAsync();
                        var targetStaffDesk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == targetStaff.StaffID && d.AppId == appId).FirstOrDefaultAsync();

                        var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();

                        var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();

                        var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        if (sourceStaff == null || targetStaff == null || appID == null)
                        {
                            return BadRequest(new { message = "An error occured while trying to get process flow for this application. Make sure that source and target staffIDs are valid including appId" });
                        }

                        if (sourceStaff.Staff_SBU != targetStaff.Staff_SBU)
                        {
                            return BadRequest(new { message = "An error occured while trying to get process flow for this application. Source Staff's SBU and Role must match the Target Staff's." });
                        }


                        //retrieve source desk using staffID and appId
                        var sourceDesk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == sourceStaffID && d.AppId == appId).FirstOrDefaultAsync();
                        var targetDesk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == targetStaffID && d.AppId == appId).FirstOrDefaultAsync();

                        if (sourceDesk == null)
                        {
                            return BadRequest(new { message = "An error occured while trying to get process flow for this application. Application was not found on source staff's desk." });
                        }

                        if (targetDesk == null)
                        {
                            var desk = new MyDesk
                            {
                                //save staff desk
                                StaffID = targetStaffID,
                                FromRoleId = sourceDesk.FromRoleId,
                                FromSBU = sourceDesk.FromSBU,
                                FromStaffID = sourceDesk.FromStaffID,
                                //ProcessID = processFlow.ProccessID,
                                AppId = appId,
                                HasPushed = false,
                                HasWork = true,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Comment = sourceDesk.Comment,
                                LastJobDate = DateTime.Now,
                                ProcessStatus = sourceDesk.ProcessStatus,
                            };

                            await _context.MyDesks.AddAsync(desk);
                        }
                        else
                        {
                            targetDesk.StaffID = targetStaffID;
                            targetDesk.FromRoleId = sourceDesk.FromRoleId;
                            targetDesk.FromSBU = sourceDesk.FromSBU;
                            targetDesk.FromStaffID = sourceDesk.FromStaffID;
                            targetDesk.AppId = appId;
                            targetDesk.HasWork = true;
                            targetDesk.UpdatedAt = DateTime.Now;
                            targetDesk.Comment = sourceDesk.Comment;
                            targetDesk.ProcessStatus = sourceDesk.ProcessStatus;
                            targetDesk.LastJobDate = DateTime.Now;

                            _context.MyDesks.Update(targetDesk);
                        }


                        var save = await _context.SaveChangesAsync();
                        if (save > 0)
                        {
                            var result = await _helpersController.DeleteDeskIdByDeskId(sourceDesk.DeskID);
                            //await _helpersController.UpdateDeskAfterMove(sourceDesk, sourceDesk.Comment, STAFF_DESK_STATUS.MOVED);

                        }

                        _helpersController.SaveHistory(application.Id, sourceStaffID, sourceDesk.ProcessStatus, sourceDesk.Comment);


                        string subject = $"Re-assignment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

                        //Send mail to target Staff
                        string content = "Application with REF : " + application.ReferenceNo + " was moved from " + sourceStaff.LastName + ", " + sourceStaff.FirstName + "'s desk to " + targetStaff.LastName + ", " + targetStaff.FirstName;
                        var emailMsg = _helpersController.SaveMessage(application.Id, targetStaffID, subject, content, "Staff");
                        var sendEmail = _helpersController.SendEmailMessage(targetStaff.StaffEmail, targetStaff.LastName + ", " + targetStaff.FirstName, emailMsg, null);

                        //Send mail to source staff
                        var emailMsg_Source = _helpersController.SaveMessage(application.Id, sourceStaffID, subject, content, "Staff");
                        var sendEmail_Source = _helpersController.SendEmailMessage(sourceStaff.StaffEmail, sourceStaff.LastName + ", " + sourceStaff.FirstName, emailMsg_Source, null);

                        _helpersController.LogMessages("Application with REF : " + application.ReferenceNo + " was moved from " + sourceStaff.LastName + ", " + sourceStaff.FirstName + "'s desk to " + targetStaff.LastName + ", " + targetStaff.FirstName);
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been moved successfully.", StatusCode = ResponseCodes.Success };
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
                return BadRequest(new { message = $"An error occured while pushing application to staff." + x.Message.ToString() });
            }

        }

        //[HttpPost("RejectApplication")]
        //public async Task<object> RejectApplication(/*[FromBody] ActionModel model,*/ int deskID, string comment, string[] selectedApps, string[] SBU_IDs, string[] selectedTables)
        //{
        //	try
        //	{
        //		if (selectedApps != null)
        //		{
        //			foreach (var b in selectedApps)
        //			{
        //				int appId = b != "undefined" ? int.Parse(b) : 0;
        //				//get current staff desk

        //				var get_CurrentStaff = (from stf in _context.staff
        //										join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
        //										where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
        //										select stf).FirstOrDefault();

        //				var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();

        //				var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();

        //				var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();

        //				var concession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

        //				if (application.FieldID != null)
        //				{
        //					var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
        //				}


        //				//Determine if the app is in the reviewer's desk
        //				var appStatus = application.Status;
        //				if (appStatus ==GeneralModel.Submit)
        //				{
        //					var getStaff = (from stf in _context.staff where stf.StaffID == staffDesk.StaffID select stf).FirstOrDefault();

        //					var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == appId && x.SBU_ID == getStaff.Staff_SBU && x.ActionStatus == GeneralModel.Initiated).FirstOrDefaultAsync();

        //					if (NRejectApp == null)
        //					{
        //						List<string> RejectedForms = new List<string>();
        //						string RejectedTables = "";
        //						if (selectedTables.Count() > 0)
        //						{
        //							foreach (var table in selectedTables)
        //							{
        //								int tableID = table != "undefined" ? int.Parse(table) : 0;
        //								var getSBU_TablesToDisplay = await _context.Table_Details.Where(x => x.TableId == tableID).FirstOrDefaultAsync();

        //								if (getSBU_TablesToDisplay != null)
        //									RejectedTables = RejectedTables != "" ? $"{RejectedTables}|{getSBU_TablesToDisplay.TableName}" : getSBU_TablesToDisplay.TableName;

        //							}
        //						}


        //						var nReject = new SBU_ApplicationComment()
        //						{
        //							SBU_Comment = comment,
        //							SBU_ID = getStaff.Staff_SBU,
        //							Staff_ID = getStaff.StaffID,
        //							ActionStatus = GeneralModel.Initiated,
        //							SBU_Tables = RejectedTables,
        //							AppID = appId,
        //							DateCreated = DateTime.Now,

        //						};
        //						await _context.SBU_ApplicationComments.AddAsync(nReject);

        //						if (await _context.SaveChangesAsync() > 0)
        //						{
        //							var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();

        //							string subject = $"Comment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

        //							string content = $"{SBU?.SBU_Name} made comment on your WORK PROGRAM application for year {application.YearOfWKP}. See comment :- " + comment;
        //							var emailMsg = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
        //							var sendEmail = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

        //							return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Rejection for application {concession.Concession_Held} has been sent to the company.", StatusCode = ResponseCodes.Success };

        //						}
        //					}
        //				}


        //				//if (staffDesk.Sort == 1) //Rejection to company
        //				//{
        //				//	var getStaff = (from stf in _context.staff where stf.StaffID == staffDesk.StaffID select stf).FirstOrDefault();

        //				//	var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == appId && x.SBU_ID == getStaff.Staff_SBU && x.ActionStatus == GeneralModel.Initiated).FirstOrDefaultAsync();

        //				//	if (NRejectApp == null)
        //				//	{
        //				//		List<string> RejectedForms = new List<string>();
        //				//		string RejectedTables = "";
        //				//		if (selectedTables.Count() > 0)
        //				//		{
        //				//			foreach (var table in selectedTables)
        //				//			{
        //				//				int tableID = table != "undefined" ? int.Parse(table) : 0;
        //				//				var getSBU_TablesToDisplay = await _context.Table_Details.Where(x => x.TableId == tableID).FirstOrDefaultAsync();

        //				//				if (getSBU_TablesToDisplay != null)
        //				//					RejectedTables = RejectedTables != "" ? $"{RejectedTables}|{getSBU_TablesToDisplay.TableName}" : getSBU_TablesToDisplay.TableName;

        //				//			}
        //				//		}


        //				//		var nReject = new SBU_ApplicationComment()
        //				//		{
        //				//			SBU_Comment = comment,
        //				//			SBU_ID = getStaff.Staff_SBU,
        //				//			Staff_ID = getStaff.StaffID,
        //				//			ActionStatus = GeneralModel.Initiated,
        //				//			SBU_Tables = RejectedTables,
        //				//			AppID = appId,
        //				//			DateCreated = DateTime.Now,

        //				//		};
        //				//		await _context.SBU_ApplicationComments.AddAsync(nReject);

        //				//		if (await _context.SaveChangesAsync() > 0)
        //				//		{
        //				//			var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();

        //				//			string subject = $"Comment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

        //				//			string content = $"{SBU?.SBU_Name} made comment on your WORK PROGRAM application for year {application.YearOfWKP}. See comment :- " + comment;
        //				//			var emailMsg = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
        //				//			var sendEmail = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

        //				//			return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Rejection for application {concession.Concession_Held} has been sent to the company.", StatusCode = ResponseCodes.Success };

        //				//		}
        //				//	}
        //				//}
        //				else
        //				{
        //					var prevDesk = (from dsk in _context.MyDesks
        //									join stf in _context.staff on dsk.StaffID equals stf.StaffID
        //									where stf.Staff_SBU == get_CurrentStaff.Staff_SBU && dsk.Sort == staffDesk.Sort - 1 && stf.DeleteStatus != true
        //									select dsk).FirstOrDefault();

        //					if (SBU_IDs.Count() > 0)
        //					{
        //						foreach (var SBU in SBU_IDs)
        //						{
        //							int SBU_ID = SBU != "undefined" ? int.Parse(SBU) : 0;
        //							if (SBU_ID > 0) //planning rejecting back to a particular SBU
        //							{
        //								prevDesk = (from dsk in _context.MyDesks
        //											join stf in _context.staff on dsk.StaffID equals stf.StaffID
        //											where stf.Staff_SBU == SBU_ID && dsk.Sort == staffDesk.Sort - 1 && stf.DeleteStatus != true
        //											select dsk).FirstOrDefault();
        //							}
        //							if (prevDesk != null)
        //							{
        //								//update staff desk
        //								staffDesk.HasPushed = true;
        //								staffDesk.HasWork = true;
        //								staffDesk.UpdatedAt = DateTime.Now;
        //								prevDesk.HasPushed = false;
        //								prevDesk.HasWork = false;
        //								prevDesk.UpdatedAt = DateTime.Now;
        //								_context.SaveChanges();

        //								_helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection", comment);

        //								//send mail to staff
        //								var getStaff = (from stf in _context.staff
        //												join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
        //												where stf.StaffID == prevDesk.StaffID && stf.DeleteStatus != true
        //												select stf).FirstOrDefault();

        //								string subject = $"Rejection for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

        //								string content = $"{WKPCompanyName} rejected WORK PROGRAM application for year {application.YearOfWKP}.";

        //								var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");

        //								var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

        //								_helpersController.LogMessages("Rejection of application with REF : " + application.ReferenceNo, WKPCompanyEmail);

        //								return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been rejected successfully.", StatusCode = ResponseCodes.Success };
        //							}
        //							else
        //							{
        //								return BadRequest(new { message = "An error occured while trying to reject this application." });
        //							}
        //						}
        //					}
        //				}
        //			}
        //		}
        //		else
        //		{
        //			return BadRequest(new { message = "Error: No application ID was passed for this action to be completed." });
        //		}

        //		return BadRequest(new { message = "Error: No action was carried out on this application." });
        //	}
        //	catch (Exception x)
        //	{
        //		_helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
        //		return BadRequest(new { message = $"An error occured while rejecting application."+ x.Message.ToString() });
        //	}

        //}

        [HttpPost("RejectApplication")]
        public async Task<object> RejectApplication(/*[FromBody] ActionModel model,*/ int deskID, string comment, string[] selectedApps, string[] SBU_IDs, string[] selectedTables)
        {
            try
            {
                var SBU_IDs_int = new int[SBU_IDs.Length];

                if (selectedApps != null)
                {
                    var tempSBUs = new List<string>();
                    foreach (string s in SBU_IDs)
                    {
                        if (s != null && s != "undefined")
                        {
                            tempSBUs.Add(s);
                        }
                    }

                    if (tempSBUs.Count > 0)
                    {
                        for (int i = 0; i < tempSBUs.Count; i++)
                        {
                            SBU_IDs_int[i] = int.Parse(tempSBUs[i]);
                        }
                    }
                    else
                    {
                        SBU_IDs_int = null;
                    }

                    foreach (var b in selectedApps)
                    {
                        int appId = b != "undefined" ? int.Parse(b) : 0;
                        //get current staff desk

                        var get_CurrentStaff = (from stf in _context.staff
                                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                                join role in _context.Roles on stf.RoleID equals role.id
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


                        //Fetch App process flow
                        //var processFlow = _context.ApplicationProccesses.Where<ApplicationProccess>(p => p.ProccessID == staffDesk.ProcessID).FirstOrDefault();

                        var staffSBU = _context.StrategicBusinessUnits.Where<StrategicBusinessUnit>(s => s.Id == get_CurrentStaff.Staff_SBU).FirstOrDefault();
                        var staffRole = _context.Roles.Where<Role>(r => r.id == get_CurrentStaff.RoleID).FirstOrDefault();

                        //Determine if the app is in the reviewer's desk
                        var appStatus = application.Status;

                        if (staffSBU?.Tier == PROCESS_TIER.TIER1 && staffRole?.Rank == (int)ROLE_RANK.ONE)
                        {
                            var getStaff = (from stf in _context.staff where stf.StaffID == staffDesk.StaffID select stf).FirstOrDefault();

                            var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == appId && x.SBU_ID == getStaff.Staff_SBU && x.ActionStatus == GeneralModel.Rejected).FirstOrDefaultAsync();

                            if (NRejectApp == null)
                            {
                                List<string> RejectedForms = new List<string>();
                                string RejectedTables = "";
                                if (selectedTables.Count() > 0)
                                {
                                    foreach (var table in selectedTables)
                                    {
                                        int tableID = table != "undefined" ? int.Parse(table) : 0;
                                        var getSBU_TablesToDisplay = await _context.Table_Details.Where(x => x.TableId == tableID).FirstOrDefaultAsync();

                                        if (getSBU_TablesToDisplay != null)
                                            RejectedTables = RejectedTables != "" ? $"{RejectedTables}|{getSBU_TablesToDisplay.TableName}" : getSBU_TablesToDisplay.TableName;

                                    }
                                }


                                var nReject = new SBU_ApplicationComment()
                                {
                                    SBU_Comment = comment,
                                    SBU_ID = getStaff.Staff_SBU,
                                    Staff_ID = getStaff.StaffID,
                                    ActionStatus = GeneralModel.Rejected,
                                    SBU_Tables = RejectedTables,
                                    AppID = appId,
                                    DateCreated = DateTime.Now,
                                };

                                await _context.SBU_ApplicationComments.AddAsync(nReject);

                                if (await _context.SaveChangesAsync() > 0)
                                {

                                    //var result = await _helpersController.DeleteDeskIdByDeskId(deskID);
                                    await _helpersController.UpdateDeskAfterReject(staffDesk, comment, STAFF_DESK_STATUS.REJECTED);

                                    _helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, "Rejection", comment);

                                    var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();

                                    string subject = $"Comment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

                                    string content = $"{SBU?.SBU_Name} made comment on your WORK PROGRAM application for year {application.YearOfWKP}. See comment :- " + comment;
                                    var emailMsg = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
                                    var sendEmail = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

                                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Rejection for application {concession.Concession_Held} has been sent to the company.", StatusCode = ResponseCodes.Success };
                                }
                            }
                        }


                        //if (staffDesk.Sort == 1) //Rejection to company
                        //{
                        //	var getStaff = (from stf in _context.staff where stf.StaffID == staffDesk.StaffID select stf).FirstOrDefault();

                        //	var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == appId && x.SBU_ID == getStaff.Staff_SBU && x.ActionStatus == GeneralModel.Initiated).FirstOrDefaultAsync();

                        //	if (NRejectApp == null)
                        //	{
                        //		List<string> RejectedForms = new List<string>();
                        //		string RejectedTables = "";
                        //		if (selectedTables.Count() > 0)
                        //		{
                        //			foreach (var table in selectedTables)
                        //			{
                        //				int tableID = table != "undefined" ? int.Parse(table) : 0;
                        //				var getSBU_TablesToDisplay = await _context.Table_Details.Where(x => x.TableId == tableID).FirstOrDefaultAsync();

                        //				if (getSBU_TablesToDisplay != null)
                        //					RejectedTables = RejectedTables != "" ? $"{RejectedTables}|{getSBU_TablesToDisplay.TableName}" : getSBU_TablesToDisplay.TableName;

                        //			}
                        //		}


                        //		var nReject = new SBU_ApplicationComment()
                        //		{
                        //			SBU_Comment = comment,
                        //			SBU_ID = getStaff.Staff_SBU,
                        //			Staff_ID = getStaff.StaffID,
                        //			ActionStatus = GeneralModel.Initiated,
                        //			SBU_Tables = RejectedTables,
                        //			AppID = appId,
                        //			DateCreated = DateTime.Now,

                        //		};
                        //		await _context.SBU_ApplicationComments.AddAsync(nReject);

                        //		if (await _context.SaveChangesAsync() > 0)
                        //		{
                        //			var SBU = await (from sb in _context.StrategicBusinessUnits where sb.Id == getStaff.Staff_SBU select sb).FirstOrDefaultAsync();

                        //			string subject = $"Comment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

                        //			string content = $"{SBU?.SBU_Name} made comment on your WORK PROGRAM application for year {application.YearOfWKP}. See comment :- " + comment;
                        //			var emailMsg = _helpersController.SaveMessage(application.Id, Company.Id, subject, content, "Company");
                        //			var sendEmail = _helpersController.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

                        //			return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Rejection for application {concession.Concession_Held} has been sent to the company.", StatusCode = ResponseCodes.Success };

                        //		}
                        //	}
                        //}
                        else
                        {
                            //var prevDesk = (from dsk in _context.MyDesks
                            //                join stf in _context.staff on dsk.StaffID equals stf.StaffID
                            //                where stf.StaffID == staffDesk.FromStaffID && stf.Staff_SBU == get_CurrentStaff.Staff_SBU && dsk.FromSBU == staffDesk.FromSBU && stf.DeleteStatus != true
                            //                select dsk).FirstOrDefault();

                            var prevDesk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == staffDesk.FromStaffID && d.AppId == appId).FirstOrDefaultAsync();

                            if (SBU_IDs_int != null && SBU_IDs_int.Length > 0)
                            {
                                foreach (var SBU in SBU_IDs_int)
                                {
                                    if (SBU > 0)
                                    {
                                        prevDesk = (from dsk in _context.MyDesks
                                                    join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                                    where stf.StaffID == staffDesk.FromStaffID && dsk.AppId == appId && stf.Staff_SBU == SBU && dsk.FromSBU == staffDesk.FromSBU && stf.DeleteStatus != true
                                                    select dsk).FirstOrDefault();


                                        //}
                                        //if (prevDesk != null)
                                        //{
                                        //update staff desk
                                        //staffDesk.HasPushed = true;
                                        //staffDesk.HasWork = true;
                                        //staffDesk.ProcessStatus = STAFF_DESK_STATUS.REJECTED;
                                        //staffDesk.UpdatedAt = DateTime.Now;
                                        //_context.SaveChanges();


                                        if (prevDesk != null)
                                        {
                                            prevDesk.HasPushed = false;
                                            prevDesk.HasWork = true;
                                            prevDesk.UpdatedAt = DateTime.Now;
                                            prevDesk.Comment = comment;
                                            prevDesk.ProcessStatus = STAFF_DESK_STATUS.REJECTED;
                                            _context.SaveChanges();
                                        }
                                        else
                                        {
                                            var desk = new MyDesk()
                                            {
                                                StaffID = (int)staffDesk.FromStaffID,
                                                AppId = appId,
                                                HasWork = true,
                                                HasPushed = true,
                                                FromStaffID = staffDesk.FromStaffID,
                                                FromSBU = staffDesk.FromSBU,
                                                FromRoleId = staffDesk.FromRoleId,
                                                CreatedAt = DateTime.Now,
                                                UpdatedAt = DateTime.Now,
                                                Comment = comment,
                                                LastJobDate = DateTime.Now,
                                                ProcessStatus = STAFF_DESK_STATUS.REJECTED,
                                            };

                                            await _context.MyDesks.AddAsync(desk);
                                        }


                                        //var result = await _helpersController.DeleteDeskIdByDeskId(deskID);
                                        await _helpersController.UpdateDeskAfterReject(staffDesk, comment, STAFF_DESK_STATUS.REJECTED);


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
                                    //else
                                    //{
                                    //    return BadRequest(new { message = "An error occured while trying to reject this application." });
                                    //}
                                }
                            }
                            else
                            {
                                //if (prevDesk != null)
                                //{
                                //update staff desk
                                //staffDesk.HasPushed = true;
                                //staffDesk.HasWork = true;
                                //staffDesk.ProcessStatus = STAFF_DESK_STATUS.REJECTED;
                                //staffDesk.UpdatedAt = DateTime.Now;

                                if (prevDesk != null)
                                {
                                    prevDesk.HasPushed = false;
                                    prevDesk.HasWork = true;
                                    prevDesk.UpdatedAt = DateTime.Now;
                                    prevDesk.Comment = comment;
                                    prevDesk.ProcessStatus = STAFF_DESK_STATUS.REJECTED;
                                    _context.SaveChanges();
                                }
                                else
                                {
                                    var desk = new MyDesk()
                                    {
                                        StaffID = (int)staffDesk.FromStaffID,
                                        AppId = appId,
                                        HasWork = true,
                                        HasPushed = true,
                                        FromStaffID = staffDesk.FromStaffID,
                                        FromSBU = staffDesk.FromSBU,
                                        FromRoleId = staffDesk.FromRoleId,
                                        CreatedAt = DateTime.Now,
                                        UpdatedAt = DateTime.Now,
                                        Comment = comment,
                                        LastJobDate = DateTime.Now,
                                        ProcessStatus = STAFF_DESK_STATUS.REJECTED,
                                    };

                                    await _context.MyDesks.AddAsync(desk);

                                    prevDesk = desk;
                                }

                                //var result = await _helpersController.DeleteDeskIdByDeskId(deskID);
                                await _helpersController.UpdateDeskAfterReject(staffDesk, comment, STAFF_DESK_STATUS.REJECTED);


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
                                //}
                                //else
                                //{
                                //    return BadRequest(new { message = "An error occured while trying to reject this application." });
                                //}
                            }
                        }
                    }
                }
                else
                {
                    return BadRequest(new { message = "Error: No application ID was passed for this action to be completed." });
                }

                return BadRequest(new { message = "Error: No action was carried out on this application." });
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return BadRequest(new { message = $"An error occured while rejecting application." + x.Message.ToString() });
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
                    var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();

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
                    return BadRequest(new { message = responseMessage });
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMessage, StatusCode = ResponseCodes.Success };
            }
            catch (Exception x)
            {
                _helpersController.LogMessages($"Approve Error:: {x.ToString()}");
                return BadRequest(new { message = $"An error occured while approving application(s)." });
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
                return BadRequest(new { message = "Error : " + e.Message });
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
                return BadRequest(new { message = "Error : " + ex.Message });
            }
        }

        [HttpPost("Post_Planning_Requirement")]
        public async Task<object> Post_Planning_Requirement([FromBody] Planning_MinimumRequirement model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower();
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
                            return BadRequest(new { message = $"Error : This details could not be found." });
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
                    string successMsg = Messager.ShowMessage(action);
                    var allData = await (from d in _context.Planning_MinimumRequirements
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form." });

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });

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
                return BadRequest(new { message = "Error : " + ex.Message });
            }
        }

        [HttpPost("Post_HSE_Requirement")]
        public async Task<object> Post_HSE_Requirement([FromBody] HSE_MinimumRequirement model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");

            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower();
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
                            return BadRequest(new { message = $"Error : This details could not be found." });
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
                    string successMsg = Messager.ShowMessage(action);

                    var allData = await (from d in _context.HSE_MinimumRequirements
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form." });

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });

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
                return BadRequest(new { message = "Error : " + ex.Message });
            }
        }

        [HttpPost("Post_DecommisioningAbandonment")]
        public async Task<object> Post_DecommisioningAbandonment([FromBody] DecommissioningAbandonment model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower();
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
                        return BadRequest(new { message = $"Error : This data is already existing and can not be duplicated." });
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
                            return BadRequest(new { message = $"Error : This details could not be found." });
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
                    string successMsg = Messager.ShowMessage(action);
                    var allData = await (from d in _context.DecommissioningAbandonments
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form." });

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });

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
                return BadRequest(new { message = "Error : " + ex.Message });
            }
        }

        [HttpPost("Post_Development_Production")]
        public async Task<object> Post_Development_Production([FromBody] Development_And_Production model, string year, string omlName, string id, string actionToDo)
        {

            int save = 0;
            var concessionField = GET_CONCESSION_FIELD(omlName, "");
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower();
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
                        return BadRequest(new { message = $"Error : This data is already existing and can not be duplicated." });
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
                            return BadRequest(new { message = $"Error : This details could not be found." });
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
                    string successMsg = Messager.ShowMessage(action);
                    var allData = await (from d in _context.Development_And_Productions
                                         where d.CompanyNumber == WKPCompanyNumber && d.ConcessionID == concessionField.Result.Concession_ID
                                         select d).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allData, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = $"Error : An error occured while trying to {actionToDo} this form." });

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });

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
                                       join sbu in _context.StrategicBusinessUnits on prc.TargetedToSBU equals sbu.Id
                                       join sbu1 in _context.StrategicBusinessUnits on prc.TriggeredBySBU equals sbu1.Id
                                       join role in _context.Roles on prc.TargetedToRole equals role.id
                                       join role1 in _context.Roles on prc.TriggeredByRole equals role1.id
                                       where prc.DeleteStatus != true
                                       select new
                                       {
                                           Id = prc.ProccessID,
                                           Type = "New",
                                           //Sort = prc.Sort,
                                           ProcessAction = prc.ProcessAction,
                                           ProcessStatus = prc.ProcessStatus,
                                           TriggeredByRole = role1.RoleName, //prc.TriggeredByRole,
                                           TargetedToRole = role.RoleName, //prc.TargetedToRole,
                                           TriggeredBySBU = sbu1.SBU_Name, //prc.TriggeredBySBU,
                                           TargetedToSBU = sbu.SBU_Name, //prc.TriggeredBySBU,
                                                                         //Tier = prc.Tier,
                                                                         //Role = role.RoleName,
                                                                         //SBU = sbu.SBU_Name,
                                                                         //Process = prc.Sort,
                                       }).ToListAsync();

                var roles = await _context.Roles.ToListAsync();
                var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                var processActions = new string[] { GeneralModel.Submit, GeneralModel.Reject, GeneralModel.Approve, GeneralModel.Push, GeneralModel.Delegate, GeneralModel.FinalApproval };
                var processStatuses = new string[] { GeneralModel.Processing, GeneralModel.Submitted, GeneralModel.Rejected, GeneralModel.Approved };
                return new
                {
                    Processes = processes.OrderBy(x => x.TriggeredBySBU),
                    Roles = roles,
                    SBUs = SBUs,
                    processActions = processActions,
                    processStatuses = processStatuses
                };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        //[HttpPost("CreateProcess")]
        //public async Task<object> CreateProcess(int roleID, int sbuID, int triggeredByRole, int targetedToRole, int triggeredBySBU, int targetedBySBU, string processAction, string processStatus, int sort = 0)
        //{
        //	try
        //	{
        //		if (roleID <= 0 || sbuID <= 0 || string.IsNullOrEmpty(processAction) || string.IsNullOrEmpty(processStatus) || triggeredByRole<=0 || targetedToRole<=0)
        //		{
        //			return BadRequest(new { message = $"Error : Role/SBU/Sort ID was not passed correctly." });
        //		}

        //		var process = await (from prc in _context.ApplicationProccesses
        //							 where prc.RoleID == roleID && prc.SBU_ID == sbuID && prc.Sort == sort && prc.ProcessAction==processAction && prc.ProcessStatus==processStatus && prc.DeleteStatus != true
        //							 select prc).FirstOrDefaultAsync();
        //		if (process != null)
        //		{
        //			return BadRequest(new { message = $"Error : Process is already existing and can not be duplicated." });
        //		}
        //		else
        //		{
        //			var nProcess = new ApplicationProccess()
        //			{
        //				ProcessStatus=processStatus,
        //				ProcessAction=processAction,
        //				TriggeredBy=triggeredByRole,
        //				TargetTo=targetedToRole,
        //				Sort = sort,
        //				RoleID = roleID,
        //				SBU_ID = sbuID,
        //				CreatedAt = DateTime.Now,
        //				CreatedBy=WKPCompanyEmail,
        //				UpdatedBy=WKPCompanyEmail,
        //				UpdatedAt=DateTime.Now,
        //				DeleteStatus = false,
        //				CategoryID = 1 //Default for new applications
        //			};
        //			await _context.ApplicationProccesses.AddAsync(nProcess);

        //			if (await _context.SaveChangesAsync() > 0)
        //			{
        //				var processes = await (from prc in _context.ApplicationProccesses
        //									   join sbu in _context.StrategicBusinessUnits on prc.SBU_ID equals sbu.Id
        //									   join role in _context.Roles on prc.RoleID equals role.id
        //									   where prc.DeleteStatus != true
        //									   select new
        //									   {
        //										   Type = "New",
        //										   Sort = prc.Sort,
        //										   Role = role.RoleName,
        //										   SBU = sbu.SBU_Name,
        //										   Process = prc.Sort,
        //									   }).ToListAsync();
        //				var roles = await _context.Roles.ToListAsync();
        //				var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

        //				return new
        //				{
        //					Processes = processes,
        //					Roles = roles,
        //					SBUs = SBUs,
        //				};
        //			}
        //			else
        //			{
        //				return BadRequest(new { message = $"Error : An error occured while trying to create this process." });
        //			}
        //		}
        //	}
        //	catch (Exception e)
        //	{
        //		return BadRequest(new { message = "Error : " + e.Message });
        //	}
        //}
        [HttpPost("CreateProcess")]
        public async Task<object> CreateProcess([FromBody] ApplicationProccess proccess)
        {
            try
            {
                if (string.IsNullOrEmpty(proccess.ProcessAction) || string.IsNullOrEmpty(proccess.ProcessStatus) || proccess.TriggeredByRole <= 0 || proccess.TargetedToRole <= 0)
                {
                    return BadRequest(new { message = $"Error : Role/SBU/Sort ID was not passed correctly." });
                }

                var getProcess = await (from prc in _context.ApplicationProccesses
                                        where prc.ProcessAction == proccess.ProcessAction && prc.ProcessStatus == proccess.ProcessStatus && prc.TriggeredByRole == proccess.TriggeredByRole && prc.TriggeredBySBU == proccess.TriggeredBySBU && prc.TargetedToRole == proccess.TargetedToRole && prc.TargetedToSBU == proccess.TargetedToSBU && prc.DeleteStatus != true
                                        select prc).FirstOrDefaultAsync();
                if (getProcess != null)
                {
                    return BadRequest(new { message = $"Error : Process is already existing and can not be duplicated." });
                }
                else
                {


                    proccess.CreatedAt = DateTime.Now;
                    proccess.CreatedBy = WKPCompanyEmail;
                    proccess.UpdatedBy = WKPCompanyEmail;
                    proccess.UpdatedAt = DateTime.Now;
                    proccess.DeleteStatus = false;
                    proccess.CategoryID = 1; //Default for new applications


                    await _context.ApplicationProccesses.AddAsync(proccess);

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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this process." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("EditProcess")]
        public async Task<object> EditProcess(int id, int roleID, int sbuID, int triggeredByRole, int targetedToRole, int triggeredBySBU, int targetedToSBU, string processAction, string processStatus, int sort = 0)
        {
            try
            {
                var process = await (from prc in _context.ApplicationProccesses
                                     where prc.ProccessID == id && prc.DeleteStatus != true
                                     select prc).FirstOrDefaultAsync();

                if (process == null)
                {
                    return BadRequest(new { message = $"Error : Process details could not be found or an invalid ID was supplied." });
                }
                //else
                //{
                //process.Sort = sort;
                //process.RoleID = roleID;
                //process.SBU_ID = sbuID;
                //process.ProcessStatus=(PROCESS_STATUS)processStatus;
                //process.ProcessAction=(PROCESS_ACTION)processAction;
                process.ProcessStatus = processStatus;
                process.ProcessAction = processAction;
                process.TriggeredByRole = triggeredByRole;
                process.TargetedToRole = targetedToRole;
                process.TriggeredBySBU = triggeredBySBU;
                process.TargetedToSBU = targetedToSBU;
                process.UpdatedAt = DateTime.Now;
                process.UpdatedBy = WKPCompanyEmail;
                //process.Tier = tier;


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
                                               //Process = prc.Sort,
                                               ProccessAction = prc.ProcessAction,
                                               ProcessStatus = prc.ProcessStatus,
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
                    return BadRequest(new { message = $"Error : An error occured while trying to edit this process." });
                }
                //}
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                    return BadRequest(new { message = $"Error : Process details could not be found or an invalid ID was supplied." });
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
                        return BadRequest(new { message = $"Error : An error occured while trying to delete this process." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpGet("GetSBU_Tables")]
        public async Task<object> GetSBU_Tables()
        {
            try
            {
                var SBU_Tables = await (from tab in _context.Table_Details
                                        join sbu in _context.StrategicBusinessUnits on tab.SBU_ID equals sbu.Id.ToString()
                                        select new
                                        {
                                            Id = tab.TableId,
                                            TableName = tab.TableName,
                                            Role = tab.TableSchema,
                                            SBU = sbu.SBU_Name
                                        }).ToListAsync();
                var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                return new
                {
                    SBU_Tables = SBU_Tables.OrderBy(x => x.SBU),
                    SBUs = SBUs,
                };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("CreateSBU_Tables")]
        public async Task<object> CreateSBU_Tables(int sbuID, string TableName, string TableSchema)
        {
            try
            {
                if (TableName == null || sbuID <= 0 || TableSchema == null)
                {
                    return BadRequest(new { message = $"Error : Table name/schema/SBU ID was not passed correctly." });
                }

                var SBU_Tables = await (from tab in _context.Table_Details
                                        where tab.TableName.ToLower() == TableName.ToLower() && tab.TableSchema.ToLower() == TableSchema.ToLower() && tab.SBU_ID == sbuID.ToString()/*tab.SBU_ID.Contains(sbuID.ToString())*/
                                        select tab).FirstOrDefaultAsync();
                if (SBU_Tables != null)
                {
                    return BadRequest(new { message = $"Error : This table is already existing for this SBU and can not be duplicated." });
                }
                else
                {
                    var nSBU_Tables = new Table_Detail()
                    {
                        TableName = TableName,
                        TableSchema = TableSchema,
                        SBU_ID = sbuID.ToString()
                    };
                    await _context.Table_Details.AddAsync(nSBU_Tables);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var AllSBU_Tables = await (from tab in _context.Table_Details
                                                   join sbu in _context.StrategicBusinessUnits on tab.SBU_ID equals sbu.Id.ToString()
                                                   select new
                                                   {
                                                       Id = tab.TableId,
                                                       TableName = tab.TableName,
                                                       Role = tab.TableSchema,
                                                       SBU = sbu.SBU_Name
                                                   }).ToListAsync();
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            SBU_Tables = AllSBU_Tables.OrderBy(x => x.SBU),
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU table." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("EditSBU_Tables")]
        public async Task<object> EditSBU_Tables(int id, string TableName, int sbuID, string TableSchema)
        {
            try
            {
                if (TableName == null || id <= 0 || sbuID <= 0 || TableSchema == null)
                {
                    return BadRequest(new { message = $"Error : Table ID/name/schema/SBU_ID was not passed correctly." });
                }

                var SBU_Tables = await (from tab in _context.Table_Details
                                        where tab.TableId == id/*tab.SBU_ID.Contains(sbuID.ToString())*/
                                        select tab).FirstOrDefaultAsync();
                if (SBU_Tables == null)
                {
                    return BadRequest(new { message = $"Error : SBU_Tables details could not be found or an invalid ID was supplied." });
                }
                else
                {

                    SBU_Tables.TableName = TableName;
                    SBU_Tables.TableSchema = TableSchema;
                    SBU_Tables.SBU_ID = sbuID.ToString();

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var AllSBU_Tables = await (from tab in _context.Table_Details
                                                   join sbu in _context.StrategicBusinessUnits on tab.SBU_ID equals sbu.Id.ToString()
                                                   select new
                                                   {
                                                       Id = tab.TableId,
                                                       TableName = tab.TableName,
                                                       Role = tab.TableSchema,
                                                       SBU = sbu.SBU_Name
                                                   }).ToListAsync();
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            SBU_Tables = AllSBU_Tables.OrderBy(x => x.SBU),
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to edit this SBU table." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("DeleteSBU_Tables")]
        public async Task<object> DeleteSBU_Tables(int id)
        {
            try
            {
                var SBU_Tables = await (from tab in _context.Table_Details
                                        where tab.TableId == id
                                        select tab).FirstOrDefaultAsync();
                if (SBU_Tables == null)
                {
                    return BadRequest(new { message = $"Error : SBU_Tables details could not be found or an invalid ID was supplied." });
                }
                else
                {
                    _context.Table_Details.Remove(SBU_Tables);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var AllSBU_Tables = await (from tab in _context.Table_Details
                                                   join sbu in _context.StrategicBusinessUnits on tab.SBU_ID equals sbu.Id.ToString()
                                                   select new
                                                   {
                                                       Id = tab.TableId,
                                                       TableName = tab.TableName,
                                                       Role = tab.TableSchema,
                                                       SBU = sbu.SBU_Name
                                                   }).ToListAsync();
                        var SBUs = await _context.StrategicBusinessUnits.ToListAsync();

                        return new
                        {
                            SBU_Tables = AllSBU_Tables.OrderBy(x => x.SBU),
                            SBUs = SBUs,
                        };
                    }
                    else
                    {
                        return BadRequest(new { message = $"Error : An error occured while trying to delete this SBU table." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("CreateSBU")]
        public async Task<object> CreateSBU(string name, string code, int tier)
        {
            try
            {
                var SBU = await (from sb in _context.StrategicBusinessUnits
                                 where sb.SBU_Name.ToLower() == name.ToLower()
                                 select sb).FirstOrDefaultAsync();
                if (SBU != null)
                {
                    return BadRequest(new { message = $"Error : SBU is already existing and can not be duplicated." });
                }
                else
                {
                    var nSBU = new StrategicBusinessUnit()
                    {
                        SBU_Name = name,
                        SBU_Code = code,
                        Tier = tier,
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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("EditSBU")]
        public async Task<object> EditSBU(int id, string name, string code, int tier)
        {
            try
            {
                var SBU = await (from sb in _context.StrategicBusinessUnits
                                 where sb.Id == id
                                 select sb).FirstOrDefaultAsync();
                if (SBU == null)
                {
                    return BadRequest(new { message = $"Error : SBU details could not be found or an invalid ID was supplied." });
                }
                else
                {
                    //SBU.SBU_Name = name.ToUpper();
                    //SBU.SBU_Code = code.ToUpper();
                    SBU.SBU_Name = name;
                    SBU.SBU_Code = code;
                    SBU.Tier = tier;

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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                    return BadRequest(new { message = $"Error : SBU details could not be found or an invalid ID was supplied." });
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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this SBU." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("CreateRole")]
        public async Task<object> CreateRole(string name, string description, int rank)
        {
            try
            {
                var Role = await (from sb in _context.Roles
                                  where sb.RoleName.ToLower() == name.ToLower()
                                  select sb).FirstOrDefaultAsync();
                if (Role != null)
                {
                    return BadRequest(new { message = $"Error : Role is already existing and can not be duplicated." });
                }
                else
                {
                    var nRole = new Role()
                    {
                        RoleId = (new Regex(@"\s+")).Replace(name, "&"),
                        RoleName = name,
                        Description = description,
                        Rank = rank,
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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this Role." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }
        [HttpPost("EditRole")]
        public async Task<object> EditRole(int id, string name, string description, int rank)
        {
            try
            {
                var Role = await (from sb in _context.Roles
                                  where sb.id == id
                                  select sb).FirstOrDefaultAsync();
                if (Role == null)
                {
                    return BadRequest(new { message = $"Error : Role details could not be found or an invalid ID was supplied." });
                }
                else
                {
                    //Role.RoleName = name.ToUpper();
                    //Role.Description = description.ToUpper();

                    Role.RoleName = name;
                    Role.Description = description;
                    Role.Rank = rank;

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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this Role." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
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
                    return BadRequest(new { message = $"Error : Role details could not be found or an invalid ID was supplied." });
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
                        return BadRequest(new { message = $"Error : An error occured while trying to create this Role." });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        #endregion

		#region SBU Report
		[HttpGet("GetSBU_Report")]
		public async Task<object> GetSBU_Report(int appID)
		{
			string[] Item_types = { "Capex", "Opex" };

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

                        case "ER&SP": //Work Programme

                            var geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var capexOpexItems = await (from d in _context.BUDGET_CAPEX_OPices where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                            var budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var royalty = await (from d in _context.Royalties where d.CompanyNumber == application.CompanyID && d.Field_ID==fieldID && d.Year == year select d).FirstOrDefaultAsync();

                            var BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).FirstOrDefaultAsync();


                            return new
                            {
                                geoActivitiesAcquisition = geoActivitiesAcquisition,
                                geoActivitiesProcessing = geoActivitiesProcessing,
                                drillEachCost = drillEachCost,
                                drillEachCostProposed = drillEachCostProposed,
                                drillOperationCategoriesWell = drillOperationCategoriesWell,
                                capexOpexItems = capexOpexItems,
                                budgetProposalNairaDollar= budgetProposalNairaDollar,
                                royalty = royalty,
                                budgetCapex = BudgetCapex,
                                budgetOpex = BudgetOpex

                            };

							break;
						case "E&AM": //Planning

							var PlanningRequirement = await (from c in _context.Planning_MinimumRequirements where c.CompanyNumber == application.CompanyID && c.Year.ToString() == year select c).FirstOrDefaultAsync();
							var BudgetActualExpenditure = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var BudgetPerformanceExploratory = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var BudgetPerformanceDevelopment = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var BudgetPerformanceProductionCost = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var BudgetPerformanceFacilityDevProjects = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var BudgetProposalComponents = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var geoActivitiesAcquisitions = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();
                            
                            var BudgetCapexOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var categoriesProposedWell = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                            return new
							{
								PlanningRequirement = PlanningRequirement,
								BudgetActualExpenditure = BudgetActualExpenditure,
								BudgetPerformanceExploratory = BudgetPerformanceExploratory,
								BudgetPerformanceDevelopment = BudgetPerformanceDevelopment,
								BudgetPerformanceProductionCost = BudgetPerformanceProductionCost,
								BudgetPerformanceFacilityDevProjects = BudgetPerformanceFacilityDevProjects,
								BudgetProposalComponents = BudgetProposalComponents,
								//BudgetCapex = BudgetCapex,
								//BudgetOpex = BudgetOpex,
                                geoActivitiesAcquisitions = geoActivitiesAcquisitions,
                                geoActivitiesProcessings = geoActivitiesProcessings,
                                concessionSituations = concessionSituations,
                            };


						case "D & P":

							var OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var OilCondensateProductionMonthly = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
							var OilCondensateProductionMonthlyProposed = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
							var OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

							return new
							{
								OilCondensateProduction = OilCondensateProduction,
								OilCondensateProductionMonthly = OilCondensateProductionMonthly,
								OilCondensateProductionMonthlyProposed = OilCondensateProductionMonthlyProposed,
								OilCondensateFiveYears = OilCondensateFiveYears
							};

						case "CS & A":

							var HSESustainableDevProgramCsr_1 = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
							var NigeriaContent = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
							var NigeriaContentUploadSuccession = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
							var NigeriaContentQuestion = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

							return new
							{
								HSESustainableDevProgramCsr = HSESustainableDevProgramCsr_1,
								NigeriaContent = NigeriaContent,
								NigeriaContentUploadSuccession = NigeriaContentUploadSuccession,
								NigeriaContentQuestion = NigeriaContentQuestion
							};
                            return new
                            {
                                PlanningRequirement = PlanningRequirement,
                                BudgetActualExpenditure = BudgetActualExpenditure,
                                BudgetPerformanceExploratory = BudgetPerformanceExploratory,
                                BudgetPerformanceDevelopment = BudgetPerformanceDevelopment,
                                BudgetPerformanceProductionCost = BudgetPerformanceProductionCost,
                                BudgetPerformanceFacilityDevProjects = BudgetPerformanceFacilityDevProjects,
                                BudgetProposalComponents = BudgetProposalComponents,
                                BudgetCapexOpex = BudgetCapexOpex,
                                categoriesProposedWell= categoriesProposedWell
                            };

                        case "LGL": //Legal

                            var LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            return new
                            {
                                LegalLitigation = LegalLitigation,
                                LegalArbitration = LegalArbitration
                            };



                        case "D&P": //SBU

                            var strategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var facilitiesProjectPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var conformityAssuranceAssetIntegrity = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var facilityDevelopmentProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).FirstOrDefaultAsync();
                            var concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).FirstOrDefaultAsync();
                            var wellType = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var expectedReserves = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _categoriesProposedWell = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();



                            return new
                            {
                                strategicPlans = strategicPlans,
                                facilitiesProjectPerformance = facilitiesProjectPerformance,
                                conformityAssuranceAssetIntegrity = conformityAssuranceAssetIntegrity,
                                facilityDevelopmentProjects = facilityDevelopmentProjects,
                                lifeIndex_years= lifeIndex_years,
                                depletionRate = depletionRate,
                                fiveYearTrendConcessionReserveReplacementRatio = fiveYearTrendConcessionReserveReplacementRatio,
                                reserveDecline = reserveDecline,
                                reserveAddition = reserveAddition,
                                fiveYearReservesProjection= fiveYearReservesProjection,
                                //fiveYearReservesProjectionTerrain = fiveYearReservesProjection,
                                concessionReservesPrecedingYearJanuary = concessionReservesPrecedingYearJanuary,
                                wellType = wellType,
                                workoverRecompletionJobsQuaterlyBasis = workoverRecompletionJobsQuaterlyBasis,
                                initialWellCompletionJobsQuaterlyBasis = initialWellCompletionJobsQuaterlyBasis,
                                unitization = unitization,
                                expectedReserves = expectedReserves,
                                fieldDevelopmentPlan = fieldDevelopmentPlan,
                                _categoriesProposedWell = _categoriesProposedWell


                            };

                        case "CS&A": //SBU

                            var _strategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var successPlans = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var picturesCommunityDevelopmentProjects = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var trainingDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var scholarshipSchemes = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var mOUInformation = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();




                            return new
                            {
                                _strategicPlans = _strategicPlans,
                                successPlans = successPlans,
                                seniorManagementStaff = seniorManagementStaff,
                                staffDisposition = staffDisposition,
                                picturesCommunityDevelopmentProjects = picturesCommunityDevelopmentProjects,
                                trainingDetails = trainingDetails,
                                trainingsSkillAcquisition = trainingsSkillAcquisition,
                                scholarshipSchemes = scholarshipSchemes,
                                scholarships = scholarships,
                                capitalProjects = capitalProjects,
                                projectDetails = projectDetails,
                                mOUInformation = mOUInformation,
                                sustainableDevelopmentCommunityProjectProgram = sustainableDevelopmentCommunityProjectProgram
                        };




                        case "HSE&C": //HSE
                            var HSERequirement = await (from c in _context.HSE_MinimumRequirements where c.CompanyNumber == application.CompanyID && c.Year.ToString() == year select c).FirstOrDefaultAsync();
                            var HSEQuestion = await (from c in _context.HSE_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEFatality = await (from c in _context.HSE_FATALITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEDesignSafety = await (from c in _context.HSE_DESIGNS_SAFETies where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEInspectionMaintenance = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEInspectionMaintenanceFacility = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSESafetyStudies = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                            var HSEAssetRegister = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEOilSpill = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEAssetRegisterRBI = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                            var HSEAccidentIncidence = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEAccidentIncidenceType = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var accidentModel = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                                       join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                                       where a1.CompanyNumber == application.CompanyID && a1.Year_of_WP == year
                                                       && a2.CompanyNumber == application.CompanyID && a2.Year_of_WP == year
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

                            var HSECommunityDisturbance = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEEnvironmentalStudies = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEWasteManagementType = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEProducedWaterMgt = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEEnvironmentalCompliance = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();


                            var HSEEnvironmentalFiveYears = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSESustainableDev = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEEnvironmentalStudiesUpdated = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEOSPRegistrations = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEProducedWaterMgtUpdated = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSEEnvironmentalComplianceChemical = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSECausesOfSpill = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var HSESustainableDevMOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

							var HSESustainableDevProgramCsr1 = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

							var HSESustainableDevScheme = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSEManagementPosition = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSEQualityControl = await (from c in _context.HSE_QUALITY_CONTROLs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSEClimateChange = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSEWasteManagementSystems = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var HSEEnvironmentalManagementSystems = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseEffluentCompliances = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.CompanyNumber == application.CompanyID.ToString() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseWasteManagementDZs = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hsePointSourceRegistrations = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.Company_Number == application.CompanyID.ToString() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
							var hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                            return new
							{
								HSERequirement = HSERequirement,
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
								HSESustainableDevProjProgramCsr = HSESustainableDevProgramCsr1,

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
                                hseEnvironmentalManagementPlans = hseEnvironmentalManagementPlans,
                                hseRemediationFunds = hseRemediationFunds,
                                hseWasteManagementDZs = hseWasteManagementDZs,
                                hseEffluentCompliances = hseEffluentCompliances,
                                hseGHGManagementPlans = hseGHGManagementPlans,
                                hseHostCommunitiesDevelopments = hseHostCommunitiesDevelopments,
                                hsePointSourceRegistrations = hsePointSourceRegistrations,
                                hseOperationSafetyCases = hseOperationSafetyCases,
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
        public async Task<object> GetSBU_Report_Old(int appID)
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
                        var getStaffSBU = (from stf in _context.staff
                                           join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                           join record in _context.SBU_Records on stf.Staff_SBU equals record.SBU_Id
                                           where stf.StaffEmail == WKPCompanyEmail
                                           select record).ToList();
                        //var context = new WKP_DBContext();
                        if (getStaffSBU.Count() > 0)
                        {
                            foreach (var record in getStaffSBU)
                            {

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

                    return (report);

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
