using AutoMapper;
using Backend_UMR_Work_Program.Controllers;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Models.Enurations;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Services
{
    public class ApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly WKP_DBContext _dbContext;
        private readonly HelperService _helperService;
        private readonly AppProcessFlowService _processFlowService;

        public ApplicationService(IMapper mapper, IConfiguration config, WKP_DBContext wKP_DBContext, HelperService helperService, AppProcessFlowService processFlowService)
        {
            _mapper = mapper;
            _config = config;
            _dbContext = wKP_DBContext;
            _helperService = helperService;
            _processFlowService = processFlowService;
        }

        //public async Task<object> GetSendBackComments(int appId)
        //{
        //    try
        //    {
        //        var comments = await _dbContext.ApplicationDeskHistories
        //            .Include(x => x.Staff)
        //            .Include(x => x.Company)
        //            .Where(
        //                x => x.AppId == appId 
        //                && x.Status != null 
        //                && x.Status == APPLICATION_HISTORY_STATUS.SentBackToCompany
        //                ).OrderByDescending(x => x.ActionDate).ToListAsync();

        //        return comments;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<WebApiResponse> RejectedApplications()
        {
            try
            {
                var applications = await (from app in _dbContext.Applications
                                          join comp in _dbContext.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          //join field in _context.COMPANY_FIELDs on app.FieldID equals field.Field_ID
                                          join con in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          where app.DeleteStatus != true && app.Status == MAIN_APPLICATION_STATUS.Rejected
                                          select new Application_Model
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.ConcessionName,
                                              FieldName = app.FieldID != null ? _dbContext.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
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
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetReturnToCompanyComments(int appId, bool isPublic = false)
        {
            try
            {
                List<ApplicationDeskHistory> appHistories = null;
                
                if(isPublic)
                    appHistories = await _dbContext.ApplicationDeskHistories
                        .Include(x => x.Staff)
                        .Include(x => x.Company)
                        .Where(
                            x => x.AppId == appId
                            && x.isPublic == true
                            ).OrderByDescending(x => x.ActionDate).ToListAsync();
                else
                    appHistories = await _dbContext.ApplicationDeskHistories
                        .Include(x => x.Staff)
                        .Include(x => x.Company)
                        .Where(
                            x => x.AppId == appId
                            ).OrderByDescending(x => x.ActionDate).ToListAsync();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = appHistories, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> AddCommentToApplication(int appId, int? staffId, string? status, string comment, string? selectedTables, bool? actionByCompany, int? companyId, bool? isPublic = false)
        {
            try
            {
                _helperService.SaveApplicationHistory(appId, staffId, status, comment, selectedTables, actionByCompany, companyId, PROCESS_CONSTANTS.AddAComment, isPublic);
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = true, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<bool> HasApplicationBeenSubmittedBefore(int yearID, COMPANY_FIELD field, ADMIN_CONCESSIONS_INFORMATION concession)
        {
            var app = new Application();

            try
            {
                if (field != null)
                {
                    app = await _dbContext.Applications.Where(
                        a => a.YearOfWKP == yearID 
                        && a.ConcessionID == concession.Consession_Id 
                        && a.FieldID == field.Field_ID 
                        && a.Status != MAIN_APPLICATION_STATUS.NotSubmitted
                        ).FirstOrDefaultAsync();
                }
                else
                {
                    app = await _dbContext.Applications.Where(a => a.YearOfWKP == yearID && a.ConcessionID == concession.Consession_Id && a.Status != MAIN_APPLICATION_STATUS.NotSubmitted).FirstOrDefaultAsync();
                }

                if (app != null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WebApiResponse> SubmitApplication(int appId)
        {

            try
            {
                var app = await _dbContext.Applications.Where(x => x.Id == appId).FirstOrDefaultAsync();
                int year = app.YearOfWKP;
                //Get Year, Concession, field and configured application processes
                var company = await _dbContext.ADMIN_COMPANY_INFORMATIONs.Where(x => x.Id == app.CompanyID).FirstOrDefaultAsync();
                var concession = await _dbContext.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID && x.Year == year.ToString()).FirstOrDefaultAsync();
                var field = await _dbContext.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefaultAsync();
                var applicationProcesses = await _processFlowService.GetApplicationProccessByAction(GeneralModel.PROCESS_CONSTANTS.Submit);

                if (applicationProcesses.Count <= 0)
                    return new WebApiResponse
                    {
                        ResponseCode = AppResponseCodes.Success,
                        Message = "An error occured while trying to get process flow for this application. No, application process was configured.",
                        StatusCode = ResponseCodes.Badrequest
                    };

                if (await HasApplicationBeenSubmittedBefore(year, field, concession))
                    return new WebApiResponse
                    {
                        ResponseCode = AppResponseCodes.Success,
                        Message = "Error : An application for the Concession {omlName}, and Field Name {field.Field_Name} for the year {year} has already been submitted.",
                        StatusCode = ResponseCodes.Duplicate
                    };

                if (app != null)
                {

                    //Distribute to Reviewers
                    var staffList = await _helperService.GetReviewerStaff(applicationProcesses);

                    foreach (var staff in staffList)
                    {
                        //Get The process Flow
                        var processFlow = _dbContext.ApplicationProccesses.Where<ApplicationProccess>(p => p.TargetedToRole == staff.RoleID && p.TargetedToSBU == staff.Staff_SBU).FirstOrDefault();

                        int FromStaffID = 0; //This value is zero, because, this is company and not a staff
                        int FromStaffSBU = 0; // This value is zero, because, this is company and not a staff
                        int FromStaffRoleID = 0; //This value is zero, because, this is company and not a staff

                        int saveStaffDesk = _helperService.RecordStaffDesks(
                            app.Id, staff, FromStaffID, FromStaffSBU, 
                            FromStaffRoleID, processFlow.ProccessID, 
                            MAIN_APPLICATION_STATUS.SubmittedByCompany);

                        if (saveStaffDesk > 0)
                        {
                            _helperService.SaveApplicationHistory(app.Id, staff.StaffID,
                                MAIN_APPLICATION_STATUS.SubmittedByCompany, 
                                "Application submitted and landed on staff desk", 
                                null, false, null, APPLICATION_ACTION.SubmitApplication);

                            string emailSubject = $"{year} submission of WORK PROGRAM application for {company.COMPANY_NAME} field - {field?.Field_Name} : {app.ReferenceNo}";
                            string emailContent = $"{company.COMPANY_NAME} have submitted their WORK PROGRAM application for year {year}.";
                            var emailMessage = _helperService.SaveMessage(app.Id, staff.StaffID, emailSubject, emailContent, "Staff");
                            //var sendEmail2 = _helperService.SendEmailMessage(staff.StaffEmail, staff.FirstName, emailMessage, null);

                            _helperService.LogMessages("Submission of application with REF : " + app.ReferenceNo, company.EMAIL);
                        }
                        else
                        {
                            return new WebApiResponse
                            {
                                ResponseCode = AppResponseCodes.Success,
                                Message = "An error occured while trying to submit this application to a staff's desk.",
                                StatusCode = ResponseCodes.Failure
                            };
                        }
                    }

                    app.Status = MAIN_APPLICATION_STATUS.SubmittedByCompany;
                    app.SubmittedAt = DateTime.Now;

                    _dbContext.Update(app);
                    await _dbContext.SaveChangesAsync();

                    //send mail to company
                    string subject = $"{year} submission of WORK PROGRAM application for field - {field?.Field_Name} : {app.ReferenceNo}";
                    string content = $"You have successfully submitted your WORK PROGRAM application for year {year}, and it is currently being reviewed.";
                    var emailMsg = _helperService.SaveMessage(app.Id, Convert.ToInt32(company.Id), subject, content, "Company");
                    //var sendEmail = _helperService.SendEmailMessage(company.EMAIL, company.COMPANY_NAME, emailMsg, null);
                    var responseMsg = field != null ? $"{year} Application for field {field?.Field_Name} has been submitted successfully." : $"{year} Application for concession: ({concession.ConcessionName}) has been submitted successfully.\nIn the case multiple fields, please also ensure that submissions are made to cater for them.";

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMsg, StatusCode = ResponseCodes.Success };

                }
                else
                {
                    return new WebApiResponse
                    {
                        ResponseCode = AppResponseCodes.Success,
                        Message = "An error occured while trying to save this application record.",
                        StatusCode = ResponseCodes.Failure
                    };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse
                {
                    ResponseCode = AppResponseCodes.Success,
                    Message = e.Message,
                    StatusCode = ResponseCodes.InternalError
                };
            }
        }

        public async Task<WebApiResponse> PushApplication(int deskID, string comment, string[] selectedApps)
        {
            try
            {

                staff staffActing = (from stf in _dbContext.staff
                                        join dsk in _dbContext.MyDesks on stf.StaffID equals dsk.StaffID
                                        where dsk.DeskID == deskID
                                        select stf).FirstOrDefault();
                var staffActingRole = await _dbContext.Roles.Where(x => x.id == staffActing.RoleID).FirstOrDefaultAsync();

                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);
                        //get current staff desk
                        var staffDesk = _dbContext.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();
                        var application = _dbContext.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _dbContext.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();
                        var ownerOfDesk = await _dbContext.staff.Where(x => x.StaffID == staffDesk.StaffID).FirstOrDefaultAsync();

                        var staffId = ownerOfDesk?.StaffID;
                        var staffRoleId = ownerOfDesk?.RoleID;
                        var staffSBUId = ownerOfDesk?.Staff_SBU;
                        var getApplicationProcess = await _helperService.GetApplicationProccessBySBUAndRole(PROCESS_CONSTANTS.Push, (int)staffRoleId, (int)staffSBUId);
                        var getApplicationProcessEC = await _helperService.GetApplicationProccessBySBUAndRole(PROCESS_CONSTANTS.ApprovedByEC, (int)staffRoleId, (int)staffSBUId);

                        if (getApplicationProcess.Count > 0)
                        {
                            foreach (var processFlow in getApplicationProcess)
                            {
                                var getStaffByTargetedRoleAndSBUs = await _helperService.GetStaffByTargetRoleAndSBU((int)processFlow.TargetedToRole, (int)processFlow.TargetedToSBU);

                                var deskTemp = await _helperService.GetNextStaffDesk(getStaffByTargetedRoleAndSBUs, appId);

                                if (deskTemp != null)
                                {
                                    deskTemp.FromRoleId = processFlow.TriggeredByRole;
                                    deskTemp.FromSBU = (int)processFlow.TriggeredBySBU;
                                    deskTemp.FromStaffID = staffActing.StaffID;
                                    deskTemp.ProcessID = processFlow.ProccessID;
                                    deskTemp.AppId = appId;
                                    deskTemp.HasPushed = false;
                                    deskTemp.HasWork = true;
                                    deskTemp.CreatedAt = DateTime.Now;
                                    deskTemp.UpdatedAt = DateTime.Now;
                                    deskTemp.Comment = comment;
                                    deskTemp.LastJobDate = DateTime.Now;
                                    deskTemp.ProcessStatus = DESK_PROCESS_STATUS.SubmittedByStaff;

                                    _dbContext.Update(deskTemp);
                                }
                                else
                                {
                                    var desk = new MyDesk
                                    {
                                        //save staff desk
                                        StaffID = deskTemp.StaffID,
                                        FromRoleId = processFlow.TriggeredByRole,
                                        FromSBU = (int)processFlow.TriggeredBySBU,
                                        FromStaffID = staffActing.StaffID,
                                        ProcessID = processFlow.ProccessID,
                                        AppId = appId,
                                        HasPushed = false,
                                        HasWork = true,
                                        CreatedAt = DateTime.Now,
                                        UpdatedAt = DateTime.Now,
                                        Comment = comment,
                                        LastJobDate = DateTime.Now,
                                        ProcessStatus = DESK_PROCESS_STATUS.SubmittedByStaff,

                                    };

                                    deskTemp = desk;

                                    _dbContext.MyDesks.Add(desk);
                                }

                                var save = await _dbContext.SaveChangesAsync();
                                
                                await _helperService.UpdateDeskAfterPush(staffDesk, comment, DESK_PROCESS_STATUS.Pushed);

                                _helperService.SaveApplicationHistory(application.Id, staffActing.StaffID, DESK_PROCESS_STATUS.Pushed, comment, null, false, null, PROCESS_CONSTANTS.Push);
                                //_helperService.SaveApplicationHistory(application.Id, staffActing.StaffID, GeneralModel.APPLICATION_STATUS.Pushed, comment, null, false, null, GeneralModel.PROCESS_CONSTANTS.Push);

                                string subject = $"Push action was taken for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}) has been pushed by a staff to the next processing level.";
                                var emailMsg = _helperService.SaveMessage(application.Id, staffActing.StaffID, subject, content, "Staff");
                                //var sendEmail = _helperService.SendEmailMessage(staffActing.StaffEmail, staffActing.FirstName, emailMsg, null);

                                _helperService.LogMessages($"Push action was taken for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).");
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been pushed successfully.", StatusCode = ResponseCodes.Success };
                            }
                        }
                        else if (getApplicationProcessEC.Count > 0)
                        {
                            foreach (var processFlow in getApplicationProcessEC)
                            {
                                var getStaffByTargetedRoleAndSBUs = await _helperService.GetStaffByTargetRoleAndSBU((int)processFlow.TargetedToRole, (int)processFlow.TargetedToSBU);

                                var deskTemp1 = await _helperService.GetNextStaffDesk_EC(getStaffByTargetedRoleAndSBUs, appId);

                                if (deskTemp1.DeskID != -1)
                                {
                                    deskTemp1.FromRoleId = processFlow.TriggeredByRole;
                                    deskTemp1.FromSBU = (int)processFlow.TriggeredBySBU;
                                    deskTemp1.FromStaffID = staffActing.StaffID;
                                    deskTemp1.ProcessID = processFlow.ProccessID;
                                    deskTemp1.AppId = appId;
                                    deskTemp1.HasPushed = false;
                                    deskTemp1.HasWork = true;
                                    deskTemp1.CreatedAt = DateTime.Now;
                                    deskTemp1.UpdatedAt = DateTime.Now;
                                    deskTemp1.Comment = comment;
                                    deskTemp1.LastJobDate = DateTime.Now;
                                    deskTemp1.ProcessStatus = DESK_PROCESS_STATUS.FinalAuthorityApproved;

                                    _dbContext.Update(deskTemp1);
                                }
                                else
                                {
                                    deskTemp1 = _dbContext.MyDesks.Where(x => x.StaffID == deskTemp1.StaffID && x.AppId == deskTemp1.AppId && x.HasWork == true).FirstOrDefault();
                                }

                                var save = await _dbContext.SaveChangesAsync();

                                await _helperService.UpdateDeskAfterPush(staffDesk, comment, DESK_PROCESS_STATUS.Pushed);

                                _helperService.SaveApplicationHistory(application.Id, staffActing.StaffID, APPLICATION_HISTORY_STATUS.FinalAuthorityApproved, comment, null, false, null, APPLICATION_ACTION.Approve);

                                //Update Final Authority Approvals Table
                                await _helperService.UpdateApprovalTable(application.Id, comment, staffDesk.StaffID, staffDesk.DeskID, APPLICATION_HISTORY_STATUS.FinalAuthorityApproved);

                                string subject = $"Approval from Final Athority for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}) has been approved approved by Final Authority to the next processing level.";
                                var emailMsg = _helperService.SaveMessage(application.Id, staffActing.StaffID, subject, content, "Staff");
                                //var sendEmail = _helperService.SendEmailMessage(staffActing.StaffEmail, staffActing.FirstName, emailMsg, null);

                                _helperService.LogMessages($"Approval from Final Athority for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).");
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been approved by Final Authority successfully.", StatusCode = ResponseCodes.Success };
                            }
                        }
                        else
                        {
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while trying to get process flow for this application." , StatusCode = ResponseCodes.Failure };
                        }
                    }
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = "Error: No application ID was passed for this action to be completed." , StatusCode = ResponseCodes.Badrequest };
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = "Error: No application ID was passed for this action to be completed." , StatusCode = ResponseCodes.Badrequest };
            }
            catch (Exception x)
            {
                _helperService.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = $"An error occured while pushing application to staff. {x.Message.ToString()}" , StatusCode = ResponseCodes.Badrequest };
            }

        }

        public async Task<WebApiResponse> GetDashboardData(int WKPCompanyNumber)
        {
            try
            {
                var deskCount = 0;
                var allApplicationsCount = 0;
                var allProcessingCount = 0;
                var allApprovalsCount = 0;
                var allRejectionsCount = 0;

                var currentStaff = (from stf in _dbContext.staff
                                join admin in _dbContext.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                select stf).FirstOrDefault();

                if (currentStaff != null)
                {
                    deskCount = await _dbContext.MyDesks.Where(x => x.StaffID == currentStaff.StaffID && x.HasWork == true).CountAsync();
                    allProcessingCount = await _dbContext.MyDesks.Where(x => x.StaffID == currentStaff.StaffID && x.HasWork == true && x.ProcessStatus == DESK_PROCESS_STATUS.Processing).CountAsync();
                    allApplicationsCount = (await _dbContext.MyDesks.Include(s => s.Staff).Where(x => x.HasWork && x.Staff.Staff_SBU == currentStaff.Staff_SBU).ToListAsync()).DistinctBy(x => x.AppId).Count();
                }
                
                allRejectionsCount = await _dbContext.Applications.Where(x => x.Status == MAIN_APPLICATION_STATUS.Rejected).CountAsync();
                allApprovalsCount = await _dbContext.PermitApprovals.CountAsync();
                var data = new
                {
                    deskCount = deskCount,
                    allApplicationsCount = allApplicationsCount,
                    allProcessingCount = allProcessingCount,
                    allApprovalsCount = allApprovalsCount,
                    allRejectionsCount = allRejectionsCount
                };

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = data, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}" , StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> LockForms(int year, int concessionId, int fieldId)
        {
            try
            {
                if(year != 0 || concessionId == 0)
                {
                    var validStatues = new List<string> { 
                        MAIN_APPLICATION_STATUS.SubmittedByCompany, 
                        MAIN_APPLICATION_STATUS.ApprovedByFinalApprovingAuthority,
                        MAIN_APPLICATION_STATUS.ApprovedByFinalAuthority,
                        MAIN_APPLICATION_STATUS.Approved,
                        MAIN_APPLICATION_STATUS.ReturnedToCompany,
                        MAIN_APPLICATION_STATUS.ReturnedToStaff,
                        MAIN_APPLICATION_STATUS.Processing,

                    };

                    var apps = new List<Application>();

                    if(fieldId != 0)
                        apps = await _dbContext.Applications.Where(x => x.YearOfWKP == year && x.ConcessionID == concessionId && x.FieldID == fieldId).ToListAsync();
                    else
                        apps = await _dbContext.Applications.Where(x => x.YearOfWKP == year && x.ConcessionID == concessionId).ToListAsync();

                    var submittedApp = apps.FirstOrDefault(x => validStatues.Contains(x.Status));

                    if(submittedApp != null)
                    {
                        var returnToCompanyAppHistory = await _dbContext.ApplicationDeskHistories
                                        .Where(x => x.AppId == submittedApp.Id 
                                        && x.Status == APPLICATION_HISTORY_STATUS.ReturnedToCompany).FirstOrDefaultAsync();

                        var selectedTables = returnToCompanyAppHistory?.SelectedTables?.Split('|').ToList();

                        var res = new FormLock
                        {
                            disableSubmission = submittedApp != null,
                            enableReSubmission = returnToCompanyAppHistory != null 
                                                && (returnToCompanyAppHistory.Status == APPLICATION_HISTORY_STATUS.ReturnedToCompany 
                                                || submittedApp.PaymentStatus == PAYMENT_STATUS.PaymentPending) ? true : false,
                            formsToBeEnabled = selectedTables
                        };

                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = res, Message = "Success", StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        var res = new FormLock
                        {
                            disableSubmission = false,
                            enableReSubmission = false,
                            formsToBeEnabled = null,
                        };

                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = res, Message = "Success", StatusCode = ResponseCodes.Success };
                    }
                    
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.InvalidParameterPassed, Message = $"Error: Invalid Parameter(s) passed", StatusCode = ResponseCodes.Badrequest };
                }
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetProcessingApplicationsOnMyDesk(string staffEmail)
        {
            try
            {
                var loggedInStaff = await _dbContext.staff.Where(x => x.StaffEmail == staffEmail).FirstOrDefaultAsync();
                var applications = await (from app in _dbContext.Applications
                                          join comp in _dbContext.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join dsk in _dbContext.MyDesks on app.Id equals dsk.AppId
                                          join field in _dbContext.COMPANY_FIELDs on app.FieldID equals field.Field_ID
                                          join con in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          where dsk.StaffID == loggedInStaff.StaffID && dsk.ProcessStatus == DESK_PROCESS_STATUS.Processing
                                          select new Application_Model
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.ConcessionName,
                                              FieldName = field != null? field.Field_Name: null,
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
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetProcessingApplications(int staffId)
        {
            try
            {
                var applications = await (from app in _dbContext.Applications
                                          join comp in _dbContext.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join dsk in _dbContext.MyDesks on app.Id equals dsk.AppId
                                          join field in _dbContext.COMPANY_FIELDs on app.FieldID equals field.Field_ID
                                          join con in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          where dsk.StaffID == staffId && dsk.ProcessStatus == DESK_PROCESS_STATUS.Processing
                                          select new Application_Model
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.ConcessionName,
                                              FieldName = field != null ? field.Field_Name : null,
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
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> OpenApplication(int deskId)
        {
            try
            {
                var staffDesk = await _dbContext.MyDesks.Where(x => x.DeskID == deskId).FirstOrDefaultAsync();
                var app = await _dbContext.Applications.Where(x => x.Id == staffDesk.AppId).FirstOrDefaultAsync();

                staffDesk.ProcessStatus = _helperService.IsIncomingDeskStatus(staffDesk.ProcessStatus) ? DESK_PROCESS_STATUS.Processing : staffDesk.ProcessStatus;

                app.Status = _helperService.IsIncomingDeskStatus(app.Status) ? DESK_PROCESS_STATUS.Processing : app.Status;

                _dbContext.MyDesks.Update(staffDesk);
                _dbContext.Applications.Update(app);
                await _dbContext.SaveChangesAsync();
                return new WebApiResponse { Data = staffDesk, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetAllApplicationsScopedToSBU(string staffEmail)
        {
            try
            {
                var loggedInStaff = await _dbContext.staff.Where(x => x.StaffEmail == staffEmail).FirstOrDefaultAsync();
                var applications = await (from app in _dbContext.Applications
                                          join dsk in _dbContext.MyDesks on app.Id equals dsk.AppId
                                          join conc in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals conc.Consession_Id
                                          join field in _dbContext.COMPANY_FIELDs on app.FieldID equals field.Field_ID into fieldGroup
                                          from field in fieldGroup.DefaultIfEmpty()
                                          where app.DeleteStatus != true && dsk.Staff.Staff_SBU == loggedInStaff.Staff_SBU
                                          && dsk.HasWork == true && app.Status != MAIN_APPLICATION_STATUS.NotSubmitted
                                          select new
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = conc.ConcessionName,
                                              FieldName = field.Field_Name,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              CompanyName = conc.CompanyName,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetReturnedApplications(int WKPCompanyNumber)
        {
            try
            {
                var applications = await (from app in _dbContext.Applications
                                          join comp in _dbContext.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join appHistory in _dbContext.ApplicationDeskHistories on app.Id equals appHistory.AppId
                                          join stf in _dbContext.staff on appHistory.StaffID equals stf.StaffID
                                          join sbu in _dbContext.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                          where app.DeleteStatus != true && appHistory.Status == MAIN_APPLICATION_STATUS.ReturnedToCompany
                                          && app.CompanyID == WKPCompanyNumber
                                          select new
                                          {
                                              Last_SBU = sbu.SBU_Name,
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = _dbContext.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                              FieldName = app.FieldID != null ? _dbContext.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                              SBU_Comment = appHistory.Comment,
                                              Comment = appHistory.Comment,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              Status = app.Status,
                                              SBU_Tables = appHistory.SelectedTables,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetAppsOnMyDeskBySBUAndRole(int sbuID, int roleID)
        {
            try
            {
                //var staffs = _context.staff.Where<staff>(s => s.Staff_SBU == sbuID && s.RoleID == roleID).ToList();
                var staffDesks = await (from desk in _dbContext.MyDesks
                                        join staff in _dbContext.staff on desk.StaffID equals staff.StaffID
                                        join app in _dbContext.Applications.Include(a => a.Company).Include(a => a.Concession).Include(a => a.Field) on desk.AppId equals app.Id
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
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetAppsOnMyDeskByStaffID(int staffID)
        {
            try
            {
                //var staffs = _context.staff.Where<staff>(s => s.Staff_SBU == sbuID && s.RoleID == roleID).ToList();
                var staffDesks = await (from desk in _dbContext.MyDesks
                                        join staff in _dbContext.staff on desk.StaffID equals staff.StaffID
                                        join app in _dbContext.Applications on desk.AppId equals app.Id
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
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetAppsOnMyDesk(int WKPCompanyNumber)
        {
            try
            {
                var applications = await (from dsk in _dbContext.MyDesks
                                          join app in _dbContext.Applications on dsk.AppId equals app.Id
                                          join comp in _dbContext.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join stf in _dbContext.staff on dsk.StaffID equals stf.StaffID
                                          join admin in _dbContext.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                          join con in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs on app.ConcessionID equals con.Consession_Id
                                          where admin.Id == WKPCompanyNumber && dsk.HasWork == true
                                          select new
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.Concession_Held,
                                              FieldName = _dbContext.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              CompanyName = comp.COMPANY_NAME,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              YearOfWKP = app.YearOfWKP,
                                              CurrentDesk = dsk,
                                          }).ToListAsync();

                return new WebApiResponse { Data = applications, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> AllCompanies(string staffEmail)
        {
            try
            {
                var staff = await _dbContext.staff.Where(x => x.StaffEmail == staffEmail).FirstOrDefaultAsync();    


                var companies = await _dbContext.ADMIN_COMPANY_DETAILs.ToListAsync();

                return new WebApiResponse { Data = companies, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> SendBackApplicationToCompany(int deskID, string comment, string[] selectedApps, string[] selectedTables, int TypeOfPaymentId, string AmountNGN, string AmountUSD, int WKPCompanyNumber, string WKPCompanyEmail, string WKPCompanyName)
        {
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        int appId = b != "undefined" ? int.Parse(b) : 0;
                        //get current staff desk
                        var currentStaff = (from stf in _dbContext.staff
                                            join admin in _dbContext.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                            join role in _dbContext.Roles on stf.RoleID equals role.id
                                            where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                            select stf).FirstOrDefault();

                        var staffDesk = _dbContext.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();
                        var application = _dbContext.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _dbContext.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();
                        
                        string RejectedTables = await _processFlowService.getTableNames(selectedTables);

                        if (application.FieldID != null)
                        {
                            var field = _dbContext.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();
                        }

                        if (await _processFlowService.SendBackApplicationToCompany(Company, application, currentStaff, TypeOfPaymentId, AmountNGN, AmountUSD, comment, RejectedTables))
                        {
                            //Update Staffs Desk
                            //todo: update desk status
                            staffDesk.Comment = comment;
                            _dbContext.MyDesks.Update(staffDesk);
                            _dbContext.SaveChanges();

                            //Save Application history
                            //_helpersController.SaveHistory(application.Id, currentStaff.StaffID, GeneralModel.SentBackToCompany, comment, RejectedTables);
                            _helperService.SaveApplicationHistory(application.Id, currentStaff.StaffID, APPLICATION_HISTORY_STATUS.ReturnedToCompany, comment, RejectedTables, false, null, APPLICATION_ACTION.ReturnToCompany);

                            string subject = $"Returned WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                            string content = $"{WKPCompanyName} returned WORK PROGRAM application for year {application.YearOfWKP}.";
                            var emailMsg = _helperService.SaveMessage(application.Id, currentStaff.StaffID, subject, content, "Staff");
                            //var sendEmail = _helperService.SendEmailMessage(currentStaff.StaffEmail, currentStaff.FirstName, emailMsg, null);

                            _helperService.LogMessages("Returned application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                        }

                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application(s) has been returned successfully.", StatusCode = ResponseCodes.Success };
                    }
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.InvalidParameterPassed, Message = $"Error: No application ID was passed for this action to be completed.", StatusCode = ResponseCodes.Badrequest };
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.InvalidParameterPassed, Message = $"Error: No action was carried out on this application.", StatusCode = ResponseCodes.Badrequest };
            }
            catch (Exception x)
            {
                _helperService.LogMessages($"Approve Error:: {x.Message.ToString()}");
                return new WebApiResponse { ResponseCode = AppResponseCodes.InvalidParameterPassed, Message = $"Error: No action was carried out on this application.", StatusCode = ResponseCodes.Badrequest };
            }

        }

        public async Task<WebApiResponse> GetCompanyProcessingApplications(int WKPCompanyNumber)
        {
            try
            {
                var applications = await (from app in _dbContext.Applications
                                          join comp in _dbContext.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          where app.DeleteStatus != true && app.Status == MAIN_APPLICATION_STATUS.Processing
                                          && app.CompanyID == WKPCompanyNumber
                                          select new
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = _dbContext.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                              FieldName = app.FieldID != null ? _dbContext.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
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
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetSentBackApplications(int WKPCompanyNumber)
        {
            try
            {
                var apps = await (from rApp in _dbContext.ReturnedApplications
                                  join app in _dbContext.Applications on rApp.AppId equals app.Id
                                  join stf in _dbContext.staff on rApp.StaffId equals stf.StaffID
                                  join sbu in _dbContext.StrategicBusinessUnits on stf.Staff_SBU equals sbu.Id
                                  where app.DeleteStatus != true && app.CompanyID == WKPCompanyNumber
                                  select new
                                  {
                                      Last_SBU = sbu.SBU_Name,
                                      Id = app.Id,
                                      FieldID = app.FieldID,
                                      ConcessionID = app.ConcessionID,
                                      ConcessionName = _dbContext.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == app.ConcessionID).FirstOrDefault().Concession_Held,
                                      FieldName = app.FieldID != null ? _dbContext.COMPANY_FIELDs.Where(x => x.Field_ID == app.FieldID).FirstOrDefault().Field_Name : "",
                                      SBU_Comment = rApp.Comment != null? rApp.Comment: "",
                                      Comment = rApp.Comment != null ? rApp.Comment : "",
                                      ReferenceNo = app.ReferenceNo,
                                      CreatedAt = app.CreatedAt,
                                      SubmittedAt = app.SubmittedAt,
                                      Status = app.Status,
                                      PaymentStatus = app.PaymentStatus,
                                      SBU_Tables = rApp.StaffId,
                                      YearOfWKP = app.YearOfWKP
                                  }).ToListAsync();

                return new WebApiResponse { Data = apps, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> GetAccountDesk(string staffEmail)
        {
            try
            {
                var desks = await (
                        from desk in _dbContext.AccountDesks
                        join app in _dbContext.Applications on desk.StaffID equals app.Id
                        join staff in _dbContext.staff on desk.StaffID equals staff.StaffID
                        where desk.isApproved == false && staff.StaffEmail == staffEmail
                        select new
                        {
                            Desk = desk,
                            Application = app,
                            Staff = staff,
                        }
                    ).ToListAsync();
                return new WebApiResponse { Data = desks, ResponseCode = AppResponseCodes.Success, Message = "Success", StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> MoveApplication(int sourceStaffID, int targetStaffID, string[] selectedApps)
        {
            try
            {
                if (selectedApps != null)
                {
                    foreach (var b in selectedApps)
                    {
                        string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
                        int appId = int.Parse(appID);

                        var sourceStaff = await _dbContext.staff.Where<staff>(s => s.StaffID == sourceStaffID && s.DeleteStatus != true).FirstOrDefaultAsync();
                        var targetStaff = await _dbContext.staff.Where<staff>(s => s.StaffID == targetStaffID && s.DeleteStatus != true).FirstOrDefaultAsync();
                        var sourceStaffDesk = await _dbContext.MyDesks.Where<MyDesk>(d => d.StaffID == sourceStaff.StaffID && d.AppId == appId).FirstOrDefaultAsync();
                        var targetStaffDesk = await _dbContext.MyDesks.Where<MyDesk>(d => d.StaffID == targetStaff.StaffID && d.AppId == appId).FirstOrDefaultAsync();
                        var application = _dbContext.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _dbContext.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        if (sourceStaff == null || targetStaff == null || appID == null)
                            return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "An error occured while trying to get process flow for this application. Make sure that source and target staffIDs are valid including appId", StatusCode = ResponseCodes.InternalError };

                        if (sourceStaff.Staff_SBU != targetStaff.Staff_SBU)
                            return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "An error occured while trying to get process flow for this application. Source Staff's SBU and Role must match the Target Staff's.", StatusCode = ResponseCodes.InternalError };

                        //retrieve source desk using staffID and appId
                        var sourceDesk = await _dbContext.MyDesks.Where<MyDesk>(d => d.StaffID == sourceStaffID && d.AppId == appId).FirstOrDefaultAsync();
                        var targetDesk = await _dbContext.MyDesks.Where<MyDesk>(d => d.StaffID == targetStaffID && d.AppId == appId).FirstOrDefaultAsync();

                        if (sourceDesk == null)
                            return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "An error occured while trying to get process flow for this application. Application was not found on source staff's desk.", StatusCode = ResponseCodes.InternalError };

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

                            await _dbContext.MyDesks.AddAsync(desk);
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

                            _dbContext.MyDesks.Update(targetDesk);
                        }


                        var save = await _dbContext.SaveChangesAsync();
                        if (save > 0)
                        {
                            var result = await _helperService.DeleteDeskByDeskId(sourceDesk.DeskID);
                            //await _helpersController.UpdateDeskAfterMove(sourceDesk, sourceDesk.Comment, STAFF_DESK_STATUS.MOVED);
                        }

                        //_helpersController.SaveHistory(application.Id, sourceStaffID, sourceDesk.ProcessStatus, sourceDesk.Comment, null);
                        _helperService.SaveApplicationHistory(application.Id, sourceStaffID, sourceDesk.ProcessStatus, sourceDesk.Comment, null, false, null, APPLICATION_ACTION.Move);


                        string subject = $"Re-assignment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

                        //Send mail to target Staff
                        string content = "Application with REF : " + application.ReferenceNo + " was moved from " + sourceStaff.LastName + ", " + sourceStaff.FirstName + "'s desk to " + targetStaff.LastName + ", " + targetStaff.FirstName;
                        var emailMsg = _helperService.SaveMessage(application.Id, targetStaffID, subject, content, "Staff");
                        //var sendEmail = _helperService.SendEmailMessage(targetStaff.StaffEmail, targetStaff.LastName + ", " + targetStaff.FirstName, emailMsg, null);

                        //Send mail to source staff
                        var emailMsg_Source = _helperService.SaveMessage(application.Id, sourceStaffID, subject, content, "Staff");
                        //var sendEmail_Source = _helperService.SendEmailMessage(sourceStaff.StaffEmail, sourceStaff.LastName + ", " + sourceStaff.FirstName, emailMsg_Source, null);

                        _helperService.LogMessages("Application with REF : " + application.ReferenceNo + " was moved from " + sourceStaff.LastName + ", " + sourceStaff.FirstName + "'s desk to " + targetStaff.LastName + ", " + targetStaff.FirstName);
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been moved successfully.", StatusCode = ResponseCodes.Success };
                    }
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error: No application ID was passed for this action to be completed.", StatusCode = ResponseCodes.InternalError };
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error: No application ID was passed for this action to be completed.", StatusCode = ResponseCodes.InternalError };
            }
            catch (Exception x)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"An error occured while pushing application to staff." + x.Message.ToString(), StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> IsApplicationReturned(int appId)
        {
            try
            {
                var rApp = await _dbContext.ReturnedApplications.Include(x => x.Application).Include(x => x.Staff).Where(x => x.AppId== appId).FirstOrDefaultAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = rApp != null? true: false, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: {e.Message.ToString()}", StatusCode = ResponseCodes.InternalError };
            }
        }

        public async Task<WebApiResponse> ReturnApplicationToStaff(int deskID, string comment, string[] selectedApps, string[] SBU_IDs, string[] selectedTables, bool fromWPAReviewer, int WKPCompanyNumber, string WKPCompanyName, string WKPCompanyEmail)
        {
            try
            {
                if (selectedApps != null)
                {
                    var SBU_IDs_int = _helperService.ParseSBUIDs(SBU_IDs);


                    foreach (var b in selectedApps)
                    {
                        int appId = b != "undefined" ? int.Parse(b) : 0;

                        var LoggedInStaff = (from stf in _dbContext.staff
                                             join admin in _dbContext.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                             join role in _dbContext.Roles on stf.RoleID equals role.id
                                             where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                             select stf).FirstOrDefault();

                        var staffDesk = _dbContext.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();
                        var application = _dbContext.Applications.Where(a => a.Id == appId).FirstOrDefault();
                        var Company = _dbContext.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();
                        var concession = await (from d in _dbContext.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == application.ConcessionID select d).FirstOrDefaultAsync();

                        var LoggedInStaffSBU = _dbContext.StrategicBusinessUnits.Where<StrategicBusinessUnit>(s => s.Id == LoggedInStaff.Staff_SBU).FirstOrDefault();
                        var LoggedInStaffRole = _dbContext.Roles.Where<Role>(r => r.id == LoggedInStaff.RoleID).FirstOrDefault();

                        //Determine if the app is on a reviewer's desk
                        var appStatus = application.Status;

                        if ((LoggedInStaffSBU?.Tier == PROCESS_TIER.TIER1 || LoggedInStaffSBU?.Tier == PROCESS_TIER.TIER2) && fromWPAReviewer != true)
                        {
                            var staffWithAppOnDesk = (from stf in _dbContext.staff where stf.StaffID == staffDesk.StaffID select stf).FirstOrDefault();
                            var staffWithAppOnDeskSBU = await (from sb in _dbContext.StrategicBusinessUnits where sb.Id == staffWithAppOnDesk.Staff_SBU select sb).FirstOrDefaultAsync();

                            var targetDesk = await _dbContext.MyDesks.Where(x => x.StaffID == staffDesk.FromStaffID && x.AppId == appId).FirstOrDefaultAsync();

                            targetDesk.HasWork = true;
                            targetDesk.UpdatedAt = DateTime.Now;
                            targetDesk.Comment = comment;
                            targetDesk.ProcessStatus = APPLICATION_HISTORY_STATUS.ReturnedToStaff;
                            _dbContext.MyDesks.Update(targetDesk);

                            string returnedTables = await _processFlowService.getTableNames(selectedTables);
                            await _helperService.UpdateDeskAfterReject(staffDesk, comment, APPLICATION_HISTORY_STATUS.ReturnedToStaff);

                            await _dbContext.SaveChangesAsync();

                            _helperService.SaveApplicationHistory(application.Id, LoggedInStaff.StaffID, APPLICATION_HISTORY_STATUS.ReturnedToStaff, comment, returnedTables, false, null, APPLICATION_ACTION.ReturnToStaff);

                            //Sending email
                            string subject = $"Comment for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                            string content = $"{staffWithAppOnDeskSBU?.SBU_Name} made comment on the WORK PROGRAM application with Reference Number: {application.ReferenceNo}. See comment :- " + comment;
                            var emailMsg = _helperService.SaveMessage(application.Id, Company.Id, subject, content, "Company");
                            //var sendEmail = _helperService.SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);

                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"The Application {concession.Concession_Held} has been returned to staff.", StatusCode = ResponseCodes.Success };
                        }
                        else if (fromWPAReviewer == true)
                        {
                            var finalAuthorityApprovals = _dbContext.ApplicationSBUApprovals.Where(x => x.AppId == appId).ToList();
                            var finalAuthorityDesks = new List<MyDesk>();

                            foreach (var a in finalAuthorityApprovals)
                            {
                                foreach(var s in SBU_IDs_int)
                                {
                                    var apr = finalAuthorityApprovals.Find(x => x.SBUID == s);
                                    var tempDesk = await _dbContext.MyDesks.Where(x => x.DeskID == apr.DeskID).FirstOrDefaultAsync();
                                    finalAuthorityDesks.Add(tempDesk);
                                }
                            }

                            if (finalAuthorityDesks != null && finalAuthorityDesks.Count > 0)
                            {
                                foreach (var desk in finalAuthorityDesks)
                                {
                                    desk.HasWork = true;
                                    desk.UpdatedAt = DateTime.Now;
                                    desk.Comment = comment;
                                    desk.ProcessStatus = APPLICATION_HISTORY_STATUS.ReturnedToStaff;
                                    _dbContext.MyDesks.Update(desk);

                                    await _helperService.UpdateDeskAfterReject(staffDesk, comment, APPLICATION_HISTORY_STATUS.ReturnedToStaff);
                                    _helperService.SaveApplicationHistory(application.Id, LoggedInStaff.StaffID, APPLICATION_HISTORY_STATUS.ReturnedToStaff, comment, null, false, null, APPLICATION_ACTION.ReturnToStaff);
                                    _helperService.UpdateApprovalTable(appId, comment, desk.StaffID, desk.DeskID, APPLICATION_HISTORY_STATUS.ReturnedToStaff);

                                    await _dbContext.SaveChangesAsync();

                                    //sending mail to staff
                                    var staffWithAppOnDesk = await _dbContext.staff.Where(x => x.StaffID == desk.StaffID).FirstOrDefaultAsync();
                                    string subject = $"Returned WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                    string content = $"{WKPCompanyName} returned WORK PROGRAM application for year {application.YearOfWKP} with Reference Number {application.ReferenceNo}.";
                                    var emailMsg = _helperService.SaveMessage(application.Id, staffWithAppOnDesk.StaffID, subject, content, "Staff");
                                    //var sendEmail = _helperService.SendEmailMessage(staffWithAppOnDesk.StaffEmail, staffWithAppOnDesk.FirstName, emailMsg, null);
                                    _helperService.LogMessages("Returned application with REF : " + application.ReferenceNo, WKPCompanyEmail);
                                }

                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application(s) has been sent back successfully.", StatusCode = ResponseCodes.Success };
                            }
                            else
                            {
                                return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = $"Error: No application ID was passed for this action to be completed.", StatusCode = ResponseCodes.Badrequest };
                            }
                        }
                        //else
                        //{
                        //    var prevDesk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == staffDesk.FromStaffID && d.AppId == appId).FirstOrDefaultAsync();

                        //    if (SBU_IDs_int != null && SBU_IDs_int.Length > 0)
                        //    {
                        //        foreach (var SBU in SBU_IDs_int)
                        //        {
                        //            if (SBU > 0)
                        //            {
                        //                prevDesk = (from dsk in _context.MyDesks
                        //                            join stf in _context.staff on dsk.StaffID equals stf.StaffID
                        //                            where stf.StaffID == staffDesk.FromStaffID && dsk.AppId == appId && stf.Staff_SBU == SBU && dsk.FromSBU == staffDesk.FromSBU && stf.DeleteStatus != true
                        //                            select dsk).FirstOrDefault();

                        //                if (prevDesk != null)
                        //                {
                        //                    prevDesk.HasPushed = false;
                        //                    prevDesk.HasWork = true;
                        //                    prevDesk.UpdatedAt = DateTime.Now;
                        //                    prevDesk.Comment = comment;
                        //                    prevDesk.ProcessStatus = STAFF_DESK_STATUS.REJECTED;
                        //                    _context.SaveChanges();
                        //                }
                        //                else
                        //                {
                        //                    var desk = new MyDesk()
                        //                    {
                        //                        StaffID = (int)staffDesk.FromStaffID,
                        //                        AppId = appId,
                        //                        HasWork = true,
                        //                        HasPushed = true,
                        //                        FromStaffID = staffDesk.FromStaffID,
                        //                        FromSBU = staffDesk.FromSBU,
                        //                        FromRoleId = staffDesk.FromRoleId,
                        //                        CreatedAt = DateTime.Now,
                        //                        UpdatedAt = DateTime.Now,
                        //                        Comment = comment,
                        //                        LastJobDate = DateTime.Now,
                        //                        ProcessStatus = STAFF_DESK_STATUS.REJECTED,
                        //                    };

                        //                    await _context.MyDesks.AddAsync(desk);
                        //                }

                        //                //var result = await _helpersController.DeleteDeskIdByDeskId(deskID);

                        //                await _helpersController.UpdateDeskAfterReject(staffDesk, comment, STAFF_DESK_STATUS.REJECTED);

                        //                //_helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, GeneralModel.SentBackToStaff, comment, null);
                        //                _helperService.SaveApplicationHistory(application.Id, get_CurrentStaff.StaffID, GeneralModel.SentBackToStaff, comment, null, false, null, GeneralModel.SendBackToStaff);

                        //                //send mail to staff
                        //                var getStaff = (from stf in _context.staff
                        //                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                        //                                where stf.StaffID == prevDesk.StaffID && stf.DeleteStatus != true
                        //                                select stf).FirstOrDefault();

                        //                string subject = $"Sent back WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

                        //                string content = $"{WKPCompanyName} sent back WORK PROGRAM application for year {application.YearOfWKP}.";

                        //                var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");

                        //                var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                        //                _helpersController.LogMessages("Sent back application with REF : " + application.ReferenceNo, WKPCompanyEmail);

                        //            }
                        //        }
                        //        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application(s) has been sent back successfully.", StatusCode = ResponseCodes.Success };
                        //    }
                        //    else
                        //    {
                        //        if (prevDesk != null)
                        //        {
                        //            prevDesk.HasPushed = false;
                        //            prevDesk.HasWork = true;
                        //            prevDesk.UpdatedAt = DateTime.Now;
                        //            prevDesk.Comment = comment;
                        //            prevDesk.ProcessStatus = STAFF_DESK_STATUS.REJECTED;
                        //            _context.SaveChanges();
                        //        }
                        //        else
                        //        {
                        //            var desk = new MyDesk()
                        //            {
                        //                StaffID = (int)staffDesk.FromStaffID,
                        //                AppId = appId,
                        //                HasWork = true,
                        //                HasPushed = true,
                        //                FromStaffID = staffDesk.FromStaffID,
                        //                FromSBU = staffDesk.FromSBU,
                        //                FromRoleId = staffDesk.FromRoleId,
                        //                CreatedAt = DateTime.Now,
                        //                UpdatedAt = DateTime.Now,
                        //                Comment = comment,
                        //                LastJobDate = DateTime.Now,
                        //                ProcessStatus = STAFF_DESK_STATUS.REJECTED,
                        //            };

                        //            await _context.MyDesks.AddAsync(desk);

                        //            prevDesk = desk;
                        //        }

                        //        //var result = await _helpersController.DeleteDeskIdByDeskId(deskID);
                        //        await _helpersController.UpdateDeskAfterReject(staffDesk, comment, STAFF_DESK_STATUS.REJECTED);

                        //        //_helpersController.SaveHistory(application.Id, get_CurrentStaff.StaffID, GeneralModel.SentBackToStaff, comment, null);
                        //        _helperService.SaveApplicationHistory(application.Id, get_CurrentStaff.StaffID, GeneralModel.SentBackToStaff, comment, null, false, null, GeneralModel.SendBackToStaff);

                        //        //send mail to staff
                        //        var getStaff = (from stf in _context.staff
                        //                        join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                        //                        where stf.StaffID == prevDesk.StaffID && stf.DeleteStatus != true
                        //                        select stf).FirstOrDefault();

                        //        string subject = $"Sent back WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";

                        //        string content = $"{WKPCompanyName} sent back WORK PROGRAM application for year {application.YearOfWKP}.";

                        //        var emailMsg = _helpersController.SaveMessage(application.Id, getStaff.StaffID, subject, content, "Staff");

                        //        var sendEmail = _helpersController.SendEmailMessage(getStaff.StaffEmail, getStaff.FirstName, emailMsg, null);

                        //        _helpersController.LogMessages("Sent back application with REF : " + application.ReferenceNo, WKPCompanyEmail);

                        //        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been sent back successfully.", StatusCode = ResponseCodes.Success };
                        //    }
                        //}


                    }
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.MissingParameter, Message = $"Error: No application ID was passed for this action to be completed.", StatusCode = ResponseCodes.Badrequest };
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"Error: No action was carried out on this application.", StatusCode = ResponseCodes.Badrequest };
            }
            catch (Exception e)
            {
                _helperService.LogMessages($"Approve Error: {e.Message.ToString()}");
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = $"An error occured while rejecting application." + e.Message.ToString(), StatusCode = ResponseCodes.Badrequest };
            }

        }

        //[HttpPost("ApproveApplication")]
        //public async Task<object> ApproveApplication(int deskID, string comment, string[] selectedApps)
        //{
        //    var responseMessage = "";
        //    try
        //    {
        //        foreach (var b in selectedApps)
        //        {
        //            string appID = b.Replace('[', ' ').Replace(']', ' ').Trim();
        //            int appId = int.Parse(appID);
        //            //get current staff desk
        //            var staffDesk = _context.MyDesks.Where(a => a.DeskID == deskID && a.AppId == appId).FirstOrDefault();

        //            var application = _context.Applications.Where(a => a.Id == appId).FirstOrDefault();

        //            var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == application.CompanyID).FirstOrDefault();

        //            var field = _context.COMPANY_FIELDs.Where(p => p.Field_ID == application.FieldID).FirstOrDefault();

        //            //Update Staff Desk
        //            staffDesk.HasPushed = true;
        //            staffDesk.HasWork = true;
        //            staffDesk.UpdatedAt = DateTime.Now;
        //            application.Status = GeneralModel.Approved;
        //            _context.SaveChanges();

        //            var p = _helpersController.CreatePermit(application);

        //            responseMessage += "You have APPROVED this application (" + application.ReferenceNo + ")  and approval has been generated. Approval No: " + p + Environment.NewLine;
        //            //var staff = _context.staff.Where(x => x.StaffID == int.Parse(WKPCompanyId) && x.DeleteStatus != true).FirstOrDefault();
        //            var staff = (from stf in _context.staff
        //                         join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
        //                         where stf.StaffID == int.Parse(WKPCompanyId) && stf.DeleteStatus != true
        //                         select stf).FirstOrDefault();

        //            if (!p.ToLower().Contains("error"))
        //            {

        //                //string body = "";
        //                //var up = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        //                //string file = up + @"\\Templates\" + "InternalMemo.txt";
        //                //using (var sr = new StreamReader(file))
        //                //{
        //                //    body = sr.ReadToEnd();
        //                //}

        //                //send email to staff approver
        //                //_helpersController.SaveHistory(appId, staff.StaffID, GeneralModel.Approved, staff.StaffEmail + "Final Approval For Application With Ref: " + application.ReferenceNo, null);
        //                _helperService.SaveApplicationHistory(application.Id, staff.StaffID, GeneralModel.Approved, staff.StaffEmail + "Final Approval For Application With Ref: " + application.ReferenceNo, null, false, null, GeneralModel.Approve);

        //                string subject = $"Approval For Application With REF: {application.ReferenceNo}";
        //                string content = $"An approval has been generated for application with reference: " + application.ReferenceNo + " for " + field.Field_Name + "(" + Company.NAME + ").";

        //                var emailMsg = _helpersController.SaveMessage(appId, staff.StaffID, subject, content, "Staff");
        //                var sendEmail = _helpersController.SendEmailMessage(staff.StaffEmail, staff.FirstName, emailMsg, null);

        //                _helpersController.LogMessages("Approval generated successfully for field => " + field.Field_Name + ". Application Reference : " + application.ReferenceNo, WKPCompanyEmail);

        //                responseMessage = "Application(s) has been approved and permit approval generated successfully.";
        //            }
        //            else
        //            {
        //                responseMessage += "An error occured while trying to generate approval ref for this application." + Environment.NewLine;

        //                //Update My Process
        //                staffDesk.HasPushed = false;
        //                staffDesk.HasWork = false;
        //                staffDesk.UpdatedAt = DateTime.Now;
        //                _context.SaveChanges();
        //            }
        //            return BadRequest(new { message = responseMessage });
        //        }
        //        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = responseMessage, StatusCode = ResponseCodes.Success };
        //    }
        //    catch (Exception x)
        //    {
        //        _helpersController.LogMessages($"Approve Error:: {x.ToString()}");
        //        return BadRequest(new { message = $"An error occured while approving application(s)." });
        //    }

        //}

    }
}
