using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
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
    public class ReportController : ControllerBase
    {
        private Account _account;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ReportController(WKP_DBContext context, IConfiguration configuration, HelpersController helpersController, Account account, IMapper mapper)
        {
            _httpContextAccessor = _httpContextAccessor;
            _account = account;
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

        #region General Report Section
        [HttpGet("GENERAL_WORKPROGRAMME_REPORT")]
        public async Task<WebApiResponse> GENERAL_WORKPROGRAMME(string year)
        {
            try
            {
                WorkProgrammeReport_Model GeneralReport = new WorkProgrammeReport_Model();

                var WorkProgrammeReport = Get_General_SummaryReport(year);
                var WorkProgrammeReport2 = Get_General_Report(year);

                GeneralReport.WorkProgrammeReport1_Model = WorkProgrammeReport;
                GeneralReport.WorkProgrammeReport2_Model = WorkProgrammeReport2;

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = GeneralReport, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GENERAL_SUMMARYREPORT")]
        public async Task<WebApiResponse> GENERAL_SUMMARYREPORT(string year)
        {
            try
            {
                Task<object> WorkProgrammeReport = Get_General_SummaryReport(year);

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = WorkProgrammeReport, StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("GENERAL_REPORT")]
        public async Task<WebApiResponse> GENERAL_REPORT(string year)
        {
            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    var OIL_CONDENSATE_PRODUCTION_BY_MONTH_YEAR = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_years.Where(x => x.Year_of_WP == year).ToListAsync();

                    var OIL_CONDENSATE_PRODUCTION_BY_CONTRACT_TYPE = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs.Where(x => x.Year_of_WP == year).ToListAsync();

                    var OIL_CONDENSATE_PRODUCTION_BY_TERRAIN = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains.Where(x => x.Year_of_WP == year).ToListAsync();


                    var WorkProgrammeReport2 = new
                    {
                        OIL_CONDENSATE_PRODUCTION_BY_MONTH_YEAR = OIL_CONDENSATE_PRODUCTION_BY_MONTH_YEAR,
                        OIL_CONDENSATE_PRODUCTION_BY_CONTRACT_TYPE = OIL_CONDENSATE_PRODUCTION_BY_CONTRACT_TYPE,
                        OIL_CONDENSATE_PRODUCTION_BY_TERRAIN = OIL_CONDENSATE_PRODUCTION_BY_TERRAIN
                    };

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = WorkProgrammeReport2, StatusCode = ResponseCodes.Success };
                }
                else
                {
                    var OIL_CONDENSATE_PRODUCTION_BY_MONTH_YEAR = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_years.ToListAsync();

                    var OIL_CONDENSATE_PRODUCTION_BY_CONTRACT_TYPE = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs.ToListAsync();

                    var OIL_CONDENSATE_PRODUCTION_BY_TERRAIN = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains.ToListAsync();


                    var WorkProgrammeReport2 = new
                    {
                        OIL_CONDENSATE_PRODUCTION_BY_MONTH_YEAR = OIL_CONDENSATE_PRODUCTION_BY_MONTH_YEAR,
                        OIL_CONDENSATE_PRODUCTION_BY_CONTRACT_TYPE = OIL_CONDENSATE_PRODUCTION_BY_CONTRACT_TYPE,
                        OIL_CONDENSATE_PRODUCTION_BY_TERRAIN = OIL_CONDENSATE_PRODUCTION_BY_TERRAIN
                    };

                    return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = WorkProgrammeReport2, StatusCode = ResponseCodes.Success };
                }

            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("Get_General_SummaryReport")]
        public async Task<object> Get_General_SummaryReport(string year)
        {
            try
            {
                string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                var WKP_Report = await _context.ADMIN_WORK_PROGRAM_REPORTs.Where(x => x.Id <= 5).ToListAsync();
                var Seismic_Data_Acquisition_Activities = WKP_Report.Where(x => x.Id == 2).FirstOrDefault();
                if (year != null)
                {
                    var WP_COUNT = await _context.WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORies.Where(x => x.Year == year).ToListAsync();
                    var E_and_P_companies = await _context.WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLies.Where(x => x.YEAR == year).ToListAsync();

                    var WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                                             where o.Year_of_WP == year && o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                                             group o by new
                                                                             {
                                                                                 o.Geo_type_of_data_acquired,
                                                                                 o.Year_of_WP
                                                                             }
                                                                        into g
                                                                             select new WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION
                                                                             {
                                                                                 Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                                                 Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                 Year_of_WP = g.FirstOrDefault().Year_of_WP,

                                                                             }).ToListAsync();


                    var WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING = await _context.WP_GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Where(x => x.Year_of_WP == year && (x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD || x.Geo_Type_of_Data_being_Processed == GeneralModel.TwoD)).ToListAsync();


                    var WP_COUNT_WELLS = await _context.WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && (x.Category == GeneralModel.Exploration || x.Category == GeneralModel.Development)).ToListAsync();

                    var WP_SUM_APPRAISAL_WELLS = await (from o in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs
                                                        where o.Category.Contains(GeneralModel.Appraisal) && o.Year_of_WP == year
                                                        group o by new
                                                        {
                                                            o.Category
                                                        }
                                                    into g
                                                        select new DRILLING_OPERATIONS_CATEGORIES_OF_WELL
                                                        {
                                                            Actual_No_Drilled_in_Current_Year = g.Sum(x => Convert.ToDouble(x.Actual_No_Drilled_in_Current_Year)).ToString(),
                                                            Proposed_No_Drilled = g.Sum(x => Convert.ToDouble(x.Proposed_No_Drilled)).ToString(),
                                                            Year_of_WP = g.FirstOrDefault().Year_of_WP,

                                                        }).ToListAsync();


                    var WP_SUM_WORKOVERS_RECOMPLETION = await _context.WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETIONs.Where(x => x.Year_of_WP_I == year).ToListAsync();

                    var WP_COUNT_Appraisal = await _context.WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category.Contains(GeneralModel.Appraisal)).ToListAsync();

                    var WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oils
                                                                         where u.Year_of_WP == year
                                                                         select u).ToListAsync();

                    var WP_JV_Contract_Type = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Types
                                                     where u.Year_of_WP == previousYear /*&& u.Contract_Type == GeneralModel.JV*/
                                                     select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();

                    var WP_GAS_PRODUCTION_ACTIVITIES_Percentages = await (from u in _context.WP_GAS_PRODUCTION_ACTIVITIES_Percentages
                                                                          where u.Year_of_WP == previousYear
                                                                          select u).ToListAsync();

                    var WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY = await (from u in _context.WP_GAS_PRODUCTION_ACTIVITIES_Percentages
                                                                             where u.Year_of_WP == year
                                                                             select u).ToListAsync();

                    var WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type = await (from u in _context.WP_GAS_PRODUCTION_ACTIVITIES_Contract_Types
                                                                            where u.Year_of_WP == previousYear
                                                                            select u).ToListAsync();



                    var WP_CRUDE_OIL = await (from u in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs
                                              where u.Year_of_WP == previousYear || u.Year_of_WP == year
                                              group u by new { u.Year_of_WP } into g
                                              select new
                                              {
                                                  Year = g.Key,
                                                  Total_Reconciled_National_Crude_Oil_Production = g.Sum(c => Convert.ToInt64(Convert.ToDouble(c.Total_Reconciled_National_Crude_Oil_Production))),
                                              }).ToListAsync();
                    var WP_CRUDE_OIL_PY = WP_CRUDE_OIL.Where(x => x.Year.ToString() == previousYear).ToList();
                    var WP_CRUDE_OIL_CY = WP_CRUDE_OIL.Where(x => x.Year.ToString() == year).ToList();

                    var WP_OIL_PRODUCTION_total_barrel = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs
                                                                where u.Year_of_WP == year
                                                                select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();

                    var WP_Terrain_Continental = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains
                                                        where u.Year_of_WP == year
                                                        select u).GroupBy(x => x.Terrain).Select(x => x.FirstOrDefault()).ToListAsync();

                    #region Gas Production Activities For Previous Year & Current Year

                    var GAS_ACTIVITIES = await (from u in _context.GAS_PRODUCTION_ACTIVITIEs
                                                select u).ToListAsync();

                    var GAS_ACTIVITIES_YEAR = await (from u in _context.GAS_PRODUCTION_ACTIVITIEs
                                                     select u).GroupBy(x => x.Year_of_WP).Select(x => x.FirstOrDefault()).ToListAsync();

                    var WP_GAS_ACTIVITIES = (from g in GAS_ACTIVITIES_YEAR
                                             select new
                                             {
                                                 Actual_Total_Gas_Produced = Convert.ToInt64(g.Current_Actual_Year),
                                                 Utilized_Gas_Produced = double.TryParse(g.Utilized, out double n) ? Convert.ToDouble(g.Utilized) : 0,
                                                 Flared_Gas_Produced = Convert.ToDouble(g.Flared),
                                                 Year_of_WP = g.Year_of_WP,
                                                 CompanyName = g.CompanyName,
                                                 Percentage_Utilized = double.TryParse(g.Utilized, out double m) ? ((Convert.ToDouble(g.Utilized) / Convert.ToDouble(g.Actual_year)) * 100) : 0
                                             }).ToList();

                    var PY_GAS_ACTIVITIES = WP_GAS_ACTIVITIES.Where(x => x.Year_of_WP.ToString() == previousYear).ToList();
                    var CY_GAS_ACTIVITIES = WP_GAS_ACTIVITIES.Where(x => x.Year_of_WP.ToString() == year).ToList();

                    var GAS_ACTIVITIES_CONTRACTTYPES = await (from u in _context.GAS_PRODUCTION_ACTIVITIEs
                                                              select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();


                    #endregion

                    var OIL_CONDENSATE_MMBBL = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs.Where(x => x.Year_of_WP == year).ToListAsync();

                    #region HSE Accident
                    var HSE_ACCIDENT_Consequences = await _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequences.Where(x => x.Year_of_WP == year && x.Consequence == GeneralModel.Fatality).ToListAsync();
                    //string Sum_accident = HSE_ACCIDENT_Consequences.sum_accident.ToString();

                    var HSE_ACCIDENT_Total = await _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accidents.Where(x => x.Year_of_WP == year).ToListAsync();
                    //string Sum_accident_total = HSE_ACCIDENT_Total.Sum_accident.ToString();

                    var HSE_ACCIDENT = await (from u in _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentages
                                              where u.Year_of_WP == year
                                              select new WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentage
                                              {
                                                  Cause = u.Cause,
                                                  sum_accident = u.sum_accident,
                                                  Percentage_Spill = u.Percentage_Spill,
                                              }).GroupBy(x => x.Cause).Select(x => x.FirstOrDefault()).ToListAsync();

                    #endregion
                    // var GEO_ACTIVITIES = await (from u in _context.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_counts
                    //                             where u.Year_of_WP == year
                    //                             select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();

                    var HSE_VOLUME_OF_OILSPILL = await (from o in _context.HSE_OIL_SPILL_REPORTING_NEWs
                                                        where o.Year_of_WP == year
                                                        select o
                                                                 ).SumAsync(x => Convert.ToDouble(x.Volume_of_spill_bbls));

                    var OILSPILL_REPORT = (from o in _context.WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVEREDs
                                           where o.Year_of_WP == year
                                           group o by new
                                           {
                                               o.CompanyName
                                           }
                                                into g
                                           select new
                                           {
                                               Frequency = g.Select(x => x.Frequency),
                                               Highest_1st = g.Min(x => x.Frequency),
                                               Highest_2nd = g.Min(x => x.Frequency),
                                               Highest_3rd = g.Min(x => x.Frequency),
                                               TOTAL_QUANTITY_SPILLED = g.Sum(x => x.Total_Quantity_Spilled),
                                               CompanyName = g.Key,
                                               Year_of_WP = g.FirstOrDefault().Year_of_WP,
                                           }).OrderByDescending(x => x.Frequency);

                    var Produced_water_volumes = (from o in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs
                                                  where o.Year_of_WP == year
                                                  group o by new
                                                  {
                                                      o.Year_of_WP
                                                  }
                                                into g
                                                  select new
                                                  {
                                                      Produced_water_volumes = g.Sum(x => int.Parse(x.Produced_water_volumes)),
                                                      Year_of_WP = g.FirstOrDefault().Year_of_WP,
                                                  });

                    #region GENERAL REPORT DATA POPULATION
                    var get_ReportContent_1 = WKP_Report.Where(x => x.Id == 1)?.FirstOrDefault();
                    var get_ReportContent_2 = WKP_Report.Where(x => x.Id == 2)?.FirstOrDefault();
                    var getGasFlare_ReportContent = WKP_Report.Where(x => x.Id == 5)?.FirstOrDefault();
                    var getOilContigencyPlan_ReportContent = WKP_Report.Where(x => x.Id == 6)?.FirstOrDefault();

                    if (get_ReportContent_1 != null && get_ReportContent_2 != null)
                    {
                        string NO_OF_COMPANY_PRESENTED = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.Presented).Count().ToString();
                        string SHOWED_UP = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.ShowedButNoPresentation).Count().ToString();
                        string FAIL_TO_SHOW_UP = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.FailedToShow).Count().ToString();
                        string NOT_INVITED = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.NotInvited).Count().ToString();


                        get_ReportContent_1.Report_Content = get_ReportContent_1.Report_Content.Replace("(NO_OF_COMPANY_PRESENTED)", NO_OF_COMPANY_PRESENTED)
                            .Replace("(NO_OF_EP_COMPANIES)", E_and_P_companies.Count().ToString())
                            .Replace("(N)", year)
                            .Replace("(N + 1)", (int.Parse(year) + 1).ToString())
                            .Replace("(N - 1)", previousYear)
                            .Replace("(SHOWED_UP)", SHOWED_UP).Replace("(FAIL_TO_SHOW_UP)", SHOWED_UP).Replace("(NOT_INVITED)", NOT_INVITED)
                            .Replace("(ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                            .Replace("(PROCESSED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Processed_Actual.ToString())
                            .Replace("(REPROCESSED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Reprocessed_Actual.ToString())
                            .Replace("(PROPOSED_ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Geo_type_of_data_acquired.ToString())
                            .Replace("(PROPOSED_PROCESS_2D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.TwoD)?.FirstOrDefault()?.Processed_Proposed.ToString())
                            .Replace("(PROPOSED_PROCESS_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Processed_Proposed.ToString())
                            .Replace("(PROPOSED_REPROCESSED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Reprocessed_Proposed.ToString())
                            .Replace("(NO_EXPLORATION_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Exploration)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_EXPLORATION_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Exploration)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_FIRST_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.FirstAppraisal)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_FIRST_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.FirstAppraisal)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_SECOND_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.SecondAppraisal)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_SECOND_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.SecondAppraisal)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_ORDINARY_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.OrdinaryAppraisal)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_ORDINARY_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.OrdinaryAppraisal)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_DEVELOPMENT_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Development)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_DEVELOPMENT_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Development)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_COMPLETION_WORKOVER)", WP_SUM_WORKOVERS_RECOMPLETION.Where(x => x.Year_of_WP_I == year)?.FirstOrDefault()?.Actual_Year.ToString())
                            .Replace("(NO_PROPOSED_COMPLETION_WORKOVER)", WP_SUM_WORKOVERS_RECOMPLETION.Where(x => x.Year_of_WP_I == year)?.FirstOrDefault()?.Proposed_Year.ToString())
                            .Replace("(PREVIOUS_NO_TOTAL_RECONCILED_NATIONAL_CRUDE)", WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_JV)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_PSC)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_SR)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_MF)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_YEAR_TO_DATE)", WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Actual_Total_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Utilized_Gas_Produced.ToString())
                            .Replace("(PERCENTAGE_TOTAL_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Percentage_Utilized.ToString())
                            .Replace("(NO_TOTAL_GAS_FLARED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_JV)", WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_PSC)", WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_MFIO)", WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_YEAR_TO_DATE)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Actual_Total_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_YEAR_TO_DATE_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Utilized_Gas_Produced.ToString())
                            .Replace("(PERCENTAGE_TOTAL_GAS_PRODUCED_YEAR_TO_DATE_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Percentage_Utilized.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_YEAR_TO_DATE_FLARED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_NIGERIA_OIL_RESERVES)", OIL_CONDENSATE_MMBBL?.FirstOrDefault()?.Reserves_as_at_MMbbl.ToString())
                            .Replace("(NO_NIGERIA_OIL_CONDENSATE)", OIL_CONDENSATE_MMBBL?.FirstOrDefault()?.Reserves_as_at_MMbbl_condensate.ToString())
                            .Replace("(NO_NIGERIA_OIL_RESERVE_GAS)", OIL_CONDENSATE_MMBBL?.FirstOrDefault()?.Reserves_as_at_MMbbl_gas.ToString())
                            .Replace("(NO_OF_ACCIDENTS)", HSE_ACCIDENT_Total?.FirstOrDefault()?.Sum_accident.ToString())
                            .Replace("(NO_OF_FATALITIES)", HSE_ACCIDENT_Consequences?.FirstOrDefault()?.sum_accident.ToString())
                            .Replace("(NO_OF_SPILLS)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.Sabotage)?.FirstOrDefault()?.sum_accident.ToString())
                            .Replace("(NO_OF_RELEASE)", HSE_VOLUME_OF_OILSPILL.ToString())
                            .Replace("(PERCENTAGE_OF_SABOTAGE)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.Sabotage)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                            .Replace("(PERCENTAGE_OF_EQUIPMENT_FAILURE)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.EquipmentFailure)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                            .Replace("(PERCENTAGE_OF_HUMAN_ERROR)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.HumanError)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                            .Replace("(PERCENTAGE_OF_MYSTERY_SPILLS)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.MysterySpills)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                        ;

                        // get_ReportContent_2.Report_Content = get_ReportContent_2.Report_Content
                        //     .Replace("(NO_OF_JV)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(NO_OF_JV_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_PSC_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_PSC)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(NO_OF_MF_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_MF)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(NO_OF_INDIGENOUS_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_INDIGENOUS)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(N)", year)
                        //     .Replace("(N + 1)", (int.Parse(year) + 1).ToString())
                        //     .Replace("(N - 1)", previousYear)
                        //     .Replace("(ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     ;

                        getGasFlare_ReportContent.Report_Content = getGasFlare_ReportContent.Report_Content
                             .Replace("(TOTAL_GAS_PRODUCED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Actual_Total_Gas_Produced.ToString())
                             .Replace("(PERCENTAGE_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Percentage_Utilized.ToString())
                             .Replace("(TOTAL_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Utilized_Gas_Produced.ToString())
                             .Replace("(TOTAL_GAS_FLARED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Flared_Gas_Produced.ToString());

                        // var contigencyPlan_Data = new SqlCommand(" select MIN(Frequency) Highest_1st , SUM(Total_Quantity_Spilled) TOTAL_QUANTITY_SPILLED, CompanyName, Year_of_WP from( SELECT TOP 1  CompanyName, Year_of_WP, CAST(Frequency AS int) AS Frequency, Total_Quantity_Spilled   FROM         dbo.WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED  order by Frequency desc) b   WHERE Year_of_WP = '" + DropDownList1.SelectedItem.Text + "'   GROUP BY CompanyName, Year_of_WP ", con);
                        if (getOilContigencyPlan_ReportContent != null)
                        {
                            getOilContigencyPlan_ReportContent.Report_Content = getOilContigencyPlan_ReportContent?.Report_Content
                             .Replace("(NO_OF_OPERATING_COMPANIES)", E_and_P_companies.FirstOrDefault()?.TOTAL_COUNT_YEARLY.ToString())
                             .Replace("(TOTAL_NO_OF_SPILLS)", OILSPILL_REPORT.FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_5)", OILSPILL_REPORT.Take(5).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_5)", OILSPILL_REPORT.Take(5).FirstOrDefault()?.CompanyName.ToString())
                                          .Replace("(NO_OF_HIGHEST_bbls_5)", OILSPILL_REPORT.Take(5).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_4)", OILSPILL_REPORT.Take(4).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_4)", OILSPILL_REPORT.Take(4).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_4)", OILSPILL_REPORT.Take(4).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_3)", OILSPILL_REPORT.Take(3).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_3)", OILSPILL_REPORT.Take(3).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_3)", OILSPILL_REPORT.Take(3).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_2)", OILSPILL_REPORT.Take(2).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_2)", OILSPILL_REPORT.Take(2).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_2)", OILSPILL_REPORT.Take(2).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_1)", OILSPILL_REPORT.Take(1).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_1)", OILSPILL_REPORT.Take(1).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_1)", OILSPILL_REPORT.Take(1).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(TOTAL_PRODUCED_WATER_FORMATION)", Produced_water_volumes.FirstOrDefault()?.ToString());
                        }



                        var summaryReport = new ADMIN_WORK_PROGRAM_REPORTs_Model()
                        {
                            summary_1 = get_ReportContent_1.Report_Content,
                            //summary_2 = get_ReportContent_2.re,
                            GasFlare_ReportContent = getGasFlare_ReportContent.Report_Content,
                            OilContigencyPlan_ReportContent = getGasFlare_ReportContent.Report_Content,
                        };

                        #endregion

                        return summaryReport;
                    }

                    else
                    {
                        return new ADMIN_WORK_PROGRAM_REPORTs_Model();
                    }
                }
                else
                {
                    var WP_COUNT = await _context.WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORies.ToListAsync();
                    var E_and_P_companies = await _context.WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLies.ToListAsync();

                    var WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                                             where o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                                             group o by new
                                                                             {
                                                                                 o.Geo_type_of_data_acquired,
                                                                                 o.Year_of_WP
                                                                             }
                                                                        into g
                                                                             select new WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION
                                                                             {
                                                                                 Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                                                 Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                 Year_of_WP = g.FirstOrDefault().Year_of_WP,

                                                                             }).ToListAsync();


                    var WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING = await _context.WP_GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Where(x =>  (x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD || x.Geo_Type_of_Data_being_Processed == GeneralModel.TwoD)).ToListAsync();

                    var WP_COUNT_WELLS = await _context.WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => (x.Category == GeneralModel.Exploration || x.Category == GeneralModel.Development)).ToListAsync();

                    var WP_SUM_APPRAISAL_WELLS = await (from o in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs
                                                        where o.Category.Contains(GeneralModel.Appraisal) 
                                                        group o by new
                                                        {
                                                            o.Category
                                                        }
                                                    into g
                                                        select new DRILLING_OPERATIONS_CATEGORIES_OF_WELL
                                                        {
                                                            Actual_No_Drilled_in_Current_Year = g.Sum(x => Convert.ToDouble(x.Actual_No_Drilled_in_Current_Year)).ToString(),
                                                            Proposed_No_Drilled = g.Sum(x => Convert.ToDouble(x.Proposed_No_Drilled)).ToString(),
                                                            Year_of_WP = g.FirstOrDefault().Year_of_WP,

                                                        }).ToListAsync();


                    var WP_SUM_WORKOVERS_RECOMPLETION = await _context.WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETIONs.ToListAsync();

                    var WP_COUNT_Appraisal = await _context.WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category.Contains(GeneralModel.Appraisal)).ToListAsync();

                    var WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oils                                                                         
                                                                         select u).ToListAsync();

                    var WP_JV_Contract_Type = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Types
                                                     select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();

                    var WP_GAS_PRODUCTION_ACTIVITIES_Percentages = await (from u in _context.WP_GAS_PRODUCTION_ACTIVITIES_Percentages
                                                                          select u).ToListAsync();

                    var WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY = await (from u in _context.WP_GAS_PRODUCTION_ACTIVITIES_Percentages
                                                                             select u).ToListAsync();

                    var WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type = await (from u in _context.WP_GAS_PRODUCTION_ACTIVITIES_Contract_Types
                                                                            select u).ToListAsync();



                    var WP_CRUDE_OIL = await (from u in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs
                                              group u by new { u.Year_of_WP } into g
                                              select new
                                              {
                                                  Year = g.Key,
                                                  Total_Reconciled_National_Crude_Oil_Production = g.Sum(c => Convert.ToInt64(Convert.ToDouble(c.Total_Reconciled_National_Crude_Oil_Production))),
                                              }).ToListAsync();
                    var WP_CRUDE_OIL_PY = WP_CRUDE_OIL.ToList();
                    var WP_CRUDE_OIL_CY = WP_CRUDE_OIL.ToList();

                    var WP_OIL_PRODUCTION_total_barrel = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs
                                                                select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();

                    var WP_Terrain_Continental = await (from u in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains
                                                        select u).GroupBy(x => x.Terrain).Select(x => x.FirstOrDefault()).ToListAsync();

                    #region Gas Production Activities For Previous Year & Current Year

                    var GAS_ACTIVITIES = await (from u in _context.GAS_PRODUCTION_ACTIVITIEs
                                                select u).ToListAsync();

                    var GAS_ACTIVITIES_YEAR = await (from u in _context.GAS_PRODUCTION_ACTIVITIEs
                                                     select u).GroupBy(x => x.Year_of_WP).Select(x => x.FirstOrDefault()).ToListAsync();

                    var WP_GAS_ACTIVITIES = (from g in GAS_ACTIVITIES_YEAR
                                             select new
                                             {
                                                 Actual_Total_Gas_Produced = Convert.ToInt64(g.Current_Actual_Year),
                                                 Utilized_Gas_Produced = double.TryParse(g.Utilized, out double n) ? Convert.ToDouble(g.Utilized) : 0,
                                                 Flared_Gas_Produced = Convert.ToDouble(g.Flared),
                                                 Year_of_WP = g.Year_of_WP,
                                                 CompanyName = g.CompanyName,
                                                 Percentage_Utilized = double.TryParse(g.Utilized, out double m) ? ((Convert.ToDouble(g.Utilized) / Convert.ToDouble(g.Actual_year)) * 100) : 0
                                             }).ToList();

                    var PY_GAS_ACTIVITIES = WP_GAS_ACTIVITIES.Where(x => x.Year_of_WP.ToString() == previousYear).ToList();
                    var CY_GAS_ACTIVITIES = WP_GAS_ACTIVITIES.Where(x => x.Year_of_WP.ToString() == year).ToList();

                    var GAS_ACTIVITIES_CONTRACTTYPES = await (from u in _context.GAS_PRODUCTION_ACTIVITIEs
                                                              select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();


                    #endregion

                    var OIL_CONDENSATE_MMBBL = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs.ToListAsync();

                    #region HSE Accident
                    var HSE_ACCIDENT_Consequences = await _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequences.Where(x =>  x.Consequence == GeneralModel.Fatality).ToListAsync();
                    //string Sum_accident = HSE_ACCIDENT_Consequences.sum_accident.ToString();

                    var HSE_ACCIDENT_Total = await _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accidents.ToListAsync();
                    //string Sum_accident_total = HSE_ACCIDENT_Total.Sum_accident.ToString();

                    var HSE_ACCIDENT = await (from u in _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentages
                                              select new WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentage
                                              {
                                                  Cause = u.Cause,
                                                  sum_accident = u.sum_accident,
                                                  Percentage_Spill = u.Percentage_Spill,
                                              }).GroupBy(x => x.Cause).Select(x => x.FirstOrDefault()).ToListAsync();

                    #endregion
                    // var GEO_ACTIVITIES = await (from u in _context.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_counts
                    //                             where u.Year_of_WP == year
                    //                             select u).GroupBy(x => x.Contract_Type).Select(x => x.FirstOrDefault()).ToListAsync();

                    var HSE_VOLUME_OF_OILSPILL = await (from o in _context.HSE_OIL_SPILL_REPORTING_NEWs
                                                        select o
                                                                 ).SumAsync(x => Convert.ToDouble(x.Volume_of_spill_bbls));

                    var OILSPILL_REPORT = (from o in _context.WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVEREDs
                                           group o by new
                                           {
                                               o.CompanyName
                                           }
                                                into g
                                           select new
                                           {
                                               Frequency = g.Select(x => x.Frequency),
                                               Highest_1st = g.Min(x => x.Frequency),
                                               Highest_2nd = g.Min(x => x.Frequency),
                                               Highest_3rd = g.Min(x => x.Frequency),
                                               TOTAL_QUANTITY_SPILLED = g.Sum(x => x.Total_Quantity_Spilled),
                                               CompanyName = g.Key,
                                               Year_of_WP = g.FirstOrDefault().Year_of_WP,
                                           }).OrderByDescending(x => x.Frequency);

                    var Produced_water_volumes = (from o in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs
                                                  group o by new
                                                  {
                                                      o.Year_of_WP
                                                  }
                                                into g
                                                  select new
                                                  {
                                                      Produced_water_volumes = g.Sum(x => int.Parse(x.Produced_water_volumes)),
                                                      Year_of_WP = g.FirstOrDefault().Year_of_WP,
                                                  });

                    #region GENERAL REPORT DATA POPULATION
                    var get_ReportContent_1 = WKP_Report.Where(x => x.Id == 1)?.FirstOrDefault();
                    var get_ReportContent_2 = WKP_Report.Where(x => x.Id == 2)?.FirstOrDefault();
                    var getGasFlare_ReportContent = WKP_Report.Where(x => x.Id == 5)?.FirstOrDefault();
                    var getOilContigencyPlan_ReportContent = WKP_Report.Where(x => x.Id == 6)?.FirstOrDefault();

                    if (get_ReportContent_1 != null && get_ReportContent_2 != null)
                    {
                        string NO_OF_COMPANY_PRESENTED = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.Presented).Count().ToString();
                        string SHOWED_UP = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.ShowedButNoPresentation).Count().ToString();
                        string FAIL_TO_SHOW_UP = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.FailedToShow).Count().ToString();
                        string NOT_INVITED = WP_COUNT.Where(x => x.PRESENTED == GeneralModel.NotInvited).Count().ToString();


                        get_ReportContent_1.Report_Content = get_ReportContent_1.Report_Content.Replace("(NO_OF_COMPANY_PRESENTED)", NO_OF_COMPANY_PRESENTED)
                            .Replace("(NO_OF_EP_COMPANIES)", E_and_P_companies.Count().ToString())
                            .Replace("(N)", year)
                            .Replace("(N + 1)", (int.Parse(year) + 1).ToString())
                            .Replace("(N - 1)", previousYear)
                            .Replace("(SHOWED_UP)", SHOWED_UP).Replace("(FAIL_TO_SHOW_UP)", SHOWED_UP).Replace("(NOT_INVITED)", NOT_INVITED)
                            .Replace("(ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                            .Replace("(PROCESSED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Processed_Actual.ToString())
                            .Replace("(REPROCESSED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Reprocessed_Actual.ToString())
                            .Replace("(PROPOSED_ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Geo_type_of_data_acquired.ToString())
                            .Replace("(PROPOSED_PROCESS_2D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.TwoD)?.FirstOrDefault()?.Processed_Proposed.ToString())
                            .Replace("(PROPOSED_PROCESS_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Processed_Proposed.ToString())
                            .Replace("(PROPOSED_REPROCESSED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_PROCESSING.Where(x => x.Geo_Type_of_Data_being_Processed == GeneralModel.ThreeD)?.FirstOrDefault()?.Reprocessed_Proposed.ToString())
                            .Replace("(NO_EXPLORATION_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Exploration)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_EXPLORATION_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Exploration)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_FIRST_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.FirstAppraisal)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_FIRST_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.FirstAppraisal)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_SECOND_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.SecondAppraisal)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_SECOND_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.SecondAppraisal)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_ORDINARY_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.OrdinaryAppraisal)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_ORDINARY_APPRAISALS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.OrdinaryAppraisal)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_DEVELOPMENT_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Development)?.FirstOrDefault()?.Actual_No_Drilled_in_Current_Year.ToString())
                            .Replace("(NO_PROPOSED_DEVELOPMENT_WELLS)", WP_COUNT_WELLS.Where(x => x.Category == GeneralModel.Development)?.FirstOrDefault()?.Proposed_No_Drilled.ToString())
                            .Replace("(NO_COMPLETION_WORKOVER)", WP_SUM_WORKOVERS_RECOMPLETION.Where(x => x.Year_of_WP_I == year)?.FirstOrDefault()?.Actual_Year.ToString())
                            .Replace("(NO_PROPOSED_COMPLETION_WORKOVER)", WP_SUM_WORKOVERS_RECOMPLETION.Where(x => x.Year_of_WP_I == year)?.FirstOrDefault()?.Proposed_Year.ToString())
                            .Replace("(PREVIOUS_NO_TOTAL_RECONCILED_NATIONAL_CRUDE)", WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_JV)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_PSC)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_SR)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_MF)", WP_JV_Contract_Type.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_RECONCILED_NATIONAL_CRUDE_YEAR_TO_DATE)", WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES?.FirstOrDefault()?.Total_Reconciled_National_Crude_Oil_Production.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Actual_Total_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Utilized_Gas_Produced.ToString())
                            .Replace("(PERCENTAGE_TOTAL_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Percentage_Utilized.ToString())
                            .Replace("(NO_TOTAL_GAS_FLARED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_JV)", WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_PSC)", WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_MFIO)", WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_YEAR_TO_DATE)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Actual_Total_Gas_Produced.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_YEAR_TO_DATE_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Utilized_Gas_Produced.ToString())
                            .Replace("(PERCENTAGE_TOTAL_GAS_PRODUCED_YEAR_TO_DATE_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Percentage_Utilized.ToString())
                            .Replace("(NO_TOTAL_GAS_PRODUCED_YEAR_TO_DATE_FLARED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY?.FirstOrDefault()?.Flared_Gas_Produced.ToString())
                            .Replace("(NO_NIGERIA_OIL_RESERVES)", OIL_CONDENSATE_MMBBL?.FirstOrDefault()?.Reserves_as_at_MMbbl.ToString())
                            .Replace("(NO_NIGERIA_OIL_CONDENSATE)", OIL_CONDENSATE_MMBBL?.FirstOrDefault()?.Reserves_as_at_MMbbl_condensate.ToString())
                            .Replace("(NO_NIGERIA_OIL_RESERVE_GAS)", OIL_CONDENSATE_MMBBL?.FirstOrDefault()?.Reserves_as_at_MMbbl_gas.ToString())
                            .Replace("(NO_OF_ACCIDENTS)", HSE_ACCIDENT_Total?.FirstOrDefault()?.Sum_accident.ToString())
                            .Replace("(NO_OF_FATALITIES)", HSE_ACCIDENT_Consequences?.FirstOrDefault()?.sum_accident.ToString())
                            .Replace("(NO_OF_SPILLS)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.Sabotage)?.FirstOrDefault()?.sum_accident.ToString())
                            .Replace("(NO_OF_RELEASE)", HSE_VOLUME_OF_OILSPILL.ToString())
                            .Replace("(PERCENTAGE_OF_SABOTAGE)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.Sabotage)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                            .Replace("(PERCENTAGE_OF_EQUIPMENT_FAILURE)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.EquipmentFailure)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                            .Replace("(PERCENTAGE_OF_HUMAN_ERROR)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.HumanError)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                            .Replace("(PERCENTAGE_OF_MYSTERY_SPILLS)", HSE_ACCIDENT.Where(x => x.Cause == GeneralModel.MysterySpills)?.FirstOrDefault()?.Percentage_Spill.ToString() ?? "0")
                        ;

                        // get_ReportContent_2.Report_Content = get_ReportContent_2.Report_Content
                        //     .Replace("(NO_OF_JV)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(NO_OF_JV_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_PSC_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_PSC)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(NO_OF_MF_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_MF)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(NO_OF_INDIGENOUS_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                        //     .Replace("(NO_OF_INDIGENOUS)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     .Replace("(N)", year)
                        //     .Replace("(N + 1)", (int.Parse(year) + 1).ToString())
                        //     .Replace("(N - 1)", previousYear)
                        //     .Replace("(ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                        //     ;

                        getGasFlare_ReportContent.Report_Content = getGasFlare_ReportContent.Report_Content
                             .Replace("(TOTAL_GAS_PRODUCED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Actual_Total_Gas_Produced.ToString())
                             .Replace("(PERCENTAGE_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Percentage_Utilized.ToString())
                             .Replace("(TOTAL_GAS_UTILIZED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Utilized_Gas_Produced.ToString())
                             .Replace("(TOTAL_GAS_FLARED)", WP_GAS_PRODUCTION_ACTIVITIES_Percentages_CY.FirstOrDefault()?.Flared_Gas_Produced.ToString());

                        // var contigencyPlan_Data = new SqlCommand(" select MIN(Frequency) Highest_1st , SUM(Total_Quantity_Spilled) TOTAL_QUANTITY_SPILLED, CompanyName, Year_of_WP from( SELECT TOP 1  CompanyName, Year_of_WP, CAST(Frequency AS int) AS Frequency, Total_Quantity_Spilled   FROM         dbo.WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED  order by Frequency desc) b   WHERE Year_of_WP = '" + DropDownList1.SelectedItem.Text + "'   GROUP BY CompanyName, Year_of_WP ", con);
                        if (getOilContigencyPlan_ReportContent != null)
                        {
                            getOilContigencyPlan_ReportContent.Report_Content = getOilContigencyPlan_ReportContent?.Report_Content
                             .Replace("(NO_OF_OPERATING_COMPANIES)", E_and_P_companies.FirstOrDefault()?.TOTAL_COUNT_YEARLY.ToString())
                             .Replace("(TOTAL_NO_OF_SPILLS)", OILSPILL_REPORT.FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_5)", OILSPILL_REPORT.Take(5).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_5)", OILSPILL_REPORT.Take(5).FirstOrDefault()?.CompanyName.ToString())
                                          .Replace("(NO_OF_HIGHEST_bbls_5)", OILSPILL_REPORT.Take(5).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_4)", OILSPILL_REPORT.Take(4).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_4)", OILSPILL_REPORT.Take(4).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_4)", OILSPILL_REPORT.Take(4).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_3)", OILSPILL_REPORT.Take(3).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_3)", OILSPILL_REPORT.Take(3).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_3)", OILSPILL_REPORT.Take(3).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_2)", OILSPILL_REPORT.Take(2).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_2)", OILSPILL_REPORT.Take(2).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_2)", OILSPILL_REPORT.Take(2).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(NO_OF_HIGHEST_INCIDENCE_1)", OILSPILL_REPORT.Take(1).FirstOrDefault()?.Highest_1st.ToString())
                             .Replace("(NAME_OF_HIGHEST_COMPANY_1)", OILSPILL_REPORT.Take(1).FirstOrDefault()?.CompanyName.ToString())
                                                          .Replace("(NO_OF_HIGHEST_bbls_1)", OILSPILL_REPORT.Take(1).FirstOrDefault()?.TOTAL_QUANTITY_SPILLED.ToString())
                             .Replace("(TOTAL_PRODUCED_WATER_FORMATION)", Produced_water_volumes.FirstOrDefault()?.ToString());
                        }
                        var summaryReport = new ADMIN_WORK_PROGRAM_REPORTs_Model()
                        {
                            summary_1 = get_ReportContent_1.Report_Content,
                            //summary_2 = get_ReportContent_2.re,
                            GasFlare_ReportContent = getGasFlare_ReportContent.Report_Content,
                            OilContigencyPlan_ReportContent = getGasFlare_ReportContent.Report_Content,
                        };
                        #endregion
                        return summaryReport;
                    }
                    else
                    {
                        return new ADMIN_WORK_PROGRAM_REPORTs_Model();
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error : " + e.Message });
            }
        }

        [HttpGet("GET_SEISMIC_DATA_REPORT")]
        public async Task<object> GET_SEISMIC_DATA_REPORT(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                    string twoYearsAgo = year != null ? (int.Parse(year) - 1).ToString() : "";
                    string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                    WKP_Report2.Seismic_Data_Approved_and_Acquired = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == year && x.Geo_type_of_data_acquired == GeneralModel.ThreeD).ToListAsync();

                    WKP_Report2.Seismic_Data_Approved_and_Acquired_PLANNED = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                                                    where o.Year_of_WP == year && o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                                                    group o by new { o.Year_of_WP } into g
                                                                                    select new
                                                                                    {
                                                                                        Year_of_WP = g.Key,
                                                                                        CompanyName = g.FirstOrDefault().CompanyName,
                                                                                        OML_Name = g.FirstOrDefault().OML_Name,
                                                                                        Terrain = g.FirstOrDefault().Terrain,
                                                                                        Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                        Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                                                        Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                        Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                        Quantum_Planned = g.Sum(x => Convert.ToDouble(x.Quantum_Planned))
                                                                                    }).ToListAsync();


                    WKP_Report2.Seismic_Data_Approved_and_Acquired_PREVIOUS = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == previousYear).ToListAsync();

                    WKP_Report2.Seismic_Data_Approved_and_Acquired_TWO_YEARS_AG0 = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == twoYearsAgo).ToListAsync();

                    var text3data = await (from a in _context.WP_GEOPHYSICAL_ACTIVITIES_PROCESSINGs where a.Year_of_WP == year && a.Geo_Type_of_Data_being_Processed == "3D" select a).FirstOrDefaultAsync();
                    var text3 = await (from a in _context.ADMIN_WORK_PROGRAM_REPORTs where a.Id == 3 select a.Report_Content).FirstOrDefaultAsync();
                    var text3Modified = text3?.Replace("(N)", year).Replace("(NO_OF_PROCESSED)", text3data?.Processed_Actual.ToString()).Replace("(NO_OF_REPROCESSED)", text3data?.Reprocessed_Actual.ToString() + " ");
                    WKP_Report2.GEOPHYSICAL_ACTIVITIES_PROCESSING_DESCRIPTION = text3Modified;
                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                     where o.Year_of_WP == year
                                                                                                     group o by new { o.CompanyName, o.OML_Name, o.Terrain, o.Name_of_Contractor } into g
                                                                                                     select new
                                                                                                     {
                                                                                                         Year_of_WP = g.Key,
                                                                                                         CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                         OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                         Terrain = g.FirstOrDefault().Terrain,
                                                                                                         Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                         Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                         Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                         Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data))

                                                                                                     }).ToListAsync();

                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT_PLANNED = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                             where o.Year_of_WP == proposedYear
                                                                                                             group o by new { o.CompanyName } into g
                                                                                                             select new
                                                                                                             {
                                                                                                                 Year_of_WP = g.Key,
                                                                                                                 CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                                 OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                                 Terrain = g.FirstOrDefault().Terrain,
                                                                                                                 Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                                 Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                                 Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                                 Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data))

                                                                                                             }).ToListAsync();

                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_PREVIOUS = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                      where o.Year_of_WP == previousYear
                                                                                                      group o by new { o.CompanyName, o.OML_Name, o.Terrain, o.Name_of_Contractor } into g
                                                                                                      select new
                                                                                                      {
                                                                                                          Year_of_WP = g.Key,
                                                                                                          CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                          OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                          Terrain = g.FirstOrDefault().Terrain,
                                                                                                          Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                          Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                          Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                          Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data))

                                                                                                      }).ToListAsync();


                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_TWO_YEARS_AGO = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                           where o.Year_of_WP == twoYearsAgo
                                                                                                           group o by new { o.CompanyName } into g
                                                                                                           select new
                                                                                                           {
                                                                                                               Year_of_WP = g.Key,
                                                                                                               CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                               OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                               Terrain = g.FirstOrDefault().Terrain,
                                                                                                               Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                               Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                               Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                               Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                           }).ToListAsync();
                }
                else
                {
                    WKP_Report2.Seismic_Data_Approved_and_Acquired = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == year && x.Geo_type_of_data_acquired == GeneralModel.ThreeD).ToListAsync();

                    WKP_Report2.Seismic_Data_Approved_and_Acquired_PLANNED = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                where o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                group o by new { o.Year_of_WP } into g
                                select new
                                {
                                    Year_of_WP = g.Key,
                                    CompanyName = g.FirstOrDefault().CompanyName,
                                    OML_Name = g.FirstOrDefault().OML_Name,
                                    Terrain = g.FirstOrDefault().Terrain,
                                    Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                    Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                    Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                    Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                    Quantum_Planned = g.Sum(x => Convert.ToDouble(x.Quantum_Planned))
                                }).ToListAsync();


                    WKP_Report2.Seismic_Data_Approved_and_Acquired_PREVIOUS = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.ToListAsync();

                    WKP_Report2.Seismic_Data_Approved_and_Acquired_TWO_YEARS_AG0 = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.ToListAsync();

                    var text3data = await (from a in _context.WP_GEOPHYSICAL_ACTIVITIES_PROCESSINGs where  a.Geo_Type_of_Data_being_Processed == "3D" select a).FirstOrDefaultAsync();
                    var text3 = await (from a in _context.ADMIN_WORK_PROGRAM_REPORTs where a.Id == 3 select a.Report_Content).FirstOrDefaultAsync();
                    var text3Modified = text3?.Replace("(N)", year).Replace("(NO_OF_PROCESSED)", text3data?.Processed_Actual.ToString()).Replace("(NO_OF_REPROCESSED)", text3data?.Reprocessed_Actual.ToString() + " ");
                    WKP_Report2.GEOPHYSICAL_ACTIVITIES_PROCESSING_DESCRIPTION = text3Modified;
                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs 
                        group o by new { o.CompanyName, o.OML_Name, o.Terrain, o.Name_of_Contractor } into g
                        select new
                        {
                            Year_of_WP = g.Key,
                            CompanyName = g.FirstOrDefault().CompanyName,
                            OML_Name = g.FirstOrDefault().OML_Name,
                            Terrain = g.FirstOrDefault().Terrain,
                            Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                            Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                            Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                            Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data))

                        }).ToListAsync();

                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT_PLANNED = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                        group o by new { o.CompanyName } into g
                        select new
                        {
                            Year_of_WP = g.Key,
                            CompanyName = g.FirstOrDefault().CompanyName,
                            OML_Name = g.FirstOrDefault().OML_Name,
                            Terrain = g.FirstOrDefault().Terrain,
                            Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                            Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                            Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                            Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data))

                        }).ToListAsync();

                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_PREVIOUS = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs                         
                        group o by new { o.CompanyName, o.OML_Name, o.Terrain, o.Name_of_Contractor } into g
                        select new
                        {
                            Year_of_WP = g.Key,
                            CompanyName = g.FirstOrDefault().CompanyName,
                            OML_Name = g.FirstOrDefault().OML_Name,
                            Terrain = g.FirstOrDefault().Terrain,
                            Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                            Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                            Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                            Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data))

                        }).ToListAsync();


                    WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_TWO_YEARS_AGO = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                        group o by new { o.CompanyName } into g
                        select new
                        {
                            Year_of_WP = g.Key,
                            CompanyName = g.FirstOrDefault().CompanyName,
                            OML_Name = g.FirstOrDefault().OML_Name,
                            Terrain = g.FirstOrDefault().Terrain,
                            Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                            Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                            Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                            Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                        }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

            return WKP_Report2;
        }


        [HttpGet("GET_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_REPORT")]
        public async Task<object> GET_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_REPORT(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                    string twoYearsAgo = year != null ? (int.Parse(year) - 1).ToString() : "";
                    string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Exploration).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development = await _context.WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Development).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration_PY = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == proposedYear && x.Category == GeneralModel.Exploration).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal_PY = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == proposedYear && x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development_PY = await _context.WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == proposedYear && x.Category == GeneralModel.Development).ToListAsync();
                }
                else
                {

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category == GeneralModel.Exploration).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development = await _context.WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category == GeneralModel.Development).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration_PY = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category == GeneralModel.Exploration).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal_PY = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();

                    WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development_PY = await _context.WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Category == GeneralModel.Development).ToListAsync();
                }

            }

            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

            return WKP_Report2;
        }
        [HttpGet("GET_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS")]
        public async Task<object> GET_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    WKP_Report2.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS_PY = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x => x.Year_of_WP == year && x.Actual_Proposed == "Actual Year").ToListAsync();
                }
                else
                {
                    WKP_Report2.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.ToListAsync();

                    WKP_Report2.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS_PY = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x => x.Actual_Proposed == "Actual Year").ToListAsync();
                }

            }

            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

            return WKP_Report2;
        }
        [HttpGet("GET_NIGERIA_CONTENT")]
        public async Task<object> GET_NIGERIA_CONTENT(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();
            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    WKP_Report2.NIGERIA_CONTENT_TRAINING_PY = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Year_of_WP == year && x.Actual_Proposed == "Proposed Year").ToListAsync();

                    WKP_Report2.NIGERIA_CONTENT_TRAINING = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.NIGERIA_CONTENT_UPLOAD_SUCESSION_PLAN = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.Where(x => x.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    WKP_Report2.NIGERIA_CONTENT_TRAINING_PY = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Actual_Proposed == "Proposed Year").ToListAsync();

                    WKP_Report2.NIGERIA_CONTENT_TRAINING = await _context.NIGERIA_CONTENT_Trainings.ToListAsync();

                    WKP_Report2.NIGERIA_CONTENT_UPLOAD_SUCESSION_PLAN = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.ToListAsync();
                }
            }

            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message);
            }
            return WKP_Report2;
        }

        [HttpGet("GET_OIL_GAS_CONDENSATE_PRODUCTION_ACTIVITIES")]
        public async Task<object> GET_OIL_GAS_CONDENSATE_PRODUCTION_ACTIVITIES(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                    string twoYearsAgo = year != null ? (int.Parse(year) - 1).ToString() : "";
                    string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_NEW_TECHNOLOGY_CONFORMITY_ASSESSMENT = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_OPERATING_FACILITIES = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNEDs.Where(x => x.Fiveyear_Projection_Year == proposedYear).ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_C_TYPE_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    //error WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_PRODUCTION_BRKDWN_PLANNED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    WKP_Report2.GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();
                }
                else
                {
                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_NEW_TECHNOLOGY_CONFORMITY_ASSESSMENT = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_OPERATING_FACILITIES = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities.ToListAsync();

                    WKP_Report2.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNEDs.ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSEDs.ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_C_TYPE_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSEDs.ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSEDs.ToListAsync();

                    //error WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_PRODUCTION_BRKDWN_PLANNED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNEDs.ToListAsync();

                    //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                    WKP_Report2.GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNEDs.ToListAsync();
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message);
            }
            return WKP_Report2;
        }

        [HttpGet("GET_BUDGET")]
        public async Task<object> GET_BUDGET(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();
            try
            {
                if (!string.IsNullOrEmpty(year))
                {
                    WKP_Report2.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES = await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES = await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT = await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.BUDGET_PERFORMANCE_PRODUCTION_COST = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Where(x => x.Year_of_WP == year).ToListAsync();

                    WKP_Report2.STRATEGIC_PLANS_ON_COMPANY_BASIS = await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.Where(x => x.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    WKP_Report2.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES = await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.ToListAsync();

                    WKP_Report2.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES = await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.ToListAsync();

                    WKP_Report2.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT = await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.ToListAsync();

                    WKP_Report2.BUDGET_PERFORMANCE_PRODUCTION_COST = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.ToListAsync();

                    WKP_Report2.STRATEGIC_PLANS_ON_COMPANY_BASIS = await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.ToListAsync();
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message);
            }
            return WKP_Report2;
        }

        [HttpGet("GET_HSE")]
        public async Task<object> GET_HSE(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";


                WKP_Report2.FATALITIES_ACCIDENT_STATISTIC_TABLE = await _context.WP_HSE_FATALITIES_accident_statistic_tables.Where(x => x.Year_of_WP == year && x.Fatalities_Type == GeneralModel.Fatality).ToListAsync();

                WKP_Report2.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.HSE_CAUSES_OF_SPILL = await _context.HSE_CAUSES_OF_SPILLs.Where(x => x.Year_of_WP == year).ToListAsync();

            }

            catch (Exception e)
            {

                return "Error : " + e.Message;

            }

            return WKP_Report2;
        }

        [HttpGet("GET_RESERVES")]
        public async Task<object> GET_RESERVES(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";


                WKP_Report2.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNEDs.Where(x => x.Fiveyear_Projection_Year == proposedYear).ToListAsync();

                //error WKP_Report2.RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTED = await _context.WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTEDs.ToListAsync();
            }

            catch (Exception e)
            {

                return "Error : " + e.Message;

            }

            return WKP_Report2;
        }


        [HttpGet("Get_General_Report")]
        public async Task<object> Get_General_Report(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                string twoYearsAgo = year != null ? (int.Parse(year) - 1).ToString() : "";
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                WKP_Report2.Seismic_Data_Approved_and_Acquired = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == year && x.Geo_type_of_data_acquired == GeneralModel.ThreeD).ToListAsync();

                WKP_Report2.Seismic_Data_Approved_and_Acquired_PLANNED = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                                                where o.Year_of_WP == year && o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                                                group o by new { o.Year_of_WP } into g
                                                                                select new
                                                                                {
                                                                                    Year_of_WP = g.Key,
                                                                                    CompanyName = g.FirstOrDefault().CompanyName,
                                                                                    OML_Name = g.FirstOrDefault().OML_Name,
                                                                                    Terrain = g.FirstOrDefault().Terrain,
                                                                                    Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                    Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                                                    Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                    Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                    Quantum_Planned = g.Sum(x => Convert.ToDouble(x.Quantum_Planned)),

                                                                                }).ToListAsync();


                WKP_Report2.Seismic_Data_Approved_and_Acquired_PREVIOUS = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == previousYear).ToListAsync();

                WKP_Report2.Seismic_Data_Approved_and_Acquired_TWO_YEARS_AG0 = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == twoYearsAgo).ToListAsync();


                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                 where o.Year_of_WP == year
                                                                                                 group o by new { o.CompanyName } into g
                                                                                                 select new
                                                                                                 {
                                                                                                     Year_of_WP = g.Key,
                                                                                                     CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                     OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                     Terrain = g.FirstOrDefault().Terrain,
                                                                                                     Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                     Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                     Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                     Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                 }).ToListAsync();

                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT_PLANNED = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                         where o.Year_of_WP == proposedYear
                                                                                                         group o by new { o.CompanyName } into g
                                                                                                         select new
                                                                                                         {
                                                                                                             Year_of_WP = g.Key,
                                                                                                             CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                             OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                             Terrain = g.FirstOrDefault().Terrain,
                                                                                                             Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                             Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                             Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                             Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                         }).ToListAsync();

                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_PREVIOUS = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                  where o.Year_of_WP == previousYear
                                                                                                  group o by new { o.CompanyName } into g
                                                                                                  select new
                                                                                                  {
                                                                                                      Year_of_WP = g.Key,
                                                                                                      CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                      OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                      Terrain = g.FirstOrDefault().Terrain,
                                                                                                      Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                      Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                      Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                      Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                  }).ToListAsync();


                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_TWO_YEARS_AGO = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                       where o.Year_of_WP == twoYearsAgo
                                                                                                       group o by new { o.CompanyName } into g
                                                                                                       select new
                                                                                                       {
                                                                                                           Year_of_WP = g.Key,
                                                                                                           CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                           OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                           Terrain = g.FirstOrDefault().Terrain,
                                                                                                           Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                           Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                           Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                           Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                       }).ToListAsync();


                WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Exploration).ToListAsync();

                WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();

                WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development = await _context.WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Development).ToListAsync();

                WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration_PY = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == proposedYear && x.Category == GeneralModel.Exploration).ToListAsync();

                WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal_PY = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == proposedYear && x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();

                WKP_Report2.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development_PY = await _context.WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == proposedYear && x.Category == GeneralModel.Development).ToListAsync();

                //err WKP_Report2.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENTs.Where(x => x.Company_Reserves_Year == proposedYear ).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTIONs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_years.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotteds.ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoteds.ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdowns.ToListAsync();

                //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flareds.ToListAsync();

                //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_contract_type_basis = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_bases.ToListAsync();

                //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_terrain_pivotted = await _context.WP_GAS_PRODUCTION_ACTIVITIES_terrain_pivotteds.ToListAsync();

                //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_contract_type_pivoted = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoteds.ToListAsync();

                //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_penalty_payment = await _context.WP_GAS_PRODUCTION_ACTIVITIES_penalty_payments.ToListAsync();

                WKP_Report2.FATALITIES_ACCIDENT_STATISTIC_TABLE = await _context.WP_HSE_FATALITIES_accident_statistic_tables.Where(x => x.Year_of_WP == year && x.Fatalities_Type == GeneralModel.Fatality).ToListAsync();

                //WKP_Report2.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x=>x.Year_of_WP == year && x.Actual_Proposed == "Actual Year").ToListAsync();

                WKP_Report2.NIGERIA_CONTENT_TRAINING_PY = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Year_of_WP == year && x.Actual_Proposed == "Proposed Year").ToListAsync();

                WKP_Report2.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.NIGERIA_CONTENT_TRAINING = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_NEW_TECHNOLOGY_CONFORMITY_ASSESSMENT = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_OPERATING_FACILITIES = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.NIGERIA_CONTENT_UPLOAD_SUCESSION_PLAN = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES = await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES = await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT = await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.BUDGET_PERFORMANCE_PRODUCTION_COST = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Where(x => x.Year_of_WP == year).ToListAsync();

                WKP_Report2.STRATEGIC_PLANS_ON_COMPANY_BASIS = await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.Where(x => x.Year_of_WP == year).ToListAsync();



                //WP_OML_WEIGHTED_SCORE_UNION_ALL_COMPANIES_by_Contract_Type_new
                //WKP_Report2.OML_WEIGHTED_SCORE_UNION_COMPANIES_BY_CONTRACT_TYPE__JV = await _context.WP_OML_WEIGHTED_SCORE_UNION_ALL_COMPANIES_by_Contract_Type_news.Where(x=>x.Year_of_WP == year &&  x.Contract_Type == GeneralModel.JV).ToListAsync().orderbyweightedscore;
                //WKP_Report2.OML_WEIGHTED_SCORE_UNION_COMPANIES_BY_CONTRACT_TYPE__JV = await _context.WP_OML_WEIGHTED_SCORE_UNION_ALL_COMPANIES_by_Contract_Type_news.Where(x=>x.Year_of_WP == year &&  x.Contract_Type == GeneralModel.PSC).ToListAsync();
                //WKP_Report2.OML_WEIGHTED_SCORE_UNION_COMPANIES_BY_CONTRACT_TYPE__JV = await _context.WP_OML_WEIGHTED_SCORE_UNION_ALL_COMPANIES_by_Contract_Type_news.Where(x=>x.Year_of_WP == year &&  x.Contract_Type == GeneralModel.SR).ToListAsync();
                //WKP_Report2.OML_WEIGHTED_SCORE_UNION_COMPANIES_BY_CONTRACT_TYPE__JV = await _context.WP_OML_WEIGHTED_SCORE_UNION_ALL_COMPANIES_by_Contract_Type_news.Where(x=>x.Year_of_WP == year &&  x.Contract_Type == GeneralModel.MF).ToListAsync();

                //err WKP_Report2.OML_Aggregated_Score_ALL_COMPANIES = await _context.WP_OML_Aggregated_Score_ALL_COMPANIEs.Where(x => x.Year_of_WP == year).ToListAsync().OrderByDescending(x => x.OML_Aggregated_Score);

                WKP_Report2.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNEDs.Where(x => x.Fiveyear_Projection_Year == proposedYear).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_C_TYPE_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                //error WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                WKP_Report2.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_PRODUCTION_BRKDWN_PLANNED = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                //error WKP_Report2.GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                WKP_Report2.GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                //error WKP_Report2.RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTED = await _context.WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTEDs.ToListAsync();

                WKP_Report2.HSE_CAUSES_OF_SPILL = await _context.HSE_CAUSES_OF_SPILLs.Where(x => x.Year_of_WP == year).ToListAsync();

            }

            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });

            }

            return WKP_Report2;
        }

        [HttpGet("Get_Summary_Report")]
        public async Task<object> Get_Summary_Report(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                string twoYearsAgo = year != null ? (int.Parse(year) - 1).ToString() : "";
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                WKP_Report2.Seismic_Data_Approved_and_Acquired = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == year && x.Geo_type_of_data_acquired == GeneralModel.ThreeD).ToListAsync();

                WKP_Report2.Seismic_Data_Approved_and_Acquired_PLANNED = (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                                          where o.Year_of_WP == year && o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                                          group o by new { o.Year_of_WP } into g
                                                                          select new
                                                                          {
                                                                              Year_of_WP = g.Key,
                                                                              CompanyName = g.FirstOrDefault().CompanyName,
                                                                              OML_Name = g.FirstOrDefault().OML_Name,
                                                                              Terrain = g.FirstOrDefault().Terrain,
                                                                              Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                              Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                                              Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                              Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                              Quantum_Planned = g.Sum(x => Convert.ToDouble(x.Quantum_Planned)),

                                                                          }).ToListAsync();


                WKP_Report2.Seismic_Data_Approved_and_Acquired_PREVIOUS = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == previousYear).ToListAsync();

                WKP_Report2.Seismic_Data_Approved_and_Acquired_TWO_YEARS_AG0 = await _context.Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(x => x.Year_of_WP == twoYearsAgo).ToListAsync();


                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT = (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                           where o.Year_of_WP == year
                                                                                           group o by new { o.CompanyName } into g
                                                                                           select new
                                                                                           {
                                                                                               Year_of_WP = g.Key,
                                                                                               CompanyName = g.FirstOrDefault().CompanyName,
                                                                                               OML_Name = g.FirstOrDefault().OML_Name,
                                                                                               Terrain = g.FirstOrDefault().Terrain,
                                                                                               Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                               Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                               Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                               Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                           }).ToListAsync();

                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT_PLANNED = (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                   where o.Year_of_WP == proposedYear
                                                                                                   group o by new { o.CompanyName } into g
                                                                                                   select new
                                                                                                   {
                                                                                                       Year_of_WP = g.Key,
                                                                                                       CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                       OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                       Terrain = g.FirstOrDefault().Terrain,
                                                                                                       Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                       Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                       Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                       Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                   }).ToListAsync();

                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_PREVIOUS = (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                            where o.Year_of_WP == previousYear
                                                                                            group o by new { o.CompanyName } into g
                                                                                            select new
                                                                                            {
                                                                                                Year_of_WP = g.Key,
                                                                                                CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                Terrain = g.FirstOrDefault().Terrain,
                                                                                                Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                            }).ToListAsync();


                WKP_Report2.Seismic_Data_Processing_and_Reprocessing_Activities_TWO_YEARS_AGO = (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                                                 where o.Year_of_WP == twoYearsAgo
                                                                                                 group o by new { o.CompanyName } into g
                                                                                                 select new
                                                                                                 {
                                                                                                     Year_of_WP = g.Key,
                                                                                                     CompanyName = g.FirstOrDefault().CompanyName,
                                                                                                     OML_Name = g.FirstOrDefault().OML_Name,
                                                                                                     Terrain = g.FirstOrDefault().Terrain,
                                                                                                     Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                                                     Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                                                     Quantum_Approved = g.Sum(x => Convert.ToDouble(x.Quantum_Approved)),
                                                                                                     Geo_Quantum_of_Data = g.Sum(x => Convert.ToDouble(x.Geo_Quantum_of_Data)),

                                                                                                 }).ToListAsync();


            }

            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });

            }

            return WKP_Report2;
        }
        [HttpGet("Get_Exploration_Report")]
        public async Task<object> Get_Exploration_Report(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                var Exploration_Report = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Exploration).ToListAsync();
                return Exploration_Report;
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }
        }

        [HttpGet("Get_Appraisal_Report")]
        public async Task<object> Get_Appraisal_Report(string year)
        {
            try
            {
                var Appraisal_Report = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category.ToLower().Contains(GeneralModel.Appraisal.ToLower())).ToListAsync();
                return Appraisal_Report;
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }
        }

        [HttpGet("Get_Development_Report")]
        public async Task<object> Get_Development_Report(string year)
        {
            try
            {
                var Development_Report = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category.ToLower().Contains(GeneralModel.Development.ToLower())).ToListAsync();
                return Development_Report;
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }
        }

        [HttpGet("Get_Reserves_Updates_Report")]
        public async Task<object> Get_Reserves_Updates_Report(string year)
        {
            try
            {
                var Reserves_Updates_Report = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENTs.Where(x => x.Company_Reserves_Year == year).ToListAsync();
                return Reserves_Updates_Report;
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }
        }

        [HttpGet("Get_Crude_Oil_Production_Report_Content")]
        public async Task<object> Get_Crude_Oil_Production_Report_Content(string year)
        {
            try
            {
                var data = await (from a in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs where a.Year_of_WP == year select a).ToListAsync();
                var no_of_barrels = Convert.ToDecimal(data.FirstOrDefault()?.Annual_Total_Production_by_year);
                var no_of_jv = Convert.ToDecimal((from a in data where a.Contract_Type == "JVC" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_jv = (from a in data where a.Contract_Type == "JVC" select a.Percentage_Production).FirstOrDefault();
                var no_of_psc = Convert.ToDecimal((from a in data where a.Contract_Type == "PSC" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_psc = (from a in data where a.Contract_Type == "PSC" select a.Percentage_Production).FirstOrDefault();
                var no_of_mf = Convert.ToDecimal((from a in data where a.Contract_Type == "SC" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_mf = (from a in data where a.Contract_Type == "SC" select a.Percentage_Production).FirstOrDefault();
                var no_of_sr = Convert.ToDecimal((from a in data where a.Contract_Type == "SR" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_sr = (from a in data where a.Contract_Type == "SR" select a.Percentage_Production).FirstOrDefault();

                var terrainData = await (from a in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains where a.Year_of_WP == year select a).ToListAsync();

                //var terrainData = await (from a in _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains where a.Year_of_WP == year && a.Terrain == "Onshore" select a).ToListAsync();
                var no_of_onshore = Convert.ToDecimal((from a in terrainData where a.Terrain == "Onshore" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_onshore = (from a in terrainData where a.Terrain == "Onshore" select a.Percentage_Production).FirstOrDefault();
                var no_of_offshore = Convert.ToDecimal((from a in terrainData where a.Terrain == "Continental Shelf" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_offshore = (from a in terrainData where a.Terrain == "Continental Shelf" select a.Percentage_Production).FirstOrDefault();
                var no_of_deepoffshore = Convert.ToDecimal((from a in terrainData where a.Terrain == "Deep Offshore" select a.Annual_Total_Production_by_company).FirstOrDefault());
                var percentage_of_deepoffshore = (from a in terrainData where a.Terrain == "Deep Offshore" select a.Percentage_Production).FirstOrDefault();

                var reportText = await (from a in _context.ADMIN_WORK_PROGRAM_REPORTs where a.Id == 4 select a.Report_Content).FirstOrDefaultAsync();
                reportText = reportText?.Replace("(N)", year).Replace("(NO_OF_BARRELS)", (Math.Round(no_of_barrels, 2)).ToString()).Replace("(NO_OF_JV)", (Math.Round(no_of_jv, 2)).ToString()).Replace("(PERCENTAGE_OF_JV)", (Math.Round(Convert.ToDecimal(percentage_of_jv), 2)).ToString())
                .Replace("(NO_OF_PSC)", (Math.Round(no_of_psc, 2)).ToString()).Replace("(PERCENTAGE_OF_PSC)", (Math.Round(Convert.ToDecimal(percentage_of_psc), 2)).ToString()).Replace("(NO_OF_MF)", (Math.Round(no_of_mf, 2)).ToString())
                .Replace("(PERCENTAGE_OF_MF)", (Math.Round(Convert.ToDecimal(percentage_of_mf), 2)).ToString()).Replace("(NO_OF_SR)", (Math.Round(no_of_sr, 2)).ToString()).Replace("(PERCENTAGE_OF_SR)", (Math.Round(Convert.ToDecimal(percentage_of_sr), 2)).ToString())
                .Replace("(NO_OF_ONSHORE)", (Math.Round(no_of_onshore, 2)).ToString()).Replace("(PERCENTAGE_OF_ONSHORE)", (Math.Round(Convert.ToDecimal(percentage_of_onshore), 2)).ToString())
                .Replace("(NO_OF_OFFSHORE)", (Math.Round(no_of_offshore, 2)).ToString())
                .Replace("(PERCENTAGE_OF_OFFSHORE)", (Math.Round(Convert.ToDecimal(percentage_of_offshore), 2)).ToString()).Replace("(NO_OF_DEEPOFFSHORE)", (Math.Round(no_of_deepoffshore, 2)).ToString())
                .Replace("(PERCENTAGE_OF_DEEPOFFSHORE)", (Math.Round(Convert.ToDecimal(percentage_of_deepoffshore), 2)).ToString());

                return new { text = reportText };
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

        [HttpGet("Get_Crude_Oil_Production_Report")]
        public async Task<object> Get_Crude_Oil_Production_Report(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();

            try
            {
                var Crude_Oil_Production = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTIONs.Where(x => x.Year_of_WP == year).ToListAsync();
                var Crude_Oil_Production_By_Contract_Basis = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTIONs.Where(x => x.Year_of_WP == year).ToListAsync();
                var Crude_Oil_Monthly_Production = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_years.Where(x => x.Year_of_WP == year).ToListAsync();
                var Crude_Oil_Production_By_Terrain = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains.Where(x => x.Year_of_WP == year).ToListAsync();
                var Crude_Oil_Production_By_ContractType_Pivotted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotteds.ToListAsync();
                var Crude_Oil_Production_By_Terrain_Pivotted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoteds.ToListAsync();
                var Crude_Oil_Monthly_Production_Pivotted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdowns.ToListAsync();
                var Crude_Oil_Monthly_Activities_Pivotted_Breakdown = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNEDs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyName).ToListAsync();
                var Company_RRR_Pivotted = await _context.WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTEDs.ToListAsync();
                var Nation_RRR_Pivotted = await _context.WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTEDs.ToListAsync();


                return new
                {
                    Crude_Oil_Production = Crude_Oil_Production,
                    Crude_Oil_Production_By_Contract_Basis = Crude_Oil_Production_By_Contract_Basis,
                    Crude_Oil_Monthly_Production = Crude_Oil_Monthly_Production,
                    Crude_Oil_Production_By_Terrain = Crude_Oil_Production_By_Terrain,
                    Crude_Oil_Production_By_ContractType_Pivotted = Crude_Oil_Production_By_ContractType_Pivotted,
                    Crude_Oil_Production_By_Terrain_Pivotted = Crude_Oil_Production_By_Terrain_Pivotted,
                    Crude_Oil_Monthly_Production_Pivotted = Crude_Oil_Monthly_Production_Pivotted,
                    Crude_Oil_Monthly_Activities_Pivotted_Breakdown = Crude_Oil_Monthly_Activities_Pivotted_Breakdown,
                    Company_RRR_Pivotted = Company_RRR_Pivotted,
                    Nation_RRR_Pivotted = Nation_RRR_Pivotted,

                };
            }

            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [HttpGet("Get_Gas_Production_Report")]
        public async Task<object> Get_Gas_Production_Report(string year)
        {
            WorkProgrammeReport2_Model WKP_Report2 = new WorkProgrammeReport2_Model();
            try
            {
                var Annual_Gas_Produced = await _context.WP_GAS_PRODUCTION_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();
                var Gas_Produced_Utilized_Flared = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flareds.Where(x => x.Year_of_WP == year).ToListAsync();
                var Gas_Produced_Utilized_By_Contract_Basis = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_bases.Where(x => x.Year_of_WP == year).ToListAsync();
                var Gas_Produced_Utilized_By_Contract_Basis_Pivotted = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoteds.ToListAsync();
                var Gas_Produced_Utilized_By_Terrain_Pivotted = await _context.WP_GAS_PRODUCTION_ACTIVITIES_terrain_pivotteds.ToListAsync();
                var Gas_Flare_Penalty = await _context.WP_GAS_PRODUCTION_ACTIVITIES_penalty_payments.Where(x => x.Year_of_WP == year).ToListAsync();

                return new
                {
                    Annual_Gas_Produced = Annual_Gas_Produced,
                    Gas_Produced_Utilized_Flared = Gas_Produced_Utilized_Flared,
                    Gas_Produced_Utilized_By_Contract_Basis = Gas_Produced_Utilized_By_Contract_Basis,
                    Gas_Produced_Utilized_By_Contract_Basis_Pivotted = Gas_Produced_Utilized_By_Contract_Basis_Pivotted,
                    Gas_Produced_Utilized_By_Terrain_Pivotted = Gas_Produced_Utilized_By_Terrain_Pivotted,
                    Gas_Flare_Penalty = Gas_Flare_Penalty
                };
            }

            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [HttpGet("Get_Accident_Statistics_Report")]
        public async Task<object> Get_Accident_Statistics_Report(string year)
        {

            try
            {
                var Accident_Statistics_Facility = await _context.WP_HSE_FATALITIES_accident_statistic_tables.Where(x => x.Year_of_WP == year && x.Fatalities_Type.ToLower() == GeneralModel.Fatality.ToLower()).ToListAsync();
                var Causes_Of_Spill = await _context.HSE_CAUSES_OF_SPILLs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyName).ToListAsync();
                return new
                {
                    Accident_Statistics_Facility = Accident_Statistics_Facility,
                    Causes_Of_Spill = Causes_Of_Spill
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }

        [HttpGet("Get_Accident_Statistics_Content_Report")]
        public async Task<object> Get_Accident_Statistics_Content_Report(string year)
        {

            try
            {
                var acrep = await _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequences.Where(x => x.Year_of_WP == year && x.Consequence == "FATALITY").ToListAsync();
                var actotal = await _context.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accidents.Where(x => x.Year_of_WP == year).ToListAsync();
                return new
                {
                    acrep = acrep,
                    actotal = actotal
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }

        [HttpGet("Get_Facilities_Report")]
        public async Task<object> Get_Facilities_Report(string year)
        {

            try
            {
                var Accident_Statistics_Facility = await _context.WP_HSE_FATALITIES_accident_statistic_tables.Where(x => x.Year_of_WP == year && x.Fatalities_Type == GeneralModel.Fatality).ToListAsync();
                var Causes_Of_Spill = await _context.HSE_CAUSES_OF_SPILLs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyName).ToListAsync();
                return new
                {
                    Accident_Statistics_Facility = Accident_Statistics_Facility,
                    Causes_Of_Spill = Causes_Of_Spill
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Facilities_Projects_Report")]
        public async Task<object> Get_Facilities_Projects_Report(string year)
        {

            try
            {
                var Major_Projects = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x => x.Year_of_WP == year && x.Actual_Proposed == "Actual Year").ToListAsync();
                var New_Technology_Conformity = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Where(x => x.Year_of_WP == year).ToListAsync();

                return new
                {
                    Major_Projects = Major_Projects,
                    New_Technology_Conformity = New_Technology_Conformity
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Nigeria_Content_Report")]
        public async Task<object> Get_Nigeria_Content_Report(string year)
        {

            try
            {
                var Nigeria_Content = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Year_of_WP == year && x.Actual_Proposed == "Actual Year").ToListAsync();
                var Nigeria_Content_SuccessionPlan = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.Where(x => x.Year_of_WP == year && x.Actual_proposed == "Actual Year").ToListAsync();

                return new
                {
                    Nigeria_Content = Nigeria_Content,
                    Nigeria_Content_SuccessionPlan = Nigeria_Content_SuccessionPlan
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Sustainable_Community_Development_Report")]
        public async Task<object> Get_Sustainable_Community_Development_Report(string year)
        {

            try
            {
                var Capital_Projects = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Where(x => x.Year_of_WP == year && x.Actual_proposed == "Actual Year").ToListAsync();
                var Scholarship = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Where(x => x.Year_of_WP == year && x.Actual_proposed == "Actual Year").ToListAsync();
                var Training_Skill_Acquisition = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Where(x => x.Year_of_WP == year && x.Actual_proposed == "Actual Year").ToListAsync();

                return new
                {
                    Capital_Projects = Capital_Projects,
                    Scholarship = Scholarship,
                    Training_Skill_Acquisition = Training_Skill_Acquisition,
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Budget_Performance_Report")]
        public async Task<object> Get_Budget_Performance_Report(string year)
        {

            try
            {
                var Exploratory_Activities = await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();
                var Development_Activities = await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Where(x => x.Year_of_WP == year).ToListAsync();
                var Facilities_Development_Projects = await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Where(x => x.Year_of_WP == year).ToListAsync();
                var Production_Costs = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Where(x => x.Year_of_WP == year).ToListAsync();

                return new
                {
                    Exploratory_Activities = Exploratory_Activities,
                    Development_Activities = Development_Activities,
                    Facilities_Development_Projects = Facilities_Development_Projects,
                    Production_Costs = Production_Costs,
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Planned_Seismic_Activities_Report")]
        public async Task<object> Get_Planned_Seismic_Activities_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Planned_Seismic_Activities = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                        where o.proposed_year == proposedYear && o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                        group o by new
                                                        {
                                                            o.CompanyName,
                                                            o.OML_Name,
                                                            o.Name_of_Contractor,
                                                            o.Terrain,
                                                            o.Geo_type_of_data_acquired,
                                                        }
                                                                        into g
                                                        select new
                                                        {
                                                            Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                            Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                            Quantum_Approved = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Quantum_Approved))),
                                                            Quantum_Planned = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Quantum_Planned))),
                                                            Year_of_WP = g.FirstOrDefault().Year_of_WP,
                                                            OML_Name = g.FirstOrDefault().OML_Name,
                                                            CompanyName = g.FirstOrDefault().CompanyName,
                                                            Terrain = g.FirstOrDefault().Terrain,
                                                            Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                        }).ToListAsync();

                var Planned_Seismic_Processing_Reprocessing = await (from o in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                                                                     where o.proposed_year == proposedYear
                                                                     group o by new
                                                                     {
                                                                         o.CompanyName,
                                                                         o.OML_Name,
                                                                         o.Name_of_Contractor,
                                                                         o.Terrain,
                                                                     }
                                                                        into g
                                                                     select new
                                                                     {
                                                                         Quantum_Approved = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Quantum_Approved))),
                                                                         Quantum_Planned = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Quantum_Planned))),
                                                                         OML_Name = g.FirstOrDefault().OML_Name,
                                                                         CompanyName = g.FirstOrDefault().CompanyName,
                                                                         Terrain = g.FirstOrDefault().Terrain,
                                                                         Name_of_Contractor = g.FirstOrDefault().Name_of_Contractor,
                                                                     }).ToListAsync();


                return new
                {
                    Planned_Seismic_Activities = Planned_Seismic_Activities,
                    Planned_Seismic_Processing_Reprocessing = Planned_Seismic_Processing_Reprocessing,

                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Planned_Exploration_Report")]
        public async Task<object> Get_Planned_Exploration_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Planned_Exploration_Wells = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Exploration).ToListAsync();
                var Planned_Appraisal_Wells = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category.Contains(GeneralModel.Appraisal)).ToListAsync();
                var Planned_Develoment_Wells = await _context.Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(x => x.Year_of_WP == year && x.Category == GeneralModel.Development).ToListAsync();

                return new
                {
                    Planned_Exploration_Wells = Planned_Exploration_Wells,
                    Planned_Appraisal_Wells = Planned_Appraisal_Wells,
                    Planned_Develoment_Wells = Planned_Develoment_Wells,

                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Research_Forecast_Report")]
        public async Task<object> Get_Research_Forecast_Report(string year)
        {

            try
            {

                var Research_Forecast = await _context.WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNEDs.Where(x => x.Fiveyear_Projection_Year == year).ToListAsync();

                return new
                {
                    Research_Forecast = Research_Forecast

                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Projected_Oil_Production_Report")]
        public async Task<object> Get_Projected_Oil_Production_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Projected_Oil_Production = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();
                var Oil_Production_Forecast_By_ContractBasis = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();
                var Monthly_Production_Forecast = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();
                var Oil_Production_Forecast_ByTerrainBasis = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains.Where(x => x.Year_of_WP == proposedYear).ToListAsync();
                var Crude_Oil_Production_ByContractBasis_BBLs_Pivotted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotteds.ToListAsync();
                var Crude_Oil_Production_ByTerrainBasis_BBLs_Pivotted = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoteds.ToListAsync();
                var Breakdown_of_Reconciled_Oil_Production = await _context.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdowns.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyName).ToListAsync();

                return new
                {
                    Projected_Oil_Production = Projected_Oil_Production,
                    Oil_Production_Forecast_By_ContractBasis = Oil_Production_Forecast_By_ContractBasis,
                    Monthly_Production_Forecast = Monthly_Production_Forecast,
                    Oil_Production_Forecast_ByTerrainBasis = Oil_Production_Forecast_ByTerrainBasis,
                    Crude_Oil_Production_ByContractBasis_BBLs_Pivotted = Crude_Oil_Production_ByContractBasis_BBLs_Pivotted,
                    Crude_Oil_Production_ByTerrainBasis_BBLs_Pivotted = Crude_Oil_Production_ByTerrainBasis_BBLs_Pivotted,
                    Breakdown_of_Reconciled_Oil_Production = Breakdown_of_Reconciled_Oil_Production,

                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Gas_Production_Utilization_Report")]
        public async Task<object> Get_Gas_Production_Utilization_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Gas_Production_Utilization_Forecast = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).OrderBy(x => x.CompanyName).ToListAsync();
                var Gas_Production_Utilization_Forecast_By_ContractBasis = await _context.WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNEDs.Where(x => x.Year_of_WP == proposedYear).ToListAsync();

                return new
                {
                    Gas_Production_Utilization_Forecast = Gas_Production_Utilization_Forecast,
                    Gas_Production_Utilization_Forecast_By_ContractBasis = Gas_Production_Utilization_Forecast_By_ContractBasis,
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Proposed_Facility_Project_Report")]
        public async Task<object> Get_Proposed_Facility_Project_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Proposed_Facility_Project = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(x => x.Year_of_WP == year && x.Actual_Proposed == GeneralModel.ProposedYear).OrderBy(x => x.CompanyName).ToListAsync();

                return new
                {
                    Proposed_Facility_Project = Proposed_Facility_Project,
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Nigeria_Content_Planning_Report")]
        public async Task<object> Get_Nigeria_Content_Planning_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Nigeria_Content_Planning = await _context.NIGERIA_CONTENT_Trainings.Where(x => x.Year_of_WP == year && x.Actual_Proposed == GeneralModel.ProposedYear).OrderBy(x => x.CompanyName).ToListAsync();
                var Proposed_Succession_Plans = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.Where(x => x.Year_of_WP == year && x.Actual_proposed == GeneralModel.ProposedYear).OrderBy(x => x.CompanyName).ToListAsync();

                return new
                {
                    Nigeria_Content_Planning = Nigeria_Content_Planning,
                    Proposed_Succession_Plans = Proposed_Succession_Plans
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Planned_SDCP_Report")]
        public async Task<object> Get_Planned_SDCP_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Capital_Projects = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Where(x => x.Year_of_WP == year && x.Actual_proposed == GeneralModel.ProposedYear).OrderBy(x => x.CompanyNumber).ToListAsync();
                var Proposed_Scholarships = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Where(x => x.Year_of_WP == year && x.Actual_proposed == GeneralModel.ProposedYear).OrderBy(x => x.CompanyName).ToListAsync();
                var Proposed_Training_Skills_Acquisition = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Where(x => x.Year_of_WP == year && x.Actual_proposed == GeneralModel.ProposedYear).OrderBy(x => x.CompanyName).ToListAsync();

                return new
                {
                    Capital_Projects = Capital_Projects,
                    Proposed_Scholarships = Proposed_Scholarships,
                    Proposed_Training_Skills_Acquisition = Proposed_Training_Skills_Acquisition
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Planned_Budget_Report")]
        public async Task<object> Get_Planned_Budget_Report(string year)
        {

            try
            {
                string proposedYear = year != null ? (int.Parse(year) + 1).ToString() : "";

                var Proposed_Exploratory_Activities = await _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyNumber).ToListAsync();
                var Proposed_DevelopmentDrilling_Activities = await _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyNumber).ToListAsync();
                var Proposed_FacilityDevelopmentProjects_Activities = await _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyNumber).ToListAsync();
                var Planned_ProductionCost = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Where(x => x.Year_of_WP == year).OrderBy(x => x.CompanyNumber).ToListAsync();

                return new
                {
                    Proposed_Exploratory_Activities = Proposed_Exploratory_Activities,
                    Proposed_DevelopmentDrilling_Activities = Proposed_DevelopmentDrilling_Activities,
                    Proposed_FacilityDevelopmentProjects_Activities = Proposed_FacilityDevelopmentProjects_Activities,
                    Planned_ProductionCost = Planned_ProductionCost,
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }
        [HttpGet("Get_Strategic_Plan_Report")]
        public async Task<object> Get_Strategic_Plan_Report(string year)
        {

            try
            {
                var Strategic_Plan = await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.Where(x => x.Year_of_WP == year).ToListAsync();

                return new
                {
                    Strategic_Plan = Strategic_Plan
                };
            }

            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }

        #endregion

        [HttpGet("CONCESSIONSINFORMATION")]
        public async Task<WebApiResponse> Get_ADMIN_CONCESSIONS_INFORMATION_BY_CURRENT_YEAR(string year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<ADMIN_CONCESSIONS_INFORMATION>();

                if (WKUserRole == GeneralModel.Admin)
                {
                    ConcessionsInformation = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(c => c.DELETED_STATUS == null).ToListAsync();

                }
                else
                {
                    ConcessionsInformation = await _context.ADMIN_CONCESSIONS_INFORMATIONs.Where(c => c.Company_ID == WKPCompanyId && c.DELETED_STATUS == null).ToListAsync();
                }

                if (year != null)
                {
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year == year).ToList();
                }
                else
                {
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year == dateYear).ToList();

                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("REPORTS_YEARLIST")]
        public async Task<object> REPORTS_YEARLIST()
        {
            try
            {
                int portalDate = int.Parse(_configuration.GetSection("AppSettings").GetSection("portalDate").Value.ToString());
                var yearList = from n in Enumerable.Range(0, (DateTime.Now.Year - portalDate) + 1)
                               select (DateTime.Now.Year - n).ToString();

                return yearList;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("CONCESSIONSITUATION")]
        public async Task<WebApiResponse> Get_CONCESSION_SITUATION(string year)
        {

            var ConcessionSituation = new List<CONCESSION_SITUATION>();
            try
            {

                if (WKUserRole == GeneralModel.Admin)
                {
                    ConcessionSituation = await _context.CONCESSION_SITUATIONs.Where(c => c.Year == year).ToListAsync();
                }
                else
                {
                    ConcessionSituation = await _context.CONCESSION_SITUATIONs.Where(c => c.Year == year && c.COMPANY_ID == WKPCompanyId && c.Year == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionSituation.OrderBy(x => x.Year), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("GEOPHYSICALACTIVITIES")]
        public async Task<WebApiResponse> Get_GEOPHYSICAL_ACTIVITIES_ACQUISITION(string year)
        {
            var GEOPHYSICALACTIVITIES = new List<GEOPHYSICAL_ACTIVITIES_ACQUISITION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    GEOPHYSICALACTIVITIES = await _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    GEOPHYSICALACTIVITIES = await _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Where(c => c.Year_of_WP == year && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = GEOPHYSICALACTIVITIES.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("GEOPHYSICALPROCESSING")]
        public async Task<WebApiResponse> Get_GEOPHYSICAL_ACTIVITIES_PROCESSING(string year)
        {

            var GEOPHYSICALACTIVITIES = new List<GEOPHYSICAL_ACTIVITIES_PROCESSING>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    GEOPHYSICALACTIVITIES = await _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    GEOPHYSICALACTIVITIES = await _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Where(c => c.Year_of_WP == year && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = GEOPHYSICALACTIVITIES.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("DRILLING-OPERATIONS")]
        public async Task<WebApiResponse> Get_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS(string year)
        {

            var DRILLING_OPERATIONS = new List<DRILLING_OPERATIONS_CATEGORIES_OF_WELL>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    DRILLING_OPERATIONS = await _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    DRILLING_OPERATIONS = await _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Where(c => c.Year_of_WP == year && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = DRILLING_OPERATIONS.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("WORKOVERS_RECOMPLETION")]
        public async Task<WebApiResponse> Get_WORKOVERS_RECOMPLETION_JOBs(string year)
        {
            var WORKOVERS_RECOMPLETION = new List<WORKOVERS_RECOMPLETION_JOB1>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    WORKOVERS_RECOMPLETION = await _context.WORKOVERS_RECOMPLETION_JOBs1.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    WORKOVERS_RECOMPLETION = await _context.WORKOVERS_RECOMPLETION_JOBs1.Where(c => c.Year_of_WP == year && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = WORKOVERS_RECOMPLETION.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("INITIAL_WELLCOMPLETION")]
        public async Task<WebApiResponse> Get_INITIAL_WELL_COMPLETION(string year)
        {
            var INITIAL_WELLCOMPLETION = new List<INITIAL_WELL_COMPLETION_JOB1>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    INITIAL_WELLCOMPLETION = await _context.INITIAL_WELL_COMPLETION_JOBs1.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    INITIAL_WELLCOMPLETION = await _context.INITIAL_WELL_COMPLETION_JOBs1.Where(c => c.Year_of_WP == year && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = INITIAL_WELLCOMPLETION.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("FDP_EXPECTED_RESERVES")]
        public async Task<WebApiResponse> Get_FIELD_DEVELOPMENT_PLAN_EXPECTED_RESERVES(string year)
        {
            var FDP_Reserves = new List<FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    FDP_Reserves = await _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    FDP_Reserves = await _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = FDP_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("FDP_TOSUBMIT")]
        public async Task<WebApiResponse> Get_FIELD_DEVELOPMENT_PLAN_TOBESUBMITTED(string year)
        {
            var FDP_Reserves = new List<FIELD_DEVELOPMENT_PLAN>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    FDP_Reserves = await _context.FIELD_DEVELOPMENT_PLANs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    FDP_Reserves = await _context.FIELD_DEVELOPMENT_PLANs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = FDP_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("FDP_FIELDSTATUS")]
        public async Task<WebApiResponse> FIELD_DEVELOPMENT_FIELDS_AND_STATUS(string year)
        {
            var FDP_Fields = new List<FIELD_DEVELOPMENT_FIELDS_AND_STATUS>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    FDP_Fields = await _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    FDP_Fields = await _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = FDP_Fields.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("NDR")]
        public async Task<WebApiResponse> NDR(string year)
        {
            var NDR = new List<NDR>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    NDR = await _context.NDRs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    NDR = await _context.NDRs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = NDR.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("OIL_CONDENSATE_PRODUCTION_ACTIVITIES")]
        public async Task<WebApiResponse> OIL_CONDENSATE_PRODUCTION_ACTIVITIES(string year)
        {
            var OilCondensate = new List<OIL_CONDENSATE_PRODUCTION_ACTIVITy>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("OIL_CONDENSATE_MONTHLY_ACTIVITIES")]
        public async Task<WebApiResponse> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities(string year)
        {
            var OilCondensate = new List<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("OIL_CONDENSATE_MONTHLY_ACTIVITIES_PROPOSED")]
        public async Task<WebApiResponse> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED(string year)
        {
            var OilCondensate = new List<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("OIL_CONDENSATE_MONTHLY_ACTIVITIES_PROPOSED_FIVEYEARS")]
        public async Task<WebApiResponse> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION(string year)
        {
            var OilCondensate = new List<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("GAS_PRODUCTION_ACTIVITIES")]
        public async Task<WebApiResponse> GAS_PRODUCTION_ACTIVITIES(string year)
        {
            var GasProduction = new List<GAS_PRODUCTION_ACTIVITy>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    GasProduction = await _context.GAS_PRODUCTION_ACTIVITIEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    GasProduction = await _context.GAS_PRODUCTION_ACTIVITIEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = GasProduction.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY")]
        public async Task<WebApiResponse> GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY(string year)
        {

            var GasProduction = new List<GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    GasProduction = await _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    GasProduction = await _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = GasProduction.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("UNITIZATION")]
        public async Task<WebApiResponse> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION(string year)
        {

            var GasProduction = new List<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    GasProduction = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    GasProduction = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = GasProduction.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("CONCESSION_RESERVES_FOR_1ST_JANUARY")]
        public async Task<WebApiResponse> CONCESSION_RESERVES_FOR_1ST_JANUARY(string year)
        {
            var Concession = new List<RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    Concession = await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Where(c => c.Year_of_WP == year && c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR").ToListAsync();
                }

                else
                {
                    Concession = await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Where(c => c.FLAG1 == "COMPANY_RESERVE_OF_PRECEDDING_YEAR" && c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = Concession.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("CONCESSION_RESERVES_FOR_CURRENT_YEAR")]
        public async Task<WebApiResponse> CONCESSION_RESERVES_FOR_CURRENT_YEAR(string year)
        {
            var Concession = new List<RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    Concession = await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Where(c => c.FLAG1 == "COMPANY_CURRENT_RESERVE").ToListAsync();
                }

                else
                {
                    Concession = await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Where(c => c.FLAG1 == "COMPANY_CURRENT_RESERVE" && c.COMPANY_ID == WKPCompanyId).ToListAsync();
                }

                if (year != null)
                {
                    Concession = Concession.Where(c => c.Year_of_WP == year).ToList();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = Concession.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_OIL_CONDENSATE_PRODUCTION")]
        public async Task<WebApiResponse> RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION(string year)
        {
            var OilCondensate_Reserves = new List<RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_ADDITION")]
        public async Task<WebApiResponse> RESERVES_ADDITION(string year)
        {
            var OilCondensate_Reserves = new List<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_DECLINE")]
        public async Task<WebApiResponse> RESERVES_DECLINE(string year)
        {
            var OilCondensate_Reserves = new List<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_LIFE_INDEX")]
        public async Task<WebApiResponse> RESERVES_UPDATES_LIFE_INDEX(string year)
        {
            var OilCondensate_Reserves = new List<RESERVES_UPDATES_LIFE_INDEX>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_LIFE_INDices.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_LIFE_INDices.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_UPDATES_DEPLETION_RATE")]
        public async Task<WebApiResponse> RESERVES_UPDATES_DEPLETION_RATE(string year)
        {
            var OilCondensate_Reserves = new List<RESERVES_UPDATES_DEPLETION_RATE>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_DEPLETION_RATEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_DEPLETION_RATEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_OIL_CONDENSATE_MMBBL")]
        public async Task<WebApiResponse> RESERVES_UPDATES_OIL_CONDENSATE_MMBBL(string year)
        {
            var OilCondensate_Reserves = new List<RESERVES_UPDATES_OIL_CONDENSATE_MMBBL>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs.Where(c => c.Companyemail == WKPCompanyId).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("RESERVES_REPLACEMENT_RATIO")]
        public async Task<WebApiResponse> RESERVES_REPLACEMENT_RATIO(string year)
        {

            var OilCondensate_Reserves = new List<RESERVES_REPLACEMENT_RATIO>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate_Reserves = await _context.RESERVES_REPLACEMENT_RATIOs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate_Reserves = await _context.RESERVES_REPLACEMENT_RATIOs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate_Reserves.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("BUDGET_CAPEX_OPEX")]
        public async Task<WebApiResponse> BUDGET_CAPEX_OPEX(string year)
        {
            var BudgetCapex = new List<BUDGET_CAPEX_OPEX>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    BudgetCapex = await _context.BUDGET_CAPEX_OPices.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    BudgetCapex = await _context.BUDGET_CAPEX_OPices.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = BudgetCapex.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("OIL_AND_GAS__MAINTENANCE_PROJECTS")]
        public async Task<WebApiResponse> OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS(string year)
        {
            var BudgetCapex = new List<OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    BudgetCapex = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    BudgetCapex = await _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = BudgetCapex.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("OIL_CONDENSATE_CONFORMITY")]
        public async Task<WebApiResponse> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment(string year)
        {
            var OilCondensate = new List<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    OilCondensate = await _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = OilCondensate.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("FACILITIES_PROJECT_PERFORMANCE")]
        public async Task<WebApiResponse> FACILITIES_PROJECT_PERFORMANCE(string year)
        {
            var ResultData = new List<FACILITIES_PROJECT_PERFORMANCE>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.FACILITIES_PROJECT_PERFORMANCEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.FACILITIES_PROJECT_PERFORMANCEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("LEGAL_LITIGATION")]
        public async Task<WebApiResponse> LEGAL_LITIGATION(string year)
        {
            var ResultData = new List<LEGAL_LITIGATION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.LEGAL_LITIGATIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.LEGAL_LITIGATIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }


                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("LEGAL_ARBITRATION")]
        public async Task<WebApiResponse> LEGAL_ARBITRATION(string year)
        {
            var ResultData = new List<LEGAL_ARBITRATION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.LEGAL_ARBITRATIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.LEGAL_ARBITRATIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("NIGERIA_CONTENT_TRAINING")]
        public async Task<WebApiResponse> NIGERIA_CONTENT_TRAINING(string year)
        {
            var ResultData = new List<NIGERIA_CONTENT_Training>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.NIGERIA_CONTENT_Trainings.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.NIGERIA_CONTENT_Trainings.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("NIGERIA_CONTENT_SUCCESSIONPLAN")]
        public async Task<WebApiResponse> NIGERIA_CONTENT_Upload_Succession_Plan(string year)
        {
            var ResultData = new List<NIGERIA_CONTENT_Upload_Succession_Plan>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.NIGERIA_CONTENT_Upload_Succession_Plans.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("STRATEGIC_PLANS_ON_COMPANY_BASIS")]
        public async Task<WebApiResponse> STRATEGIC_PLANS_ON_COMPANY_BASIS(string year)
        {
            var ResultData = new List<STRATEGIC_PLANS_ON_COMPANY_BASI>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.STRATEGIC_PLANS_ON_COMPANY_BAses.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW")]
        public async Task<WebApiResponse> HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW(string year)
        {
            var ResultData = new List<HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_MANAGEMENT_POSITION")]
        public async Task<WebApiResponse> HSE_MANAGEMENT_POSITION(string year)
        {
            var ResultData = new List<HSE_MANAGEMENT_POSITION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_MANAGEMENT_POSITIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_MANAGEMENT_POSITIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("ENVIRONMENTAL_MANAGEMENT_SYSTEM")]
        public async Task<WebApiResponse> ENVIRONMENTAL_MANAGEMENT_SYSTEM(string year)
        {
            var ResultData = new List<HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("WASTE_MANAGEMENT_UPLOAD")]
        public async Task<WebApiResponse> WASTE_MANAGEMENT_UPLOAD(string year)
        {
            var ResultData = new List<HSE_WASTE_MANAGEMENT_SYSTEM>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_WASTE_MANAGEMENT_SYSTEMs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_WASTE_MANAGEMENT_SYSTEMs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("WASTE_MANAGEMENT")]
        public async Task<WebApiResponse> WASTE_MANAGEMENT(string year)
        {
            var ResultData = new List<HSE_WASTE_MANAGEMENT_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_WASTE_MANAGEMENT_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_WASTE_MANAGEMENT_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("HSE_WASTE_MANAGEMENT_DISCHARGE_ZONE")]
        public async Task<WebApiResponse> HSE_WASTE_MANAGEMENT_DISCHARGE_ZONE(string? year)
        {
            var ResultData = new List<HSE_WASTE_MANAGEMENT_DZ>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_WASTE_MANAGEMENT_DZs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_WASTE_MANAGEMENT_DZs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        
        [HttpGet("HSE_OPERATIONS_SAFETY_CASE")]
        public async Task<WebApiResponse> HSE_OPERATIONS_SAFETY_CASE(string? year)
        {
            var ResultData = new List<HSE_OPERATIONS_SAFETY_CASE>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_OPERATIONS_SAFETY_CASEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_OPERATIONS_SAFETY_CASEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        
        [HttpGet("HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING")]
        public async Task<WebApiResponse> HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW(string? year)
        {
            var ResultData = new List<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        
        [HttpGet("HSE_ENVIRONMENTAL_STUDIES")]
        public async Task<WebApiResponse> HSE_ENVIRONMENTAL_STUDIES_NEW(string? year)
        {
            var ResultData = new List<HSE_ENVIRONMENTAL_STUDIES_NEW>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_STUDIES_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        
        [HttpGet("DECOMMISSIONING_AND_ABANDONMENT")]
        public async Task<WebApiResponse> DECOMMISSIONING_ABANDONMENT(string? year)
        {
            var ResultData = new List<DECOMMISSIONING_ABANDONMENT>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.DECOMMISSIONING_ABANDONMENTs.Where(c => c.WpYear == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.DECOMMISSIONING_ABANDONMENTs.Where(c => c.CompanyEmail == WKPCompanyEmail && c.WpYear == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.WpYear), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        
        [HttpGet("HSE_ENVIRONMENTAL_MANAGEMENT_PLAN")]
        public async Task<WebApiResponse> HSE_ENVIRONMENTAL_MANAGEMENT_PLAN(string? year)
        {
            var ResultData = new List<HSE_ENVIRONMENTAL_MANAGEMENT_PLAN>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_ENVIRONMENTAL_MANAGEMENT_PLANs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        
        [HttpGet("BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT")]
        public async Task<WebApiResponse> BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT(string? year)
        {
            var ResultData = new List<BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT>();
            if (string.IsNullOrWhiteSpace(year))
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData, StatusCode = ResponseCodes.Success };

            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };

            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL")]
        public async Task<WebApiResponse> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("PRESCRIPTIONS")]
        public async Task<WebApiResponse> PRESCRIPTIONS(string year)
        {
            var ResultData = new List<HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();

                }
                else
                {
                    ResultData = await _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("WATER_MANAGEMENT")]
        public async Task<WebApiResponse> WATER_MANAGEMENT(string year)
        {
            var ResultData = new List<HSE_PRODUCED_WATER_MANAGEMENT_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Where(c => c.Year_of_WP == year && c.COMPANY_ID == WKPCompanyId).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };

            }
        }

        [HttpGet("HSE_OSP_REGISTRATIONS_NEW")]
        public async Task<WebApiResponse> HSE_OSP_REGISTRATIONS_NEW(string year)
        {
            var ResultData = new List<HSE_OSP_REGISTRATIONS_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_OSP_REGISTRATIONS_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_OSP_REGISTRATIONS_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("HSE_OIL_SPILL_INCIDENT")]
        public async Task<WebApiResponse> HSE_OIL_SPILL_INCIDENT(string year)
        {
            var ResultData = new List<HSE_OIL_SPILL_INCIDENT>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_OIL_SPILL_INCIDENTs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_OIL_SPILL_INCIDENTs.Where(c => c.CompanyName == WKPCompanyName && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("HSE_CAUSES_OF_SPILL")]
        public async Task<WebApiResponse> HSE_CAUSES_OF_SPILL(string year)
        {
            var ResultData = new List<HSE_CAUSES_OF_SPILL>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_CAUSES_OF_SPILLs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_CAUSES_OF_SPILLs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("HSE_OIL_SPILL_REPORTING")]
        public async Task<WebApiResponse> HSE_OIL_SPILL_REPORTING(string year)
        {
            var ResultData = new List<HSE_OIL_SPILL_REPORTING_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_OIL_SPILL_REPORTING_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_OIL_SPILL_REPORTING_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW")]
        public async Task<WebApiResponse> HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW(string year)
        {
            var Resultdata = new List<HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    Resultdata = await _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    Resultdata = await _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }
                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = Resultdata.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("HSE_SAFETY_CULTURE_TRAINING")]
        public async Task<WebApiResponse> HSE_SAFETY_CULTURE_TRAINING(string year)
        {
            var ResultData = new List<HSE_SAFETY_CULTURE_TRAINING>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SAFETY_CULTURE_TRAININGs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_SAFETY_CULTURE_TRAININGs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("HSE_OCCUPATIONAL_HEALTH_MANAGEMENT")]
        public async Task<WebApiResponse> HSE_OCCUPATIONAL_HEALTH_MANAGEMENT(string year)
        {
            var ResultData = new List<HSE_OCCUPATIONAL_HEALTH_MANAGEMENT>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("HSE_QUALITY_CONTROL")]
        public async Task<WebApiResponse> HSE_QUALITY_CONTROL(string year)
        {
            var ResultData = new List<HSE_QUALITY_CONTROL>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_QUALITY_CONTROLs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_QUALITY_CONTROLs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }


        [HttpGet("HSE_CLIMATE_CHANGE_AND_AIR_QUALITY")]
        public async Task<WebApiResponse> HSE_CLIMATE_CHANGE_AND_AIR_QUALITY(string year)
        {
            var ResultData = new List<HSE_CLIMATE_CHANGE_AND_AIR_QUALITY>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW")]
        public async Task<WebApiResponse> HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW(string year)
        {
            var ResultData = new List<HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("UPLOADED_PRESENTATIONS")]
        public async Task<WebApiResponse> UPLOADED_PRESENTATIONS(string year)
        {
            var ResultData = new List<PRESENTATION_UPLOAD>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.PRESENTATION_UPLOADs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.PRESENTATION_UPLOADs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("UPLOADED_COMMUNITY_DEVELOPMENT_PROJECTS")]
        public async Task<WebApiResponse> UPLOADED_COMMUNITY_DEVELOPMENT_PROJECTS(string year)
        {
            var ResultData = new List<PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_SKILL_ACQUISITION")]
        public async Task<WebApiResponse> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_SKILL_ACQUISITION(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_NEW_SCHOLARSHIPS")]
        public async Task<WebApiResponse> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_NEW_SCHOLARSHIP(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {

                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW")]
        public async Task<WebApiResponse> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU")]
        public async Task<WebApiResponse> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Where(c => c.Year_of_WP == year).ToListAsync();
                }
                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME")]
        public async Task<WebApiResponse> Hse_Sustainable_Development_Community_Project_Program_Training_Scheme(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION")]
        public async Task<WebApiResponse> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION(string year)
        {
            var ResultData = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("NIGERIA_CONTENT_QUESTION")]
        public async Task<WebApiResponse> NIGERIA_CONTENT_QUESTION(string year)
        {
            var ResultData = new List<NIGERIA_CONTENT_QUESTION>();
            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    ResultData = await _context.NIGERIA_CONTENT_QUESTIONs.Where(c => c.Year_of_WP == year).ToListAsync();
                }

                else
                {
                    ResultData = await _context.NIGERIA_CONTENT_QUESTIONs.Where(c => c.COMPANY_ID == WKPCompanyId && c.Year_of_WP == year).ToListAsync();
                }

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ResultData.OrderBy(x => x.Year_of_WP), StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        [HttpGet("EXECUTIVE_SUMMARY_REPORT2")]
        public async Task<WebApiResponse> EXECUTIVE_SUMMARY(string year)
        {
            try
            {
                string previousYear = year != null ? (int.Parse(year) - 1).ToString() : "";
                var WKP_Report = await _context.ADMIN_WORK_PROGRAM_REPORTs.Where(x => x.Id <= 5).ToListAsync();
                var get_ReportContent_2 = WKP_Report.Where(x => x.Id == 2)?.FirstOrDefault();
                var GEO_ACTIVITIES = await (from u in _context.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_counts where u.Year_of_WP == year select u).ToListAsync();

                var WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION = await (from o in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                                                                         where o.Year_of_WP == year && o.Geo_type_of_data_acquired == GeneralModel.ThreeD
                                                                         group o by new
                                                                         {
                                                                             o.Geo_type_of_data_acquired,
                                                                             o.Year_of_WP
                                                                         }
                                                                           into g
                                                                         select new WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION
                                                                         {
                                                                             Geo_type_of_data_acquired = g.FirstOrDefault().Geo_type_of_data_acquired,
                                                                             Actual_year_aquired_data = g.Sum(x => Convert.ToInt32(Convert.ToDouble(x.Actual_year_aquired_data))),
                                                                             Year_of_WP = g.FirstOrDefault().Year_of_WP,

                                                                         }).ToListAsync();

                var reportText = get_ReportContent_2.Report_Content
                                .Replace("(NO_OF_JV)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                                .Replace("(NO_OF_JV_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.JV)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                                .Replace("(NO_OF_PSC_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                                .Replace("(NO_OF_PSC)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.PSC)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                                .Replace("(NO_OF_MF_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                                .Replace("(NO_OF_MF)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.MF)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                                .Replace("(NO_OF_INDIGENOUS_COMPANIES)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Count_Contract_Type.ToString())
                                .Replace("(NO_OF_INDIGENOUS)", GEO_ACTIVITIES.Where(x => x.Contract_Type == GeneralModel.SR)?.FirstOrDefault()?.Actual_year_aquired_data.ToString())
                                .Replace("(N)", year)
                                .Replace("(N + 1)", (int.Parse(year) + 1).ToString())
                                .Replace("(N - 1)", previousYear)
                                .Replace("(ACQUIRED_3D)", WP_COUNT_GEOPHYSICAL_ACTIVITIES_ACQUISITION?.FirstOrDefault()?.Actual_year_aquired_data.ToString());
                //var data = await (from a in _context.ADMIN_WORK_PROGRAM_REPORTs where a.Id == 2 select a.Report_Content).FirstOrDefaultAsync();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = reportText, StatusCode = ResponseCodes.Success };
            }

            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE remediation fund
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("remediation_fund")]
        public async Task<WebApiResponse> Get_remediation_fund([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_REMEDIATION_FUND>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_REMEDIATION_FUNDs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_REMEDIATION_FUNDs.Where(c => c.Company_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE effluent_compliance_monitoring
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("effluent_compliance_monitoring")]
        public async Task<WebApiResponse> Get_effluent_compliance_monitoring([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_EFFLUENT_MONITORING_COMPLIANCE>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_EFFLUENT_MONITORING_COMPLIANCEs.Where(c => c.COMPANY_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE point_source_registration
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("point_source_registration")]
        public async Task<WebApiResponse> Get_point_source_registration([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_POINT_SOURCE_REGISTRATION>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_POINT_SOURCE_REGISTRATIONs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_POINT_SOURCE_REGISTRATIONs.Where(c => c.Company_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE GHG_management_plan
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("GHG_management_plan")]
        public async Task<WebApiResponse> Get_GHG_management_plan([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_GHG_MANAGEMENT_PLAN>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_GHG_MANAGEMENT_PLANs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_GHG_MANAGEMENT_PLANs.Where(c => c.CompanY_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE host_communities_development
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("host_communities_development")]
        public async Task<WebApiResponse> Get_host_communities_development([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_HOST_COMMUNITIES_DEVELOPMENT>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_HOST_COMMUNITIES_DEVELOPMENTs.Where(c => c.COMPANY_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE scholarship_scheme
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("scholarship_scheme")]
        public async Task<WebApiResponse> Get_scholarship_scheme([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.Where(c => c.COMPANY_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

        /// <summary>
        /// Endpoint to get the HSE sustainable_development_community_project_planned_and_actuals
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("sustainable_development_community_project_planned_and_actuals")]
        public async Task<WebApiResponse> Get_sustainable_development_community_project_planned_and_actuals([FromQuery] string? year)
        {
            try
            {
                var dateYear = DateTime.Now.AddYears(0).ToString("yyyy");
                var ConcessionsInformation = new List<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL>();

                if (WKUserRole == GeneralModel.Admin)
                    ConcessionsInformation = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.ToListAsync();
                else
                    ConcessionsInformation = await _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Where(c => c.COMPANY_ID == WKPCompanyId).ToListAsync();

                if (!string.IsNullOrEmpty(year))
                    ConcessionsInformation = ConcessionsInformation.Where(c => c.Year_of_WP == year).ToList();

                return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = "Success", Data = ConcessionsInformation, StatusCode = ResponseCodes.Success };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error :  " + e.Message, StatusCode = ResponseCodes.InternalError }; ;
            }
        }

    }
}