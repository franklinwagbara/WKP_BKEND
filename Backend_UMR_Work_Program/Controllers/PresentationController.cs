using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;
using static Backend_UMR_Work_Program.Models.ViewModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]

    public class PresentationController : ControllerBase
    {
        private Presentation _presentation;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        IMapper _mapper;
        private BlobService blobService;
        public PresentationController(Presentation presentation, WKP_DBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper, BlobService blobservice)
        {
            _presentation = presentation;
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            this.blobService = blobservice;
        }

        //private string? WKPUserId => "1";
        //private string? WKPUserName => "Name";
        //private string? WKPUserEmail => "adeola.kween123@gmail.com";
        //private string? WKPUserRole => "Admin";
        private string? WKPUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPUserName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPUserEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKPUserRole => User.FindFirstValue(ClaimTypes.Role);
        private int? WKPUserNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));



        [HttpGet("GetCompanyDetails")]
        public object CompanyDetails(string companyName, string companyEmail, string companyId)
        {
            try
            {

                //var details = _context.ADMIN_COMPANY_INFORMATIONs.Where(q => q.EMAIL==companyEmail || q.COMPANY_ID==companyId).FirstOrDefault();

                var details = _context.ADMIN_COMPANY_DETAILs.Where(q => q.CompanyId.Trim().ToUpper() == companyId.Trim().ToUpper() || q.COMPANY_NAME.ToLower().Trim() == companyName.ToLower().Trim()).FirstOrDefault();
                //var details = _presentation.CompanyDetails(companyName, companyEmail, companyId);

                if (details == null) details = new ADMIN_COMPANY_DETAIL();


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = details, StatusCode = ResponseCodes.Success };

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("EditCompanyDetails")]
        public object EditCompanyDetails([FromBody] CompanyDetail myDetail)
        {
            try
            {

                var details = _context.ADMIN_COMPANY_DETAILs.Where(a => a.COMPANY_NAME == myDetail.CompanyName).FirstOrDefault();
                if (details != null)
                {

                    details.Address_of_Company = myDetail.Address_of_Company;
                    details.Phone_NO_of_MD_CEO = myDetail.Phone_NO_of_MD_CEO;
                    details.Name_of_MD_CEO = myDetail.Name_of_MD_CEO;
                    details.Contact_Person = myDetail.Contact_Person;
                    details.Email_Address = myDetail.Email_Address;
                    details.Phone_No = myDetail.Phone_No;

                }
                else
                {
                    var companyDetail = new ADMIN_COMPANY_DETAIL
                    {
                        Address_of_Company = myDetail.Address_of_Company,
                        //companyDetail.CompanyNumber=myDetail.CompanyId;
                        Phone_NO_of_MD_CEO = myDetail.Phone_NO_of_MD_CEO,
                        Name_of_MD_CEO = myDetail.Name_of_MD_CEO,
                        Contact_Person = myDetail.Contact_Person,
                        Email_Address = myDetail.Email_Address,
                        Phone_No = myDetail.Phone_No,
                        Phone_No_alt = myDetail.Phone_No_alt,
                        COMPANY_NAME = myDetail.CompanyName,
                        Created_by = WKPUserEmail,
                        Date_Created = DateTime.Now.ToLongDateString(),
                        EMAIL = myDetail.CompanyEmail,
                        CompanyId = myDetail.CompanyId
                    };


                    _context.ADMIN_COMPANY_DETAILs.Add(companyDetail);
                }

                if (_context.SaveChanges() > 0)
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };


                }



            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }

            return null;

        }

        [HttpGet("GET_PRESENTATION_DATETIME")]
        public async Task<object> GET_PRESENTATION_DATETIME()
        {
            var schedule = await _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.COMPANY_ID == WKPUserId && c.YEAR == DateTime.Now.Year.ToString()).FirstOrDefaultAsync();
            return schedule;
        }

        [HttpGet("GET_PRESENTATION_DATETIMES")]
        public async Task<object> GET_PRESENTATION_DATETIMES()
        {
            var schedule = await _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.COMPANY_ID == WKPUserId && c.YEAR == DateTime.Now.Year.ToString()).ToListAsync();
            return schedule;
        }
        //Added by Musa 
        [HttpGet("Get_StartAndEndDates")]
        public async Task<StartAndEndDateDto> Get_StartAndEndDates()
        {
            try
            {
                var data = await _context.ADMIN_WP_START_END_DATEs?.FirstOrDefaultAsync();

                if (data == null)
                {
                    return null;
                }

                var startnEndDate = new StartAndEndDateDto()
                {
                    start_date = data.start_date,
                    end_date = data.end_date

                    //2022 - 12 - 17
                };
                //var response = new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = data, StatusCode = ResponseCodes.Success };
                return startnEndDate = startnEndDate;
            }
            catch (Exception e)
            {
                throw e;
                //return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("SCHEDULEPRESENTATION")]
        public async Task<WebApiResponse> SCHEDULE_PRESENTATION_DATETIME(string time, DateTime date)
        {


            try
            {
                if(time !=null && date != null)
                {
                    var CurrentYear = DateTime.Now.Year.ToString();
                    string Date_Conversion = date.ToString("dddd , dd MMMM yyyy");

                    var checkSchedule = _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.wp_date == Date_Conversion && c.wp_time == time).FirstOrDefault();

                    if (checkSchedule != null)
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Sorry, date and time have already been selected by another company. Kindly select another day and/or time.", StatusCode = ResponseCodes.Failure };
                    }
                    else
                    {
                        var presentation = new ADMIN_DATETIME_PRESENTATION()
                        {
                            COMPANYNAME = WKPUserName,
                            COMPANYEMAIL = WKPUserEmail,
                            COMPANY_ID = WKPUserId,
                            YEAR = CurrentYear,
                            CREATED_BY = WKPUserEmail,
                            wp_date = Date_Conversion,
                            DATE_TIME_TEXT = Date_Conversion,
                            wp_time = time,
                            Histories = new List<EnagementScheduledHistory>
                        {
                            new EnagementScheduledHistory() { actionBy = WKPUserEmail, wp_date = Date_Conversion, wp_time = time, MEETINGROOM = "Not Yet Selected"}
                        }
                        };

                        // var engagement = new EnagementScheduledHistory() { actionBy = WKPUserEmail, wp_date = presentation.wp_date, wp_time = presentation.wp_time };

                        // presentation.Histories.Add(engagement);
                        _context.ADMIN_DATETIME_PRESENTATIONs.Add(presentation);
                        // _context.EnagementScheduledHistorys.Add(engagement);

                        var myTime = await _context.SaveChangesAsync();


                        if (myTime > 0)
                        {
                            var companyPresentations = _context.ADMIN_DATETIME_PRESENTATIONs.Where(x => x.COMPANY_ID == WKPUserId).ToListAsync();
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "A presentation schedule was created successfully.", Data = companyPresentations, StatusCode = ResponseCodes.Success };
                        }
                        else
                        {
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while trying to create this presentation schedule.", StatusCode = ResponseCodes.Failure };

                        }
                    }
                }


                //var checkCompanySchedule = _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.COMPANY_ID == WKPUserId && c.YEAR == CurrentYear).FirstOrDefault();

                //if (checkCompanySchedule != null)
                //{
                //    string Date_Conversion1 = date.ToString("dddd , dd MMMM yyyy");
                //    checkCompanySchedule.wp_date = Date_Conversion1;
                //    checkCompanySchedule.DATE_TIME_TEXT = Date_Conversion1;
                //    checkCompanySchedule.wp_time = time;
                //    checkCompanySchedule.Updated_by = WKPUserEmail;
                //    _context.Entry(checkCompanySchedule).State = EntityState.Modified;
                //    await _context.SaveChangesAsync();

                //    var companyPresentations = _context.ADMIN_DATETIME_PRESENTATIONs.Where(x => x.COMPANY_ID == WKPUserId).ToListAsync();
                //    return new WebApiResponse { ResponseCode = "200", Message = "A presentation schedule was created successfully.", Data = companyPresentations, StatusCode = 200 };


                //    //schedule already exist for company
                //    //return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "There is an existing presentation schedule for this year.", StatusCode = ResponseCodes.Failure };

                //}
                //else
                //{

                //check if date has been scheduled by another company

                // }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Invalid entry.", StatusCode = ResponseCodes.Failure };

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
        }



        //Added by Musa

        [HttpPost("GET_UPLOAD_PRESENTATION")]
        public async Task<WebApiResponse> GET_PRESENTATION_DOCUMENT(string year)
        {
            try
            {
                var CurrentYear = DateTime.Now.Year.ToString();

                var checkCompanyPresentation = await _context.PRESENTATION_UPLOADs.Where(c => c.COMPANY_ID == WKPUserId && c.Year_of_WP == year).ToListAsync();


                //check if date has been scheduled by another company
                if (checkCompanyPresentation.Count > 0)
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "successful", Data = checkCompanyPresentation, StatusCode = ResponseCodes.Success };
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Sorry, document is empty.", StatusCode = ResponseCodes.Failure };

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpDelete("DELETE_UPLOAD_PRESENTATION")]
        public async Task<WebApiResponse> DELETE_PRESENTATION_DOCUMENT(string year)
        {
            try
            {
                var CurrentYear = DateTime.Now.Year.ToString();

                var getPresentation = await _context.PRESENTATION_UPLOADs.Where(c => c.COMPANY_ID == WKPUserId && c.Year_of_WP == year).FirstOrDefaultAsync();


                //check if date has been scheduled by another company
                if (getPresentation == null)
                {

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "No Record Found", StatusCode = ResponseCodes.Failure };
                }
                _context.PRESENTATION_UPLOADs.Remove(getPresentation);
                var save = await _context.SaveChangesAsync();
                if (save > 0)
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Successfu", Data = getPresentation, StatusCode = ResponseCodes.Failure };
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Sorry, an error occured.", StatusCode = ResponseCodes.Failure };

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpPost("UPLOADPRESENTATION")]
        public async Task<WebApiResponse> UPLOAD_PRESENTATION_DOCUMENT(string year, IFormFile document)
        {
            try
            {
                var CurrentYear = DateTime.Now.Year.ToString();
                var checkCompanyPresentation = _context.PRESENTATION_UPLOADs.Where(c => c.COMPANY_ID == WKPUserId && c.Year_of_WP == year).FirstOrDefault();

                //Commented by Musa Sule to enable multiple uploads

                //if (checkCompanyPresentation != null)
                //{
                //schedule already exist for company
                //return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "You have already uploaded a presentation for the selected year, kindly delete an existing document to upload another.", StatusCode = ResponseCodes.Failure };
                //}
                //else
                //{

                //check if date has been scheduled by another company
                var system_date = DateTime.Now.ToString(); // 
                if (document != null)
                {

                    var blobname1 = blobService.Filenamer(document);
                    var uploadedDocument = await blobService.UploadFileBlobAsync("documents", document.OpenReadStream(), document.ContentType, $"Presentations/{blobname1}", "PRESENTATION", (int)WKPUserNumber, int.Parse(year));

                    if (uploadedDocument == null)
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while trying to upload presentation document.", StatusCode = ResponseCodes.Failure };
                    }


                    var fileSplitArray = document.FileName.Split(".");


                    string document_FileExtension = fileSplitArray[fileSplitArray.Length - 1].Trim();

                    var PPTX = "pptx";
                    var PPT = "ppt";

                    if (document_FileExtension.ToLower() != PPTX.ToLower() /*|| document_FileExtension.ToLower()!=PPT.ToLower()*/)
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Only pptx or ppt are allowed. Please select Presentation file", StatusCode = ResponseCodes.Failure };
                    }


                    var presentation = new PRESENTATION_UPLOAD()
                    {
                        CompanyName = WKPUserName,
                        Companyemail = WKPUserEmail,
                        COMPANY_ID = WKPUserId,
                        Year_of_WP = year,
                        uploaded_presentation = uploadedDocument,
                        upload_extension = "." + document_FileExtension,
                        original_filemane = document.FileName.Split(".")[0].Trim(),
                        Created_by = WKPUserEmail,
                        Date_Created = DateTime.Now,
                    };

                    _context.PRESENTATION_UPLOADs.Add(presentation);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var companyPresentations = await _context.PRESENTATION_UPLOADs.Where(x => x.COMPANY_ID == WKPUserId /*&& x.Year_of_WP == CurrentYear*/).ToListAsync();

                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "File uploaded successfully.", Data = companyPresentations, StatusCode = ResponseCodes.Success };
                    }
                    //else
                    //{
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while trying to create this presentation schedule.", StatusCode = ResponseCodes.Failure };

                    //}
                }
                //else
                //{
                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Sorry, document is empty.", StatusCode = ResponseCodes.Failure };

                //}
                //}

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpPost("PRESENTATION_SCRIBES")]
        public async Task<WebApiResponse> Presentation_scribe(int[] Id, string emailStatus, string year)
        {
            int save = 0;
            var details = await _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.YEAR == year).ToListAsync();
            if (details.Count > 0)
            {
                try
                {
                    if (WKPUserRole == GeneralModel.Admin)
                    {
                        foreach (var select in Id)
                        {
                            var selected = details.Find(c => c.Id == select);
                            if (selected != null)
                            {
                                if (emailStatus == "Active" && selected.EMAIL_REMARK != "Successful" || emailStatus == "Active" && selected.EMAIL_REMARK != null)
                                {
                                    selected.EMAIL_REMARK = "Successful";
                                }
                                else if (emailStatus == "Inactive" && selected.EMAIL_REMARK == "Successful" || emailStatus == "Inactive" && selected.EMAIL_REMARK == null)
                                {
                                    selected.EMAIL_REMARK = emailStatus.ToUpper();
                                }
                            }
                        }
                    }
                    else
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };
                    }
                    save = await _context.SaveChangesAsync();
                    if (save > 0)
                    {
                        string message = "Email updated successfully.";
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = message, Data = details, StatusCode = ResponseCodes.Success };
                    }
                }
                catch (Exception ex)
                {

                    return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.Badrequest };
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };
            }
            else
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "No data found", StatusCode = ResponseCodes.RecordNotFound };

            }
        }

        [HttpGet("SCRIBES_YEARLIST")]
        public async Task<object> Get_Scribes_And_Chairmen_Yearlist()
        {
            try
            {
                var yearlist = await (from a in _context.ADMIN_DATETIME_PRESENTATIONs where a.isDeleted != true && a.YEAR != "" orderby a.YEAR select a.YEAR).Distinct().ToListAsync();
                return yearlist;
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("SCRIBES_&_CHAIRMEN")]
        public async Task<WebApiResponse> scribes(string year)
        {
            var presentYear = DateTime.Now.Year;

            var details = new List<ADMIN_DATETIME_PRESENTATION>();
            try
            {
                if (WKPUserRole == GeneralModel.Admin)
                {
                    details = await _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.YEAR == year && c.isDeleted != true).ToListAsync();
                }
                else
                {
                    details = await _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.YEAR == year && c.COMPANY_ID == WKPUserId && c.isDeleted != true).ToListAsync();
                }

                //var presentationDetails =
                //        from presentation in details
                //        join history in _context.EnagementScheduledHistorys on presentation.Id equals history.PresentationId
                //        select new { Id= presentation.Id, presentation = presentation, history = history };





                //var _details = await _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.YEAR == year && c.COMPANY_ID == WKPUserId).ToListAsync
                // var oo=    _context.EnagementScheduledHistorys.Where(a => a.PresentationId == details[0].Id);
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.Success };
            }


        }



        [HttpPatch("DELETE_SCHEDULE_PRESENTATION_DATETIME")]
        public async Task<WebApiResponse> DELETE_SCHEDULE_PRESENTATION_DATETIME(int Id)
        {
            try
            {
                var checkSchedule = _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.Id == Id).FirstOrDefault();

                if (checkSchedule != null)
                {

                    if(checkSchedule?.Histories.Count>1)
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "This Engagement has activities and can't be deleted", StatusCode = ResponseCodes.Success };


                    checkSchedule.isDeleted = true;
                    _context.ADMIN_DATETIME_PRESENTATIONs.Update(checkSchedule);
                    var myTime = await _context.SaveChangesAsync();


                    if (myTime > 0)
                    {
                       
                        string successMsg = Messager.ShowMessage(GeneralModel.Delete);
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while trying to delete this presentation schedule.", StatusCode = ResponseCodes.Failure };

                    }
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.RecordNotFound, Message = "Schedule record cannot be found", StatusCode = ResponseCodes.RecordNotFound };

            }
            catch (Exception e)
            {
                throw e;
                //return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

       

        [HttpGet("EngagementHistories")]
        public async Task<WebApiResponse> GetEngagementHistories(int Id)
        {

            var histories = new List<EnagementScheduledHistory>();
            try
            {
                if (Id > 0 || Id != null)
                {
                    histories = await _context.EnagementScheduledHistorys.Where(c => c.PresentationId == Id).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = histories, StatusCode = ResponseCodes.Success };

                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error : Invalid Id", StatusCode = ResponseCodes.Success };


            }
            catch (Exception ex)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.Success };
            }


        }




        [HttpGet("DIVISIONAL_SCHEDULE_LIST")]
        public async Task<WebApiResponse> Get_Divisional_Schedule_list(string year = null)
        {

            var details = new List<ADMIN_DIVISIONAL_REPS_PRESENTATION>();
            try
            {
                details = await (from a in _context.ADMIN_DIVISIONAL_REPS_PRESENTATIONs select a).ToListAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details.OrderBy(x => x.YEAR), StatusCode = ResponseCodes.Success };
            }
            catch (Exception ex)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.Success };
            }


        }

        [HttpGet("DIVISIONAL_SCHEDULE_BY_YEAR")]
        public async Task<WebApiResponse> Get_Divisional_Schedule_By_Year(string year = null)
        {

            var details = new List<ADMIN_DIVISIONAL_REPS_PRESENTATION>();
            try
            {
                details = await (from a in _context.ADMIN_DIVISIONAL_REPS_PRESENTATIONs where a.YEAR == year select a).ToListAsync();
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details.OrderBy(x => x.YEAR), StatusCode = ResponseCodes.Success };

            }
            catch (Exception ex)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Error : " + ex.Message, StatusCode = ResponseCodes.Success };
            }


        }

        [HttpGet("GET_COMPANY_REP")]
        public async Task<WebApiResponse> Comprep(int Id)
        {

            var details = _context.ADMIN_DATETIME_PRESENTATIONs.FirstOrDefault(c => c.Id == Id);
            if (WKPUserRole == GeneralModel.Admin)
            {
                try
                {
                    if (details != null)
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };
                    }
                }
                catch (Exception ex)
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = ex.Message, StatusCode = ResponseCodes.InternalError };
                }
            }
            return new WebApiResponse { ResponseCode = AppResponseCodes.UserNotFound, Message = "No data found", StatusCode = ResponseCodes.RecordNotFound };
        }

        [HttpGet("DIVISIONAL_YEARLIST")]
        public async Task<object> Get_Divisional_Yearlist()
        {
            try
            {
                var yearlist = await (from a in _context.ADMIN_DIVISIONAL_REPS_PRESENTATIONs where a.YEAR != "" orderby a.YEAR select a.YEAR).Distinct().ToListAsync();
                return yearlist;
            }
            catch (Exception ex)
            {
                return new WebApiResponse
                {
                    ResponseCode = AppResponseCodes.InternalError,
                    Message = "Error : " + ex.Message,
                    StatusCode = ResponseCodes.InternalError
                };
            }
        }

        [HttpGet("COMPANY_REPS")]
        public async Task<object> Get_Company_Replist()
        {
            return await _context.ADMIN_DIVISION_REP_LISTs.ToListAsync();

        }
        [HttpPost("UPDATE_COMPANY_REP")]
        public async Task<WebApiResponse> UpdateRep(int Id, int UpdateId)
        {

            int save = 0;
            var details = _context.ADMIN_DIVISION_REP_LISTs.FirstOrDefault(c => c.Id == Id);
            var compId = _context.ADMIN_DIVISIONAL_REPS_PRESENTATIONs.FirstOrDefault(n => n.Id == UpdateId);
            if (WKPUserRole == GeneralModel.Admin)
            {
                if (details != null && compId != null)
                {
                    try
                    {
                        compId.REPRESENTATIVE = details.DIV_REP_NAME;
                        compId.REPRESENTATIVE_EMAIL = details.DIV_REP_EMAIL;
                        save = await _context.SaveChangesAsync();
                        if (save > 0)
                        {
                            string message = "Company admin representative updated sucessfully";
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = message, Data = compId, StatusCode = ResponseCodes.Success };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = ex.Message, StatusCode = ResponseCodes.InternalError };
                    }
                }
            }
            return new WebApiResponse { ResponseCode = AppResponseCodes.UserNotFound, Message = "No data found", StatusCode = ResponseCodes.RecordNotFound };
        }
        [HttpPost("ACTIVATE_DEACTIVATE_EMAIL")]
        public async Task<WebApiResponse> UpdateEmailStatus(int compId, string option)
        {
            string optionA = "Active";
            string optionB = "Inactive";
            string active = "Successful";
            string inactive = "Inactive";
            int save = 0;
            var dateTimeId = _context.ADMIN_DATETIME_PRESENTATIONs.FirstOrDefault(x => x.Id == compId);
            if (dateTimeId.EMAIL_REMARK == null)
            {
                dateTimeId.EMAIL_REMARK = inactive;
            }
            if (WKPUserRole == GeneralModel.Admin)
            {
                try
                {
                    if (dateTimeId != null)
                    {
                        if (dateTimeId != null && option == optionA && dateTimeId.EMAIL_REMARK.ToLower() != active.ToLower())
                        {
                            dateTimeId.EMAIL_REMARK = active;

                        }
                        if (dateTimeId != null && option == optionB && dateTimeId.EMAIL_REMARK.ToLower() != inactive.ToLower())
                        {
                            dateTimeId.EMAIL_REMARK = inactive.ToUpper();

                        }
                        save = _context.SaveChanges();
                        if (save > 0)
                        {
                            string message = "Company admin representative updated sucessfully";
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = message, Data = compId, StatusCode = ResponseCodes.Success };
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error:" + ex.Message, StatusCode = ResponseCodes.InternalError };

                }

            }
            return new WebApiResponse { ResponseCode = AppResponseCodes.UserNotFound, Message = "Not Successful", StatusCode = ResponseCodes.RecordNotFound };

        }


        [HttpPost("UPLOAD_MOM")]
        public async Task<WebApiResponse> UPLOADMOM(int compId, IFormFile document)
        {

            var userRole = WKPUserRole;
            var userName = WKPUserName;
            var userEmail = WKPUserEmail;
            var companyID = WKPUserId;
            var CurrentYear = DateTime.Now.Year.ToString();
            string folderToSave = "";
            var checkUploadedMom = _context.ADMIN_DATETIME_PRESENTATIONs.Where(c => c.Id == compId).FirstOrDefault();
            try
            {
                if (checkUploadedMom.MOM_UPLOAD_DATE != null)
                {
                    //schedule already exist for company
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "You have already uploaded minutes for the selected year, kindly delete an existing document to upload another.", StatusCode = ResponseCodes.Failure };
                }
                else
                {
                    //check if date has been scheduled by another company
                    var system_date = DateTime.Now.ToString(); // 

                    var uniqueFileName = "";
                    var FileExtension = "";
                    var newFileName = "";
                    var documentPath = "";
                    var fileName = "";
                    var save = 0;

                    if (document != null)
                    {
                        if (document.Length > 0)
                        {
                            var up = Path.Combine(Directory.GetCurrentDirectory(), "Documents");
                            var uploads = Path.Combine(up, "UploadMOMs");
                            fileName = document.FileName.Split(".")[0].Trim();
                            uniqueFileName = Convert.ToString(Guid.NewGuid());
                            FileExtension = document.FileName.Split(".")[1].Trim();

                            newFileName = fileName + "." + FileExtension;


                            documentPath = "//Documents/UploadMOMs/" + newFileName;
                            using (var s = new FileStream(Path.Combine(uploads, newFileName),
                                 FileMode.Create))
                            {
                                document.CopyTo(s);
                            }
                        }
                        checkUploadedMom.MOM = documentPath;
                        checkUploadedMom.MOM_UPLOADED_BY = userEmail;
                        checkUploadedMom.MOM_UPLOAD_DATE = DateTime.Now;
                        save = _context.SaveChanges();
                        if (save > 0)
                        {
                            var companyUploadedmom = _context.ADMIN_DATETIME_PRESENTATIONs.Where(x => x.Id == compId).ToList();

                            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "File uploaded successfully.", Data = companyUploadedmom, StatusCode = ResponseCodes.Success };
                        }
                        else
                        {
                            return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "An error occured while trying to upload this minutes.", StatusCode = ResponseCodes.Failure };

                        }
                    }
                    else
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Sorry, document is empty.", StatusCode = ResponseCodes.Failure };

                    }
                }
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error:" + ex.Message, StatusCode = ResponseCodes.InternalError };

            }
        }
    }
}
