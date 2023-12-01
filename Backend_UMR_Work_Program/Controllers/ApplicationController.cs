using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Rotativa.AspNetCore;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text.RegularExpressions;
using WKP.Application.Application.Commands.OpenApplication;
using WKP.Application.Application.Commands.PushApplicationCommand;
using WKP.Application.Application.Queries.GetDashboardData;
using WKP.Application.Application.Queries.GetProcessingApplications;
using WKP.Application.Application.Queries.GetProcessingAppsOnMyDesk;
using WKP.Application.Features.Application.Commands.ApproveApplication;
using WKP.Application.Features.Application.Commands.MoveApplication;
using WKP.Application.Features.Application.Commands.RejectApplication;
using WKP.Application.Features.Application.Commands.ReturnAppToStaff;
using WKP.Application.Features.Application.Commands.SendBackApplicationToCompany;
using WKP.Application.Features.Application.Commands.SubmitApplication;
using WKP.Application.Features.Application.Queries.GetAllApplications;
using WKP.Application.Features.Application.Queries.GetAllApplicationsCompany;
using WKP.Application.Features.Application.Queries.GetAllApprovals;
using WKP.Application.Features.Application.Queries.GetAllAppsScopedToSBU;
using WKP.Application.Features.Application.Queries.GetAllRejections;
using WKP.Application.Features.Application.Queries.GetReturnedApplications;
using WKP.Application.Features.Application.Queries.GetStaffDesksByStaffID;
using WKP.Application.Features.Application.Queries.GetStaffsAppInfoWithSBURoleId;
using WKP.Contracts.Application;
using WKP.Contracts.Features.Application;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]

    public class ApplicationController : BaseController
    {
        public readonly ISender _mediator;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AppProcessFlowService _appProcessFlowService;
        private readonly ApplicationService _applicationService;
        private readonly HelperService _helperService;
        private readonly AppSettings _appSettings;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);
        private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        public ApplicationController(
            WKP_DBContext context, 
            IConfiguration configuration, 
            IMapper mapper, 
            IOptions<AppSettings> appsettings,
            ApplicationService applicationService,
            AppProcessFlowService appProcessFlowService,
            HelperService helperService,
            ISender mediator
            )
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _appProcessFlowService = appProcessFlowService;
            _applicationService = applicationService;
            _helperService = helperService;
            _appSettings = appsettings.Value;
            _mediator = mediator;
        }


        [HttpGet("GetDashboardData")]
        public async Task<IActionResult> GetDashboardData() 
        {
            var query = _mapper.Map<GetDashboardDataQuery>(new GetDashboardDataRequest((int)WKPCompanyNumber));
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GetProcessingApplications/staffId")] //For general application view
        public async Task<IActionResult> GetProcessingApplicationsByStaffId(GetProcessingApplicationsByStaffIdRequest request)
        {
            var query = _mapper.Map<GetProcessingApplicationsByStaffIdQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GetProcessingApplicationsOnMyDesk")] //For general application view
        public async Task<IActionResult> GetProcessingApplicationsOnMyDesk()
        {
            var query = _mapper.Map<GetProcessingAppsOnMyDeskQuery>(new GetProcessingAppsOnMyDeskQuery(WKPCompanyEmail));
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("OpenApplication")]
        public async Task<IActionResult> OpenApplication(OpenApplicationRequest request)
        {
            var command = _mapper.Map<OpenApplicationCommand>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpPost("PushApplication")]
        public async Task<IActionResult> PushApplication([FromBody] PushApplicationRequest request)
        {
            var command = _mapper.Map<PushApplicationCommand>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpGet("GetAllApplications")]
        public async Task<IActionResult> GetAllApplications(GetAllApplicationsRequest request)
        {
            var query = _mapper.Map<GetAllApplicationsQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GetAllApplicationsCompany")]
        public async Task<IActionResult> GetAllApplicationsCompany()
        {
            var query = _mapper.Map<GetAllApplicationsCompanyQuery>(new GetAllApplicationsCompanyRequest((int)WKPCompanyNumber));
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GetReturnedApplications")]
        public async Task<object> GetReturnedApplications()
        {
            var query = _mapper.Map<GetReturnedApplicationsQuery>(new GetReturnedApplicationsRequest((int)WKPCompanyNumber));
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpPost("SUBMIT_APPLICATION")]
        public async Task<IActionResult> SubmitApplication(SubmitApplicationRequest request) 
        {
            var command = _mapper.Map<SubmitApplicationCommand>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpPost("RETURN_APPLICATION_TO_STAFF")]
        public async Task<IActionResult> ReturnApplicationToStaff(int deskID, string comment, int[] selectedApps, int[] SBU_IDs, int[] selectedTables, bool fromWPAReviewer)
        {
            var request = new ReturnAppToStaffRequest(deskID, comment, selectedApps, SBU_IDs, selectedTables, fromWPAReviewer, (int)WKPCompanyNumber);
            var command = _mapper.Map<ReturnAppToStaffCommand>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpPost("SendBackApplicationToCompany")]
        public async Task<IActionResult> SendBackApplicationToCompany(
            [FromBody] SendBackApplicationToCompanyRequest request)
        {
            var requestTemp = new SendBackApplicationToCompanyRequest(
                request.DeskID, 
                request.Comment, 
                request.SelectedApps, 
                request.SelectedTables, 
                request.TypeOfPaymentId, 
                request.AmountNGN, 
                request.AmountUSD, 
                (int)WKPCompanyNumber, 
                WKPCompanyEmail);
            var command = _mapper.Map<SendBackApplicationToCompanyCommand>(requestTemp);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpGet("GetAllApplicationsScopedToSBU")]
        public async Task<IActionResult> GetAllApplicationsScopedToSBU()
        {
            var request = new GetAllAppsScopedToSBURequest((int)WKPCompanyNumber);
            var query = _mapper.Map<GetAllAppsScopedToSBUQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpPost("ApproveApplication")]
        public async Task<IActionResult> ApproveApplication(int AppId)
        {
            var request = new ApproveApplicationRequest(AppId, WKPCompanyEmail);
            var command = _mapper.Map<ApproveApplicationCommand>(request);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpGet("GetStaffsAppInfoWithSBURoleId")]
        public async Task<IActionResult> GetStaffsAppInfoWithSBURoleId(GetStaffsAppInfoWithSBURoleIdRequest request)
        {
            var query = _mapper.Map<GetStaffsAppInfoWithSBURoleIdQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GetStaffDesksByStaffID")]
        public async Task<IActionResult> GetAppsOnMyDeskByStaffID(GetStaffDesksByStaffIDRequest request)
        {
            var query = _mapper.Map<GetStaffDesksByStaffIDQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpPost("MoveApplication")]
        public async Task<IActionResult> MoveApplication(MoveApplicationRequest request)
        {
            var query = _mapper.Map<MoveApplicationCommand>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpPost("RejectApplication")]
        public async Task<IActionResult> RejectApplication([FromBody] RejectApplicationRequest request)
        {
            var request1 = new RejectApplicationRequest(request.AppId, WKPCompanyEmail, request.Comment);
            var command = _mapper.Map<RejectApplicationCommand>(request1);
            var result = await _mediator.Send(command);
            return Response(result);
        }

        [HttpGet("GetAllApprovals")]
        public async Task<IActionResult> GetAllApprovals(GetAllApprovalsRequest request)
        {
            var query = _mapper.Map<GetAllApprovalsQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        [HttpGet("GetAllRejections")]
        public async Task<IActionResult> GetAllRejections(GetAllRejectionsRequest request)
        {
            var query = _mapper.Map<GetAllRejectionsQuery>(request);
            var result = await _mediator.Send(query);
            return Response(result);
        }

        //Rework
        [HttpGet("GetAppsOnMyDesk")]
        public async Task<object> GetAppsOnMyDesk() => await _applicationService.GetAppsOnMyDesk((int)WKPCompanyNumber);

        [HttpGet("All-Companies")]
        public async Task<object> AllCompanies() => await _applicationService.AllCompanies(WKPCompanyEmail);

        [HttpGet("GetProcessingApplications")]
        public async Task<WebApiResponse> GetCompanyProcessingApplications() => await _applicationService.GetCompanyProcessingApplications((int)WKPCompanyNumber);

        [HttpGet("GetSentBackApplications")]
        public async Task<object> GetSentBackApplications() => await _applicationService.GetSentBackApplications((int)WKPCompanyNumber);

        [HttpPost("ADD_COMMENT_BY_COMPANY")]
        public async Task<WebApiResponse> ADD_COMMENT_BY_COMPANY([FromBody] AddCommentByCompanyRequest request)
        {
            return await _applicationService.AddCommentToApplication(request.appId, request.staffId, APPLICATION_HISTORY_STATUS.AddedComment, request.comment, request.selectedTables, true, WKPCompanyNumber, true);
        }

        [HttpPost("ADD_COMMENT_BY_STAFF")]
        public async Task<WebApiResponse> ADD_COMMENT_BY_STAFF([FromBody] AddCommentByStaffRequest request)
        {
            return await _applicationService.AddCommentToApplication(request.appId, request.staffId, APPLICATION_HISTORY_STATUS.AddedComment, request.comment, request.selectedTables, false, WKPCompanyNumber, request.isPublic);
        }

        [HttpGet("GET_SENDBACK_COMMENTS")]
        public async Task<WebApiResponse> GET_SENDBACK_COMMENTS(int appId, bool isPublic) => await _applicationService.GetReturnToCompanyComments(appId, isPublic);

        [HttpGet("Rejected-Applications")]
        public async Task<WebApiResponse> AllApplications() => await _applicationService.RejectedApplications();

        [HttpGet("GET_ACCOUNT_DESK")]
        public async Task<WebApiResponse> GetAccountDesk() => await _applicationService.GetAccountDesk(WKPCompanyEmail);

        [HttpGet("IS_APPLICATION_RETURNED")]
        public async Task<WebApiResponse> IsApplicationReturned(int appId) => await _applicationService.IsApplicationReturned(appId);

        [HttpPost("RESUBMIT_APPLICATION_WITHOUT_FEE")]
        public async Task<WebApiResponse> ReSubmitApplicationWithoutFee(int? concessionId, int? fieldId)
        {
            return await _applicationService.ReSubmitApplicationWithoutFee(concessionId, fieldId);
        }

        [HttpGet("GetLockForms")]
        public async Task<WebApiResponse> GetLockForms(int year, int concessionId, int fieldId) => await _applicationService.LockForms(year, concessionId, fieldId);

        //Rework
        [HttpGet("All-Applications")] //For general application view
        public async Task<object> RejectedApplications()
        {
            try
            {
                var applications = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          //join field in _context.COMPANY_FIELDs on app.FieldID equals field.Field_ID
                                          join con in _context.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          where app.DeleteStatus != true && app.Status == MAIN_APPLICATION_STATUS.Rejected
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

        //Rework
        [HttpGet("CompanyRejectedApplications")] //For general application view
        public async Task<object> CompanyRejectedApplications()
        {
            try
            {
                var applications = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join appHistory in _context.ApplicationDeskHistories on app.Id equals appHistory.AppId
                                          join stf in _context.staff on appHistory.StaffID equals stf.StaffID
                                          join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                          where app.DeleteStatus != true && appHistory.Status == MAIN_APPLICATION_STATUS.Rejected
                                          && app.CompanyID == WKPCompanyNumber
                                          select new
                                          {
                                              Last_SBU = sbu.SBU_Name,
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                              FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              SBU_Comment = appHistory.Comment,
                                              Comment = appHistory.Comment,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              SBU_Tables = appHistory.SelectedTables,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        //Rework
        [HttpGet("GetApprovedApplications")]
        public async Task<object> GetApprovedApplications()
        {
            try
            {
                var applications = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          where app.DeleteStatus != true && app.Status == MAIN_APPLICATION_STATUS.ApprovedByFinalApprovingAuthority && app.CompanyID == WKPCompanyNumber
                                          select new
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                              FieldName = app.FieldID != null ? _context.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
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

        //Rework
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
                                    where app.DeleteStatus != true && cmt.ActionStatus == GeneralModel.PROCESS_CONSTANTS.Initiated
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

        //Rework
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

        //Rework
        [HttpGet("ProcessApplication")] //For processing application view
        public async Task<object> ProcessApplication(int appID)
        {
            try
            {
                // var application = (from ap in _context.Applications where ap.Id == appID && ap.DeleteStatus != true select ap).FirstOrDefault();

                var application = await _context.Applications
                            .Include(x => x.Company)
                            .Include(x => x.Concession)
                            .Include(x => x.Field)
                            .Where(ap => ap.Id == appID && ap.DeleteStatus != true).FirstOrDefaultAsync();

                if (application == null)
                    return BadRequest(new { message = "Sorry, this application details could not be found." });

                // var field = await _context.COMPANY_FIELDs.Where(x => x.Field_ID == application.FieldID).FirstOrDefaultAsync();
                // var concession = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == application.ConcessionID).FirstOrDefaultAsync();
                // var company = await _context.ADMIN_COMPANY_INFORMATIONs.Where(x => x.Id == application.CompanyID).FirstOrDefaultAsync();

                var companyDetails = await _context.ADMIN_COMPANY_DETAILs.Where(x => x.EMAIL == application.Company.EMAIL).FirstOrDefaultAsync();

                var appHistory = await _context.ApplicationDeskHistories.Include(x => x.Staff).ThenInclude(x => x.StrategicBusinessUnit).Include(x => x.Company).Where(x => x.AppId == appID)
                                    .Select(x => new
                                    {
                                        ID = x.Id,
                                        Staff_Name = x.Staff != null ? x.Staff.LastName + ", " + x.Staff.FirstName : "",
                                        Staff_Email = x.Staff != null ? x.Staff.StaffEmail : "",
                                        // Staff = x.Staff,
                                        // Staff_SBU = x.Staff != null ? _context.StrategicBusinessUnits.Where(s => s.Id == x.Staff.Staff_SBU).FirstOrDefault().SBU_Name : "",
                                        Staff_SBU = x.Staff != null ? x.Staff.StrategicBusinessUnit.SBU_Name: null,
                                        // Staff_SBUID = _context.StrategicBusinessUnits.Where(s => s.Id == x.Staff.Staff_SBU).FirstOrDefault().Id,
                                        Staff_SBUID = x.Staff != null? x.Staff.Staff_SBU: null,
                                        Staff_Role = x.Staff != null? _context.Roles.Where(r => r.id == x.Staff.RoleID).FirstOrDefault().RoleName: "",
                                        Comment = x.Comment,
                                        Date = x.ActionDate,
                                        ActionByCompany = x.ActionByCompany,
                                        Company = x.Company,
                                        CompanyDetails = companyDetails,
                                        Status = x.Status,
                                        Action = x.AppAction,
                                        SelectedTables = x.SelectedTables,
                                    })
                                    .ToListAsync();

                var currentDesks = await (from dsk in _context.MyDesks
                                       join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                       join rol in _context.Roles on stf.RoleID equals rol.id
                                       join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                       where dsk.HasWork == true && dsk.AppId == appID && stf.ActiveStatus != false && stf.DeleteStatus != true
                                       select new 
                                       {
                                           Desk_ID = dsk.DeskID,
                                           Staff_Name = stf.LastName + ", " + stf.FirstName,
                                           Staff_Email = stf.StaffEmail,
                                           Staff_SBU = sbu.SBU_Name,
                                           Staff_Role = rol.RoleName,
                                           deskStatus = dsk.ProcessStatus,
                                           internalStatus = dsk.ProcessStatus,
                                           SBU_Code = sbu.SBU_Code
                                       }).ToListAsync();

                var staffDesk = await (from dsk in _context.MyDesks
                                       join stf in _context.staff on dsk.StaffID equals stf.StaffID
                                       join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                       join rol in _context.Roles on stf.RoleID equals rol.id
                                       join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                       where admin.Id == WKPCompanyNumber && dsk.AppId == appID && stf.ActiveStatus != false && stf.DeleteStatus != true
                                          select new
                                       {
                                           Desk_ID = dsk.DeskID,
                                           Staff_Name = stf.LastName + ", " + stf.FirstName,
                                           Staff_Email = stf.StaffEmail,
                                           Staff_SBU = sbu.SBU_Name,
                                           Staff_Role = rol.RoleName,
                                           StaffID = stf.StaffID,
                                           internalStatus = dsk.ProcessStatus
                                       }).ToListAsync();

                // var staffs = await _context.staff.ToListAsync();

                // var documents = await _context.SubmittedDocuments.Where(x => x.CreatedBy == application.CompanyID.ToString() && x.YearOfWKP == application.YearOfWKP).Take(10).ToListAsync();

                var getStaffSBU = (from stf in _context.staff
                                   join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                   where stf.StaffEmail == WKPCompanyEmail
                                   select sbu).FirstOrDefault();

                var getSBU_TablesToDisplay = await _context.Table_Details.Where(x => x.SBU_ID.Contains(getStaffSBU.Id.ToString())).ToListAsync();

                var selectedTables = appHistory.Find(x => x.Staff_SBUID == getStaffSBU.Id);

                var sbuApprovals = new List<ApplicationSBUApproval>();
                
                if(getStaffSBU.Tier == 2 && appID != null)
                {
                    sbuApprovals = await _context.ApplicationSBUApprovals.Include(x => x.Staff).Where(x => x.AppId == appID).ToListAsync();
                }
                else
                {
                    sbuApprovals = null;
                }

                var appDetails = new 
                {
                    Application = application,
                    // Field = application.Field,
                    // Concession = application.Concession,
                    // Company = application.Company,
                    CompanyDetails = companyDetails,
                    Staff = staffDesk,
                    currentDesks = currentDesks,
                    Application_History = appHistory.OrderByDescending(x => x.ID).ToList(),
                    // Document = documents,
                    SBU_TableDetails = getSBU_TablesToDisplay,
                    SBU = await _context.StrategicBusinessUnits.ToListAsync(),
                    SBUApprovals = sbuApprovals,
                    // staffs = staffs,
                    staffDesk = staffDesk.FirstOrDefault(),
                    StaffSBU = getStaffSBU,
                };

                return new WebApiResponse { Data = appDetails, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }


        // [HttpPost("ApproveApplication")]
        // public async Task<object> ApproveApplication(int deskID, string comment, string[] selectedApps)
        // {
        //     var responseMessage = "";
        //     try
        //     {
        //         foreach (var b in selectedApps)
        //         {
        //             string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
        //             int appId = int.Parse(appID);
        //             //get current staff desk
        //             var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();

        //             var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();

        //             var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();

        //             var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();

        //             //Update Staff Desk
        //             staffDesk.HasPushed = true;
        //             staffDesk.HasWork = true;
        //             staffDesk.UpdatedAt = DateTime.Now;
        //             application.Status = GeneralModel.Approved;
        //             _context.SaveChanges();

        //             var p = _helpersController.CreatePermit(application);

        //             responseMessage += "You have APPROVED this application (" + application.ReferenceNo + ")  and approval has been generated. Approval No: " + p + Environment.NewLine;
        //             //var staff = _context.staff.Where(x => x.StaffID == int.Parse(WKPCompanyId) && x.DeleteStatus != true).FirstOrDefault();
        //             var staff = (from stf in _context.staff
        //                          join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
        //                          where stf.StaffID == int.Parse(WKPCompanyId) && stf.DeleteStatus != true
        //                          select stf).FirstOrDefault();

        //             if (!p.ToLower().Contains("error"))
        //             {

        //                 //string body = "";
        //                 //var up = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        //                 //string file = up + @"\\Templates\" + "InternalMemo.txt";
        //                 //using (var sr = new StreamReader(file))
        //                 //{
        //                 //    body = sr.ReadToEnd();
        //                 //}

        //                 //send email to staff approver
        //                 //_helpersController.SaveHistory(appId, staff.StaffID, GeneralModel.Approved, staff.StaffEmail + "Final Approval For Application With Ref: " + application.ReferenceNo, null);
        //                 _helperService.SaveApplicationHistory(application.Id, staff.StaffID, GeneralModel.Approved, staff.StaffEmail + "Final Approval For Application With Ref: " + application.ReferenceNo, null, false, null, GeneralModel.Approve);

        //                 string subject = $"Approval For Application With REF: {application.ReferenceNo}";
        //                 string content = $"An approval has been generated for application with reference: " + application.ReferenceNo + " for " + field.Field_Name + "(" + Company.NAME + ").";

        //                 var emailMsg = _helpersController.SaveMessage(appId, staff.StaffID, subject, content, "Staff");
        //                 var sendEmail = _helpersController.SendEmailMessage(staff.StaffEmail, staff.FirstName, emailMsg, null);

        //                 _helpersController.LogMessages("Approval generated successfully for field => " + field.Field_Name + ". Application Reference : " + application.ReferenceNo, WKPCompanyEmail);

        //                 responseMessage = "Application(s) has been approved and permit approval generated successfully.";
        //             }
        //             else
        //             {
        //                 responseMessage += "An error occured while trying to generate approval ref for this application." + Environment.NewLine;

        //                 //Update My Process
        //                 staffDesk.HasPushed = false;
        //                 staffDesk.HasWork = false;
        //                 staffDesk.UpdatedAt = DateTime.Now;
        //                 _context.SaveChanges();
        //             }
        //             return BadRequest(new { message = responseMessage });
        //         }
        //         return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMessage, StatusCode = ResponseCodes.Success };
        //     }
        //     catch (Exception x)
        //     {
        //         _helpersController.LogMessages($"Approve Error:: {x.ToString()}");
        //         return BadRequest(new { message = $"An error occured while approving application(s)." });
        //     }

        // }



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

                var processActions = new string[] { PROCESS_CONSTANTS.Submit, 
                                    PROCESS_CONSTANTS.Reject, PROCESS_CONSTANTS.Approve, 
                                    PROCESS_CONSTANTS.Push, PROCESS_CONSTANTS.ApprovedByEC, 
                                    PROCESS_CONSTANTS.Delegate, PROCESS_CONSTANTS.FinalApproval };

                var processStatuses = new string[] { MAIN_APPLICATION_STATUS.Processing, 
                                    MAIN_APPLICATION_STATUS.SubmittedByCompany, 
                                    MAIN_APPLICATION_STATUS.Rejected, 
                                    MAIN_APPLICATION_STATUS.Approved,
                                    MAIN_APPLICATION_STATUS.ApprovedByFinalApprovingAuthority,
                                    MAIN_APPLICATION_STATUS.ApprovedByFinalAuthority};
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
                                            Step = tab.Step,
                                            Section = tab.Section,
                                            SubSection = tab.SubSection,
                                            TableSchema = tab.TableSchema,
                                            Role = tab.TableSchema,
                                            SBU = sbu.SBU_Name,
                                            SBU_ID = sbu.Id
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
        public async Task<object> CreateSBU_Tables(int sbuID, string Step, string Section, string SubSection, string TableSchema)
        {
            try
            {
                if (Step == null || Section == null || SubSection == null || sbuID <= 0 || TableSchema == null)
                {
                    return BadRequest(new { message = $"Error : Table name/schema/SBU ID was not passed correctly." });
                }

                var SBU_Tables = await (from tab in _context.Table_Details
                                        where tab.SubSection.ToLower() == SubSection.ToLower() && tab.TableSchema.ToLower() == TableSchema.ToLower() && tab.SBU_ID == sbuID.ToString()/*tab.SBU_ID.Contains(sbuID.ToString())*/
                                        select tab).FirstOrDefaultAsync();
                if (SBU_Tables != null)
                {
                    return BadRequest(new { message = $"Error : This table is already existing for this SBU and can not be duplicated." });
                }
                else
                {
                    var nSBU_Tables = new Table_Detail()
                    {
                        Step = Step,
                        Section = Section,
                        SubSection = SubSection,
                        TableName = null,
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
                                                       table = tab,
                                                       Role = tab.TableSchema,
                                                       SBU = sbu.SBU_Name,
                                                       SBU_ID = sbu.Id
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
        public async Task<object> EditSBU_Tables(int id, int sbuID, string Step, string Section, string SubSection, string TableSchema)
        {
            try
            {
                if (Step == null || Section == null || SubSection == null || id <= 0 || sbuID <= 0 || TableSchema == null)
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

                    SBU_Tables.Step = Step;
                    SBU_Tables.Section = Section;
                    SBU_Tables.SubSection = SubSection;
                    SBU_Tables.TableName = null;
                    SBU_Tables.TableSchema = TableSchema;
                    SBU_Tables.SBU_ID = sbuID.ToString();

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var AllSBU_Tables = await (from tab in _context.Table_Details
                                                   join sbu in _context.StrategicBusinessUnits on tab.SBU_ID equals sbu.Id.ToString()
                                                   select new
                                                   {
                                                       Id = tab.TableId,
                                                       table = tab,
                                                       Role = tab.TableSchema,
                                                       SBU = sbu.SBU_Name,
                                                       SBU_ID = sbu.Id
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
                                                       SBU = sbu.SBU_Name,
                                                       SBU_ID = sbu.Id
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
                    int? fieldID = null;
                    if (application.FieldID != null)
                    {
                        fieldID = (int)application.FieldID;
                    }

                    var getStaffSBU = (from stf in _context.staff
                                       join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                       where stf.StaffEmail == WKPCompanyEmail
                                       //"franlin.wagbara@brandonetech.com"
                                       select sbu).FirstOrDefault();

                    var staff = await _context.staff.Where(x => x.StaffEmail == WKPCompanyEmail).FirstOrDefaultAsync();
                    var staffRole = await _context.Roles.Where(x => x.id == staff.RoleID).FirstOrDefaultAsync();

                    string year = application.YearOfWKP.ToString();

                    if(staffRole.RoleName == ROLE.ExecutiveCommissioner || staffRole.RoleName == ROLE.FinalAuthority)
                    {
                        var _geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                        var _geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                        var _drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                        var _capexOpexItems = await (from d in _context.BUDGET_CAPEX_OPices where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                        var _budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                        var _royalty = await (from d in _context.Royalties where d.CompanyNumber == application.CompanyID && d.Concession_ID == application.ConcessionID && d.Field_ID == fieldID && d.Year == year select d).FirstOrDefaultAsync();
                        var _BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).ToListAsync();
                        var _BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).ToListAsync();

                        var _geoActivitiesAcquisitions = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                        var _geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                        var __concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();

                        var _categoriesProposedWells = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                        var _geophysicalActivities = await (from c in _context.Geophysical_Activities where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                        var _sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _mOUInformation = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _scholarshipSchemes = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _picturesCommunityDevelopmentProjects = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _trainingDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var __strategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _NigeriaContentUploadSuccession = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

                        var _LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

                        var _facilitiesProjectPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _conformityAssuranceAssetIntegrity = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _facilityDevelopmentProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).ToListAsync();
                        var _concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).ToListAsync();
                        var _wellType_oil = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _wellType_gas = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _expectedReserves = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                        var _OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        var _OilCondensateProductionMonthly = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _OilCondensateProductionMonthlyProposed = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _fiveYearProd = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        var ___concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();


                        var _HSERequirement = await (from c in _context.HSE_MinimumRequirements where c.CompanyNumber == application.CompanyID && c.Year.ToString() == year select c).ToListAsync();
                        var _HSEQuestion = await (from c in _context.HSE_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEFatality = await (from c in _context.HSE_FATALITIEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEDesignSafety = await (from c in _context.HSE_DESIGNS_SAFETies where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEInspectionMaintenance = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEInspectionMaintenanceFacility = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSESafetyStudies = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                        var _HSEAssetRegister = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEOilSpill = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEAssetRegisterRBI = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                        var _HSEAccidentIncidence = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEAccidentIncidenceType = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _accidentModel = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                                    join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                                    where a1.CompanyNumber == application.CompanyID && a1.Year_of_WP == year
                                                    && a1.Field_ID == application.FieldID
                                                    && a2.Field_ID == application.FieldID
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
                                                    }).ToListAsync();

                        var _HSECommunityDisturbance = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEEnvironmentalStudies = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEWasteManagementType = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEProducedWaterMgt = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEEnvironmentalCompliance = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();


                        var _HSEEnvironmentalFiveYears = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSESustainableDev = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEEnvironmentalStudiesUpdated = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEOSPRegistrations = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEProducedWaterMgtUpdated = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEEnvironmentalComplianceChemical = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSECausesOfSpill = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSESustainableDevMOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                        var _HSESustainableDevProgramCsr = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                        var _HSESustainableDevScheme = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEManagementPosition = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEQualityControl = await (from c in _context.HSE_QUALITY_CONTROLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEClimateChange = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEWasteManagementSystems = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEEnvironmentalManagementSystems = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseEffluentCompliances = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseWasteManagementDZs = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hsePointSourceRegistrations = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();


                        return new
                        {
                            geoActivitiesAcquisition = _geoActivitiesAcquisition,
                            geoActivitiesProcessing = _geoActivitiesProcessing,
                            drillOperationCategoriesWell = _drillOperationCategoriesWell,
                            capexOpexItems = _capexOpexItems,
                            budgetProposalNairaDollar = _budgetProposalNairaDollar,
                            royalty = _royalty,
                            budgetCapex = _BudgetCapex,
                            budgetOpex = _BudgetOpex,

                            categoriesProposedWells = _categoriesProposedWells,
                            geoActivitiesAcquisitions = _geoActivitiesAcquisitions,
                            geoActivitiesProcessings = _geoActivitiesProcessings,
                            concessionSituations = __concessionSituations,
                            geoPhysical = _geophysicalActivities,
                            concessionSituation = __concessionSituations,
                         
                            NigeriaContentUploadSuccession = _NigeriaContentUploadSuccession,
                            _strategicPlans = __strategicPlans,
                            seniorManagementStaff = _seniorManagementStaff,
                            staffDisposition = _staffDisposition,
                            picturesCommunityDevelopmentProjects = _picturesCommunityDevelopmentProjects,
                            trainingDetails = _trainingDetails,
                            trainingsSkillAcquisition = _trainingsSkillAcquisition,
                            scholarshipSchemes = _scholarshipSchemes,
                            scholarships = _scholarships,
                            capitalProjects = _capitalProjects,
                            projectDetails = _projectDetails,
                            mOUInformation = _mOUInformation,
                            sustainableDevelopmentCommunityProjectProgram = _sustainableDevelopmentCommunityProjectProgram,

                            LegalLitigation = _LegalLitigation,
                            LegalArbitration = _LegalArbitration,

                            strategicPlans = __strategicPlans,
                            facilitiesProjectPerformance = _facilitiesProjectPerformance,
                            conformityAssuranceAssetIntegrity = _conformityAssuranceAssetIntegrity,
                            facilityDevelopmentProjects = _facilityDevelopmentProjects,
                            lifeIndex_years = _lifeIndex_years,
                            depletionRate = _depletionRate,
                            fiveYearTrendConcessionReserveReplacementRatio = _fiveYearTrendConcessionReserveReplacementRatio,
                            reserveDecline = _reserveDecline,
                            reserveAddition = _reserveAddition,
                            fiveYearReservesProjection = _fiveYearReservesProjection,
                            concessionReservesPrecedingYearJanuary = _concessionReservesPrecedingYearJanuary,
                            reservesUpdateConcessionReservesJanuary = _reservesUpdateConcessionReservesJanuary,
                            wellType_oil = _wellType_oil,
                            wellType_gas = _wellType_gas,
                            workoverRecompletionJobsQuaterlyBasis = _workoverRecompletionJobsQuaterlyBasis,
                            initialWellCompletionJobsQuaterlyBasis = _initialWellCompletionJobsQuaterlyBasis,
                            unitization = _unitization,
                            expectedReserves = _expectedReserves,
                            fieldDevelopmentPlan = _fieldDevelopmentPlan,

                            OilCondensateProduction = _OilCondensateProduction,
                            OilCondensateProductionMonthly = _OilCondensateProductionMonthly,
                            OilCondensateProductionMonthlyProposed = _OilCondensateProductionMonthlyProposed,
                            OilCondensateFiveYears = _OilCondensateFiveYears,
                            fiveYearProductionForcast = _fiveYearProd,


                            HSERequirement = _HSERequirement,
                            HSETechnicalSafety = _HSETechnicalSafety,
                            HSESafetyStudies = _HSESafetyStudies,
                            HSEQualityControl = _HSEQualityControl,
                            HSEInspectionMaintenance = _HSEInspectionMaintenance,
                            HSEAssetRegister = _HSEAssetRegister,
                            HSEOilSpill = _HSEOilSpill,
                            HSECausesOfSpill = _HSECausesOfSpill,
                            HSEAssetRegisterRBI = _HSEAssetRegisterRBI,
                            HSEAccidentModel = _accidentModel,
                            HSEAccidentIncidence = _HSEAccidentIncidence,
                            HSEOSPRegistrations = _HSEOSPRegistrations,
                            HSEAccidentIncidenceType = _HSEAccidentIncidenceType,
                            HSECommunityDisturbance = _HSECommunityDisturbance,
                            HSESustainableDevProjProgramCsr = _HSESustainableDevProgramCsr,

                            HSEQuestion = _HSEQuestion,
                            HSEFatality = _HSEFatality,
                            HSEDesignSafety = _HSEDesignSafety,
                            HSEInspectionMaintenanceFacility = _HSEInspectionMaintenanceFacility,
                            HSEEnvironmentalStudies = _HSEEnvironmentalStudies,
                            HSEWasteManagement = _HSEWasteManagement,
                            HSEWasteManagementType = _HSEWasteManagementType,
                            HSEProducedWaterMgt = _HSEProducedWaterMgt,
                            HSEEnvironmentalCompliance = _HSEEnvironmentalCompliance,
                            HSEEnvironmentalFiveYears = _HSEEnvironmentalFiveYears,
                            HSEEnvironmentalStudiesUpdated = _HSEEnvironmentalStudiesUpdated,
                            HSEProducedWaterMgtUpdated = _HSEProducedWaterMgtUpdated,
                            HSEEnvironmentalComplianceChemical = _HSEEnvironmentalComplianceChemical,
                            HSEManagementPosition = _HSEManagementPosition,
                            HSEClimateChange = _HSEClimateChange,
                            HSESafetyCulture = _HSESafetyCulture,
                            HSEOccupationalHealth = _HSEOccupationalHealth,
                            HSEWasteManagementSystems = _HSEWasteManagementSystems,
                            HSEEnvironmentalManagementSystems = _HSEEnvironmentalManagementSystems,
                            hseEnvironmentalManagementPlans = _hseEnvironmentalManagementPlans,
                            hseRemediationFunds = _hseRemediationFunds,
                            hseWasteManagementDZs = _hseWasteManagementDZs,
                            hseEffluentCompliances = _hseEffluentCompliances,
                            hseGHGManagementPlans = _hseGHGManagementPlans,
                            hseHostCommunitiesDevelopments = _hseHostCommunitiesDevelopments,
                            hsePointSourceRegistrations = _hsePointSourceRegistrations,
                            hseOperationSafetyCases = _hseOperationSafetyCases,

                        };
                    }

                    switch (getStaffSBU.SBU_Code)
                    {

                        case "ER&SP": //Work Programme

                            var geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var capexOpexItems = await (from d in _context.BUDGET_CAPEX_OPices where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                            var budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                            var royalty = await (from d in _context.Royalties where d.CompanyNumber == application.CompanyID && d.Concession_ID == application.ConcessionID && d.Field_ID == fieldID && d.Year == year select d).FirstOrDefaultAsync();

                            var BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).ToListAsync();
                            var BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).ToListAsync();

                            var ___hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                            var ___hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();


                            return new
                            {
                                geoActivitiesAcquisition = geoActivitiesAcquisition,
                                geoActivitiesProcessing = geoActivitiesProcessing,
                                drillOperationCategoriesWell = drillOperationCategoriesWell,
                                capexOpexItems = capexOpexItems,
                                budgetProposalNairaDollar = budgetProposalNairaDollar,
                                royalty = royalty,
                                budgetCapex = BudgetCapex,
                                budgetOpex = BudgetOpex,
                                hseEnvironmentalManagementPlans = ___hseEnvironmentalManagementPlans,
                                hseRemediationFunds = ___hseRemediationFunds
                            };

                        case "E&AM": //Planning ER&SP
                            var geoActivitiesAcquisitions = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year == year select d).ToListAsync();

                            //var BudgetCapexOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var categoriesProposedWells = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                            //var drillingOperations = await (from c in _context.Drilling_Operations where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var geophysicalActivities = await (from c in _context.Geophysical_Activities where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            return new
                            {
                                categoriesProposedWells = categoriesProposedWells,
                                geoActivitiesAcquisitions = geoActivitiesAcquisitions,
                                geoActivitiesProcessings = geoActivitiesProcessings,
                                concessionSituations = concessionSituations,
                                //drillingOperations = drillingOperations,
                                geoPhysical = geophysicalActivities,
                                concessionSituation = concessionSituations,
                                //budgetPerformance = budgetPerformance
                            };

						case "CS&A":

                            var sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var mOUInformation = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var scholarshipSchemes = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var trainingDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var picturesCommunityDevelopmentProjects = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _strategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var NigeriaContentUploadSuccessions = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

                            return new
                            {
                                successPlans = NigeriaContentUploadSuccessions,
                                NigeriaContentUploadSuccession = NigeriaContentUploadSuccessions,
                                _strategicPlans = _strategicPlans,
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
                           

                        case "LGL": //Legal

                            var LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            return new
                            {
                                LegalLitigation = LegalLitigation,
                                LegalArbitration = LegalArbitration
                            };



                        case "D&P": //SBU
                            var strategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var facilitiesProjectPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var conformityAssuranceAssetIntegrity = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var facilityDevelopmentProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).ToListAsync();
                            var concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).ToListAsync();
                            var wellType_oil = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var wellType_gas = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var expectedReserves = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _categoriesProposedWell = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();

                            var OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var OilCondensateProductionMonthly = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var OilCondensateProductionMonthlyProposed = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearProd = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();

                            return new
                            {
                                strategicPlans = strategicPlans,
                                facilitiesProjectPerformance = facilitiesProjectPerformance,
                                conformityAssuranceAssetIntegrity = conformityAssuranceAssetIntegrity,
                                facilityDevelopmentProjects = facilityDevelopmentProjects,
                                lifeIndex_years = lifeIndex_years,
                                depletionRate = depletionRate,
                                fiveYearTrendConcessionReserveReplacementRatio = fiveYearTrendConcessionReserveReplacementRatio,
                                reserveDecline = reserveDecline,
                                reserveAddition = reserveAddition,
                                fiveYearReservesProjection = fiveYearReservesProjection,
                                //concessionSituation = concessionSituations,
                                //fiveYearReservesProjectionTerrain = fiveYearReservesProjection,
                                concessionReservesPrecedingYearJanuary = concessionReservesPrecedingYearJanuary,
                                reservesUpdateConcessionReservesJanuary= reservesUpdateConcessionReservesJanuary,
                                wellType_oil = wellType_oil,
                                wellType_gas = wellType_gas,
                                workoverRecompletionJobsQuaterlyBasis = workoverRecompletionJobsQuaterlyBasis,
                                initialWellCompletionJobsQuaterlyBasis = initialWellCompletionJobsQuaterlyBasis,
                                unitization = unitization,
                                expectedReserves = expectedReserves,
                                fieldDevelopmentPlan = fieldDevelopmentPlan,
                                categoriesProposedWells = _categoriesProposedWell,

                                OilCondensateProduction = OilCondensateProduction,
                                OilCondensateProductionMonthly = OilCondensateProductionMonthly,
                                OilCondensateProductionMonthlyProposed = OilCondensateProductionMonthlyProposed,
                                OilCondensateFiveYears = OilCondensateFiveYears,
                                fiveYearProductionForcast = fiveYearProd,
                                concessionSituations= _concessionSituations
                            };

                        case "HSE&C": //HSE
                            var HSERequirement = await (from c in _context.HSE_MinimumRequirements where c.CompanyNumber == application.CompanyID && c.Year.ToString() == year select c).ToListAsync();
                            var HSEQuestion = await (from c in _context.HSE_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEFatality = await (from c in _context.HSE_FATALITIEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEDesignSafety = await (from c in _context.HSE_DESIGNS_SAFETies where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEInspectionMaintenance = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEInspectionMaintenanceFacility = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSESafetyStudies = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                            var HSEAssetRegister = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEOilSpill = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEAssetRegisterRBI = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                            var HSEAccidentIncidence = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEAccidentIncidenceType = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var accidentModel = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                                       join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                                       where a1.CompanyNumber == application.CompanyID && a1.Year_of_WP == year
                                                       && a1.Field_ID == application.FieldID
                                                       && a2.Field_ID == application.FieldID
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
                                                       }).ToListAsync();

                            var HSECommunityDisturbance = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEEnvironmentalStudies = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEWasteManagementType = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEProducedWaterMgt = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEEnvironmentalCompliance = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();


                            var HSEEnvironmentalFiveYears = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSESustainableDev = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEEnvironmentalStudiesUpdated = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEOSPRegistrations = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEProducedWaterMgtUpdated = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEEnvironmentalComplianceChemical = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSECausesOfSpill = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSESustainableDevMOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                            var HSESustainableDevProgramCsr = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                            var HSESustainableDevScheme = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEManagementPosition = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEQualityControl = await (from c in _context.HSE_QUALITY_CONTROLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEClimateChange = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEWasteManagementSystems = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEEnvironmentalManagementSystems = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseEffluentCompliances = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseWasteManagementDZs = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hsePointSourceRegistrations = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

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

                        case "WPA":
                            var _geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var _geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            //var _drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            //var _drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var _drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.CompanyNumber == application.CompanyID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var _capexOpexItems = await (from d in _context.BUDGET_CAPEX_OPices where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).FirstOrDefaultAsync();
                            var _budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                            var _royalty = await (from d in _context.Royalties where d.CompanyNumber == application.CompanyID && d.Concession_ID == application.ConcessionID && d.Field_ID == fieldID && d.Year == year select d).FirstOrDefaultAsync();
                            var _BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).ToListAsync();
                            var _BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).ToListAsync();
                                
                            var _geoActivitiesAcquisitions = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var _geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var __concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();


                            //var BudgetCapexOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _categoriesProposedWells = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                            //var drillingOperations = await (from c in _context.Drilling_Operations where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _geophysicalActivities = await (from c in _context.Geophysical_Activities where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            //var concessionSituation = await (from c in _context.ConcessionSituations where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            //var _budgetPerformance = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();



                            var _sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _mOUInformation = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _scholarshipSchemes = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _picturesCommunityDevelopmentProjects = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _trainingDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var __strategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _NigeriaContentUploadSuccession = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

                            var _LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

                            var _facilitiesProjectPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _conformityAssuranceAssetIntegrity = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _facilityDevelopmentProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).ToListAsync();
                            var _concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).ToListAsync();
                            var _wellType_oil = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _wellType_gas = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _expectedReserves = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                            var _OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _OilCondensateProductionMonthly = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _OilCondensateProductionMonthlyProposed = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _fiveYearProd = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var ___concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();


                            var _HSERequirement = await (from c in _context.HSE_MinimumRequirements where c.CompanyNumber == application.CompanyID && c.Year.ToString() == year select c).ToListAsync();
                            var _HSEQuestion = await (from c in _context.HSE_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEFatality = await (from c in _context.HSE_FATALITIEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEDesignSafety = await (from c in _context.HSE_DESIGNS_SAFETies where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEInspectionMaintenance = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEInspectionMaintenanceFacility = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSESafetyStudies = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                            var _HSEAssetRegister = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEOilSpill = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEAssetRegisterRBI = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                            var _HSEAccidentIncidence = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEAccidentIncidenceType = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _accidentModel = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                                       join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                                       where a1.CompanyNumber == application.CompanyID && a1.Year_of_WP == year
                                                       && a1.Field_ID == application.FieldID
                                                       && a2.Field_ID == application.FieldID
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
                                                       }).ToListAsync();

                            var _HSECommunityDisturbance = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEEnvironmentalStudies = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEWasteManagementType = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEProducedWaterMgt = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEEnvironmentalCompliance = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                                
                            var _HSEEnvironmentalFiveYears = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSESustainableDev = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEEnvironmentalStudiesUpdated = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEOSPRegistrations = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEProducedWaterMgtUpdated = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEEnvironmentalComplianceChemical = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSECausesOfSpill = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSESustainableDevMOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                            var _HSESustainableDevProgramCsr = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                            var _HSESustainableDevScheme = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEManagementPosition = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEQualityControl = await (from c in _context.HSE_QUALITY_CONTROLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEClimateChange = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEWasteManagementSystems = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEEnvironmentalManagementSystems = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseEffluentCompliances = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseWasteManagementDZs = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hsePointSourceRegistrations = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                                
                                
                            return new
                            {
                                geoActivitiesAcquisition = _geoActivitiesAcquisition,
                                geoActivitiesProcessing = _geoActivitiesProcessing,
                                //drillEachCost = _drillEachCost,
                                //drillEachCostProposed = _drillEachCostProposed,
                                drillOperationCategoriesWell = _drillOperationCategoriesWell,
                                capexOpexItems = _capexOpexItems,
                                budgetProposalNairaDollar = _budgetProposalNairaDollar,
                                royalty = _royalty,
                                budgetCapex = _BudgetCapex,
                                budgetOpex = _BudgetOpex,


                                //PlanningRequirement = _PlanningRequirement,
                                //BudgetActualExpenditure = _BudgetActualExpenditure,
                                //BudgetPerformanceExploratory = _BudgetPerformanceExploratory,
                                //BudgetPerformanceDevelopment = _BudgetPerformanceDevelopment,
                                //BudgetPerformanceProductionCost = _BudgetPerformanceProductionCost,
                                //BudgetPerformanceFacilityDevProjects = _BudgetPerformanceFacilityDevProjects,
                                //BudgetProposalComponents = _BudgetProposalComponents,
                                //BudgetCapex = _BudgetCapex,
                                //BudgetOpex = _BudgetOpex,
                                categoriesProposedWells = _categoriesProposedWells,
                                geoActivitiesAcquisitions = _geoActivitiesAcquisitions,
                                geoActivitiesProcessings = _geoActivitiesProcessings,
                                concessionSituations = __concessionSituations,
                                //drillingOperations = _drillingOperations,
                                geoPhysical = _geophysicalActivities,
                                concessionSituation = __concessionSituations,
                                //budgetPerformance = _budgetPerformance,



                                //HSESustainableDevProgramCsr = _HSESustainableDevProgramCsr_1,
                                //NigeriaContent = _NigeriaContent,
                                //successPlans = _successPlans,
                                //NigeriaContentQuestion = _NigeriaContentQuestion,

                                NigeriaContentUploadSuccession = _NigeriaContentUploadSuccession,
                                _strategicPlans = __strategicPlans,
                                seniorManagementStaff = _seniorManagementStaff,
                                staffDisposition = _staffDisposition,
                                picturesCommunityDevelopmentProjects = _picturesCommunityDevelopmentProjects,
                                trainingDetails = _trainingDetails,
                                trainingsSkillAcquisition = _trainingsSkillAcquisition,
                                scholarshipSchemes = _scholarshipSchemes,
                                scholarships = _scholarships,
                                capitalProjects = _capitalProjects,
                                projectDetails = _projectDetails,
                                mOUInformation = _mOUInformation,
                                sustainableDevelopmentCommunityProjectProgram = _sustainableDevelopmentCommunityProjectProgram,

                                LegalLitigation = _LegalLitigation,
                                LegalArbitration = _LegalArbitration,

                                strategicPlans = __strategicPlans,
                                facilitiesProjectPerformance = _facilitiesProjectPerformance,
                                conformityAssuranceAssetIntegrity = _conformityAssuranceAssetIntegrity,
                                facilityDevelopmentProjects = _facilityDevelopmentProjects,
                                lifeIndex_years = _lifeIndex_years,
                                depletionRate = _depletionRate,
                                fiveYearTrendConcessionReserveReplacementRatio = _fiveYearTrendConcessionReserveReplacementRatio,
                                reserveDecline = _reserveDecline,
                                reserveAddition = _reserveAddition,
                                fiveYearReservesProjection = _fiveYearReservesProjection,
                                //concessionSituation = _concessionSituations,
                                //fiveYearReservesProjectionTerrain = _fiveYearReservesProjection,
                                concessionReservesPrecedingYearJanuary = _concessionReservesPrecedingYearJanuary,
                                reservesUpdateConcessionReservesJanuary = _reservesUpdateConcessionReservesJanuary,
                                wellType_oil = _wellType_oil,
                                wellType_gas = _wellType_gas,
                                workoverRecompletionJobsQuaterlyBasis = _workoverRecompletionJobsQuaterlyBasis,
                                initialWellCompletionJobsQuaterlyBasis = _initialWellCompletionJobsQuaterlyBasis,
                                unitization = _unitization,
                                expectedReserves = _expectedReserves,
                                fieldDevelopmentPlan = _fieldDevelopmentPlan,

                                OilCondensateProduction = _OilCondensateProduction,
                                OilCondensateProductionMonthly = _OilCondensateProductionMonthly,
                                OilCondensateProductionMonthlyProposed = _OilCondensateProductionMonthlyProposed,
                                OilCondensateFiveYears = _OilCondensateFiveYears,
                                fiveYearProductionForcast = _fiveYearProd,


                                HSERequirement = _HSERequirement,
                                HSETechnicalSafety = _HSETechnicalSafety,
                                HSESafetyStudies = _HSESafetyStudies,
                                HSEQualityControl = _HSEQualityControl,
                                HSEInspectionMaintenance = _HSEInspectionMaintenance,
                                HSEAssetRegister = _HSEAssetRegister,
                                HSEOilSpill = _HSEOilSpill,
                                HSECausesOfSpill = _HSECausesOfSpill,
                                HSEAssetRegisterRBI = _HSEAssetRegisterRBI,
                                HSEAccidentModel = _accidentModel,
                                HSEAccidentIncidence = _HSEAccidentIncidence,
                                HSEOSPRegistrations = _HSEOSPRegistrations,
                                HSEAccidentIncidenceType = _HSEAccidentIncidenceType,
                                HSECommunityDisturbance = _HSECommunityDisturbance,
                                HSESustainableDevProjProgramCsr = _HSESustainableDevProgramCsr,

                                HSEQuestion = _HSEQuestion,
                                HSEFatality = _HSEFatality,
                                HSEDesignSafety = _HSEDesignSafety,
                                HSEInspectionMaintenanceFacility = _HSEInspectionMaintenanceFacility,
                                HSEEnvironmentalStudies = _HSEEnvironmentalStudies,
                                HSEWasteManagement = _HSEWasteManagement,
                                HSEWasteManagementType = _HSEWasteManagementType,
                                HSEProducedWaterMgt = _HSEProducedWaterMgt,
                                HSEEnvironmentalCompliance = _HSEEnvironmentalCompliance,
                                HSEEnvironmentalFiveYears = _HSEEnvironmentalFiveYears,
                                HSEEnvironmentalStudiesUpdated = _HSEEnvironmentalStudiesUpdated,
                                HSEProducedWaterMgtUpdated = _HSEProducedWaterMgtUpdated,
                                HSEEnvironmentalComplianceChemical = _HSEEnvironmentalComplianceChemical,
                                HSEManagementPosition = _HSEManagementPosition,
                                HSEClimateChange = _HSEClimateChange,
                                HSESafetyCulture = _HSESafetyCulture,
                                HSEOccupationalHealth = _HSEOccupationalHealth,
                                HSEWasteManagementSystems = _HSEWasteManagementSystems,
                                HSEEnvironmentalManagementSystems = _HSEEnvironmentalManagementSystems,
                                hseEnvironmentalManagementPlans = _hseEnvironmentalManagementPlans,
                                hseRemediationFunds = _hseRemediationFunds,
                                hseWasteManagementDZs = _hseWasteManagementDZs,
                                hseEffluentCompliances = _hseEffluentCompliances,
                                hseGHGManagementPlans = _hseGHGManagementPlans,
                                hseHostCommunitiesDevelopments = _hseHostCommunitiesDevelopments,
                                hsePointSourceRegistrations = _hsePointSourceRegistrations,
                                hseOperationSafetyCases = _hseOperationSafetyCases,

                            };

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


        #region SBU Minimum Requirement Report
        [HttpGet("GetSBU_Minimum_Requirement_Report")]
        public async Task<object> GetSBU_Minimum_Requirement_Report(int appID)
        {
            string[] Item_types = { "Capex", "Opex" };

            try
            {
                var application = (from ap in _context.Applications where ap.Id == appID select ap).FirstOrDefault();

                if (application != null)
                {
                    int? fieldID = null;
                    if (application.FieldID != null)
                    {
                        fieldID = (int)application.FieldID;
                    }
                    var getStaffSBU = (from stf in _context.staff
                                       join sbu in _context.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                       where stf.StaffEmail == WKPCompanyEmail
                                       //"supervisorsupervisord@mailinator.com"
                                       select sbu).FirstOrDefault();

                    string year = application.YearOfWKP.ToString();

                    var staff = await _context.staff.Where(x => x.StaffEmail == WKPCompanyEmail).FirstOrDefaultAsync();
                    var staffRole = await _context.Roles.Where(x => x.id == staff.RoleID).FirstOrDefaultAsync();

                    if(staffRole.RoleName == ROLE.ExecutiveCommissioner || staffRole.RoleName == ROLE.FinalAuthority)
                    {
                        var _budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                        var _BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).ToListAsync();
                        var _BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).ToListAsync();

                        //var _BudgetPerformanceExploratory = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        var _geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                        var __concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();
                        var _categoriesProposedWells = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();

                        var _sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();


                        var __LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var __LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();

                        var __categoriesProposedWell = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                        var _fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        var _fiveYearProd = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        var _reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).ToListAsync();
                        var _concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).ToListAsync();
                        var _lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                        var _fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();



                        var _HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                        var _hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();


                        return new
                        {
                            budgetProposalNairaDollar = _budgetProposalNairaDollar,
                            budgetCapex = _BudgetCapex,
                            budgetOpex = _BudgetOpex,


                            //BudgetPerformanceExploratory = _BudgetPerformanceExploratory,
                            categoriesProposedWells = _categoriesProposedWells,
                            geoActivitiesProcessings = _geoActivitiesProcessings,
                            concessionSituations = __concessionSituations,
                            concessionSituation = __concessionSituations,


                            sustainableDevelopmentCommunityProjectProgram = _sustainableDevelopmentCommunityProjectProgram,
                            projectDetails = _projectDetails,
                            capitalProjects = _capitalProjects,
                            scholarships = _scholarships,
                            trainingsSkillAcquisition = _trainingsSkillAcquisition,
                            staffDisposition = _staffDisposition,
                            seniorManagementStaff = _seniorManagementStaff,

                            LegalLitigation = __LegalLitigation,
                            LegalArbitration = __LegalArbitration,

                            lifeIndex_years = _lifeIndex_years,
                            depletionRate = _depletionRate,
                            fiveYearTrendConcessionReserveReplacementRatio = _fiveYearTrendConcessionReserveReplacementRatio,
                            reserveDecline = _reserveDecline,
                            reserveAddition = _reserveAddition,
                            fiveYearReservesProjection = _fiveYearReservesProjection,
                            concessionReservesPrecedingYearJanuary = _concessionReservesPrecedingYearJanuary,
                            reservesUpdateConcessionReservesJanuary = _reservesUpdateConcessionReservesJanuary,
                            workoverRecompletionJobsQuaterlyBasis = _workoverRecompletionJobsQuaterlyBasis,
                            initialWellCompletionJobsQuaterlyBasis = _initialWellCompletionJobsQuaterlyBasis,
                            fieldDevelopmentPlan = _fieldDevelopmentPlan,
                            OilCondensateProduction = _OilCondensateProduction,
                            fiveYearProductionForcast = _fiveYearProd,


                            HSETechnicalSafety = _HSETechnicalSafety,
                            HSEWasteManagement = _HSEWasteManagement,
                            HSESafetyCulture = _HSESafetyCulture,
                            hseEnvironmentalManagementPlans = _hseEnvironmentalManagementPlans,
                            hseRemediationFunds = _hseRemediationFunds,
                            HSEOccupationalHealth = _HSEOccupationalHealth,
                            hseGHGManagementPlans = _hseGHGManagementPlans,
                            hseHostCommunitiesDevelopments = _hseHostCommunitiesDevelopments,
                            hseOperationSafetyCases = _hseOperationSafetyCases,

                        };
                    }

                    switch (getStaffSBU.SBU_Code)
                    {

                        case "ER&SP": //Work Programme

                            var budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();

                            var BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).ToListAsync();
                            var BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).ToListAsync();

                            return new
                            {
                                budgetProposalNairaDollar = budgetProposalNairaDollar,
                                budgetCapex = BudgetCapex,
                            };

                        case "E&AM": //Planning
                            var geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Year == year select d).ToListAsync();
                            var categoriesProposedWells = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                          
                            return new
                            {
                                categoriesProposedWells = categoriesProposedWells,
                                geoActivitiesProcessings = geoActivitiesProcessings,
                                concessionSituations = concessionSituations,
                                concessionSituation = concessionSituations,
                            };

                        case "CS&A":
                            var sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            return new
                            {
                                sustainableDevelopmentCommunityProjectProgram = sustainableDevelopmentCommunityProjectProgram,
                                projectDetails = projectDetails,
                                capitalProjects = capitalProjects,
                                scholarships = scholarships,
                                trainingsSkillAcquisition = trainingsSkillAcquisition,
                                staffDisposition = staffDisposition,
                                seniorManagementStaff = seniorManagementStaff,
                            };


                        case "LGL": //Legal

                            var LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            return new
                            {
                                LegalLitigation = LegalLitigation,
                                LegalArbitration = LegalArbitration
                            };



                        case "D&P": //SBU
                            var _concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();
                            var _categoriesProposedWell = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                            var fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var fiveYearProd = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).ToListAsync();
                            var concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).ToListAsync();
                            var lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var facilitiesProjectPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var conformityAssuranceAssetIntegrity = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var facilityDevelopmentProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            
                            return new
                            {
                                lifeIndex_years = lifeIndex_years,
                                depletionRate = depletionRate,
                                fiveYearTrendConcessionReserveReplacementRatio = fiveYearTrendConcessionReserveReplacementRatio,
                                reserveDecline = reserveDecline,
                                reserveAddition = reserveAddition,
                                fiveYearReservesProjection = fiveYearReservesProjection,
                                concessionReservesPrecedingYearJanuary = concessionReservesPrecedingYearJanuary,
                                reservesUpdateConcessionReservesJanuary = reservesUpdateConcessionReservesJanuary,
                                workoverRecompletionJobsQuaterlyBasis = workoverRecompletionJobsQuaterlyBasis,
                                initialWellCompletionJobsQuaterlyBasis = initialWellCompletionJobsQuaterlyBasis,
                                fieldDevelopmentPlan = fieldDevelopmentPlan,
                                categoriesProposedWells = _categoriesProposedWell,
                                OilCondensateProduction = OilCondensateProduction,
                                fiveYearProductionForcast = fiveYearProd,
                                concessionSituations = _concessionSituations,
                                facilitiesProjectPerformance = facilitiesProjectPerformance,
                                conformityAssuranceAssetIntegrity = conformityAssuranceAssetIntegrity,
                                facilityDevelopmentProjects = facilityDevelopmentProjects,
                            };

                        case "HSE&C": //HSE
                            var HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID==application.FieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();

                            return new
                            {
                                HSETechnicalSafety = HSETechnicalSafety,
                                HSEWasteManagement = HSEWasteManagement,
                                HSESafetyCulture = HSESafetyCulture,
                                hseEnvironmentalManagementPlans = hseEnvironmentalManagementPlans,
                                hseRemediationFunds = hseRemediationFunds,
                                HSEOccupationalHealth = HSEOccupationalHealth,
                                hseGHGManagementPlans = hseGHGManagementPlans,
                                hseHostCommunitiesDevelopments = hseHostCommunitiesDevelopments,
                                hseOperationSafetyCases = hseOperationSafetyCases,
                            };

                        case "WPA":
                            var _budgetProposalNairaDollar = await (from d in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where d.CompanyNumber == application.CompanyID && d.Field_ID == fieldID && d.Year_of_WP == year select d).ToListAsync();
                            var _BudgetCapex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[0] && c.Year_of_WP == year select c).ToListAsync();
                            var _BudgetOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.CompanyNumber == application.CompanyID && c.Item_Type == Item_types[1] && c.Year_of_WP == year select c).ToListAsync();
                                
                            //var _BudgetPerformanceExploratory = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _geoActivitiesProcessings = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year_of_WP == year orderby d.QUATER select d).ToListAsync();
                            var __concessionSituations = await (from d in _context.CONCESSION_SITUATIONs where d.CompanyNumber == application.CompanyID && d.Field_ID == application.FieldID && d.Year == year select d).ToListAsync();
                            var _categoriesProposedWells = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                                
                            var _sustainableDevelopmentCommunityProjectProgram = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _projectDetails = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _capitalProjects = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _scholarships = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _trainingsSkillAcquisition = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _staffDisposition = await (from c in _context.NIGERIA_CONTENT_Trainings where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _seniorManagementStaff = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                                
                                
                            var __LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var __LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                                
                            var __categoriesProposedWell = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year orderby c.QUATER select c).ToListAsync();
                            var _fieldDevelopmentPlan = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _initialWellCompletionJobsQuaterlyBasis = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _workoverRecompletionJobsQuaterlyBasis = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _fiveYearProd = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                            var _reservesUpdateConcessionReservesJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).ToListAsync();
                            var _concessionReservesPrecedingYearJanuary = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).ToListAsync();
                            var _lifeIndex_years = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _depletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _fiveYearTrendConcessionReserveReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _reserveDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _reserveAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                            var _fiveYearReservesProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.CompanyNumber == application.CompanyID && c.Year_of_WP == year select c).ToListAsync();
                                


                            var _HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseOperationSafetyCases = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseEnvironmentalManagementPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseGHGManagementPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanyNumber == application.CompanyID && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseHostCommunitiesDevelopments = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.CompanyNumber == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();
                            var _hseRemediationFunds = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_Number == application.CompanyID.ToString() && c.Field_ID == fieldID && c.Year_of_WP == year select c).ToListAsync();


                            return new
                            {
                                budgetProposalNairaDollar = _budgetProposalNairaDollar,
                                budgetCapex = _BudgetCapex,
                                budgetOpex = _BudgetOpex,


                                //BudgetPerformanceExploratory = _BudgetPerformanceExploratory,
                                categoriesProposedWells = _categoriesProposedWells,
                                geoActivitiesProcessings = _geoActivitiesProcessings,
                                concessionSituations = __concessionSituations,
                                concessionSituation = __concessionSituations,


                                sustainableDevelopmentCommunityProjectProgram = _sustainableDevelopmentCommunityProjectProgram,
                                projectDetails = _projectDetails,
                                capitalProjects = _capitalProjects,
                                scholarships = _scholarships,
                                trainingsSkillAcquisition = _trainingsSkillAcquisition,
                                staffDisposition = _staffDisposition,
                                seniorManagementStaff = _seniorManagementStaff,

                                LegalLitigation = __LegalLitigation,
                                LegalArbitration = __LegalArbitration,

                                lifeIndex_years = _lifeIndex_years,
                                depletionRate = _depletionRate,
                                fiveYearTrendConcessionReserveReplacementRatio = _fiveYearTrendConcessionReserveReplacementRatio,
                                reserveDecline = _reserveDecline,
                                reserveAddition = _reserveAddition,
                                fiveYearReservesProjection = _fiveYearReservesProjection,
                                concessionReservesPrecedingYearJanuary = _concessionReservesPrecedingYearJanuary,
                                reservesUpdateConcessionReservesJanuary = _reservesUpdateConcessionReservesJanuary,
                                workoverRecompletionJobsQuaterlyBasis = _workoverRecompletionJobsQuaterlyBasis,
                                initialWellCompletionJobsQuaterlyBasis = _initialWellCompletionJobsQuaterlyBasis,
                                fieldDevelopmentPlan = _fieldDevelopmentPlan,
                                OilCondensateProduction = _OilCondensateProduction,
                                fiveYearProductionForcast = _fiveYearProd,


                                HSETechnicalSafety = _HSETechnicalSafety,
                                HSEWasteManagement = _HSEWasteManagement,
                                HSESafetyCulture = _HSESafetyCulture,
                                hseEnvironmentalManagementPlans = _hseEnvironmentalManagementPlans,
                                hseRemediationFunds = _hseRemediationFunds,
                                HSEOccupationalHealth = _HSEOccupationalHealth,
                                hseGHGManagementPlans = _hseGHGManagementPlans,
                                hseHostCommunitiesDevelopments = _hseHostCommunitiesDevelopments,
                                hseOperationSafetyCases = _hseOperationSafetyCases,

                            };

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

        #endregion

        [AllowAnonymous]
        [HttpGet("TestGEN")]
        public IActionResult GeneratePdf()
        {
            var model = new MyViewModel
            {
                Title = "My PDF Title",
                Description = "This is the content of my PDF."
            };

            var rotativaFolder = "Rotativa";
            var wkhtmltopdfRelativePath = Path.Combine(rotativaFolder, "wkhtmltopdf");

            var wkhtmltopdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, wkhtmltopdfRelativePath);


            var res = new ViewAsPdf
            {
                ViewName = "ApplicationView",
                //IsGrayScale = true,
                //WkhtmltopdfPath = wkhtmltopdfPath
            };

            //var pdfBytes = res.BuildFile(ControllerContext);
            //return File(pdfBytes, "application/pdf", "GeneratedPdf.pdf");

            return res;
        }
    }
}
