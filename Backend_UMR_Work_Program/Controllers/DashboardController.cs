// using Backend_UMR_Work_Program.Models;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using System.Security.Claims;
// using static Backend_UMR_Work_Program.Models.GeneralModel;

// namespace Backend_UMR_Work_Program.Controllers
// {

//     [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//     [Route("api/[controller]")]
//     public class DashboardController : ControllerBase
//     {
//         public WKP_DBContext _context;

//         public DashboardController(WKP_DBContext context)
//         {
//             _context = context;
//         }

//         private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
//         private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
//         private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
//         private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);
//         private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

//         [HttpGet("Company_Dashboard_Report")]
//         public async Task<object> Company_Dashboard(string year)
//         {
//             try
//             {
//                 var data = await (from conc in _context.CONCESSION_SITUATIONs
//                                   join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
//                                   join reserve in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs on conc.OML_ID equals reserve.OML_ID
//                                   join reserveStatus in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs on conc.OML_ID equals reserveStatus.OML_ID
//                                   where reserve.Year_of_WP == year && (reserve.Created_by == WKPCompanyEmail || reserve.CompanyNumber == WKPCompanyNumber)
//                                   && (reserveStatus.Created_by == WKPCompanyEmail || reserveStatus.CompanyNumber == WKPCompanyNumber)

//                                   select new
//                                   {
//                                       year = reserve.Year_of_WP,
//                                       conc = conc,
//                                       reserve = reserve,
//                                       reserveStatus = reserveStatus,
//                                       comp
//                                   }).ToListAsync();

//                 var companyDashboard_DataList = new List<CompanyReportModel>();
//                 var companyDashboard_Data = new CompanyReportModel();
//                 var companyDashboard_Report = new CompanyDashboardModel();
//                 var companyConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.DELETED_STATUS != "DELETED" select d).ToListAsync();

//                 //  var test = data.GroupBy(x => x.conc.OML_ID).ToList();

//                 data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
//                 {
//                     companyDashboard_Data = new CompanyReportModel()
//                     {
//                         concessionName = key.FirstOrDefault().conc.OML_Name,
//                         oil_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_Oil)),
//                         AG_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_AG)),
//                         NAG_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_NAG)),
//                         condensate_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_Condensate)),
//                         oil_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualOilProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
//                         AG_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualGasAGProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
//                         NAG_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualGasNAGProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
//                         condensate_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualCondensateProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualCondensateProduction)),

//                     };
//                     companyDashboard_Data.totalNetProduction = companyDashboard_Data.oil_NetProduction + companyDashboard_Data.AG_NetProduction + companyDashboard_Data.NAG_NetProduction + companyDashboard_Data.condensate_NetProduction;
//                     companyDashboard_Data.totalReserves = companyDashboard_Data.oil_Reserves + companyDashboard_Data.AG_Reserves + companyDashboard_Data.NAG_Reserves + companyDashboard_Data.condensate_Reserves;
//                     companyDashboard_DataList.Add(companyDashboard_Data);
//                 });
//                 companyDashboard_Report.CompanyReportModel = companyDashboard_DataList;

//                 //data.ForEach(a =>
//                 //{
//                 //    companyDashboard_Data = new CompanyReportModel()
//                 //    {
//                 //        concessionName = a.conc.OML_Name,
//                 //        oil_NetProduction = double.Parse(a.reserve.Company_Annual_Oil),
//                 //        AG_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_AG)),
//                 //        NAG_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_NAG)),
//                 //        condensate_NetProduction = key.Where(x => x.year == year).Sum(x => double.Parse(x.reserve.Company_Annual_Condensate)),
//                 //        oil_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualOilProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
//                 //        AG_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualGasAGProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
//                 //        NAG_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualGasNAGProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
//                 //        condensate_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualCondensateProduction != null).Sum(x => double.Parse(x.reserveStatus?.Company_Reserves_AnnualCondensateProduction)),

