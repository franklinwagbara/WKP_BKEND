using Microsoft.AspNetCore.Mvc;
using Backend_UMR_Work_Program.Models;
using static Backend_UMR_Work_Program.Models.GeneralModel;
using AutoMapper;
using System.Security.Claims;
using Backend_UMR_Work_Program.DataModels;

namespace Backend_UMR_Work_Program.Services
{
    public class DatabaseService : BackgroundService, IDisposable
    {

        private Account _account;
        public WKP_DBContext _context;
        public IConfiguration _configuration;
        private readonly IServiceScopeFactory _scopeFactory;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public DatabaseService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<WKP_DBContext>();

                //while (!stoppingToken.IsCancellationRequested)
                //{

                //    //var getProducedWater =


                //    //Company Number section

                //    var companyInformation = (from c in _context.ADMIN_COMPANY_INFORMATIONs
                //                              //where c.EMAIL == "Simon.njoku@shell.com"
                //                              select c).ToList();

                //    companyInformation.ForEach(company =>
                //    {

                //        //CONCESSION_SITUATIONs
                //        var CONCESSION_SITUATIONs = (from c in _context.CONCESSION_SITUATIONs
                //                                     where c.Companyemail.ToLower() == company.EMAIL.ToLower()
                //                                     || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                     select c).ToList();
                //        if (CONCESSION_SITUATIONs.Count > 0)
                //        {
                //            CONCESSION_SITUATIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                //        var GEOPHYSICAL_ACTIVITIES_ACQUISITIONs = (from c in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs
                //                                                   where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                   select c).ToList();
                //        if (GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Count > 0)
                //        {
                //            GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();
                //            });
                //        }
                //        //GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                //        var GEOPHYSICAL_ACTIVITIES_PROCESSINGs = (from c in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs
                //                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                  select c).ToList();
                //        if (GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Count > 0)
                //        {
                //            GEOPHYSICAL_ACTIVITIES_PROCESSINGs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //DRILLING_OPERATIONS_CATEGORIES_OF_WELLs
                //        var DRILLING_OPERATIONS_CATEGORIES_OF_WELLs = (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs
                //                                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                       select c).ToList();
                //        if (DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Count > 0)
                //        {
                //            DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //DRILLING_EACH_WELL_COSTs
                //        var DRILLING_EACH_WELL_COSTs = (from c in _context.DRILLING_EACH_WELL_COSTs
                //                                        where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                        select c).ToList();
                //        if (DRILLING_EACH_WELL_COSTs.Count > 0)
                //        {
                //            DRILLING_EACH_WELL_COSTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //DRILLING_EACH_WELL_COST_PROPOSEDs
                //        var DRILLING_EACH_WELL_COST_PROPOSEDs = (from c in _context.DRILLING_EACH_WELL_COST_PROPOSEDs
                //                                                 where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                 select c).ToList();
                //        if (DRILLING_EACH_WELL_COST_PROPOSEDs.Count > 0)
                //        {
                //            DRILLING_EACH_WELL_COST_PROPOSEDs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }


                //        //INITIAL_WELL_COMPLETION_JOBs
                //        var INITIAL_WELL_COMPLETION_JOBs = (from c in _context.INITIAL_WELL_COMPLETION_JOBs1
                //                                            where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                            select c).ToList();
                //        if (INITIAL_WELL_COMPLETION_JOBs.Count > 0)
                //        {
                //            INITIAL_WELL_COMPLETION_JOBs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //WORKOVERS_RECOMPLETION_JOBs1
                //        var WORKOVERS_RECOMPLETION_JOBs1 = (from c in _context.WORKOVERS_RECOMPLETION_JOBs1
                //                                            where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                            select c).ToList();
                //        if (WORKOVERS_RECOMPLETION_JOBs1.Count > 0)
                //        {
                //            WORKOVERS_RECOMPLETION_JOBs1.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs
                //        var FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs = (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs
                //                                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                         select c).ToList();
                //        if (FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.Count > 0)
                //        {
                //            FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs
                //        var FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs = (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs
                //                                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                       select c).ToList();
                //        if (FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.Count > 0)
                //        {
                //            FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }


