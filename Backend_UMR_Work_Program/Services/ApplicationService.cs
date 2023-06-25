using AutoMapper;
using Backend_UMR_Work_Program.Controllers;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;
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

        public async Task<object> GetSendBackComments(int appId)
        {
            try
            {
                var comments = await _dbContext.ApplicationDeskHistories
                    .Include(x => x.Staff)
                    .Include(x => x.Company)
                    .Where(
                        x => x.AppId == appId 
                        && x.Status != null 
                        && x.Status == GeneralModel.APPLICATION_STATUS.SentBackToCompany
                        ).OrderByDescending(x => x.ActionDate).ToListAsync();

                return comments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCommentToApplication(int appId, int? staffId, string? status, string comment, string? selectedTables, bool? actionByCompany, int? companyId)
        {
            try
            {
                _helperService.SaveApplicationHistory(appId, staffId, status, comment, selectedTables, actionByCompany, companyId, GeneralModel.PROCESS_CONSTANTS.AddAComment);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> HasApplicationBeenSubmittedBefore(int yearID, COMPANY_FIELD field, ADMIN_CONCESSIONS_INFORMATION concession)
        {
            var app = new Application();
            var listOfNonSubmittedStatus = new List<string> { GeneralModel.APPLICATION_STATUS.SubmissionByCompany, GeneralModel.APPLICATION_STATUS.PaymentPending};

            try
            {
                if (field != null)
                {
                    app = await _dbContext.Applications.Where<Application>(
                        a => a.YearOfWKP == yearID 
                        && a.ConcessionID == concession.Consession_Id 
                        && a.FieldID == field.Field_ID 
                        && listOfNonSubmittedStatus.Contains(a.Status)
                        ).FirstOrDefaultAsync();
                }
                else
                {
                    app = await _dbContext.Applications.Where<Application>(a => a.YearOfWKP == yearID && a.ConcessionID == concession.Consession_Id).FirstOrDefaultAsync();
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
                            GeneralModel.APPLICATION_STATUS.SubmissionByCompany);

                        if (saveStaffDesk > 0)
                        {
                            _helperService.SaveApplicationHistory(app.Id, staff.StaffID, 
                                GeneralModel.APPLICATION_STATUS.SubmissionByCompany, 
                                "Application submitted and landed on staff desk", 
                                null, false, null, GeneralModel.PROCESS_CONSTANTS.Submit);

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

                    app.Status = GeneralModel.APPLICATION_STATUS.SubmissionByCompany;
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
                        var getApplicationProcess = await _helperService.GetApplicationProccessBySBUAndRole(GeneralModel.PROCESS_CONSTANTS.Push, (int)staffRoleId, (int)staffSBUId);
                        var getApplicationProcessEC = await _helperService.GetApplicationProccessBySBUAndRole(GeneralModel.PROCESS_CONSTANTS.ApprovedByEC, (int)staffRoleId, (int)staffSBUId);

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
                                    deskTemp.ProcessStatus = GeneralModel.APPLICATION_STATUS.SubmissionByStaff;

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
                                        ProcessStatus = GeneralModel.APPLICATION_STATUS.SubmissionByStaff,

                                    };

                                    deskTemp = desk;

                                    _dbContext.MyDesks.Add(desk);
                                }

                                var save = await _dbContext.SaveChangesAsync();
                                
                                await _helperService.UpdateDeskAfterPush(staffDesk, comment, GeneralModel.APPLICATION_STATUS.Pushed);

                                _helperService.SaveApplicationHistory(application.Id, staffActing.StaffID, GeneralModel.APPLICATION_STATUS.Pushed, comment, null, false, null, GeneralModel.PROCESS_CONSTANTS.Push);
                                //_helperService.SaveApplicationHistory(application.Id, staffActing.StaffID, GeneralModel.APPLICATION_STATUS.Pushed, comment, null, false, null, GeneralModel.PROCESS_CONSTANTS.Push);

                                string subject = $"Push for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"{Company.COMPANY_NAME} have submitted their WORK PROGRAM application for year {application.YearOfWKP}.";
                                var emailMsg = _helperService.SaveMessage(application.Id, staffActing.StaffID, subject, content, "Staff");
                                // var sendEmail = _helperService.SendEmailMessage(staffActing.StaffEmail, staffActing.FirstName, emailMsg, null);

                                _helperService.LogMessages("Submission of application with REF : " + application.ReferenceNo, Company.EMAIL);
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
                                    deskTemp1.ProcessStatus = GeneralModel.APPLICATION_STATUS.ApprovalByFinalAuthority;

                                    _dbContext.Update(deskTemp1);
                                }
                                else
                                {
                                    deskTemp1 = _dbContext.MyDesks.Where(x => x.StaffID == deskTemp1.StaffID && x.AppId == deskTemp1.AppId && x.HasWork == true).FirstOrDefault();
                                }

                                var save = await _dbContext.SaveChangesAsync();

                                await _helperService.UpdateDeskAfterPush(staffDesk, comment, GeneralModel.APPLICATION_STATUS.Approved);

                                _helperService.SaveApplicationHistory(application.Id, staffActing.StaffID, GeneralModel.APPLICATION_STATUS.Approved, comment, null, false, null, GeneralModel.PROCESS_CONSTANTS.ApprovedByEC);

                                //Todo: Update EC Approvals Table
                                await _helperService.UpdateApprovalTable(application.Id, comment, staffDesk.StaffID, staffDesk.DeskID, GeneralModel.APPLICATION_STATUS.ApprovalByFinalAuthority);

                                string subject = $"Push for WORK PROGRAM application with ref: {application.ReferenceNo} ({concession.Concession_Held} - {application.YearOfWKP}).";
                                string content = $"{Company.COMPANY_NAME} have submitted their WORK PROGRAM application for year {application.YearOfWKP}.";
                                var emailMsg = _helperService.SaveMessage(application.Id, staffActing.StaffID, subject, content, "Staff");
                                // var sendEmail = _helperService.SendEmailMessage(staffActing.StaffEmail, staffActing.FirstName, emailMsg, null);

                                _helperService.LogMessages("Submission of application with REF : " + application.ReferenceNo, Company.EMAIL);
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = $"Application for concession {concession.Concession_Held} has been pushed successfully.", StatusCode = ResponseCodes.Success };
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

                var currentStaff = (from stf in _dbContext.staff
                                join admin in _dbContext.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                where stf.AdminCompanyInfo_ID == WKPCompanyNumber && stf.DeleteStatus != true
                                select stf).FirstOrDefault();

                if (currentStaff != null)
                {
                    deskCount = await _dbContext.MyDesks.Where(x => x.StaffID == currentStaff.StaffID && x.HasWork == true).CountAsync();
                    allProcessingCount = await _dbContext.MyDesks.Where(x => x.StaffID == currentStaff.StaffID && x.HasWork == true && x.ProcessStatus == GeneralModel.APPLICATION_STATUS.Processing).CountAsync();
                    allApplicationsCount = (await _dbContext.MyDesks.Include(s => s.Staff).Where(x => x.HasWork && x.Staff.Staff_SBU == currentStaff.Staff_SBU).ToListAsync()).DistinctBy(x => x.AppId).Count();
                }
                
                allApprovalsCount = await _dbContext.PermitApprovals.CountAsync();
                var data = new
                {
                    deskCount = deskCount,
                    allApplicationsCount = allApplicationsCount,
                    allProcessingCount = allProcessingCount,
                    allApprovalsCount = allApprovalsCount
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
                    var validStatues = new List<string> { GeneralModel.APPLICATION_STATUS.SubmissionByCompany, GeneralModel.APPLICATION_STATUS.PaymentPending, GeneralModel.PROCESS_CONSTANTS.Submitted };
                    var apps = new List<Application>();

                    if(fieldId != 0)
                        apps = await _dbContext.Applications.Where(x => x.YearOfWKP == year && x.ConcessionID == concessionId && x.FieldID == fieldId).ToListAsync();
                    else
                        apps = await _dbContext.Applications.Where(x => x.YearOfWKP == year && x.ConcessionID == concessionId).ToListAsync();

                    var submittedApp = apps.FirstOrDefault(x => validStatues.Contains(x.Status));

                    if(submittedApp != null)
                    {
                        var sendBackToCompanyAppHistory = await _dbContext.ApplicationDeskHistories.Where(x => x.AppId == submittedApp.Id && x.Status == GeneralModel.APPLICATION_STATUS.SentBackToCompany).FirstOrDefaultAsync();
                        var selectedTables = sendBackToCompanyAppHistory?.SelectedTables.Split('|').ToList();

                        var res = new FormLock
                        {
                            disableSubmission = submittedApp != null,
                            enableReSubmission = sendBackToCompanyAppHistory != null && sendBackToCompanyAppHistory.Status == GeneralModel.APPLICATION_STATUS.SendBackToCompany && sendBackToCompanyAppHistory.Status == GeneralModel.APPLICATION_STATUS.PaymentPending ? true : false,
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

        // public async Task<bool> OpenApplication(int appId, int staffId)
        // {

        // }
    }
}