//                 //    };
//                 //    companyDashboard_Data.totalNetProduction = companyDashboard_Data.oil_NetProduction + companyDashboard_Data.AG_NetProduction + companyDashboard_Data.NAG_NetProduction + companyDashboard_Data.condensate_NetProduction;
//                 //    companyDashboard_Data.totalReserves = companyDashboard_Data.oil_Reserves + companyDashboard_Data.AG_Reserves + companyDashboard_Data.NAG_Reserves + companyDashboard_Data.condensate_Reserves;
//                 //    companyDashboard_Report.CompanyReportModel.Add(companyDashboard_Data);
//                 //});
//                 companyDashboard_Report.OML_Count = companyConcessions.Where(x => x.Consession_Type.ToLower() == GeneralModel.OML.ToLower()).Count();
//                 companyDashboard_Report.OPL_Count = companyConcessions.Where(x => x.Consession_Type.ToLower() == GeneralModel.OPL.ToLower()).Count();
//                 companyDashboard_Report.No_Of_ProducingFields_Count = await (from d in _context.COMPANY_FIELDs where d.CompanyNumber == WKPCompanyNumber && d.DeletedStatus != true select d).CountAsync();

//                 return companyDashboard_Report;
//             }
//             catch (Exception e)
//             {
//                 return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
//             }
//         }

//         [HttpGet("DASHBOARD_TOTAL_GAS_PRODUCTION_UTILIZED_FLARED")]
//         public async Task<object> DASHBOARD_TOTAL_GAS_PRODUCTION_UTILIZED_FLARED()
//         {
//             var TGPUF = new List<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED>();
//             var TBPPCT = new List<BUDGET_PERFORMANCE_PRODUCTION_COST>();
//             var TROC = new List<RESERVES_UPDATES_OIL_CONDENSATE>();
//             try
//             {               
//                 if (WKUserRole == GeneralModel.Admin)
//                 {
//                     TGPUF = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs.Where(c => c.CompanyName == WKPCompanyName).ToListAsync();
//                     TBPPCT = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Where(c => c.CompanyName == WKPCompanyName).ToListAsync();
//                     TROC = await _context.RESERVES_UPDATES_OIL_CONDENSATEs.Where(c => c.CompanyName == WKPCompanyName).ToListAsync();
//                 }
//                 else
//                 {
//                     TGPUF = await _context.WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs.Where(c => c.CompanyName == WKPCompanyName).ToListAsync();
//                     TBPPCT = await _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Where(c => c.CompanyName == WKPCompanyName).ToListAsync();
//                     TROC = await _context.RESERVES_UPDATES_OIL_CONDENSATEs.Where(c => c.CompanyName == WKPCompanyName).ToListAsync();
//                 }
//                 return new { TGPUF = TGPUF, TBP = TBPPCT, TR = TROC };
//             }
//             catch (Exception e)
//             {

//                 return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
//             }
//         }
//     }
// }