                //        //FIELD_DEVELOPMENT_FIELDS_AND_STATUSes
                //        var FIELD_DEVELOPMENT_FIELDS_AND_STATUSes = (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes
                //                                                     where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                     select c).ToList();
                //        if (FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.Count > 0)
                //        {
                //            FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //RESERVES_UPDATES_LIFE_INDices
                //        var RESERVES_UPDATES_LIFE_INDices = (from c in _context.RESERVES_UPDATES_LIFE_INDices
                //                                             where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                             select c).ToList();
                //        if (RESERVES_UPDATES_LIFE_INDices.Count > 0)
                //        {
                //            RESERVES_UPDATES_LIFE_INDices.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //FIELD_DEVELOPMENT_PLANs
                //        var FIELD_DEVELOPMENT_PLANs = (from c in _context.FIELD_DEVELOPMENT_PLANs
                //                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                       select c).ToList();
                //        if (FIELD_DEVELOPMENT_PLANs.Count > 0)
                //        {
                //            FIELD_DEVELOPMENT_PLANs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //OIL_CONDENSATE_PRODUCTION_ACTIVITIEs
                //        var OIL_CONDENSATE_PRODUCTION_ACTIVITIEs = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs
                //                                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                    select c).ToList();
                //        if (OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.Count > 0)
                //        {
                //            OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs
                //        var OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs
                //                                                                 where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                 select c).ToList();
                //        if (OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.Count > 0)
                //        {
                //            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //GAS_PRODUCTION_ACTIVITIEs
                //        var GAS_PRODUCTION_ACTIVITIEs = (from c in _context.GAS_PRODUCTION_ACTIVITIEs
                //                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                         select c).ToList();
                //        if (GAS_PRODUCTION_ACTIVITIEs.Count > 0)
                //        {
                //            GAS_PRODUCTION_ACTIVITIEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //NDRs
                //        var NDRs = (from c in _context.NDRs
                //                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                    select c).ToList();
                //        if (NDRs.Count > 0)
                //        {
                //            NDRs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs
                //        var RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs
                //                                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                  select c).ToList();
                //        if (RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Count > 0)
                //        {
                //            RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections
                //        var RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections
                //                                                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                    select c).ToList();
                //        if (RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.Count > 0)
                //        {
                //            RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs
                //        var OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs
                //                                                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                          select c).ToList();
                //        if (OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Count > 0)
                //        {
                //            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs
                //        var RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs
                //                                                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                          select c).ToList();
                //        if (RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.Count > 0)
                //        {
                //            RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs
                //        var RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs
                //                                                                 where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                 select c).ToList();
                //        if (RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.Count > 0)
                //        {
                //            RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions
                //        var RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions
                //                                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                  select c).ToList();
                //        if (RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.Count > 0)
                //        {
                //            RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
                //        var OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
                //                                                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                       select c).ToList();
                //        if (OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.Count > 0)
                //        {
                //            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //RESERVES_REPLACEMENT_RATIOs
                //        var RESERVES_REPLACEMENT_RATIOs = (from c in _context.RESERVES_REPLACEMENT_RATIOs
                //                                           where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                           select c).ToList();
                //        if (RESERVES_REPLACEMENT_RATIOs.Count > 0)
                //        {
                //            RESERVES_REPLACEMENT_RATIOs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs
                //        var OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs
                //                                                                                 where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                                 select c).ToList();
                //        if (OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Count > 0)
                //        {
                //            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies
                //        var GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies = (from c in _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies
                //                                                           where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                           select c).ToList();
                //        if (GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.Count > 0)
                //        {
                //            GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //BUDGET_ACTUAL_EXPENDITUREs
                //        var BUDGET_ACTUAL_EXPENDITUREs = (from c in _context.BUDGET_ACTUAL_EXPENDITUREs
                //                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                          select c).ToList();
                //        if (BUDGET_ACTUAL_EXPENDITUREs.Count > 0)
                //        {
                //            BUDGET_ACTUAL_EXPENDITUREs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs
                //        var BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs = (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs
                //                                                              where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                              select c).ToList();
                //        if (BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Count > 0)
                //        {
                //            BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs
                //        var BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs = (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs
                //                                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                         select c).ToList();
                //        if (BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Count > 0)
                //        {
                //            BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs
                //        var BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs = (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs
                //                                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                  select c).ToList();
                //        if (BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Count > 0)
                //        {
                //            BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //BUDGET_PERFORMANCE_PRODUCTION_COSTs
                //        var BUDGET_PERFORMANCE_PRODUCTION_COSTs = (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs
                //                                                   where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                   select c).ToList();
                //        if (BUDGET_PERFORMANCE_PRODUCTION_COSTs.Count > 0)
                //        {
                //            BUDGET_PERFORMANCE_PRODUCTION_COSTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs
                //        var BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs = (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs
                //                                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                  select c).ToList();
                //        if (BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Count > 0)
                //        {
                //            BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs
                //        var OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs
                //                                                             where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                             select c).ToList();
                //        if (OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.Count > 0)
                //        {
                //            OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments
                //        var OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments
                //                                                                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                                          select c).ToList();
                //        if (OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Count > 0)
                //        {
                //            OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs
                //        var OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs
                //                                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                         select c).ToList();
                //        if (OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Count > 0)
                //        {
                //            OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //FACILITIES_PROJECT_PERFORMANCEs
                //        var FACILITIES_PROJECT_PERFORMANCEs = (from c in _context.FACILITIES_PROJECT_PERFORMANCEs
                //                                               where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                               select c).ToList();
                //        if (FACILITIES_PROJECT_PERFORMANCEs.Count > 0)
                //        {
                //            FACILITIES_PROJECT_PERFORMANCEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //BUDGET_CAPEX_OPices
                //        var BUDGET_CAPEX_OPices = (from c in _context.BUDGET_CAPEX_OPices
                //                                   where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                   select c).ToList();
                //        if (BUDGET_CAPEX_OPices.Count > 0)
                //        {
                //            BUDGET_CAPEX_OPices.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //NIGERIA_CONTENT_Trainings
                //        var NIGERIA_CONTENT_Trainings = (from c in _context.NIGERIA_CONTENT_Trainings
                //                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                         select c).ToList();
                //        if (NIGERIA_CONTENT_Trainings.Count > 0)
                //        {
                //            NIGERIA_CONTENT_Trainings.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //NIGERIA_CONTENT_Upload_Succession_Plans
                //        var NIGERIA_CONTENT_Upload_Succession_Plans = (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans
                //                                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                       select c).ToList();
                //        if (NIGERIA_CONTENT_Upload_Succession_Plans.Count > 0)
                //        {
                //            NIGERIA_CONTENT_Upload_Succession_Plans.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //NIGERIA_CONTENT_QUESTIONs
                //        var NIGERIA_CONTENT_QUESTIONs = (from c in _context.NIGERIA_CONTENT_QUESTIONs
                //                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                         select c).ToList();
                //        if (NIGERIA_CONTENT_QUESTIONs.Count > 0)
                //        {
                //            NIGERIA_CONTENT_QUESTIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //LEGAL_LITIGATIONs
                //        var LEGAL_LITIGATIONs = (from c in _context.LEGAL_LITIGATIONs
                //                                 where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                 select c).ToList();
                //        if (LEGAL_LITIGATIONs.Count > 0)
                //        {
                //            LEGAL_LITIGATIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //LEGAL_ARBITRATIONs
                //        var LEGAL_ARBITRATIONs = (from c in _context.LEGAL_ARBITRATIONs
                //                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                  select c).ToList();
                //        if (LEGAL_ARBITRATIONs.Count > 0)
                //        {
                //            LEGAL_ARBITRATIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //STRATEGIC_PLANS_ON_COMPANY_BAses
                //        var STRATEGIC_PLANS_ON_COMPANY_BAses = (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses
                //                                                where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                select c).ToList();
                //        if (STRATEGIC_PLANS_ON_COMPANY_BAses.Count > 0)
                //        {
                //            STRATEGIC_PLANS_ON_COMPANY_BAses.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //HSE_QUESTIONs
                //        var HSE_QUESTIONs = (from c in _context.HSE_QUESTIONs
                //                             where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                             select c).ToList();
                //        if (HSE_QUESTIONs.Count > 0)
                //        {
                //            HSE_QUESTIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_FATALITIEs
                //        var HSE_FATALITIEs = (from c in _context.HSE_FATALITIEs
                //                              where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                              select c).ToList();
                //        if (HSE_FATALITIEs.Count > 0)
                //        {
                //            HSE_FATALITIEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_DESIGNS_SAFETies
                //        var HSE_DESIGNS_SAFETies = (from c in _context.HSE_DESIGNS_SAFETies
                //                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                    select c).ToList();
                //        if (HSE_DESIGNS_SAFETies.Count > 0)
                //        {
                //            HSE_DESIGNS_SAFETies.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_SAFETY_STUDIES_NEWs
                //        var HSE_SAFETY_STUDIES_NEWs = (from c in _context.HSE_SAFETY_STUDIES_NEWs
                //                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                       select c).ToList();
                //        if (HSE_SAFETY_STUDIES_NEWs.Count > 0)
                //        {
                //            HSE_SAFETY_STUDIES_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_INSPECTION_AND_MAINTENANCE_NEWs
                //        var HSE_INSPECTION_AND_MAINTENANCE_NEWs = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_NEWs
                //                                                   where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                   select c).ToList();
                //        if (HSE_INSPECTION_AND_MAINTENANCE_NEWs.Count > 0)
                //        {
                //            HSE_INSPECTION_AND_MAINTENANCE_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs
                //        var HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs = (from c in _context.HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs
                //                                                                 where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                 select c).ToList();
                //        if (HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.Count > 0)
                //        {
                //            HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs
                //        var HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs = (from c in _context.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs
                //                                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                         select c).ToList();
                //        if (HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.Count > 0)
                //        {
                //            HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs
                //        var HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs
                //                                                                                           where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                                           select c).ToList();
                //        if (HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Count > 0)
                //        {
                //            HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_OIL_SPILL_REPORTING_NEWs
                //        var HSE_OIL_SPILL_REPORTING_NEWs = (from c in _context.HSE_OIL_SPILL_REPORTING_NEWs
                //                                            where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                            select c).ToList();
                //        if (HSE_OIL_SPILL_REPORTING_NEWs.Count > 0)
                //        {
                //            HSE_OIL_SPILL_REPORTING_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs
                //        var HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs = (from c in _context.HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs
                //                                                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                                  select c).ToList();
                //        if (HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.Count > 0)
                //        {
                //            HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                //        var HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs
                //                                                     where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                     select c).ToList();
                //        if (HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.Count > 0)
                //        {
                //            HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs
                //        var HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs = (from c in _context.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs
                //                                                                      where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                      select c).ToList();
                //        if (HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.Count > 0)
                //        {
                //            HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs
                //        var HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs = (from c in _context.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs
                //                                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                  select c).ToList();
                //        if (HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.Count > 0)
                //        {
                //            HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_ENVIRONMENTAL_STUDIES_NEWs
                //        var HSE_ENVIRONMENTAL_STUDIES_NEWs = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEWs
                //                                              where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                              select c).ToList();
                //        if (HSE_ENVIRONMENTAL_STUDIES_NEWs.Count > 0)
                //        {
                //            HSE_ENVIRONMENTAL_STUDIES_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //HSE_WASTE_MANAGEMENT_NEWs
                //        var HSE_WASTE_MANAGEMENT_NEWs = (from c in _context.HSE_WASTE_MANAGEMENT_NEWs
                //                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                         select c).ToList();
                //        if (HSE_WASTE_MANAGEMENT_NEWs.Count > 0)
                //        {
                //            HSE_WASTE_MANAGEMENT_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs
                //        var HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs = (from c in _context.HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs
                //                                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                          select c).ToList();
                //        if (HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.Count > 0)
                //        {
                //            HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_PRODUCED_WATER_MANAGEMENT_NEWs
                //        var HSE_PRODUCED_WATER_MANAGEMENT_NEWs = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEWs
                //                                                  where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                  select c).ToList();
                //        if (HSE_PRODUCED_WATER_MANAGEMENT_NEWs.Count > 0)
                //        {
                //            HSE_PRODUCED_WATER_MANAGEMENT_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs
                //        var HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs
                //                                                            where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                            select c).ToList();
                //        if (HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.Count > 0)
                //        {
                //            HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs
                //        var HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs
                //                                                                       where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                       select c).ToList();
                //        if (HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.Count > 0)
                //        {
                //            HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs
                //        var HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs
                //                                                                                         where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                                         select c).ToList();
                //        if (HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.Count > 0)
                //        {
                //            HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs
                //        var HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs = (from c in _context.HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs
                //                                                      where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                      select c).ToList();
                //        if (HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.Count > 0)
                //        {
                //            HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_OSP_REGISTRATIONS_NEWs
                //        var HSE_OSP_REGISTRATIONS_NEWs = (from c in _context.HSE_OSP_REGISTRATIONS_NEWs
                //                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                          select c).ToList();
                //        if (HSE_OSP_REGISTRATIONS_NEWs.Count > 0)
                //        {
                //            HSE_OSP_REGISTRATIONS_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs
                //        var HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs = (from c in _context.HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs
                //                                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                          select c).ToList();
                //        if (HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.Count > 0)
                //        {
                //            HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs
                //        var HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs = (from c in _context.HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs
                //                                                                           where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                           select c).ToList();
                //        if (HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.Count > 0)
                //        {
                //            HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_CAUSES_OF_SPILLs
                //        var HSE_CAUSES_OF_SPILLs = (from c in _context.HSE_CAUSES_OF_SPILLs
                //                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                    select c).ToList();
                //        if (HSE_CAUSES_OF_SPILLs.Count > 0)
                //        {
                //            HSE_CAUSES_OF_SPILLs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }//HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs
                //        var HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs
                //                                                                          where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                          select c).ToList();
                //        if (HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.Count > 0)
                //        {
                //            HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }

