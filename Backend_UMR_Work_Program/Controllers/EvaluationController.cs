using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private Account _account;
        public WKP_DBContext _context;

        public EvaluationController(WKP_DBContext context, Account account)
        {
            _account = account;
            _context = context;
        }

        [HttpGet("Best10_OPLAcquisitionIndex")]
        public async Task<object> Best10_OPLAcquisitionIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where a.Year_of_WP == year && a.OML_Name.ToLower().Contains("opl") select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;


                while (i < reel.Count())
                {
                    double acq = (Convert.ToInt64(reel[i].Quantum) / Convert.ToInt64(reel[i].Quantum_Planned)) * 100;
                    acqlist.Add(acq);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("Best10_OPLExploratoryIndex")]
        public async Task<object> Best10OPLExploratoryIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.CONCESSION_SITUATIONs where a.Year == year select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    var drillingFieldPresent = Convert.ToInt32(reel[i].No_of_discovered_field) > 0 ? 100 : 0;
                    acqlist.Add(drillingFieldPresent);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Best10_OPLDiscoveryIndex")]
        public async Task<object> Best10OPLDiscoveryIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.CONCESSION_SITUATIONs where a.Year == year select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    var discoveredFieldPresent = Convert.ToInt32(reel[i].No_of_discovered_field) > 0 ? 100 : 0;
                    acqlist.Add(discoveredFieldPresent);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Best10_OPLConcessionRentalsIndex")]
        public async Task<object> Best10OPLConcessionRentalsIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.CONCESSION_SITUATIONs where a.Year == year select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    var concessionRentalPaid = Convert.ToInt32(reel[i].Has_the_Concession_Rentals_been_paid) > 0 ? 100 : 0;
                    acqlist.Add(concessionRentalPaid);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Best10_OMLAcquisitionIndex")]
        public async Task<object> Best10OMLAcquisitionIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where a.Year_of_WP == year && a.OML_Name.ToLower().Contains("oml") select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    double acq = (Convert.ToInt64(reel[i].Quantum) / Convert.ToInt64(reel[i].Quantum_Planned)) * 100;
                    acqlist.Add(acq);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Best10_OMLExploratoryIndex")]
        public async Task<object> Best10OMLExploratoryIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.CONCESSION_SITUATIONs where a.Year == year select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    var drillingFieldPresent = Convert.ToInt32(reel[i].No_of_discovered_field) > 0 ? 100 : 0;
                    acqlist.Add(drillingFieldPresent);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Best10_OMLDiscoveryIndex")]
        public async Task<object> Best10OMLDiscoveryIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.CONCESSION_SITUATIONs where a.Year == year select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    var discoveredFieldPresent = Convert.ToInt32(reel[i].No_of_discovered_field) > 0 ? 100 : 0;
                    acqlist.Add(discoveredFieldPresent);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Best10_OMLConcessionRentalsIndex")]
        public async Task<object> Best10OMLConcessionRentalsIndex(string year)
        {
            try
            {
                var reel = await (from a in _context.CONCESSION_SITUATIONs where a.Year == year select a).ToListAsync();
                var acqlist = new List<double>();
                long value = 0;
                int i = 0;

                while (i < reel.Count())
                {
                    var concessionRentalPaid = Convert.ToInt32(reel[i].Has_the_Concession_Rentals_been_paid) > 0 ? 100 : 0;
                    acqlist.Add(concessionRentalPaid);
                    i++;
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        //By Adeola
        [HttpGet("Best10_Concession_RoyaltyPayment_Index")]
        public async Task<object> Best10_OML_RoyaltyPayment_Index(string year, string type)
        {
            try
            {
                var data = await (from a in _context.CONCESSION_SITUATIONs
                                  join comp in _context.ADMIN_COMPANY_INFORMATIONs on a.CompanyNumber equals comp.Id
                                  join ry in _context.Royalties on a.Id equals ry.Concession_ID
                                  where a.Year == year && a.Consession_Type == type
                                  select new
                                  {
                                      a,
                                      ry,
                                      comp
                                  }).ToListAsync();
                var acqlist = new List<Concession_Index>();
                int i = 0;

                while (i < data.Count())
                {
                    var concessionRentalPaid = data[i].ry.Gas_Flare_Payment == "true" ? 100 : 0;
                    acqlist.Add(new Concession_Index()
                    {
                        companyName = data[i].comp.COMPANY_NAME,
                        concessionName = data[i].a.OML_Name,
                        concessionType = "OML",
                        royaltyPayment_Index = concessionRentalPaid
                    });
                }

                acqlist.Sort();
                return acqlist.Take(10);
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("Concession_RRR_Index")]
        public async Task<object> Concession_RRR_Index(string year, string type)
        {
            try
            {
                //variable declaration
                int N = int.Parse(year);
                double NetProduction_PY;
                double TwoP_Reserves_CurrentYear;
                double TwoP_Reserves_PreviousYear;

                var netProduction_Data = await (from conc in _context.CONCESSION_SITUATIONs
                                                join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
                                                join reserve in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs on conc.Id.ToString() equals reserve.OML_ID
                                                join reserveStatus in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs on conc.Id.ToString() equals reserveStatus.OML_ID
                                                where (reserve.Year_of_WP == year || reserve.Year_of_WP == (N - 1).ToString()) && conc.Consession_Type == type
                                                select new
                                                {
                                                    year = reserve.Year_of_WP,
                                                    conc = conc,
                                                    reserve = reserve,
                                                    reserveStatus = reserveStatus,
                                                    comp
                                                }).ToListAsync();

                var acqlist = new List<Concession_Index>();
                int i = 0;

                netProduction_Data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
                {
                    double oil_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Oil));
                    double AG_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_AG));
                    double NAG_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_NAG));
                    double Condensate_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Condensate));
                    NetProduction_PY = oil_NetProduction_PY + AG_NetProduction_PY + NAG_NetProduction_PY + Condensate_NetProduction_PY;

                    double oil_Reserve_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualOilProduction));
                    var AG_Reserve_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualOilProduction));
                    double NAG_Reserve_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualOilProduction));
                    double Condensate_Reserve_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualCondensateProduction));
                    TwoP_Reserves_PreviousYear = oil_Reserve_PY + AG_Reserve_PY + NAG_Reserve_PY + Condensate_Reserve_PY;

                    double oil_Reserve = key.Where(x => x.year.ToString() == N.ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualOilProduction));
                    double AG_Reserve = key.Where(x => x.year.ToString() == N.ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualGasProduction));
                    double NAG_Reserve = key.Where(x => x.year.ToString() == N.ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualGasAGProduction));
                    double Condensate_Reserve = key.Where(x => x.year.ToString() == N.ToString()).Sum(x => double.Parse(x.reserveStatus.Company_Reserves_AnnualGasNAGProduction));
                    TwoP_Reserves_CurrentYear = oil_Reserve + AG_Reserve + NAG_Reserve + Condensate_Reserve;

                    double RRR_Cal = NetProduction_PY > 0 ? ((NetProduction_PY + TwoP_Reserves_CurrentYear - TwoP_Reserves_PreviousYear) / NetProduction_PY) : 0;
                    double RRR_index = RRR_Cal * 100;

                    acqlist.Add(new Concession_Index()
                    {
                        companyName = key?.FirstOrDefault()?.comp?.COMPANY_NAME,
                        concessionName = key?.FirstOrDefault()?.conc.OML_Name,
                        concessionType = type,
                        RRR_Index = RRR_index
                    });
                });
                return acqlist;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }

        [HttpGet("Concession_IncrementInProduction_Index")]
        public async Task<object> Concession_IncrementInProduction_Index(string year, string type)
        {
            try
            {
                //variable declaration
                int N = int.Parse(year);
                double NetProduction_PY;
                double NetProduction_CY;
                var netProduction_Data = await (from conc in _context.CONCESSION_SITUATIONs
                                                join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
                                                join reserve in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs on conc.Id.ToString() equals reserve.OML_ID
                                                where (reserve.Year_of_WP == year || reserve.Year_of_WP == (N - 1).ToString()) && conc.Consession_Type == type
                                                select new
                                                {
                                                    year = reserve.Year_of_WP,
                                                    conc = conc,
                                                    reserve = reserve,
                                                    comp
                                                }).ToListAsync();

                var acqlist = new List<Concession_Index>();
                int i = 0;
                netProduction_Data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
                {
                    double oil_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Oil));
                    double AG_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_AG));
                    double NAG_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_NAG));
                    double Condensate_NetProduction_PY = key.Where(x => x.year.ToString() == (N - 1).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Condensate));
                    NetProduction_PY = oil_NetProduction_PY + AG_NetProduction_PY + NAG_NetProduction_PY + Condensate_NetProduction_PY;

                    double oil_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Oil));
                    double AG_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_AG));
                    double NAG_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_NAG));
                    double Condensate_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Condensate));
                    NetProduction_CY = oil_NetProduction_CY + AG_NetProduction_CY + NAG_NetProduction_CY + Condensate_NetProduction_CY;

                    double netCal = NetProduction_CY > 0 ? ((NetProduction_PY + NetProduction_CY) / NetProduction_CY) : 0;
                    double II_Index = 100 * netCal;

                    acqlist.Add(new Concession_Index()
                    {
                        companyName = key?.FirstOrDefault()?.comp?.COMPANY_NAME,
                        concessionName = key?.FirstOrDefault()?.conc.OML_Name,
                        concessionType = type,
                        IncrementInProduction_Index = II_Index
                    });
                });
                return acqlist;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Concession_CostEfficieny_Index")]
        public async Task<object> Concession_CostEfficieny_Index(string year, string type)
        {
            try
            {
                int N = int.Parse(year);
                double NetProduction_CY;
                var netProduction_Data = await (from conc in _context.CONCESSION_SITUATIONs
                                                join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
                                                join reserve in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs on conc.Id.ToString() equals reserve.OML_ID
                                                join capex_opex in _context.BUDGET_CAPEX_OPices on conc.Id.ToString() equals capex_opex.OML_ID
                                                where (reserve.Year_of_WP == year || reserve.Year_of_WP == (N - 1).ToString()) && conc.Consession_Type == type
                                                select new
                                                {
                                                    year = reserve.Year_of_WP,
                                                    conc = conc,
                                                    reserve = reserve,
                                                    comp,
                                                    capex_opex
                                                }).ToListAsync();

                var acqlist = new List<Concession_Index>();
                int i = 0;
                netProduction_Data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
                {

                    double CAPEX = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Oil));
                    double OPEX = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_AG));

                    double oil_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Oil));
                    double AG_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_AG));
                    double NAG_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_NAG));
                    double Condensate_NetProduction_CY = key.Where(x => x.year.ToString() == (N).ToString()).Sum(x => double.Parse(x.reserve.Company_Annual_Condensate));
                    NetProduction_CY = oil_NetProduction_CY + AG_NetProduction_CY + NAG_NetProduction_CY + Condensate_NetProduction_CY;

                    double COPEX = CAPEX + OPEX;
                    double costEfficiency_Index = COPEX > 0 ? NetProduction_CY / COPEX : 0;

                    acqlist.Add(new Concession_Index()
                    {
                        companyName = key?.FirstOrDefault()?.comp?.COMPANY_NAME,
                        concessionName = key?.FirstOrDefault()?.conc.OML_Name,
                        concessionType = type,
                        costEfficiency_Index = costEfficiency_Index
                    });
                });
                return acqlist;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Concession_CSR_Index")]
        public async Task<object> Concession_CSR_Index(string year, string type)
        {
            try
            {
                int N = int.Parse(year);
                var data = await (from conc in _context.CONCESSION_SITUATIONs
                                  join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
                                  join csr in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs on conc.Id.ToString() equals csr.OML_ID
                                  where csr.Actual_proposed == GeneralModel.ActualYear && csr.Actual_Proposed_Year == year
                                  select new
                                  {
                                      year = year,
                                      conc = conc,
                                      csr = csr,
                                      comp
                                  }).ToListAsync();

                var acqlist = new List<Concession_Index>();
                int i = 0;
                data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
                {

                    double Actual_CSR = key.Sum(x => double.Parse(x.csr.Actual_Spent));
                    double Planned_CSR = key.Sum(x => double.Parse(x.csr.Budget_));

                    double CSR_Index = Planned_CSR > 0 ? Actual_CSR / Planned_CSR : 0;

                    acqlist.Add(new Concession_Index()
                    {
                        companyName = key?.FirstOrDefault()?.comp?.COMPANY_NAME,
                        concessionName = key?.FirstOrDefault()?.conc.OML_Name,
                        concessionType = type,
                        CSR_Index = CSR_Index
                    });
                });
                return acqlist;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
        [HttpGet("Concession_StatutoryPayment_Index")]
        public async Task<object> Concession_StatutoryPayment_Index(string year, string type)
        {
            try
            {
                int N = int.Parse(year);

                var data = await (from conc in _context.CONCESSION_SITUATIONs
                                  join comp in _context.ADMIN_COMPANY_INFORMATIONs on conc.COMPANY_ID equals comp.COMPANY_ID
                                  join csr in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs on conc.Id.ToString() equals csr.OML_ID
                                  where csr.Actual_proposed == GeneralModel.ActualYear && csr.Actual_Proposed_Year == year
                                  select new
                                  {
                                      year = year,
                                      conc = conc,
                                      csr = csr,
                                      comp
                                  }).ToListAsync();

                var acqlist = new List<Concession_Index>();
                int i = 0;
                data.GroupBy(x => x.conc.OML_ID).ToList().ForEach(key =>
                {

                    double Actual_CSR = key.Sum(x => double.Parse(x.csr.Actual_Spent));
                    double Planned_CSR = key.Sum(x => double.Parse(x.csr.Budget_));

                    double CSR_Index = Planned_CSR > 0 ? Actual_CSR / Planned_CSR : 0;

                    acqlist.Add(new Concession_Index()
                    {
                        companyName = key?.FirstOrDefault()?.comp?.COMPANY_NAME,
                        concessionName = key?.FirstOrDefault()?.conc.OML_Name,
                        concessionType = type,
                        CSR_Index = CSR_Index
                    });
                });
                return acqlist;
            }
            catch (Exception e)
            {
                return new WebApiResponse { ResponseCode = AppResponseCodes.InternalError, Message = "Error : " + e.Message, StatusCode = ResponseCodes.InternalError };
            }
        }
    }
}