using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
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
    public class DashboardController : ControllerBase
    {
        public readonly HelperService _helperService;
        public WKP_DBContext _context;

        public DashboardController(WKP_DBContext context, HelperService helperService)
        {
            _context = context;
            _helperService = helperService;
        }

        private string? WKPCompanyId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? WKPCompanyName => User.FindFirstValue(ClaimTypes.Name);
        private string? WKPCompanyEmail => User.FindFirstValue(ClaimTypes.Email);
        private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);
        private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

        [HttpGet("Company_Dashboard_Report")]
        public async Task<object> Company_Dashboard(string year)
        {
            try
            {
                
                if (WKUserRole == GeneralModel.Admin)
                {
                    var data = new
                    {
                        year = year,
                        conc = await _context.CONCESSION_SITUATIONs.ToListAsync(),
                        reserve = await _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.ToListAsync(),
                        reserveStatus = await _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.ToListAsync()
                    };

                    var companyDashboard_DataList = new List<CompanyReportModel>();
                    var companyDashboard_Data = new CompanyReportModel();
                    var companyDashboard_Report = new CompanyDashboardModel();
                    var companyConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.DELETED_STATUS != "DELETED" select d).ToListAsync();


                    data.conc.GroupBy(x => x.OML_ID).ToList().ForEach(key =>
                    {
                        companyDashboard_Data = new CompanyReportModel()
                        {
                            concessionName = key.FirstOrDefault().OML_Name,
                            oil_NetProduction = data.reserve.Where(x => x.Year_of_WP == year).Sum(x => _helperService.TryParseDouble(x.Company_Annual_Oil)),
                            AG_NetProduction = data.reserve.Where(x => x.Year_of_WP == year).Sum(x => _helperService.TryParseDouble(x.Company_Annual_AG)),
                            NAG_NetProduction = data.reserve.Where(x => x.Year_of_WP == year).Sum(x => _helperService.TryParseDouble(x.Company_Annual_NAG)),
                            condensate_NetProduction = data.reserve.Where(x => x.Year_of_WP == year).Sum(x => _helperService.TryParseDouble(x.Company_Annual_Condensate)),
                            oil_Reserves = data.reserveStatus.Where(x => x.Year_of_WP == year && x.Company_Reserves_AnnualOilProduction != null).Sum(x => _helperService.TryParseDouble(x?.Company_Reserves_AnnualOilProduction)),
                            AG_Reserves = data.reserveStatus.Where(x => x.Year_of_WP == year && x.Company_Reserves_AnnualGasAGProduction != null).Sum(x => _helperService.TryParseDouble(x?.Company_Reserves_AnnualOilProduction)),
                            NAG_Reserves = data.reserveStatus.Where(x => x.Year_of_WP == year && x.Company_Reserves_AnnualGasNAGProduction != null).Sum(x => _helperService.TryParseDouble(x?.Company_Reserves_AnnualOilProduction)),
                            condensate_Reserves = data.reserveStatus.Where(x => x.Year_of_WP == year && x.Company_Reserves_AnnualCondensateProduction != null).Sum(x => _helperService.TryParseDouble(x?.Company_Reserves_AnnualCondensateProduction))

                        };
                        companyDashboard_Data.totalNetProduction = companyDashboard_Data.oil_NetProduction + companyDashboard_Data.AG_NetProduction + companyDashboard_Data.NAG_NetProduction + companyDashboard_Data.condensate_NetProduction;
                        companyDashboard_Data.totalReserves = companyDashboard_Data.oil_Reserves + companyDashboard_Data.AG_Reserves + companyDashboard_Data.NAG_Reserves + companyDashboard_Data.condensate_Reserves;
                        companyDashboard_DataList.Add(companyDashboard_Data);
                    });
                    companyDashboard_Report.CompanyReportModels = companyDashboard_DataList;


                    companyDashboard_Report.OML_Count = companyConcessions.Where(x => x.Consession_Type.ToLower() == GeneralModel.OML.ToLower()).Count();
                    companyDashboard_Report.OPL_Count = companyConcessions.Where(x => x.Consession_Type.ToLower() == GeneralModel.OPL.ToLower()).Count();
                    companyDashboard_Report.No_Of_ProducingFields_Count = await (from d in _context.COMPANY_FIELDs where d.DeletedStatus != true select d).CountAsync();

                    return companyDashboard_Report;

                }
                else
                {
                    var data = await (from conc in _context.CONCESSION_SITUATIONs
                                      join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
                                      join reserve in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs on conc.OML_ID equals reserve.OML_ID
                                      join reserveStatus in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs on conc.OML_ID equals reserveStatus.OML_ID
                                      where reserve.Year_of_WP == year && (reserve.Created_by == WKPCompanyEmail || reserve.CompanyNumber == WKPCompanyNumber)
                                      && (reserveStatus.Created_by == WKPCompanyEmail || reserveStatus.CompanyNumber == WKPCompanyNumber)

                                      select new
                                      {
                                          year = reserve.Year_of_WP,
                                          conc = conc,
                                          reserve = reserve,
                                          reserveStatus = reserveStatus,
                                          comp
                                      }).ToListAsync();

                    var companyDashboard_DataList = new List<CompanyReportModel>();
                    var companyDashboard_Data = new CompanyReportModel();
                    var companyDashboard_Report = new CompanyDashboardModel();
                    var companyConcessions = await (from d in _context.ADMIN_CONCESSIONS_INFORMATIONs where d.Company_ID == WKPCompanyId && d.DELETED_STATUS != "DELETED" select d).ToListAsync();



                    data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
                    {
                        companyDashboard_Data = new CompanyReportModel()
                        {
                            concessionName = key.FirstOrDefault().conc.OML_Name,
                            oil_NetProduction = key.Where(x => x.year == year).Sum(x => _helperService.TryParseDouble(x.reserve.Company_Annual_Oil)),
                            AG_NetProduction = key.Where(x => x.year == year).Sum(x => _helperService.TryParseDouble(x.reserve.Company_Annual_AG)),
                            NAG_NetProduction = key.Where(x => x.year == year).Sum(x => _helperService.TryParseDouble(x.reserve.Company_Annual_NAG)),
                            condensate_NetProduction = key.Where(x => x.year == year).Sum(x => _helperService.TryParseDouble(x.reserve.Company_Annual_Condensate)),
                            oil_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualOilProduction != null).Sum(x => _helperService.TryParseDouble(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
                            AG_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualGasAGProduction != null).Sum(x => _helperService.TryParseDouble(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
                            NAG_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualGasNAGProduction != null).Sum(x => _helperService.TryParseDouble(x.reserveStatus?.Company_Reserves_AnnualOilProduction)),
                            condensate_Reserves = key.Where(x => x.year == year && x.reserveStatus.Company_Reserves_AnnualCondensateProduction != null).Sum(x => _helperService.TryParseDouble(x.reserveStatus?.Company_Reserves_AnnualCondensateProduction))
                        };
                        companyDashboard_Data.totalNetProduction = companyDashboard_Data.oil_NetProduction + companyDashboard_Data.AG_NetProduction + companyDashboard_Data.NAG_NetProduction + companyDashboard_Data.condensate_NetProduction;
                        companyDashboard_Data.totalReserves = companyDashboard_Data.oil_Reserves + companyDashboard_Data.AG_Reserves + companyDashboard_Data.NAG_Reserves + companyDashboard_Data.condensate_Reserves;
                        companyDashboard_DataList.Add(companyDashboard_Data);
                    });
                    companyDashboard_Report.CompanyReportModels = companyDashboard_DataList;


                    companyDashboard_Report.OML_Count = companyConcessions.Where(x => x.Consession_Type.ToLower() == GeneralModel.OML.ToLower()).Count();
                    companyDashboard_Report.OPL_Count = companyConcessions.Where(x => x.Consession_Type.ToLower() == GeneralModel.OPL.ToLower()).Count();
                    companyDashboard_Report.No_Of_ProducingFields_Count = await (from d in _context.COMPANY_FIELDs where d.CompanyNumber == WKPCompanyNumber && d.DeletedStatus != true select d).CountAsync();

                    return companyDashboard_Report;
                }

                
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("DASHBOARD_TOTAL_GAS_BUDGET_RESERVES_DETAILS")]
        public async Task<object> DASHBOARD_TOTAL_GAS_BUDGET_RESERVES_DETAILS(string year)
        {
            var GasProduction = new List<GAS_PRODUCTION_ACTIVITy>();
            var TBPPCT = new List<BUDGET_PERFORMANCE_PRODUCTION_COST>();
            var TROC = new List<RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION>();
            double directProdCost, gasFlareds, oilCondensate, gasPlantCapacity = 0;

            try
            {

                if (WKUserRole == GeneralModel.Admin)
                {

                    GasProduction = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.Year_of_WP == year select c).ToListAsync();
                    TBPPCT = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.Year_of_WP == year select c).ToListAsync();
                    TROC = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.Year_of_WP == year select c).ToListAsync();

                }
                else
                {

                    GasProduction = await (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();
                    TBPPCT = await (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();
                    TROC = await (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.Companyemail == WKPCompanyEmail && c.Year_of_WP == year select c).ToListAsync();

                }

                
                gasPlantCapacity = GasProduction.Sum(a => double.Parse(a.Gas_plant_capacity));
                gasFlareds = GasProduction.Sum(a => double.Parse(a.Flared));
                directProdCost = TBPPCT.Sum(a => double.Parse(a.DIRECT_COST_Actual));
                oilCondensate = TROC.Sum(a => double.Parse(a.Company_Annual_Oil)) + TROC.Sum(a => double.Parse(a.Company_Annual_Condensate));

                return new { gasPlantCapacity = gasPlantCapacity, gasFlareds = gasFlareds, directProdCost = directProdCost, oilCondensate = oilCondensate };
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("TOTAL_RESERVE_BUDGET")]
        public async Task<object> TOTAL_RESERVE_BUDGET(string year)
        {
            double prodCost, reserveOilCondensate, reserveAGNAG = 0;


            try
            {
                if (WKUserRole == GeneralModel.Admin)
                {
                    reserveOilCondensate = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_Oil.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_Condensate.Replace(",", ""))).ToListAsync()).Sum();
                    reserveAGNAG = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_AG.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_NAG.Replace(",", ""))).ToListAsync()).Sum();
                    prodCost = (await (from a in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where a.Year_of_WP == year select Convert.ToDouble(a.INDIRECT_COST_Actual) + Convert.ToDouble(a.DIRECT_COST_Actual)).ToListAsync()).Sum();
                }
                else
                {
                    reserveOilCondensate = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.COMPANY_ID == WKPCompanyId && a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_Oil.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_Condensate.Replace(",", ""))).ToListAsync()).Sum();
                    reserveAGNAG = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.COMPANY_ID == WKPCompanyId && a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_AG.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_NAG.Replace(",", ""))).ToListAsync()).Sum();
                    prodCost = (await (from a in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.INDIRECT_COST_Actual.Replace(",", "")) + Convert.ToDouble(a.DIRECT_COST_Actual.Replace(",", ""))).ToListAsync()).Sum();
                }
                return new { reserveOilCondensate = Math.Round(reserveOilCondensate), reserveAGNAG = Math.Round(reserveAGNAG), prodCost = Math.Round(prodCost)} ;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }


        [HttpGet("COMPANY_MONTHLY_PRODUCTION")]
        public async Task<object> COMPANY_MONTHLY_PRODUCTION(string year)
        {
            var ProdList = new List<object>();
            var months = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select a.Production_month).ToListAsync()).Distinct();
            foreach (var month in months) {
                var prodMonth = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Production_month == month && a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {prodMonth = prodMonth, month = month});
            }
            return ProdList;
        }
        
        [HttpGet("COMPANY_MONTHLY_PRODUCTION_PROPOSED")]
        public async Task<object> COMPANY_MONTHLY_PRODUCTION_PROPOSED(string year)
        {
            var ProdList = new List<object>();
            var months = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select a.Production_month).ToListAsync()).Distinct();
            foreach (var month in months) {
                var prodMonth = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where a.Production_month == month && a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {prodMonth = prodMonth, month = month});
            }
            return ProdList;
        }

        [HttpGet("COMPANY_CONCESSION_PRODUCTION")]
        public async Task<object> COMPANY_CONCESSION_PRODUCTION(string year)
        {
            var ProdList = new List<object>();
            var contractList = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select a.OML_Name).ToListAsync()).Distinct();
            foreach (var conType in contractList) {
                var prod = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.OML_Name == conType && a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {omlname = conType, prod = prod});
            }
            return ProdList;
        }
        
        [HttpGet("COMPANY_CONCESSION_PRODUCTION_PROPOSED")]
        public async Task<object> COMPANY_CONCESSION_PRODUCTION_PROPOSED(string year)
        {
            var ProdList = new List<object>();
            var contractList = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select a.OML_Name).ToListAsync()).Distinct();
            foreach (var conType in contractList) {
                var prod = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where a.OML_Name == conType && a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {omlname = conType, prod = prod});
            }
            return ProdList;
        }

        [HttpGet("COMPANY_CONCESSION_RESERVE")]
        public async Task<object> COMPANY_CONCESSION_RESERVE(string year)
        {
            var ProdList = new List<object>();
            var contractList = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.COMPANY_ID == WKPCompanyId && a.Company_Reserves_Year == year select a.OML_Name).ToListAsync()).Distinct();
            foreach (var conType in contractList) {
                var reserve = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.OML_Name == conType && a.COMPANY_ID == WKPCompanyId && a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_Oil.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_Condensate.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {omlname = conType, reserve = reserve});
            }
            return ProdList;
        }
        
        [HttpGet("COMPANY_PRODUCTION_OIL_CONDENSATE_PROPOSED")]
        public async Task<object> COMPANY_PRODUCTION_OIL_CONDENSATE_PROPOSED(string year)
        {
            var ProdList = new List<object>();
            var contractList = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select a.OML_Name).ToListAsync()).Distinct();
            foreach (var conType in contractList) {
                var reserve = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where a.OML_Name == conType && a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.Company_Oil.Replace(",", "")) + Convert.ToDouble(a.Company_Condensate.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {omlname = conType, reserve = reserve});
            }
            return ProdList;
        }

        [HttpGet("COMPANY_CONCESSION_RESERVE_GAS")]
        public async Task<object> COMPANY_CONCESSION_RESERVE_GAS(string year)
        {
            var ProdList = new List<object>();
            var contractList = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.COMPANY_ID == WKPCompanyId && a.Company_Reserves_Year == year select a.OML_Name).ToListAsync()).Distinct();
            foreach (var conType in contractList) {
                var reserve = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.OML_Name == conType && a.COMPANY_ID == WKPCompanyId && a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_AG.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_NAG.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {omlname = conType, reserve = reserve});
            }
            return ProdList;
        }

        [HttpGet("COMPANY_GAS_PRODUCTION_ACTIVITIE_PROPOSED")]
        public async Task<object> COMPANY_GAS_PRODUCTION_ACTIVITIE_PROPOSED(string year)
        {
            var ProdList = new List<object>();
            var contractList = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select a.OML_Name).ToListAsync()).Distinct();
            foreach (var conType in contractList)
            {
                var reserve = (await (from a in _context.GAS_PRODUCTION_ACTIVITIEs where a.OML_Name == conType && a.COMPANY_ID == WKPCompanyId && a.Year_of_WP == year select Convert.ToDouble(a.proposed_production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new { omlname = conType, reserve = reserve });
            }
            return ProdList;
            
        }


        [HttpGet("TOTAL_MONTHLY_PRODUCTION")]
        public async Task<object> TOTAL_MONTHLY_PRODUCTION(string year)
        {
            var ProdList = new List<object>();
            var months = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Year_of_WP == year select a.Production_month).ToListAsync()).Distinct();
            foreach (var month in months) {
                var prodMonth = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Production_month == month && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {prodMonth = prodMonth, month = month});
            }
            return ProdList;
        }

        [HttpGet("TOTAL_MONTHLY_PRODUCTION_BY_TERRAIN")]
        public async Task<object> TOTAL_MONTHLY_PRODUCTION_BY_TERRAIN(string year)
        {
            var ProdList = new List<object>();
            var terrains = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Year_of_WP == year select a.Terrain).ToListAsync()).Distinct();
            foreach (var terrain in terrains) {
                var prodMonth = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Terrain == terrain && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {prodMonth = prodMonth, terrain = terrain});
            }
            return ProdList;
        }


        [HttpGet("TOTAL_CONCESSION_RESERVE_BY_TERRAIN")]
        public async Task<object> TOTAL_CONCESSION_RESERVE(string year)
        {
            var ProdList = new List<object>();
            var terrains = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.Company_Reserves_Year == year select a.Terrain).ToListAsync()).Distinct();
            foreach (var terrain in terrains) {
                var reserve = (await (from a in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where a.Terrain == terrain && a.Company_Reserves_Year == year select Convert.ToDouble(a.Company_Reserves_Oil.Replace(",", "")) + Convert.ToDouble(a.Company_Reserves_Condensate.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {terrain = terrain, reserve = reserve});
            }
            return ProdList;
        }

        [HttpGet("TOTAL_CONCESSION_RESERVE_BY_CONTRACTTYPE")]
        public async Task<object> TOTAL_CONCESSION_RESERVE_BY_CONTRACTTYPE(string year)
        {
            var ProdList = new List<object>();
            var contractTypes = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Year_of_WP == year select a.Contract_Type).ToListAsync()).Distinct();
            foreach (var contractType in contractTypes) {
                var reserve = (await (from a in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where a.Contract_Type == contractType && a.Year_of_WP == year select Convert.ToDouble(a.Production.Replace(",", ""))).ToListAsync()).Sum();
                ProdList.Add(new {contractType = contractType, prod = reserve});
            }
            return ProdList;
        }

        [HttpGet("GET_ADMIN_CHARTDATA")]
        public async Task<object> GET_ADMIN_CHARTDATA(string year)
        {
            var prodByMonth = await TOTAL_MONTHLY_PRODUCTION(year);
            var prodByTerrain = await TOTAL_MONTHLY_PRODUCTION_BY_TERRAIN(year);
            var reserveByTerrain = await TOTAL_CONCESSION_RESERVE(year);
            var reserveByContract = await TOTAL_CONCESSION_RESERVE_BY_CONTRACTTYPE(year);

            return new {prodByMonth = prodByMonth, prodByTerrain = prodByTerrain, reserveByTerrain = reserveByTerrain, reserveByContract = reserveByContract};
        }


        

    }
}