                //        //HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs
                //        var HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs = (from c in _context.HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs
                //                                                                                        where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                                                        select c).ToList();
                //        if (HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.Count > 0)
                //        {
                //            HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_MANAGEMENT_POSITIONs
                //        var HSE_MANAGEMENT_POSITIONs = (from c in _context.HSE_MANAGEMENT_POSITIONs
                //                                        where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                        select c).ToList();
                //        if (HSE_MANAGEMENT_POSITIONs.Count > 0)
                //        {
                //            HSE_MANAGEMENT_POSITIONs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_QUALITY_CONTROLs
                //        var HSE_QUALITY_CONTROLs = (from c in _context.HSE_QUALITY_CONTROLs
                //                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                    select c).ToList();
                //        if (HSE_QUALITY_CONTROLs.Count > 0)
                //        {
                //            HSE_QUALITY_CONTROLs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_CLIMATE_CHANGE_AND_AIR_QUALITies
                //        var HSE_CLIMATE_CHANGE_AND_AIR_QUALITies = (from c in _context.HSE_CLIMATE_CHANGE_AND_AIR_QUALITies
                //                                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                    select c).ToList();
                //        if (HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.Count > 0)
                //        {
                //            HSE_CLIMATE_CHANGE_AND_AIR_QUALITies.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_SAFETY_CULTURE_TRAININGs
                //        var HSE_SAFETY_CULTURE_TRAININGs = (from c in _context.HSE_SAFETY_CULTURE_TRAININGs
                //                                            where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                            select c).ToList();
                //        if (HSE_SAFETY_CULTURE_TRAININGs.Count > 0)
                //        {
                //            HSE_SAFETY_CULTURE_TRAININGs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs
                //        var HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs = (from c in _context.HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs
                //                                                   where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                   select c).ToList();
                //        if (HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.Count > 0)
                //        {
                //            HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        } //HSE_WASTE_MANAGEMENT_SYSTEMs
                //        var HSE_WASTE_MANAGEMENT_SYSTEMs = (from c in _context.HSE_WASTE_MANAGEMENT_SYSTEMs
                //                                            where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                            select c).ToList();
                //        if (HSE_WASTE_MANAGEMENT_SYSTEMs.Count > 0)
                //        {
                //            HSE_WASTE_MANAGEMENT_SYSTEMs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs
                //        var HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs = (from c in _context.HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs
                //                                                    where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                    select c).ToList();
                //        if (HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.Count > 0)
                //        {
                //            HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        } //PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs
                //        var PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs = (from c in _context.PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs
                //                                                             where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //                                                             select c).ToList();
                //        if (PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.Count > 0)
                //        {
                //            PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs.ForEach(x =>
                //            {
                //                x.CompanyNumber = company.Id;
                //                int save = _context.SaveChanges();

                //            });
                //        }
                //        //CONCESSION_SITUATIONs
                //        //var CONCESSION_SITUATIONs = (from c in _context.CONCESSION_SITUATIONs
                //        //                             where c.Companyemail.ToLower() == company.EMAIL.ToLower() || c.CompanyName.ToLower() == company.NAME.ToLower()
                //        //                             select c).ToList();
                //        //if (CONCESSION_SITUATIONs.Count > 0)
                //        //{
                //        //    CONCESSION_SITUATIONs.ForEach(x =>
                //        //    {
                //        //        x.CompanyNumber = company.Id;
                //        //        int save = _context.SaveChanges();

                //        //    });
                //        //}

                //    });

                //}
            }
            catch (Exception e)
            {

            }
        }
    }
}