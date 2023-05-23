using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class WorkProgrammeController : ControllerBase
    {
        private Account _account;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        HelpersController _helpersController;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private BlobService blobService;

        public WorkProgrammeController(WKP_DBContext context, IConfiguration configuration, HelpersController helpersController, IMapper mapper, BlobService blobservice)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _helpersController = new HelpersController(_context, _configuration, _httpContextAccessor, _mapper);
            blobService = blobservice;
            GeneralModel.Insert = GeneralModel.Insert.ToLower().Trim();
            GeneralModel.Delete = GeneralModel.Delete.ToLower().Trim();
            GeneralModel.Update = GeneralModel.Update.ToLower().Trim();
        }
        //Added by Musa for Testing
        //private string WKPCompanyId = GeneralModel.CompanyId;

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);
        private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        [HttpGet("GETWORKPROGRAMYEARS")]
        public object GETWORKPROGRAMYEARS()
        {
            var now = DateTime.UtcNow.Year + 1;
            var yearlist = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                yearlist.Add((now - i));
            }
            return yearlist;
        }

        [HttpGet("GETCOMPLETEDPAGES")]
        public async Task<object> GETCOMPLETEDPAGES(string omlname, string year, string fieldname)
        {
            bool isStep1;
            bool isStep2;
            bool isStep3;
            bool isStep4;
            bool isStep5;



            var step1 = await (from a in _context.CONCESSION_SITUATIONs
                               join b in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs on a.OML_Name equals b.OML_Name
                               join c in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs on a.OML_Name equals c.OML_Name
                               join d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs on a.OML_Name equals d.OML_Name
                               where a.OML_Name == omlname && a.Companyemail == WKPCompanyEmail && a.Field_ID.ToString() == fieldname
                               select new
                               {
                                   concessionCreated = a,
                                   geoData = b,
                                   geoDataProcessed = c,
                                   wellType = d


                               }).FirstOrDefaultAsync();
            // var _step1 = _context.CONCESSION_SITUATIONs.Where(a => a.OML_Name == omlname);
            if (step1?.geoData != null && step1?.geoDataProcessed != null && step1?.wellType != null && step1?.concessionCreated != null)
            {
                isStep1 = true;
            }
            else
            {
                isStep1 = false;
            }

            var step2 = await (from a in _context.INITIAL_WELL_COMPLETION_JOBs1
                               join b in _context.WORKOVERS_RECOMPLETION_JOBs1 on a.OML_Name equals b.OML_Name
                               join c in _context.GAS_PRODUCTION_ACTIVITIEs on a.OML_Name equals c.OML_Name
                               join d in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs on a.OML_Name equals d.OML_Name
                               join e in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs on a.OML_Name equals e.OML_Name
                               join f in _context.FIELD_DEVELOPMENT_PLANs on a.OML_Name equals f.OML_Name
                               where a.OML_Name == omlname && a.Companyemail == WKPCompanyEmail && a.Field_ID.ToString() == fieldname

                               select new
                               {
                                   currentdata = a,
                                   approvalWorkover = b,
                                   gasRoyalty = c,
                                   oilRoyalty = d,
                                   oilReserve = e,
                                   wellDrilled = f
                               }).FirstOrDefaultAsync();
            if (step2?.currentdata != null && step2?.approvalWorkover != null && step2?.gasRoyalty != null && step2?.oilRoyalty != null && step2?.oilReserve != null && step2?.wellDrilled != null)
            {
                isStep2 = true;
            }
            else
            {
                isStep2 = false;
            }

            var step3 = await (from a in _context.BUDGET_ACTUAL_EXPENDITUREs
                               join b in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs on a.OML_Name equals b.OML_Name
                               join c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs on a.OML_Name equals c.OML_Name
                               where a.OML_Name == omlname && a.Companyemail == WKPCompanyEmail && a.Field_ID.ToString() == fieldname
                               select new
                               {
                                   exploratoryBudget = a.Budget_for_Direct_Exploration_and_Production_Activities_USD,
                                   proposalBudget = b.Budget_for_Direct_Exploration_and_Production_Activities_Dollars,
                                   majorProjects = c.Major_Projects
                               }).FirstOrDefaultAsync();
            if (step3?.exploratoryBudget != null && step3?.proposalBudget != null && step3?.majorProjects != null)
            {
                isStep3 = true;
            }
            else
            {
                isStep3 = false;
            }

            var step4 = await (from a in _context.NIGERIA_CONTENT_Trainings
                               join b in _context.STRATEGIC_PLANS_ON_COMPANY_BAses on a.COMPANY_ID equals b.COMPANY_ID
                               join c in _context.LEGAL_LITIGATIONs on a.COMPANY_ID equals c.COMPANY_ID
                               where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year
                               select new
                               {
                                   actual_proposed = a.Actual_Proposed,
                                   activities = b.ACTIVITIES,
                                   anyLitigation = c.AnyLitigation
                               }).FirstOrDefaultAsync();
            if (step4?.actual_proposed != null && step4?.activities != null && step4?.anyLitigation != null)
            {
                isStep4 = true;
            }
            else
            {
                isStep4 = false;
            }

            var step5 = await (from a in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs
                               where a.OML_Name == omlname && a.Year_of_WP == year
                               select new
                               {
                                   facility = a.facility
                               }).FirstOrDefaultAsync();
            if (step5?.facility != null)
            {
                isStep5 = true;
            }
            else
            {
                isStep5 = false;
            }

            return new { step1 = isStep1, step2 = isStep2, step3 = isStep3, step4 = isStep4, step5 = isStep5 };
        }

        #region company concessions and fields management
        [HttpGet("GET_COMPANY_CONCESSIONS")]
        public async Task<object> GET_COMPANY_CONCESSIONS(int companyNumber)
        {
            try
            {
                int companyID = companyNumber > 0 ? companyNumber : (int)WKPCompanyNumber;
                var companyConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.CompanyNumber == WKPCompanyNumber && d.DELETED_STATUS != "DELETED" select d).ToListAsync();
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

        [HttpGet("GET_CONCESSIONS_FIELD")]
        public async Task<object> GET_CONCESSIONS_FIELD(int companyNumber)
        {
            try
            {
                int companyID = companyNumber > 0 ? companyNumber : (int)WKPCompanyNumber;
                var companyConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.CompanyNumber == WKPCompanyNumber && d.DELETED_STATUS == null select d).ToListAsync();
                var companyFields = await (from d in _context.COMPANY_FIELDs
                                           where d.CompanyNumber == WKPCompanyNumber && d.DeletedStatus != true
                                           select new
                                           {
                                               Field_Name = d.Field_Name,
                                               Field_ID = d.Field_ID,
                                               Concession_Name = _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == d.Concession_ID && x.Company_ID == WKPCompanyId).FirstOrDefault().Concession_Held
                                           }).ToListAsync();

                return new { CompanyConcessions = companyConcessions, CompanyFields = companyFields };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpPost("POST_ADMIN_CONCESSIONS_INFORMATION")]
        public async Task<object> POST_ADMIN_CONCESSIONS_INFORMATION([FromBody] ADMIN_CONCESSIONS_INFORMATION ADMIN_CONCESSIONS_INFORMATION_model, string id, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();

            try
            {

                #region Saving Concession

                if (action == GeneralModel.Insert || action == GeneralModel.Insert.ToUpper())
                {
                    var companyConcession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs
                                             where (d.ConcessionName == ADMIN_CONCESSIONS_INFORMATION_model.Concession_Held.TrimEnd().ToUpper() || d.Concession_Held == ADMIN_CONCESSIONS_INFORMATION_model.Concession_Held.TrimEnd().ToUpper())
                                                   && d.CompanyNumber == WKPCompanyNumber && d.DELETED_STATUS == null
                                             select d).FirstOrDefault();

                    if (companyConcession != null)
                    {
                        //return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

                        return BadRequest(new { message = $"Error : Concession ({ADMIN_CONCESSIONS_INFORMATION_model.Concession_Held} is already existing and can not be duplicated." });
                    }
                    else
                    {
                        ADMIN_CONCESSIONS_INFORMATION_model.CompanyName = WKPCompanyName;
                        ADMIN_CONCESSIONS_INFORMATION_model.Company_ID = WKPCompanyId;
                        ADMIN_CONCESSIONS_INFORMATION_model.Year = DateTime.UtcNow.Year.ToString();
                        ADMIN_CONCESSIONS_INFORMATION_model.DELETED_STATUS = null;
                        ADMIN_CONCESSIONS_INFORMATION_model.CompanyNumber = WKPCompanyNumber;
                        ADMIN_CONCESSIONS_INFORMATION_model.Date_Created = DateTime.Now;
                        ADMIN_CONCESSIONS_INFORMATION_model.Created_by = WKPCompanyEmail;
                        ADMIN_CONCESSIONS_INFORMATION_model.ConcessionName = ADMIN_CONCESSIONS_INFORMATION_model.Concession_Held.TrimEnd().ToUpper();
                        await _context.ADMIN_CONCESSIONS_INFORMATIONs.AddAsync(ADMIN_CONCESSIONS_INFORMATION_model);
                    }
                }
                else
                {
                    var companyConcession = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs
                                                   where d.Consession_Id == int.Parse(id)
                                                   select d).FirstOrDefaultAsync();

                    if (action == GeneralModel.Update)
                    {

                        if (companyConcession == null)
                        {
                            return BadRequest(new { message = $"Error : This concession details could not be found." });
                        }
                        else
                        {
                            // ADMIN_CONCESSIONS_INFORMATION_model.CompanyName = WKPCompanyName;
                            // ADMIN_CONCESSIONS_INFORMATION_model.Company_ID = WKPCompanyId;
                            // ADMIN_CONCESSIONS_INFORMATION_model.Year = DateTime.UtcNow.Year.ToString();
                            // ADMIN_CONCESSIONS_INFORMATION_model.CompanyNumber = WKPCompanyNumber;
                            // ADMIN_CONCESSIONS_INFORMATION_model.Date_Updated = DateTime.Now;
                            // ADMIN_CONCESSIONS_INFORMATION_model.Date_Created = companyConcession.Date_Created;
                            // ADMIN_CONCESSIONS_INFORMATION_model.Updated_by = WKPCompanyEmail;
                            // ADMIN_CONCESSIONS_INFORMATION_model.ConcessionName = ADMIN_CONCESSIONS_INFORMATION_model.Concession_Held.TrimEnd().ToUpper();

                            companyConcession.Area = ADMIN_CONCESSIONS_INFORMATION_model.Area;
                            companyConcession.Comment = ADMIN_CONCESSIONS_INFORMATION_model.Comment;
                            companyConcession.ConcessionName = ADMIN_CONCESSIONS_INFORMATION_model.ConcessionName;
                            companyConcession.Concession_Held = ADMIN_CONCESSIONS_INFORMATION_model.Concession_Held;
                            companyConcession.Consession_Type = ADMIN_CONCESSIONS_INFORMATION_model.Consession_Type;
                            companyConcession.Contract_Type = ADMIN_CONCESSIONS_INFORMATION_model.Contract_Type;
                            companyConcession.Terrain = ADMIN_CONCESSIONS_INFORMATION_model.Terrain;
                            companyConcession.Comment = ADMIN_CONCESSIONS_INFORMATION_model.Comment;
                            companyConcession.Equity_distribution = ADMIN_CONCESSIONS_INFORMATION_model.Equity_distribution;
                            companyConcession.Date_of_Expiration = ADMIN_CONCESSIONS_INFORMATION_model.Date_of_Expiration;
                            companyConcession.Year_of_Grant_Award = ADMIN_CONCESSIONS_INFORMATION_model.Year_of_Grant_Award;
                            _context.Entry(companyConcession).State = EntityState.Modified;
                            //await _context.SaveChangesAsync();
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.ADMIN_CONCESSIONS_INFORMATIONs.Remove(companyConcession);
                    }
                }
                save += await _context.SaveChangesAsync();
                #endregion

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var allConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.DELETED_STATUS != "DELETED" select d).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allConcessions, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("GET_CONCESSIONS_FIELDS")]
        public async Task<object> GET_CONCESSIONS_FIELDS(string concessionID, string companyID)
        {
            try
            {
                var companyFields = new List<COMPANY_FIELD>();
                if (!string.IsNullOrEmpty(companyID) && companyID != "null")
                {
                    companyFields = await (from d in _context.COMPANY_FIELDs where d.CompanyNumber.ToString() == companyID && d.DeletedStatus != true select d).ToListAsync();
                }
                else
                {
                    var concession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where (d.Consession_Id.ToString() == concessionID || d.Concession_Held == concessionID) && d.Company_ID == WKPCompanyId && d.DELETED_STATUS != "DELETED" select d).FirstOrDefault();

                    companyFields = await (from d in _context.COMPANY_FIELDs where d.Concession_ID == concession.Consession_Id && d.DeletedStatus != true select d).ToListAsync();

                }
                //string isEditable = null;
                if (companyFields.Count > 0)
                {
                    foreach (var field in companyFields)
                    {
                        var checkApplication = await (from ap in _context.Applications
                                                      where ap.YearOfWKP == DateTime.Now.Year && ap.FieldID == field.Field_ID && ap.DeleteStatus != true
                                                      select ap).FirstOrDefaultAsync();
                        field.isEditable = true;
                        if (checkApplication != null)
                        {
                            var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == checkApplication.Id && x.ActionStatus == GeneralModel.Initiated).FirstOrDefaultAsync();
                            if (NRejectApp == null)
                                field.isEditable = false;
                        }
                    }
                }
                return companyFields;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FIELD_CONCESSIONS")]
        public async Task<object> GET_FIELD_CONCESSIONS()
        {
            try
            {
                var concessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.DELETED_STATUS != "DELETED" select d).ToListAsync();

                var companyFields = await (from d in _context.COMPANY_FIELDs
                                           where d.CompanyNumber == WKPCompanyNumber
                                           select new
                                           {
                                               companyNumber = d.CompanyNumber,
                                               concession_ID = d.Concession_ID,
                                               concession_Held = _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == d.Concession_ID && x.Company_ID == WKPCompanyId).FirstOrDefault().Concession_Held,
                                               field_Name = d.Field_Name,
                                               field_ID = d.Field_ID
                                           }).ToListAsync();
                return new { concessions = concessions, fields = companyFields };

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GAS_PRODUCTION_TEXT")]
        public async Task<object> GAS_PRODUCTION_TEXT(string year)
        {
            var reportText = await (from a in _context.ADMIN_WORK_PROGRAM_REPORTs where a.Id == 5 select a.Report_Content_).FirstOrDefaultAsync();
            var gasActivities = await (from d in _context.WP_GAS_PRODUCTION_ACTIVITIES_Percentages where d.Year_of_WP == year select d).FirstOrDefaultAsync();
            reportText = reportText.Replace("(NO_TOTAL_GAS_PRODUCED)", gasActivities.Actual_Total_Gas_Produced.ToString()).Replace("(NO_TOTAL_GAS_UTILIZED)", gasActivities.Utilized_Gas_Produced.ToString())
            .Replace("(NO_TOTAL_GAS_FLARED)", gasActivities.Flared_Gas_Produced.ToString()).Replace("(PERCENTAGE_TOTAL_GAS_UTILIZED)", gasActivities.Percentage_Utilized.ToString());
            return new { reportText = reportText };
        }

        //[HttpPost("POST_COMPANY_FIELD")]
        //public async Task<object> POST_COMPANY_FIELD([FromBody] COMPANY_FIELD company_field_model, string actionToDo = null)
        //{

        //    int save = 0;
        //    string action = (actionToDo == null || actionToDo =="")? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower(); 
        //    try
        //    {
        //        #region Saving Field

        //        if (action == GeneralModel.Insert)
        //        {
        //            var companyField = (from d in _context.COMPANY_FIELDs
        //                                where d.Field_Name == company_field_model.Field_Name.TrimEnd().ToUpper()
        //                                      && d.CompanyNumber == int.Parse(WKPCompanyId) && d.DeletedStatus != true
        //                                select d).FirstOrDefault();

        //            if (companyField != null)
        //            {
        //                return BadRequest(new { message = $"Error : Field ({company_field_model.Field_Name} is already existing and can not be duplicated."});
        //            }
        //            else
        //            {
        //                company_field_model.CompanyNumber = int.Parse(WKPCompanyId);
        //                company_field_model.Date_Created = DateTime.Now;
        //                company_field_model.Field_Name = company_field_model.Field_Name.TrimEnd().ToUpper();
        //                await _context.COMPANY_FIELDs.AddAsync(company_field_model);
        //            }
        //        }
        //        else if (action == GeneralModel.Update)
        //        {
        //            var companyField = (from d in _context.COMPANY_FIELDs
        //                                where d.Field_ID == company_field_model.Field_ID
        //                                      && d.CompanyNumber == int.Parse(WKPCompanyId) && d.DeletedStatus != true
        //                                select d).FirstOrDefault();

        //            if (companyField == null)
        //            {
        //                return BadRequest(new { message = $"Error : This field details could not be found."});
        //            }
        //            else
        //            {
        //                company_field_model.Date_Updated = DateTime.Now;
        //                company_field_model.Field_Name = company_field_model.Field_Name.TrimEnd().ToUpper();
        //            }
        //        }
        //        else if (action == GeneralModel.Delete)
        //        {
        //            _context.COMPANY_FIELDs.Remove(company_field_model);
        //        }

        //        save += await _context.SaveChangesAsync();
        //        #endregion

        //        if (save > 0)
        //        {
        //            string successMsg = "Field has been " + action + "D successfully.";
        //            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
        //        }
        //        else
        //        {
        //            return BadRequest(new { message = "Error : An error occured while trying to submit this form."});

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

        //    }
        //}

        [HttpPost("POST_COMPANY_FIELD")]
        public async Task<object> POST_COMPANY_FIELD([FromBody] COMPANY_FIELD company_field_model, string id, string actionToDo)
        {
            int save = 0;
            string action = (id == "undefined" || actionToDo == null) ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower();
            try
            {
                #region Saving Field
                var concession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Consession_Id == company_field_model.Concession_ID && d.Company_ID == WKPCompanyId && d.DELETED_STATUS == null select d).FirstOrDefault();

                if (action == GeneralModel.Insert)
                {
                    var companyField = await (from d in _context.COMPANY_FIELDs
                                              where d.Field_Name == company_field_model.Field_Name.TrimEnd().ToUpper()
                                                    && d.CompanyNumber == WKPCompanyNumber && d.DeletedStatus != true
                                              select d).FirstOrDefaultAsync();

                    if (companyField != null)
                    {
                        return BadRequest(new { message = $"Error : Field ({company_field_model.Field_Name}) is already existing and can not be duplicated." });
                    }
                    else
                    {
                        company_field_model.Concession_ID = concession.Consession_Id;
                        company_field_model.CompanyNumber = WKPCompanyNumber;
                        company_field_model.Date_Created = DateTime.Now;
                        company_field_model.Field_Name = company_field_model.Field_Name.TrimEnd().ToUpper();
                        await _context.COMPANY_FIELDs.AddAsync(company_field_model);
                    }
                }
                else
                {
                    var companyField = (from d in _context.COMPANY_FIELDs
                                        where d.Field_ID.ToString() == id
                                              && d.CompanyNumber == WKPCompanyNumber && d.DeletedStatus != true
                                        select d).FirstOrDefault();

                    if (action == GeneralModel.Update)
                    {

                        if (companyField == null)
                        {
                            return BadRequest(new { message = $"Error : This field details could not be found." });
                        }
                        else
                        {
                            companyField.Concession_ID = concession.Consession_Id;
                            companyField.Date_Updated = DateTime.Now;
                            companyField.Field_Name = company_field_model.Field_Name.TrimEnd().ToUpper();
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.COMPANY_FIELDs.Remove(companyField);
                    }
                }
                save += await _context.SaveChangesAsync();
                #endregion

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var allFields = await (from d in _context.COMPANY_FIELDs
                                           where d.CompanyNumber == WKPCompanyNumber && d.DeletedStatus != true
                                           select new
                                           {
                                               Field_Name = d.Field_Name,
                                               Field_ID = d.Field_ID,
                                               Concession_Held = _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(x => x.Consession_Id == d.Concession_ID && x.Company_ID == WKPCompanyId).FirstOrDefault().Concession_Held
                                           }).ToListAsync();

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = allFields, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        #endregion

        #region database tables actions
        [HttpGet("GET_FORM_ONE_CONCESSION")]
        public async Task<object> GET_FORM_ONE_CONCESSION(string omlName, string fieldName, string myyear)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

                List<ADMIN_CONCESSIONS_INFORMATION> concessionInfo = null;
                List<CONCESSION_SITUATION> concessionSituation = null;
                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    concessionInfo = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).ToListAsync();
                    concessionSituation = await (from d in _context.CONCESSION_SITUATIONs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Field_ID == concessionField.Field_ID && d.Year == myyear select d).ToListAsync();
                }
                else
                {
                    concessionInfo = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).ToListAsync();
                    concessionSituation = await (from d in _context.CONCESSION_SITUATIONs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year == myyear select d).ToListAsync();
                }

                return new { concessionSituation = concessionSituation, concessionInfo = concessionInfo };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("GET_FORM_ONE_GEOPHYSICAL")]
        public async Task<object> GET_FORM_ONE_GEOPHYSICAL(string omlName, string fieldName, string myyear)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    var geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    return new { geoActivitiesAcquisition = geoActivitiesAcquisition, geoActivitiesProcessing = geoActivitiesProcessing };

                }
                else
                {
                    var geoActivitiesAcquisition = await (from d in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    var geoActivitiesProcessing = await (from d in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    return new { geoActivitiesAcquisition = geoActivitiesAcquisition, geoActivitiesProcessing = geoActivitiesProcessing };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GET_FORM_ONE_DRILLING")]
        public async Task<object> GET_FORM_ONE_DRILLING(string omlName, string fieldName, string myyear)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if ((concessionField.Consession_Type == "OML" || concessionField.Consession_Type == "PML") && concessionField.Field_Name != null)
                {

                    var drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    var drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    return new { drillEachCost = drillEachCost, drillEachCostProposed = drillEachCostProposed, drillOperationCategoriesWell = drillOperationCategoriesWell };


                }
                else
                {
                    var drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    var drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                    return new { drillEachCost = drillEachCost, drillEachCostProposed = drillEachCostProposed, drillOperationCategoriesWell = drillOperationCategoriesWell };
                }

                // if (concessionField.Consession_Type != "OPL" && int.Parse(myyear) > 2022)
                // {
                // 	var drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                // 	var drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                // 	var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.COMPANY_ID == WKPCompanyId && d.Field_ID == concessionField.Field_ID && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                // 	return new { drillEachCost = drillEachCost, drillEachCostProposed = drillEachCostProposed, drillOperationCategoriesWell = drillOperationCategoriesWell };
                // }
                // else
                // {
                // 	var drillEachCost = await (from d in _context.DRILLING_EACH_WELL_COSTs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                // 	var drillEachCostProposed = await (from d in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                // 	var drillOperationCategoriesWell = await (from d in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where d.COMPANY_ID == WKPCompanyId && d.OML_Name == omlName && d.Year_of_WP == myyear orderby d.QUATER select d).ToListAsync();
                // 	return new { drillEachCost = drillEachCost, drillEachCostProposed = drillEachCostProposed, drillOperationCategoriesWell = drillOperationCategoriesWell };
                // }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_CONCESSION_FIELD")]
        public ConcessionField GET_CONCESSION_FIELD(string omlName, string fieldID)
        {

            try
            {
                if (omlName != "undefined")
                {
                    COMPANY_FIELD field = null;
                    var concession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).FirstOrDefault();
                    if (fieldID != "null" && !string.IsNullOrEmpty(fieldID))
                    {
                        field = (from a in _context.COMPANY_FIELDs where a.Field_ID == Convert.ToInt32(fieldID) select a).FirstOrDefault();
                    }

                    return new ConcessionField
                    {
                        Concession_ID = concession.Consession_Id,
                        Concession_Name = concession.Concession_Held,
                        Consession_Type = concession.Consession_Type,
                        Terrain = concession.Terrain,
                        Field_Name = field?.Field_Name,
                        Field_ID = field?.Field_ID,
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }


            //try
            //{


            //    //Added By Musa For Testing
            //    //var WKPCompId = GeneralModel.CompanyId;


            //    //var concession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).FirstOrDefault();

            //    var concession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).FirstOrDefault();


            //    var field = (from d in _context.COMPANY_FIELDs where d.Field_Name == fieldName && d.DeletedStatus != true select d)?.FirstOrDefault();


            //    return new ConcessionField

            //    if (omlName != "undefined") 


            //        var concession = (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.Concession_Held == omlName && d.DELETED_STATUS == null select d).FirstOrDefault();
            //        var field = (from d in _context.COMPANY_FIELDs where d.Field_Name == fieldName && d.DeletedStatus != true select d).FirstOrDefault();
            //        return new ConcessionField
            //        {
            //            Concession_ID = concession.Consession_Id,
            //            Concession_Name = concession.ConcessionName,
            //            Consession_Type = concession.Consession_Type,
            //            Terrain = concession.Terrain,
            //            Field_Name = field?.Field_Name,
            //            Field_ID = field?.Field_ID,
            //        };
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
        }

        [HttpGet("GET_FORM_TWO_INITIAL_WELL_COMPLETION_JOB")]
        public async Task<object?> GET_INITIAL_WELL_COMPLETION_JOB(string year, string omlName, string fieldName)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if (concessionField == null) return null;

                if ((concessionField.Consession_Type == "OML" || concessionField.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var InitialWellCompletion = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.COMPANY_ID == WKPCompanyId && c.OML_Name == concessionField.Concession_Name && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).ToListAsync();
                    return new { InitialWellCompletion = InitialWellCompletion };
                }
                else
                {
                    var InitialWellCompletion = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new { InitialWellCompletion = InitialWellCompletion };
                }


            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GET_FORM_TWO_WORKOVERS_RECOMPLETION_JOB")]
        public async Task<object?> GET_WORKOVERS_RECOMPLETION_JOB(string year, string omlName, string fieldName)
        {

            try
            {

                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if (concessionField == null)
                {
                    return null;
                }
                if ((concessionField.Consession_Type == "OML" || concessionField.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var WorkoverRecompletion = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).ToListAsync();

                    return new { WorkoverRecompletion = WorkoverRecompletion };
                }
                else
                {
                    var WorkoverRecompletion = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    return new { WorkoverRecompletion = WorkoverRecompletion };

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }
        [HttpGet("GET_FORM_TWO_FDP_UNITISATION")]
        public async Task<object?> GET_FORM_TWO_FDP_UNITISATION(string omlName, string fieldName, string year)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if (concessionField == null)
                {
                    return null;
                }
                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField?.Field_Name != null)
                {
                    var FDP = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var FDPExcessiveReserves = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).ToListAsync();
                    var FieldsToSubmitFDP = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var FDPFieldsAndStatus = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var Unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    return new { FDP = FDP, FDPExcessiveReserves = FDPExcessiveReserves, FieldsToSubmitFDP = FieldsToSubmitFDP, FDPFieldsAndStatus = FDPFieldsAndStatus, Unitization = Unitization };

                }
                else
                {
                    var FDP = (from c in _context.FIELD_DEVELOPMENT_PLANs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    var FDPExcessiveReserves = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var FieldsToSubmitFDP = (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    var FDPFieldsAndStatus = (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    var Unitization = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    return new { FDP = FDP, FDPExcessiveReserves = FDPExcessiveReserves, FieldsToSubmitFDP = FieldsToSubmitFDP, FDPFieldsAndStatus = FDPFieldsAndStatus, Unitization = Unitization };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GET_FORM_TWO_RESERVES")]
        public async Task<object> GET_FORM_TWO_RESERVES(string omlName, string fieldName, string year)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if (concessionField == null)
                {
                    return null;
                }
                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var ReservesUpdate = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var StatusOfReservesPreceeding = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).FirstOrDefaultAsync();
                    var StatusOfReservesCurrent = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).FirstOrDefaultAsync();
                    var FiveYearProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).ToListAsync();
                    var CompanyAnnualProduction = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReservesAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReservesDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReservesReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).ToListAsync();
                    var ReserveDepletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReserveLifeIndices = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    return new
                    {
                        ReservesUpdate = ReservesUpdate,
                        StatusOfReservesPreceeding = StatusOfReservesPreceeding,
                        StatusOfReservesCurrent = StatusOfReservesCurrent,
                        FiveYearProjection = FiveYearProjection,
                        CompanyAnnualProduction = CompanyAnnualProduction,
                        ReservesAddition = ReservesAddition,
                        ReservesDecline = ReservesDecline,
                        ReservesReplacementRatio = ReservesReplacementRatio,
                        OilCondensateFiveYears = OilCondensateFiveYears,
                        ReserveDepletionRate = ReserveDepletionRate,
                        ReserveLifeIndices = ReserveLifeIndices
                    };
                }
                else
                {
                    var ReservesUpdate = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var StatusOfReservesPreceeding = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).FirstOrDefaultAsync();
                    var StatusOfReservesCurrent = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).FirstOrDefaultAsync();
                    var FiveYearProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var CompanyAnnualProduction = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReservesAddition = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReservesDecline = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReservesReplacementRatio = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReserveDepletionRate = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var ReserveLifeIndices = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    return new
                    {
                        ReservesUpdate = ReservesUpdate,
                        StatusOfReservesPreceeding = StatusOfReservesPreceeding,
                        StatusOfReservesCurrent = StatusOfReservesCurrent,
                        FiveYearProjection = FiveYearProjection,
                        CompanyAnnualProduction = CompanyAnnualProduction,
                        ReservesAddition = ReservesAddition,
                        ReservesDecline = ReservesDecline,
                        ReservesReplacementRatio = ReservesReplacementRatio,
                        OilCondensateFiveYears = OilCondensateFiveYears,
                        ReserveDepletionRate = ReserveDepletionRate,
                        ReserveLifeIndices = ReserveLifeIndices
                    };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GET_FORM_TWO_OIL_PRODUCTION")]
        public async Task<object> GET_FORM_TWO_OIL_PRODUCTION(string omlName, string fieldName, string year)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if (concessionField == null)
                {
                    return null;
                }
                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //var Unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var OilCondensateProductionMonthly = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateProductionMonthlyProposed = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).ToListAsync();

                    return new
                    {
                        OilCondensateProduction = OilCondensateProduction,
                        //Unitization = Unitization,
                        OilCondensateProductionMonthly = OilCondensateProductionMonthly,
                        OilCondensateProductionMonthlyProposed = OilCondensateProductionMonthlyProposed,
                        OilCondensateFiveYears = OilCondensateFiveYears
                    };
                }
                else
                {
                    var OilCondensateProduction = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //var Unitization = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var OilCondensateProductionMonthly = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateProductionMonthlyProposed = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateFiveYears = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    return new
                    {
                        OilCondensateProduction = OilCondensateProduction,
                        //Unitization = Unitization,
                        OilCondensateProductionMonthly = OilCondensateProductionMonthly,
                        OilCondensateProductionMonthlyProposed = OilCondensateProductionMonthlyProposed,
                        OilCondensateFiveYears = OilCondensateFiveYears
                    };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GET_FORM_TWO_GAS_PRODUCTION")]
        public async Task<object> GET_FORM_TWO_GAS_PRODUCTION(string omlName, string fieldName, string year)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var GasProduction = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.Field_ID == concessionField.Field_ID && c.OML_Name.ToUpper() == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var GasProductionDomestic = await (from c in _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies where c.Field_ID == concessionField.Field_ID && c.OML_Name.ToUpper() == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    return new
                    {
                        GasProductionActivity = GasProduction,
                        GasProductionDomestic = GasProductionDomestic
                    };
                }
                else
                {
                    var GasProduction = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    var GasProductionDomestic = await (from c in _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    return new
                    {
                        GasProductionActivity = GasProduction,
                        GasProductionDomestic = GasProductionDomestic
                    };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GET_FORM_THREE_BUDGET_PERFORMANCE")]
        public async Task<object> GET_FORM_THREE_BUDGET_PERFORMANCE(string year, string omlName, string fieldName)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

                if ((concessionField.Consession_Type == "OML" || concessionField.Consession_Type == "PML") && concessionField.Field_Name != null)
                {


                    var BudgetActualExpenditure = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceExploratory = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceDevelopment = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceProductionCost = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceFacilityDevProjects = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new
                    {
                        BudgetActualExpenditure = BudgetActualExpenditure,
                        BudgetPerformanceExploratory = BudgetPerformanceExploratory,
                        BudgetPerformanceDevelopment = BudgetPerformanceDevelopment,
                        BudgetPerformanceProductionCost = BudgetPerformanceProductionCost,
                        BudgetPerformanceFacilityDevProjects = BudgetPerformanceFacilityDevProjects
                    };
                }
                else
                {
                    var BudgetActualExpenditure = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceExploratory = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceDevelopment = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceProductionCost = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetPerformanceFacilityDevProjects = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    return new
                    {
                        BudgetActualExpenditure = BudgetActualExpenditure,
                        BudgetPerformanceExploratory = BudgetPerformanceExploratory,
                        BudgetPerformanceDevelopment = BudgetPerformanceDevelopment,
                        BudgetPerformanceProductionCost = BudgetPerformanceProductionCost,
                        BudgetPerformanceFacilityDevProjects = BudgetPerformanceFacilityDevProjects
                    };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FORM_THREE_BUDGET_PROPOSAL_IN_NAIRA_DOLLAR")]
        public async Task<object> GET_FORM_THREE_BUDGET_PROPOSAL_IN_NAIRA_DOLLAR(string year, string omlName, string fieldName)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if ((concessionField.Consession_Type == "OML" || concessionField.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var BudgetProposalComponents = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetCapexOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var DecommissioningAbadonment = await (from c in _context.DECOMMISSIONING_ABANDONMENTs where c.FieldId == concessionField.Field_ID && c.CompanyEmail == WKPCompanyEmail && c.WpYear == year select c).FirstOrDefaultAsync();
                    return new
                    {
                        BudgetProposalComponents = BudgetProposalComponents,
                        BudgetCapexOpex = BudgetCapexOpex,
                        DecommissioningAbadonment = DecommissioningAbadonment
                    };
                }
                else
                {
                    var BudgetProposalComponents = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var BudgetCapexOpex = await (from c in _context.BUDGET_CAPEX_OPices where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var DecommissioningAbadonment = await (from c in _context.DECOMMISSIONING_ABANDONMENTs where c.CompanyEmail == WKPCompanyEmail && c.WpYear == year select c).FirstOrDefaultAsync();

                    return new
                    {
                        BudgetProposalComponents = BudgetProposalComponents,
                        BudgetCapexOpex = BudgetCapexOpex,
                        DecommissioningAbadonment = DecommissioningAbadonment
                    };
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FORM_THREE_OIL_GAS_FACILITY_MAINTENANCE")]
        public async Task<object> GET_FORM_THREE_OIL_GAS_FACILITY_MAINTENANCE(string year, string omlName, string fieldName)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if ((concessionField.Consession_Type == "OML" || concessionField.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    var OilAndGasExpenditure = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateTechnologyAssessment = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var OilAndGasProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var FacilitiesProjetPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    return new
                    {
                        OilAndGasExpenditure = OilAndGasExpenditure,
                        OilCondensateTechnologyAssessment = OilCondensateTechnologyAssessment,
                        OilAndGasProjects = OilAndGasProjects,
                        FacilitiesProjetPerformance = FacilitiesProjetPerformance,
                    };
                }
                else
                {
                    var OilAndGasExpenditure = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var OilCondensateTechnologyAssessment = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var OilAndGasProjects = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                    var FacilitiesProjetPerformance = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();

                    return new
                    {
                        OilAndGasExpenditure = OilAndGasExpenditure,
                        OilCondensateTechnologyAssessment = OilCondensateTechnologyAssessment,
                        OilAndGasProjects = OilAndGasProjects,
                        FacilitiesProjetPerformance = FacilitiesProjetPerformance,
                    };

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FORM_FOUR_NIGERIA_CONTENT")]
        public async Task<object> GET_FORM_FOUR_NIGERIA_CONTENT(string year)
        {
            try
            {
                // var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                // if (concessionField.Consession_Type != "OPL" && int.Parse(year) > 2022)
                // {
                //     var NigeriaContent = await (from c in _context.NIGERIA_CONTENT_Trainings where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //     var NigeriaContentUploadSuccession = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //     var NigeriaContentQuestion = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                //     return new
                //     {
                //         NigeriaContent = NigeriaContent,
                //         NigeriaContentUploadSuccession = NigeriaContentUploadSuccession,
                //         NigeriaContentQuestion = NigeriaContentQuestion
                //     };
                // }
                // else
                // {
                var NigeriaContent = await (from c in _context.NIGERIA_CONTENT_Trainings where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();
                var NigeriaContentUploadSuccession = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();
                var NigeriaContentQuestion = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();

                return new
                {
                    NigeriaContent = NigeriaContent,
                    NigeriaContentUploadSuccession = NigeriaContentUploadSuccession,
                    NigeriaContentQuestion = NigeriaContentQuestion
                };
                //}
                // else
                // {
                //     var NigeriaContent = await (from c in _context.NIGERIA_CONTENT_Trainings where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //     var NigeriaContentUploadSuccession = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //     var NigeriaContentQuestion = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                //     return new
                //     {
                //         NigeriaContent = NigeriaContent,
                //         NigeriaContentUploadSuccession = NigeriaContentUploadSuccession,
                //         NigeriaContentQuestion = NigeriaContentQuestion
                //     };
                // }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FORM_FOUR_STRATEGIC_PLANS")]
        public async Task<object> GET_FORM_FOUR_STRATEGIC_PLANS(string year)
        {
            try
            {
                //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                // if (concessionField.Consession_Type != "OPL" && int.Parse(year) > 2022)
                // {
                //     var StrategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.Field_ID == concessionField.Field_ID && c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();
                //     return new
                //     {
                //         StrategicPlans = StrategicPlans
                //     };
                // }
                // else
                // {
                var StrategicPlans = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                return new
                {
                    StrategicPlans = StrategicPlans
                };
                //}
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FORM_FOUR_LEGAL_PROCEEDINGS")]
        public async Task<object> GET_FORM_FOUR_LEGAL_PROCEEDINGS(string year)
        {
            try
            {
                // var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                // if (concessionField.Consession_Type != "OPL" && int.Parse(year) > 2022)
                // {
                //     var LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //     var LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //     return new
                //     {
                //         LegalLitigation = LegalLitigation,
                //         LegalArbitration = LegalArbitration
                //     };
                // }
                // else
                // {
                var LegalLitigation = await (from c in _context.LEGAL_LITIGATIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                var LegalArbitration = await (from c in _context.LEGAL_ARBITRATIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                return new
                {
                    LegalLitigation = LegalLitigation,
                    LegalArbitration = LegalArbitration
                };
                //}
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        // Added by Musa
        [HttpGet("GET_FORM_THREE_CAPEX")]
        public async Task<object> GET_FORM_THREE_CAPEX(string year)
        {
            try
            {
                var budgetCapex = await (from c in _context.BUDGET_CAPices where c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                return new
                {
                    BudgetCapex = budgetCapex
                };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_FORM_FIVE_HSE")]
        public async Task<object> GET_FORM_FIVE_HSE(string omlName, string fieldName, string year, string type_of_facility, string number_of_facilities)
        {


            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                if (concessionField == null)
                {
                    return null;
                }
                if (concessionField.Field_Name != null)
                {

                    var HSEQuestion = await (from c in _context.HSE_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEFatality = await (from c in _context.HSE_FATALITIEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEDesignSafety = await (from c in _context.HSE_DESIGNS_SAFETies where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEInspectionMaintenance = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEInspectionMaintenanceFacility = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSETechnicalSafety = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSESafetyStudies = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSERemediationFund = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEAssetRegister = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEOilSpill = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEAssetRegisterRBI = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEAccidentIncidence = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEAccidentIncidenceType = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var accidentModel = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                               join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                               where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
                                               && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year
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

                    var HSECommunityDisturbance = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEEnvironmentalStudies = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEWasteManagement = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEWasteManagementType = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEProducedWaterMgt = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEEnvironmentalCompliance = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();


                    var HSEEnvironmentalFiveYears = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSESustainableDev = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEEnvironmentalStudiesUpdated = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEOSPRegistrations = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEProducedWaterMgtUpdated = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEEnvironmentalComplianceChemical = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSECausesOfSpill = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    // var HSESustainableDevMOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSESustainableDevProgramCsr = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSESustainableDevScheme = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEManagementPosition = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEQualityControl = await (from c in _context.HSE_QUALITY_CONTROLs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEClimateChange = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSESafetyCulture = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEOccupationalHealth = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEWasteManagementSystems = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEWastManagementDZs = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    var HSEEnvironmentalManagementSystems = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //Added by Musa

                    var HSEOPERATIONSSAFETYCASEs = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();


                    var HSEPointSourceRegistrations = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEEnvironmentalMgtPlans = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEEnfluenceConliences = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();


                    var HSEGHGPlans = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.Field_ID == concessionField.Field_ID && c.CompanY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSEHostCommunities = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

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
                        HSEPointSourceRegistrations = HSEPointSourceRegistrations,
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
                        HSEOperationSafetyCases = HSEOPERATIONSSAFETYCASEs,
                        HSEEnvironmentalManagementPlans = HSEEnvironmentalMgtPlans,
                        HSEEnfluenceConliences = HSEEnfluenceConliences,
                        HSEGHGPlans = HSEGHGPlans,
                        HSEHostCommunities = HSEHostCommunities,
                        HSERemediationFund = HSERemediationFund,
                        HSEWastManagementDZs = HSEWastManagementDZs
                    };
                }
                else
                {
                    var HSEQuestion = (from c in _context.HSE_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEFatality = (from c in _context.HSE_FATALITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEDesignSafety = (from c in _context.HSE_DESIGNS_SAFETies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEInspectionMaintenance = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEInspectionMaintenanceFacility = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSETechnicalSafety = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSESafetyStudies = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEAssetRegister = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEOilSpill = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEAssetRegisterRBI = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEAccidentIncidence = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEAccidentIncidenceType = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var accidentModel = (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                         join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                         where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
                                         && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year
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
                                         }).ToList();

                    var HSECommunityDisturbance = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEEnvironmentalStudies = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEWasteManagement = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEWasteManagementType = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEProducedWaterMgt = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEEnvironmentalCompliance = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEEnvironmentalFiveYears = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSESustainableDev = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEEnvironmentalStudiesUpdated = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEOSPRegistrations = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEProducedWaterMgtUpdated = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEEnvironmentalComplianceChemical = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSECausesOfSpill = (from c in _context.HSE_CAUSES_OF_SPILLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    // var HSESustainableDevMOU = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSESustainableDevScheme = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEManagementPosition = (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEQualityControl = (from c in _context.HSE_QUALITY_CONTROLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEClimateChange = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    //Musa
                    var HSESustainableDevProgramCsr = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEPointSourceRegistrations = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.OML_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    var HSESafetyCulture = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEOccupationalHealth = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEWasteManagementSystems = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSEEnvironmentalManagementSystems = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEOperationCases = (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEEnvironmentalMgtPlans = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEEFluenceCompliences = (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEHostComms = (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    var HSEGHGPlans = (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.OmL_Name == omlName && c.CompanY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
                    var HSERemediationFund = (from c in _context.HSE_REMEDIATION_FUNDs where c.CompanyName == WKPCompanyName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
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

                        HSESustainableDevProjectProgmCsr = HSESustainableDevProgramCsr,
                        HSEPointSourceRegistrations = HSEPointSourceRegistrations,
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
                        HSEOperationalCases = HSEOperationCases,
                        HSEEnvironmentalMgtPlans = HSEEnvironmentalMgtPlans,
                        HSEEFluenceCompliences = HSEEFluenceCompliences,
                        HSEHostComms = HSEHostComms,
                        HSEGHGPlans = HSEGHGPlans,
                        HSERemediationFund = HSERemediationFund

                    };
                }

                return null;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }












            //try
            //{
            //    var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);


            //    if (concessionField.Consession_Type != "OPL" && int.Parse(year) > 2022)
            //    {
            //        var HSEQuestion = (from c in _context.HSE_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEFatality = (from c in _context.HSE_FATALITIEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEDesignSafety = (from c in _context.HSE_DESIGNS_SAFETies where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEInspectionMaintenance = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEInspectionMaintenanceFacility = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSETechnicalSafety = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSESafetyStudies = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEAssetRegister = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEOilSpill = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEAssetRegisterRBI = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEAccidentIncidence = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEAccidentIncidenceType = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var accidentModel = (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
            //                             join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
            //                             where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
            //                             && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year
            //                             select new HSE_ACCIDENT_INCIDENCE_MODEL
            //                             {
            //                                 Was_there_any_accident_incidence = a1.Was_there_any_accident_incidence,
            //                                 If_YES_were_they_reported = a1.If_YES_were_they_reported,
            //                                 Cause = a2.Cause,
            //                                 Type_of_Accident_Incidence = a2.Type_of_Accident_Incidence,
            //                                 Consequence = a2.Consequence,
            //                                 Frequency = a2.Frequency,
            //                                 Investigation = a2.Investigation,
            //                                 Lesson_Learnt = a2.Lesson_Learnt,
            //                                 Location = a2.Location,
            //                                 Date_ = a2.Date_
            //                             }).ToList();

            //        var HSECommunityDisturbance = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEEnvironmentalStudies = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEWasteManagement = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEWasteManagementType = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEProducedWaterMgt = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEEnvironmentalCompliance = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();


            //        var HSEEnvironmentalFiveYears = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSESustainableDev = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEEnvironmentalStudiesUpdated = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEOSPRegistrations = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEProducedWaterMgtUpdated = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEEnvironmentalComplianceChemical = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSECausesOfSpill = (from c in _context.HSE_CAUSES_OF_SPILLs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSESustainableDevMOU = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSESustainableDevScheme = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //        //Musa
            //        var HSESustainableDevProgramCsr = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEManagementPosition = (from c in _context.HSE_MANAGEMENT_POSITIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEQualityControl = (from c in _context.HSE_QUALITY_CONTROLs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEClimateChange = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSESafetyCulture = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEOccupationalHealth = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEWasteManagementSystems = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        var HSEEnvironmentalManagementSystems = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //        return new
            //        {
            //            HSETechnicalSafety = HSETechnicalSafety,
            //            HSESafetyStudies = HSESafetyStudies,
            //            HSEQualityControl = HSEQualityControl,
            //            HSEInspectionMaintenance = HSEInspectionMaintenance,
            //            HSEAssetRegister = HSEAssetRegister,
            //            HSEOilSpill = HSEOilSpill,
            //            HSECausesOfSpill = HSECausesOfSpill,
            //            HSEAssetRegisterRBI = HSEAssetRegisterRBI,
            //            HSEAccidentModel = accidentModel,
            //            HSEAccidentIncidence = HSEAccidentIncidence,
            //            HSEOSPRegistrations = HSEOSPRegistrations,
            //            HSEAccidentIncidenceType = HSEAccidentIncidenceType,
            //            HSECommunityDisturbance = HSECommunityDisturbance,

            //            HSEQuestion = HSEQuestion,
            //            HSEFatality = HSEFatality,
            //            HSEDesignSafety = HSEDesignSafety,
            //            HSEInspectionMaintenanceFacility = HSEInspectionMaintenanceFacility,
            //            HSEEnvironmentalStudies = HSEEnvironmentalStudies,
            //            HSEWasteManagement = HSEWasteManagement,
            //            HSEWasteManagementType = HSEWasteManagementType,
            //            HSEProducedWaterMgt = HSEProducedWaterMgt,
            //            HSEEnvironmentalCompliance = HSEEnvironmentalCompliance,
            //            HSEEnvironmentalFiveYears = HSEEnvironmentalFiveYears,
            //            HSEEnvironmentalStudiesUpdated = HSEEnvironmentalStudiesUpdated,
            //            HSEProducedWaterMgtUpdated = HSEProducedWaterMgtUpdated,
            //            HSEEnvironmentalComplianceChemical = HSEEnvironmentalComplianceChemical,
            //            HSEManagementPosition = HSEManagementPosition,

            //            HSESustainableDevCommProjProgCsr = HSESustainableDevProgramCsr,

            //            HSEClimateChange = HSEClimateChange,
            //            HSESafetyCulture = HSESafetyCulture,
            //            HSEOccupationalHealth = HSEOccupationalHealth,
            //            HSEWasteManagementSystems = HSEWasteManagementSystems,
            //            HSEEnvironmentalManagementSystems = HSEEnvironmentalManagementSystems,
            //        };

            //        if (concessionField == null)
            //        {
            //            return null;

            //        }
            //        if (concessionField != null)
            //        {

            //            var HSEQuestion = (from c in _context.HSE_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEFatality = (from c in _context.HSE_FATALITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEDesignSafety = (from c in _context.HSE_DESIGNS_SAFETies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEInspectionMaintenance = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEInspectionMaintenanceFacility = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSETechnicalSafety = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSESafetyStudies = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAssetRegister = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEOilSpill = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAssetRegisterRBI = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAccidentIncidence = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAccidentIncidenceType = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var accidentModel = (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
            //                                 join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
            //                                 where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
            //                                 && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year
            //                                 select new HSE_ACCIDENT_INCIDENCE_MODEL
            //                                 {
            //                                     Was_there_any_accident_incidence = a1.Was_there_any_accident_incidence,
            //                                     If_YES_were_they_reported = a1.If_YES_were_they_reported,
            //                                     Cause = a2.Cause,
            //                                     Type_of_Accident_Incidence = a2.Type_of_Accident_Incidence,
            //                                     Consequence = a2.Consequence,
            //                                     Frequency = a2.Frequency,
            //                                     Investigation = a2.Investigation,
            //                                     Lesson_Learnt = a2.Lesson_Learnt,
            //                                     Location = a2.Location,
            //                                     Date_ = a2.Date_
            //                                 }).ToList();

            //            var HSECommunityDisturbance = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEEnvironmentalStudies = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEWasteManagement = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEWasteManagementType = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEProducedWaterMgt = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEEnvironmentalCompliance = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEEnvironmentalFiveYears = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSESustainableDev = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            //Musa
            //            var HSESustainableDevProgramCsr = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEEnvironmentalStudiesUpdated = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEOSPRegistrations = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEProducedWaterMgtUpdated = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEEnvironmentalComplianceChemical = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSECausesOfSpill = (from c in _context.HSE_CAUSES_OF_SPILLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSESustainableDevMOU = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSESustainableDevScheme = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEManagementPosition = (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEQualityControl = (from c in _context.HSE_QUALITY_CONTROLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEClimateChange = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSESafetyCulture = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEOccupationalHealth = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEWasteManagementSystems = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEEnvironmentalManagementSystems = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            return new


            //        if (concessionField.Consession_Type != "OPL" && int.Parse(year) > 2022)

            //            {
            //                var HSEQuestion = (from c in _context.HSE_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //                var HSEFatality = (from c in _context.HSE_FATALITIEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //                var HSEDesignSafety = (from c in _context.HSE_DESIGNS_SAFETies where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //                var HSEInspectionMaintenance = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //                var HSEInspectionMaintenanceFacility = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //                var HSETechnicalSafety = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //                var HSESafetyStudies = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();


            //                HSESustainableDevCommProjProgCsr = HSESustainableDevProgramCsr,

            //            HSEQuestion = HSEQuestion,
            //            HSEFatality = HSEFatality,
            //            HSEDesignSafety = HSEDesignSafety,
            //            HSEInspectionMaintenanceFacility = HSEInspectionMaintenanceFacility,
            //            HSEEnvironmentalStudies = HSEEnvironmentalStudies,
            //            HSEWasteManagement = HSEWasteManagement,
            //            HSEWasteManagementType = HSEWasteManagementType,
            //            HSEProducedWaterMgt = HSEProducedWaterMgt,
            //            HSEEnvironmentalCompliance = HSEEnvironmentalCompliance,
            //            HSEEnvironmentalFiveYears = HSEEnvironmentalFiveYears,
            //            HSEEnvironmentalStudiesUpdated = HSEEnvironmentalStudiesUpdated,
            //            HSEProducedWaterMgtUpdated = HSEProducedWaterMgtUpdated,
            //            HSEEnvironmentalComplianceChemical = HSEEnvironmentalComplianceChemical,
            //            HSEManagementPosition = HSEManagementPosition,
            //            HSEClimateChange = HSEClimateChange,
            //            HSESafetyCulture = HSESafetyCulture,
            //            HSEOccupationalHealth = HSEOccupationalHealth,
            //            HSEWasteManagementSystems = HSEWasteManagementSystems,
            //            HSEEnvironmentalManagementSystems = HSEEnvironmentalManagementSystems,
            //        };

            //            var HSEAssetRegister = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEOilSpill = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEAssetRegisterRBI = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAccidentIncidence = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEAccidentIncidenceType = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var accidentModel = (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
            //                                 join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
            //                                 where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
            //                                 && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year
            //                                 select new HSE_ACCIDENT_INCIDENCE_MODEL
            //                                 {
            //                                     Was_there_any_accident_incidence = a1.Was_there_any_accident_incidence,
            //                                     If_YES_were_they_reported = a1.If_YES_were_they_reported,
            //                                     Cause = a2.Cause,
            //                                     Type_of_Accident_Incidence = a2.Type_of_Accident_Incidence,
            //                                     Consequence = a2.Consequence,
            //                                     Frequency = a2.Frequency,
            //                                     Investigation = a2.Investigation,
            //                                     Lesson_Learnt = a2.Lesson_Learnt,
            //                                     Location = a2.Location,
            //                                     Date_ = a2.Date_
            //                                 }).ToList();

            //            var HSECommunityDisturbance = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalStudies = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEWasteManagement = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEWasteManagementType = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEProducedWaterMgt = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalCompliance = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();


            //            var HSEEnvironmentalFiveYears = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESustainableDev = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalStudiesUpdated = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEOSPRegistrations = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEProducedWaterMgtUpdated = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalComplianceChemical = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSECausesOfSpill = (from c in _context.HSE_CAUSES_OF_SPILLs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESustainableDevMOU = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESustainableDevScheme = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEManagementPosition = (from c in _context.HSE_MANAGEMENT_POSITIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEQualityControl = (from c in _context.HSE_QUALITY_CONTROLs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEClimateChange = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESafetyCulture = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEOccupationalHealth = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEWasteManagementSystems = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalManagementSystems = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            return new
            //            {
            //                HSETechnicalSafety = HSETechnicalSafety,
            //                HSESafetyStudies = HSESafetyStudies,
            //                HSEQualityControl = HSEQualityControl,
            //                HSEInspectionMaintenance = HSEInspectionMaintenance,
            //                HSEAssetRegister = HSEAssetRegister,
            //                HSEOilSpill = HSEOilSpill,
            //                HSECausesOfSpill = HSECausesOfSpill,
            //                HSEAssetRegisterRBI = HSEAssetRegisterRBI,
            //                HSEAccidentModel = accidentModel,
            //                HSEAccidentIncidence = HSEAccidentIncidence,
            //                HSEOSPRegistrations = HSEOSPRegistrations,
            //                HSEAccidentIncidenceType = HSEAccidentIncidenceType,
            //                HSECommunityDisturbance = HSECommunityDisturbance,

            //                HSEQuestion = HSEQuestion,
            //                HSEFatality = HSEFatality,
            //                HSEDesignSafety = HSEDesignSafety,
            //                HSEInspectionMaintenanceFacility = HSEInspectionMaintenanceFacility,
            //                HSEEnvironmentalStudies = HSEEnvironmentalStudies,
            //                HSEWasteManagement = HSEWasteManagement,
            //                HSEWasteManagementType = HSEWasteManagementType,
            //                HSEProducedWaterMgt = HSEProducedWaterMgt,
            //                HSEEnvironmentalCompliance = HSEEnvironmentalCompliance,
            //                HSEEnvironmentalFiveYears = HSEEnvironmentalFiveYears,
            //                HSEEnvironmentalStudiesUpdated = HSEEnvironmentalStudiesUpdated,
            //                HSEProducedWaterMgtUpdated = HSEProducedWaterMgtUpdated,
            //                HSEEnvironmentalComplianceChemical = HSEEnvironmentalComplianceChemical,
            //                HSEManagementPosition = HSEManagementPosition,
            //                HSEClimateChange = HSEClimateChange,
            //                HSESafetyCulture = HSESafetyCulture,
            //                HSEOccupationalHealth = HSEOccupationalHealth,
            //                HSEWasteManagementSystems = HSEWasteManagementSystems,
            //                HSEEnvironmentalManagementSystems = HSEEnvironmentalManagementSystems,
            //            };
            //        }
            //        else
            //        {
            //            var HSEQuestion = (from c in _context.HSE_QUESTIONs where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEFatality = (from c in _context.HSE_FATALITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEDesignSafety = (from c in _context.HSE_DESIGNS_SAFETies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEInspectionMaintenance = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEInspectionMaintenanceFacility = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSETechnicalSafety = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESafetyStudies = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAssetRegister = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEOilSpill = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEAssetRegisterRBI = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            var HSEAccidentIncidence = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEAccidentIncidenceType = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var accidentModel = (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
            //                                 join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
            //                                 where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
            //                                 && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year
            //                                 select new HSE_ACCIDENT_INCIDENCE_MODEL
            //                                 {
            //                                     Was_there_any_accident_incidence = a1.Was_there_any_accident_incidence,
            //                                     If_YES_were_they_reported = a1.If_YES_were_they_reported,
            //                                     Cause = a2.Cause,
            //                                     Type_of_Accident_Incidence = a2.Type_of_Accident_Incidence,
            //                                     Consequence = a2.Consequence,
            //                                     Frequency = a2.Frequency,
            //                                     Investigation = a2.Investigation,
            //                                     Lesson_Learnt = a2.Lesson_Learnt,
            //                                     Location = a2.Location,
            //                                     Date_ = a2.Date_
            //                                 }).ToList();

            //            var HSECommunityDisturbance = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalStudies = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEWasteManagement = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEWasteManagementType = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEProducedWaterMgt = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalCompliance = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalFiveYears = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESustainableDev = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalStudiesUpdated = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEOSPRegistrations = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEProducedWaterMgtUpdated = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalComplianceChemical = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSECausesOfSpill = (from c in _context.HSE_CAUSES_OF_SPILLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESustainableDevMOU = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESustainableDevScheme = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEManagementPosition = (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEQualityControl = (from c in _context.HSE_QUALITY_CONTROLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEClimateChange = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSESafetyCulture = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEOccupationalHealth = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEWasteManagementSystems = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();
            //            var HSEEnvironmentalManagementSystems = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

            //            return new
            //            {
            //                HSETechnicalSafety = HSETechnicalSafety,
            //                HSESafetyStudies = HSESafetyStudies,
            //                HSEQualityControl = HSEQualityControl,
            //                HSEInspectionMaintenance = HSEInspectionMaintenance,
            //                HSEAssetRegister = HSEAssetRegister,
            //                HSEOilSpill = HSEOilSpill,
            //                HSECausesOfSpill = HSECausesOfSpill,
            //                HSEAssetRegisterRBI = HSEAssetRegisterRBI,
            //                HSEAccidentModel = accidentModel,
            //                HSEAccidentIncidence = HSEAccidentIncidence,
            //                HSEOSPRegistrations = HSEOSPRegistrations,
            //                HSEAccidentIncidenceType = HSEAccidentIncidenceType,
            //                HSECommunityDisturbance = HSECommunityDisturbance,

            //                HSEQuestion = HSEQuestion,
            //                HSEFatality = HSEFatality,
            //                HSEDesignSafety = HSEDesignSafety,
            //                HSEInspectionMaintenanceFacility = HSEInspectionMaintenanceFacility,
            //                HSEEnvironmentalStudies = HSEEnvironmentalStudies,
            //                HSEWasteManagement = HSEWasteManagement,
            //                HSEWasteManagementType = HSEWasteManagementType,
            //                HSEProducedWaterMgt = HSEProducedWaterMgt,
            //                HSEEnvironmentalCompliance = HSEEnvironmentalCompliance,
            //                HSEEnvironmentalFiveYears = HSEEnvironmentalFiveYears,
            //                HSEEnvironmentalStudiesUpdated = HSEEnvironmentalStudiesUpdated,
            //                HSEProducedWaterMgtUpdated = HSEProducedWaterMgtUpdated,
            //                HSEEnvironmentalComplianceChemical = HSEEnvironmentalComplianceChemical,
            //                HSEManagementPosition = HSEManagementPosition,
            //                HSEClimateChange = HSEClimateChange,
            //                HSESafetyCulture = HSESafetyCulture,
            //                HSEOccupationalHealth = HSEOccupationalHealth,
            //                HSEWasteManagementSystems = HSEWasteManagementSystems,
            //                HSEEnvironmentalManagementSystems = HSEEnvironmentalManagementSystems,
            //            };
            //        }

            //    }
            //    return null;
            //}
            //catch (Exception e)
            //{
            //    return new WebApiResponse
            //    {
            //        ResponseCode = AppResponseCodes.InternalError,
            //        Message = "Error : " + e.Message,
            //        StatusCode = ResponseCodes.InternalError
            //    };
            //}
        }


        [HttpGet("GET_ROYALTY")]
        public async Task<object> GET_ROYALTY(string myyear, string omlName, string fieldID)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldID);
                Royalty royaltyData;
                if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                {
                    // if ()
                    // {
                    royaltyData = await (from d in _context.Royalties where d.CompanyNumber == WKPCompanyNumber && d.OmlName == omlName && d.Field_ID == concessionField.Field_ID && d.Year == myyear select d).FirstOrDefaultAsync();
                    //}
                }
                else
                {
                    royaltyData = await (from d in _context.Royalties where d.CompanyNumber == WKPCompanyNumber && d.OmlName == omlName && d.Year == myyear select d).FirstOrDefaultAsync();
                }
                // if (concessionField != null)
                // {
                // 	var royalty = await (from d in _context.Royalties where d.CompanyNumber == WKPCompanyNumber && d.Concession_ID == concessionField.Concession_ID && d.Year == myyear select d).ToListAsync();

                // }
                return new { royalty = royaltyData };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_DECOMMISSIONING_ABANDONMENT")]
        public async Task<object> POST_DECOMMISSIONING_ABANDONMENT([FromBody] DECOMMISSIONING_ABANDONMENT decomAban_model, string year, string omlName, string fieldName, string actionToDo)
        {
            int save = 0;

            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();

            DECOMMISSIONING_ABANDONMENT myDecomAban;
            try
            {
                if (concessionField?.Field_Name != null)
                {
                    myDecomAban = await (from c in _context.DECOMMISSIONING_ABANDONMENTs where c.CompanyEmail == WKPCompanyEmail && c.OmlId == concessionField.Concession_ID && c.FieldId == concessionField.Field_ID && c.WpYear == year select c).FirstOrDefaultAsync();
                }
                else
                {
                    myDecomAban = await (from c in _context.DECOMMISSIONING_ABANDONMENTs where c.CompanyEmail == WKPCompanyEmail && c.OmlId == concessionField.Concession_ID && c.WpYear == year select c).FirstOrDefaultAsync();
                }

                if (action == GeneralModel.Insert)
                {
                    decomAban_model.CompanyEmail = WKPCompanyEmail;
                    decomAban_model.OmlId = concessionField.Concession_ID ?? null;
                    decomAban_model.FieldId = concessionField?.Field_ID ?? null;
                    decomAban_model.WpYear = year;

                    if (myDecomAban == null)
                    {


                        decomAban_model.DateCreated = DateTime.Now;
                        decomAban_model.CreatedBy = WKPCompanyEmail;
                        await _context.DECOMMISSIONING_ABANDONMENTs.AddAsync(decomAban_model);
                    }
                    else
                    {


                        decomAban_model.DateCreated = myDecomAban.DateCreated;
                        decomAban_model.CreatedBy = myDecomAban.CreatedBy;
                        decomAban_model.DateUpdated = DateTime.Now;
                        decomAban_model.UpdatedBy = WKPCompanyEmail;
                        _context.DECOMMISSIONING_ABANDONMENTs.Remove(myDecomAban);
                        await _context.DECOMMISSIONING_ABANDONMENTs.AddAsync(decomAban_model);
                    }
                }
                else if (action == GeneralModel.Delete)
                {
                    _context.DECOMMISSIONING_ABANDONMENTs.Remove(myDecomAban);
                }
                save += await _context.SaveChangesAsync();
                // }
                // else
                // {
                // 	return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                // }


                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await _context.DECOMMISSIONING_ABANDONMENTs.FirstOrDefaultAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }




        [HttpPost("POST_ROYALTY")]
        public async Task<object> POST_ROYALTY([FromBody] Royalty royalty_model, string year, string omlName, string fieldName, string actionToDo)
        {
            int save = 0;

            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();

            Royalty myRoyalty;
            try
            {
                if (concessionField?.Field_Name != null)
                {
                    myRoyalty = await (from c in _context.Royalties where c.CompanyNumber == WKPCompanyNumber && c.OmlName == omlName && c.Field_ID == concessionField.Field_ID && c.Year == year select c).FirstOrDefaultAsync();
                }
                else
                {
                    myRoyalty = await (from c in _context.Royalties where c.CompanyNumber == WKPCompanyNumber && c.OmlName == omlName && c.Year == year select c).FirstOrDefaultAsync();
                }

                // if (!string.IsNullOrEmpty(id))
                // {
                // 	var getData = await (from c in _context.Royalties where c.CompanyNumber == WKPCompanyNumber && c.OmlName == omlName && c.Field_ID == Convert.ToInt32(fieldName) select c).FirstOrDefaultAsync();
                // 	if (action == GeneralModel.Delete)
                // 		_context.Royalties.Remove(getData);
                // 	save += _context.SaveChanges();
                // }
                //if (royalty_model != null)
                //{
                //var getData = await (from d in _context.Royalties where d.CompanyNumber == WKPCompanyNumber && d.Concession_ID == concessionField.Concession_ID && d.Year == year select d).FirstOrDefaultAsync();
                royalty_model.CompanyNumber = WKPCompanyNumber;
                royalty_model.Concession_ID = concessionField?.Concession_ID ?? null;
                royalty_model.OmlName = concessionField?.Concession_Name ?? null;
                royalty_model.Field_ID = concessionField?.Field_ID ?? null;
                royalty_model.Year = year;
                if (action == GeneralModel.Insert)
                {
                    if (myRoyalty == null)
                    {
                        royalty_model.Date_Created = DateTime.Now;
                        await _context.Royalties.AddAsync(royalty_model);
                    }
                    else
                    {

                        _context.Royalties.Remove(myRoyalty);
                        royalty_model.Date_Created = DateTime.Now;
                        await _context.Royalties.AddAsync(royalty_model);
                    }
                }
                else if (action == GeneralModel.Delete)
                {
                    _context.Royalties.Remove(myRoyalty);
                }
                save += await _context.SaveChangesAsync();
                // }
                // else
                // {
                // 	return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                // }


                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = new object();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }








        [HttpGet("GET_FORM_FIVE_SDCP")]
        public async Task<object> GET_FORM_FIVE_SDCP(string omlName, string fieldName, string year)
        {
            try
            {
                var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
                var HSESustainable_CSR = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                var HSESustainable_Question = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();


                // var HSESustainable_Capital = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                var HSESustainable_MOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();


                var HSESustainable_Schorlarship_CSR = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                var HSESustainable_Schorlarship = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                var HSESustainable_Training_CSR = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                //Musa
                var HSESustainableDevProgramCsr = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                var HSESustainable_TrainingDetails_CSR = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                var PictureUpload = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                //List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU> HSESustainable_MOU;
                //if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
                //{
                //    HSESustainable_MOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //}
                //else
                //{
                //    HSESustainable_MOU = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                //}

                return new
                {
                    HSESustainable_CSR = HSESustainable_CSR,
                    HSESustainable_Question = HSESustainable_Question,
                    HSESustainableDevProjProgramCsr = HSESustainableDevProgramCsr,
                    HSESustainable_Schorlarship_CSR = HSESustainable_Schorlarship_CSR,
                    HSESustainable_MOU = HSESustainable_MOU,
                    HSESustainable_Schorlarship = HSESustainable_Schorlarship,
                    HSESustainable_Training_CSR = HSESustainable_Training_CSR,
                    HSESustainable_TrainingDetails_CSR = HSESustainable_TrainingDetails_CSR,
                    PictureUpload = PictureUpload
                };

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpPost("POST_CONCESSION_SITUATION")]
        public async Task<object> POST_CONCESSION_SITUATION([FromBody] CONCESSION_SITUATION concession_situation_model, string year, string omlName, string fieldID, string actionToDo = null)
        {

            int save = 0;
            var ConcessionCONCESSION_SITUATION_Model = concession_situation_model;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldID);
            CONCESSION_SITUATION concessionDbData;

            try
            {
                #region Saving Concession Situations

                if (concessionField?.Field_Name != null)
                {
                    concessionDbData = await (from c in _context.CONCESSION_SITUATIONs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year == year select c).FirstOrDefaultAsync();
                }
                else
                {
                    concessionDbData = await (from c in _context.CONCESSION_SITUATIONs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year == year select c).FirstOrDefaultAsync();
                }


                ConcessionCONCESSION_SITUATION_Model.Companyemail = WKPCompanyEmail;
                ConcessionCONCESSION_SITUATION_Model.CompanyName = WKPCompanyName;
                ConcessionCONCESSION_SITUATION_Model.COMPANY_ID = WKPCompanyId;
                ConcessionCONCESSION_SITUATION_Model.Date_Updated = DateTime.Now;
                ConcessionCONCESSION_SITUATION_Model.Updated_by = WKPCompanyEmail;
                ConcessionCONCESSION_SITUATION_Model.Year = year;
                ConcessionCONCESSION_SITUATION_Model.OML_Name = omlName;

                if (action == GeneralModel.Insert)
                {
                    if (concessionDbData == null)
                    {
                        ConcessionCONCESSION_SITUATION_Model.COMPANY_ID = WKPCompanyId;
                        ConcessionCONCESSION_SITUATION_Model.CompanyNumber = WKPCompanyNumber;
                        ConcessionCONCESSION_SITUATION_Model.Created_by = WKPCompanyEmail;
                        ConcessionCONCESSION_SITUATION_Model.Date_Created = DateTime.Now;
                        ConcessionCONCESSION_SITUATION_Model.Field_ID = concessionField?.Field_ID ?? null;
                        ConcessionCONCESSION_SITUATION_Model.Field_Name = concessionField?.Field_Name ?? null;
                        await _context.CONCESSION_SITUATIONs.AddAsync(ConcessionCONCESSION_SITUATION_Model);
                    }
                    else
                    {
                        _context.CONCESSION_SITUATIONs.Remove(concessionDbData);
                        ConcessionCONCESSION_SITUATION_Model.Created_by = WKPCompanyId;
                        ConcessionCONCESSION_SITUATION_Model.Date_Created = DateTime.Now;
                        ConcessionCONCESSION_SITUATION_Model.Field_ID = concessionField?.Field_ID ?? null;
                        ConcessionCONCESSION_SITUATION_Model.Field_Name = concessionField?.Field_Name ?? null;
                        await _context.CONCESSION_SITUATIONs.AddAsync(ConcessionCONCESSION_SITUATION_Model);
                    }
                }
                else if (action == GeneralModel.Delete)
                {
                    _context.CONCESSION_SITUATIONs.Remove(concessionDbData);
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
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
                return BadRequest(new { message = $"Error : No CONCESSION_SITUATION_Model was passed for {actionToDo} process to be completed." });
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_GEOPHYSICAL_ACTIVITIES_ACQUISITION")]
        public async Task<object> POST_GEOPHYSICAL_ACTIVITIES_ACQUISITION([FromBody] GEOPHYSICAL_ACTIVITIES_ACQUISITION geophysical_activities_acquisition_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            try
            {
                GEOPHYSICAL_ACTIVITIES_ACQUISITION getgeophysical_activities_acquisition_model;
                #region Saving Geophysical Activites
                if (geophysical_activities_acquisition_model != null)
                {
                    if (concessionField?.Field_Name != null)
                    {
                        getgeophysical_activities_acquisition_model = await (from c in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.QUATER == geophysical_activities_acquisition_model.QUATER && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getgeophysical_activities_acquisition_model = await (from c in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.QUATER == geophysical_activities_acquisition_model.QUATER && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    geophysical_activities_acquisition_model.Companyemail = WKPCompanyEmail;
                    geophysical_activities_acquisition_model.CompanyName = WKPCompanyName;
                    geophysical_activities_acquisition_model.COMPANY_ID = WKPCompanyId;
                    geophysical_activities_acquisition_model.CompanyNumber = WKPCompanyNumber;
                    geophysical_activities_acquisition_model.Date_Updated = DateTime.Now;
                    geophysical_activities_acquisition_model.Updated_by = WKPCompanyId;
                    geophysical_activities_acquisition_model.Year_of_WP = year;
                    geophysical_activities_acquisition_model.OML_Name = omlName;
                    geophysical_activities_acquisition_model.Field_ID = concessionField?.Field_ID ?? null;
                    geophysical_activities_acquisition_model.Actual_year = year;
                    geophysical_activities_acquisition_model.proposed_year = (int.Parse(year) + 1).ToString();
                    geophysical_activities_acquisition_model.OML_ID = concessionField?.Concession_ID.ToString();

                    if (action == GeneralModel.Insert)
                    {

                        if (getgeophysical_activities_acquisition_model == null)
                        {
                            geophysical_activities_acquisition_model.Date_Created = DateTime.Now;
                            geophysical_activities_acquisition_model.Created_by = WKPCompanyId;
                            await _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.AddAsync(geophysical_activities_acquisition_model);
                        }
                        else
                        {
                            _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Remove(getgeophysical_activities_acquisition_model);
                            geophysical_activities_acquisition_model.Date_Created = getgeophysical_activities_acquisition_model.Date_Created;
                            geophysical_activities_acquisition_model.Created_by = getgeophysical_activities_acquisition_model.Created_by;
                            geophysical_activities_acquisition_model.Date_Updated = DateTime.Now;
                            geophysical_activities_acquisition_model.Updated_by = WKPCompanyId;
                            await _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.AddAsync(geophysical_activities_acquisition_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Remove(geophysical_activities_acquisition_model);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_geophysical_activities_acquisitions = new object();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_geophysical_activities_acquisitions, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_GEOPHYSICAL_ACTIVITIES_PROCESSING")]
        public async Task<object> POST_GEOPHYSICAL_ACTIVITIES_PROCESSING([FromBody] GEOPHYSICAL_ACTIVITIES_PROCESSING geophysical_activities_processing_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            try
            {
                GEOPHYSICAL_ACTIVITIES_PROCESSING getGeophysicalActivitesData;
                #region Saving Geophysical Activites
                if (geophysical_activities_processing_model != null)
                {
                    if (concessionField?.Field_Name != null)
                    {
                        getGeophysicalActivitesData = await (from c in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.QUATER == geophysical_activities_processing_model.QUATER && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getGeophysicalActivitesData = await (from c in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.QUATER == geophysical_activities_processing_model.QUATER && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }


                    geophysical_activities_processing_model.Companyemail = WKPCompanyEmail;
                    geophysical_activities_processing_model.CompanyName = WKPCompanyName;
                    geophysical_activities_processing_model.COMPANY_ID = WKPCompanyId;
                    geophysical_activities_processing_model.CompanyNumber = WKPCompanyNumber;
                    geophysical_activities_processing_model.Date_Updated = DateTime.Now;
                    geophysical_activities_processing_model.Updated_by = WKPCompanyId;
                    geophysical_activities_processing_model.Year_of_WP = year;
                    geophysical_activities_processing_model.OML_Name = omlName;
                    geophysical_activities_processing_model.Field_ID = concessionField?.Field_ID ?? null;
                    geophysical_activities_processing_model.Actual_year = year;
                    geophysical_activities_processing_model.proposed_year = (int.Parse(year) + 1).ToString();
                    geophysical_activities_processing_model.OML_ID = concessionField?.Concession_ID.ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getGeophysicalActivitesData == null)
                        {
                            geophysical_activities_processing_model.Date_Created = DateTime.Now;
                            geophysical_activities_processing_model.Created_by = WKPCompanyId;
                            await _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.AddAsync(geophysical_activities_processing_model);
                        }
                        else
                        {
                            _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Remove(getGeophysicalActivitesData);
                            geophysical_activities_processing_model.Date_Created = getGeophysicalActivitesData.Date_Created;
                            geophysical_activities_processing_model.Created_by = getGeophysicalActivitesData.Created_by;
                            geophysical_activities_processing_model.Date_Updated = DateTime.Now;
                            geophysical_activities_processing_model.Updated_by = WKPCompanyId;
                            await _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.AddAsync(geophysical_activities_processing_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Remove(geophysical_activities_processing_model);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = new object();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        //added by Musa
        [HttpPost("POST_HSE_OPERATIONS_SAFETY_CASE"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_OPERATIONS_SAFETY_CASE([FromForm] HSE_OPERATIONS_SAFETY_CASE operations_Sefety_Case_model, string omlName, string fieldName, string year, string actionToDo = null, int id = 0)
        {

            int save = 0;
            int Id = operations_Sefety_Case_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            HSE_OPERATIONS_SAFETY_CASE getOperationSafetyCaseData;
            try
            {

                #region Saving Operation Safety Case
                if (id > 0 || operations_Sefety_Case_model != null)
                {

                    if (id > 0)
                    {
                        getOperationSafetyCaseData = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.Id == id select c).FirstOrDefaultAsync();

                        if (getOperationSafetyCaseData != null)
                        {
                            _context.HSE_OPERATIONS_SAFETY_CASEs.Remove(getOperationSafetyCaseData);
                        }
                    }
                    else
                    {
                        if (concessionField.Field_Name != null)
                        {
                            getOperationSafetyCaseData = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        }
                        else
                        {
                            getOperationSafetyCaseData = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        }

                        operations_Sefety_Case_model.Companyemail = WKPCompanyEmail;
                        operations_Sefety_Case_model.CompanyName = WKPCompanyName;
                        operations_Sefety_Case_model.COMPANY_ID = WKPCompanyId;
                        operations_Sefety_Case_model.CompanyNumber = WKPCompanyNumber;
                        operations_Sefety_Case_model.Date_Updated = DateTime.Now;
                        operations_Sefety_Case_model.Updated_by = WKPCompanyId;
                        operations_Sefety_Case_model.Year_of_WP = year;
                        operations_Sefety_Case_model.OML_Name = omlName;
                        operations_Sefety_Case_model.Field_ID = concessionField?.Field_ID ?? null;
                        //operations_Sefety_Case_model.Actual_year = year;
                        //operations_Sefety_Case_model.proposed_year = (int.Parse(year) + 1).ToString();

                        #region file section
                        var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                        var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                        if (file1 != null)
                        {
                            string docName = "Evidence of Operations Safety Case Approval";
                            operations_Sefety_Case_model.Evidence_of_Operations_Safety_Case_Approval = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"HRDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (operations_Sefety_Case_model.Evidence_of_Operations_Safety_Case_Approval == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            //else
                            //    operations_Sefety_Case_model. = blobname1;
                        }
                        else
                        {
                            operations_Sefety_Case_model.Evidence_of_Operations_Safety_Case_Approval = null;
                        }
                        #endregion

                        if (action == GeneralModel.Insert)
                        {
                            if (getOperationSafetyCaseData == null)
                            {
                                operations_Sefety_Case_model.Date_Created = DateTime.Now;
                                operations_Sefety_Case_model.Created_by = WKPCompanyId;
                                await _context.HSE_OPERATIONS_SAFETY_CASEs.AddAsync(operations_Sefety_Case_model);
                            }
                            else
                            {
                                _context.HSE_OPERATIONS_SAFETY_CASEs.Remove(getOperationSafetyCaseData);

                                operations_Sefety_Case_model.Date_Created = operations_Sefety_Case_model.Date_Created;
                                operations_Sefety_Case_model.Created_by = operations_Sefety_Case_model.Created_by;
                                operations_Sefety_Case_model.Date_Updated = DateTime.Now;
                                operations_Sefety_Case_model.Updated_by = WKPCompanyId;
                                await _context.HSE_OPERATIONS_SAFETY_CASEs.AddAsync(operations_Sefety_Case_model);
                            }
                        }
                        else if (action == GeneralModel.Delete)
                        {
                            _context.HSE_OPERATIONS_SAFETY_CASEs.Remove(getOperationSafetyCaseData);
                        }
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        //var All_Data = await (from c in _context.HSE_OPERATIONS_SAFETY_CASEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }







        [HttpPost("POST_HSE_ENVIRONMENTAL_MANAGEMENT_PLAN")]
        public async Task<object> POST_HSE_ENVIRONMENTAL_MANAGEMENT_PLAN([FromForm] HSE_ENVIRONMENTAL_MANAGEMENT_PLAN environment_Management_Plan_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            int Id = environment_Management_Plan_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            try
            {

                #region Saving Operation Safety Case
                if (environment_Management_Plan_model != null)
                {
                    HSE_ENVIRONMENTAL_MANAGEMENT_PLAN getOperationSafetyCaseData;
                    if (concessionField.Field_Name != null)
                    {
                        getOperationSafetyCaseData = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getOperationSafetyCaseData = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    environment_Management_Plan_model.Companyemail = WKPCompanyEmail;
                    environment_Management_Plan_model.CompanyName = WKPCompanyName;
                    environment_Management_Plan_model.COMPANY_ID = WKPCompanyId;
                    environment_Management_Plan_model.CompanyNumber = WKPCompanyNumber;
                    environment_Management_Plan_model.Date_Updated = DateTime.Now;
                    environment_Management_Plan_model.Updated_by = WKPCompanyId;
                    environment_Management_Plan_model.Year_of_WP = year;
                    environment_Management_Plan_model.OML_Name = omlName;
                    environment_Management_Plan_model.Field_ID = concessionField?.Field_ID ?? null;
                    //operations_Sefety_Case_model.Actual_year = year;
                    //operations_Sefety_Case_model.proposed_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getOperationSafetyCaseData == null)
                        {
                            environment_Management_Plan_model.Date_Created = DateTime.Now;
                            environment_Management_Plan_model.Created_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs.AddAsync(environment_Management_Plan_model);
                        }
                        else
                        {
                            _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs.Remove(getOperationSafetyCaseData);

                            environment_Management_Plan_model.Date_Created = environment_Management_Plan_model.Date_Created;
                            environment_Management_Plan_model.Created_by = environment_Management_Plan_model.Created_by;
                            environment_Management_Plan_model.Date_Updated = DateTime.Now;
                            environment_Management_Plan_model.Updated_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs.AddAsync(environment_Management_Plan_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs.Remove(getOperationSafetyCaseData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        //var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_EFFLUENT_MONITORING_COMPLIANCE"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_EFFLUENT_MONITORING_COMPLIANCE([FromForm] HSE_EFFLUENT_MONITORING_COMPLIANCE Effluenct_Monitoring_Complience_Mode, string omlName, string fieldName, string year, string actionToDo = null, int id = 0)
        {

            int save = 0;
            int Id = Effluenct_Monitoring_Complience_Mode.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            HSE_EFFLUENT_MONITORING_COMPLIANCE getData;


            try
            {

                #region Saving Operation Safety Case
                if (id > 0 || Effluenct_Monitoring_Complience_Mode != null)
                {

                    if (id > 0)
                    {
                        getData = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.Id == id select c).FirstOrDefaultAsync();
                        _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.Remove(getData);

                    }

                    else
                    {


                        if (concessionField.Field_Name != null)
                        {
                            getData = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        }
                        else
                        {
                            getData = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        }

                        Effluenct_Monitoring_Complience_Mode.Companyemail = WKPCompanyEmail;
                        Effluenct_Monitoring_Complience_Mode.CompanyName = WKPCompanyName;
                        Effluenct_Monitoring_Complience_Mode.COMPANY_ID = WKPCompanyId;
                        Effluenct_Monitoring_Complience_Mode.CompanyNumber = WKPCompanyNumber.ToString();
                        Effluenct_Monitoring_Complience_Mode.Date_Updated = DateTime.Now;
                        Effluenct_Monitoring_Complience_Mode.Updated_by = WKPCompanyId;
                        Effluenct_Monitoring_Complience_Mode.Year_of_WP = year;
                        Effluenct_Monitoring_Complience_Mode.OML_Name = omlName;
                        Effluenct_Monitoring_Complience_Mode.Field_ID = concessionField?.Field_ID ?? null;
                        //operations_Sefety_Case_model.Actual_year = year;
                        //operations_Sefety_Case_model.proposed_year = (int.Parse(year) + 1).ToString();



                        #region File processing
                        var files = Request.Form.Files;

                        if (files.Count >= 1)
                        {
                            var file1 = Request.Form.Files[0];
                            var blobname1 = blobService.Filenamer(file1);

                            if (file1 != null)
                            {
                                string docName = "Effluent Monitoring Complience";
                                Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"EffluenceMonitoringDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingFilename = blobname1;

                            }
                            else
                            {
                                Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingPath = null;
                                Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingFilename = null;
                            }
                        }
                        else
                        {
                            Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingPath = null;
                            Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingFilename = null;
                        }

                        if (Effluenct_Monitoring_Complience_Mode.AreThereEvidentOfSampling.ToLower() == "yes")
                        {
                            Effluenct_Monitoring_Complience_Mode.ReasonForNoEvidenceSampling = null;
                        }
                        else
                        {
                            Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingPath = null;
                            Effluenct_Monitoring_Complience_Mode.EvidenceOfSamplingFilename = null;
                        }
                        #endregion

                        if (action == GeneralModel.Insert)
                        {
                            if (getData == null)
                            {
                                Effluenct_Monitoring_Complience_Mode.Date_Created = DateTime.Now;
                                Effluenct_Monitoring_Complience_Mode.Created_by = WKPCompanyId;
                                await _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.AddAsync(Effluenct_Monitoring_Complience_Mode);
                            }
                            else
                            {
                                _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.Remove(getData);

                                Effluenct_Monitoring_Complience_Mode.Date_Created = Effluenct_Monitoring_Complience_Mode.Date_Created;
                                Effluenct_Monitoring_Complience_Mode.Created_by = Effluenct_Monitoring_Complience_Mode.Created_by;
                                Effluenct_Monitoring_Complience_Mode.Date_Updated = DateTime.Now;
                                Effluenct_Monitoring_Complience_Mode.Updated_by = WKPCompanyId;
                                await _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.AddAsync(Effluenct_Monitoring_Complience_Mode);
                            }
                        }
                        else if (action == GeneralModel.Delete)
                        {
                            _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.Remove(getData);
                        }
                    }
                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        var All_Data = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }









        [HttpPost("POST_HSE_GHG_MANAGEMENT_PLAN"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_GHG_MANAGEMENT_PLAN([FromForm] HSE_GHG_MANAGEMENT_PLAN ghg_Mgt_Plan_Model, string omlName, string fieldName, string year, string actionToDo = null, int id = 0)
        {

            int save = 0;
            int Id = ghg_Mgt_Plan_Model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            HSE_GHG_MANAGEMENT_PLAN getOperationSafetyCaseData;
            try
            {


                #region Saving Operation Safety Case
                if (ghg_Mgt_Plan_Model != null || id > 0)
                {

                    if (id > 0 && action == GeneralModel.Delete)
                    {
                        getOperationSafetyCaseData = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.Id == id select c).FirstOrDefaultAsync();

                        if (getOperationSafetyCaseData != null)
                        {
                            _context.HSE_GHG_MANAGEMENT_PLANs.Remove(getOperationSafetyCaseData);
                        }

                    }
                    else
                    {

                        if (concessionField.Field_Name != null)
                        {
                            getOperationSafetyCaseData = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanY_ID == WKPCompanyId && c.OmL_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        }
                        else
                        {
                            getOperationSafetyCaseData = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanY_ID == WKPCompanyId && c.OmL_Name == omlName && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                        }
                        ghg_Mgt_Plan_Model.companyemail = WKPCompanyEmail;
                        ghg_Mgt_Plan_Model.CompanyName = WKPCompanyName;
                        ghg_Mgt_Plan_Model.CompanY_ID = WKPCompanyId;
                        ghg_Mgt_Plan_Model.CompanyNumber = WKPCompanyNumber;
                        ghg_Mgt_Plan_Model.Date_Updated = DateTime.Now;
                        ghg_Mgt_Plan_Model.Updated_by = WKPCompanyId;
                        ghg_Mgt_Plan_Model.Year_of_WP = year;
                        ghg_Mgt_Plan_Model.OmL_Name = omlName;
                        ghg_Mgt_Plan_Model.Field_ID = concessionField?.Field_ID ?? null;
                        //operations_Sefety_Case_model.Actual_year = year;
                        //operations_Sefety_Case_model.proposed_year = (int.Parse(year) + 1).ToString();

                        #region File processing
                        //var files = Request.Form.Files;

                        if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                        {

                            IFormFile? file1 = null;
                            string blobname1 = string.Empty;
                            IFormFile? file2 = null;
                            string blobname2 = string.Empty;
                            IFormFile? file3 = null;
                            string blobname3 = string.Empty;
                            if (Request.Form.Files.Count == 1)
                            {
                                file1 = Request.Form.Files[0];
                                blobname1 = blobService.Filenamer(file1);
                                if (file1 != null)
                                {
                                    string docName = "GHG Approval";
                                    ghg_Mgt_Plan_Model.GHGApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"GHGApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                    if (ghg_Mgt_Plan_Model.GHGApprovalPath == null)
                                        return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                    else
                                        ghg_Mgt_Plan_Model.GHGApprovalFilename = blobname1;

                                }
                                else
                                {
                                    ghg_Mgt_Plan_Model.GHGApprovalPath = null;
                                    ghg_Mgt_Plan_Model.GHGApprovalFilename = null;
                                }
                            }
                            else
                            {
                                ghg_Mgt_Plan_Model.GHGApprovalPath = null;
                                ghg_Mgt_Plan_Model.GHGApprovalFilename = null;
                            }

                            if (Request.Form.Files.Count == 2)
                            {
                                file1 = Request.Form.Files[0];
                                file2 = Request.Form.Files[1];
                                blobname1 = blobService.Filenamer(file1);
                                blobname2 = blobService.Filenamer(file2);
                                if (file1 != null)
                                {
                                    string docName = "GHG Approval";
                                    ghg_Mgt_Plan_Model.GHGApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"GHGApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                    if (ghg_Mgt_Plan_Model.GHGApprovalPath == null)
                                        return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                    else
                                        ghg_Mgt_Plan_Model.GHGApprovalFilename = blobname1;

                                }
                                else
                                {
                                    ghg_Mgt_Plan_Model.GHGApprovalPath = null;
                                    ghg_Mgt_Plan_Model.GHGApprovalFilename = null;

                                }

                                if (file2 != null)
                                {
                                    string docName = "LDR Certificate";
                                    ghg_Mgt_Plan_Model.LDRCertificatePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"LDRCertificateDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                    if (ghg_Mgt_Plan_Model.LDRCertificatePath == null)
                                        return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                    else
                                        ghg_Mgt_Plan_Model.LDRCertificateFilename = blobname2;
                                }
                                else
                                {
                                    ghg_Mgt_Plan_Model.LDRCertificatePath = null;
                                    ghg_Mgt_Plan_Model.LDRCertificateFilename = null;

                                }
                            }
                            else
                            {
                                ghg_Mgt_Plan_Model.LDRCertificatePath = null;
                                ghg_Mgt_Plan_Model.LDRCertificateFilename = null;

                            }

                            if (Request.Form.Files.Count > 2)
                            {
                                file1 = Request.Form.Files[0];
                                file2 = Request.Form.Files[1];
                                file3 = Request.Form.Files[2];
                                blobname1 = blobService.Filenamer(file1);
                                blobname2 = blobService.Filenamer(file2);
                                blobname3 = blobService.Filenamer(file3);
                                if (file1 != null)
                                {
                                    string docName = "GHG Approval";
                                    ghg_Mgt_Plan_Model.GHGApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"GHGApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                    if (ghg_Mgt_Plan_Model.GHGApprovalPath == null)
                                        return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                    else
                                        ghg_Mgt_Plan_Model.GHGApprovalFilename = blobname1;

                                }
                                if (file2 != null)
                                {
                                    string docName = "LDR Certificate";
                                    ghg_Mgt_Plan_Model.LDRCertificatePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"LDRCertificateDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                    if (ghg_Mgt_Plan_Model.LDRCertificatePath == null)
                                        return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                    else
                                        ghg_Mgt_Plan_Model.LDRCertificateFilename = blobname2;

                                }
                                if (file3 != null)
                                {
                                    string docName = "LDR Certificate";
                                    ghg_Mgt_Plan_Model.LDRCertificatePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"LDRCertificateDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                    if (ghg_Mgt_Plan_Model.LDRCertificatePath == null)
                                        return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                    else
                                        ghg_Mgt_Plan_Model.LDRCertificateFilename = blobname3;

                                }
                            }
                        }

                        if (ghg_Mgt_Plan_Model.DoYouHaveGHG.ToLower() == "yes")
                        {
                            ghg_Mgt_Plan_Model.ReasonForNoGHG = null;
                        }
                        else
                        {
                            ghg_Mgt_Plan_Model.GHGApprovalPath = null;
                            ghg_Mgt_Plan_Model.GHGApprovalFilename = null;
                        }

                        if (ghg_Mgt_Plan_Model.DoYouHaveLDRCertificate.ToLower() == "yes")
                        {
                            ghg_Mgt_Plan_Model.ReasonForNoLDR = null;
                        }
                        else
                        {
                            ghg_Mgt_Plan_Model.LDRCertificatePath = null;
                            ghg_Mgt_Plan_Model.LDRCertificateFilename = null;
                        }

                        #endregion

                        if (action == GeneralModel.Insert)
                        {
                            if (getOperationSafetyCaseData == null)
                            {
                                ghg_Mgt_Plan_Model.Date_Created = DateTime.Now;
                                ghg_Mgt_Plan_Model.Created_by = WKPCompanyId;
                                await _context.HSE_GHG_MANAGEMENT_PLANs.AddAsync(ghg_Mgt_Plan_Model);
                            }
                            else
                            {
                                _context.HSE_GHG_MANAGEMENT_PLANs.Remove(getOperationSafetyCaseData);

                                ghg_Mgt_Plan_Model.Date_Created = ghg_Mgt_Plan_Model.Date_Created;
                                ghg_Mgt_Plan_Model.Created_by = ghg_Mgt_Plan_Model.Created_by;
                                ghg_Mgt_Plan_Model.Date_Updated = DateTime.Now;
                                ghg_Mgt_Plan_Model.Updated_by = WKPCompanyId;
                                await _context.HSE_GHG_MANAGEMENT_PLANs.AddAsync(ghg_Mgt_Plan_Model);
                            }
                        }
                        else if (action == GeneralModel.Delete)
                        {
                            _context.HSE_GHG_MANAGEMENT_PLANs.Remove(ghg_Mgt_Plan_Model);
                        }
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        var All_Data = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        string successMsg = "No update was made.";
                        var All_Data = await (from c in _context.HSE_GHG_MANAGEMENT_PLANs where c.CompanY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_HOST_COMMUNITIES_DEVELOPMENT"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_HOST_COMMUNITIES_DEVELOPMENT([FromForm] HSE_HOST_COMMUNITIES_DEVELOPMENT host_Community_Devt_Model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            int Id = host_Community_Devt_Model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            try
            {

                #region Saving Operation Safety Case
                if (host_Community_Devt_Model != null)
                {
                    HSE_HOST_COMMUNITIES_DEVELOPMENT getOperationSafetyCaseData;
                    if (concessionField.Field_Name != null)
                    {
                        getOperationSafetyCaseData = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getOperationSafetyCaseData = await (from c in _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    host_Community_Devt_Model.Companyemail = WKPCompanyEmail;
                    host_Community_Devt_Model.CompanyName = WKPCompanyName;
                    host_Community_Devt_Model.COMPANY_ID = WKPCompanyId;
                    host_Community_Devt_Model.CompanyNumber = WKPCompanyNumber.ToString();
                    host_Community_Devt_Model.Date_Updated = DateTime.Now;
                    host_Community_Devt_Model.Updated_by = WKPCompanyId;
                    host_Community_Devt_Model.Year_of_WP = year;
                    host_Community_Devt_Model.OML_Name = omlName;
                    host_Community_Devt_Model.Field_ID = concessionField?.Field_ID ?? null;
                    //operations_Sefety_Case_model.Actual_year = year;
                    //operations_Sefety_Case_model.proposed_year = (int.Parse(year) + 1).ToString();



                    #region File processing
                    //var files = Request.Form.Files;

                    if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                    {
                        IFormFile? file1 = null;
                        string blobname1 = string.Empty;

                        IFormFile? file2 = null;
                        string blobname2 = string.Empty;

                        IFormFile? file3 = null;
                        string blobname3 = string.Empty;

                        if (Request.Form.Files.Count == 1)
                        {
                            file1 = Request.Form.Files[0];
                            blobname1 = blobService.Filenamer(file1);
                            if (file1 != null)
                            {
                                string docName = "Upload Comm Dev Plan Approval";
                                host_Community_Devt_Model.UploadCommDevPlanApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"UploadCommDevPlanApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (host_Community_Devt_Model.UploadCommDevPlanApprovalPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    host_Community_Devt_Model.UploadCommDevPlanApprovalFilename = blobname1;

                            }
                            else
                            {
                                host_Community_Devt_Model.UploadCommDevPlanApprovalPath = null;
                                host_Community_Devt_Model.UploadCommDevPlanApprovalFilename = null;
                            }
                        }
                        if (Request.Form.Files.Count == 2)
                        {
                            file1 = Request.Form.Files[0];
                            file2 = Request.Form.Files[1];
                            blobname1 = blobService.Filenamer(file1);
                            blobname2 = blobService.Filenamer(file2);
                            if (file1 != null)
                            {
                                string docName = "Upload Comm Dev Plan Approval";
                                host_Community_Devt_Model.UploadCommDevPlanApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"UploadCommDevPlanApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (host_Community_Devt_Model.UploadCommDevPlanApprovalPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    host_Community_Devt_Model.UploadCommDevPlanApprovalFilename = blobname1;

                            }
                            else
                            {
                                host_Community_Devt_Model.UploadCommDevPlanApprovalPath = null;
                                host_Community_Devt_Model.UploadCommDevPlanApprovalFilename = null;
                            }

                            if (file2 != null)
                            {
                                string docName = "Evidence Of Pay Trust Fund";
                                host_Community_Devt_Model.EvidenceOfPayTrustFundPath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"EvidenceOfPayTrustFundDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (host_Community_Devt_Model.EvidenceOfPayTrustFundPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    host_Community_Devt_Model.EvidenceOfPayTrustFundFilename = blobname2;

                            }
                            else
                            {
                                host_Community_Devt_Model.EvidenceOfPayTrustFundPath = null;
                                host_Community_Devt_Model.EvidenceOfPayTrustFundFilename = null;
                            }

                        }
                        else
                        {
                            host_Community_Devt_Model.EvidenceOfPayTrustFundPath = null;
                            host_Community_Devt_Model.EvidenceOfPayTrustFundFilename = null;
                        }

                        if (Request.Form.Files.Count > 2)
                        {
                            file1 = Request.Form.Files[0];
                            file2 = Request.Form.Files[1];
                            file3 = Request.Form.Files[2];
                            blobname1 = blobService.Filenamer(file1);
                            blobname2 = blobService.Filenamer(file2);
                            blobname3 = blobService.Filenamer(file3);
                            if (file1 != null)
                            {
                                string docName = "Upload Comm Dev Plan Approval";
                                host_Community_Devt_Model.UploadCommDevPlanApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"UploadCommDevPlanApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (host_Community_Devt_Model.UploadCommDevPlanApprovalPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    host_Community_Devt_Model.UploadCommDevPlanApprovalFilename = blobname1;

                            }
                            else
                            {
                                host_Community_Devt_Model.UploadCommDevPlanApprovalPath = null;
                                host_Community_Devt_Model.UploadCommDevPlanApprovalFilename = null;
                            }

                            if (file2 != null)
                            {
                                string docName = "Evidence Of Pay Trust Fund";
                                host_Community_Devt_Model.EvidenceOfPayTrustFundPath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"EvidenceOfPayTrustFundDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (host_Community_Devt_Model.EvidenceOfPayTrustFundPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    host_Community_Devt_Model.EvidenceOfPayTrustFundFilename = blobname2;

                            }
                            else
                            {
                                host_Community_Devt_Model.EvidenceOfPayTrustFundPath = null;
                                host_Community_Devt_Model.EvidenceOfPayTrustFundFilename = null;
                            }

                            if (file3 != null)
                            {
                                string docName = "Evidence Of Reg Trust Fund ";
                                host_Community_Devt_Model.EvidenceOfRegTrustFundPath = await blobService.UploadFileBlobAsync("documents", file3.OpenReadStream(), file3.ContentType, $"EvidenceOfRegTrustFundDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (host_Community_Devt_Model.EvidenceOfRegTrustFundPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    host_Community_Devt_Model.EvidenceOfRegTrustFundFilename = blobname3;

                            }
                            else
                            {
                                host_Community_Devt_Model.EvidenceOfRegTrustFundPath = null;
                                host_Community_Devt_Model.EvidenceOfRegTrustFundFilename = null;
                            }
                        }
                        else
                        {
                            host_Community_Devt_Model.EvidenceOfRegTrustFundPath = null;
                            host_Community_Devt_Model.EvidenceOfRegTrustFundFilename = null;
                        }
                    }

                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        if (getOperationSafetyCaseData == null)
                        {
                            host_Community_Devt_Model.Date_Created = DateTime.Now;
                            host_Community_Devt_Model.Created_by = WKPCompanyId;
                            await _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs.AddAsync(host_Community_Devt_Model);
                        }
                        else
                        {
                            _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs.Remove(getOperationSafetyCaseData);

                            host_Community_Devt_Model.Date_Created = host_Community_Devt_Model.Date_Created;
                            host_Community_Devt_Model.Created_by = host_Community_Devt_Model.Created_by;
                            host_Community_Devt_Model.Date_Updated = DateTime.Now;
                            host_Community_Devt_Model.Updated_by = WKPCompanyId;
                            await _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs.AddAsync(host_Community_Devt_Model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs.Remove(getOperationSafetyCaseData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        var All_Data = await (from c in _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_DRILLING_OPERATIONS_CATEGORIES_OF_WELL")]
        public async Task<object> POST_DRILLING_OPERATIONS_CATEGORIES_OF_WELL([FromForm] DRILLING_OPERATIONS_CATEGORIES_OF_WELL drilling_operations_categories_of_well_model, string omlName, string fieldName, string year, string actionToDo = null)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                DRILLING_OPERATIONS_CATEGORIES_OF_WELL getData;
                #region Saving drilling data

                //var getData = new DRILLING_OPERATIONS_CATEGORIES_OF_WELL();
                if (drilling_operations_categories_of_well_model != null)
                {
                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.QUATER == drilling_operations_categories_of_well_model.QUATER && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.QUATER == drilling_operations_categories_of_well_model.QUATER && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }


                    drilling_operations_categories_of_well_model.Companyemail = WKPCompanyEmail;
                    drilling_operations_categories_of_well_model.CompanyName = WKPCompanyName;
                    drilling_operations_categories_of_well_model.COMPANY_ID = WKPCompanyId;
                    drilling_operations_categories_of_well_model.CompanyNumber = WKPCompanyNumber;
                    drilling_operations_categories_of_well_model.Date_Updated = DateTime.Now;
                    drilling_operations_categories_of_well_model.Updated_by = WKPCompanyId;
                    drilling_operations_categories_of_well_model.Year_of_WP = year;
                    drilling_operations_categories_of_well_model.OML_Name = omlName;
                    drilling_operations_categories_of_well_model.Field_ID = concessionField?.Field_ID ?? null;
                    drilling_operations_categories_of_well_model.Actual_year = year;
                    //drilling_operations_categories_of_well_model.proposed_year = (int.Parse(year) + 1).ToString();

                    // #region file section
                    // var files = Request.Form.Files;
                    // if (files.Count>1)
                    // {
                    // 	var file1 = Request.Form.Files[0];
                    // 	var file2 = Request.Form.Files[1];
                    // 	var blobname1 = blobService.Filenamer(file1);
                    // 	var blobname2 = blobService.Filenamer(file2);

                    // 	if (file1 != null)
                    // 	{
                    // 		string docName = "Field Discovery";
                    // 		drilling_operations_categories_of_well_model.FieldDiscoveryUploadFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"FieldDiscoveryDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                    // 		if (drilling_operations_categories_of_well_model.FieldDiscoveryUploadFilePath == null)
                    // 			return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to upload " + docName + " document.", StatusCode = ResponseCodes.Badrequest };
                    // 	}
                    // 	if (file2 != null)
                    // 	{
                    // 		string docName = "Hydrocarbon Count";
                    // 		drilling_operations_categories_of_well_model.HydrocarbonCountUploadFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"HydrocarbonCountDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                    // 		if (drilling_operations_categories_of_well_model.HydrocarbonCountUploadFilePath == null)
                    // 			return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to upload " + docName + " document.", StatusCode = ResponseCodes.Badrequest };
                    // 	}
                    // }
                    // #endregion

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            drilling_operations_categories_of_well_model.Date_Created = DateTime.Now;
                            drilling_operations_categories_of_well_model.Created_by = WKPCompanyId;
                            await _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.AddAsync(drilling_operations_categories_of_well_model);
                        }
                        else
                        {
                            drilling_operations_categories_of_well_model.Date_Created = getData.Date_Created;
                            drilling_operations_categories_of_well_model.Created_by = getData.Created_by;
                            drilling_operations_categories_of_well_model.Date_Updated = DateTime.Now;
                            drilling_operations_categories_of_well_model.Updated_by = WKPCompanyId;
                            _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Remove(getData);
                            await _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.AddAsync(drilling_operations_categories_of_well_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Remove(drilling_operations_categories_of_well_model);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                    #endregion

                }
                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_DRILLING_EACH_WELL_COST")]
        public async Task<object> POST_DRILLING_EACH_WELL_COST([FromBody] DRILLING_EACH_WELL_COST drilling_each_well_cost_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            try
            {

                #region Saving drilling data
                if (drilling_each_well_cost_model != null)
                {
                    DRILLING_EACH_WELL_COST getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.DRILLING_EACH_WELL_COSTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.QUATER == drilling_each_well_cost_model.QUATER && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.DRILLING_EACH_WELL_COSTs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.QUATER == drilling_each_well_cost_model.QUATER && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    drilling_each_well_cost_model.Companyemail = WKPCompanyEmail;
                    drilling_each_well_cost_model.CompanyName = WKPCompanyName;
                    drilling_each_well_cost_model.COMPANY_ID = WKPCompanyId;
                    drilling_each_well_cost_model.CompanyNumber = WKPCompanyNumber;
                    drilling_each_well_cost_model.Date_Updated = DateTime.Now;
                    drilling_each_well_cost_model.Updated_by = WKPCompanyId;
                    drilling_each_well_cost_model.Year_of_WP = year;
                    drilling_each_well_cost_model.OML_Name = omlName;
                    drilling_each_well_cost_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            drilling_each_well_cost_model.Date_Created = DateTime.Now;
                            drilling_each_well_cost_model.Created_by = WKPCompanyId;
                            await _context.DRILLING_EACH_WELL_COSTs.AddAsync(drilling_each_well_cost_model);
                        }
                        else
                        {
                            _context.DRILLING_EACH_WELL_COSTs.Remove(getData);
                            drilling_each_well_cost_model.Date_Created = getData.Date_Created;
                            drilling_each_well_cost_model.Created_by = getData.Created_by;
                            drilling_each_well_cost_model.Date_Updated = DateTime.Now;
                            drilling_each_well_cost_model.Updated_by = WKPCompanyId;
                            await _context.DRILLING_EACH_WELL_COSTs.AddAsync(drilling_each_well_cost_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.DRILLING_EACH_WELL_COSTs.Remove(drilling_each_well_cost_model);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action); //getMsg(action);
                        var All_Data = await (from c in _context.DRILLING_EACH_WELL_COSTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_DRILLING_EACH_WELL_COST_PROPOSED")]
        public async Task<object> POST_DRILLING_EACH_WELL_COST_PROPOSED([FromBody] DRILLING_EACH_WELL_COST_PROPOSED drilling_each_well_cost_proposed_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                #region Saving drilling data
                if (drilling_each_well_cost_proposed_model != null)
                {
                    DRILLING_EACH_WELL_COST_PROPOSED getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.QUATER == drilling_each_well_cost_proposed_model.QUATER && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.QUATER == drilling_each_well_cost_proposed_model.QUATER && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    drilling_each_well_cost_proposed_model.Companyemail = WKPCompanyEmail;
                    drilling_each_well_cost_proposed_model.CompanyName = WKPCompanyName;
                    drilling_each_well_cost_proposed_model.COMPANY_ID = WKPCompanyId;
                    drilling_each_well_cost_proposed_model.CompanyNumber = WKPCompanyNumber;
                    drilling_each_well_cost_proposed_model.Date_Updated = DateTime.Now;
                    drilling_each_well_cost_proposed_model.Updated_by = WKPCompanyId;
                    drilling_each_well_cost_proposed_model.Year_of_WP = year;
                    drilling_each_well_cost_proposed_model.OML_Name = omlName;
                    drilling_each_well_cost_proposed_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            drilling_each_well_cost_proposed_model.Date_Created = DateTime.Now;
                            drilling_each_well_cost_proposed_model.Created_by = WKPCompanyId;
                            await _context.DRILLING_EACH_WELL_COST_PROPOSEDs.AddAsync(drilling_each_well_cost_proposed_model);
                        }
                        else
                        {
                            drilling_each_well_cost_proposed_model.Date_Created = getData.Date_Created;
                            drilling_each_well_cost_proposed_model.Created_by = getData.Created_by;
                            drilling_each_well_cost_proposed_model.Date_Updated = DateTime.Now;
                            drilling_each_well_cost_proposed_model.Updated_by = WKPCompanyId;
                            _context.DRILLING_EACH_WELL_COST_PROPOSEDs.Remove(getData);
                            await _context.DRILLING_EACH_WELL_COST_PROPOSEDs.AddAsync(drilling_each_well_cost_proposed_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.DRILLING_EACH_WELL_COST_PROPOSEDs.Remove(drilling_each_well_cost_proposed_model);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        //[HttpPost("POST_FIELD_DEVELOPMENT_PLAN")]
        //public async Task<object> POST_FIELD_DEVELOPMENT_PLAN([FromForm] FIELD_DEVELOPMENT_PLAN field_development_plan_model, string omlName, string fieldName, string year, string actionToDo = null)
        //{


        //	int save = 0;
        //	string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
        //	var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
        //	List<FIELD_DEVELOPMENT_PLAN> getData;
        //	try
        //	{

        //		#region Saving FDP data
        //		if (field_development_plan_model != null)
        //		{

        //			//var getData = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();


        //			if (concessionField?.Field_Name != null)
        //			{
        //				getData = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID==concessionField.Field_ID && c.Year_of_WP == year select c).ToListAsync();

        //			}
        //			else
        //			{
        //				getData = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();

        //			}


        //			field_development_plan_model.Companyemail = WKPCompanyEmail;
        //			field_development_plan_model.CompanyName = WKPCompanyName;
        //			field_development_plan_model.COMPANY_ID = WKPCompanyId;
        //			field_development_plan_model.CompanyNumber = WKPCompanyNumber;
        //			field_development_plan_model.Date_Updated = DateTime.Now;
        //			field_development_plan_model.Updated_by = WKPCompanyId;
        //			field_development_plan_model.Year_of_WP = year;
        //			field_development_plan_model.OML_Name = omlName.ToUpper();
        //			field_development_plan_model.Field_ID = concessionField?.Field_ID ?? null;
        //			#region file section
        //			//string approved_FDP_Document = null;
        //			var file1 = Request.Form.Files[0];
        //			var blobname1 = blobService.Filenamer(file1);
        //			field_development_plan_model.FDPDocumentFilename = blobname1;

        //			if (file1 != null)
        //			{
        //				string docName = "Approved FDP";
        //				field_development_plan_model.Uploaded_approved_FDP_Document = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"FDPDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
        //				if (field_development_plan_model.Uploaded_approved_FDP_Document == null)
        //					return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
        //			}
        //		}


        //		// if (file1 != null)
        //		// {
        //		//     string docName = "Approved FDP";
        //		//     approved_FDP_Document = _helpersController.UploadDocument(file1, "FDPDocuments");
        //		//     if (approved_FDP_Document == null)
        //		//         return BadRequest(new { message = "Error : An error occured while trying to upload " + docName + " document."});
        //		// }
        //		#endregion

        //		// field_development_plan_model.Uploaded_approved_FDP_Document = file1 != null ? approved_FDP_Document.filePath : null;
        //		// field_development_plan_model.FDPDocumentFilename = file1 != null ? approved_FDP_Document.fileName : null;

        //		if (action == GeneralModel.Insert)
        //		{
        //			if (getData == null || getData.Count == 0)
        //			{
        //				field_development_plan_model.Date_Created = DateTime.Now;
        //				field_development_plan_model.Created_by = WKPCompanyId;
        //				await _context.FIELD_DEVELOPMENT_PLANs.AddAsync(field_development_plan_model);
        //			}
        //			else
        //			{
        //				field_development_plan_model.Date_Created = getData.FirstOrDefault().Date_Created;
        //				field_development_plan_model.Created_by = getData.FirstOrDefault().Created_by;
        //				field_development_plan_model.Date_Updated = DateTime.Now;
        //				field_development_plan_model.Updated_by = WKPCompanyId;
        //				_context.FIELD_DEVELOPMENT_PLANs.RemoveRange(getData);
        //				await _context.FIELD_DEVELOPMENT_PLANs.AddAsync(field_development_plan_model);
        //			}
        //		}
        //		else if (action == GeneralModel.Delete)
        //		{
        //			_context.FIELD_DEVELOPMENT_PLANs.Remove(field_development_plan_model);
        //		}
        //		save += await _context.SaveChangesAsync();


        //		if (save > 0)
        //		{
        //			string successMsg = getMsg(action);
        //			var All_Data = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
        //			return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
        //		}
        //		else
        //		{
        //			return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
        //		}


        //		return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
        //	#endregion

        //	}
        //	catch (Exception e)
        //	{
        //		return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError
        //			};
        //	}
        //}



        [HttpPost("POST_FIELD_DEVELOPMENT_PLAN")]
        public async Task<object> POST_FIELD_DEVELOPMENT_PLAN([FromForm] FIELD_DEVELOPMENT_PLAN field_development_plan_model, string omlName, string fieldName, string year, string actionToDo = null)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);


            try
            {
                List<FIELD_DEVELOPMENT_PLAN> getData;
                #region Saving FDP data
                if (field_development_plan_model != null)
                {

                    //var getData = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();


                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).ToListAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();

                    }

                    field_development_plan_model.Companyemail = WKPCompanyEmail;
                    field_development_plan_model.CompanyName = WKPCompanyName;
                    field_development_plan_model.COMPANY_ID = WKPCompanyId;
                    field_development_plan_model.CompanyNumber = WKPCompanyNumber;
                    field_development_plan_model.Date_Updated = DateTime.Now;
                    field_development_plan_model.Updated_by = WKPCompanyId;
                    field_development_plan_model.Year_of_WP = year;
                    field_development_plan_model.OML_Name = omlName.ToUpper();
                    field_development_plan_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (field_development_plan_model.Status == "Approved")
                    {
                        #region file section
                        //string approved_FDP_Document = null;
                        var file1 = Request.Form.Files[0];
                        var blobname1 = blobService.Filenamer(file1);
                        field_development_plan_model.FDPDocumentFilename = blobname1;

                        if (file1 != null)
                        {
                            string docName = "Approved FDP";
                            field_development_plan_model.Uploaded_approved_FDP_Document = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"FDPDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (field_development_plan_model.Uploaded_approved_FDP_Document == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        }
                    }

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            field_development_plan_model.Date_Created = DateTime.Now;
                            field_development_plan_model.Created_by = WKPCompanyId;
                            await _context.FIELD_DEVELOPMENT_PLANs.AddAsync(field_development_plan_model);
                        }
                        else
                        {
                            field_development_plan_model.Date_Created = getData.FirstOrDefault().Date_Created;
                            field_development_plan_model.Created_by = getData.FirstOrDefault().Created_by;
                            field_development_plan_model.Date_Updated = DateTime.Now;
                            field_development_plan_model.Updated_by = WKPCompanyId;
                            _context.FIELD_DEVELOPMENT_PLANs.RemoveRange(getData);
                            await _context.FIELD_DEVELOPMENT_PLANs.AddAsync(field_development_plan_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.FIELD_DEVELOPMENT_PLANs.Remove(field_development_plan_model);
                    }



                    // if (file1 != null)
                    // {
                    //     string docName = "Approved FDP";
                    //     approved_FDP_Document = _helpersController.UploadDocument(file1, "FDPDocuments");
                    //     if (approved_FDP_Document == null)
                    //         return BadRequest(new { message = "Error : An error occured while trying to upload " + docName + " document."});
                    // }
                    #endregion

                    // field_development_plan_model.Uploaded_approved_FDP_Document = file1 != null ? approved_FDP_Document.filePath : null;
                    // field_development_plan_model.FDPDocumentFilename = file1 != null ? approved_FDP_Document.fileName : null;


                    save += await _context.SaveChangesAsync();


                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }


                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }




        //	//do delete for this
        [HttpPost("POST_FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVE")]
        public async Task<object> POST_FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVE([FromBody] FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf field_development_plan_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving FDP data
                if (field_development_plan_model != null)
                {
                    FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year && c.Proposed_Development_well_name == field_development_plan_model.Proposed_Development_well_name select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year && c.Proposed_Development_well_name == field_development_plan_model.Proposed_Development_well_name select c).FirstOrDefaultAsync();
                    }

                    field_development_plan_model.Companyemail = WKPCompanyEmail;
                    field_development_plan_model.CompanyName = WKPCompanyName;
                    field_development_plan_model.COMPANY_ID = WKPCompanyId;
                    field_development_plan_model.CompanyNumber = WKPCompanyNumber;
                    field_development_plan_model.Date_Updated = DateTime.Now;
                    field_development_plan_model.Updated_by = WKPCompanyId;
                    field_development_plan_model.Year_of_WP = year;
                    field_development_plan_model.OML_Name = omlName;
                    field_development_plan_model.Field_ID = concessionField?.Field_ID ?? null;
                    field_development_plan_model.Field_Name = concessionField?.Field_Name ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            field_development_plan_model.Date_Created = DateTime.Now;
                            field_development_plan_model.Created_by = WKPCompanyId;
                            await _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.AddAsync(field_development_plan_model);
                        }
                        else
                        {
                            field_development_plan_model.Date_Created = getData.Date_Created;
                            field_development_plan_model.Created_by = getData.Created_by;
                            field_development_plan_model.Date_Updated = DateTime.Now;
                            field_development_plan_model.Updated_by = WKPCompanyId;
                            _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.Remove(getData);
                            await _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.AddAsync(field_development_plan_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.Remove(getData);
                    }
                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP")]
        public async Task<object> POST_FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP([FromBody] FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP field_development_plan_model, string omlName, string fieldName, string year, string actionToDo = null)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving FDP data
                if (field_development_plan_model != null)
                {

                    FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs where c.COMPANY_ID == WKPCompanyId && c.OML_Name == omlName && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    field_development_plan_model.Companyemail = WKPCompanyEmail;
                    field_development_plan_model.CompanyName = WKPCompanyName;
                    field_development_plan_model.COMPANY_ID = WKPCompanyId;
                    field_development_plan_model.CompanyNumber = WKPCompanyNumber;
                    field_development_plan_model.Date_Updated = DateTime.Now;
                    field_development_plan_model.Updated_by = WKPCompanyId;
                    field_development_plan_model.Year_of_WP = year;
                    field_development_plan_model.OML_Name = field_development_plan_model.OML_Name.ToUpper();
                    field_development_plan_model.Field_Name = concessionField?.Field_Name ?? null;
                    field_development_plan_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            field_development_plan_model.Date_Created = DateTime.Now;
                            field_development_plan_model.Created_by = WKPCompanyId;
                            await _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.AddAsync(field_development_plan_model);
                        }
                        else
                        {
                            field_development_plan_model.Date_Created = getData.Date_Created;
                            field_development_plan_model.Created_by = getData.Created_by;
                            field_development_plan_model.Date_Updated = DateTime.Now;
                            field_development_plan_model.Updated_by = WKPCompanyId;
                            await _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.AddAsync(field_development_plan_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.Remove(field_development_plan_model);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_FIELD_DEVELOPMENT_FIELDS_AND_STATUS")]
        public async Task<object> POST_FIELD_DEVELOPMENT_FIELDS_AND_STATUS([FromBody] FIELD_DEVELOPMENT_FIELDS_AND_STATUS field_development_plan_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving FDP data
                if (field_development_plan_model != null)
                {
                    FIELD_DEVELOPMENT_FIELDS_AND_STATUS getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    field_development_plan_model.Companyemail = WKPCompanyEmail;
                    field_development_plan_model.CompanyName = WKPCompanyName;
                    field_development_plan_model.COMPANY_ID = WKPCompanyId;
                    field_development_plan_model.CompanyNumber = WKPCompanyNumber;
                    field_development_plan_model.Date_Updated = DateTime.Now;
                    field_development_plan_model.Updated_by = WKPCompanyId;
                    field_development_plan_model.Year_of_WP = year;
                    field_development_plan_model.OML_Name = field_development_plan_model.OML_Name.ToUpper();
                    field_development_plan_model.Field_ID = concessionField?.Field_ID ?? null;
                    field_development_plan_model.Field_Name = concessionField?.Field_Name ?? null;
                    field_development_plan_model.OML_ID = concessionField.Concession_ID.ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            field_development_plan_model.Date_Created = DateTime.Now;
                            field_development_plan_model.Created_by = WKPCompanyId;
                            await _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.AddAsync(field_development_plan_model);
                        }
                        else
                        {
                            field_development_plan_model.Date_Created = getData.Date_Created;
                            field_development_plan_model.Created_by = getData.Created_by;
                            field_development_plan_model.Date_Updated = DateTime.Now;
                            field_development_plan_model.Updated_by = WKPCompanyId;
                            _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.Remove(getData);
                            await _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.AddAsync(field_development_plan_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        //do delete for this


        [HttpPost("POST_INITIAL_WELL_COMPLETION_JOB")]
        public async Task<object> POST_INITIAL_WELL_COMPLETION_JOB([FromBody] INITIAL_WELL_COMPLETION_JOB1 initial_well_completion_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            INITIAL_WELL_COMPLETION_JOB1 getData = new INITIAL_WELL_COMPLETION_JOB1();
            try
            {

                #region Saving FDP data
                if (initial_well_completion_model != null)
                {

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Field_ID == concessionField.Field_ID && c.QUATER == initial_well_completion_model.QUATER && c.Proposed_Initial_Name.ToUpper().Trim() == initial_well_completion_model.Proposed_Initial_Name.ToUpper().Trim() select c).FirstOrDefaultAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.QUATER == initial_well_completion_model.QUATER && c.Proposed_Initial_Name.ToUpper().Trim() == initial_well_completion_model.Proposed_Initial_Name.ToUpper().Trim() select c).FirstOrDefaultAsync();

                    }

                    initial_well_completion_model.Companyemail = WKPCompanyEmail;
                    initial_well_completion_model.CompanyName = WKPCompanyName;
                    initial_well_completion_model.COMPANY_ID = WKPCompanyId;
                    initial_well_completion_model.CompanyNumber = WKPCompanyNumber;


                    initial_well_completion_model.Year_of_WP = year;
                    initial_well_completion_model.OML_Name = omlName.ToUpper();
                    initial_well_completion_model.Field_ID = concessionField?.Field_ID ?? null;
                    initial_well_completion_model.Actual_year = year;
                    initial_well_completion_model.proposed_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            initial_well_completion_model.Date_Created = DateTime.Now;
                            initial_well_completion_model.Created_by = WKPCompanyId;
                            //initial_well_completion_model.Proposed_Well_Number=getDataList.Count()+1;
                            await _context.INITIAL_WELL_COMPLETION_JOBs1.AddAsync(initial_well_completion_model);
                        }
                        else
                        {
                            initial_well_completion_model.Date_Created = getData.Date_Created;
                            initial_well_completion_model.Created_by = getData.Created_by;
                            initial_well_completion_model.Date_Updated = DateTime.Now;
                            initial_well_completion_model.Updated_by = WKPCompanyId;
                            _context.INITIAL_WELL_COMPLETION_JOBs1.Remove(getData);
                            await _context.INITIAL_WELL_COMPLETION_JOBs1.AddAsync(initial_well_completion_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.INITIAL_WELL_COMPLETION_JOBs1.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        //added by Musa
        // [HttpPost("POST_BUDGET_CAPEX")]
        // public async Task<object> POST_BUDGET_CAPEX([FromBody] BUDGET_CAPEX Budget_Capex_model, string omlName, string fieldName, string year, string actionToDo)
        // {

        //     int save = 0;
        //     string action = actionToDo == null ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

        //     try
        //     {

        //         #region Saving FDP data
        //         if (Budget_Capex_model != null)
        //         {
        //             var getData = await (from c in _context.BUDGET_CAPices where c.OmL_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();



        //             Budget_Capex_model.Companyemail = WKPCompanyEmail;
        //             Budget_Capex_model.CompanyName = WKPCompanyName;
        //             Budget_Capex_model.Company_ID = WKPCompanyId;
        //             Budget_Capex_model.CompanyNumber = WKPCompanyNumber;
        //             Budget_Capex_model.Date_Updated = DateTime.Now;
        //             Budget_Capex_model.Updated_by = WKPCompanyId;
        //             Budget_Capex_model.Year_of_WP = year;
        //             Budget_Capex_model.OmL_Name = omlName.ToUpper();

        //             if (action == GeneralModel.Insert)
        //             {
        //                 if (getData == null)
        //                 {
        //                     Budget_Capex_model.Date_Created = DateTime.Now;
        //                     Budget_Capex_model.Created_by = WKPCompanyId;
        //                     //initial_well_completion_model.Proposed_Well_Number=getDataList.Count()+1;
        //                     await _context.BUDGET_CAPices.AddAsync(Budget_Capex_model);
        //                 }
        //                 else
        //                 {
        //                     Budget_Capex_model.Date_Created = getData.Date_Created;
        //                     Budget_Capex_model.Created_by = getData.Created_by;
        //                     Budget_Capex_model.Date_Updated = DateTime.Now;
        //                     Budget_Capex_model.Updated_by = WKPCompanyId;
        //                     _context.BUDGET_CAPices.Remove(getData);
        //                     await _context.BUDGET_CAPices.AddAsync(Budget_Capex_model);
        //                 }
        //             }
        //             else if (action == GeneralModel.Delete)
        //             {
        //                 _context.BUDGET_CAPices.Remove(getData);
        //             }

        //             save += await _context.SaveChangesAsync();

        //             if (save > 0)
        //             {
        //                 string successMsg = Messager.ShowMessage(action);
        //                 var All_Data = await (from c in _context.BUDGET_CAPices where c.OmL_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
        //                 return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
        //             }
        //             else
        //             {
        //                 return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
        //             }
        //         }

        //         return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
        //         #endregion

        //     }
        //     catch (Exception e)
        //     {
        //         return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
        //     }
        // }
        // //POST_BUDGET_ OPEX
        // [HttpPost("POST_BUDGET_OPEX")]
        // public async Task<object> POST_BUDGET_OPEX([FromBody] BUDGET_OPEX Budget_Opex_model, string omlName, string fieldName, string year, string actionToDo)
        // {

        //     int save = 0;
        //     string action = actionToDo == null ? GeneralModel.Insert.Trim().ToLower() : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

        //     try
        //     {

        //         #region Saving FDP data
        //         if (Budget_Opex_model != null)
        //         {
        //             var getData = await (from c in _context.BUDGET_OPEXes where c.OmL_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();



        //             Budget_Opex_model.Companyemail = WKPCompanyEmail;
        //             Budget_Opex_model.CompanyName = WKPCompanyName;
        //             Budget_Opex_model.Company_ID = WKPCompanyId;
        //             Budget_Opex_model.CompanyNumber = WKPCompanyNumber;
        //             Budget_Opex_model.Date_Updated = DateTime.Now;
        //             Budget_Opex_model.Updated_by = WKPCompanyId;
        //             Budget_Opex_model.Year_of_WP = year;
        //             Budget_Opex_model.OmL_Name = omlName.ToUpper();

        //             if (action == GeneralModel.Insert)
        //             {
        //                 if (getData == null)
        //                 {
        //                     Budget_Opex_model.Date_Created = DateTime.Now;
        //                     Budget_Opex_model.Created_by = WKPCompanyId;
        //                     //initial_well_completion_model.Proposed_Well_Number=getDataList.Count()+1;
        //                     await _context.BUDGET_OPEXes.AddAsync(Budget_Opex_model);
        //                 }
        //                 else
        //                 {
        //                     Budget_Opex_model.Date_Created = getData.Date_Created;
        //                     Budget_Opex_model.Created_by = getData.Created_by;
        //                     Budget_Opex_model.Date_Updated = DateTime.Now;
        //                     Budget_Opex_model.Updated_by = WKPCompanyId;
        //                     _context.BUDGET_OPEXes.Remove(getData);
        //                     await _context.BUDGET_OPEXes.AddAsync(Budget_Opex_model);
        //                 }
        //             }
        //             else if (action == GeneralModel.Delete)
        //             {
        //                 _context.BUDGET_OPEXes.Remove(getData);
        //             }

        //             save += await _context.SaveChangesAsync();

        //             if (save > 0)
        //             {
        //                 string successMsg = Messager.ShowMessage(action);
        //                 var All_Data = await (from c in _context.BUDGET_OPEXes where c.OmL_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
        //                 return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
        //             }
        //             else
        //             {
        //                 return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
        //             }
        //         }

        //         return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
        //         #endregion

        //     }
        //     catch (Exception e)
        //     {
        //         return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
        //     }
        // }


        [HttpPost("POST_WORKOVERS_RECOMPLETION_JOB")]
        public async Task<object> POST_WORKOVERS_RECOMPLETION_JOB([FromBody] WORKOVERS_RECOMPLETION_JOB1 workovers_recompletion_model, string omlName, string fieldName, string year, string actionToDo, int? id)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            WORKOVERS_RECOMPLETION_JOB1 getData;



            try
            {
                if (id > 0 || workovers_recompletion_model != null)
                {

                    if (id > 0 && workovers_recompletion_model.Id == 0)
                    {
                        getData = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.Id == id select c).FirstOrDefaultAsync();

                        _context.WORKOVERS_RECOMPLETION_JOBs1.Remove(getData);
                        action = GeneralModel.Delete;
                    }

                    #region Saving FDP data
                    else if (workovers_recompletion_model != null)
                    {
                        if (concessionField?.Field_Name != null)
                        {
                            getData = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.CompletionWellName.ToUpper().Trim() == workovers_recompletion_model.CompletionWellName.ToUpper().Trim() && c.Year_of_WP == year && c.QUATER == workovers_recompletion_model.QUATER select c).FirstOrDefaultAsync();

                        }
                        else
                        {
                            getData = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.CompletionWellName.ToUpper().Trim() == workovers_recompletion_model.CompletionWellName.ToUpper().Trim() && c.Year_of_WP == year && c.QUATER == workovers_recompletion_model.QUATER select c).FirstOrDefaultAsync();

                        }

                        workovers_recompletion_model.Companyemail = WKPCompanyEmail;
                        workovers_recompletion_model.CompanyName = WKPCompanyName;
                        workovers_recompletion_model.COMPANY_ID = WKPCompanyId;
                        workovers_recompletion_model.CompanyNumber = WKPCompanyNumber;
                        workovers_recompletion_model.Year_of_WP = year;
                        workovers_recompletion_model.OML_Name = omlName.ToUpper();
                        workovers_recompletion_model.Field_ID = concessionField?.Field_ID ?? null;
                        //workovers_recompletion_model.Actual_year = year;
                        //	workovers_recompletion_model.proposed_year = (int.Parse(year) + 1).ToString();
                        workovers_recompletion_model.proposed_year = year;

                        if (action == GeneralModel.Insert)
                        {
                            if (getData == null)
                            {
                                workovers_recompletion_model.Date_Created = DateTime.Now;
                                workovers_recompletion_model.Created_by = WKPCompanyId;
                                await _context.WORKOVERS_RECOMPLETION_JOBs1.AddAsync(workovers_recompletion_model);
                            }
                            else
                            {
                                workovers_recompletion_model.Date_Created = getData.Date_Created;
                                workovers_recompletion_model.Created_by = getData.Created_by;
                                workovers_recompletion_model.Date_Updated = DateTime.Now;
                                workovers_recompletion_model.Updated_by = WKPCompanyId;
                                _context.WORKOVERS_RECOMPLETION_JOBs1.Remove(getData);
                                await _context.WORKOVERS_RECOMPLETION_JOBs1.AddAsync(workovers_recompletion_model);
                            }
                        }
                        else if (action == GeneralModel.Delete)
                        {
                            _context.WORKOVERS_RECOMPLETION_JOBs1.Remove(getData);
                        }


                    }
                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {

                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }


                }
                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }







        [HttpPost("POST_OIL_CONDENSATE_PRODUCTION_ACTIVITY")]
        public async Task<object> POST_OIL_CONDENSATE_PRODUCTION_ACTIVITY([FromBody] OIL_CONDENSATE_PRODUCTION_ACTIVITy oil_condensate_activity_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                #region Saving Oil Condensate data
                if (oil_condensate_activity_model != null)
                {
                    OIL_CONDENSATE_PRODUCTION_ACTIVITy getData;
                    //var getData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }


                    oil_condensate_activity_model.Companyemail = WKPCompanyEmail;
                    oil_condensate_activity_model.CompanyName = WKPCompanyName;
                    oil_condensate_activity_model.COMPANY_ID = WKPCompanyId;
                    oil_condensate_activity_model.CompanyNumber = WKPCompanyNumber;
                    oil_condensate_activity_model.Date_Updated = DateTime.Now;
                    oil_condensate_activity_model.Updated_by = WKPCompanyId;
                    oil_condensate_activity_model.Year_of_WP = year;
                    oil_condensate_activity_model.OML_Name = omlName.ToUpper();
                    oil_condensate_activity_model.Field_ID = concessionField?.Field_ID ?? null;
                    //oil_condensate_activity_model.Actual_year = year;
                    oil_condensate_activity_model.proposed_year = year;


                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_condensate_activity_model.Date_Created = DateTime.Now;
                            oil_condensate_activity_model.Created_by = WKPCompanyId;
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.AddAsync(oil_condensate_activity_model);
                        }
                        else
                        {
                            oil_condensate_activity_model.Date_Created = getData.Date_Created;
                            oil_condensate_activity_model.Created_by = getData.Created_by;
                            oil_condensate_activity_model.Date_Updated = DateTime.Now;
                            oil_condensate_activity_model.Updated_by = WKPCompanyId;
                            _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.Remove(getData);
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.AddAsync(oil_condensate_activity_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);

                        //var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpPost("POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION")]
        public async Task<object> POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION([FromBody] Unitisation_Model unitisation_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo;
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                var oil_condensate_unitisation_model = new OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION()
                {
                    Has_DPR_been_notified = unitisation_model.Has_DPR_been_notified,
                    Has_the_other_party_been_notified = unitisation_model.Has_the_other_party_been_notified,
                    Is_any_of_your_field_straddling = unitisation_model.Is_any_of_your_field_straddling,
                    How_many_fields_straddle = unitisation_model.How_many_fields_straddle,
                    Is_there_a_Joint_Development = unitisation_model.Is_there_a_Joint_Development,
                    what_concession_field_straddling = unitisation_model.What_concession_field_straddling
                };

                #region Saving Oil Condensate data
                if (oil_condensate_unitisation_model != null)
                {
                    OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    oil_condensate_unitisation_model.Companyemail = WKPCompanyEmail;
                    oil_condensate_unitisation_model.CompanyName = WKPCompanyName;
                    oil_condensate_unitisation_model.COMPANY_ID = WKPCompanyId;
                    oil_condensate_unitisation_model.CompanyNumber = WKPCompanyNumber;
                    oil_condensate_unitisation_model.Year_of_WP = year;
                    oil_condensate_unitisation_model.OML_Name = omlName;
                    oil_condensate_unitisation_model.Field_ID = concessionField?.Field_ID ?? null;
                    oil_condensate_unitisation_model.Actual_year = year;
                    oil_condensate_unitisation_model.proposed_year = (int.Parse(year) + 1).ToString();

                    //#region file section
                    //UploadedDocument PUAUploadFile = null;
                    //UploadedDocument UUOAUploadFile = null;

                    // if (files[0] != null)
                    // {
                    //     string docName = "PUA";
                    //     PUAUploadFile = _helpersController.UploadDocument(files[0], "PUADocuments");
                    //     if (PUAUploadFile == null)
                    //         return BadRequest(new { message = "Error : An error occured while trying to upload " + docName + " document."});

                    // }
                    // if (files[1] != null)
                    // {
                    //     string docName = "UUOA";
                    //     UUOAUploadFile = _helpersController.UploadDocument(files[1], "UUOADocuments");
                    //     if (UUOAUploadFile == null)
                    //         return BadRequest(new { message = "Error : An error occured while trying to upload " + docName + " document."});

                    // }
                    // #endregion


                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_condensate_unitisation_model.Date_Created = DateTime.Now;
                            oil_condensate_unitisation_model.Created_by = WKPCompanyId;
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.AddAsync(oil_condensate_unitisation_model);
                        }
                        else
                        {
                            oil_condensate_unitisation_model.Date_Created = getData.Date_Created;
                            oil_condensate_unitisation_model.Created_by = getData.Created_by;
                            oil_condensate_unitisation_model.Date_Updated = DateTime.Now;
                            oil_condensate_unitisation_model.Updated_by = WKPCompanyId;
                            _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.Remove(getData);
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.AddAsync(oil_condensate_unitisation_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.Remove(getData);
                    }
                    save = 0;
                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {


                        string successMsg = Messager.ShowMessage(action);
                        //var returnData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                        // var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        [HttpPost("POST_GAS_PRODUCTION_ACTIVITY")]
        public async Task<object> POST_GAS_PRODUCTION_ACTIVITY([FromBody] GAS_PRODUCTION_ACTIVITy gas_production_model, List<IFormFile> files, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                GAS_PRODUCTION_ACTIVITy getData;
                #region Saving Oil Condensate data
                if (gas_production_model != null)
                {

                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    gas_production_model.Companyemail = WKPCompanyEmail;
                    gas_production_model.CompanyName = WKPCompanyName;
                    gas_production_model.COMPANY_ID = WKPCompanyId;
                    gas_production_model.CompanyNumber = WKPCompanyNumber;
                    gas_production_model.Date_Updated = DateTime.Now;
                    gas_production_model.Updated_by = WKPCompanyId;
                    gas_production_model.Year_of_WP = year;
                    gas_production_model.OML_Name = omlName;
                    gas_production_model.Field_ID = concessionField?.Field_ID ?? null;
                    //gas_production_model.Actual_year = year;
                    gas_production_model.proposed_year = year;

                    #region file section
                    //UploadedDocument Upload_NDR_payment_receipt_File = null;

                    // if (files[0] != null)
                    // {
                    //     string docName = "NDR Payment Receipt";
                    //     Upload_NDR_payment_receipt_File = _helpersController.UploadDocument(files[0], "NDRPaymentReceipt");
                    //     if (Upload_NDR_payment_receipt_File == null)
                    //         return BadRequest(new { message = "Error : An error occured while trying to upload " + docName + " document."});

                    // }
                    #endregion


                    //gas_production_model.Upload_NDR_payment_receipt = files[0] != null ? Upload_NDR_payment_receipt_File.filePath : null;
                    //gas_production_model.NDRFilename = files[0] != null ? Upload_NDR_payment_receipt_File.fileName : null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            gas_production_model.Date_Created = DateTime.Now;
                            gas_production_model.Created_by = WKPCompanyId;
                            await _context.GAS_PRODUCTION_ACTIVITIEs.AddAsync(gas_production_model);
                        }
                        else
                        {
                            gas_production_model.Date_Created = getData.Date_Created;
                            gas_production_model.Created_by = getData.Created_by;
                            gas_production_model.Date_Updated = DateTime.Now;
                            gas_production_model.Updated_by = WKPCompanyId;
                            _context.GAS_PRODUCTION_ACTIVITIEs.Remove(getData);
                            await _context.GAS_PRODUCTION_ACTIVITIEs.AddAsync(gas_production_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.GAS_PRODUCTION_ACTIVITIEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }



        [HttpPost("POST_NDR")]
        public async Task<object> POST_NDR([FromBody] NDR ndr_model, string omlName, string fieldName, string year, string actionToDo)
        {
            try
            {
                int save = 0;
                string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo; var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

                #region Saving NDR data
                if (ndr_model != null)
                {

                    NDR getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.NDRs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.NDRs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    ndr_model.Companyemail = WKPCompanyEmail;
                    ndr_model.CompanyName = WKPCompanyName;
                    ndr_model.COMPANY_ID = WKPCompanyId;
                    ndr_model.CompanyNumber = WKPCompanyNumber;
                    ndr_model.Date_Updated = DateTime.Now;
                    ndr_model.Updated_by = WKPCompanyId;
                    ndr_model.Year_of_WP = year;
                    ndr_model.OML_Name = omlName;
                    ndr_model.Field_ID = concessionField?.Field_ID ?? null;


                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            ndr_model.Date_Created = DateTime.Now;
                            ndr_model.Created_by = WKPCompanyId;
                            await _context.NDRs.AddAsync(ndr_model);
                        }
                        else
                        {
                            ndr_model.Date_Created = getData.Date_Created;
                            ndr_model.Created_by = getData.Created_by;
                            ndr_model.Date_Updated = DateTime.Now;
                            ndr_model.Updated_by = WKPCompanyId;
                            _context.NDRs.Remove(getData);
                            await _context.NDRs.AddAsync(ndr_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.NDRs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = new object();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_RESERVES_UPDATES_DEPLETION_RATE")]
        public async Task<object> POST_RESERVES_UPDATES_DEPLETION_RATE([FromBody] RESERVES_UPDATES_DEPLETION_RATE reserves_depletion_rate_model, string omlName, string fieldName, string year, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                RESERVES_UPDATES_DEPLETION_RATE getData;
                #region Saving RESERVES_UPDATES_DEPLETION_RATE
                if (reserves_depletion_rate_model != null)
                {

                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_DEPLETION_RATEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    reserves_depletion_rate_model.Companyemail = WKPCompanyEmail;
                    reserves_depletion_rate_model.CompanyName = WKPCompanyName;
                    reserves_depletion_rate_model.COMPANY_ID = WKPCompanyId;
                    reserves_depletion_rate_model.Date_Updated = DateTime.Now;
                    reserves_depletion_rate_model.CompanyNumber = WKPCompanyNumber;
                    reserves_depletion_rate_model.Updated_by = WKPCompanyId;
                    reserves_depletion_rate_model.Year_of_WP = year;
                    reserves_depletion_rate_model.OML_Name = omlName;
                    reserves_depletion_rate_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_depletion_rate_model.Date_Created = DateTime.Now;
                            reserves_depletion_rate_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_DEPLETION_RATEs.AddAsync(reserves_depletion_rate_model);
                        }
                        else
                        {
                            reserves_depletion_rate_model.Date_Created = getData.Date_Created;
                            reserves_depletion_rate_model.Created_by = getData.Created_by;
                            reserves_depletion_rate_model.Date_Updated = DateTime.Now;
                            reserves_depletion_rate_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_DEPLETION_RATEs.Remove(getData);
                            await _context.RESERVES_UPDATES_DEPLETION_RATEs.AddAsync(reserves_depletion_rate_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_DEPLETION_RATEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An Error occured while trying to submit this form." });
                    }
                }
                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }






        [HttpPost("POST_RESERVES_UPDATES_LIFE_INDEX")]
        public async Task<object> POST_RESERVES_UPDATES_LIFE_INDEX([FromBody] RESERVES_UPDATES_LIFE_INDEX reserves_life_index_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                RESERVES_UPDATES_LIFE_INDEX getData;
                #region Saving RESERVES_UPDATES_LIFE_INDEX data
                if (reserves_life_index_model != null)
                {


                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }


                    reserves_life_index_model.Companyemail = WKPCompanyEmail;
                    reserves_life_index_model.CompanyName = WKPCompanyName;
                    reserves_life_index_model.COMPANY_ID = WKPCompanyId;
                    reserves_life_index_model.CompanyNumber = WKPCompanyNumber;
                    reserves_life_index_model.Date_Updated = DateTime.Now;
                    reserves_life_index_model.Updated_by = WKPCompanyId;
                    reserves_life_index_model.Year_of_WP = year;
                    reserves_life_index_model.OML_Name = omlName;
                    reserves_life_index_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_life_index_model.Date_Created = DateTime.Now;
                            reserves_life_index_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_LIFE_INDices.AddAsync(reserves_life_index_model);
                        }
                        else
                        {
                            reserves_life_index_model.Date_Created = getData.Date_Created;
                            reserves_life_index_model.Created_by = getData.Created_by;
                            reserves_life_index_model.Date_Updated = DateTime.Now;
                            reserves_life_index_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_LIFE_INDices.Remove(getData);
                            await _context.RESERVES_UPDATES_LIFE_INDices.AddAsync(reserves_life_index_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_LIFE_INDices.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {



                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        [HttpPost("POST_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_PRECEEDING")]
        public async Task<object> POST_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_PRECEEDING([FromBody] Condensate_Status_Model condensateModel, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                var reserves_condensate_status_model = new RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE()
                {
                    Company_Reserves_AG = condensateModel.Company_Reserves_AG,
                    Company_Reserves_Oil = condensateModel.Company_Reserves_Oil,
                    Company_Reserves_Year = condensateModel.Company_Reserves_Year,
                    Company_Reserves_Condensate = condensateModel.Company_Reserves_Condensate,
                    Company_Reserves_NAG = condensateModel.Company_Reserves_NAG
                };

                RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE getData;
                #region Saving RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE data
                if (reserves_condensate_status_model != null)
                {
                    //var getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).FirstOrDefaultAsync();

                    //RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" select c).FirstOrDefaultAsync();
                    }

                    reserves_condensate_status_model.Companyemail = WKPCompanyEmail;
                    reserves_condensate_status_model.CompanyName = WKPCompanyName;
                    reserves_condensate_status_model.COMPANY_ID = WKPCompanyId;
                    reserves_condensate_status_model.CompanyNumber = WKPCompanyNumber;
                    reserves_condensate_status_model.Date_Updated = DateTime.Now;
                    reserves_condensate_status_model.Updated_by = WKPCompanyId;
                    reserves_condensate_status_model.Year_of_WP = year;
                    reserves_condensate_status_model.OML_Name = omlName;
                    reserves_condensate_status_model.Field_ID = concessionField?.Field_ID ?? null;
                    reserves_condensate_status_model.FLAG1 = "COMPANY_RESERVE_OF_PRECEDDING_YEAR";

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_condensate_status_model.Date_Created = DateTime.Now;
                            reserves_condensate_status_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.AddAsync(reserves_condensate_status_model);
                        }
                        else
                        {
                            reserves_condensate_status_model.Date_Created = getData.Date_Created;
                            reserves_condensate_status_model.Created_by = getData.Created_by;
                            reserves_condensate_status_model.Date_Updated = DateTime.Now;
                            reserves_condensate_status_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Remove(getData);
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.AddAsync(reserves_condensate_status_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {



                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }




        [HttpPost("POST_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT")]
        public async Task<object> POST_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT([FromBody] Condensate_Status_Model condensateModelCurrent, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {


                var reserves_condensate_status_model = new RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE()
                {
                    Company_Reserves_AG = condensateModelCurrent.Company_Reserves_AG,
                    Company_Reserves_Oil = condensateModelCurrent.Company_Reserves_Oil,
                    Company_Reserves_Year = condensateModelCurrent.Company_Reserves_Year,
                    Company_Reserves_Condensate = condensateModelCurrent.Company_Reserves_Condensate,
                    Company_Reserves_NAG = condensateModelCurrent.Company_Reserves_NAG
                };

                RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE getData;
                #region Saving RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE data
                if (reserves_condensate_status_model != null)
                {
                    //var getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).FirstOrDefaultAsync();

                    //RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE getData;

                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.FLAG1 == "COMPANY_CURRENT_RESERVE" select c).FirstOrDefaultAsync();
                    }

                    reserves_condensate_status_model.Companyemail = WKPCompanyEmail;
                    reserves_condensate_status_model.CompanyName = WKPCompanyName;
                    reserves_condensate_status_model.COMPANY_ID = WKPCompanyId;
                    reserves_condensate_status_model.CompanyNumber = WKPCompanyNumber;
                    reserves_condensate_status_model.Year_of_WP = year;
                    reserves_condensate_status_model.OML_Name = omlName;
                    reserves_condensate_status_model.Field_ID = concessionField?.Field_ID ?? null;
                    reserves_condensate_status_model.FLAG1 = "COMPANY_CURRENT_RESERVE";

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_condensate_status_model.Date_Created = DateTime.Now;
                            reserves_condensate_status_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.AddAsync(reserves_condensate_status_model);
                        }
                        else
                        {
                            reserves_condensate_status_model.Date_Created = getData.Date_Created;
                            reserves_condensate_status_model.Created_by = getData.Created_by;
                            reserves_condensate_status_model.Date_Updated = DateTime.Now;
                            reserves_condensate_status_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Remove(getData);
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.AddAsync(reserves_condensate_status_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }


        [HttpGet("GET_RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection")]
        public async Task<object> GET_RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection(string omlName, string fieldName, string year)
        {
            RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection FiveYearProjection;
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            if ((concessionField?.Consession_Type == "OML" || concessionField?.Consession_Type == "PML") && concessionField.Field_Name != null)
            {
                FiveYearProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.OML_Name.ToUpper() == omlName.ToUpper() && c.Year_of_WP == year select c).FirstOrDefaultAsync();
            }
            else
            {
                FiveYearProjection = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.OML_Name == omlName.ToUpper() && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
            }

            return new { FiveYearProjection = FiveYearProjection };
        }





        [HttpPost("POST_RESERVES_UPDATES_OIL_CONDENSATE_FIVEYEARS_PROJECTION")]
        public async Task<object> POST_RESERVES_UPDATES_OIL_CONDENSATE_FIVEYEARS_PROJECTION([FromBody] RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection reserves_condensate_status_model, string omlName, string fieldName, string year, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection getData;
                #region Saving RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection data
                if (reserves_condensate_status_model != null)
                {
                    //var getData = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Fiveyear_Projection_Year==reserves_condensate_status_model.Fiveyear_Projection_Year select c).FirstOrDefault();

                    //RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection getData;

                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Fiveyear_Projection_Year == reserves_condensate_status_model.Fiveyear_Projection_Year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Fiveyear_Projection_Year == reserves_condensate_status_model.Fiveyear_Projection_Year select c).FirstOrDefaultAsync();
                    }

                    reserves_condensate_status_model.Companyemail = WKPCompanyEmail;
                    reserves_condensate_status_model.CompanyName = WKPCompanyName;
                    reserves_condensate_status_model.COMPANY_ID = WKPCompanyId;
                    reserves_condensate_status_model.CompanyNumber = WKPCompanyNumber;
                    reserves_condensate_status_model.Year_of_WP = year;
                    reserves_condensate_status_model.OML_Name = omlName;
                    reserves_condensate_status_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_condensate_status_model.Date_Created = DateTime.Now;
                            reserves_condensate_status_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.AddAsync(reserves_condensate_status_model);
                        }
                        else
                        {
                            reserves_condensate_status_model.Date_Created = getData.Date_Created;
                            reserves_condensate_status_model.Created_by = getData.Created_by;
                            reserves_condensate_status_model.Date_Updated = DateTime.Now;
                            reserves_condensate_status_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.Remove(getData);
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.AddAsync(reserves_condensate_status_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpPost("POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION")]
        public async Task<object> POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION([FromBody] OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION oil_condensate_fiveyears_model, string omlName, string fieldName, string year, string actionToDo, int id)
        {

            int save = 0;
            string action = (String.IsNullOrWhiteSpace(actionToDo)) ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION getData;
            try
            {
                if (action == "delete" && id != null && id != 0)
                {
                    getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.Id == id select c).FirstOrDefaultAsync();
                    _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Remove(getData);
                }
                #region Saving OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION data
                else if (oil_condensate_fiveyears_model != null)
                {

                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Fiveyear_Timeline == oil_condensate_fiveyears_model.Fiveyear_Timeline select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Fiveyear_Timeline == oil_condensate_fiveyears_model.Fiveyear_Timeline select c).FirstOrDefaultAsync();
                    }

                    oil_condensate_fiveyears_model.Companyemail = WKPCompanyEmail;
                    oil_condensate_fiveyears_model.CompanyName = WKPCompanyName;
                    oil_condensate_fiveyears_model.COMPANY_ID = WKPCompanyId;
                    oil_condensate_fiveyears_model.CompanyNumber = WKPCompanyNumber;
                    oil_condensate_fiveyears_model.Date_Updated = DateTime.Now;
                    oil_condensate_fiveyears_model.Updated_by = WKPCompanyId;
                    oil_condensate_fiveyears_model.Year_of_WP = year;
                    oil_condensate_fiveyears_model.OML_Name = omlName;
                    oil_condensate_fiveyears_model.Field_ID = concessionField?.Field_ID ?? null;
                    oil_condensate_fiveyears_model.Actual_year = year;
                    oil_condensate_fiveyears_model.proposed_year = (int.Parse(year) + 1).ToString();


                    #region file section
                    //var file1 = Request.Form.Files[0];
                    //var blobname1 = blobService.Filenamer(file1);

                    //if (file1 != null)
                    //{
                    //	string docName = "Production Oil Condensate AGNAG";
                    //	oil_condensate_fiveyears_model.ProductionOilCondensateAGNAGUFilename = blobname1;
                    //	oil_condensate_fiveyears_model.ProductionOilCondensateAGNAGUploadFilePath= await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"ProductionOilCondensateAGNAGDocument/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                    //	if (oil_condensate_fiveyears_model.ProductionOilCondensateAGNAGUploadFilePath == null)
                    //		return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                    //}
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_condensate_fiveyears_model.Date_Created = DateTime.Now;
                            oil_condensate_fiveyears_model.Created_by = WKPCompanyId;
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.AddAsync(oil_condensate_fiveyears_model);
                        }
                        else
                        {
                            oil_condensate_fiveyears_model.Date_Created = getData.Date_Created;
                            oil_condensate_fiveyears_model.Created_by = getData.Created_by;
                            oil_condensate_fiveyears_model.Date_Updated = DateTime.Now;
                            oil_condensate_fiveyears_model.Updated_by = WKPCompanyId;
                            _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Remove(getData);
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.AddAsync(oil_condensate_fiveyears_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Remove(getData);
                    }
                }

                save += await _context.SaveChangesAsync();

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }


                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        [HttpPost("POST_RESERVES_UPDATES_OIL_CONDENSATE_COMPANY_ANNUAL_PRODUCTION")]
        public async Task<object> POST_RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION([FromBody] RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION reserves_update_production_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                #region Saving RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION data
                if (reserves_update_production_model != null)
                {
                    var getData = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    reserves_update_production_model.Companyemail = WKPCompanyEmail;
                    reserves_update_production_model.CompanyName = WKPCompanyName;
                    reserves_update_production_model.COMPANY_ID = WKPCompanyId;
                    reserves_update_production_model.CompanyNumber = WKPCompanyNumber;
                    reserves_update_production_model.Date_Updated = DateTime.Now;
                    reserves_update_production_model.Updated_by = WKPCompanyId;
                    reserves_update_production_model.Year_of_WP = year;
                    reserves_update_production_model.OML_Name = omlName;
                    reserves_update_production_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_update_production_model.Date_Created = DateTime.Now;
                            reserves_update_production_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.AddAsync(reserves_update_production_model);
                        }
                        else
                        {
                            reserves_update_production_model.Date_Created = getData.Date_Created;
                            reserves_update_production_model.Created_by = getData.Created_by;
                            reserves_update_production_model.Date_Updated = DateTime.Now;
                            reserves_update_production_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.Remove(getData);
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.AddAsync(reserves_update_production_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }





        [HttpPost("POST_RESERVES_UPDATES_OIL_CONDENSATE_RESERVES_Addition")]
        public async Task<object> POST_RESERVES_UPDATES_OIL_CONDENSATE_RESERVES_Addition([FromBody] RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition reserve_update_addition_model, string omlName, string fieldName, string year, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionFields = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition getData;
                #region Saving RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition data
                if (reserve_update_addition_model != null)
                {
                    if (concessionFields?.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.OML_Name == omlName && c.Field_ID == concessionFields.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }


                    reserve_update_addition_model.Companyemail = WKPCompanyEmail;
                    reserve_update_addition_model.CompanyName = WKPCompanyName;
                    reserve_update_addition_model.COMPANY_ID = WKPCompanyId;
                    reserve_update_addition_model.CompanyNumber = WKPCompanyNumber;
                    reserve_update_addition_model.Date_Updated = DateTime.Now;
                    reserve_update_addition_model.Updated_by = WKPCompanyId;
                    reserve_update_addition_model.Year_of_WP = year;
                    reserve_update_addition_model.OML_Name = omlName;
                    reserve_update_addition_model.Field_ID = concessionFields?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserve_update_addition_model.Date_Created = DateTime.Now;
                            reserve_update_addition_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.AddAsync(reserve_update_addition_model);
                        }
                        else
                        {
                            reserve_update_addition_model.Date_Created = getData.Date_Created;
                            reserve_update_addition_model.Created_by = getData.Created_by;
                            reserve_update_addition_model.Date_Updated = DateTime.Now;
                            reserve_update_addition_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.Remove(getData);
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.AddAsync(reserve_update_addition_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }

                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }







        [HttpPost("POST_RESERVES_UPDATES_OIL_CONDENSATE_RESERVES_DECLINE")]
        public async Task<object> POST_RESERVES_UPDATES_OIL_CONDENSATE_RESERVES_DECLINE([FromBody] RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE reserves_update_decline_model, string omlName, string fieldName, string year, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                #region Saving RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE data
                if (reserves_update_decline_model != null)
                {
                    var getData = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    reserves_update_decline_model.Companyemail = WKPCompanyEmail;
                    reserves_update_decline_model.CompanyName = WKPCompanyName;
                    reserves_update_decline_model.COMPANY_ID = WKPCompanyId;
                    reserves_update_decline_model.CompanyNumber = WKPCompanyNumber;
                    reserves_update_decline_model.Date_Updated = DateTime.Now;
                    reserves_update_decline_model.Updated_by = WKPCompanyId;
                    reserves_update_decline_model.Year_of_WP = year;
                    reserves_update_decline_model.OML_Name = omlName;
                    reserves_update_decline_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_update_decline_model.Date_Created = DateTime.Now;
                            reserves_update_decline_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.AddAsync(reserves_update_decline_model);
                        }
                        else
                        {
                            reserves_update_decline_model.Date_Created = getData.Date_Created;
                            reserves_update_decline_model.Created_by = getData.Created_by;
                            reserves_update_decline_model.Date_Updated = DateTime.Now;
                            reserves_update_decline_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.Remove(getData);
                            await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.AddAsync(reserves_update_decline_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


















        [HttpPost("POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_MONTHLY_ACTIVITY")]
        public async Task<object> POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_MONTHLY_ACTIVITY([FromBody] OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity oil_condensate_reserves_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity getData;
                #region Saving OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity data
                if (oil_condensate_reserves_model != null)
                {
                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Production_month == oil_condensate_reserves_model.Production_month select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Production_month == oil_condensate_reserves_model.Production_month select c).FirstOrDefaultAsync();
                    }


                    oil_condensate_reserves_model.Companyemail = WKPCompanyEmail;
                    oil_condensate_reserves_model.CompanyName = WKPCompanyName;
                    oil_condensate_reserves_model.COMPANY_ID = WKPCompanyId;
                    oil_condensate_reserves_model.CompanyNumber = WKPCompanyNumber;
                    oil_condensate_reserves_model.Date_Updated = DateTime.Now;
                    oil_condensate_reserves_model.Updated_by = WKPCompanyId;
                    oil_condensate_reserves_model.Year_of_WP = year;
                    oil_condensate_reserves_model.OML_Name = omlName;
                    oil_condensate_reserves_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_condensate_reserves_model.Date_Created = DateTime.Now;
                            oil_condensate_reserves_model.Created_by = WKPCompanyId;
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.AddAsync(oil_condensate_reserves_model);
                        }
                        else
                        {
                            oil_condensate_reserves_model.Date_Created = getData.Date_Created;
                            oil_condensate_reserves_model.Created_by = getData.Created_by;
                            oil_condensate_reserves_model.Date_Updated = DateTime.Now;
                            oil_condensate_reserves_model.Updated_by = WKPCompanyId;
                            _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.Remove(getData);
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.AddAsync(oil_condensate_reserves_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }



        [HttpPost("POST_RESERVES_REPLACEMENT_RATIO")]
        public async Task<object> POST_RESERVES_REPLACEMENT_RATIO([FromBody] RESERVES_REPLACEMENT_RATIO reserves_replacement_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                RESERVES_REPLACEMENT_RATIO getData;
                #region Saving RESERVES_REPLACEMENT_RATIO data
                if (reserves_replacement_model != null)
                {
                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Trend_Year == reserves_replacement_model.Trend_Year  select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }


                    reserves_replacement_model.Companyemail = WKPCompanyEmail;
                    reserves_replacement_model.CompanyName = WKPCompanyName;
                    reserves_replacement_model.COMPANY_ID = WKPCompanyId;
                    reserves_replacement_model.CompanyNumber = WKPCompanyNumber;
                    reserves_replacement_model.Date_Updated = DateTime.Now;
                    reserves_replacement_model.Updated_by = WKPCompanyId;
                    reserves_replacement_model.Year_of_WP = year;
                    reserves_replacement_model.OML_Name = omlName;
                    reserves_replacement_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            reserves_replacement_model.Date_Created = DateTime.Now;
                            reserves_replacement_model.Created_by = WKPCompanyId;
                            await _context.RESERVES_REPLACEMENT_RATIOs.AddAsync(reserves_replacement_model);
                        }
                        else
                        {
                            reserves_replacement_model.Date_Created = getData.Date_Created;
                            reserves_replacement_model.Created_by = getData.Created_by;
                            reserves_replacement_model.Date_Updated = DateTime.Now;
                            reserves_replacement_model.Updated_by = WKPCompanyId;
                            _context.RESERVES_REPLACEMENT_RATIOs.Remove(getData);
                            await _context.RESERVES_REPLACEMENT_RATIOs.AddAsync(reserves_replacement_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.RESERVES_REPLACEMENT_RATIOs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        //var All_Data = await (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }




        [HttpPost("POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_MONTHLY_ACTIVITIES_PROPOSED")]
        public async Task<object> POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_MONTHLY_ACTIVITIES_PROPOSED([FromBody] OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED oil_condensate_monthly_model, string omlName, string fieldName, string year, string actionToDo, int id)
        {

            int save = 0;
            string action = (String.IsNullOrWhiteSpace(actionToDo)) ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED getData;

            try
            {

                if (action == "delete" && id != null && id != 0)
                {
                    getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.Id == id select c).FirstOrDefaultAsync();
                    _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Remove(getData);


                }





                #region Saving OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED data
                else if (oil_condensate_monthly_model != null)
                {
                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Production_month == oil_condensate_monthly_model.Production_month select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Production_month == oil_condensate_monthly_model.Production_month select c).FirstOrDefaultAsync();
                    }


                    oil_condensate_monthly_model.Companyemail = WKPCompanyEmail;
                    oil_condensate_monthly_model.CompanyName = WKPCompanyName;
                    oil_condensate_monthly_model.COMPANY_ID = WKPCompanyId;
                    oil_condensate_monthly_model.CompanyNumber = WKPCompanyNumber;
                    oil_condensate_monthly_model.Date_Updated = DateTime.Now;
                    oil_condensate_monthly_model.Updated_by = WKPCompanyId;
                    oil_condensate_monthly_model.Year_of_WP = year;
                    oil_condensate_monthly_model.OML_Name = omlName;
                    oil_condensate_monthly_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_condensate_monthly_model.Date_Created = DateTime.Now;
                            oil_condensate_monthly_model.Created_by = WKPCompanyId;
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.AddAsync(oil_condensate_monthly_model);
                        }
                        else
                        {
                            oil_condensate_monthly_model.Date_Created = getData.Date_Created;
                            oil_condensate_monthly_model.Created_by = getData.Created_by;
                            oil_condensate_monthly_model.Date_Updated = DateTime.Now;
                            oil_condensate_monthly_model.Updated_by = WKPCompanyId;
                            _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Remove(getData);
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.AddAsync(oil_condensate_monthly_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Remove(getData);
                    }
                }

                save += await _context.SaveChangesAsync();

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }


                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }













        [HttpPost("POST_OIL_GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY")]
        public async Task<object> POST_OIL_GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY([FromBody] GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY oil_gas_domestic_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY data
                if (oil_gas_domestic_model != null)
                {
                    var getData = (from c in _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    oil_gas_domestic_model.Companyemail = WKPCompanyEmail;
                    oil_gas_domestic_model.CompanyName = WKPCompanyName;
                    oil_gas_domestic_model.COMPANY_ID = WKPCompanyId;
                    oil_gas_domestic_model.CompanyNumber = WKPCompanyNumber;
                    oil_gas_domestic_model.Date_Updated = DateTime.Now;
                    oil_gas_domestic_model.Updated_by = WKPCompanyId;
                    oil_gas_domestic_model.Year_of_WP = year;
                    oil_gas_domestic_model.OML_Name = omlName;
                    oil_gas_domestic_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_gas_domestic_model.Date_Created = DateTime.Now;
                            oil_gas_domestic_model.Created_by = WKPCompanyId;
                            await _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.AddAsync(oil_gas_domestic_model);
                        }
                        else
                        {
                            oil_gas_domestic_model.Date_Created = getData.Date_Created;
                            oil_gas_domestic_model.Created_by = getData.Created_by;
                            oil_gas_domestic_model.Date_Updated = DateTime.Now;
                            oil_gas_domestic_model.Updated_by = WKPCompanyId;
                            _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.Remove(getData);
                            await _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.AddAsync(oil_gas_domestic_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_BUDGET_ACTUAL_EXPENDITURE")]
        public async Task<object> POST_BUDGET_ACTUAL_EXPENDITURE([FromBody] BUDGET_ACTUAL_EXPENDITURE budget_actual_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.BUDGET_ACTUAL_EXPENDITUREs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (budget_actual_model != null)
                {
                    var getData = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var getData = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    budget_actual_model.Companyemail = WKPCompanyEmail;
                    budget_actual_model.CompanyName = WKPCompanyName;
                    budget_actual_model.COMPANY_ID = WKPCompanyId;
                    budget_actual_model.CompanyNumber = WKPCompanyNumber;
                    budget_actual_model.Date_Updated = DateTime.Now;
                    budget_actual_model.Updated_by = WKPCompanyId;
                    budget_actual_model.Year_of_WP = year;
                    budget_actual_model.OML_Name = omlName;
                    budget_actual_model.Field_ID = concessionField?.Field_ID ?? null;
                    budget_actual_model.Actual_year = year;
                    budget_actual_model.Proposed_year = (int.Parse(year) + 1).ToString();
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            budget_actual_model.Date_Created = DateTime.Now;
                            budget_actual_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_ACTUAL_EXPENDITUREs.AddAsync(budget_actual_model);
                        }
                        else
                        {
                            budget_actual_model.Date_Updated = DateTime.Now;
                            budget_actual_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_ACTUAL_EXPENDITUREs.RemoveRange(getData);
                            await _context.BUDGET_ACTUAL_EXPENDITUREs.AddAsync(budget_actual_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.BUDGET_ACTUAL_EXPENDITUREs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT")]
        public async Task<object> POST_BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT([FromBody] Budget_Proposal_Ngn_Usd_Model budgetProposal_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT getData;
            BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT budget_proposal_model = new BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT()
            {

                Budget_for_Direct_Exploration_and_Production_Activities_Dollars = budgetProposal_model.Budget_for_Direct_Exploration_and_Production_Activities_Dollars,
                Budget_for_Direct_Exploration_and_Production_Activities_Naira = budgetProposal_model.Budget_for_Direct_Exploration_and_Production_Activities_Naira,
                Budget_for_other_Activities_Dollars = budgetProposal_model.Budget_for_other_Activities_Dollars,
                Budget_for_other_Activities_Naira = budgetProposal_model.Budget_for_other_Activities_Naira
            };

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //var getData = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.Id == int.Parse(id) select c).FirstOrDefaultAsync();

                    if (action == GeneralModel.Delete.Trim().ToLower())
                        _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (budget_proposal_model != null)
                {

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Id == budgetProposal_model.Id select c).FirstOrDefaultAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Id == budgetProposal_model.Id select c).FirstOrDefaultAsync();

                    }

                    //var getData = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    budget_proposal_model.Companyemail = WKPCompanyEmail;
                    budget_proposal_model.CompanyName = WKPCompanyName;
                    budget_proposal_model.COMPANY_ID = WKPCompanyId;
                    budget_proposal_model.CompanyNumber = WKPCompanyNumber;
                    budget_proposal_model.Year_of_WP = year;
                    budget_proposal_model.OML_Name = omlName;
                    budget_proposal_model.Field_ID = concessionField?.Field_ID ?? null;
                    // budget_proposal_model.Actual_year = year;
                    budget_proposal_model.Proposed_year = year;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            budget_proposal_model.Date_Created = DateTime.Now;
                            budget_proposal_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.AddAsync(budget_proposal_model);
                        }
                        else
                        {
                            budget_proposal_model.Date_Created = getData.Date_Created;
                            budget_proposal_model.Created_by = getData.Created_by;
                            budget_proposal_model.Date_Updated = DateTime.Now;
                            budget_proposal_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Remove(getData);
                            await _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.AddAsync(budget_proposal_model);
                        }
                    }
                    else if (action == GeneralModel.Delete.Trim().ToLower())
                    {
                        _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITY")]
        public async Task<object> POST_BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy([FromBody] ExploratoryActivitiesModel budget, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy budget_exploratory_model = new BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy()
            {
                ACQUISITION_planned = budget.AcquisitioN_planned,
                APPRAISAL_planned = budget.AppraisaL_planned,
                EXPLORATION_planned = budget.ExploratioN_planned,
                OML_Name = budget.OmL_Name,
                PROCESSING_planned = budget.ProcessinG_planned,
                REPROCESSING_planned = budget.AcquisitioN_planned,
                Year_of_WP = budget.Year_of_WP
            };
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            List<BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy> getData;

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete.Trim().ToLower())
                        _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (budget_exploratory_model != null)
                {

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    //var getData = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    budget_exploratory_model.Companyemail = WKPCompanyEmail;
                    budget_exploratory_model.CompanyName = WKPCompanyName;
                    budget_exploratory_model.COMPANY_ID = WKPCompanyId;
                    budget_exploratory_model.CompanyNumber = WKPCompanyNumber;
                    budget_exploratory_model.Year_of_WP = year;
                    budget_exploratory_model.OML_Name = omlName;
                    budget_exploratory_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            budget_exploratory_model.Date_Created = DateTime.Now;
                            budget_exploratory_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.AddAsync(budget_exploratory_model);
                        }
                        else
                        {
                            budget_exploratory_model.Date_Created = getData.FirstOrDefault()?.Date_Created;
                            budget_exploratory_model.Created_by = getData.FirstOrDefault()?.Created_by;
                            budget_exploratory_model.Date_Updated = DateTime.Now;
                            budget_exploratory_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.RemoveRange(getData);
                            await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.AddAsync(budget_exploratory_model);
                        }
                    }
                    else if (action == GeneralModel.Delete.Trim().ToLower())
                    {
                        _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITY")]
        public async Task<object> POST_BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy([FromBody] BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_MODEL budget_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy budget_proposal_model = new BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy()
            {
                COMPLETION_planned = budget_model.CompletioN_planned,
                DEVELOPMENT_Actual = budget_model.DevelopmenT_Actual,
                DEVELOPMENT_planned = budget_model.DevelopmenT_planned,
                WORKOVER_planned = budget_model.WorkoveR_planned
            };

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            List<BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy> getData = new List<BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy>();

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete.Trim().ToLower())
                        _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (budget_proposal_model != null)
                {

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    //var getData = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    budget_proposal_model.Companyemail = WKPCompanyEmail;
                    budget_proposal_model.CompanyName = WKPCompanyName;
                    budget_proposal_model.COMPANY_ID = WKPCompanyId;
                    budget_proposal_model.CompanyNumber = WKPCompanyNumber;
                    budget_proposal_model.Year_of_WP = year;
                    budget_proposal_model.OML_Name = omlName;
                    budget_proposal_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            budget_proposal_model.Date_Created = DateTime.Now;
                            budget_proposal_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.AddAsync(budget_proposal_model);
                        }
                        else
                        {
                            budget_proposal_model.Date_Created = getData.FirstOrDefault().Date_Created;
                            budget_proposal_model.Created_by = getData.FirstOrDefault().Created_by;
                            budget_proposal_model.Date_Updated = DateTime.Now;
                            budget_proposal_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.RemoveRange(getData);
                            await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.AddAsync(budget_proposal_model);
                        }
                    }
                    else if (action == GeneralModel.Delete.Trim().ToLower())
                    {
                        _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }


            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_BUDGET_PERFORMANCE_PRODUCTION_COST")]
        public async Task<object> POST_BUDGET_PERFORMANCE_PRODUCTION_COST([FromBody] Budget_Performance_Model _budget_performance_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            BUDGET_PERFORMANCE_PRODUCTION_COST budget_performance_model = new BUDGET_PERFORMANCE_PRODUCTION_COST
            {

                DIRECT_COST_Actual = _budget_performance_model.DirecT_COST_Actual,
                DIRECT_COST_planned = _budget_performance_model.DirecT_COST_planned,
                INDIRECT_COST_Actual = _budget_performance_model.IndirecT_COST_Actual,
                INDIRECT_COST_planned = _budget_performance_model.IndirecT_COST_planned
            };


            List<BUDGET_PERFORMANCE_PRODUCTION_COST> getData;
            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete.Trim().ToLower())
                        _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (budget_performance_model != null)
                {

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    //var getData = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    budget_performance_model.Companyemail = WKPCompanyEmail;
                    budget_performance_model.CompanyName = WKPCompanyName;
                    budget_performance_model.COMPANY_ID = WKPCompanyId;
                    budget_performance_model.CompanyNumber = WKPCompanyNumber;
                    budget_performance_model.Year_of_WP = year;
                    budget_performance_model.OML_Name = omlName;
                    budget_performance_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            budget_performance_model.Date_Created = DateTime.Now;
                            budget_performance_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.AddAsync(budget_performance_model);
                        }
                        else
                        {
                            budget_performance_model.Date_Created = getData.FirstOrDefault().Date_Created;
                            budget_performance_model.Created_by = getData.FirstOrDefault().Created_by;
                            budget_performance_model.Date_Updated = DateTime.Now;
                            budget_performance_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.RemoveRange(getData);
                            await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.AddAsync(budget_performance_model);
                        }
                    }
                    else if (action == GeneralModel.Delete.Trim().ToLower())
                    {
                        _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT")]
        public async Task<object> POST_BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT([FromBody] BUDGET_FACILITIES_DEVELOPMENT_MODEL facilities_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            List<BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT> getData;
            BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT budget_facilities_model = new BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT()
            {
                CONCEPT_planned = facilities_model.ConcepT_planned,
                CONSTRUCTION_FABRICATION_planned = facilities_model.ConstructioN_FABRICATION_planned,
                DECOMMISSIONING_ABANDONMENT = facilities_model.DecommissioninG_ABANDONMENT,
                DETAILED_ENGINEERING_planned = facilities_model.DetaileD_ENGINEERING_planned,
                INSTALLATION_planned = facilities_model.InstallatioN_planned,
                PROCUREMENT_planned = facilities_model.ProcuremenT_planned,
                UPGRADE_MAINTENANCE_planned = facilities_model.UpgradE_MAINTENANCE_planned,
                FEED_planned = facilities_model.FeeD_planned

            };


            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (budget_facilities_model != null)
                {

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    }


                    //var getData = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    budget_facilities_model.Companyemail = WKPCompanyEmail;
                    budget_facilities_model.CompanyName = WKPCompanyName;
                    budget_facilities_model.COMPANY_ID = WKPCompanyId;
                    budget_facilities_model.CompanyNumber = WKPCompanyNumber;
                    budget_facilities_model.Year_of_WP = year;
                    budget_facilities_model.OML_Name = omlName;
                    budget_facilities_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            budget_facilities_model.Date_Created = DateTime.Now;
                            budget_facilities_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.AddAsync(budget_facilities_model);
                        }
                        else
                        {
                            budget_facilities_model.Date_Created = getData.FirstOrDefault().Date_Created;
                            budget_facilities_model.Created_by = getData.FirstOrDefault().Created_by;
                            budget_facilities_model.Date_Updated = DateTime.Now;
                            budget_facilities_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.RemoveRange(getData);
                            await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.AddAsync(budget_facilities_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE")]
        public async Task<object> POST_OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE([FromBody] OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE oil_gas_facility_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (oil_gas_facility_model != null)
                {
                    var getData = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    oil_gas_facility_model.Companyemail = WKPCompanyEmail;
                    oil_gas_facility_model.CompanyName = WKPCompanyName;
                    oil_gas_facility_model.COMPANY_ID = WKPCompanyId;
                    oil_gas_facility_model.CompanyNumber = WKPCompanyNumber;
                    oil_gas_facility_model.Date_Updated = DateTime.Now;
                    oil_gas_facility_model.Updated_by = WKPCompanyId;
                    oil_gas_facility_model.Year_of_WP = year;
                    oil_gas_facility_model.OML_Name = omlName;
                    oil_gas_facility_model.Field_ID = concessionField?.Field_ID ?? null;
                    oil_gas_facility_model.Actual_year = year;
                    oil_gas_facility_model.Proposed_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            oil_gas_facility_model.Date_Created = DateTime.Now;
                            oil_gas_facility_model.Created_by = WKPCompanyId;
                            await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.AddAsync(oil_gas_facility_model);
                        }
                        else
                        {
                            oil_gas_facility_model.Date_Created = getData.Date_Created;
                            oil_gas_facility_model.Created_by = getData.Created_by;
                            oil_gas_facility_model.Date_Updated = DateTime.Now;
                            oil_gas_facility_model.Updated_by = WKPCompanyId;
                            _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.Remove(getData);
                            await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.AddAsync(oil_gas_facility_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        [HttpPost("POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_NEW_TECHNOLOGY_CONFORMITY_ASSESSMENT")]
        public async Task<object> POST_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment([FromForm] OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment oil_condensate_assessment_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (oil_condensate_assessment_model != null)
                {
                    List<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment> getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    }
                    //var getData = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    oil_condensate_assessment_model.Companyemail = WKPCompanyEmail;
                    oil_condensate_assessment_model.CompanyName = WKPCompanyName;
                    oil_condensate_assessment_model.COMPANY_ID = WKPCompanyId;
                    oil_condensate_assessment_model.CompanyNumber = WKPCompanyNumber;
                    oil_condensate_assessment_model.Date_Updated = DateTime.Now;
                    oil_condensate_assessment_model.Updated_by = WKPCompanyId;
                    oil_condensate_assessment_model.Year_of_WP = year;
                    oil_condensate_assessment_model.OML_Name = omlName;
                    oil_condensate_assessment_model.Field_ID = concessionField?.Field_ID ?? null;




                    if (action == GeneralModel.Insert)
                    {

                        #region file section
                        if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                        {

                            var files = Request.Form.Files;
                            if (files.Count >= 1)
                            {
                                var file1 = Request.Form.Files[0];
                                //var file2 = Request.Form.Files[1];
                                var blobname1 = blobService.Filenamer(file1);
                                //var blobname2 = blobService.Filenamer(file2);

                                if (file1 != null)
                                {
                                    string docName = "Evidence of Inspection And Ugrade Main";
                                    oil_condensate_assessment_model.EvidenceOfInspectionAndUgradePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"EvidenceOfInspectionAndUgradePathDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                                    if (oil_condensate_assessment_model.EvidenceOfInspectionAndUgradePath == null)
                                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to upload " + docName + " document.", StatusCode = ResponseCodes.Badrequest };
                                    else
                                        oil_condensate_assessment_model.EvidenceOfInspectionAndUgradeFilename = blobname1;
                                }

                            }
                        }

                        #endregion





                        if (getData == null || getData.Count == 0)
                        {
                            oil_condensate_assessment_model.Date_Created = DateTime.Now;
                            oil_condensate_assessment_model.Created_by = WKPCompanyId;
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.AddAsync(oil_condensate_assessment_model);
                        }
                        else
                        {
                            //oil_condensate_assessment_model.Date_Created = getData.Date_Created;
                            //oil_condensate_assessment_model.Created_by = getData.Created_by;
                            oil_condensate_assessment_model.Date_Updated = DateTime.Now;
                            oil_condensate_assessment_model.Updated_by = WKPCompanyId;
                            _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.RemoveRange(getData);
                            await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.AddAsync(oil_condensate_assessment_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        [HttpPost("POST_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT")]
        public async Task<object> POST_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT([FromBody] OIL_AND_GAS_FACILITY_MAINTENANCE_Model _oil_gas_facility_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {



            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (_oil_gas_facility_model != null)
                {




                    var oil_gas_facility_model = new OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT()
                    {
                        Id = _oil_gas_facility_model.Id,
                        Actual_Proposed = _oil_gas_facility_model.Actual_Proposed,
                        Actual_capital_expenditure_Current_year_NGN = _oil_gas_facility_model.Actual_capital_expenditure_Current_year_NGN,
                        Actual_capital_expenditure_Current_year_USD = _oil_gas_facility_model.Actual_capital_expenditure_Current_year_USD,
                        Challenges = _oil_gas_facility_model.Challenges,
                        Comment_ = _oil_gas_facility_model.Comment_,
                        Completion_Status = _oil_gas_facility_model.Completion_Status,
                        Has_it_been_adopted_by_DPR_ = _oil_gas_facility_model.Has_it_been_adopted_by_DPR_,
                        New_Technology_ = _oil_gas_facility_model.New_Technology_,
                        Nigerian_Content_Value = _oil_gas_facility_model.Nigerian_Content_Value,
                        Planned_ongoing_and_routine_maintenance = _oil_gas_facility_model.Planned_ongoing_and_routine_maintenance,
                        Project_Stage = _oil_gas_facility_model.Project_Stage,
                        Project_Timeline = _oil_gas_facility_model.Project_Timeline,
                        Proposed_Capital_Expenditure_NGN = _oil_gas_facility_model.Proposed_Capital_Expenditure_NGN,
                        Proposed_Capital_Expenditure_USD = _oil_gas_facility_model.Proposed_Capital_Expenditure_USD,
                        Facility_Name = _oil_gas_facility_model.Facility_Name,
                        Facility_Type = _oil_gas_facility_model.Facility_Type,
                        Proposed_Projects = _oil_gas_facility_model.Proposed_Projects
                    };



                    List<OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT> getData;

                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Id == oil_gas_facility_model.Id select c).ToListAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Id == oil_gas_facility_model.Id select c).ToListAsync();
                    }
                    //var getData = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Actual_Proposed == oil_gas_facility_model.Actual_Proposed select c).ToListAsync();

                    oil_gas_facility_model.Companyemail = WKPCompanyEmail;
                    oil_gas_facility_model.CompanyName = WKPCompanyName;
                    oil_gas_facility_model.COMPANY_ID = WKPCompanyId;
                    oil_gas_facility_model.CompanyNumber = WKPCompanyNumber;
                    // oil_gas_facility_model.Date_Updated = DateTime.Now;
                    // oil_gas_facility_model.Updated_by = WKPCompanyId;
                    oil_gas_facility_model.Year_of_WP = year;
                    oil_gas_facility_model.OML_Name = omlName;
                    oil_gas_facility_model.Field_ID = concessionField?.Field_ID ?? null;
                    // oil_gas_facility_model.Actual_year = year;
                    //  oil_gas_facility_model.Proposed_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            oil_gas_facility_model.Date_Created = DateTime.Now;
                            oil_gas_facility_model.Created_by = WKPCompanyId;
                            await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.AddAsync(oil_gas_facility_model);
                        }
                        else
                        {
                            oil_gas_facility_model.Date_Created = getData[0].Date_Created;
                            oil_gas_facility_model.Created_by = getData[0].Created_by;
                            oil_gas_facility_model.Date_Updated = DateTime.Now;
                            oil_gas_facility_model.Updated_by = WKPCompanyId;
                            _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.RemoveRange(getData);
                            await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.AddAsync(oil_gas_facility_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        // [HttpPost("POST_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT")]
        // public async Task<object> POST_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT([FromBody] OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT oil_gas_facility_model, string omlName, string fieldName, string year, string id, string actionToDo)
        // {

        // 	int save = 0;
        // 	string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
        // 	var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

        // 	try
        // 	{

        // 		if (!string.IsNullOrEmpty(id))
        // 		{
        // 			var getData = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.Id == int.Parse(id) select c).FirstOrDefault();

        // 			if (action == GeneralModel.Delete)
        // 				_context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Remove(getData);
        // 			save += _context.SaveChanges();
        // 		}
        // 		else if (oil_gas_facility_model != null)
        // 		{
        // 			var getData = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
        // 			//var getData = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Actual_Proposed == oil_gas_facility_model.Actual_Proposed select c).ToListAsync();

        // 			oil_gas_facility_model.Companyemail = WKPCompanyEmail;
        // 			oil_gas_facility_model.CompanyName = WKPCompanyName;
        // 			oil_gas_facility_model.COMPANY_ID = WKPCompanyId;
        // 			oil_gas_facility_model.CompanyNumber = WKPCompanyNumber;
        // 			oil_gas_facility_model.Date_Updated = DateTime.Now;
        // 			oil_gas_facility_model.Updated_by = WKPCompanyId;
        // 			oil_gas_facility_model.Year_of_WP = year;
        // 			oil_gas_facility_model.OML_Name = omlName;
        // 			oil_gas_facility_model.Field_ID = concessionField?.Field_ID ?? null;
        // 			oil_gas_facility_model.Actual_year = year;
        // 			oil_gas_facility_model.Proposed_year = (int.Parse(year) + 1).ToString();

        // 			if (action == GeneralModel.Insert)
        // 			{
        // 				if (getData == null || getData.Count == 0)
        // 				{
        // 					oil_gas_facility_model.Date_Created = DateTime.Now;
        // 					oil_gas_facility_model.Created_by = WKPCompanyId;
        // 					await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.AddAsync(oil_gas_facility_model);
        // 				}
        // 				else
        // 				{
        // 					//oil_gas_facility_model.Date_Created = getData.Date_Created;
        // 					//oil_gas_facility_model.Created_by = getData.Created_by;
        // 					oil_gas_facility_model.Date_Updated = DateTime.Now;
        // 					oil_gas_facility_model.Updated_by = WKPCompanyId;
        // 					_context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.RemoveRange(getData);
        // 					await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.AddAsync(oil_gas_facility_model);
        // 				}
        // 			}
        // 			else if (action == GeneralModel.Delete)
        // 			{
        // 				_context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.RemoveRange(getData);
        // 			}

        // 			save += await _context.SaveChangesAsync();
        // 		}
        // 		else
        // 		{
        // 			return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
        // 		}
        // 		if (save > 0)
        // 		{
        // 			string successMsg = Messager.ShowMessage(action);
        // 			var All_Data = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
        // 			//var All_Data = await (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
        // 			return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
        // 		}
        // 		else
        // 		{
        // 			return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
        // 		}
        // 	}
        // 	catch (Exception e)
        // 	{
        // 		return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

        // 	}
        // }





        [HttpPost("POST_FACILITIES_PROJECT_PERFORMANCE")]
        public async Task<object> POST_FACILITIES_PROJECT_PERFORMANCE([FromForm] FACILITIES_PROJECT_PERFORMANCE facilities_project_model, string omlName, string fieldName,
                    string year, string id, string actionToDo, string evidenceOfDesignSafetyCaseApprovalPath, string evidenceOfDesignSafetyCaseApprovalFilename)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.FACILITIES_PROJECT_PERFORMANCEs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (facilities_project_model != null)
                {
                    FACILITIES_PROJECT_PERFORMANCE getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    facilities_project_model.Companyemail = WKPCompanyEmail;
                    facilities_project_model.CompanyName = WKPCompanyName;
                    facilities_project_model.COMPANY_ID = WKPCompanyId;
                    facilities_project_model.CompanyNumber = WKPCompanyNumber;
                    facilities_project_model.Date_Updated = DateTime.Now;
                    facilities_project_model.Updated_by = WKPCompanyId;
                    facilities_project_model.Year_of_WP = year;
                    //facilities_project_model.OML_Name = facilities_project_model.OML_Name.ToUpper();
                    facilities_project_model.OML_Name = omlName;
                    facilities_project_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (facilities_project_model.areThereEvidenceOfDesignSafetyCaseApproval == "Yes")
                    {

                        #region file section
                        if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                        {

                            var files = Request.Form.Files;
                            if (files.Count >= 1)
                            {
                                var file1 = Request.Form.Files[0];
                                //var file2 = Request.Form.Files[1];
                                var blobname1 = blobService.Filenamer(file1);
                                //var blobname2 = blobService.Filenamer(file2);

                                if (file1 != null)
                                {
                                    string docName = "Evidence of Design Safety Case Approval";
                                    facilities_project_model.evidenceOfDesignSafetyCaseApprovalPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"EvidenceofDesignSafetyCaseApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                                    if (facilities_project_model.evidenceOfDesignSafetyCaseApprovalPath == null)
                                        return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to upload " + docName + " document.", StatusCode = ResponseCodes.Badrequest };
                                    else
                                        facilities_project_model.evidenceOfDesignSafetyCaseApprovalFilename = blobname1;
                                }

                            }
                        }

                        #endregion
                    }
                    if (action == GeneralModel.Insert)
                    {
                        facilities_project_model.Date_Created = DateTime.Now;
                        facilities_project_model.Created_by = WKPCompanyId;
                        await _context.FACILITIES_PROJECT_PERFORMANCEs.AddAsync(facilities_project_model);
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.FACILITIES_PROJECT_PERFORMANCEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    // var All_Data = await (from c in _context.FACILITIES_PROJECT_PERFORMANCEs
                    // 					  where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year &&
                    // 					 c.evidenceOfDesignSafetyCaseApprovalPath == evidenceOfDesignSafetyCaseApprovalPath &&
                    // 					 c.evidenceOfDesignSafetyCaseApprovalFilename == evidenceOfDesignSafetyCaseApprovalFilename
                    // 					  select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpPost("POST_BUDGET_CAPEX_OPEX")]
        public async Task<object> POST_BUDGET_CAPEX_OPEX([FromBody] Capex_Opex_Model capex_Opex, string omlName, string fieldName, string year, string id, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            List<BUDGET_CAPEX_OPEX> getData = new List<BUDGET_CAPEX_OPEX>();




            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = (from c in _context.BUDGET_CAPEX_OPices where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action.Trim().ToLower() == GeneralModel.Delete.Trim().ToLower())
                        _context.BUDGET_CAPEX_OPices.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (capex_Opex != null)
                {
                    BUDGET_CAPEX_OPEX budget_capex_opex_model = new BUDGET_CAPEX_OPEX()
                    {
                        dollar = capex_Opex.Dollar,
                        Dollar_equivalent = capex_Opex.Dollar_equivalent,
                        Item_Description = capex_Opex.Item_Description,
                        Item_Type = capex_Opex.Item_Type,
                        naira = capex_Opex.Naira,
                        OML_Name = capex_Opex.Oml_Name,
                        remarks = capex_Opex.Remarks
                    };

                    if (concessionField?.Field_Name != null)
                    {
                        getData = await (from c in _context.BUDGET_CAPEX_OPices where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Item_Type == budget_capex_opex_model.Item_Type && c.Item_Description == budget_capex_opex_model.Item_Description && c.Year_of_WP == year select c).ToListAsync();

                    }
                    else
                    {
                        getData = await (from c in _context.BUDGET_CAPEX_OPices where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Item_Type == budget_capex_opex_model.Item_Type && c.Item_Description == budget_capex_opex_model.Item_Description && c.Year_of_WP == year select c).ToListAsync();

                    }


                    //var getData = await (from c in _context.BUDGET_CAPEX_OPices where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    budget_capex_opex_model.Companyemail = WKPCompanyEmail;
                    budget_capex_opex_model.CompanyName = WKPCompanyName;
                    budget_capex_opex_model.COMPANY_ID = WKPCompanyId;
                    budget_capex_opex_model.CompanyNumber = WKPCompanyNumber;
                    // budget_capex_opex_model.Date_Updated = DateTime.Now;
                    // budget_capex_opex_model.Updated_by = WKPCompanyId;
                    budget_capex_opex_model.Year_of_WP = year;
                    budget_capex_opex_model.OML_Name = omlName;
                    budget_capex_opex_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData?.Count == 0)
                        {
                            budget_capex_opex_model.Date_Created = DateTime.Now;
                            budget_capex_opex_model.Created_by = WKPCompanyId;
                            await _context.BUDGET_CAPEX_OPices.AddAsync(budget_capex_opex_model);
                        }
                        else
                        {
                            budget_capex_opex_model.Date_Created = getData.LastOrDefault().Date_Created;
                            budget_capex_opex_model.Created_by = getData.LastOrDefault().Created_by;
                            budget_capex_opex_model.Date_Updated = DateTime.Now;
                            budget_capex_opex_model.Updated_by = WKPCompanyId;
                            _context.BUDGET_CAPEX_OPices.RemoveRange(getData);
                            await _context.BUDGET_CAPEX_OPices.AddAsync(budget_capex_opex_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.BUDGET_CAPEX_OPices.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.BUDGET_CAPEX_OPices where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //var All_Data = await (from c in _context.BUDGET_CAPEX_OPices where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_NIGERIA_CONTENT_TRAINING")]
        public async Task<object> POST_NIGERIA_CONTENT_Training([FromBody] NIGERIA_CONTENT_Training nigeria_content_training_model, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving NIGERIA_CONTENT_Trainings data
                if (nigeria_content_training_model != null)
                {
                    var getData = await (from c in _context.NIGERIA_CONTENT_Trainings where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Actual_Proposed == nigeria_content_training_model.Actual_Proposed select c).ToListAsync();

                    nigeria_content_training_model.Companyemail = WKPCompanyEmail;
                    nigeria_content_training_model.CompanyName = WKPCompanyName;
                    nigeria_content_training_model.COMPANY_ID = WKPCompanyId;
                    nigeria_content_training_model.CompanyNumber = WKPCompanyNumber;
                    nigeria_content_training_model.Date_Updated = DateTime.Now;
                    nigeria_content_training_model.Updated_by = WKPCompanyId;
                    nigeria_content_training_model.Year_of_WP = year;
                    //nigeria_content_training_model.OML_Name = omlName;
                    //nigeria_content_training_model.Field_ID = concessionField?.Field_ID ?? null;
                    // nigeria_content_training_model.Actual_Proposed_Year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null || getData.Count == 0)
                        {
                            nigeria_content_training_model.Date_Created = DateTime.Now;
                            nigeria_content_training_model.Created_by = WKPCompanyId;
                            await _context.NIGERIA_CONTENT_Trainings.AddAsync(nigeria_content_training_model);
                        }
                        else
                        {
                            //nigeria_content_training_model.Date_Created = getData.Date_Created;
                            //nigeria_content_training_model.Created_by = getData.Created_by;
                            nigeria_content_training_model.Date_Updated = DateTime.Now;
                            nigeria_content_training_model.Updated_by = WKPCompanyId;
                            _context.NIGERIA_CONTENT_Trainings.RemoveRange(getData);
                            await _context.NIGERIA_CONTENT_Trainings.AddAsync(nigeria_content_training_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.NIGERIA_CONTENT_Trainings.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.NIGERIA_CONTENT_Trainings where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_NIGERIA_CONTENT_UPLOAD_SUCCESSION_PLAN")]
        public async Task<object> POST_NIGERIA_CONTENT_UPLOAD_SUCCESSION_PLAN([FromBody] NIGERIA_CONTENT_Upload_Succession_Plan nigeria_content_succession_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving NIGERIA_CONTENT_Upload_Succession_Plans data
                if (nigeria_content_succession_model != null)
                {
                    var getData = (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Actual_proposed == nigeria_content_succession_model.Actual_proposed select c).FirstOrDefault();

                    nigeria_content_succession_model.Companyemail = WKPCompanyEmail;
                    nigeria_content_succession_model.CompanyName = WKPCompanyName;
                    nigeria_content_succession_model.COMPANY_ID = WKPCompanyId;
                    nigeria_content_succession_model.CompanyNumber = WKPCompanyNumber;
                    nigeria_content_succession_model.Date_Updated = DateTime.Now;
                    nigeria_content_succession_model.Updated_by = WKPCompanyId;
                    nigeria_content_succession_model.Year_of_WP = year;
                    nigeria_content_succession_model.OML_Name = omlName;
                    nigeria_content_succession_model.Field_ID = concessionField?.Field_ID ?? null;
                    //nigeria_content_succession_model.Actual_Proposed_Year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            nigeria_content_succession_model.Date_Created = DateTime.Now;
                            nigeria_content_succession_model.Created_by = WKPCompanyId;
                            await _context.NIGERIA_CONTENT_Upload_Succession_Plans.AddAsync(nigeria_content_succession_model);
                        }
                        else
                        {
                            nigeria_content_succession_model.Date_Created = getData.Date_Created;
                            nigeria_content_succession_model.Created_by = getData.Created_by;
                            nigeria_content_succession_model.Date_Updated = DateTime.Now;
                            nigeria_content_succession_model.Updated_by = WKPCompanyId;
                            _context.NIGERIA_CONTENT_Upload_Succession_Plans.Remove(getData);
                            await _context.NIGERIA_CONTENT_Upload_Succession_Plans.AddAsync(nigeria_content_succession_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.NIGERIA_CONTENT_Upload_Succession_Plans.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_NIGERIA_CONTENT_QUESTION")]
        public async Task<object> POST_NIGERIA_CONTENT_QUESTION([FromBody] NIGERIA_CONTENT_QUESTION nigeria_content_question_model, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                #region Saving NIGERIA_CONTENT_QUESTIONs data
                if (nigeria_content_question_model != null)
                {
                    var getData = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();

                    nigeria_content_question_model.Companyemail = WKPCompanyEmail;
                    nigeria_content_question_model.CompanyName = WKPCompanyName;
                    nigeria_content_question_model.COMPANY_ID = WKPCompanyId;
                    nigeria_content_question_model.CompanyNumber = WKPCompanyNumber;
                    nigeria_content_question_model.Date_Updated = DateTime.Now;
                    nigeria_content_question_model.Updated_by = WKPCompanyId;
                    nigeria_content_question_model.Year_of_WP = year;
                    // nigeria_content_question_model.OML_Name = omlName.ToUpper();
                    // nigeria_content_question_model.OML_Name = omlName;
                    // nigeria_content_question_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            nigeria_content_question_model.Date_Created = DateTime.Now;
                            nigeria_content_question_model.Created_by = WKPCompanyId;
                            await _context.NIGERIA_CONTENT_QUESTIONs.AddAsync(nigeria_content_question_model);
                        }
                        else
                        {
                            //nigeria_content_question_model.Date_Created = getData.Date_Created;
                            //nigeria_content_question_model.Created_by = getData.Created_by;
                            nigeria_content_question_model.Date_Updated = DateTime.Now;
                            nigeria_content_question_model.Updated_by = WKPCompanyId;
                            _context.NIGERIA_CONTENT_QUESTIONs.RemoveRange(getData);
                            await _context.NIGERIA_CONTENT_QUESTIONs.AddAsync(nigeria_content_question_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.NIGERIA_CONTENT_QUESTIONs.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_LEGAL_LITIGATION")]
        public async Task<object> POST_LEGAL_LITIGATION([FromBody] LEGAL_LITIGATION legal_litigation_model, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving LEGAL_LITIGATIONs data
                if (legal_litigation_model != null)
                {

                    var getData = await (from c in _context.LEGAL_LITIGATIONs where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year && c.Id == legal_litigation_model.Id select c).FirstOrDefaultAsync();

                    legal_litigation_model.Companyemail = WKPCompanyEmail;
                    legal_litigation_model.CompanyName = WKPCompanyName;
                    legal_litigation_model.COMPANY_ID = WKPCompanyId;
                    legal_litigation_model.CompanyNumber = WKPCompanyNumber;
                    legal_litigation_model.Date_Updated = DateTime.Now;
                    legal_litigation_model.Updated_by = WKPCompanyId;
                    legal_litigation_model.Year_of_WP = year;
                    //legal_litigation_model.OML_Name = omlName;
                    //legal_litigation_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            legal_litigation_model.Date_Created = DateTime.Now;
                            legal_litigation_model.Created_by = WKPCompanyId;
                            await _context.LEGAL_LITIGATIONs.AddAsync(legal_litigation_model);
                        }
                        else
                        {
                            legal_litigation_model.Date_Created = getData.Date_Created;
                            legal_litigation_model.Created_by = getData.Created_by;
                            legal_litigation_model.Date_Updated = DateTime.Now;
                            legal_litigation_model.Updated_by = WKPCompanyId;
                            _context.LEGAL_LITIGATIONs.Remove(getData);
                            await _context.LEGAL_LITIGATIONs.AddAsync(legal_litigation_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.LEGAL_LITIGATIONs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.LEGAL_LITIGATIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_LEGAL_ARBITRATION")]
        public async Task<object> POST_LEGAL_ARBITRATION([FromBody] LEGAL_ARBITRATION legal_arbitration_model, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving LEGAL_ARBITRATIONs data
                if (legal_arbitration_model != null)
                {
                    var getData = await (from c in _context.LEGAL_ARBITRATIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Id == legal_arbitration_model.Id select c).FirstOrDefaultAsync();

                    legal_arbitration_model.Companyemail = WKPCompanyEmail;
                    legal_arbitration_model.CompanyName = WKPCompanyName;
                    legal_arbitration_model.COMPANY_ID = WKPCompanyId;
                    legal_arbitration_model.CompanyNumber = WKPCompanyNumber;
                    // legal_arbitration_model.Date_Updated = DateTime.Now;
                    //egal_arbitration_model.Updated_by = WKPCompanyId;
                    legal_arbitration_model.Year_of_WP = year;
                    //legal_arbitration_model.OML_Name = omlName;
                    //legal_arbitration_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            legal_arbitration_model.Date_Created = DateTime.Now;
                            legal_arbitration_model.Created_by = WKPCompanyId;
                            await _context.LEGAL_ARBITRATIONs.AddAsync(legal_arbitration_model);
                        }
                        else
                        {
                            legal_arbitration_model.Date_Created = getData.Date_Created;
                            legal_arbitration_model.Created_by = getData.Created_by;
                            legal_arbitration_model.Date_Updated = DateTime.Now;
                            legal_arbitration_model.Updated_by = WKPCompanyId;
                            _context.LEGAL_ARBITRATIONs.Remove(getData);
                            await _context.LEGAL_ARBITRATIONs.AddAsync(legal_arbitration_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.LEGAL_ARBITRATIONs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.LEGAL_ARBITRATIONs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_STRATEGIC_PLANS_ON_COMPANY_BASES")]
        public async Task<object> POST_STRATEGIC_PLANS_ON_COMPANY_BASI([FromBody] STRATEGIC_PLANS_ON_COMPANY_BASI strategic_plans_model, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving STRATEGIC_PLANS_ON_COMPANY_BASIs data
                if (strategic_plans_model != null)
                {
                    var getData = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.ACTIVITIES == strategic_plans_model.ACTIVITIES select c).ToListAsync();

                    strategic_plans_model.Companyemail = WKPCompanyEmail;
                    strategic_plans_model.CompanyName = WKPCompanyName;
                    strategic_plans_model.COMPANY_ID = WKPCompanyId;
                    strategic_plans_model.CompanyNumber = WKPCompanyNumber;
                    strategic_plans_model.Date_Updated = DateTime.Now;
                    strategic_plans_model.Updated_by = WKPCompanyId;
                    strategic_plans_model.Year_of_WP = year;
                    // strategic_plans_model.OML_Name = omlName;
                    // strategic_plans_model.Field_ID = concessionField?.Field_ID ?? null;
                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null || getData.Count == 0)
                        // {
                        strategic_plans_model.Date_Created = DateTime.Now;
                        strategic_plans_model.Created_by = WKPCompanyId;
                        await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.AddAsync(strategic_plans_model);
                        // }
                        // else
                        // {
                        //     //strategic_plans_model.Date_Created = getData.Date_Created;
                        //     //strategic_plans_model.Created_by = getData.Created_by;
                        //     strategic_plans_model.Date_Updated = DateTime.Now;
                        //     strategic_plans_model.Updated_by = WKPCompanyId;
                        //     _context.STRATEGIC_PLANS_ON_COMPANY_BAses.RemoveRange(getData);
                        //     await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.AddAsync(strategic_plans_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.STRATEGIC_PLANS_ON_COMPANY_BAses.RemoveRange(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_QUESTION")]
        public async Task<object> POST_HSE_QUESTION([FromBody] HSE_QUESTION hse_question_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_QUESTIONs data
                if (hse_question_model != null)
                {
                    var getData = (from c in _context.HSE_QUESTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_question_model.Companyemail = WKPCompanyEmail;
                    hse_question_model.CompanyName = WKPCompanyName;
                    hse_question_model.COMPANY_ID = WKPCompanyId;
                    hse_question_model.CompanyNumber = WKPCompanyNumber;
                    hse_question_model.Date_Updated = DateTime.Now;
                    hse_question_model.Updated_by = WKPCompanyId;
                    hse_question_model.Year_of_WP = year;
                    hse_question_model.OML_Name = omlName;
                    hse_question_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_question_model.Date_Created = DateTime.Now;
                        hse_question_model.Created_by = WKPCompanyId;
                        await _context.HSE_QUESTIONs.AddAsync(hse_question_model);
                        // }
                        // else
                        // {
                        //     hse_question_model.Date_Created = getData.Date_Created;
                        //     hse_question_model.Created_by = getData.Created_by;
                        //     hse_question_model.Date_Updated = DateTime.Now;
                        //     hse_question_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_QUESTIONs.Remove(getData);
                        //     await _context.HSE_QUESTIONs.AddAsync(hse_question_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_QUESTIONs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_QUESTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_FATALITY")]
        public async Task<object> POST_HSE_FATALITY([FromBody] HSE_FATALITy hse_fatality_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_FATALITY data
                if (hse_fatality_model != null)
                {
                    var getData = (from c in _context.HSE_FATALITIEs where c.Fatalities_Type == hse_fatality_model.Fatalities_Type && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_fatality_model.Companyemail = WKPCompanyEmail;
                    hse_fatality_model.CompanyName = WKPCompanyName;
                    hse_fatality_model.COMPANY_ID = WKPCompanyId;
                    hse_fatality_model.CompanyNumber = WKPCompanyNumber;
                    hse_fatality_model.Date_Updated = DateTime.Now;
                    hse_fatality_model.Updated_by = WKPCompanyId;
                    hse_fatality_model.Year_of_WP = year;
                    hse_fatality_model.OML_Name = omlName;
                    hse_fatality_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_fatality_model.Date_Created = DateTime.Now;
                        hse_fatality_model.Created_by = WKPCompanyId;
                        await _context.HSE_FATALITIEs.AddAsync(hse_fatality_model);
                        // }
                        // else
                        // {
                        //     hse_fatality_model.Date_Created = getData.Date_Created;
                        //     hse_fatality_model.Created_by = getData.Created_by;
                        //     hse_fatality_model.Date_Updated = DateTime.Now;
                        //     hse_fatality_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_FATALITIEs.Remove(getData);
                        //     await _context.HSE_FATALITIEs.AddAsync(hse_fatality_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_FATALITIEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_FATALITIEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_DESIGNS_SAFETY")]
        public async Task<object> POST_HSE_DESIGNS_SAFETY([FromBody] HSE_DESIGNS_SAFETY hse_designs_safety_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_DESIGNS_SAFETYs data
                if (hse_designs_safety_model != null)
                {
                    var getData = (from c in _context.HSE_DESIGNS_SAFETies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_designs_safety_model.Companyemail = WKPCompanyEmail;
                    hse_designs_safety_model.CompanyName = WKPCompanyName;
                    hse_designs_safety_model.COMPANY_ID = WKPCompanyId;
                    hse_designs_safety_model.CompanyNumber = WKPCompanyNumber;
                    hse_designs_safety_model.Date_Updated = DateTime.Now;
                    hse_designs_safety_model.Updated_by = WKPCompanyId;
                    hse_designs_safety_model.Year_of_WP = year;
                    hse_designs_safety_model.OML_Name = omlName;
                    hse_designs_safety_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_designs_safety_model.Date_Created = DateTime.Now;
                        hse_designs_safety_model.Created_by = WKPCompanyId;
                        await _context.HSE_DESIGNS_SAFETies.AddAsync(hse_designs_safety_model);
                        // }
                        // else
                        // {
                        //     hse_designs_safety_model.Date_Created = getData.Date_Created;
                        //     hse_designs_safety_model.Created_by = getData.Created_by;
                        //     hse_designs_safety_model.Date_Updated = DateTime.Now;
                        //     hse_designs_safety_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_DESIGNS_SAFETies.Remove(getData);
                        //     await _context.HSE_DESIGNS_SAFETies.AddAsync(hse_designs_safety_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_DESIGNS_SAFETies.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_DESIGNS_SAFETies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_INSPECTION_AND_MAINTENANCE_NEW")]
        public async Task<object> POST_HSE_INSPECTION_AND_MAINTENANCE_NEW([FromBody] HSE_INSPECTION_AND_MAINTENANCE_NEW hse_IM_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_INSPECTION_AND_MAINTENANCE_NEWs data
                if (hse_IM_model != null)
                {
                    var getData = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_IM_model.Companyemail = WKPCompanyEmail;
                    hse_IM_model.CompanyName = WKPCompanyName;
                    hse_IM_model.COMPANY_ID = WKPCompanyId;
                    hse_IM_model.CompanyNumber = WKPCompanyNumber;
                    hse_IM_model.Date_Updated = DateTime.Now;
                    hse_IM_model.Updated_by = WKPCompanyId;
                    hse_IM_model.Year_of_WP = year;
                    hse_IM_model.OML_Name = omlName;
                    hse_IM_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_IM_model.ACTUAL_year = year;
                    hse_IM_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_IM_model.Date_Created = DateTime.Now;
                        hse_IM_model.Created_by = WKPCompanyId;
                        await _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs.AddAsync(hse_IM_model);
                        // }
                        // else
                        // {
                        //     hse_IM_model.Date_Created = getData.Date_Created;
                        //     hse_IM_model.Created_by = getData.Created_by;
                        //     hse_IM_model.Date_Updated = DateTime.Now;
                        //     hse_IM_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs.Remove(getData);
                        //     await _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs.AddAsync(hse_IM_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    //else
                    //{
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    //}
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW")]
        public async Task<object> POST_HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW([FromBody] HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW hse_IM_facility_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs data
                if (hse_IM_facility_model != null)
                {
                    var getData = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_IM_facility_model.Companyemail = WKPCompanyEmail;
                    hse_IM_facility_model.CompanyName = WKPCompanyName;
                    hse_IM_facility_model.COMPANY_ID = WKPCompanyId;
                    hse_IM_facility_model.CompanyNumber = WKPCompanyNumber;
                    hse_IM_facility_model.Date_Updated = DateTime.Now;
                    hse_IM_facility_model.Updated_by = WKPCompanyId;
                    hse_IM_facility_model.Year_of_WP = year;
                    hse_IM_facility_model.OML_Name = omlName;
                    hse_IM_facility_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_IM_facility_model.ACTUAL_year = year;
                    hse_IM_facility_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_IM_facility_model.Date_Created = DateTime.Now;
                        hse_IM_facility_model.Created_by = WKPCompanyId;
                        await _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.AddAsync(hse_IM_facility_model);
                        // }
                        // else
                        // {
                        //     hse_IM_facility_model.Date_Created = getData.Date_Created;
                        //     hse_IM_facility_model.Created_by = getData.Created_by;
                        //     hse_IM_facility_model.Date_Updated = DateTime.Now;
                        //     hse_IM_facility_model.Updated_by = WKPCompanyId;

                        //     _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.Remove(getData);
                        //     await _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.AddAsync(hse_IM_facility_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW")]
        public async Task<object> POST_HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW([FromBody] HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW hse_technical_safety_model,
            string omlName, string fieldName, string year, int id, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_technical_safety_model != null)
                {
                    //List<HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW> getData;
                    //if (concessionField?.Field_Name != null)
                    //{
                    //    getData = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //}
                    //else
                    //{
                    //    getData = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //}

                    var getData = id > 0 ? _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Where(x => x.Id == id).FirstOrDefault() : null;


                    hse_technical_safety_model.Companyemail = WKPCompanyEmail;
                    hse_technical_safety_model.CompanyName = WKPCompanyName;
                    hse_technical_safety_model.COMPANY_ID = WKPCompanyId;
                    hse_technical_safety_model.CompanyNumber = WKPCompanyNumber;
                    hse_technical_safety_model.Date_Updated = DateTime.Now;
                    hse_technical_safety_model.Updated_by = WKPCompanyId;
                    hse_technical_safety_model.Year_of_WP = year;
                    hse_technical_safety_model.OML_Name = omlName;
                    hse_technical_safety_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        //if (getData.Count() <= 0)
                        //{
                        if (getData == null)
                        {
                            hse_technical_safety_model.Date_Created = DateTime.Now;
                            hse_technical_safety_model.Created_by = WKPCompanyId;
                            await _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.AddAsync(hse_technical_safety_model);
                        }
                        else
                        {
                            hse_technical_safety_model.Date_Created = DateTime.Now;
                            hse_technical_safety_model.Created_by = WKPCompanyId;

                            _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Remove(getData);
                            await _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.AddAsync(hse_technical_safety_model);
                        }

                        //}
                        //else
                        //{
                        //    hse_technical_safety_model.Date_Created = getData.FirstOrDefault()?.Date_Created;
                        //    hse_technical_safety_model.Created_by = getData.FirstOrDefault()?.Created_by;
                        //    hse_technical_safety_model.Date_Updated = DateTime.Now;
                        //    hse_technical_safety_model.Updated_by = WKPCompanyId;
                        //    // getData.ForEach(x =>
                        //    // {
                        //    //     _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Remove(x);
                        //    //     save += _context.SaveChanges();

                        //    // });
                        //    await _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.AddAsync(hse_technical_safety_model);
                        //}
                    }

                    save += await _context.SaveChangesAsync();
                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_SAFETY_STUDIES_NEW"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_SAFETY_STUDIES_NEW([FromForm] HSE_SAFETY_STUDIES_NEW hse_safety_studies_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SAFETY_STUDIES_NEWs.Remove(getData);
                    save += _context.SaveChanges();

                    //Added by Musa
                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }


                if (hse_safety_studies_model != null)
                {
                    var getData = (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToList();

                    hse_safety_studies_model.Companyemail = WKPCompanyEmail;
                    hse_safety_studies_model.CompanyName = WKPCompanyName;
                    hse_safety_studies_model.COMPANY_ID = WKPCompanyId;
                    hse_safety_studies_model.CompanyNumber = WKPCompanyNumber;
                    hse_safety_studies_model.Date_Updated = DateTime.Now;
                    hse_safety_studies_model.Updated_by = WKPCompanyId;
                    hse_safety_studies_model.Year_of_WP = year;
                    hse_safety_studies_model.OML_Name = omlName;
                    hse_safety_studies_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_safety_studies_model.ACTUAL_year = year;
                    hse_safety_studies_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    var file1 = Request.Form.Files[0];
                    var blobname1 = blobService.Filenamer(file1);

                    if (file1 != null)
                    {
                        string docName = "SMS";
                        hse_safety_studies_model.SMSFileUploadPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"SMSDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_safety_studies_model.SMSFileUploadPath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                    }
                    if (action == GeneralModel.Insert)
                    {
                        // if (getData.Count <= 0)
                        // {
                        hse_safety_studies_model.Date_Created = DateTime.Now;
                        hse_safety_studies_model.Created_by = WKPCompanyId;
                        await _context.HSE_SAFETY_STUDIES_NEWs.AddAsync(hse_safety_studies_model);
                        // }
                        // else
                        // {
                        //     hse_safety_studies_model.Date_Created = getData?.FirstOrDefault().Date_Created;
                        //     hse_safety_studies_model.Created_by = getData?.FirstOrDefault().Created_by;
                        //     hse_safety_studies_model.Date_Updated = DateTime.Now;
                        //     hse_safety_studies_model.Updated_by = WKPCompanyId;
                        //     getData.ForEach(x =>
                        //     {
                        //         _context.HSE_SAFETY_STUDIES_NEWs.Remove(x);
                        //         save += _context.SaveChanges();
                        //     });
                        //     await _context.HSE_SAFETY_STUDIES_NEWs.AddAsync(hse_safety_studies_model);
                        // }
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_SAFETY_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    //else
                    //{
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    //}
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW")]
        public async Task<object> POST_HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW([FromBody] HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW hse_asset_register_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            int Id = hse_asset_register_model.Id;

            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW getData;

            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs data
                if (hse_asset_register_model != null)
                {
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    }
                    else
                    {
                        getData = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    }


                    hse_asset_register_model.Companyemail = WKPCompanyEmail;
                    hse_asset_register_model.CompanyName = WKPCompanyName;
                    hse_asset_register_model.COMPANY_ID = WKPCompanyId;
                    hse_asset_register_model.CompanyNumber = WKPCompanyNumber;
                    //  hse_asset_register_model.Date_Updated = DateTime.Now;
                    // hse_asset_register_model.Updated_by = WKPCompanyId;
                    hse_asset_register_model.Year_of_WP = year;
                    hse_asset_register_model.OML_Name = omlName;
                    hse_asset_register_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_asset_register_model.Date_Created = DateTime.Now;
                            hse_asset_register_model.Created_by = WKPCompanyId;
                            await _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.AddAsync(hse_asset_register_model);
                        }
                        else
                        {
                            hse_asset_register_model.Date_Created = DateTime.Now;
                            hse_asset_register_model.Created_by = WKPCompanyId;

                            _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(getData);
                            await _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.AddAsync(hse_asset_register_model);
                        }
                        // }
                        // else
                        // {
                        //     hse_asset_register_model.Date_Created = getData.Date_Created;
                        //     hse_asset_register_model.Created_by = getData.Created_by;
                        //     hse_asset_register_model.Date_Updated = DateTime.Now;
                        //     hse_asset_register_model.Updated_by = WKPCompanyId;

                        //     _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(getData);

                        //     await _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.AddAsync(hse_asset_register_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);

                        var All_Data = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_OIL_SPILL_REPORTING_NEW")]
        public async Task<object> POST_HSE_OIL_SPILL_REPORTING_NEW([FromBody] HSE_OIL_SPILL_REPORTING_NEW hse_oil_spill_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_oil_spill_model.Id;

            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            HSE_OIL_SPILL_REPORTING_NEW getData;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var _getData = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_OIL_SPILL_REPORTING_NEWs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (hse_oil_spill_model != null)
                {
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    }

                    hse_oil_spill_model.Companyemail = WKPCompanyEmail;
                    hse_oil_spill_model.CompanyName = WKPCompanyName;
                    hse_oil_spill_model.COMPANY_ID = WKPCompanyId;
                    hse_oil_spill_model.CompanyNumber = WKPCompanyNumber;
                    //hse_oil_spill_model.Date_Updated = DateTime.Now;
                    // hse_oil_spill_model.Updated_by = WKPCompanyId;
                    hse_oil_spill_model.Year_of_WP = year;
                    hse_oil_spill_model.OML_Name = omlName;
                    hse_oil_spill_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_oil_spill_model.Date_Created = DateTime.Now;
                            hse_oil_spill_model.Created_by = WKPCompanyId;
                            await _context.HSE_OIL_SPILL_REPORTING_NEWs.AddAsync(hse_oil_spill_model);
                        }
                        else
                        {
                            hse_oil_spill_model.Date_Created = DateTime.Now;
                            hse_oil_spill_model.Created_by = WKPCompanyId;

                            _context.HSE_OIL_SPILL_REPORTING_NEWs.Remove(getData);
                            await _context.HSE_OIL_SPILL_REPORTING_NEWs.AddAsync(hse_oil_spill_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_oil_spill_model.Date_Created = getData.Date_Created;
                        //     hse_oil_spill_model.Created_by = getData.Created_by;
                        //     hse_oil_spill_model.Date_Updated = DateTime.Now;
                        //     hse_oil_spill_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_OIL_SPILL_REPORTING_NEWs.Remove(getData);
                        //     _context.SaveChanges();
                        //     await _context.HSE_OIL_SPILL_REPORTING_NEWs.AddAsync(hse_oil_spill_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_OIL_SPILL_REPORTING_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();


                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW")]
        public async Task<object> POST_HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW([FromBody] HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW hse_asset_register_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_asset_register_model.Id;

            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW getData;

            try
            {

                if (!string.IsNullOrEmpty(id))
                {

                    var _getData = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(_getData);
                    save += _context.SaveChanges();
                }
                else if (hse_asset_register_model != null)
                {
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    }
                    else
                    {
                        getData = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    }

                    hse_asset_register_model.Companyemail = WKPCompanyEmail;
                    hse_asset_register_model.CompanyName = WKPCompanyName;
                    hse_asset_register_model.COMPANY_ID = WKPCompanyId;
                    hse_asset_register_model.CompanyNumber = WKPCompanyNumber;
                    hse_asset_register_model.Date_Updated = DateTime.Now;
                    hse_asset_register_model.Updated_by = WKPCompanyId;
                    hse_asset_register_model.Year_of_WP = year;
                    hse_asset_register_model.OML_Name = omlName;
                    hse_asset_register_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_asset_register_model.Date_Created = DateTime.Now;
                            hse_asset_register_model.Created_by = WKPCompanyId;
                            await _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.AddAsync(hse_asset_register_model);
                        }
                        else
                        {
                            hse_asset_register_model.Date_Created = DateTime.Now;
                            hse_asset_register_model.Created_by = WKPCompanyId;

                            _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(getData);
                            await _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.AddAsync(hse_asset_register_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_asset_register_model.Date_Created = getData.Date_Created;
                        //     hse_asset_register_model.Created_by = getData.Created_by;
                        //     hse_asset_register_model.Date_Updated = DateTime.Now;
                        //     hse_asset_register_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(getData);
                        //     _context.SaveChanges();
                        //     await _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.AddAsync(hse_asset_register_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ACCIDENT_INCIDENCE")]
        public async Task<object> POST_HSE_ACCIDENT_INCIDENCE_REPORTING_NEW([FromForm] HSE_ACCIDENT_INCIDENCE_MODEL hse_accident_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            var HSE_Accident_Incidence = new HSE_ACCIDENT_INCIDENCE_REPORTING_NEW();

            var HSE_Accident_Incidence_Type = new HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW();

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (getData == null)
                    {
                        return new WebApiResponse { ResponseCode = AppResponseCodes.RecordNotFound, Message = "Records not Found", Data = null, StatusCode = ResponseCodes.RecordNotFound };
                    }

                    if (action == GeneralModel.Delete)
                        _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }

                else if (hse_accident_model != null)
                {
                    #region Saving HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs data

                    var getData = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    HSE_Accident_Incidence.Was_there_any_accident_incidence = hse_accident_model.Was_there_any_accident_incidence;
                    HSE_Accident_Incidence.If_YES_were_they_reported = hse_accident_model.If_YES_were_they_reported;
                    HSE_Accident_Incidence.Companyemail = WKPCompanyEmail;
                    HSE_Accident_Incidence.CompanyName = WKPCompanyName;
                    HSE_Accident_Incidence.COMPANY_ID = WKPCompanyId;
                    HSE_Accident_Incidence.CompanyNumber = WKPCompanyNumber;
                    HSE_Accident_Incidence.Date_Updated = DateTime.Now;
                    HSE_Accident_Incidence.Updated_by = WKPCompanyId;
                    HSE_Accident_Incidence.Year_of_WP = year;
                    HSE_Accident_Incidence.OML_Name = omlName;


                    #region File Upload
                    var file1 = Request.Form.Files[0];
                    var blobname1 = blobService.Filenamer(file1);
                    if (file1 != null)
                    {
                        string docName = "Accident Incidence Report";
                        HSE_Accident_Incidence.UploadIncidentStatisticsPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"AccidentIncidenceReportDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (HSE_Accident_Incidence.UploadIncidentStatisticsPath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            HSE_Accident_Incidence.UploadIncidentStatisticsFilename = blobname1;
                    }
                    #endregion



                    if (action == GeneralModel.Insert)
                    {
                        // if (getData.Count() <= 0)
                        // {
                        HSE_Accident_Incidence.Date_Created = DateTime.Now;
                        HSE_Accident_Incidence.Created_by = WKPCompanyId;
                        await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.AddAsync(HSE_Accident_Incidence);
                        // }
                        // else
                        // {
                        //     HSE_Accident_Incidence.Date_Created = getData.FirstOrDefault().Date_Created;
                        //     HSE_Accident_Incidence.Created_by = getData.FirstOrDefault().Created_by;
                        //     HSE_Accident_Incidence.Date_Updated = DateTime.Now;
                        //     HSE_Accident_Incidence.Updated_by = WKPCompanyId;
                        //     getData.ForEach(x =>
                        //     {
                        //         _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Remove(x);
                        //         save += _context.SaveChanges();
                        //     });
                        //     await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.AddAsync(HSE_Accident_Incidence);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        getData.ForEach(x =>
                        {
                            _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Remove(x);
                            save += _context.SaveChanges();
                        });
                    }

                    save += await _context.SaveChangesAsync();

                    #endregion

                    #region Saving HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs data

                    var getData2 = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();

                    HSE_Accident_Incidence_Type.Cause = hse_accident_model.Cause;
                    HSE_Accident_Incidence_Type.Frequency = hse_accident_model.Frequency;
                    HSE_Accident_Incidence_Type.Type_of_Accident_Incidence = hse_accident_model.Type_of_Accident_Incidence;
                    HSE_Accident_Incidence_Type.Location = hse_accident_model.Location;
                    HSE_Accident_Incidence_Type.Investigation = hse_accident_model.Investigation;
                    HSE_Accident_Incidence_Type.Lesson_Learnt = hse_accident_model.Lesson_Learnt;
                    HSE_Accident_Incidence_Type.Consequence = hse_accident_model.Consequence;
                    HSE_Accident_Incidence_Type.Date_ = hse_accident_model.Date_;

                    HSE_Accident_Incidence_Type.Companyemail = WKPCompanyEmail;
                    HSE_Accident_Incidence_Type.CompanyName = WKPCompanyName;
                    HSE_Accident_Incidence_Type.COMPANY_ID = WKPCompanyId;
                    HSE_Accident_Incidence_Type.CompanyNumber = WKPCompanyNumber;
                    HSE_Accident_Incidence_Type.Date_Updated = DateTime.Now;
                    HSE_Accident_Incidence_Type.Updated_by = WKPCompanyId;
                    HSE_Accident_Incidence_Type.Year_of_WP = year;
                    HSE_Accident_Incidence_Type.OML_Name = omlName;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData2.Count() <= 0)
                        // {
                        HSE_Accident_Incidence_Type.Date_Created = DateTime.Now;
                        HSE_Accident_Incidence_Type.Created_by = WKPCompanyId;
                        await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.AddAsync(HSE_Accident_Incidence_Type);
                        // }
                        // else
                        // {
                        //     HSE_Accident_Incidence_Type.Date_Created = getData2.FirstOrDefault().Date_Created;
                        //     HSE_Accident_Incidence_Type.Created_by = getData2.FirstOrDefault().Created_by;
                        //     HSE_Accident_Incidence_Type.Date_Updated = DateTime.Now;
                        //     HSE_Accident_Incidence_Type.Updated_by = WKPCompanyId;
                        //     getData2.ForEach(x =>
                        //     {
                        //         _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.Remove(x);
                        //         save += _context.SaveChanges();
                        //     });
                        //     await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.AddAsync(HSE_Accident_Incidence_Type);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        getData2.ForEach(x =>
                        {
                            _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.Remove(x);
                            save += _context.SaveChanges();
                        });
                    }

                    save += await _context.SaveChangesAsync();
                    #endregion


                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);

                    var All_Data = await (from a1 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                                          join a2 in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs on a1.COMPANY_ID equals a2.COMPANY_ID
                                          where a1.COMPANY_ID == WKPCompanyId && a1.OML_Name == omlName && a1.Year_of_WP == year
                                          && a2.COMPANY_ID == WKPCompanyId && a2.OML_Name == omlName && a2.Year_of_WP == year

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


                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_ACCIDENT_INCIDENCE_REPORTING_NEW")]
        public async Task<object> POST_HSE_ACCIDENT_INCIDENCE_REPORTING_NEW([FromBody] HSE_ACCIDENT_INCIDENCE_REPORTING_NEW hse_accident_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_accident_model != null)
                {
                    var getData = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_accident_model.Companyemail = WKPCompanyEmail;
                    hse_accident_model.CompanyName = WKPCompanyName;
                    hse_accident_model.COMPANY_ID = WKPCompanyId;
                    hse_accident_model.CompanyNumber = WKPCompanyNumber;
                    hse_accident_model.Date_Updated = DateTime.Now;
                    hse_accident_model.Updated_by = WKPCompanyId;
                    hse_accident_model.Year_of_WP = year;
                    hse_accident_model.OML_Name = omlName;
                    hse_accident_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_accident_model.ACTUAL_year = year;
                    hse_accident_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_accident_model.Date_Created = DateTime.Now;
                        hse_accident_model.Created_by = WKPCompanyId;
                        await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.AddAsync(hse_accident_model);
                        // }
                        // else
                        // {
                        //     hse_accident_model.Date_Created = getData.Date_Created;
                        //     hse_accident_model.Created_by = getData.Created_by;
                        //     hse_accident_model.Date_Updated = DateTime.Now;
                        //     hse_accident_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Remove(hse_accident_model);
                        //     await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.AddAsync(hse_accident_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW")]
        public async Task<object> POST_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW([FromBody] HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW hse_accident_reporting_model, string omlName, string fieldName, string year, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                #region Saving HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs data
                if (hse_accident_reporting_model != null)
                {
                    var getData = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_accident_reporting_model.Companyemail = WKPCompanyEmail;
                    hse_accident_reporting_model.CompanyName = WKPCompanyName;
                    hse_accident_reporting_model.COMPANY_ID = WKPCompanyId;
                    hse_accident_reporting_model.CompanyNumber = WKPCompanyNumber;
                    hse_accident_reporting_model.Date_Updated = DateTime.Now;
                    hse_accident_reporting_model.Updated_by = WKPCompanyId;
                    hse_accident_reporting_model.Year_of_WP = year;
                    hse_accident_reporting_model.OML_Name = omlName;
                    hse_accident_reporting_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_accident_reporting_model.ACTUAL_year = year;
                    hse_accident_reporting_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_accident_reporting_model.Date_Created = DateTime.Now;
                        hse_accident_reporting_model.Created_by = WKPCompanyId;
                        await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.AddAsync(hse_accident_reporting_model);
                        // }
                        // else
                        // {
                        //     hse_accident_reporting_model.Date_Created = getData.Date_Created;
                        //     hse_accident_reporting_model.Created_by = getData.Created_by;
                        //     hse_accident_reporting_model.Date_Updated = DateTime.Now;
                        //     hse_accident_reporting_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.Remove(getData);
                        //     await _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.AddAsync(hse_accident_reporting_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW")]
        public async Task<object> POST_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW([FromBody] HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW hse_community_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_community_model != null)
                {
                    var getData = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_community_model.Companyemail = WKPCompanyEmail;
                    hse_community_model.CompanyName = WKPCompanyName;
                    hse_community_model.COMPANY_ID = WKPCompanyId;
                    hse_community_model.CompanyNumber = WKPCompanyNumber;
                    hse_community_model.Date_Updated = DateTime.Now;
                    hse_community_model.Updated_by = WKPCompanyId;
                    hse_community_model.Year_of_WP = year;
                    hse_community_model.OML_Name = omlName;
                    hse_community_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_community_model.ACTUAL_year = year;
                    hse_community_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_community_model.Date_Created = DateTime.Now;
                        hse_community_model.Created_by = WKPCompanyId;
                        await _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.AddAsync(hse_community_model);
                        // }
                        // else
                        // {
                        //     hse_community_model.Date_Created = getData.Date_Created;
                        //     hse_community_model.Created_by = getData.Created_by;
                        //     hse_community_model.Date_Updated = DateTime.Now;
                        //     hse_community_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.Remove(getData);
                        //     await _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.AddAsync(hse_community_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }


                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_ENVIRONMENTAL_STUDIES_NEW")]
        public async Task<object> POST_HSE_ENVIRONMENTAL_STUDIES_NEW([FromBody] HSE_ENVIRONMENTAL_STUDIES_NEW hse_environmental_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_environmental_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_environmental_model != null)
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

                    hse_environmental_model.Companyemail = WKPCompanyEmail;
                    hse_environmental_model.CompanyName = WKPCompanyName;
                    hse_environmental_model.COMPANY_ID = WKPCompanyId;
                    hse_environmental_model.CompanyNumber = WKPCompanyNumber;
                    hse_environmental_model.Date_Updated = DateTime.Now;
                    hse_environmental_model.Updated_by = WKPCompanyId;
                    hse_environmental_model.Year_of_WP = year;
                    hse_environmental_model.OML_Name = omlName;
                    hse_environmental_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_environmental_model.ACTUAL_year = year;
                    hse_environmental_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_environmental_model.Date_Created = DateTime.Now;
                            hse_environmental_model.Created_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.AddAsync(hse_environmental_model);
                        }
                        else
                        {
                            hse_environmental_model.Date_Created = DateTime.Now;
                            hse_environmental_model.Created_by = WKPCompanyId;

                            _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.Remove(getData);
                            await _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.AddAsync(hse_environmental_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_environmental_model.Date_Created = getData.Date_Created;
                        //     hse_environmental_model.Created_by = getData.Created_by;
                        //     hse_environmental_model.Date_Updated = DateTime.Now;
                        //     hse_environmental_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.Remove(getData);
                        //     await _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.AddAsync(hse_environmental_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }



        [HttpPost("POST_HSE_WASTE_MANAGEMENT_NEW")]
        public async Task<object> POST_HSE_WASTE_MANAGEMENT_NEW([FromBody] HSE_WASTE_MANAGEMENT_NEW hse_waste_management_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_waste_management_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_WASTE_MANAGEMENT_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_waste_management_model != null)
                {
                    HSE_WASTE_MANAGEMENT_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    hse_waste_management_model.Companyemail = WKPCompanyEmail;
                    hse_waste_management_model.CompanyName = WKPCompanyName;
                    hse_waste_management_model.COMPANY_ID = WKPCompanyId;
                    hse_waste_management_model.CompanyNumber = WKPCompanyNumber;
                    hse_waste_management_model.Date_Updated = DateTime.Now;
                    hse_waste_management_model.Updated_by = WKPCompanyId;
                    hse_waste_management_model.Year_of_WP = year;
                    hse_waste_management_model.OML_Name = omlName;
                    hse_waste_management_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_waste_management_model.ACTUAL_year = year;
                    hse_waste_management_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_waste_management_model.Date_Created = DateTime.Now;
                            hse_waste_management_model.Created_by = WKPCompanyId;
                            await _context.HSE_WASTE_MANAGEMENT_NEWs.AddAsync(hse_waste_management_model);
                        }
                        else
                        {
                            hse_waste_management_model.Date_Created = DateTime.Now;
                            hse_waste_management_model.Created_by = WKPCompanyId;

                            _context.HSE_WASTE_MANAGEMENT_NEWs.Remove(getData);
                            await _context.HSE_WASTE_MANAGEMENT_NEWs.AddAsync(hse_waste_management_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_waste_management_model.Date_Created = getData.Date_Created;
                        //     hse_waste_management_model.Created_by = getData.Created_by;
                        //     hse_waste_management_model.Date_Updated = DateTime.Now;
                        //     hse_waste_management_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_WASTE_MANAGEMENT_NEWs.Remove(getData);
                        //     await _context.HSE_WASTE_MANAGEMENT_NEWs.AddAsync(hse_waste_management_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_WASTE_MANAGEMENT_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_WASTE_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }


            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW")]
        public async Task<object> POST_HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW([FromBody] HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW hse_waste_management_facility_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_waste_management_facility_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_waste_management_facility_model != null)
                {
                    HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    hse_waste_management_facility_model.Companyemail = WKPCompanyEmail;
                    hse_waste_management_facility_model.CompanyName = WKPCompanyName;
                    hse_waste_management_facility_model.COMPANY_ID = WKPCompanyId;
                    hse_waste_management_facility_model.CompanyNumber = WKPCompanyNumber;
                    hse_waste_management_facility_model.Date_Updated = DateTime.Now;
                    hse_waste_management_facility_model.Updated_by = WKPCompanyId;
                    hse_waste_management_facility_model.Year_of_WP = year;
                    hse_waste_management_facility_model.OML_Name = omlName;
                    hse_waste_management_facility_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_waste_management_facility_model.ACTUAL_year = year;
                    hse_waste_management_facility_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_waste_management_facility_model.Date_Created = DateTime.Now;
                            hse_waste_management_facility_model.Created_by = WKPCompanyId;
                            await _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.AddAsync(hse_waste_management_facility_model);
                        }
                        else
                        {
                            hse_waste_management_facility_model.Date_Created = DateTime.Now;
                            hse_waste_management_facility_model.Created_by = WKPCompanyId;

                            _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.Remove(getData);
                            await _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.AddAsync(hse_waste_management_facility_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_waste_management_facility_model.Date_Created = getData.Date_Created;
                        //     hse_waste_management_facility_model.Created_by = getData.Created_by;
                        //     hse_waste_management_facility_model.Date_Updated = DateTime.Now;
                        //     hse_waste_management_facility_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.Remove(getData);
                        //     await _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.AddAsync(hse_waste_management_facility_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_PRODUCED_WATER_MANAGEMENT_NEW")]
        public async Task<object> POST_HSE_PRODUCED_WATER_MANAGEMENT_NEW([FromBody] HSE_PRODUCED_WATER_MANAGEMENT_NEW hse_produced_water_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_produced_water_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_produced_water_model != null)
                {
                    HSE_PRODUCED_WATER_MANAGEMENT_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    hse_produced_water_model.Companyemail = WKPCompanyEmail;
                    hse_produced_water_model.CompanyName = WKPCompanyName;
                    hse_produced_water_model.COMPANY_ID = WKPCompanyId;
                    hse_produced_water_model.CompanyNumber = WKPCompanyNumber;
                    hse_produced_water_model.Date_Updated = DateTime.Now;
                    hse_produced_water_model.Updated_by = WKPCompanyId;
                    hse_produced_water_model.Year_of_WP = year;
                    hse_produced_water_model.OML_Name = omlName;
                    hse_produced_water_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_produced_water_model.ACTUAL_year = year;
                    hse_produced_water_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_produced_water_model.Date_Created = DateTime.Now;
                            hse_produced_water_model.Created_by = WKPCompanyId;
                            await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.AddAsync(hse_produced_water_model);
                        }
                        else
                        {
                            hse_produced_water_model.Date_Created = DateTime.Now;
                            hse_produced_water_model.Created_by = WKPCompanyId;

                            _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Remove(getData);
                            await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.AddAsync(hse_produced_water_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_produced_water_model.Date_Created = getData.Date_Created;
                        //     hse_produced_water_model.Created_by = getData.Created_by;
                        //     hse_produced_water_model.Date_Updated = DateTime.Now;
                        //     hse_produced_water_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Remove(getData);
                        //     await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.AddAsync(hse_produced_water_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        //var All_Data = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                #endregion

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("FetchConcessionsByCompanies")]
        public async Task<object> FetchConcessionsByCompanies()
        {


            var data = await (from comp in _context.ADMIN_COMPANY_INFORMATIONs
                              join conce in _context.ADMIN_CONCESSIONS_INFORMATIONs on comp.COMPANY_ID equals conce.Company_ID
                              orderby conce.Consession_Id
                              select new
                              {

                                  comp.COMPANY_NAME,
                                  comp.EMAIL,
                                  conce.Concession_Held,
                                  conce.Field_Name,
                                  conce.Contract_Type
                              }).ToListAsync();


            var _comData = await _context.ADMIN_COMPANY_INFORMATIONs.Where(a => a.COMPANY_NAME.Trim().ToLower() != "admin").ToListAsync();

            //var _bject = new
            //{
            //	CompanyName = "err",
            //	NumberOfConcessions = 1,
            //             NumberOfFields = 1,
            //	Concessions = data.



            //         }

            return data.GroupBy(a => a.COMPANY_NAME);
        }



        [HttpPost("POST_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW")]
        public async Task<object> POST_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW([FromBody] HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW hse_compliance_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_compliance_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_compliance_model != null)
                {
                    HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    hse_compliance_model.Companyemail = WKPCompanyEmail;
                    hse_compliance_model.CompanyName = WKPCompanyName;
                    hse_compliance_model.COMPANY_ID = WKPCompanyId;
                    hse_compliance_model.CompanyNumber = WKPCompanyNumber;
                    hse_compliance_model.Date_Updated = DateTime.Now;
                    hse_compliance_model.Updated_by = WKPCompanyId;
                    hse_compliance_model.Year_of_WP = year;
                    hse_compliance_model.OML_Name = omlName;
                    hse_compliance_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_compliance_model.ACTUAL_year = year;
                    hse_compliance_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_compliance_model.Date_Created = DateTime.Now;
                            hse_compliance_model.Created_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.AddAsync(hse_compliance_model);
                        }
                        else
                        {
                            hse_compliance_model.Date_Created = DateTime.Now;
                            hse_compliance_model.Created_by = WKPCompanyId;

                            _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Remove(getData);
                            await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.AddAsync(hse_compliance_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_compliance_model.Date_Created = getData.Date_Created;
                        //     hse_compliance_model.Created_by = getData.Created_by;
                        //     hse_compliance_model.Date_Updated = DateTime.Now;
                        //     hse_compliance_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Remove(getData);
                        //     await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.AddAsync(hse_compliance_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW")]
        public async Task<object> POST_HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW([FromBody] HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW hse_environmental_studies_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_environmental_studies_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {


                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_environmental_studies_model != null)
                {
                    HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.YEAR_ == hse_environmental_studies_model.YEAR_ && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.YEAR_ == hse_environmental_studies_model.YEAR_ && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_environmental_studies_model.Companyemail = WKPCompanyEmail;
                    hse_environmental_studies_model.CompanyName = WKPCompanyName;
                    hse_environmental_studies_model.COMPANY_ID = WKPCompanyId;
                    hse_environmental_studies_model.CompanyNumber = WKPCompanyNumber;
                    hse_environmental_studies_model.Date_Updated = DateTime.Now;
                    hse_environmental_studies_model.Updated_by = WKPCompanyId;
                    hse_environmental_studies_model.Year_of_WP = year;
                    hse_environmental_studies_model.OML_Name = omlName;
                    hse_environmental_studies_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_environmental_studies_model.ACTUAL_year = year;
                    hse_environmental_studies_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_environmental_studies_model.Date_Created = DateTime.Now;
                            hse_environmental_studies_model.Created_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.AddAsync(hse_environmental_studies_model);
                        }
                        else
                        {
                            hse_environmental_studies_model.Date_Created = DateTime.Now;
                            hse_environmental_studies_model.Created_by = WKPCompanyId;

                            _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.Remove(getData);
                            await _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.AddAsync(hse_environmental_studies_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_environmental_studies_model.Date_Created = getData.Date_Created;
                        //     hse_environmental_studies_model.Created_by = getData.Created_by;
                        //     hse_environmental_studies_model.Date_Updated = DateTime.Now;
                        //     hse_environmental_studies_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.Remove(getData);
                        //     await _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.AddAsync(hse_environmental_studies_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION([FromForm] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION hse_sustainable_model, string omlName, string fieldName, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            // using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.Id == id select c).FirstOrDefault();
                    _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    hse_sustainable_model.Date_Updated = DateTime.Now;
                    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;
                    hse_sustainable_model.OML_Name = omlName;
                    hse_sustainable_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var file2 = Request.Form.Files.Count > 1 && Request.Form.Files[1] != null ? Request.Form.Files[1] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;
                    var blobname2 = file2 != null ? blobService.Filenamer(file2) : null;

                    if (file1 != null)
                    {
                        string docName = "MOU Responder";
                        hse_sustainable_model.MOUResponderFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"MOUResponderDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_sustainable_model.MOUResponderFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_sustainable_model.MOUResponderFilename = blobname1;
                    }
                    else
                    {
                        hse_sustainable_model.MOUResponderFilePath = null;
                        hse_sustainable_model.MOUResponderFilename = null;
                    }

                    if (file2 != null)
                    {
                        string docName = "OSCP";
                        hse_sustainable_model.MOUOSCPFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"MOUOSCPDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_sustainable_model.MOUOSCPFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_sustainable_model.MOUOSCPFilename = blobname2;

                    }
                    else
                    {
                        hse_sustainable_model.MOUOSCPFilePath = null;
                        hse_sustainable_model.MOUOSCPFilename = null;
                    }
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.AddAsync(hse_sustainable_model);
                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.AddAsync(hse_sustainable_model);
                        }
                        // }
                        // else
                        // {
                        //     hse_sustainable_model.Date_Created = getData.Date_Created;
                        //     hse_sustainable_model.Created_by = getData.Created_by;
                        //     hse_sustainable_model.Date_Updated = DateTime.Now;
                        //     hse_sustainable_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.Remove(getData);
                        //     await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    //  transaction.Commit();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }
        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU([FromForm] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU hse_sustainable_model, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU getData;
                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    hse_sustainable_model.Date_Updated = DateTime.Now;
                    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                    if (file1 != null)
                    {
                        string docName = "GMOU";
                        hse_sustainable_model.MOUUploadFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"MOUDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_sustainable_model.MOUUploadFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                    }
                    else
                    {
                        hse_sustainable_model.MOUUploadFilePath = null;
                    }
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        //if (getData == null)
                        //{

                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.AddAsync(hse_sustainable_model);
                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.AddAsync(hse_sustainable_model);
                        }

                        // }
                        // else
                        // {
                        // 	hse_sustainable_model.Date_Created = getData.Date_Created;
                        // 	hse_sustainable_model.Created_by = getData.Created_by;
                        // 	hse_sustainable_model.Date_Updated = DateTime.Now;
                        // 	hse_sustainable_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW")]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW([FromBody] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW hse_sustainable_model, string omlName, string fieldName, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW getData;

                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Actual_Proposed_Year == hse_sustainable_model.Actual_Proposed_Year select c).FirstOrDefaultAsync();

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    //    hse_sustainable_model.Date_Updated = DateTime.Now;
                    //    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;
                    //hse_sustainable_model.OML_Name = omlName;
                    //hse_sustainable_model.Field_ID = concessionField?.Field_ID ?? null;
                    //hse_sustainable_model.Actual_Proposed_Year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        //if (getData == null)
                        //{

                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.AddAsync(hse_sustainable_model);
                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.AddAsync(hse_sustainable_model);
                        }

                        // }
                        // else
                        // {
                        // 	hse_sustainable_model.Date_Created = getData.Date_Created;
                        // 	hse_sustainable_model.Created_by = getData.Created_by;
                        // 	hse_sustainable_model.Date_Updated = DateTime.Now;
                        // 	hse_sustainable_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL")]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL([FromBody] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL hse_sustainable_model, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0)
                {
                    var getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.Id == id select c).FirstOrDefaultAsync();

                    if (action.ToLower() == GeneralModel.Delete.ToLower())
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Remove(getData);
                        save += await _context.SaveChangesAsync();
                    }
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL getData;
                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.COMPANY_ID == WKPCompanyId && c.Id == hse_sustainable_model.Id && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    hse_sustainable_model.Date_Updated = DateTime.Now;
                    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;
                    //hse_sustainable_model.OML_Name = omlName;
                    //hse_sustainable_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_sustainable_model.ACTUAL_year = year;
                    hse_sustainable_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.AddAsync(hse_sustainable_model);

                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.AddAsync(hse_sustainable_model);

                        }
                        // }
                        // else
                        // {
                        // 	hse_sustainable_model.Date_Created = getData.Date_Created;
                        // 	hse_sustainable_model.Created_by = getData.Created_by;
                        // 	hse_sustainable_model.Date_Updated = DateTime.Now;
                        // 	hse_sustainable_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }
        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition")]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition([FromBody] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition hse_sustainable_model, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.Id == hse_sustainable_model.Id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition getData;
                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.Actual_proposed == hse_sustainable_model.Actual_proposed && c.COMPANY_ID == WKPCompanyId && c.Id == hse_sustainable_model.Id && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    hse_sustainable_model.Date_Updated = DateTime.Now;
                    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;
                    //hse_sustainable_model.OML_Name = omlName;
                    //hse_sustainable_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_sustainable_model.Actual_Proposed_Year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.AddAsync(hse_sustainable_model);
                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.AddAsync(hse_sustainable_model);
                        }
                        //{
                        // }
                        // else
                        // {
                        // 	hse_sustainable_model.Date_Created = getData.Date_Created;
                        // 	hse_sustainable_model.Created_by = getData.Created_by;
                        // 	hse_sustainable_model.Date_Updated = DateTime.Now;
                        // 	hse_sustainable_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }
        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME"), DisableRequestSizeLimitAttribute]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME([FromForm] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME hse_sustainable_model, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME getData;

                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.COMPANY_ID == WKPCompanyId && c.Id == hse_sustainable_model.Id && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    hse_sustainable_model.Date_Updated = DateTime.Now;
                    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;
                    //hse_sustainable_model.OML_Name = omlName;
                    //hse_sustainable_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                    if (file1 != null)
                    {
                        string docName = "TS";
                        hse_sustainable_model.TSUploadFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"TSDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_sustainable_model.TSUploadFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });

                    }
                    else
                    {
                        hse_sustainable_model.TSUploadFilePath = null;
                    }
                    #endregion
                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.AddAsync(hse_sustainable_model);
                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.AddAsync(hse_sustainable_model);
                        }


                        // }
                        // else
                        // {
                        // 	hse_sustainable_model.Date_Created = getData.Date_Created;
                        // 	hse_sustainable_model.Created_by = getData.Created_by;
                        // 	hse_sustainable_model.Date_Updated = DateTime.Now;
                        // 	hse_sustainable_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship")]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship([FromBody] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship hse_sustainable_model, string year, int id, string actionToDo)
        {
            int save = 0;
            int Id = hse_sustainable_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_sustainable_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship getData;
                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.Actual_Proposed_Year == hse_sustainable_model.Actual_Proposed_Year && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    hse_sustainable_model.Companyemail = WKPCompanyEmail;
                    hse_sustainable_model.CompanyName = WKPCompanyName;
                    hse_sustainable_model.COMPANY_ID = WKPCompanyId;
                    hse_sustainable_model.CompanyNumber = WKPCompanyNumber;
                    hse_sustainable_model.Date_Updated = DateTime.Now;
                    hse_sustainable_model.Updated_by = WKPCompanyId;
                    hse_sustainable_model.Year_of_WP = year;
                    //hse_sustainable_model.OML_Name = omlName;
                    //hse_sustainable_model.Field_ID = concessionField?.Field_ID ?? null;
                    //hse_sustainable_model.Actual_Proposed_Year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        //if (getData == null)
                        //{

                        if (getData == null)
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.AddAsync(hse_sustainable_model);

                        }
                        else
                        {
                            hse_sustainable_model.Date_Created = DateTime.Now;
                            hse_sustainable_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.AddAsync(hse_sustainable_model);
                        }
                        // }
                        // else
                        // {
                        // 	hse_sustainable_model.Date_Created = getData.Date_Created;
                        // 	hse_sustainable_model.Created_by = getData.Created_by;
                        // 	hse_sustainable_model.Date_Updated = DateTime.Now;
                        // 	hse_sustainable_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.AddAsync(hse_sustainable_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED")]
        public async Task<object> POST_HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED([FromBody] HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED hse_environmental_studies_new_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {


                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.Remove(getData);
                    save += _context.SaveChanges();
                    //Added by Musa
                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }
                if (hse_environmental_studies_new_model != null)
                {
                    HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED getData;
                    if (concessionField?.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_environmental_studies_new_model.Companyemail = WKPCompanyEmail;
                    hse_environmental_studies_new_model.CompanyName = WKPCompanyName;
                    hse_environmental_studies_new_model.COMPANY_ID = WKPCompanyId;
                    hse_environmental_studies_new_model.CompanyNumber = WKPCompanyNumber;
                    hse_environmental_studies_new_model.Date_Updated = DateTime.Now;
                    hse_environmental_studies_new_model.Updated_by = WKPCompanyId;
                    hse_environmental_studies_new_model.Year_of_WP = year;
                    hse_environmental_studies_new_model.OML_Name = omlName;
                    hse_environmental_studies_new_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_environmental_studies_new_model.Date_Created = DateTime.Now;
                        hse_environmental_studies_new_model.Created_by = WKPCompanyId;
                        await _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.AddAsync(hse_environmental_studies_new_model);
                        // }
                        // else
                        // {
                        //     hse_environmental_studies_new_model.Date_Created = getData.Date_Created;
                        //     hse_environmental_studies_new_model.Created_by = getData.Created_by;
                        //     hse_environmental_studies_new_model.Date_Updated = DateTime.Now;
                        //     hse_environmental_studies_new_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.Remove(getData);
                        //     await _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.AddAsync(hse_environmental_studies_new_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_POINT_SOURCE_REGISTRATION")]
        public async Task<object> POST_HSE_POINT_SOURCE_REGISTRATION([FromForm] HSE_POINT_SOURCE_REGISTRATION hse_point_source_registration, string omlName, string actionToDo, string fieldName, string year, int id)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {


                if (id > 0)
                {
                    var getData = (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_POINT_SOURCE_REGISTRATIONs.Remove(getData);
                    save += _context.SaveChanges();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }
                if (hse_point_source_registration != null)
                {
                    HSE_POINT_SOURCE_REGISTRATION getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.OML_Name == concessionField.Concession_Name && c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.OML_Name == concessionField.Concession_Name && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_point_source_registration.OML_ID = concessionField.Concession_ID.ToString();
                    hse_point_source_registration.OML_Name = omlName;
                    hse_point_source_registration.Field_ID = concessionField?.Field_ID ?? null;
                    hse_point_source_registration.Year_of_WP = year;
                    hse_point_source_registration.Company_ID = WKPCompanyId;
                    hse_point_source_registration.CompanyName = WKPCompanyName;

                    hse_point_source_registration.Company_Email = WKPCompanyEmail;

                    hse_point_source_registration.Company_Number = WKPCompanyNumber.ToString();



                    if (hse_point_source_registration.are_there_point_source_permit == "YES")
                    {
                        #region Fileregion
                        var file = Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                        var blobname = blobService.Filenamer(file);

                        if (file != null)
                        {
                            string docName = "Evidence of Registration";
                            hse_point_source_registration.evidence_of_PSP_path = await blobService.UploadFileBlobAsync("documents", file.OpenReadStream(), file.ContentType, $"Remediation Documents/{blobname}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_point_source_registration.evidence_of_PSP_path == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_point_source_registration.evidence_of_PSP_filename = blobname;
                        }
                        else
                        {
                            hse_point_source_registration.evidence_of_PSP_path = null;
                            hse_point_source_registration.evidence_of_PSP_filename = null;
                        }
                        #endregion
                    }
                    else
                    {
                        hse_point_source_registration.evidence_of_PSP_path = null;
                        hse_point_source_registration.evidence_of_PSP_filename = null;
                    }



                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {


                            await _context.HSE_POINT_SOURCE_REGISTRATIONs.AddAsync(hse_point_source_registration);
                        }
                        else
                        {

                            _context.HSE_POINT_SOURCE_REGISTRATIONs.Remove(getData);
                            await _context.HSE_POINT_SOURCE_REGISTRATIONs.AddAsync(hse_point_source_registration);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_POINT_SOURCE_REGISTRATIONs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = All_Data, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    string successMsg = "No update was made.";
                    var All_Data = await (from c in _context.HSE_POINT_SOURCE_REGISTRATIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = All_Data, Message = successMsg, StatusCode = ResponseCodes.Success };
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_REMEDIATION_FUND")]
        public async Task<object> POST_HSE_REMEDIATION_FUND([FromForm] HSE_REMEDIATION_FUND hse_remediation_fund, string omlName, string fieldName, string year, int id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_REMEDIATION_FUNDs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_REMEDIATION_FUNDs.Remove(getData);
                    save += _context.SaveChanges();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }
                if (hse_remediation_fund != null)
                {
                    HSE_REMEDIATION_FUND getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.HSE_REMEDIATION_FUNDs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.HSE_REMEDIATION_FUNDs where c.OML_Name == omlName && c.Company_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    hse_remediation_fund.OML_ID = concessionField.Concession_ID.ToString();
                    hse_remediation_fund.Company_Email = WKPCompanyEmail;
                    hse_remediation_fund.CompanyName = WKPCompanyName;
                    hse_remediation_fund.Company_ID = WKPCompanyId;
                    hse_remediation_fund.Company_Number = WKPCompanyNumber.ToString();
                    hse_remediation_fund.OML_Name = omlName;
                    hse_remediation_fund.Field_ID = concessionField?.Field_ID ?? null;
                    hse_remediation_fund.Year_of_WP = year;

                    if (hse_remediation_fund.areThereRemediationFund == "YES")
                    {
                        #region Fileregion
                        var file1 = Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                        var file2 = Request.Form.Files[1] != null ? Request.Form.Files[1] : null;

                        var blobname1 = blobService.Filenamer(file1);
                        var blobname2 = blobService.Filenamer(file2);

                        if (file1 != null)
                        {
                            string docName = "Evidence of Payment";
                            hse_remediation_fund.evidenceOfPaymentPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"Remediation Documents/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_remediation_fund.evidenceOfPaymentPath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_remediation_fund.evidenceOfPaymentFilename = blobname1;
                        }
                        else
                        {
                            hse_remediation_fund.evidenceOfPaymentPath = null;
                            hse_remediation_fund.evidenceOfPaymentFilename = null;

                        }

                        if (file2 != null)
                        {
                            string docName = "Evidence of Payment";
                            hse_remediation_fund.evidenceOfPreviousYearsPaymentPath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"Remediation Documents/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_remediation_fund.evidenceOfPreviousYearsPaymentPath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_remediation_fund.evidenceOfPreviousYearsPaymentFilename = blobname2;
                        }
                        else
                        {
                            hse_remediation_fund.evidenceOfPreviousYearsPaymentPath = null;
                            hse_remediation_fund.evidenceOfPreviousYearsPaymentFilename = null;

                        }
                        #endregion
                    }
                    else
                    {
                        hse_remediation_fund.evidenceOfPaymentPath = null;
                        hse_remediation_fund.evidenceOfPaymentFilename = null;


                        var file1 = Request.Form.Files[0] != null ? Request.Form.Files[0] : null;

                        var blobname1 = blobService.Filenamer(file1);

                        if (file1 != null)
                        {
                            string docName = "Evidence of Payment";
                            hse_remediation_fund.evidenceOfPreviousYearsPaymentPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"Remediation Documents/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_remediation_fund.evidenceOfPreviousYearsPaymentPath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_remediation_fund.evidenceOfPreviousYearsPaymentFilename = blobname1;
                        }
                        else
                        {
                            hse_remediation_fund.evidenceOfPreviousYearsPaymentPath = null;
                            hse_remediation_fund.evidenceOfPreviousYearsPaymentFilename = null;

                        }

                    }

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        if (getData == null)
                        {
                            await _context.HSE_REMEDIATION_FUNDs.AddAsync(hse_remediation_fund);
                        }
                        else
                        {
                            _context.HSE_REMEDIATION_FUNDs.Remove(getData);
                            await _context.HSE_REMEDIATION_FUNDs.AddAsync(hse_remediation_fund);
                        }
                        // }
                        // else
                        // {
                        //     hse_remediation_fund.Updated_by = WKPCompanyId;
                        //     hse_remediation_fund.Date_Updated = DateTime.Now;
                        //     hse_remediation_fund.Date_Created = getData.Date_Created;
                        //     hse_remediation_fund.Created_by = getData.Created_by;
                        //     _context.HSE_REMEDIATION_FUNDs.Remove(getData);
                        //     await _context.HSE_REMEDIATION_FUNDs.AddAsync(hse_remediation_fund);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_REMEDIATION_FUNDs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_ID == WKPCompanyId && c.Year_of_WP == year && c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = All_Data, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    string successMsg = "No Changes was made.";
                    var All_Data = await (from c in _context.HSE_REMEDIATION_FUNDs where c.Company_ID == WKPCompanyId && c.Year_of_WP == year && c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = All_Data, Message = successMsg, StatusCode = ResponseCodes.Success };

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_WASTE_MANAGEMENT_DZ")]
        public async Task<object> POST_HSE_WASTE_MANAGEMENT_DZ([FromForm] HSE_WASTE_MANAGEMENT_DZ hSE_WASTE_MANAGEMENT_DZ, string omlName, string fieldName, string year, string omlID, string actionToDo)
        {

            int save = 0;
            int Id = hSE_WASTE_MANAGEMENT_DZ.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (!string.IsNullOrEmpty(omlID))
                {
                    var getData = (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.Id == int.Parse(omlID) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_WASTE_MANAGEMENT_DZs.Remove(getData);
                    save += _context.SaveChanges();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.OML_ID == omlID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }
                if (hSE_WASTE_MANAGEMENT_DZ != null)
                {
                    HSE_WASTE_MANAGEMENT_DZ getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.OML_ID == omlID && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }
                    else
                    {
                        getData = await (from c in _context.HSE_WASTE_MANAGEMENT_DZs where c.OML_ID == omlID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    }

                    hSE_WASTE_MANAGEMENT_DZ.OML_ID = omlID;
                    hSE_WASTE_MANAGEMENT_DZ.Companyemail = WKPCompanyEmail;
                    hSE_WASTE_MANAGEMENT_DZ.CompanyName = WKPCompanyName;
                    hSE_WASTE_MANAGEMENT_DZ.COMPANY_ID = WKPCompanyId;
                    hSE_WASTE_MANAGEMENT_DZ.CompanyNumber = WKPCompanyNumber;
                    hSE_WASTE_MANAGEMENT_DZ.OML_Name = omlName;
                    hSE_WASTE_MANAGEMENT_DZ.Field_ID = concessionField?.Field_ID ?? null;
                    hSE_WASTE_MANAGEMENT_DZ.Year_of_WP = year;

                    #region Fileregion
                    if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                    {
                        IFormFile? file1 = null;
                        string blobname1 = string.Empty;

                        IFormFile? file2 = null;
                        string blobname2 = string.Empty;

                        IFormFile? file3 = null;
                        string blobname3 = string.Empty;

                        if (Request.Form.Files.Count == 1)
                        {
                            file1 = Request.Form.Files[0];
                            blobname1 = blobService.Filenamer(file1);
                            if (file1 != null)
                            {
                                string docName = "Upload Evidence of EWD";
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"UploadCommDevPlanApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Filename = blobname1;

                            }
                        }
                        else
                        {
                            hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path = null;
                            hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Filename = null;
                        }
                        if (Request.Form.Files.Count == 2)
                        {
                            file1 = Request.Form.Files[0];
                            file2 = Request.Form.Files[1];
                            blobname1 = blobService.Filenamer(file1);
                            blobname2 = blobService.Filenamer(file2);
                            if (file1 != null)
                            {
                                string docName = "Upload Evidence of EWD";
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"UploadCommDevPlanApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Filename = blobname1;

                            }
                            else
                            {
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path = null;
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Filename = null;
                            }

                            if (file2 != null)
                            {
                                string docName = "Evidence Of Pay Trust Fund";
                                hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Path = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"EvidenceOfPayTrustFundDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Path == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Filename = blobname2;

                            }
                            else
                            {
                                hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Path = null;
                                hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Filename = null;
                            }
                        }
                        else
                        {
                            hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Path = null;
                            hSE_WASTE_MANAGEMENT_DZ.Waste_Service_Permit_Filename = null;
                        }

                        if (Request.Form.Files.Count > 2)
                        {
                            file1 = Request.Form.Files[0];
                            file2 = Request.Form.Files[1];
                            file3 = Request.Form.Files[2];
                            blobname1 = blobService.Filenamer(file1);
                            blobname2 = blobService.Filenamer(file2);
                            blobname3 = blobService.Filenamer(file3);
                            if (file1 != null)
                            {
                                string docName = "Upload Evidence of EWD";
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"UploadCommDevPlanApprovalDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Filename = blobname1;

                            }
                            else
                            {
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Path = null;
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_EWD_Filename = null;
                            }

                            if (file2 != null)
                            {
                                string docName = "Evidence Of Pay of DDCPath";
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_pay_of_DDCPath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"EvidenceOfPayTrustFundDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (hSE_WASTE_MANAGEMENT_DZ.Evidence_of_pay_of_DDCPath == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    hSE_WASTE_MANAGEMENT_DZ.Evidence_of_pay_of_DDCFilename = blobname2;

                            }
                            else
                            {
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_pay_of_DDCPath = null;
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_pay_of_DDCFilename = null;
                            }

                            if (file3 != null)
                            {
                                string docName = "Evidence Of Reinjection Permit ";
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_Reinjection_Permit_Path = await blobService.UploadFileBlobAsync("documents", file3.OpenReadStream(), file3.ContentType, $"EvidenceOfRegTrustFundDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));

                                if (hSE_WASTE_MANAGEMENT_DZ.Evidence_of_Reinjection_Permit_Path == null)
                                    return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                                else
                                    hSE_WASTE_MANAGEMENT_DZ.Evidence_of_Reinjection_Permit_Filename = blobname3;

                            }
                            else
                            {
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_Reinjection_Permit_Path = null;
                                hSE_WASTE_MANAGEMENT_DZ.Evidence_of_Reinjection_Permit_Filename = null;
                            }
                        }
                    }

                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        if (getData == null)
                        {
                            hSE_WASTE_MANAGEMENT_DZ.Date_Created = DateTime.Now;
                            hSE_WASTE_MANAGEMENT_DZ.Created_by = WKPCompanyId;
                            await _context.HSE_WASTE_MANAGEMENT_DZs.AddAsync(hSE_WASTE_MANAGEMENT_DZ);
                        }
                        else
                        {
                            hSE_WASTE_MANAGEMENT_DZ.Date_Created = DateTime.Now;
                            hSE_WASTE_MANAGEMENT_DZ.Created_by = WKPCompanyId;

                            _context.HSE_WASTE_MANAGEMENT_DZs.Remove(getData);
                            await _context.HSE_WASTE_MANAGEMENT_DZs.AddAsync(hSE_WASTE_MANAGEMENT_DZ);
                        }

                        // }
                        // else
                        // {
                        //     hSE_WASTE_MANAGEMENT_DZ.Date_Created = getData.Date_Created;
                        //     hSE_WASTE_MANAGEMENT_DZ.Created_by = getData.Created_by;
                        //     hSE_WASTE_MANAGEMENT_DZ.Date_Updated = DateTime.Now;
                        //     hSE_WASTE_MANAGEMENT_DZ.Updated_by = WKPCompanyId;
                        //     _context.HSE_WASTE_MANAGEMENT_DZs.Remove(getData);
                        //     await _context.HSE_WASTE_MANAGEMENT_DZs.AddAsync(hSE_WASTE_MANAGEMENT_DZ);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_WASTE_MANAGEMENT_DZs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                        var All_Data = _context.HSE_WASTE_MANAGEMENT_DZs.Where(a => a.Year_of_WP == year && a.Field_ID == concessionField.Field_ID && a.COMPANY_ID == WKPCompanyId && a.OML_Name == concessionField.Concession_Name).ToList();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                    else
                    {
                        return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                    }
                }

                return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }



        [HttpPost("POST_HSE_OSP_REGISTRATIONS_NEW")]
        public async Task<object> POST_HSE_OSP_REGISTRATIONS_NEW([FromBody] HSE_OSP_REGISTRATIONS_NEW hse_osp_registrations_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_OSP_REGISTRATIONS_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_osp_registrations_model != null)
                {
                    HSE_OSP_REGISTRATIONS_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.VALUES_ == hse_osp_registrations_model.VALUES_ && c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.VALUES_ == hse_osp_registrations_model.VALUES_ && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_osp_registrations_model.Companyemail = WKPCompanyEmail;
                    hse_osp_registrations_model.CompanyName = WKPCompanyName;
                    hse_osp_registrations_model.COMPANY_ID = WKPCompanyId;
                    hse_osp_registrations_model.CompanyNumber = WKPCompanyNumber;
                    hse_osp_registrations_model.Date_Updated = DateTime.Now;
                    hse_osp_registrations_model.Updated_by = WKPCompanyId;
                    hse_osp_registrations_model.Year_of_WP = year;
                    hse_osp_registrations_model.OML_Name = omlName;
                    hse_osp_registrations_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_osp_registrations_model.Date_Created = DateTime.Now;
                        hse_osp_registrations_model.Created_by = WKPCompanyId;
                        await _context.HSE_OSP_REGISTRATIONS_NEWs.AddAsync(hse_osp_registrations_model);
                        // }
                        // else
                        // {
                        //     hse_osp_registrations_model.Date_Created = getData.Date_Created;
                        //     hse_osp_registrations_model.Created_by = getData.Created_by;
                        //     hse_osp_registrations_model.Date_Updated = DateTime.Now;
                        //     hse_osp_registrations_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_OSP_REGISTRATIONS_NEWs.Remove(getData);
                        //     await _context.HSE_OSP_REGISTRATIONS_NEWs.AddAsync(hse_osp_registrations_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_OSP_REGISTRATIONS_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.HSE_OSP_REGISTRATIONS_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED")]
        public async Task<object> POST_HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED([FromBody] HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED hse_produced_water_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_produced_water_model != null)
                {
                    HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_produced_water_model.Companyemail = WKPCompanyEmail;
                    hse_produced_water_model.CompanyName = WKPCompanyName;
                    hse_produced_water_model.COMPANY_ID = WKPCompanyId;
                    hse_produced_water_model.CompanyNumber = WKPCompanyNumber;
                    hse_produced_water_model.Date_Updated = DateTime.Now;
                    hse_produced_water_model.Updated_by = WKPCompanyId;
                    hse_produced_water_model.Year_of_WP = year;
                    hse_produced_water_model.OML_Name = omlName;
                    hse_produced_water_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_produced_water_model.Date_Created = DateTime.Now;
                        hse_produced_water_model.Created_by = WKPCompanyId;
                        await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.AddAsync(hse_produced_water_model);
                        // }
                        // else
                        // {
                        //     hse_produced_water_model.Date_Created = getData.Date_Created;
                        //     hse_produced_water_model.Created_by = getData.Created_by;
                        //     hse_produced_water_model.Date_Updated = DateTime.Now;
                        //     hse_produced_water_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.Remove(getData);
                        //     await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.AddAsync(hse_produced_water_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW")]
        public async Task<object> POST_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW([FromBody] HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW hse_chemical_usage_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            int Id = hse_chemical_usage_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_chemical_usage_model != null)
                {
                    HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_chemical_usage_model.Companyemail = WKPCompanyEmail;
                    hse_chemical_usage_model.CompanyName = WKPCompanyName;
                    hse_chemical_usage_model.COMPANY_ID = WKPCompanyId;
                    hse_chemical_usage_model.CompanyNumber = WKPCompanyNumber;
                    hse_chemical_usage_model.Date_Updated = DateTime.Now;
                    hse_chemical_usage_model.Updated_by = WKPCompanyId;
                    hse_chemical_usage_model.Year_of_WP = year;
                    hse_chemical_usage_model.OML_Name = omlName;
                    hse_chemical_usage_model.Field_ID = concessionField?.Field_ID ?? null;
                    hse_chemical_usage_model.ACTUAL_year = year;
                    hse_chemical_usage_model.PROPOSED_year = (int.Parse(year) + 1).ToString();

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_chemical_usage_model.Date_Created = DateTime.Now;
                            hse_chemical_usage_model.Created_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.AddAsync(hse_chemical_usage_model);
                        }
                        else
                        {
                            hse_chemical_usage_model.Date_Created = DateTime.Now;
                            hse_chemical_usage_model.Created_by = WKPCompanyId;

                            _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.Remove(getData);
                            await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.AddAsync(hse_chemical_usage_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_chemical_usage_model.Date_Created = getData.Date_Created;
                        //     hse_chemical_usage_model.Created_by = getData.Created_by;
                        //     hse_chemical_usage_model.Date_Updated = DateTime.Now;
                        //     hse_chemical_usage_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.Remove(getData);
                        //     await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.AddAsync(hse_chemical_usage_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_CAUSES_OF_SPILL")]
        public async Task<object> POST_HSE_CAUSES_OF_SPILL([FromBody] HSE_CAUSES_OF_SPILL hse_causes_of_spill_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_CAUSES_OF_SPILLs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_CAUSES_OF_SPILLs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_causes_of_spill_model != null)
                {
                    HSE_CAUSES_OF_SPILL getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_CAUSES_OF_SPILLs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_CAUSES_OF_SPILLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }

                    hse_causes_of_spill_model.Companyemail = WKPCompanyEmail;
                    hse_causes_of_spill_model.CompanyName = WKPCompanyName;
                    hse_causes_of_spill_model.COMPANY_ID = WKPCompanyId;
                    hse_causes_of_spill_model.CompanyNumber = WKPCompanyNumber;
                    hse_causes_of_spill_model.Date_Updated = DateTime.Now;
                    hse_causes_of_spill_model.Updated_by = WKPCompanyId;
                    hse_causes_of_spill_model.Year_of_WP = year;
                    hse_causes_of_spill_model.OML_Name = omlName;
                    hse_causes_of_spill_model.Field_ID = concessionField?.Field_ID ?? null;

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {
                        hse_causes_of_spill_model.Date_Created = DateTime.Now;
                        hse_causes_of_spill_model.Created_by = WKPCompanyId;
                        await _context.HSE_CAUSES_OF_SPILLs.AddAsync(hse_causes_of_spill_model);
                        // }
                        // else
                        // {
                        //     hse_causes_of_spill_model.Date_Created = getData.Date_Created;
                        //     hse_causes_of_spill_model.Created_by = getData.Created_by;
                        //     hse_causes_of_spill_model.Date_Updated = DateTime.Now;
                        //     hse_causes_of_spill_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_CAUSES_OF_SPILLs.Remove(getData);
                        //     await _context.HSE_CAUSES_OF_SPILLs.AddAsync(hse_causes_of_spill_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_CAUSES_OF_SPILLs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.HSE_CAUSES_OF_SPILLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME([FromForm] HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME hse_scholarship_model, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = hse_scholarship_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            // var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    //int.Parse(id)
                    var getData = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_scholarship_model != null)
                {
                    HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME getData;
                    getData = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.COMPANY_ID == WKPCompanyId && c.Id == hse_scholarship_model.Id && c.Year_of_WP == year select c).FirstOrDefaultAsync();

                    hse_scholarship_model.Companyemail = WKPCompanyEmail;
                    hse_scholarship_model.CompanyName = WKPCompanyName;
                    hse_scholarship_model.COMPANY_ID = WKPCompanyId;
                    hse_scholarship_model.CompanyNumber = WKPCompanyNumber;
                    hse_scholarship_model.Date_Updated = DateTime.Now;
                    hse_scholarship_model.Updated_by = WKPCompanyId;
                    hse_scholarship_model.Year_of_WP = year;
                    //hse_scholarship_model.OML_Name = omlName;
                    //hse_scholarship_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                    if (file1 != null)
                    {
                        string docName = "SS";
                        hse_scholarship_model.SSUploadFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"SSDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_scholarship_model.SSUploadFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_scholarship_model.SSUploadFilename = blobname1;
                    }
                    else
                    {
                        hse_scholarship_model.SSUploadFilePath = null;
                        hse_scholarship_model.SSUploadFilename = null;
                    }

                    #endregion
                    if (action == GeneralModel.Insert)
                    {
                        //if (getData == null)
                        //{
                        if (getData == null)
                        {
                            hse_scholarship_model.Date_Created = DateTime.Now;
                            hse_scholarship_model.Created_by = WKPCompanyId;
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.AddAsync(hse_scholarship_model);
                        }
                        else
                        {
                            hse_scholarship_model.Date_Created = DateTime.Now;
                            hse_scholarship_model.Created_by = WKPCompanyId;

                            _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.Remove(getData);
                            await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.AddAsync(hse_scholarship_model);
                        }

                        // }
                        // else
                        // {
                        // 	hse_scholarship_model.Date_Created = getData.Date_Created;
                        // 	hse_scholarship_model.Created_by = getData.Created_by;
                        // 	hse_scholarship_model.Date_Updated = DateTime.Now;
                        // 	hse_scholarship_model.Updated_by = WKPCompanyId;
                        // 	_context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.Remove(getData);
                        // 	await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.AddAsync(hse_scholarship_model);
                        // }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.Remove(getData);
                    }
                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_MANAGEMENT_POSITION"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_MANAGEMENT_POSITION([FromForm] HSE_MANAGEMENT_POSITION hse_management_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();

            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);
            try
            {
                if (!string.IsNullOrEmpty(id) && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_MANAGEMENT_POSITIONs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete.ToLower())
                        _context.HSE_MANAGEMENT_POSITIONs.Remove(getData);
                    save += _context.SaveChanges();
                    //Added By Musa
                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }
                if (hse_management_model != null)
                {
                    //List<HSE_MANAGEMENT_POSITION> getData;
                    //if (concessionField.Field_Name != null)
                    //{
                    //    getData = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //}
                    //else
                    //{
                    //    getData = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //}

                    HSE_MANAGEMENT_POSITION getData = _context.HSE_MANAGEMENT_POSITIONs.Where(x => x.Id == int.Parse(id)).FirstOrDefault();

                    hse_management_model.Companyemail = WKPCompanyEmail;
                    hse_management_model.CompanyName = WKPCompanyName;
                    hse_management_model.COMPANY_ID = WKPCompanyId;
                    hse_management_model.CompanyNumber = WKPCompanyNumber;
                    hse_management_model.Date_Updated = DateTime.Now;
                    hse_management_model.Updated_by = WKPCompanyId;
                    hse_management_model.Year_of_WP = year;
                    hse_management_model.OML_Name = omlName;
                    hse_management_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var file2 = Request.Form.Files[1] != null ? Request.Form.Files[1] : null;
                    var blobname1 = blobService.Filenamer(file1);
                    var blobname2 = blobService.Filenamer(file2);

                    if (file1 != null)
                    {
                        string docName = "Promotion Letter";
                        hse_management_model.PromotionLetterFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"HRDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_management_model.PromotionLetterFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_management_model.PromotionLetterFilename = blobname1;
                    }
                    if (file2 != null)
                    {
                        string docName = "Organogram";
                        hse_management_model.OrganogramrFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"OGDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_management_model.OrganogramrFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_management_model.OrganogramrFilename = blobname2;

                    }
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData.Count <= 0)
                        // {

                        if (getData == null)
                        {
                            hse_management_model.Date_Created = DateTime.Now;
                            hse_management_model.Created_by = WKPCompanyId;

                            await _context.HSE_MANAGEMENT_POSITIONs.AddAsync(hse_management_model);
                        }
                        else
                        {
                            hse_management_model.Date_Created = DateTime.Now;
                            hse_management_model.Created_by = WKPCompanyId;

                            _context.HSE_MANAGEMENT_POSITIONs.Remove(getData);
                            await _context.HSE_MANAGEMENT_POSITIONs.AddAsync(hse_management_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_management_model.Date_Created = getData.FirstOrDefault().Date_Created;
                        //     hse_management_model.Created_by = getData.FirstOrDefault().Created_by;
                        //     hse_management_model.Date_Updated = DateTime.Now;
                        //     hse_management_model.Updated_by = WKPCompanyId;

                        //     getData.ForEach(x =>
                        //     {
                        //         _context.HSE_MANAGEMENT_POSITIONs.Remove(x);
                        //         save += _context.SaveChanges();

                        //     });

                        //     await _context.HSE_MANAGEMENT_POSITIONs.AddAsync(hse_management_model);
                        // }
                    }

                    save += await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(int.Parse(id) > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_MANAGEMENT_POSITIONs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                //else
                //{
                return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                //}
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_SAFETY_CULTURE_TRAINING"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_SAFETY_CULTURE_TRAINING([FromForm] HSE_SAFETY_CULTURE_TRAINING hse_safety_culture_model, string year, string omlName, string fieldName, int id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_SAFETY_CULTURE_TRAININGs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_safety_culture_model != null)
                {
                    //List<HSE_SAFETY_CULTURE_TRAINING> getData;
                    //if (concessionField.Field_Name != null)
                    //{
                    //    getData = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //}
                    //else
                    //{
                    //    getData = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    //}

                    var getData = id > 0 ? _context.HSE_SAFETY_CULTURE_TRAININGs.Where(x => x.Id == id).FirstOrDefault() : null;


                    hse_safety_culture_model.Companyemail = WKPCompanyEmail;
                    hse_safety_culture_model.CompanyName = WKPCompanyName;
                    hse_safety_culture_model.COMPANY_ID = WKPCompanyId;
                    hse_safety_culture_model.CompanyNumber = WKPCompanyNumber;
                    hse_safety_culture_model.Date_Updated = DateTime.Now;
                    hse_safety_culture_model.Updated_by = WKPCompanyId;
                    hse_safety_culture_model.Year_of_WP = year;
                    hse_safety_culture_model.OML_Name = omlName;
                    hse_safety_culture_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var filesLength = Request.Form.Files;

                    IFormFile? file1 = null;
                    IFormFile? file2 = null;
                    IFormFile? file3 = null;
                    var blobname3 = string.Empty;

                    var blobname1 = string.Empty;
                    var blobname2 = string.Empty;

                    if (filesLength.Count > 2)
                    {
                        file1 = Request.Form.Files[0];
                        file2 = Request.Form.Files[1];
                        file3 = Request.Form.Files[2];

                        blobname3 = blobService.Filenamer(file3);
                        blobname1 = blobService.Filenamer(file1);
                        blobname2 = blobService.Filenamer(file2);

                        if (file3 != null)
                        {
                            string docName = "Evidence Of Training Plan";
                            hse_safety_culture_model.EvidenceOfTrainingPlanPath = await blobService.UploadFileBlobAsync("documents", file3.OpenReadStream(), file3.ContentType, $"EvidenceOfTrainingPlanDocuments/{blobname3}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_safety_culture_model.EvidenceOfTrainingPlanPath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_safety_culture_model.EvidenceOfTrainingPlanFilename = blobname3;
                        }
                        else
                        {
                            hse_safety_culture_model.EvidenceOfTrainingPlanPath = null;
                            hse_safety_culture_model.EvidenceOfTrainingPlanFilename = null;
                        }
                        if (file1 != null)
                        {
                            string docName = "Safety Current Year";
                            hse_safety_culture_model.SafetyCurrentYearFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"SafetyCurrentYearDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_safety_culture_model.SafetyCurrentYearFilePath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_safety_culture_model.SafetyCurrentYearFilename = blobname1;
                        }
                        else
                        {
                            hse_safety_culture_model.SafetyCurrentYearFilePath = null;
                            hse_safety_culture_model.SafetyCurrentYearFilename = null;
                        }

                        if (file2 != null)
                        {
                            string docName = "Safety Last Two Years";
                            hse_safety_culture_model.SafetyLast2YearsFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"SafetyLast2YearsDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_safety_culture_model.SafetyLast2YearsFilePath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_safety_culture_model.SafetyLast2YearsFilename = blobname2;
                        }
                        else
                        {
                            hse_safety_culture_model.SafetyLast2YearsFilePath = null;
                            hse_safety_culture_model.SafetyLast2YearsFilename = null;
                        }
                    }
                    else if (filesLength.Count == 2)
                    {
                        file1 = Request.Form.Files[0];
                        file2 = Request.Form.Files[1];

                        blobname1 = blobService.Filenamer(file1);
                        blobname2 = blobService.Filenamer(file2);

                        if (file1 != null)
                        {
                            string docName = "Safety Current Year";
                            hse_safety_culture_model.SafetyCurrentYearFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"SafetyCurrentYearDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_safety_culture_model.SafetyCurrentYearFilePath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_safety_culture_model.SafetyCurrentYearFilename = blobname1;
                        }
                        else
                        {
                            hse_safety_culture_model.SafetyCurrentYearFilePath = null;
                            hse_safety_culture_model.SafetyCurrentYearFilename = null;
                        }

                        if (file2 != null)
                        {
                            string docName = "Safety Last Two Years";
                            hse_safety_culture_model.SafetyLast2YearsFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"SafetyLast2YearsDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_safety_culture_model.SafetyLast2YearsFilePath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_safety_culture_model.SafetyLast2YearsFilename = blobname2;
                        }
                        else
                        {
                            hse_safety_culture_model.SafetyLast2YearsFilePath = null;
                            hse_safety_culture_model.SafetyLast2YearsFilename = null;
                        }

                        hse_safety_culture_model.EvidenceOfTrainingPlanPath = null;
                        hse_safety_culture_model.EvidenceOfTrainingPlanFilename = null;
                    }
                    else if (filesLength.Count == 1)
                    {
                        file1 = Request.Form.Files[0];

                        blobname1 = blobService.Filenamer(file1);

                        if (file1 != null)
                        {
                            string docName = "Safety Current Year";
                            hse_safety_culture_model.EvidenceOfTrainingPlanPath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"SafetyCurrentYearDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_safety_culture_model.EvidenceOfTrainingPlanPath == null)
                                return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                            else
                                hse_safety_culture_model.EvidenceOfTrainingPlanFilename = blobname1;
                        }
                        else
                        {
                            hse_safety_culture_model.EvidenceOfTrainingPlanPath = null;
                            hse_safety_culture_model.EvidenceOfTrainingPlanFilename = null;
                        }
                    }
                    else
                    {
                        hse_safety_culture_model.SafetyCurrentYearFilePath = null;
                        hse_safety_culture_model.SafetyCurrentYearFilename = null;
                        hse_safety_culture_model.SafetyLast2YearsFilePath = null;
                        hse_safety_culture_model.SafetyLast2YearsFilename = null;
                        hse_safety_culture_model.EvidenceOfTrainingPlanPath = null;
                        hse_safety_culture_model.EvidenceOfTrainingPlanFilename = null;
                    }

                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData.Count <= 0)
                        // {

                        if (getData == null)
                        {
                            hse_safety_culture_model.Date_Created = DateTime.Now;
                            hse_safety_culture_model.Created_by = WKPCompanyId;
                            await _context.HSE_SAFETY_CULTURE_TRAININGs.AddAsync(hse_safety_culture_model);
                        }
                        else
                        {
                            hse_safety_culture_model.Date_Created = DateTime.Now;
                            hse_safety_culture_model.Created_by = WKPCompanyId;

                            _context.HSE_SAFETY_CULTURE_TRAININGs.Remove(getData);
                            await _context.HSE_SAFETY_CULTURE_TRAININGs.AddAsync(hse_safety_culture_model);
                        }
                        // }
                        // else
                        // {
                        //     hse_safety_culture_model.Date_Created = getData.FirstOrDefault().Date_Created;
                        //     hse_safety_culture_model.Created_by = getData.FirstOrDefault().Created_by;
                        //     hse_safety_culture_model.Date_Updated = DateTime.Now;
                        //     hse_safety_culture_model.Updated_by = WKPCompanyId;
                        //     hse_safety_culture_model.CompanyNumber = WKPCompanyNumber;

                        //     getData.ForEach(x =>
                        //     {
                        //         _context.HSE_SAFETY_CULTURE_TRAININGs.Remove(x);
                        //         save += _context.SaveChanges();

                        //     });
                        //     await _context.HSE_SAFETY_CULTURE_TRAININGs.AddAsync(hse_safety_culture_model);
                        // }
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_SAFETY_CULTURE_TRAININGs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpPost("POST_HSE_QUALITY_CONTROL"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_QUALITY_CONTROL([FromForm] HSE_QUALITY_CONTROL hse_quality_model, string omlName, string fieldName, string year, int id, string actionToDo)
        {
            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_QUALITY_CONTROLs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_QUALITY_CONTROLs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_quality_model != null)
                {
                    //HSE_QUALITY_CONTROL getData;
                    //if (concessionField.Field_Name != null)
                    //{
                    //    getData = await (from c in _context.HSE_QUALITY_CONTROLs where c.Field_ID == concessionField.Field_ID && c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //}
                    //else
                    //{
                    //    getData = await (from c in _context.HSE_QUALITY_CONTROLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //}

                    var getData = id > 0 ? _context.HSE_QUALITY_CONTROLs.Where(x => x.Id == id).FirstOrDefault() : null;

                    hse_quality_model.Companyemail = WKPCompanyEmail;
                    hse_quality_model.CompanyName = WKPCompanyName;
                    hse_quality_model.COMPANY_ID = WKPCompanyId;
                    hse_quality_model.CompanyNumber = WKPCompanyNumber;
                    hse_quality_model.Date_Updated = DateTime.Now;
                    hse_quality_model.Updated_by = WKPCompanyId;
                    hse_quality_model.Year_of_WP = year;
                    hse_quality_model.OML_Name = omlName;
                    hse_quality_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                    if (file1 != null)
                    {
                        string docName = "Quality Control";
                        hse_quality_model.QualityControlFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"COSDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_quality_model.QualityControlFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_quality_model.QualityControlFilename = blobname1;
                    }
                    else
                    {
                        hse_quality_model.QualityControlFilePath = null;
                        hse_quality_model.QualityControlFilename = null;
                    }
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_quality_model.Date_Created = DateTime.Now;
                            hse_quality_model.Created_by = WKPCompanyId;
                            await _context.HSE_QUALITY_CONTROLs.AddAsync(hse_quality_model);
                        }
                        else
                        {
                            hse_quality_model.Date_Created = DateTime.Now;
                            hse_quality_model.Created_by = WKPCompanyId;

                            _context.HSE_QUALITY_CONTROLs.Remove(getData);
                            await _context.HSE_QUALITY_CONTROLs.AddAsync(hse_quality_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_quality_model.Date_Created = getData.Date_Created;
                        //     hse_quality_model.Created_by = getData.Created_by;
                        //     hse_quality_model.Date_Updated = DateTime.Now;
                        //     hse_quality_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_QUALITY_CONTROLs.RemoveRange(getData);
                        //     save += await _context.SaveChangesAsync();

                        //     await _context.HSE_QUALITY_CONTROLs.AddAsync(hse_quality_model);
                        // }
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });

                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_QUALITY_CONTROLs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_CLIMATE_CHANGE_AND_AIR_QUALITY"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_CLIMATE_CHANGE_AND_AIR_QUALITY([FromForm] HSE_CLIMATE_CHANGE_AND_AIR_QUALITY hse_climate_model, string omlName, string fieldName, string year, int id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_climate_model != null)
                {
                    //HSE_CLIMATE_CHANGE_AND_AIR_QUALITY getData;
                    //if (concessionField.Field_Name != null)
                    //{
                    //    getData = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    //}
                    //else
                    //{
                    //    getData = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    //}

                    var getData = id > 0 ? _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Where(x => x.Id == id).FirstOrDefault() : null;

                    hse_climate_model.Companyemail = WKPCompanyEmail;
                    hse_climate_model.CompanyName = WKPCompanyName;
                    hse_climate_model.COMPANY_ID = WKPCompanyId;
                    hse_climate_model.CompanyNumber = WKPCompanyNumber;
                    hse_climate_model.Date_Updated = DateTime.Now;
                    hse_climate_model.Updated_by = WKPCompanyId;
                    hse_climate_model.Year_of_WP = year;
                    hse_climate_model.OML_Name = omlName;
                    hse_climate_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                    if (file1 != null && hse_climate_model.DoyouhaveGHG.ToLower() == "yes")
                    {
                        string docName = "GHG";
                        hse_climate_model.GHGFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"GHGDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_climate_model.GHGFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_climate_model.GHGFilename = blobname1;
                    }
                    else
                    {
                        hse_climate_model.GHGFilePath = null;
                        hse_climate_model.GHGFilename = null;
                    }

                    #endregion
                    if (action == GeneralModel.Insert)
                    {
                        // if (getData == null)
                        // {

                        if (getData == null)
                        {
                            hse_climate_model.Date_Created = DateTime.Now;
                            hse_climate_model.Created_by = WKPCompanyId;
                            await _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.AddAsync(hse_climate_model);
                        }
                        else
                        {
                            hse_climate_model.Date_Created = DateTime.Now;
                            hse_climate_model.Created_by = WKPCompanyId;

                            _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Remove(getData);
                            await _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.AddAsync(hse_climate_model);
                        }

                        // }
                        // else
                        // {
                        //     hse_climate_model.Date_Created = getData.Date_Created;
                        //     hse_climate_model.Created_by = getData.Created_by;
                        //     hse_climate_model.Date_Updated = DateTime.Now;
                        //     hse_climate_model.Updated_by = WKPCompanyId;
                        //     _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Remove(getData);
                        //     await _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.AddAsync(hse_climate_model);
                        // }
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }

                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        // [HttpPost("POST_HSE_OCCUPATIONAL_HEALTH_MANAGEMENT"), DisableRequestSizeLimit]
        // public async Task<object> POST_HSE_OCCUPATIONAL_HEALTH_MANAGEMENT([FromForm] HSE_OCCUPATIONAL_HEALTH_MANAGEMENT hse_occupational_model, string omlName, string fieldName, string year, string id, string actionToDo)
        // {

        // 	int save = 0;
        // 	string action = (actionToDo == null || actionToDo =="")? GeneralModel.Insert : actionToDo; var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

        // 	try
        // 	{
        // 		if (!string.IsNullOrEmpty(id))
        // 		{
        // 			var getData = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.Id == int.Parse(id) select c).FirstOrDefault();

        // 			if (action == GeneralModel.Delete)
        // 				_context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Remove(getData);
        // 			save += _context.SaveChanges();
        // 		}
        // 		else if (hse_occupational_model != null)
        // 		{
        // 			var getData = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();

        // 			hse_occupational_model.Companyemail = WKPCompanyEmail;
        // 			hse_occupational_model.CompanyName = WKPCompanyName;
        // 			hse_occupational_model.COMPANY_ID = WKPCompanyId;
        // 			hse_occupational_model.CompanyNumber = WKPCompanyNumber;
        // 			hse_occupational_model.Date_Updated = DateTime.Now;
        // 			hse_occupational_model.Updated_by = WKPCompanyId;
        // 			hse_occupational_model.Year_of_WP = year;
        // 			hse_occupational_model.OML_Name = omlName;
        // 			hse_occupational_model.Field_ID = concessionField?.Field_ID ?? null;

        // 			#region file section
        // 			//var files = Request.Form.Files;
        // 			var file1 = Request.Form.Files[0];
        // 			var file2 = Request.Form.Files[1];

        // 			var blobname1 = blobService.Filenamer(file1);
        // 			var blobname2 = blobService.Filenamer(file2);


        // 			if (file1 != null)
        // 			{
        // 				string docName = "submission of OHM plan";
        // 				hse_occupational_model.OHMplanCommunicationFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"OHMplanCommunicationDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
        // 				if (hse_occupational_model.OHMplanCommunicationFilePath == null)
        // 					return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document."});
        // 				else
        // 					hse_occupational_model.OHMplanCommunicationFilename = blobname1;
        // 			}
        // 			if (file2 != null)
        // 			{
        // 				string docName = "Reason Why Ohm Was Not Communicated To Staff";
        // 				hse_occupational_model.ReasonWhyOhmWasNotCommunicatedToStaffPath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"FieldDiscoveryDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
        // 				if (hse_occupational_model.ReasonWhyOhmWasNotCommunicatedToStaffPath == null)
        // 					return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document."});
        // 				else
        // 					hse_occupational_model.ReasonWhyOhmWasNotCommunicatedToStaffFileName = blobname2;
        // 			}
        // 			//}


        // 			#endregion

        // 			if (action == GeneralModel.Insert)
        // 			{
        // 				if (getData == null)
        // 				{
        // 					hse_occupational_model.Date_Created = DateTime.Now;
        // 					hse_occupational_model.Created_by = WKPCompanyId;
        // 					await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.AddAsync(hse_occupational_model);
        // 				}
        // 				else
        // 				{
        // 					hse_occupational_model.Date_Created = getData.Date_Created;
        // 					hse_occupational_model.Created_by = getData.Created_by;
        // 					hse_occupational_model.Date_Updated = DateTime.Now;
        // 					hse_occupational_model.Updated_by = WKPCompanyId;
        // 					_context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Remove(getData);
        // 					await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.AddAsync(hse_occupational_model);
        // 				}
        // 			}

        // 			save += await _context.SaveChangesAsync();
        // 		}
        // 		else
        // 		{
        // 			return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed."});
        // 		}
        // 		if (save > 0)
        // 		{
        // 			string successMsg = Messager.ShowMessage(action);
        // 			var All_Data = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
        // 			return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
        // 		}
        // 		else
        // 		{
        // 			return BadRequest(new { message = "Error : An error occured while trying to submit this form."});

        // 		}
        // 	}
        // 	catch (Exception e)
        // 	{
        // 		return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

        // 	}
        // }

        [HttpPost("POST_HSE_OCCUPATIONAL_HEALTH_MANAGEMENT"), DisableRequestSizeLimit]
        public async Task<WebApiResponse> POST_HSE_OCCUPATIONAL_HEALTH_MANAGEMENT([FromForm] HSE_OCCUPATIONAL_HEALTH_MANAGEMENT hse_occupational_model, string omlName, string fieldName, string year, int id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (hse_occupational_model != null)
                {
                    //HSE_OCCUPATIONAL_HEALTH_MANAGEMENT getData;
                    //if (concessionField.Field_Name != null)
                    //{
                    //    getData = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //}
                    //else
                    //{
                    //    getData = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefaultAsync();
                    //}

                    var getData = id > 0 ? _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Where(x => x.Id == id).FirstOrDefault() : null;

                    hse_occupational_model.Companyemail = WKPCompanyEmail;
                    hse_occupational_model.CompanyName = WKPCompanyName;
                    hse_occupational_model.COMPANY_ID = WKPCompanyId;
                    hse_occupational_model.CompanyNumber = WKPCompanyNumber;
                    hse_occupational_model.Date_Updated = DateTime.Now;
                    hse_occupational_model.Updated_by = WKPCompanyId;
                    hse_occupational_model.Year_of_WP = year;
                    hse_occupational_model.OML_Name = omlName;
                    hse_occupational_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var files = Request.Form.Files;
                    if (files.Count > 0)
                    {
                        // if(files.Count)
                        var file1 = Request.Form?.Files[0];



                        if (file1 != null)
                        {
                            var blobname1 = blobService.Filenamer(file1);
                            string docName = "submission of OHM plan";
                            hse_occupational_model.OHMplanCommunicationFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"OHMplanCommunicationDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_occupational_model.OHMplanCommunicationFilePath == null)
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to upload " + docName + " document.", StatusCode = ResponseCodes.Badrequest };
                            else
                                hse_occupational_model.OHMplanCommunicationFilename = blobname1;
                        }
                        else
                        {
                            hse_occupational_model.OHMplanCommunicationFilePath = null;
                            hse_occupational_model.OHMplanCommunicationFilename = null;
                        }

                        if (files.Count == 2)
                        {
                            var file2 = Request.Form?.Files[1];
                            var blobname2 = blobService.Filenamer(file2);
                            string docName = "OHM Plan";
                            hse_occupational_model.OHMplanFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"FieldDiscoveryDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                            if (hse_occupational_model.OHMplanFilePath == null)
                                return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to upload " + docName + " document.", StatusCode = ResponseCodes.Badrequest };
                            else
                                hse_occupational_model.OHMplanFilename = blobname2;
                        }
                        else
                        {
                            hse_occupational_model.OHMplanFilePath = null;
                            hse_occupational_model.OHMplanFilename = null;
                        }
                    }
                    else
                    {
                        hse_occupational_model.OHMplanCommunicationFilePath = null;
                        hse_occupational_model.OHMplanCommunicationFilename = null;
                        hse_occupational_model.OHMplanFilePath = null;
                        hse_occupational_model.OHMplanFilename = null;
                    }


                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        //if (getData == null)
                        //{

                        if (getData == null)
                        {
                            hse_occupational_model.Date_Created = DateTime.Now;
                            hse_occupational_model.Created_by = WKPCompanyId;
                            await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.AddAsync(hse_occupational_model);
                        }
                        else
                        {
                            hse_occupational_model.Date_Created = DateTime.Now;
                            hse_occupational_model.Created_by = WKPCompanyId;

                            _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Remove(getData);
                            await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.AddAsync(hse_occupational_model);
                        }
                        //}
                        //else
                        //{
                        //	hse_occupational_model.Date_Created = getData.Date_Created;
                        //	hse_occupational_model.Created_by = getData.Created_by;
                        //	hse_occupational_model.Date_Updated = DateTime.Now;
                        //	hse_occupational_model.Updated_by = WKPCompanyId;
                        //	_context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Remove(getData);
                        //	await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.AddAsync(hse_occupational_model);
                        //}
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = $"Error : No data was passed for {actionToDo} process to be completed.", StatusCode = ResponseCodes.Failure };
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
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

        [HttpPost("POST_HSE_WASTE_MANAGEMENT_SYSTEM"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_WASTE_MANAGEMENT_SYSTEM([FromForm] HSE_WASTE_MANAGEMENT_SYSTEM hse_waste_model, string omlName, string fieldName, string year, int id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {

                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_WASTE_MANAGEMENT_SYSTEMs.Remove(getData);
                    save += await _context.SaveChangesAsync();
                }
                else if (hse_waste_model != null)
                {
                    HSE_WASTE_MANAGEMENT_SYSTEM getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }


                    hse_waste_model.Companyemail = WKPCompanyEmail;
                    hse_waste_model.CompanyName = WKPCompanyName;
                    hse_waste_model.COMPANY_ID = WKPCompanyId;
                    hse_waste_model.CompanyNumber = WKPCompanyNumber;
                    hse_waste_model.Date_Updated = DateTime.Now;
                    hse_waste_model.Updated_by = WKPCompanyId;
                    hse_waste_model.Year_of_WP = year;
                    hse_waste_model.OML_Name = omlName;
                    hse_waste_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var file2 = Request.Form.Files.Count > 1 && Request.Form.Files[1] != null ? Request.Form.Files[1] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;
                    var blobname2 = file2 != null ? blobService.Filenamer(file2) : null;

                    if (file1 != null)
                    {
                        string docName = "Decom Certificate";
                        hse_waste_model.WasteManagementPlanFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"DecomCertificateDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_waste_model.WasteManagementPlanFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_waste_model.WasteManagementPlanFilename = blobname1;
                    }
                    if (file2 != null)
                    {
                        string docName = "Waste Management Plan";
                        hse_waste_model.DecomCertificateFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"WasteManagementPlanDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_waste_model.DecomCertificateFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_waste_model.DecomCertificateFilename = blobname2;
                    }

                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            hse_waste_model.Date_Created = DateTime.Now;
                            hse_waste_model.Created_by = WKPCompanyId;
                            await _context.HSE_WASTE_MANAGEMENT_SYSTEMs.AddAsync(hse_waste_model);
                        }
                        else
                        {
                            hse_waste_model.Date_Created = getData.Date_Created;
                            hse_waste_model.Created_by = getData.Created_by;
                            hse_waste_model.Date_Updated = DateTime.Now;
                            hse_waste_model.Updated_by = WKPCompanyId;
                            _context.HSE_WASTE_MANAGEMENT_SYSTEMs.Remove(getData);
                            await _context.HSE_WASTE_MANAGEMENT_SYSTEMs.AddAsync(hse_waste_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_WASTE_MANAGEMENT_SYSTEMs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    var All_Data = await (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Data = All_Data, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpPost("POST_HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM"), DisableRequestSizeLimit]
        public async Task<object> POST_HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM([FromForm] HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM hse_EMS_model, string omlName, string fieldName, string year, string id, string actionToDo)
        {

            int save = 0;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower(); var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var getData = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.Id == int.Parse(id) select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.Remove(getData);
                    save += _context.SaveChanges();

                    if (save > 0)
                    {
                        string successMsg = Messager.ShowMessage(action);
                        var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                        return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = All_Data, StatusCode = ResponseCodes.Success };
                    }
                }
                if (hse_EMS_model != null)
                {
                    HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM getData;
                    if (concessionField.Field_Name != null)
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.Field_ID == concessionField.Field_ID && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }
                    else
                    {
                        getData = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).FirstOrDefault();
                    }


                    hse_EMS_model.Companyemail = WKPCompanyEmail;
                    hse_EMS_model.CompanyName = WKPCompanyName;
                    hse_EMS_model.COMPANY_ID = WKPCompanyId;
                    hse_EMS_model.CompanyNumber = WKPCompanyNumber;
                    hse_EMS_model.Date_Updated = DateTime.Now;
                    hse_EMS_model.Updated_by = WKPCompanyId;
                    hse_EMS_model.Year_of_WP = year;
                    hse_EMS_model.OML_Name = omlName;
                    hse_EMS_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var file2 = Request.Form.Files[1] != null ? Request.Form.Files[1] : null;
                    var blobname1 = blobService.Filenamer(file1);
                    var blobname2 = blobService.Filenamer(file2);

                    if (file1 != null)
                    {
                        string docName = "EMS";
                        hse_EMS_model.EMSFilePath = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"EMSDocuments/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_EMS_model.EMSFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_EMS_model.EMSFilename = blobname1;
                    }
                    if (file2 != null)
                    {
                        string docName = "Audit File";
                        hse_EMS_model.AUDITFilePath = await blobService.UploadFileBlobAsync("documents", file2.OpenReadStream(), file2.ContentType, $"AUDITDocuments/{blobname2}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (hse_EMS_model.AUDITFilePath == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                        else
                            hse_EMS_model.AUDITFilename = blobname2;
                    }
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            hse_EMS_model.Date_Created = DateTime.Now;
                            hse_EMS_model.Created_by = WKPCompanyId;
                            await _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.AddAsync(hse_EMS_model);
                        }
                        else
                        {
                            hse_EMS_model.Date_Created = getData.Date_Created;
                            hse_EMS_model.Created_by = getData.Created_by;
                            hse_EMS_model.Date_Updated = DateTime.Now;
                            hse_EMS_model.Updated_by = WKPCompanyId;
                            _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.Remove(getData);
                            await _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.AddAsync(hse_EMS_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(action);
                    //var All_Data = await (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }




        [HttpPost("POST_PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT"), DisableRequestSizeLimit]
        public async Task<object> POST_PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT([FromForm] PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT picture_upload_model, string year, int id, string actionToDo)
        {

            int save = 0;
            int Id = picture_upload_model.Id;
            string action = (actionToDo == null || actionToDo == "") ? GeneralModel.Insert : actionToDo.Trim().ToLower();
            //var concessionField = GET_CONCESSION_FIELD(omlName, fieldName);

            try
            {
                if (id > 0 && action == GeneralModel.Delete)
                {
                    var getData = (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.Id == id select c).FirstOrDefault();

                    if (action == GeneralModel.Delete)
                        _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.Remove(getData);
                    save += _context.SaveChanges();
                }
                else if (picture_upload_model != null)
                {
                    PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT getData;
                    getData = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year && c.Id == picture_upload_model.Id select c).FirstOrDefaultAsync();

                    picture_upload_model.Companyemail = WKPCompanyEmail;
                    picture_upload_model.CompanyName = WKPCompanyName;
                    picture_upload_model.COMPANY_ID = WKPCompanyId;
                    picture_upload_model.CompanyNumber = WKPCompanyNumber;
                    picture_upload_model.Date_Updated = DateTime.Now;
                    picture_upload_model.Updated_by = WKPCompanyId;
                    picture_upload_model.Year_of_WP = year;
                    //picture_upload_model.OML_Name = omlName;
                    //picture_upload_model.Field_ID = concessionField?.Field_ID ?? null;

                    #region file section
                    var file1 = Request.Form.Files.Count > 0 && Request.Form.Files[0] != null ? Request.Form.Files[0] : null;
                    var blobname1 = file1 != null ? blobService.Filenamer(file1) : null;

                    if (file1 != null)
                    {
                        string docName = "Uploaded Presentation";
                        picture_upload_model.uploaded_presentation = await blobService.UploadFileBlobAsync("documents", file1.OpenReadStream(), file1.ContentType, $"Presentations/{blobname1}", docName.ToUpper(), (int)WKPCompanyNumber, int.Parse(year));
                        if (picture_upload_model.uploaded_presentation == null)
                            return BadRequest(new { message = "Failure : An error occured while trying to upload " + docName + " document." });
                    }
                    else
                    {
                        picture_upload_model.uploaded_presentation = null;
                    }
                    #endregion

                    if (action == GeneralModel.Insert)
                    {
                        if (getData == null)
                        {
                            picture_upload_model.Date_Created = DateTime.Now;
                            picture_upload_model.Created_by = WKPCompanyId;
                            await _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.AddAsync(picture_upload_model);
                        }
                        else
                        {
                            picture_upload_model.Date_Created = getData.Date_Created;
                            picture_upload_model.Created_by = getData.Created_by;
                            picture_upload_model.Date_Updated = DateTime.Now;
                            picture_upload_model.Updated_by = WKPCompanyId;
                            _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.Remove(getData);
                            await _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.AddAsync(picture_upload_model);
                        }
                    }
                    else if (action == GeneralModel.Delete)
                    {
                        _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.Remove(getData);
                    }

                    save += await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = $"Error : No data was passed for {actionToDo} process to be completed." });
                }
                if (save > 0)
                {
                    string successMsg = Messager.ShowMessage(Id > 0 && action != GeneralModel.Delete ? GeneralModel.Update : action);
                    //var All_Data = await (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs where c.OML_Name == omlName && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year select c).ToListAsync();
                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    return BadRequest(new { message = "Error : An error occured while trying to submit this form." });

                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpGet("PRESENTATION SCHEDULES")]
        public async Task<object> PRESENTATION_SCHEDULES(string year)
        {
            try
            {
                var schedules = (from sch in _context.ADMIN_DATETIME_PRESENTATIONs select sch).ToList();
                var viewYears = schedules.Select(x => x.YEAR).Distinct().ToList();

                if (year != null)
                {
                    schedules = schedules.Where(x => x.YEAR == year).ToList();
                }
                var presentationSchedules = new PresentationSchedules_Model()
                {
                    presentationSchedules = schedules,
                    Years = viewYears
                };

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = presentationSchedules, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });

            }
        }

        [HttpGet("DIVISIONAL_PRESENTATIONS")]
        public async Task<object> DIVISIONAL_PRESENTATIONS(string year)
        {
            try
            {
                var presentations = (from sch in _context.ADMIN_DIVISIONAL_REPS_PRESENTATIONs select sch).ToList();
                var viewYears = presentations.Select(x => x.YEAR).Distinct().ToList();

                if (year != null)
                {
                    presentations = presentations.Where(x => x.YEAR == year).ToList();
                }
                var presentationDivision = new PresentationSchedules_Model()
                {
                    Divisionpresentations = presentations,
                    Years = viewYears
                };

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = presentationDivision, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });

            }
        }

        #region work program admin     
        [HttpGet("OPL_RECALIBRATED_SCALED")]
        public async Task<object> opl_recalibrated(string year)
        {
            var details = new List<WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANy>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {

                    details = await _context.WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANIEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    details = await _context.WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANIEs.Where(c => c.CompanyName.Trim().ToUpper() == WKPCompanyName.Trim().ToUpper() && c.Year_of_WP == year).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Error : " + ex.Message });
            }

            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };

        }
        [HttpGet("OPL_AGGREGATED_SCORE")]
        public async Task<object> opl_aggregated_score(string year)
        {
            var presentYear = DateTime.Now.Year;

            var details = new List<WP_OPL_Aggregated_Score_ALL_COMPANy>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    details = await _context.WP_OPL_Aggregated_Score_ALL_COMPANIEs.Where(c => c.Year_of_WP == year).ToListAsync();

                }
                else
                {
                    details = await _context.WP_OPL_Aggregated_Score_ALL_COMPANIEs.Where(c => c.CompanyName.Trim().ToUpper() == WKPCompanyName.Trim().ToUpper() && c.Year_of_WP == year).ToListAsync();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Error : " + ex.Message });
            }

            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };

        }
        [HttpGet("OML_RECALIBRATED_SCALED")]
        public async Task<object> OML_RECALIBRATED_SCALE(string year)
        {
            var details = new List<WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANy>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    //details = await _context.WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANIEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    // details = await _context.WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANIEs.Where(c => c.CompanyName.Trim().ToUpper() == WKPCompanyName.Trim().ToUpper() && c.Year_of_WP == year).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Error : " + ex.Message, StatusCode = ResponseCodes.Success });
            }

            return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };

        }
        //[HttpGet("OML_AGGREGATED_SCORE")]
        //public async Task<object> oml_aggregated_score(string year)
        //{
        //    var presentYear = DateTime.Now.Year;

        //    var details = new List<WP_OML_Aggregated_Score_ALL_COMPANy>();
        //    try
        //    {
        //        if (WKUserRole == GeneralModel.Admin)
        //        {
        //            details = await _context.WP_OML_Aggregated_Score_ALL_COMPANIEs.Where(c => c.Year_of_WP == year).ToListAsync();

        //        }
        //        else
        //        {
        //            details = await _context.WP_OML_Aggregated_Score_ALL_COMPANIEs.Where(c => c.CompanyName.Trim().ToUpper() == WKPCompanyName.Trim().ToUpper() && c.Year_of_WP == year).ToListAsync();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(new { message = "Error : " + ex.Message, StatusCode = ResponseCodes.Success };
        //    }

        //    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = details, StatusCode = ResponseCodes.Success };

        //}

        [HttpGet("GET_CONCESSION_HELD")]
        public async Task<object> Get_Concession_Held(string mycompanyId, string myyear)
        {
            try
            {
                var listObject = new List<object>();
                var concessions = await (from a in _context.ADMIN_CONCESSIONS_INFORMATIONs where a.Company_ID == WKPCompanyId && a.DELETED_STATUS == null select a).Distinct().ToListAsync();
                foreach (var concession in concessions)
                {
                    var concessionFields = await (from d in _context.COMPANY_FIELDs where d.Concession_ID == concession.Consession_Id && d.DeletedStatus != true select d).ToListAsync();
                    bool isEditable = true;
                    if (concessionFields.Count > 0)
                    {
                        foreach (var field in concessionFields)
                        {
                            var checkApplication = await (from ap in _context.Applications
                                                          where ap.YearOfWKP == DateTime.Now.Year && ap.FieldID == field.Field_ID && ap.DeleteStatus != true
                                                          select ap).FirstOrDefaultAsync();
                            isEditable = true;
                            if (checkApplication != null)
                            {
                                var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == checkApplication.Id && x.ActionStatus == GeneralModel.Initiated).FirstOrDefaultAsync();
                                if (NRejectApp == null)
                                    isEditable = false;
                            }

                        }

                        listObject.Add(new
                        {
                            con = concession.Concession_Held,
                            isEditable = isEditable
                        });
                    }
                    else
                    {
                        var checkApplication = await (from ap in _context.Applications
                                                      where ap.YearOfWKP == DateTime.Now.Year && ap.ConcessionID == concession.Consession_Id && ap.DeleteStatus != true
                                                      select ap).FirstOrDefaultAsync();
                        isEditable = true;
                        if (checkApplication != null)
                        {
                            var NRejectApp = await _context.SBU_ApplicationComments.Where(x => x.AppID == checkApplication.Id && x.ActionStatus == GeneralModel.Initiated).FirstOrDefaultAsync();
                            if (NRejectApp == null)
                                isEditable = false;
                        }
                        listObject.Add(new
                        {
                            con = concession.Concession_Held,
                            isEditable = isEditable
                        });
                    }
                }
                return new { listObject };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GET_WPYEAR_LIST")]
        public async Task<object> Get_WPYear_List()
        {
            try
            {
                return await (from a in _context.ADMIN_CONCESSIONS_INFORMATIONs select a.Year).Distinct().ToListAsync();
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        #endregion

    }
}