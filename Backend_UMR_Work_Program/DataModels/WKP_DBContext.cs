using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WKP_DBContext : DbContext
{
    public IConfiguration _configuration { get; }
    public WKP_DBContext()
    {
    }

    public WKP_DBContext(DbContextOptions<WKP_DBContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<ApplicationSBUApproval> ApplicationSBUApprovals { get; set; }
    public virtual DbSet<SBU_Submission> SBU_Submissions { get; set; }
    public virtual DbSet<ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE> ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSEs { get; set; }

    public virtual DbSet<ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE> ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCEs { get; set; }

    public virtual DbSet<ADMIN_BUDGET_CAPEX_OPEX> ADMIN_BUDGET_CAPEX_OPEXes { get; set; }

    public virtual DbSet<ADMIN_CATEGORy> ADMIN_CATEGORIEs { get; set; }

    public virtual DbSet<ADMIN_CHAIRPERSON> ADMIN_CHAIRPeople { get; set; }

    public virtual DbSet<ADMIN_COMPANYEMAIL_REMINDER_TABLE> ADMIN_COMPANYEMAIL_REMINDER_TABLEs { get; set; }

    public virtual DbSet<ADMIN_COMPANY_CODE> ADMIN_COMPANY_CODEs { get; set; }

    public virtual DbSet<ADMIN_COMPANY_DETAIL> ADMIN_COMPANY_DETAILs { get; set; }

    public virtual DbSet<ADMIN_COMPANY_INFORMATION> ADMIN_COMPANY_INFORMATIONs { get; set; }

    public virtual DbSet<ADMIN_COMPANY_INFORMATION_AUDIT> ADMIN_COMPANY_INFORMATION_AUDITs { get; set; }

    public virtual DbSet<ADMIN_COMPANY_INFORMATION_old_18052020> ADMIN_COMPANY_INFORMATION_old_18052020s { get; set; }

    public virtual DbSet<ADMIN_COMPLIANCE_INDEX_TABLE> ADMIN_COMPLIANCE_INDEX_TABLEs { get; set; }

    public virtual DbSet<ADMIN_CONCESSIONS_INFORMATION> ADMIN_CONCESSIONS_INFORMATIONs { get; set; }

    public virtual DbSet<ADMIN_CONCESSIONS_INFORMATION_AUDIT> ADMIN_CONCESSIONS_INFORMATION_AUDITs { get; set; }

    public virtual DbSet<ADMIN_CONCESSIONS_INFORMATION_BK_23112021> ADMIN_CONCESSIONS_INFORMATION_BK_23112021s { get; set; }

    public virtual DbSet<ADMIN_CONCESSIONS_INFORMATION_HISTORY> ADMIN_CONCESSIONS_INFORMATION_HISTORies { get; set; }

    public virtual DbSet<ADMIN_CONCESSIONS_INFORMATION_old_18052020> ADMIN_CONCESSIONS_INFORMATION_old_18052020s { get; set; }

    public virtual DbSet<ADMIN_CONCESSION_STATUS> ADMIN_CONCESSION_STATUSes { get; set; }

    public virtual DbSet<ADMIN_DATETIME_PRESENTATION> ADMIN_DATETIME_PRESENTATIONs { get; set; }

    public virtual DbSet<ADMIN_DEVELOPMENT_PLAN_STATUS> ADMIN_DEVELOPMENT_PLAN_STATUSes { get; set; }

    public virtual DbSet<ADMIN_DIVISIONAL_REPRESENTATIVE> ADMIN_DIVISIONAL_REPRESENTATIVEs { get; set; }

    public virtual DbSet<ADMIN_DIVISIONAL_REPS_PRESENTATION> ADMIN_DIVISIONAL_REPS_PRESENTATIONs { get; set; }

    public virtual DbSet<ADMIN_DIVISION_REP> ADMIN_DIVISION_REPs { get; set; }

    public virtual DbSet<ADMIN_DIVISION_REP_LIST> ADMIN_DIVISION_REP_LISTs { get; set; }

    public virtual DbSet<ADMIN_EMAIL_DAY> ADMIN_EMAIL_DAYs { get; set; }

    public virtual DbSet<ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING> ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOINGs { get; set; }

    public virtual DbSet<ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING> ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOINGs { get; set; }

    public virtual DbSet<ADMIN_ENVIROMENTAL_STUDy> ADMIN_ENVIROMENTAL_STUDIEs { get; set; }

    public virtual DbSet<ADMIN_ENVIRONMENTAL_STUDY> ADMIN_ENVIRONMENTAL_STUDies { get; set; }

    public virtual DbSet<ADMIN_FEILDDEVELOPMENTPLAN_WELLORGA> ADMIN_FEILDDEVELOPMENTPLAN_WELLORGAs { get; set; }

    public virtual DbSet<ADMIN_FIVE_YEAR_TREND> ADMIN_FIVE_YEAR_TRENDs { get; set; }

    public virtual DbSet<ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI> ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTIs { get; set; }

    public virtual DbSet<ADMIN_GASPRODUCTION_UTILIZED_MMSCF> ADMIN_GASPRODUCTION_UTILIZED_MMSCFs { get; set; }

    public virtual DbSet<ADMIN_HSE_CONDITION_OF_EQUIPMENT> ADMIN_HSE_CONDITION_OF_EQUIPMENTs { get; set; }

    public virtual DbSet<ADMIN_HSE_OSP_REGISTRATIONS_NEW> ADMIN_HSE_OSP_REGISTRATIONS_NEWs { get; set; }

    public virtual DbSet<ADMIN_HSE_OSP_REGISTRATIONS_NEW1> ADMIN_HSE_OSP_REGISTRATIONS_NEWs1 { get; set; }

    public virtual DbSet<ADMIN_INSPECTION_MAINTENANCE> ADMIN_INSPECTION_MAINTENANCEs { get; set; }

    public virtual DbSet<ADMIN_LIST_OF_OMLS_OPL> ADMIN_LIST_OF_OMLS_OPLs { get; set; }

    public virtual DbSet<ADMIN_LITIGATION_JURISDICTION> ADMIN_LITIGATION_JURISDICTIONs { get; set; }

    public virtual DbSet<ADMIN_MEETING_ROOM> ADMIN_MEETING_ROOMs { get; set; }

    public virtual DbSet<ADMIN_MONTH> ADMIN_MONTHs { get; set; }

    public virtual DbSet<ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facility> ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities { get; set; }

    public virtual DbSet<ADMIN_ONGOING_COMPLETED> ADMIN_ONGOING_COMPLETEDs { get; set; }

    public virtual DbSet<ADMIN_PERFOMANCE_INDEX> ADMIN_PERFOMANCE_INDices { get; set; }

    public virtual DbSet<ADMIN_PRESENTATION_CATEGORy> ADMIN_PRESENTATION_CATEGORIEs { get; set; }

    public virtual DbSet<ADMIN_PRESENTATION_TIME> ADMIN_PRESENTATION_TIMEs { get; set; }

    public virtual DbSet<ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO> ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TOs { get; set; }

    public virtual DbSet<ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT> ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORTs { get; set; }

    public virtual DbSet<ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE> ADMIN_PRODUCED_WATER_MANAGEMENT_ZONEs { get; set; }

    public virtual DbSet<ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water> ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_waters { get; set; }

    public virtual DbSet<ADMIN_PUBLIC_HOLIDAY> ADMIN_PUBLIC_HOLIDAYs { get; set; }

    public virtual DbSet<ADMIN_QUARTER> ADMIN_QUARTERs { get; set; }

    public virtual DbSet<ADMIN_REASON_FOR_ADDITION> ADMIN_REASON_FOR_ADDITIONs { get; set; }

    public virtual DbSet<ADMIN_REASON_FOR_DECLINE> ADMIN_REASON_FOR_DECLINEs { get; set; }

    public virtual DbSet<ADMIN_SCHEDULED_STATUS> ADMIN_SCHEDULED_STATUSes { get; set; }

    public virtual DbSet<ADMIN_SCRIBE> ADMIN_SCRIBEs { get; set; }

    public virtual DbSet<ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASI> ADMIN_STRATEGIC_PLANS_ON_COMPANY_BAses { get; set; }

    public virtual DbSet<ADMIN_SUBMISSION_WINDOW> ADMIN_SUBMISSION_WINDOWs { get; set; }

    public virtual DbSet<ADMIN_TRAINING_LOCAL_CONTENT> ADMIN_TRAINING_LOCAL_CONTENTs { get; set; }

    public virtual DbSet<ADMIN_TRAINING_NIGERIA_CONTENT> ADMIN_TRAINING_NIGERIA_CONTENTs { get; set; }

    public virtual DbSet<ADMIN_TYPE_OF_TEST> ADMIN_TYPE_OF_TESTs { get; set; }

    public virtual DbSet<ADMIN_Terrain> ADMIN_Terrains { get; set; }

    public virtual DbSet<ADMIN_WASTE_MANAGEMENT_FACILITY> ADMIN_WASTE_MANAGEMENT_FACILITies { get; set; }

    public virtual DbSet<ADMIN_WELL_CATEGORy> ADMIN_WELL_CATEGORIEs { get; set; }

    public virtual DbSet<ADMIN_WELL_TYPE> ADMIN_WELL_TYPEs { get; set; }

    public virtual DbSet<ADMIN_WELL_Trajectory> ADMIN_WELL_Trajectories { get; set; }

    public virtual DbSet<ADMIN_WORK_PROGRAM_REPORT> ADMIN_WORK_PROGRAM_REPORTs { get; set; }

    public virtual DbSet<ADMIN_WORK_PROGRAM_REPORT_History> ADMIN_WORK_PROGRAM_REPORT_Histories { get; set; }

    public virtual DbSet<ADMIN_WP_PENALTIES_AUDIT> ADMIN_WP_PENALTIES_AUDITs { get; set; }

    public virtual DbSet<ADMIN_WP_PENALTy> ADMIN_WP_PENALTIEs { get; set; }

    public virtual DbSet<ADMIN_WP_START_END_DATE> ADMIN_WP_START_END_DATEs { get; set; }

    public virtual DbSet<ADMIN_WP_START_END_DATE_AUDIT> ADMIN_WP_START_END_DATE_AUDITs { get; set; }

    public virtual DbSet<ADMIN_WP_START_END_DATE_DATA_UPLOAD> ADMIN_WP_START_END_DATE_DATA_UPLOADs { get; set; }

    public virtual DbSet<ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT> ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDITs { get; set; }

    public virtual DbSet<ADMIN_YEAR> ADMIN_YEARs { get; set; }

    public virtual DbSet<ADMIN_YES_NO> ADMIN_YES_NOs { get; set; }

    public virtual DbSet<ActualExpenditure> ActualExpenditures { get; set; }

    public virtual DbSet<ActualProposed_Year> ActualProposed_Years { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationCategory> ApplicationCategories { get; set; }

    public virtual DbSet<ApplicationDeskHistory> ApplicationDeskHistories { get; set; }

    public virtual DbSet<ApplicationDocument> ApplicationDocuments { get; set; }

    public virtual DbSet<ApplicationProccess> ApplicationProccesses { get; set; }

    public virtual DbSet<Appraisal_Drilling> Appraisal_Drillings { get; set; }

    public virtual DbSet<AuditTrail> AuditTrails { get; set; }

    public virtual DbSet<BUDGET_ACTUAL_EXPENDITURE> BUDGET_ACTUAL_EXPENDITUREs { get; set; }

    public virtual DbSet<BUDGET_CAPEX> BUDGET_CAPices { get; set; }

    public virtual DbSet<BUDGET_CAPEX_OPEX> BUDGET_CAPEX_OPices { get; set; }

    public virtual DbSet<BUDGET_OPEX> BUDGET_OPices { get; set; }

    public virtual DbSet<BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy> BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs { get; set; }

    public virtual DbSet<BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy> BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs { get; set; }

    public virtual DbSet<BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT> BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs { get; set; }

    public virtual DbSet<BUDGET_PERFORMANCE_PRODUCTION_COST> BUDGET_PERFORMANCE_PRODUCTION_COSTs { get; set; }

    public virtual DbSet<BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT> BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs { get; set; }

    public virtual DbSet<BudgetProposal> BudgetProposals { get; set; }

    public virtual DbSet<COMPANY_CONCESSIONS_FIELD> COMPANY_CONCESSIONS_FIELDs { get; set; }

    public virtual DbSet<COMPANY_FIELD> COMPANY_FIELDs { get; set; }

    public virtual DbSet<CONCESSION_SITUATION> CONCESSION_SITUATIONs { get; set; }

    public virtual DbSet<CSR> CSRs { get; set; }

    public virtual DbSet<Class_Table> Class_Tables { get; set; }

    public virtual DbSet<CompletionJob> CompletionJobs { get; set; }

    public virtual DbSet<ConcessionSituation> ConcessionSituations { get; set; }

    public virtual DbSet<ConcessionSituationTwo> ConcessionSituationTwos { get; set; }

    public virtual DbSet<Contract_Type> Contract_Types { get; set; }

    public virtual DbSet<DECOMMISSIONING_ABANDONMENT> DECOMMISSIONING_ABANDONMENTs { get; set; }

    public virtual DbSet<DRILLING_EACH_WELL_COST> DRILLING_EACH_WELL_COSTs { get; set; }

    public virtual DbSet<DRILLING_EACH_WELL_COST_PROPOSED> DRILLING_EACH_WELL_COST_PROPOSEDs { get; set; }

    public virtual DbSet<DRILLING_OPERATIONS_> DRILLING_OPERATIONS_s { get; set; }

    public virtual DbSet<DRILLING_OPERATIONS_CATEGORIES_OF_WELL> DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }

    public virtual DbSet<Data_Type> Data_Types { get; set; }

    public virtual DbSet<DecommissioningAbandonment> DecommissioningAbandonments { get; set; }

    public virtual DbSet<DevelopmentDrilling> DevelopmentDrillings { get; set; }

    public virtual DbSet<Development_And_Production> Development_And_Productions { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Drilling_Operation> Drilling_Operations { get; set; }

    public virtual DbSet<Exploration_Drilling> Exploration_Drillings { get; set; }

    public virtual DbSet<FACILITIES_PROJECT_PERFORMANCE> FACILITIES_PROJECT_PERFORMANCEs { get; set; }

    public virtual DbSet<FIELD_DEVELOPMENT_FIELDS_AND_STATUS> FIELD_DEVELOPMENT_FIELDS_AND_STATUSes { get; set; }

    public virtual DbSet<FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP> FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs { get; set; }

    public virtual DbSet<FIELD_DEVELOPMENT_PLAN> FIELD_DEVELOPMENT_PLANs { get; set; }

    public virtual DbSet<FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf> FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs { get; set; }

    public virtual DbSet<FacilityConstruction> FacilityConstructions { get; set; }

    public virtual DbSet<Functionality> Functionalities { get; set; }

    public virtual DbSet<GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY> GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies { get; set; }

    public virtual DbSet<GAS_PRODUCTION_ACTIVITy> GAS_PRODUCTION_ACTIVITIEs { get; set; }

    public virtual DbSet<GEOPHYSICAL_ACTIVITIES_ACQUISITION> GEOPHYSICAL_ACTIVITIES_ACQUISITIONs { get; set; }

    public virtual DbSet<GEOPHYSICAL_ACTIVITIES_PROCESSING> GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }

    public virtual DbSet<Gas_Production_Activity1> Gas_Production_Activities1 { get; set; }

    public virtual DbSet<Gas_Reserve_Update> Gas_Reserve_Updates { get; set; }

    public virtual DbSet<GeographicalActivity> GeographicalActivities { get; set; }

    public virtual DbSet<Geophysical_Activity> Geophysical_Activities { get; set; }

    public virtual DbSet<HSE> HSEs { get; set; }

    public virtual DbSet<HSE_ACCIDENT_INCIDENCE_REPORTING_NEW> HSE_ACCIDENT_INCIDENCE_REPORTING_NEWs { get; set; }

    public virtual DbSet<HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW> HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEWs { get; set; }

    public virtual DbSet<HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW> HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEWs { get; set; }

    public virtual DbSet<HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW> HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEWs { get; set; }

    public virtual DbSet<HSE_CAUSES_OF_SPILL> HSE_CAUSES_OF_SPILLs { get; set; }

    public virtual DbSet<HSE_CLIMATE_CHANGE_AND_AIR_QUALITY> HSE_CLIMATE_CHANGE_AND_AIR_QUALITies { get; set; }

    public virtual DbSet<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST> HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COSTs { get; set; }

    public virtual DbSet<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW> HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEWs { get; set; }

    public virtual DbSet<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW> HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEWs { get; set; }

    public virtual DbSet<HSE_DESIGNS_SAFETY> HSE_DESIGNS_SAFETies { get; set; }

    public virtual DbSet<HSE_EFFLUENT_MONITORING_COMPLIANCE> HSE_EFFLUENT_MONITORING_COMPLIANCEs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW> HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEWs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW> HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEWs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW> HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEWs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_IMPACT_ASSESSMENT> HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_MANAGEMENT_PLAN> HSE_ENVIRONMENTAL_MANAGEMENT_PLANs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM> HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEMs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW> HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEWs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_STUDIES_NEW> HSE_ENVIRONMENTAL_STUDIES_NEWs { get; set; }

    public virtual DbSet<HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED> HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATEDs { get; set; }

    public virtual DbSet<HSE_FATALITy> HSE_FATALITIEs { get; set; }

    public virtual DbSet<HSE_GHG_MANAGEMENT_PLAN> HSE_GHG_MANAGEMENT_PLANs { get; set; }

    public virtual DbSet<HSE_HOST_COMMUNITIES_DEVELOPMENT> HSE_HOST_COMMUNITIES_DEVELOPMENTs { get; set; }

    public virtual DbSet<HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW> HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEWs { get; set; }

    public virtual DbSet<HSE_INSPECTION_AND_MAINTENANCE_NEW> HSE_INSPECTION_AND_MAINTENANCE_NEWs { get; set; }

    public virtual DbSet<HSE_MANAGEMENT_POSITION> HSE_MANAGEMENT_POSITIONs { get; set; }

    public virtual DbSet<HSE_MinimumRequirement> HSE_MinimumRequirements { get; set; }

    public virtual DbSet<HSE_OCCUPATIONAL_HEALTH_MANAGEMENT> HSE_OCCUPATIONAL_HEALTH_MANAGEMENTs { get; set; }

    public virtual DbSet<HSE_OIL_SPILL_INCIDENT> HSE_OIL_SPILL_INCIDENTs { get; set; }

    public virtual DbSet<HSE_OIL_SPILL_REPORTING_NEW> HSE_OIL_SPILL_REPORTING_NEWs { get; set; }

    public virtual DbSet<HSE_OPERATIONS_SAFETY_CASE> HSE_OPERATIONS_SAFETY_CASEs { get; set; }

    public virtual DbSet<HSE_OSP_REGISTRATIONS_NEW> HSE_OSP_REGISTRATIONS_NEWs { get; set; }

    public virtual DbSet<HSE_POINT_SOURCE_REGISTRATION> HSE_POINT_SOURCE_REGISTRATIONs { get; set; }

    public virtual DbSet<HSE_PRODUCED_WATER_MANAGEMENT_NEW> HSE_PRODUCED_WATER_MANAGEMENT_NEWs { get; set; }

    public virtual DbSet<HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED> HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATEDs { get; set; }

    public virtual DbSet<HSE_QUALITY_CONTROL> HSE_QUALITY_CONTROLs { get; set; }

    public virtual DbSet<HSE_QUESTION> HSE_QUESTIONs { get; set; }

    public virtual DbSet<HSE_REMEDIATION_FUND> HSE_REMEDIATION_FUNDs { get; set; }

    public virtual DbSet<HSE_SAFETY_CULTURE_TRAINING> HSE_SAFETY_CULTURE_TRAININGs { get; set; }

    public virtual DbSet<HSE_SAFETY_STUDIES_NEW> HSE_SAFETY_STUDIES_NEWs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSRs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEWs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisitions { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOUs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUALs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTIONs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEMEs { get; set; }

    public virtual DbSet<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME> HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEMEs { get; set; }

    public virtual DbSet<HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW> HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEWs { get; set; }

    public virtual DbSet<HSE_WASTE_MANAGEMENT_DZ> HSE_WASTE_MANAGEMENT_DZs { get; set; }

    public virtual DbSet<HSE_WASTE_MANAGEMENT_NEW> HSE_WASTE_MANAGEMENT_NEWs { get; set; }

    public virtual DbSet<HSE_WASTE_MANAGEMENT_SYSTEM> HSE_WASTE_MANAGEMENT_SYSTEMs { get; set; }

    public virtual DbSet<HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW> HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEWs { get; set; }

    public virtual DbSet<INITIAL_WELL_COMPLETION_JOB1> INITIAL_WELL_COMPLETION_JOBs1 { get; set; }

    public virtual DbSet<Initial_Well_Completion_Job> Initial_Well_Completion_Jobs { get; set; }

    public virtual DbSet<LEGAL_ARBITRATION> LEGAL_ARBITRATIONs { get; set; }

    public virtual DbSet<LEGAL_LITIGATION> LEGAL_LITIGATIONs { get; set; }

    public virtual DbSet<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMME> LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMEs { get; set; }

    public virtual DbSet<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate> LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriates { get; set; }

    public virtual DbSet<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training> LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Trainings { get; set; }

    public virtual DbSet<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training> LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Trainings { get; set; }

    public virtual DbSet<Legal> Legals { get; set; }

    public virtual DbSet<LocalContent> LocalContents { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MyDesk> MyDesks { get; set; }

    public virtual DbSet<NDPR_SUBSCRIPTION_FEE> NDPR_SUBSCRIPTION_FEEs { get; set; }

    public virtual DbSet<NDR> NDRs { get; set; }

    public virtual DbSet<NDR_DATA_POPULATION_ON_BLOCK_BASI> NDR_DATA_POPULATION_ON_BLOCK_BAses { get; set; }

    public virtual DbSet<NDR_Data_Population> NDR_Data_Populations { get; set; }

    public virtual DbSet<NIGERIA_CONTENT> NIGERIA_CONTENTs { get; set; }

    public virtual DbSet<NIGERIA_CONTENT_QUESTION> NIGERIA_CONTENT_QUESTIONs { get; set; }

    public virtual DbSet<NIGERIA_CONTENT_Training> NIGERIA_CONTENT_Trainings { get; set; }

    public virtual DbSet<NIGERIA_CONTENT_Upload_Succession_Plan> NIGERIA_CONTENT_Upload_Succession_Plans { get; set; }

    public virtual DbSet<NigerianContent> NigerianContents { get; set; }

    public virtual DbSet<OIL_AND_GAS_FACILITY_MAINTENANCE> OIL_AND_GAS_FACILITY_MAINTENANCEs { get; set; }

    public virtual DbSet<OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE> OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs { get; set; }

    public virtual DbSet<OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT> OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facility> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity> OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities { get; set; }

    public virtual DbSet<OIL_CONDENSATE_PRODUCTION_ACTIVITy> OIL_CONDENSATE_PRODUCTION_ACTIVITIEs { get; set; }

    public virtual DbSet<OilCondensateProduction> OilCondensateProductions { get; set; }

    public virtual DbSet<OilSpill_Incident> OilSpill_Incidents { get; set; }

    public virtual DbSet<PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT> PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTs { get; set; }

    public virtual DbSet<PRESENTATION_UPLOAD> PRESENTATION_UPLOADs { get; set; }

    public virtual DbSet<PermitApproval> PermitApprovals { get; set; }

    public virtual DbSet<Planning_MinimumRequirement> Planning_MinimumRequirements { get; set; }

    public virtual DbSet<ProcessAction> ProcessActions { get; set; }

    public virtual DbSet<ProcessStatus> ProcessStatuses { get; set; }

    public virtual DbSet<RESERVES_REPLACEMENT_RATIO> RESERVES_REPLACEMENT_RATIOs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_DEPLETION_RATE> RESERVES_UPDATES_DEPLETION_RATEs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_LIFE_INDEX> RESERVES_UPDATES_LIFE_INDices { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE> RESERVES_UPDATES_OIL_CONDENSATEs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE> RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVEs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION> RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection> RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_MMBBL> RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE> RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCEs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition> RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Additions { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE> RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs { get; set; }

    public virtual DbSet<RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE> RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs { get; set; }

    public virtual DbSet<ROLES_> ROLES_s { get; set; }

    public virtual DbSet<ROLES_SUPER_ADMIN> ROLES_SUPER_ADMINs { get; set; }

    public virtual DbSet<Reserve_Update_Oil_Condensate> Reserve_Update_Oil_Condensates { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Royalty> Royalties { get; set; }

    public virtual DbSet<SBU_ApplicationComment> SBU_ApplicationComments { get; set; }

    public virtual DbSet<SBU_Record> SBU_Records { get; set; }

    public virtual DbSet<STRATEGIC_PLANS_ON_COMPANY_BASI> STRATEGIC_PLANS_ON_COMPANY_BAses { get; set; }

    public virtual DbSet<SafetyManagement> SafetyManagements { get; set; }

    public virtual DbSet<StrategicBusinessUnit> StrategicBusinessUnits { get; set; }

    public virtual DbSet<SubmittedDocument> SubmittedDocuments { get; set; }

    public virtual DbSet<SubstainableDevelopment> SubstainableDevelopments { get; set; }

    public virtual DbSet<Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELL> Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }

    public virtual DbSet<Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITION> Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs { get; set; }

    public virtual DbSet<Sum_GEOPHYSICAL_ACTIVITIES_PROCESSING> Sum_GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }

    public virtual DbSet<Table_1> Table_1s { get; set; }

    public virtual DbSet<Table_Detail> Table_Details { get; set; }

    public virtual DbSet<TrainingForStaff> TrainingForStaffs { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOTs { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workovers { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover__join_Contracttype> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover__join_Contracttypes { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_years { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_companyemail> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_companyemails { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_contract_type> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_contract_types { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_years { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year_companyemail> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year_companyemails { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_appraisal> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_appraisals { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_development> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_developments { get; set; }

    public virtual DbSet<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_exploration> VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_explorations { get; set; }

    public virtual DbSet<VW_GAS_PRODUCTION_ACTIVITIES_total> VW_GAS_PRODUCTION_ACTIVITIES_totals { get; set; }

    public virtual DbSet<VW_GAS_PRODUCTION_ACTIVITIES_total_summed> VW_GAS_PRODUCTION_ACTIVITIES_total_summeds { get; set; }

    public virtual DbSet<VW_GAS_PRODUCTION_ACTIVITy> VW_GAS_PRODUCTION_ACTIVITIEs { get; set; }

    public virtual DbSet<VW_GEOPHYSICAL_ACTIVITIES_PROCESSING> VW_GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }

    public virtual DbSet<VW_GEOPHYSICAL_ACTIVITIES_PROCESSING_SUM_BY_YEAR> VW_GEOPHYSICAL_ACTIVITIES_PROCESSING_SUM_BY_YEARs { get; set; }

    public virtual DbSet<VW_Geophysical_SEISMIC_DATA_old> VW_Geophysical_SEISMIC_DATA_olds { get; set; }

    public virtual DbSet<VW_Geophysical_SEISMIC_DATA_total> VW_Geophysical_SEISMIC_DATA_totals { get; set; }

    public virtual DbSet<VW_Geophysical_SEISMIC_DATA_total_summed> VW_Geophysical_SEISMIC_DATA_total_summeds { get; set; }

    public virtual DbSet<VW_Geophysical_SEISMIC_DATum> VW_Geophysical_SEISMIC_DATAs { get; set; }

    public virtual DbSet<VW_HSE_OIL_SPILL_REPORTING_NEW> VW_HSE_OIL_SPILL_REPORTING_NEWs { get; set; }

    public virtual DbSet<VW_HSE_OIL_SPILL_REPORTING_NEW_total> VW_HSE_OIL_SPILL_REPORTING_NEW_totals { get; set; }

    public virtual DbSet<VW_HSE_OIL_SPILL_REPORTING_NEW_total_summed> VW_HSE_OIL_SPILL_REPORTING_NEW_total_summeds { get; set; }

    public virtual DbSet<VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total> VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_totals { get; set; }

    public virtual DbSet<VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total_summed> VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total_summeds { get; set; }

    public virtual DbSet<VW_OIL_CONDENSATE_PRODUCTION_ACTIVITy> VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIEs { get; set; }

    public virtual DbSet<VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL> VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs { get; set; }

    public virtual DbSet<VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_PERCENTAGE_CALCULATED> VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_PERCENTAGE_CALCULATEDs { get; set; }

    public virtual DbSet<VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_total_4_percentage_calculation> VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_total_4_percentage_calculations { get; set; }

    public virtual DbSet<VW_SEISMIC_DATA_QUANTUM> VW_SEISMIC_DATA_QUANTa { get; set; }

    public virtual DbSet<VW_SEISMIC_DATA_QUANTUM_SUM_BY_YEAR> VW_SEISMIC_DATA_QUANTUM_SUM_BY_YEARs { get; set; }

    public virtual DbSet<VW_company_and_contract_type> VW_company_and_contract_types { get; set; }

    public virtual DbSet<View_2> View_2s { get; set; }

    public virtual DbSet<WORKOVERS_RECOMPLETION_JOB1> WORKOVERS_RECOMPLETION_JOBs1 { get; set; }

    public virtual DbSet<WORK_PROGRAM_FLOW> WORK_PROGRAM_FLOWs { get; set; }

    public virtual DbSet<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLY> WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLies { get; set; }

    public virtual DbSet<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORY> WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORies { get; set; }

    public virtual DbSet<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_COMPANYNAME> WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_COMPANYNAMEs { get; set; }

    public virtual DbSet<WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELL> WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }

    public virtual DbSet<WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR> WP_COUNT_PRESENTATION_CATERGORY_BY_YEARs { get; set; }

    public virtual DbSet<WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_STATUS_COMPANYNAME> WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_STATUS_COMPANYNAMEs { get; set; }

    public virtual DbSet<WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_old> WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_olds { get; set; }

    public virtual DbSet<WP_Cost_Efficiency_Metric_CAPEX_OPEX> WP_Cost_Efficiency_Metric_CAPEX_OPEXes { get; set; }

    public virtual DbSet<WP_Cost_Efficiency_Metric_CAPEX_OPEX_OLD> WP_Cost_Efficiency_Metric_CAPEX_OPEX_OLDs { get; set; }

    public virtual DbSet<WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION> WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTIONs { get; set; }

    public virtual DbSet<WP_Cost_Efficiency_Metric_NET_PRODUCTION> WP_Cost_Efficiency_Metric_NET_PRODUCTIONs { get; set; }

    public virtual DbSet<WP_Cost_Efficiency_Metric_NET_PRODUCTION_OLD> WP_Cost_Efficiency_Metric_NET_PRODUCTION_OLDs { get; set; }

    public virtual DbSet<WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELL> WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type> WP_GAS_PRODUCTION_ACTIVITIES_Contract_Types { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_Percentage> WP_GAS_PRODUCTION_ACTIVITIES_Percentages { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis> WP_GAS_PRODUCTION_ACTIVITIES_contract_type_bases { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED> WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNEDs { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoted> WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoteds { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoted> WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoteds { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_penalty_payment> WP_GAS_PRODUCTION_ACTIVITIES_penalty_payments { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared> WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flareds { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE> WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGEs { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE_PLANNED> WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE_PLANNEDs { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED> WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNEDs { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_terrain_pivotted> WP_GAS_PRODUCTION_ACTIVITIES_terrain_pivotteds { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITIES_terrain_tobe_pivotted> WP_GAS_PRODUCTION_ACTIVITIES_terrain_tobe_pivotteds { get; set; }

    public virtual DbSet<WP_GAS_PRODUCTION_ACTIVITy> WP_GAS_PRODUCTION_ACTIVITIEs { get; set; }

    public virtual DbSet<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION> WP_GEOPHYSICAL_ACTIVITIES_ACQUISITIONs { get; set; }

    public virtual DbSet<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type> WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_types { get; set; }

    public virtual DbSet<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_count> WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_counts { get; set; }

    public virtual DbSet<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type> WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_types { get; set; }

    public virtual DbSet<WP_GEOPHYSICAL_ACTIVITIES_PROCESSING> WP_GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }

    public virtual DbSet<WP_Gas_Production_Utilisation_And_Flaring_Forecast> WP_Gas_Production_Utilisation_And_Flaring_Forecasts { get; set; }

    public virtual DbSet<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequence> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequences { get; set; }

    public virtual DbSet<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spills { get; set; }

    public virtual DbSet<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill_total> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill_totals { get; set; }

    public virtual DbSet<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accident> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accidents { get; set; }

    public virtual DbSet<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentage> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentages { get; set; }

    public virtual DbSet<WP_HSE_FATALITIES_accident_statistic_table> WP_HSE_FATALITIES_accident_statistic_tables { get; set; }

    public virtual DbSet<WP_INITIAL_WELL_COMPLETION_JOB> WP_INITIAL_WELL_COMPLETION_JOBs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Type> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Types { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oils { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_years { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Five_Year_Trend_for_Companies_Reserve_Replacement_Ratio> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Five_Year_Trend_for_Companies_Reserve_Replacement_Ratios { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTIONs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPEs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_chart> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_charts { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrains { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdowns { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_years { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year_PLANNED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year_PLANNEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotted> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotteds { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_tobe_pivoted> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_tobe_pivoteds { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoteds { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted_PLANNED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted_PLANNEDs { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoteds { get; set; }

    public virtual DbSet<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted_PLANNED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted_PLANNEDs { get; set; }

    public virtual DbSet<WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE> WP_OML_ACQUSITION_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD> WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD2021> WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD2021s { get; set; }

    public virtual DbSet<WP_OML_COMPLIANCE_INDEX_CALCULATION> WP_OML_COMPLIANCE_INDEX_CALCULATIONs { get; set; }

    public virtual DbSet<WP_OML_COMPLIANCE_INDEX_WEIGHTED_SCORE> WP_OML_COMPLIANCE_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE> WP_OML_CONCESSION_RENTALS_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR> WP_OML_Concession_Rentals_Index_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE> WP_OML_DISCOVERY_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE_OLD> WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR> WP_OML_Discovery_Index_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR_OLD> WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_Domestic_Gas_obligation_INDEX_WEIGHTED_SCORE> WP_OML_Domestic_Gas_obligation_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Domestic_Gas_obligation_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_Domestic_Gas_obligation_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE> WP_OML_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_FATALITY_INDEX_WEIGHTED_SCORE> WP_OML_FATALITY_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_FATALITY_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_FATALITY_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE> WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE_OLD> WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE> WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE_OLD> WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_Gas_Sales_Royalty_Payment_INDEX_WEIGHTED_SCORE> WP_OML_Gas_Sales_Royalty_Payment_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Gas_Sales_Royalty_Payment_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_Gas_Sales_Royalty_Payment_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_Gas_flare_Royalty_payment_INDEX_WEIGHTED_SCORE> WP_OML_Gas_flare_Royalty_payment_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Gas_flare_Royalty_payment_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_Gas_flare_Royalty_payment_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_INDEX_WEIGHTED_SCORE> WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_INDEX_WEIGHTED_SCORE> WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_INCREMENT_IN_PRODUCTION_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_INCREMENT_IN_PRODUCTION_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1> WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1s { get; set; }

    public virtual DbSet<WP_OML_INJURY_INDEX_WEIGHTED_SCORE> WP_OML_INJURY_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_INJURY_INDEX_WEIGHTED_SCORE_OLD> WP_OML_INJURY_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP_OLD> WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP_OLDs { get; set; }

    public virtual DbSet<WP_OML_NDPR_SUBSCRIPTION_FEE_INDEX_WEIGHTED_SCORE> WP_OML_NDPR_SUBSCRIPTION_FEE_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_NDPR_SUBSCRIPTION_FEE_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_NDPR_SUBSCRIPTION_FEE_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_Oil_spill_reported_INDEX_WEIGHTED_SCORE> WP_OML_Oil_spill_reported_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Oil_spill_reported_Index_MN_MAX_RGT_by_Year_of_WP> WP_OML_Oil_spill_reported_Index_MN_MAX_RGT_by_Year_of_WPs { get; set; }

    public virtual DbSet<WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1> WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1s { get; set; }

    public virtual DbSet<WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1_OLD> WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1_OLDs { get; set; }

    public virtual DbSet<WP_OML_RESERVE_REPLACEMENT_RATIO_WEIGHTED_SCORE> WP_OML_RESERVE_REPLACEMENT_RATIO_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_SIGNATURE_BONUS_INDEX_WEIGHTED_SCORE> WP_OML_SIGNATURE_BONUS_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_SIGNATURE_BONUS_Index_MN_MAX_RGT_by_YEAR> WP_OML_SIGNATURE_BONUS_Index_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021> WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021s { get; set; }

    public virtual DbSet<WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE> WP_OML_Senior_Staff_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD> WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD2021> WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD2021s { get; set; }

    public virtual DbSet<WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR> WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021> WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021s { get; set; }

    public virtual DbSet<WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE> WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD> WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD2021> WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD2021s { get; set; }

    public virtual DbSet<WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR> WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE> WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD> WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OPL_Aggregated_Score_ALL_COMPANIES_OLD> WP_OPL_Aggregated_Score_ALL_COMPANIES_OLDs { get; set; }

    public virtual DbSet<WP_OPL_Aggregated_Score_ALL_COMPANIES_WITHOUT_INDEX_TYPE> WP_OPL_Aggregated_Score_ALL_COMPANIES_WITHOUT_INDEX_TYPEs { get; set; }

    public virtual DbSet<WP_OPL_Aggregated_Score_ALL_COMPANy> WP_OPL_Aggregated_Score_ALL_COMPANIEs { get; set; }

    public virtual DbSet<WP_OPL_COMPLIANCE_INDEX_CALCULATION> WP_OPL_COMPLIANCE_INDEX_CALCULATIONs { get; set; }

    public virtual DbSet<WP_OPL_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE> WP_OPL_CONCESSION_RENTALS_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OPL_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR> WP_OPL_Concession_Rentals_Index_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE> WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE_OLD> WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR> WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR_OLD> WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OPL_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE> WP_OPL_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OPL_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEAR> WP_OPL_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR> WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEARs { get; set; }

    public virtual DbSet<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR_OLD> WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR_OLDs { get; set; }

    public virtual DbSet<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE> WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCOREs { get; set; }

    public virtual DbSet<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE_OLD> WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE_OLDs { get; set; }

    public virtual DbSet<WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANy> WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANIEs { get; set; }

    public virtual DbSet<WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTED> WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTEDs { get; set; }

    public virtual DbSet<WP_RESERVES_REPLACEMENT_RATIO_VALUE_TO_BE_PIVOTTED> WP_RESERVES_REPLACEMENT_RATIO_VALUE_TO_BE_PIVOTTEDs { get; set; }

    public virtual DbSet<WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL> WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBLs { get; set; }

    public virtual DbSet<WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT> WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENTs { get; set; }

    public virtual DbSet<WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED> WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNEDs { get; set; }

    public virtual DbSet<WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION> WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETIONs { get; set; }

    public virtual DbSet<WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED> WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVEREDs { get; set; }

    public virtual DbSet<WP_TOTAL_NO_OF_INCIDENCE_BY_YEAR_COMPANYNAME> WP_TOTAL_NO_OF_INCIDENCE_BY_YEAR_COMPANYNAMEs { get; set; }

    public virtual DbSet<WP_TOTAL_NO_OF_OIL_SPILLED_AND_RECOVERED_BY_YEAR_COMPANYNAME> WP_TOTAL_NO_OF_OIL_SPILLED_AND_RECOVERED_BY_YEAR_COMPANYNAMEs { get; set; }

    public virtual DbSet<WP_Total_E_and_P_companies_old> WP_Total_E_and_P_companies_olds { get; set; }

    public virtual DbSet<WP_Total_E_and_P_company> WP_Total_E_and_P_companies { get; set; }

    public virtual DbSet<WP_WORKOVERS_RECOMPLETION_JOB> WP_WORKOVERS_RECOMPLETION_JOBs { get; set; }

    public virtual DbSet<WorkOverJob> WorkOverJobs { get; set; }

    public virtual DbSet<WorkOvers_Recompletion_Job> WorkOvers_Recompletion_Jobs { get; set; }

    public virtual DbSet<WorkOvers_Recompletion_Job_Field_Dvelopment_Plan> WorkOvers_Recompletion_Job_Field_Dvelopment_Plans { get; set; }

    public virtual DbSet<staff> staff { get; set; }

    public virtual DbSet<tbl_fruitanalysis> tbl_fruitanalyses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration["Data:Wkpconnect:ConnectionString"]);

    
    //"Server=tcp:workprogram.database.windows.net,1433;Initial Catalog=workprogram;Persist Security Info=False;User ID=workprogram;Password=Br@nd0ne;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationSBUApproval>(entity =>
        {
            entity.ToTable("ApplicationSBUApproval");

            //entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.AppId).HasColumnName("AppId");
            entity.Property(e => e.StaffID).HasColumnName("StaffID");
            entity.Property(e => e.Comment).HasColumnName("Comment");
            entity.Property(e => e.Status).HasColumnName("Status");
            entity.Property(e => e.AppAction).HasColumnName("AppAction");
            entity.Property(e => e.DeskID).HasColumnName("DeskID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SBU_Submission>(entity =>
        {
            entity.ToTable("SBU_Submission");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProcessStatus).HasMaxLength(100);
            entity.Property(e => e.SBU_ID).HasColumnName("SBU_ID");
            entity.Property(e => e.StaffID).HasColumnName("StaffID");
        });

        modelBuilder.Entity<ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE>(entity =>
        {
            entity.ToTable("ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE>(entity =>
        {
            entity.ToTable("ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_BUDGET_CAPEX_OPEX>(entity =>
        {
            entity.ToTable("ADMIN_BUDGET_CAPEX_OPEX");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CATEGORy>(entity =>
        {
            entity.ToTable("ADMIN_CATEGORIES");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CHAIRPERSON>(entity =>
        {
            entity.ToTable("ADMIN_CHAIRPERSON");

            entity.Property(e => e.CHAIRPERSON)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CHAIRPERSONEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPANYEMAIL_REMINDER_TABLE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ADMIN_COMPANYEMAIL_REMINDER_TABLE");

            entity.Property(e => e.CLOSE_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL_REMARK)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Expr1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OPEN_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPANY_CODE>(entity =>
        {
            entity.ToTable("ADMIN_COMPANY_CODE");

            entity.Property(e => e.CompanyCode)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.GUID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPANY_DETAIL>(entity =>
        {
            entity.ToTable("ADMIN_COMPANY_DETAILS");

            entity.Property(e => e.Address_of_Company)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Alternate_Contact_Person)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contact_Person)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email_Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email_Address_alt)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FLAG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_MD_CEO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Phone_NO_of_MD_CEO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Phone_No)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Phone_No_alt)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.check_status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPANY_INFORMATION>(entity =>
        {
            entity.ToTable("ADMIN_COMPANY_INFORMATION");

            entity.Property(e => e.CATEGORY)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DESIGNATION)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.EMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL_REMARK)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FLAG1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FLAG2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FLAG_PASSWORD_CHANGE)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LAST_LOGIN_DATE).HasColumnType("datetime");
            entity.Property(e => e.NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PASSWORDS)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PHONE_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.STATUS_)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UPDATED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UPDATED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPANY_INFORMATION_AUDIT>(entity =>
        {
            entity.ToTable("ADMIN_COMPANY_INFORMATION_AUDIT");

            entity.Property(e => e.CATEGORY)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DESIGNATION)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.EMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FLAG1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FLAG2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FLAG_PASSWORD_CHANGE)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LAST_LOGIN_DATE).HasColumnType("datetime");
            entity.Property(e => e.NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PASSWORDS)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PHONE_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.STATUS_)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UPDATED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UPDATED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPANY_INFORMATION_old_18052020>(entity =>
        {
            entity.ToTable("ADMIN_COMPANY_INFORMATION_old_18052020");

            entity.Property(e => e.CATEGORY)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DESIGNATION)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.EMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FLAG_PASSWORD_CHANGE)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LAST_LOGIN_DATE).HasColumnType("datetime");
            entity.Property(e => e.NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PASSWORDS)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PHONE_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.STATUS_)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_COMPLIANCE_INDEX_TABLE>(entity =>
        {
            entity.ToTable("ADMIN_COMPLIANCE_INDEX_TABLE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Compliance_index_for_each_division)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Divisions)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Occurrence_of_Sanctions)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Occurrence_of_Waivers)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Occurrence_of_Warnings)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Penalty_Factor_for_Sanction)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Penalty_Factor_for_Waivers)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Penalty_Factor_for_Warning)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(3000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CONCESSIONS_INFORMATION>(entity =>
        {
            entity.HasKey(e => e.Consession_Id).HasName("PK_ADMIN_CONCESSIONS_INFORMATIONs");

            entity.ToTable("ADMIN_CONCESSIONS_INFORMATION");

            entity.Property(e => e.Area)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CLOSE_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ConcessionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Unique_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
            entity.Property(e => e.EMAIL_REMARK)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Equity_distribution).IsUnicode(false);
            entity.Property(e => e.Field_Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Flag1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Flag2)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OPEN_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_Grant_Award)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.submitted)
                .HasMaxLength(3900)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CONCESSIONS_INFORMATION_AUDIT>(entity =>
        {
            entity.HasKey(e => e.Consession_Id);

            entity.ToTable("ADMIN_CONCESSIONS_INFORMATION_AUDIT");

            entity.Property(e => e.Area)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CLOSE_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Unique_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
            entity.Property(e => e.Equity_distribution).IsUnicode(false);
            entity.Property(e => e.Flag1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Flag2)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OPEN_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_Grant_Award)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.submitted)
                .HasMaxLength(3900)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CONCESSIONS_INFORMATION_BK_23112021>(entity =>
        {
            entity.HasKey(e => e.Consession_Id).HasName("PK_ADMIN_CONCESSIONS_INFORMATION_");

            entity.ToTable("ADMIN_CONCESSIONS_INFORMATION_BK_23112021");

            entity.Property(e => e.Area)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CLOSE_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Unique_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_BY)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DELETED_STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
            entity.Property(e => e.EMAIL_REMARK)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Equity_distribution).IsUnicode(false);
            entity.Property(e => e.Flag1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Flag2)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OPEN_DATE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_Grant_Award)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.submitted)
                .HasMaxLength(3900)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CONCESSIONS_INFORMATION_HISTORY>(entity =>
        {
            entity.HasKey(e => e.Consession_Id);

            entity.ToTable("ADMIN_CONCESSIONS_INFORMATION_HISTORY");

            entity.Property(e => e.Area)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
            entity.Property(e => e.Equity_distribution).IsUnicode(false);
            entity.Property(e => e.Flag1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Flag2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_Grant_Award)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CONCESSIONS_INFORMATION_old_18052020>(entity =>
        {
            entity.HasKey(e => e.Consession_Id).HasName("PK_ADMIN_CONCESSIONS_INFORMATION");

            entity.ToTable("ADMIN_CONCESSIONS_INFORMATION_old_18052020");

            entity.Property(e => e.Area)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
            entity.Property(e => e.Equity_distribution).IsUnicode(false);
            entity.Property(e => e.Flag1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Flag2)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_Grant_Award)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.submitted)
                .HasMaxLength(3900)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_CONCESSION_STATUS>(entity =>
        {
            entity.ToTable("ADMIN_CONCESSION_STATUS");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Status_)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Status_Desc).IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_DATETIME_PRESENTATION>(entity =>
        {
            entity.ToTable("ADMIN_DATETIME_PRESENTATION");

            entity.Property(e => e.CHAIRPERSON)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CHAIRPERSONEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CLOSE_DATE).HasColumnType("datetime");
            entity.Property(e => e.COMPANYEMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.COMPANYNAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CREATED_BY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DATETIME_PRESENTATION).HasColumnType("datetime");
            entity.Property(e => e.DATE_TIME_TEXT)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DAYS_TO_GO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DIVISION)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Created_BY_COMPANY)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.EMAIL_REMARK)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LAST_RUN_DATE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LAST_RUN_TIME).HasColumnType("datetime");
            entity.Property(e => e.MEETINGROOM)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MOM)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MOM_UPLOADED_BY)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MOM_UPLOAD_DATE).HasColumnType("datetime");
            entity.Property(e => e.OPEN_DATE).HasColumnType("datetime");
            entity.Property(e => e.PHONE_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PRESENTED)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBEEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Submitted)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YEAR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.wp_date)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.wp_time)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_DEVELOPMENT_PLAN_STATUS>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_DEVELOPMENT_PLAN_STATUS");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Desc).IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_DIVISIONAL_REPRESENTATIVE>(entity =>
        {
            entity.ToTable("ADMIN_DIVISIONAL_REPRESENTATIVE");

            entity.Property(e => e.CHAIRPERSON)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CHAIRPERSONEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CLOSE_DATE).HasColumnType("datetime");
            entity.Property(e => e.COMPANYEMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.COMPANYNAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CREATED_BY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DATETIME_PRESENTATION).HasColumnType("datetime");
            entity.Property(e => e.DIV_REP_DIV)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DIV_REP_EMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DIV_REP_NAME)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.MEETINGROOM)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OPEN_DATE).HasColumnType("datetime");
            entity.Property(e => e.PRESENTED)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBEEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Submitted)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YEAR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.wp_date)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.wp_time)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_DIVISIONAL_REPS_PRESENTATION>(entity =>
        {
            entity.ToTable("ADMIN_DIVISIONAL_REPS_PRESENTATION");

            entity.Property(e => e.CHAIRPERSON)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CHAIRPERSONEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CLOSE_DATE).HasColumnType("datetime");
            entity.Property(e => e.COMPANYEMAIL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.COMPANYNAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CREATED_BY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DATETIME_PRESENTATION).HasColumnType("datetime");
            entity.Property(e => e.DATE_TIME_TEXT)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DAYS_TO_GO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DIVISION)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.EMAIL_REMARK)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LAST_RUN_DATE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LAST_RUN_TIME).HasColumnType("datetime");
            entity.Property(e => e.MEETINGROOM)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MOM)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MOM_UPLOADED_BY)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MOM_UPLOAD_DATE).HasColumnType("datetime");
            entity.Property(e => e.OPEN_DATE).HasColumnType("datetime");
            entity.Property(e => e.PHONE_NO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PRESENTED)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.REPRESENTATIVE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.REPRESENTATIVE_EMAIL)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBEEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.STATUS)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Submitted)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YEAR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.wp_date)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.wp_time)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_DIVISION_REP>(entity =>
        {
            entity.ToTable("ADMIN_DIVISION_REP");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DIVISION).IsUnicode(false);
            entity.Property(e => e.DIVISIONEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_DIVISION_REP_LIST>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_DIVISION_REP_LIST");

            entity.Property(e => e.DIVISION)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DIV_REP_EMAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DIV_REP_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ADMIN_EMAIL_DAY>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_EMAIL_DAYS");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DAYS_)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Deleted_Date)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Deleted_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Deleted_status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email_)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SN).ValueGeneratedOnAdd();
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING>(entity =>
        {
            entity.ToTable("ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING>(entity =>
        {
            entity.ToTable("ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_ENVIROMENTAL_STUDy>(entity =>
        {
            entity.ToTable("ADMIN_ENVIROMENTAL_STUDIES");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_ENVIRONMENTAL_STUDY>(entity =>
        {
            entity.ToTable("ADMIN_ENVIRONMENTAL_STUDY");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_FEILDDEVELOPMENTPLAN_WELLORGA>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_FEILDDEVELOPMENTPLAN_WELLORGAS");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_FIVE_YEAR_TREND>(entity =>
        {
            entity.ToTable("ADMIN_FIVE_YEAR_TREND");

            entity.Property(e => e.Year)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI>(entity =>
        {
            entity.ToTable("ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_GASPRODUCTION_UTILIZED_MMSCF>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_GASPRODUCTION_UTILIZED_MMSCF");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_HSE_CONDITION_OF_EQUIPMENT>(entity =>
        {
            entity.ToTable("ADMIN_HSE_CONDITION_OF_EQUIPMENT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_HSE_OSP_REGISTRATIONS_NEW>(entity =>
        {
            entity.ToTable("ADMIN_HSE_OSP REGISTRATIONS_NEW");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_HSE_OSP_REGISTRATIONS_NEW1>(entity =>
        {
            entity.ToTable("ADMIN_HSE_OSP_REGISTRATIONS_NEW");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_INSPECTION_MAINTENANCE>(entity =>
        {
            entity.ToTable("ADMIN_INSPECTION_MAINTENANCE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_LIST_OF_OMLS_OPL>(entity =>
        {
            entity.ToTable("ADMIN_LIST_OF_OMLS_OPLS");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_LITIGATION_JURISDICTION>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_LITIGATION_JURISDICTION");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_MEETING_ROOM>(entity =>
        {
            entity.ToTable("ADMIN_MEETING_ROOM");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.MEETING_ROOM)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_MONTH>(entity =>
        {
            entity.ToTable("ADMIN_MONTHS");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Months)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facility>(entity =>
        {
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_ONGOING_COMPLETED>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADMIN_ONGOING_COMPLETED");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PERFOMANCE_INDEX>(entity =>
        {
            entity.ToTable("ADMIN_PERFOMANCE_INDEX");

            entity.Property(e => e.CONCESSIONTYPE)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Graduation_Scale)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.INDICATOR)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Weight).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PRESENTATION_CATEGORy>(entity =>
        {
            entity.ToTable("ADMIN_PRESENTATION_CATEGORIES");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PRESENTATION_TIME>(entity =>
        {
            entity.ToTable("ADMIN_PRESENTATION_TIME");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.pt)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO>(entity =>
        {
            entity.ToTable("ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT>(entity =>
        {
            entity.ToTable("ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE>(entity =>
        {
            entity.ToTable("ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water>(entity =>
        {
            entity.ToTable("ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_PUBLIC_HOLIDAY>(entity =>
        {
            entity.ToTable("ADMIN_PUBLIC_HOLIDAY");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.public_holidays)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_QUARTER>(entity =>
        {
            entity.ToTable("ADMIN_QUARTER");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_REASON_FOR_ADDITION>(entity =>
        {
            entity.ToTable("ADMIN_REASON_FOR_ADDITION");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.REASON_FOR_ADDITION)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_REASON_FOR_DECLINE>(entity =>
        {
            entity.ToTable("ADMIN_REASON_FOR_DECLINE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.REASON_FOR_DECLINE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_SCHEDULED_STATUS>(entity =>
        {
            entity.ToTable("ADMIN_SCHEDULED_STATUS");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.SCHEDULED_STATUS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_SCRIBE>(entity =>
        {
            entity.ToTable("ADMIN_SCRIBE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.SCRIBE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SCRIBEEMAIL)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASI>(entity =>
        {
            entity.ToTable("ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASIS");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_SUBMISSION_WINDOW>(entity =>
        {
            entity.ToTable("ADMIN_SUBMISSION_WINDOW");

            entity.Property(e => e.CLOSE_DATE).HasColumnType("datetime");
            entity.Property(e => e.Close_date_only)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Close_time_only)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.FLAG_PASSWORD_CHANGE)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LAST_LOGIN_DATE).HasColumnType("datetime");
            entity.Property(e => e.OPEN_DATE).HasColumnType("datetime");
            entity.Property(e => e.Open_date_only)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Open_time_only)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.STATUS_)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_TRAINING_LOCAL_CONTENT>(entity =>
        {
            entity.ToTable("ADMIN_TRAINING_LOCAL_CONTENT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_TRAINING_NIGERIA_CONTENT>(entity =>
        {
            entity.ToTable("ADMIN_TRAINING_NIGERIA_CONTENT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_TYPE_OF_TEST>(entity =>
        {
            entity.ToTable("ADMIN_TYPE_OF_TEST");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.TESTTYPE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TEST_Desc).IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_Terrain>(entity =>
        {
            entity.ToTable("ADMIN_Terrain");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WASTE_MANAGEMENT_FACILITY>(entity =>
        {
            entity.ToTable("ADMIN_WASTE_MANAGEMENT_FACILITY");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WELL_CATEGORy>(entity =>
        {
            entity.ToTable("ADMIN_WELL_CATEGORIES");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.welltype)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WELL_TYPE>(entity =>
        {
            entity.ToTable("ADMIN_WELL_TYPE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.welltype)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WELL_Trajectory>(entity =>
        {
            entity.ToTable("ADMIN_WELL_Trajectory");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.welltype)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WORK_PROGRAM_REPORT>(entity =>
        {
            entity.ToTable("ADMIN_WORK_PROGRAM_REPORT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Report_Content).IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WORK_PROGRAM_REPORT_History>(entity =>
        {
            entity.ToTable("ADMIN_WORK_PROGRAM_REPORT_History");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Report_Content).IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WP_PENALTIES_AUDIT>(entity =>
        {
            entity.ToTable("ADMIN_WP_PENALTIES_AUDIT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NO_SHOW)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.NO_SUBMISSION)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WP_PENALTy>(entity =>
        {
            entity.ToTable("ADMIN_WP_PENALTIES");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NO_SHOW)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.NO_SUBMISSION)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WP_START_END_DATE>(entity =>
        {
            entity.ToTable("ADMIN_WP_START_END_DATE");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.end_date)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.start_date)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WP_START_END_DATE_AUDIT>(entity =>
        {
            entity.ToTable("ADMIN_WP_START_END_DATE_AUDIT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.end_date)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.start_date)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WP_START_END_DATE_DATA_UPLOAD>(entity =>
        {
            entity.ToTable("ADMIN_WP_START_END_DATE_DATA_UPLOAD");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.end_date)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.start_date)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT>(entity =>
        {
            entity.ToTable("ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
            entity.Property(e => e.end_date)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.start_date)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_YEAR>(entity =>
        {
            entity.ToTable("ADMIN_YEAR");

            entity.Property(e => e.Year)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ADMIN_YES_NO>(entity =>
        {
            entity.ToTable("ADMIN_YES_NO");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.categories)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.categories_Desc).IsUnicode(false);
        });

        modelBuilder.Entity<ActualExpenditure>(entity =>
        {
            entity.HasKey(e => e.Actual_ExpenditureId);

            entity.ToTable("ActualExpenditure");

            entity.Property(e => e.Direct_Exploration_Budget)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Equivalent_Naira_Dollar_Component)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Other_Activity_Budget)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ActualProposed_Year>(entity =>
        {
            entity.HasKey(e => e.ActualProposedYearId);

            entity.ToTable("ActualProposed_Year");

            entity.Property(e => e.ActualProposedYear)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.Property(e => e.ApprovalRef)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(25);
            entity.Property(e => e.SubmittedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApplicationCategory>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.FriendlyName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApplicationDeskHistory>(entity =>
        {
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<ApplicationDocument>(entity =>
        {
            entity.HasKey(e => e.AppDocID).HasName("PK_ApplicationDocuments_UT");

            entity.ToTable("ApplicationDocument");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DocName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DocType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApplicationProccess>(entity =>
        {
            entity.HasKey(e => e.ProccessID).HasName("PK_WorkProccess_");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(500);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(500);
            entity.Property(e => e.ProcessAction).HasMaxLength(100);
            entity.Property(e => e.ProcessStatus).HasMaxLength(100);
            //entity.Property(e => e.TargetTo).HasMaxLength(500);
            //entity.Property(e => e.TriggeredBy).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(500);
        });

        modelBuilder.Entity<Appraisal_Drilling>(entity =>
        {
            entity.ToTable("Appraisal_Drilling");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.HasKey(e => e.AuditLogID).HasName("PK_AuditTrail");

            entity.Property(e => e.AuditAction).IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserID)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_ACTUAL_EXPENDITURE>(entity =>
        {
            entity.ToTable("BUDGET_ACTUAL_EXPENDITURE");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_Direct_Exploration_and_Production_Activities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_Direct_Exploration_and_Production_Activities_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_Direct_Exploration_and_Production_Activities_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_other_Activities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_other_Activities_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_other_Activities_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Equivalent_Naira_and_Dollar_Component_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Equivalent_Naira_and_Dollar_Component_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Equivalent_Naira_and_Dollar_Component_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_CAPEX>(entity =>
        {
            entity.ToTable("BUDGET_CAPEX");

            entity.Property(e => e.Acquisition)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Appraisal_Well_Drilling)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Buildings)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Civil_Works)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Completions)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Development_Well_Drilling)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Exploratory_Well_Drilling)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Flowlines)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Generators)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OmL_ID)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.OmL_Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Other_Costs)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Other_Equipment)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Pipelines)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Processing)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Reprocessing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Turbines_Compressors)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Workover_Operations)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_CAPEX_OPEX>(entity =>
        {
            entity.ToTable("BUDGET_CAPEX_OPEX");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Dollar_equivalent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Item_Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Item_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.dollar)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.naira)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_OPEX>(entity =>
        {
            entity.ToTable("BUDGET_OPEX");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Company_ID)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Fixed_Cost)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.General_Expenses)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OmL_ID)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OmL_Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Overheads)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Repairs_and_Maintenance_Cost)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Variable_Cost)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy>(entity =>
        {
            entity.ToTable("BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPLETION_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPLETION_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DEVELOPMENT_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DEVELOPMENT_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WORKOVER_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WORKOVER_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy>(entity =>
        {
            entity.ToTable("BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES");

            entity.Property(e => e.ACQUISITION_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ACQUISITION_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.APPRAISAL_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.APPRAISAL_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.EXPLORATION_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EXPLORATION_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROCESSING_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PROCESSING_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.REPROCESSING_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.REPROCESSING_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT>(entity =>
        {
            entity.ToTable("BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CONCEPT_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CONCEPT_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CONSTRUCTION_FABRICATION_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CONSTRUCTION_FABRICATION_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DECOMMISSIONING_ABANDONMENT)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DETAILED_ENGINEERING_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DETAILED_ENGINEERING_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.FEED_COST_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FEED_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.INSTALLATION_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.INSTALLATION_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROCUREMENT_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PROCUREMENT_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UPGRADE_MAINTENANCE_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UPGRADE_MAINTENANCE_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_PERFORMANCE_PRODUCTION_COST>(entity =>
        {
            entity.ToTable("BUDGET_PERFORMANCE_PRODUCTION_COST");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DIRECT_COST_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DIRECT_COST_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.INDIRECT_COST_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.INDIRECT_COST_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT>(entity =>
        {
            entity.ToTable("BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_Direct_Exploration_and_Production_Activities_Dollars)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_Direct_Exploration_and_Production_Activities_Naira)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_other_Activities_Dollars)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_for_other_Activities_Naira)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Company_Expenditure_Dollars)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_Proposal)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BudgetProposal>(entity =>
        {
            entity.HasKey(e => e.Budget_ProposalId);

            entity.ToTable("BudgetProposal");

            entity.Property(e => e.Oil_Gas_Facility_Maintenance).IsUnicode(false);
        });

        modelBuilder.Entity<COMPANY_CONCESSIONS_FIELD>(entity =>
        {
            entity.ToTable("COMPANY_CONCESSIONS_FIELDS");

            entity.Property(e => e.Concession_Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Created_On).HasColumnType("datetime");
            entity.Property(e => e.Field_Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<COMPANY_FIELD>(entity =>
        {
            entity.HasKey(e => e.Field_ID);

            entity.ToTable("COMPANY_FIELDS");

            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Field_Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Field_Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CONCESSION_SITUATION>(entity =>
        {
            entity.ToTable("CONCESSION_SITUATION");

            entity.Property(e => e.Area)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_actual_for_license_or_lease)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Grant_Expiration).HasColumnType("datetime");
            entity.Property(e => e.Did_you_meet_the_minimum_work_programme)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Equity_distribution)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Field_Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Five_year_proposal)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Has_Assignment_of_Interest_Fee_been_paid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Has_Signature_Bonus_been_paid)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_Concession_Rentals_been_paid)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.How_Much_Concession_Rental_have_been_paid_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.How_Much_Renewal_Bonus_have_been_paid_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.How_Much_Signature_Bonus_have_been_paid_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.If_No_why_concession).IsUnicode(false);
            entity.Property(e => e.If_No_why_renewal).IsUnicode(false);
            entity.Property(e => e.If_No_why_sig)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_an_application_for_renewal)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Company)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.No_of_discovered_field)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.No_of_field_producing)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.area_in_square_meter_based_on_company_records)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.proposed_budget_for_each_license_lease)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.relinquishment_retention)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CSR>(entity =>
        {
            entity.HasKey(e => e.CSR_Id);

            entity.ToTable("CSR");

            entity.Property(e => e.All_MOU_Submitted)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CSR_Projects).IsUnicode(false);
            entity.Property(e => e.MOU_with_Community)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Reason_WithOut_MOU).IsUnicode(false);
        });

        modelBuilder.Entity<Class_Table>(entity =>
        {
            entity.HasKey(e => e.ClassId);

            entity.ToTable("Class_Table");

            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CompletionJob>(entity =>
        {
            entity.HasKey(e => e.Completion_JobsId);

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<ConcessionSituation>(entity =>
        {
            entity.HasKey(e => e.Concession_situationId);

            entity.ToTable("ConcessionSituation");

            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Company_Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Concession_Held).IsUnicode(false);
            entity.Property(e => e.Date_Grant_Expiration)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Equity_Shares)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConcessionSituationTwo>(entity =>
        {
            entity.HasKey(e => e.ConcessionSituationId);

            entity.ToTable("ConcessionSituationTwo");

            entity.Property(e => e.ActualBudgetCurrentYr).IsUnicode(false);
            entity.Property(e => e.ApplicationRenewal)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ConcessionRentals)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ContractType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FiveYrsProposal).IsUnicode(false);
            entity.Property(e => e.NoApplicationRenewalReason).IsUnicode(false);
            entity.Property(e => e.NoConcessionRentalsReason).IsUnicode(false);
            entity.Property(e => e.NoSignatureBonusReason).IsUnicode(false);
            entity.Property(e => e.SignatureBonus)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Terrain).IsUnicode(false);
        });

        modelBuilder.Entity<Contract_Type>(entity =>
        {
            entity.ToTable("Contract_Type");

            entity.Property(e => e.ContractType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DRILLING_EACH_WELL_COST>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DRILLING_EACH_WELL_COST");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surface_cordinates_for_each_well_in_degrees)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.well_cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.well_name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DRILLING_EACH_WELL_COST_PROPOSED>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DRILLING_EACH_WELL_COST_PROPOSED");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surface_cordinates_for_each_well_in_degrees)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.well_cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.well_name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DRILLING_OPERATIONS_>(entity =>
        {
            entity.ToTable("DRILLING_OPERATIONS_");

            entity.Property(e => e.Actual_No_Drilled_in_Current_Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Any_New_Discoveries)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Net_Oil_Gas_sand_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Status_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Do_you_have_approval_to_drill)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Give_reasons)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Hydrocarbon_Counts)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.No_of_wells_cored)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Budget_Allocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_No_Drilled)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.State_the_field_where_Discovery_was_made).IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Well_Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DRILLING_OPERATIONS_CATEGORIES_OF_WELL>(entity =>
        {
            entity.ToTable("DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            entity.Property(e => e.Actual_No_Drilled_in_Current_Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Proposed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Actual_wells_name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Any_New_Discoveries)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Basin)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Core_Cost_USD)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Core_Depth_Interval)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cored)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Depth_refrence)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FieldDiscoveryUploadFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HydrocarbonCountUploadFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Hydrocarbon_Counts)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location_name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Measured_depth)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.No_of_wells_cored)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Days_to_Total_Depth)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Propose_well_names)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_No_Drilled)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_cost_per_well)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rig_Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Rig_type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.State_the_field_where_Discovery_was_made)
                .HasMaxLength(4999)
                .IsUnicode(false);
            entity.Property(e => e.Surface_cordinates_for_each_well_in_degrees)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Target_reservoir)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Terrain_Drill)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.True_vertical_depth)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Water_depth)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WellName)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Well_Status_and_Depth)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.spud_date).HasColumnType("date");
            entity.Property(e => e.well_cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.well_name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.well_trajectory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.well_type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Data_Type>(entity =>
        {
            entity.HasKey(e => e.DataTypeId);

            entity.ToTable("Data_Type");

            entity.Property(e => e.Created_by)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DataType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
        });

        modelBuilder.Entity<DecommissioningAbandonment>(entity =>
        {
            entity.ToTable("DecommissioningAbandonment");

            entity.Property(e => e.Abandonment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Accrued_DA_Annual_Payment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CAPEX)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Cumulative_DA_Annual_Payment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.Decommissioning)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OPEX)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DevelopmentDrilling>(entity =>
        {
            entity.HasKey(e => e.Development_DrillingId);

            entity.ToTable("DevelopmentDrilling");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<Development_And_Production>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.Do_You_Have_Any_SubsurfacePlan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Do_You_Have_Reserves_Growth_Strategy_Plan)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FieldHistory)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FiveYears_Projection_Of_Anticipated_Dev_Schemes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Have_You_Submitted_AnnualReseves_BookingStatus)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Type_Of_SubsurfacePlan)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Division_PK);

            entity.Property(e => e.DivisionName)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Drilling_Operation>(entity =>
        {
            entity.HasKey(e => e.Drilling_OperationsId);

            entity.Property(e => e.Actual_no_drilled_current_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_no_drilled_next_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Any_new_discoveries)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Any_new_discoveries_comment)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Category_of_wells_drilled)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.Comment_drill_approval)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Cost_of_drilling_foot)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Do_you_have_approval_to_drill)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Hydrocarbon_counts)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Net_Oil_Gas_Sand)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.No_of_wells_cored)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_exploration_wells_drilled)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Processing_field_paid)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WorkProgram)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exploration_Drilling>(entity =>
        {
            entity.ToTable("Exploration_Drilling");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Net_Oil_Gas_Sand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Well_Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FACILITIES_PROJECT_PERFORMANCE>(entity =>
        {
            entity.ToTable("FACILITIES_PROJECT_PERFORMANCE");

            entity.Property(e => e.Actual_completion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.FLAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.List_of_Projects)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Planned_completion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.areThereEvidenceOfDesignSafetyCaseApproval).IsUnicode(false);
            entity.Property(e => e.evidenceOfDesignSafetyCaseApprovalFilename).IsUnicode(false);
            entity.Property(e => e.evidenceOfDesignSafetyCaseApprovalPath).IsUnicode(false);
            entity.Property(e => e.reasonForNoEvidence).IsUnicode(false);
        });

        modelBuilder.Entity<FIELD_DEVELOPMENT_FIELDS_AND_STATUS>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FIELD_DEVELOPMENT_FIELDS_AND_STATUS");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Development_Plan_Status)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Field_Name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Development_Plan_Status)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Field_Name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FIELD_DEVELOPMENT_PLAN>(entity =>
        {
            entity.ToTable("FIELD_DEVELOPMENT_PLAN");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Are_they_oil_or_gas_wells)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.FDPDocumentFilename)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.How_many_fields_have_FDP)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.How_many_fields_have_approved_FDP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.List_all_the_field_with_FDP).IsUnicode(false);
            entity.Property(e => e.No_of_wells_drilled_in_current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Noof_Producing_Fields)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_wells_proposed_in_the_FDP)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_number_of_wells_from_approved_FDP)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Uploaded_approved_FDP_Document)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Which_fields_do_you_plan_to_submit_an_FDP).IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.how_many_fields_in_concession)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf>(entity =>
        {
            entity.ToTable("FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Condensate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Field_Name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Gas)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Oil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Development_well_name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FacilityConstruction>(entity =>
        {
            entity.HasKey(e => e.Facility_ConstructionId);

            entity.ToTable("FacilityConstruction");

            entity.Property(e => e.Facility_Calibration).IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<Functionality>(entity =>
        {
            entity.HasKey(e => e.FuncId);

            entity.ToTable("Functionality");

            entity.Property(e => e.FuncId)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IconName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MenuId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GAS_PRODUCTION_ACTIVITy>(entity =>
        {
            entity.ToTable("GAS_PRODUCTION_ACTIVITIES");

            entity.Property(e => e.AG_NAG_and_Condensate_in_place_volumes_and_Reserves_Reserves_for_reservoirs_and_Fields)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Amount_Paid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Annotate_clearly_reasons_for_increase_or_reduction_in_Gas_production_utilisation_and_flare_profiles)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Are_you_up_to_date_with_your_NDR_data_submission)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_Actual_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_gas_production_utilisation_and_Flare_volumes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_pressures_for_Gas_and_condensate_Reservoirs)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_production_status_for_all_Gas_and_condensate_Reservoirs)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Custody_Transfer_status)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Domestic_Gas_Supply_DSO)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Domestic_Gas_obligation_met)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Domestic_gas_obligation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Feed_gas_Volumes_into_the_Processing_Facility)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Flared)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Forecast_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_Field_Development_Plan_Approval)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_Plant_Capacity_NEW)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_Production_and_flare_historical_Performance_5_years_Performance_and_Plan)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_Sales_Royalty_Payment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gas_compositional_Analysis)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_flare_Royalty_payment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gas_plant_capacity)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_production_and_flare_historical_performance)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_wells_drilled_and_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_wells_drilled_and_wells_planned)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_annual_NDR_subscription_fee_been_paid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.How_many_NAG_fields_have_approved_Gas_FDP)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_gas_plant)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_license_to_operate_a_gas_plant)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LNG_and_NGLs_Production_forecast)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.License_Renewal_Status_for_all_Gas_plants)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Maturation_plans_for_leads_and_prospects_leading_to_reserves_growth)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NDRFilename)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.No_of_gas_well_drilled)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.No_of_gas_well_planned)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.No_of_ongoing_projects)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.No_of_plannned_projects)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Ongoing_and_planned_Gas_plant_projects)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Pipeline_license_renewal_staus)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Planned_projects_for_domestic_supply)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Plant_Utilization_Capacity)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Plant_maintenance_activities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Production_forecast_for_all_Gas_and_condensate_reservoirs)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Projects_planned_for_Domestic_supply_Gas_to_power_industries_etc)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks_).IsUnicode(false);
            entity.Property(e => e.Sources_of_Gas_utilisation_should_be_clearly_stated)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Substantiate_flare_reduction_methods_with_projects)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Upload_NDR_payment_receipt)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Utilized)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.When_was_the_date_of_your_last_NDR_submission).HasColumnType("date");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.number_of_gas_wells_completed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.number_of_gas_wells_tested)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ongoing_and_planned_Gas_plant_projects_NEW)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.penaltyfeepaid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.proposed_flaring)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.proposed_production)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.proposed_utilization)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GEOPHYSICAL_ACTIVITIES_ACQUISITION>(entity =>
        {
            entity.HasKey(e => e.Geophysical_ActivitiesId).HasName("PK_Geophysical_Activities");

            entity.ToTable("GEOPHYSICAL_ACTIVITIES_ACQUISITION");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year_aquired_data)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Gas_Sales_Royalty_Payment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gas_flare_Royalty_payment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Activity_Timeline)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Completion_Status)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Record_Length_of_Data)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_acquired_geophysical_data)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_area_of_coverage)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_method_of_acquisition)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Contractor)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantum)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_Approved)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_Planned)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_carry_forward)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GEOPHYSICAL_ACTIVITIES_PROCESSING>(entity =>
        {
            entity.ToTable("GEOPHYSICAL_ACTIVITIES_PROCESSING");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year_aquired_data)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Geo_Activity_Timeline)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Any_Ongoing_Processing_Project)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Completion_Status)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Quantum_of_Data)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Quantum_of_Data_carry_over)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Type_of_Data_being_Processed)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Interpreted_Actual)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Interpreted_Proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Contractor)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.No_of_Folds)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processed_Actual)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Processed_Proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_Approved)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_Planned)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Reprocessed_Actual)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reprocessed_Proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Processing)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gas_Production_Activity1>(entity =>
        {
            entity.HasKey(e => e.Gas_Production_ActivityId);

            entity.ToTable("Gas_Production_Activity");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Flared)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Forecast)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Utilized)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gas_Reserve_Update>(entity =>
        {
            entity.HasKey(e => e.Gas_ReserveId);

            entity.ToTable("Gas_Reserve_Update");

            entity.Property(e => e.Additional_Reserve)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Reserve1)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Reserve2)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeographicalActivity>(entity =>
        {
            entity.HasKey(e => e.Geographical_ActivityId);

            entity.ToTable("GeographicalActivity");

            entity.Property(e => e.Actual_Year_A).IsUnicode(false);
            entity.Property(e => e.Actual_Year_B).IsUnicode(false);
            entity.Property(e => e.Proposed_Year_A).IsUnicode(false);
            entity.Property(e => e.Proposed_Year_B).IsUnicode(false);
            entity.Property(e => e.Remark_A).IsUnicode(false);
            entity.Property(e => e.Remark_B).IsUnicode(false);
        });

        modelBuilder.Entity<Geophysical_Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Geophysical_Activities_");

            entity.Property(e => e.Activity_Timeline)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Activity_Timeline_pro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Processed_Reprocessed_Interpreted_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Year_Acquired)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Any_Ongoing_Processing_Project)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Any_acquired_geophysical_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Area_of_Coverage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_Allocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_Allocation_pro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Completion_Status)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Completion_Status_pro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Method_of_Acquisition)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_processing).IsUnicode(false);
            entity.Property(e => e.Quantum_Carry_Forward)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_Carry_Forward_pro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_of_Data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quantum_of_Data_pro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Record_Length_of_Data)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Remarks_pro).IsUnicode(false);
            entity.Property(e => e.Type_of_Data_Acquired)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Data_being_Processed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE>(entity =>
        {
            entity.HasKey(e => e.HSE_Id);

            entity.ToTable("HSE");

            entity.Property(e => e.Relevant_Certificate)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ACCIDENT_INCIDENCE_REPORTING_NEW>(entity =>
        {
            entity.ToTable("HSE_ACCIDENT_INCIDENCE_REPORTING_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.If_YES_were_they_reported)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UploadIncidentStatisticsFilename)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UploadIncidentStatisticsPath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Was_there_any_accident_incidence)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW>(entity =>
        {
            entity.ToTable("HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cause)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consequence)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Frequency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Investigation)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Lesson_Learnt)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Accident_Incidence)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW>(entity =>
        {
            entity.ToTable("HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Condition_of_Equipment)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Equipment_Inspected_as_and_when_due)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_Installation_date).HasColumnType("datetime");
            entity.Property(e => e.Equipment_description)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_manufacturer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_serial_number)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_tag_number)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Function_Test_Result)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Inspection_Report_Review)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Last_Inspection_Type_Performed)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Last_inspection_date).HasColumnType("datetime");
            entity.Property(e => e.Next_Inspection_Date).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Inspection_Type)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.State_reason)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.facility)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW>(entity =>
        {
            entity.ToTable("HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Condition_of_Equipment)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Consequence_of_Failure)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Equipment_Inspected_as_and_when_due)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_Installation_date).HasColumnType("datetime");
            entity.Property(e => e.Equipment_description)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_manufacturer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_serial_number)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_tag_number)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Equipment_type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Function_Test_Result)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Inspection_Report_Review)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Last_Inspection_Type_Performed)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Last_inspection_date).HasColumnType("datetime");
            entity.Property(e => e.Likelihood_of_Failure)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Maximum_Inspection_Interval)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Next_Inspection_Date).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Inspection_Type)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.RBI_Assessment_Date).HasColumnType("datetime");
            entity.Property(e => e.State_reason)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.facility)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_CAUSES_OF_SPILL>(entity =>
        {
            entity.ToTable("HSE_CAUSES_OF_SPILL");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Corrosion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Equipment_Failure)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Erossion_waves_sand)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Human_Error)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Mystery)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Operational_Maintenance_Error)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Sabotage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Quantity_Recovered)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Total_Quantity_Spilled)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YTBD)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.no_of_spills_reported)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_CLIMATE_CHANGE_AND_AIR_QUALITY>(entity =>
        {
            entity.ToTable("HSE_CLIMATE_CHANGE_AND_AIR_QUALITY");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DoyouhaveGHG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.GHGFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.GHGFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST>(entity =>
        {
            entity.ToTable("HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Action_plan_for_PROPOSED_YEAR).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost_involved_).IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Effect_on_your_operations_).IsUnicode(false);
            entity.Property(e => e.No_of_casual_Fatality_).IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Possible_causes_).IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_days_lost_).IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW>(entity =>
        {
            entity.ToTable("HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Action_Plan_for_)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost_involved)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Effect_on_your_operations)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.If_YES_Give_details_on_Community_Related_Disturbances_within_your_operational_area).IsUnicode(false);
            entity.Property(e => e.No_of_casual_Fatality)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Oil_spill_reported)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Possible_causes)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_days_lost)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Was_any_Oil_Spill_recorded_within_your_operational_area)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Was_there_any_Community_Related_Disturbances_within_your_operational_area)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW>(entity =>
        {
            entity.ToTable("HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NUMBER)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quantity_Recovered)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Quantity_spilled)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_DESIGNS_SAFETY>(entity =>
        {
            entity.ToTable("HSE_DESIGNS_SAFETY");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DESIGNS_SAFETY_Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DESIGNS_SAFETY_Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DESIGNS_SAFETY_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_EFFLUENT_MONITORING_COMPLIANCE>(entity =>
        {
            entity.ToTable("HSE_EFFLUENT_MONITORING_COMPLIANCE");

            entity.Property(e => e.AreThereEvidentOfSampling)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CompanyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.EvidenceOfSamplingFilename)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.EvidenceOfSamplingPath)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OmL_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForNoEvidenceSampling)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DPR_Approved)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Name_of_Chemical)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_2)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_3)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_4)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Are_you_a_Producing_or_Non_Producing_Company)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Have_you_submitted_your_Chemical_Usage_Inventorization_Report)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Have_you_submitted_your_Environmental_Compliance_Report)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_Give_reasons_for_non_SUBMISSION)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_Give_reasons_for_non_submission_2)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_give_reasons_for_not_registering_your_Point_Sources)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.If_YES_have_you_registered_your_Point_Sources)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_2)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_3)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Quarter_4)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Report)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_IMPACT_ASSESSMENT>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.In_progress_Started_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Pre_Impact_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_MANAGEMENT_PLAN>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_MANAGEMENT_PLAN");

            entity.Property(e => e.AreThereEMP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.FacilityLocation)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FacilityType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OmL_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RemarkIfNoEMP)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM");

            entity.Property(e => e.AUDITFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AUDITFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.EMSFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.EMSFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Study_IA_or_EES)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YEAR_)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_STUDIES_NEW>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_STUDIES_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Any_Environmental_Studies)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.If_Ongoing)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.If_YES_state_Project_Name)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED>(entity =>
        {
            entity.ToTable("HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DPR_approval_Status)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.current_study_status)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.field_name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.study_title)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.type_of_study)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_FATALITy>(entity =>
        {
            entity.ToTable("HSE_FATALITIES");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_DATA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Fatalities_Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fatalities_Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fatalities_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_DATA)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.type_of_incidence)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_GHG_MANAGEMENT_PLAN>(entity =>
        {
            entity.ToTable("HSE_GHG_MANAGEMENT_PLAN");

            entity.Property(e => e.CompanY_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DoYouHaveGHG)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DoYouHaveLDRCertificate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GHGApprovalFilename)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.GHGApprovalPath)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.LDRCertificateFilename)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.LDRCertificatePath)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.OmL_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OmL_Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForNoGHG)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForNoLDR)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.companyemail)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_HOST_COMMUNITIES_DEVELOPMENT>(entity =>
        {
            entity.ToTable("HSE_HOST_COMMUNITIES_DEVELOPMENT");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DoYouHaveEvidenceOfPay)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DoYouHaveEvidenceOfReg)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EvidenceOfPayTrustFundFilename)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.EvidenceOfPayTrustFundPath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.EvidenceOfRegTrustFundFilename)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.EvidenceOfRegTrustFundPath)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OmL_ID)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForNoEvidenceOfPayTF)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForNoEvidenceOfRegTF)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UploadCommDevPlanApprovalFilename)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UploadCommDevPlanApprovalPath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW>(entity =>
        {
            entity.ToTable("HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Facility_Type)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.If_No_Give_reasonS)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.If_RBI_was_approval_granted)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_facility)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Inspection_and_Maintenance)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.When_was_it_carried_out)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.was_the_inspection_and_maintenemce)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_INSPECTION_AND_MAINTENANCE_NEW>(entity =>
        {
            entity.ToTable("HSE_INSPECTION_AND_MAINTENANCE_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.If_No_Give_reasonS)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.If_RBI_was_approval_granted)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Is_the_inspection_philosophy_Prescriptive_or_RBI_for_each_facility)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Was_Inspection_and_Maintenance_of_each_of_your_facility_carried_out)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_MANAGEMENT_POSITION>(entity =>
        {
            entity.ToTable("HSE_MANAGEMENT_POSITION");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OrganogramrFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.OrganogramrFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PromotionLetterFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PromotionLetterFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_MinimumRequirement>(entity =>
        {
            entity.ToTable("HSE_MinimumRequirement");

            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.Is_Company_ISO45001_Certified)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Provide_ISO45001_Certification_No)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_OCCUPATIONAL_HEALTH_MANAGEMENT>(entity =>
        {
            entity.ToTable("HSE_OCCUPATIONAL_HEALTH_MANAGEMENT");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DoYouHaveAnOhm)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OHMplanCommunicationFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OHMplanCommunicationFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OHMplanFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.OHMplanFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForNoOhm)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ReasonWhyOhmWasNotCommunicatedToStaff)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.SMSFileUploadname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WasOhmPolicyCommunicatedToStaff)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_OIL_SPILL_INCIDENT>(entity =>
        {
            entity.ToTable("HSE_OIL_SPILL_INCIDENT");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Number_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Quantity_Recovered_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quantity_spilled_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_OIL_SPILL_REPORTING_NEW>(entity =>
        {
            entity.ToTable("HSE_OIL_SPILL_REPORTING_NEW");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cause_of_spill)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Date_of_Spill).HasColumnType("datetime");
            entity.Property(e => e.Facility_Equipment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Incident_Oil_Spill_Ref_No)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LGA)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.State_)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_operation_at_spill_site)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Volume_of_spill_bbls)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Volume_recovered_bbls)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_OPERATIONS_SAFETY_CASE>(entity =>
        {
            entity.ToTable("HSE_OPERATIONS_SAFETY_CASE");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Does_the_Facility_Have_a_Valid_Safety_Case)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Evidence_of_Operations_Safety_Case_Approval)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Location_of_Facility)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Name_Of_Facility)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Facilities)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reason_If_No_Evidence)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Facility)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_OSP_REGISTRATIONS_NEW>(entity =>
        {
            entity.ToTable("HSE_OSP_REGISTRATIONS_NEW");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DESCRIPTION_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VALUES_)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_POINT_SOURCE_REGISTRATION>(entity =>
        {
            entity.ToTable("HSE_POINT_SOURCE_REGISTRATION");

            entity.Property(e => e.CompanyName).IsUnicode(false);
            entity.Property(e => e.Company_Email).IsUnicode(false);
            entity.Property(e => e.Company_ID).IsUnicode(false);
            entity.Property(e => e.Company_Number).IsUnicode(false);
            entity.Property(e => e.OML_ID).IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP).IsUnicode(false);
            entity.Property(e => e.are_there_point_source_permit).IsUnicode(false);
            entity.Property(e => e.evidence_of_PSP_filename).IsUnicode(false);
            entity.Property(e => e.evidence_of_PSP_path).IsUnicode(false);
            entity.Property(e => e.reason_for_no_PSP).IsUnicode(false);
        });

        modelBuilder.Entity<HSE_PRODUCED_WATER_MANAGEMENT_NEW>(entity =>
        {
            entity.ToTable("HSE_PRODUCED_WATER_MANAGEMENT_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Export_to_Terminal_with_fluid)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Within_which_zone_are_you_operating)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.how_do_you_handle_your_produced_water)
                .HasMaxLength(3900)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED>(entity =>
        {
            entity.ToTable("HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Concession)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DEPTH_AND_DISTANCE_FROM_SHORELINE)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.DPR_APPROVAL_STATUS)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Disposal_philosophy)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.FIELD_NAME)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Produced_water_volumes)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.facilities)
                .HasMaxLength(3999)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_QUALITY_CONTROL>(entity =>
        {
            entity.ToTable("HSE_QUALITY_CONTROL");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DoyouhaveQualityControl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.QualityControlFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.QualityControlFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valid_Accreditation_Letter_For_QualityControl)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_QUESTION>(entity =>
        {
            entity.ToTable("HSE_QUESTIONS");

            entity.Property(e => e.Accident_Stat)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Qty_Spilled)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Relevant_Certificate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_REMEDIATION_FUND>(entity =>
        {
            entity.ToTable("HSE_REMEDIATION_FUND");

            entity.Property(e => e.CompanyName).IsUnicode(false);
            entity.Property(e => e.Company_Email).IsUnicode(false);
            entity.Property(e => e.Company_ID).IsUnicode(false);
            entity.Property(e => e.Company_Number).IsUnicode(false);
            entity.Property(e => e.OML_ID).IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP).IsUnicode(false);
            entity.Property(e => e.evidenceOfPaymentFilename).IsUnicode(false);
            entity.Property(e => e.evidenceOfPaymentPath).IsUnicode(false);
            entity.Property(e => e.reasonForNoRemediation).IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SAFETY_CULTURE_TRAINING>(entity =>
        {
            entity.ToTable("HSE_SAFETY_CULTURE_TRAINING");

            entity.Property(e => e.AreThereTrainingPlansForHSE).IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.EvidenceOfTrainingPlanFilename).IsUnicode(false);
            entity.Property(e => e.EvidenceOfTrainingPlanPath).IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SafetyCurrentYearFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.SafetyCurrentYearFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SafetyLast2YearsFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SafetyLast2YearsFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SAFETY_STUDIES_NEW>(entity =>
        {
            entity.ToTable("HSE_SAFETY_STUDIES_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Did_you_carry_out_safety_studies)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.DoyouhaveSMSinPlace)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.List_identified_Major_Accident_Hazards_for_the_study)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.List_the_Safeguards_based_on_the_identified_Major_Accident_Hazards)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.List_the_studies)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SMSFileUploadPath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.State_Project_Name_for_which_studies_was_carried_out)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Spent_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CSR_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Completion_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW");

            entity.Property(e => e.Actual_Proposed_Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Spent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Beneficiary_Communities).IsUnicode(false);
            entity.Property(e => e.Budget_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CSR_)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Completion_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship>(entity =>
        {
            entity.Property(e => e.Actual_Proposed_Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Spent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Beneficiary_Communities_National).IsUnicode(false);
            entity.Property(e => e.Beneficiary_Communities_host).IsUnicode(false);
            entity.Property(e => e.Budget_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CSR_)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Completion_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition");

            entity.Property(e => e.Actual_Proposed_Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Spent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Beneficiary_Communities_National).IsUnicode(false);
            entity.Property(e => e.Beneficiary_Communities_host).IsUnicode(false);
            entity.Property(e => e.Budget_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CSR_)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Completion_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU");

            entity.Property(e => e.Actual_Budget_Total_Dollars)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Beneficiary_Community)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Component_of_project)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.MOUUploadFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MOUUploadFilename)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Project_Location)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Status_Of_Project)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_project_excuted)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_GMou_was_signed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Description_of_Projects_Actual).IsUnicode(false);
            entity.Property(e => e.Description_of_Projects_Planned).IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Do_you_have_an_MOU_with_the_communities_for_all_your_assets)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Have_you_submitted_all_MoUs_to_DPR)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_why)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MOUOSCPFilePath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MOUOSCPFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MOUResponderFilePath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MOUResponderFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MOUResponderInPlace)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME");

            entity.Property(e => e.Actual_Budget_Total_Dollars)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ComponentOfScholarship)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NameOfCommunity)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SSUploadFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SSUploadFilename)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ScholarshipYear)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_GMou_was_signed)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME>(entity =>
        {
            entity.ToTable("HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME");

            entity.Property(e => e.Actual_Budget_Total_Dollars)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ComponentOfTraining)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NameOfCommunity)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StatusOfTraining)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TSUploadFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TSUploadFilename)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrainingYear)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_GMou_was_signed)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW>(entity =>
        {
            entity.ToTable("HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.approval_status)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.facility)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.facility_location)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.number_of_facilities).IsUnicode(false);
            entity.Property(e => e.remarks)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.study_type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.type_of_facility).IsUnicode(false);
        });

        modelBuilder.Entity<HSE_WASTE_MANAGEMENT_NEW>(entity =>
        {
            entity.ToTable("HSE_WASTE_MANAGEMENT_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Are_Registered_Point_Sources_Valid)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Commitment_To_Waste_Management)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Do_you_have_Waste_Management_facilities)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Evidence_Of_Submission_Of_Journey_MGT_Plan)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Evidence_Of_Submission_Of_PreviousYears_Waste_Release)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_give_reasons_for_not_being_registered)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.If_YES_is_the_facility_registered)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_WASTE_MANAGEMENT_SYSTEM>(entity =>
        {
            entity.ToTable("HSE_WASTE_MANAGEMENT_SYSTEM");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DecomCertificateFilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DecomCertificateFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WasteManagementPlanFilePath)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.WasteManagementPlanFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW>(entity =>
        {
            entity.ToTable("HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW");

            entity.Property(e => e.ACTUAL_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Approved_or_Not_Approve)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.LOCATION)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PROPOSED_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Facility)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<INITIAL_WELL_COMPLETION_JOB1>(entity =>
        {
            entity.ToTable("INITIAL_WELL_COMPLETION_JOBS");

            entity.Property(e => e.Actual_Completion_Date).HasColumnType("date");
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Number)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Budget_Allocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Do_you_have_approval_to_complete_the_well)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Completion_Date).HasColumnType("date");
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.oil_or_gas_wells)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Initial_Well_Completion_Job>(entity =>
        {
            entity.HasKey(e => e.Initial_Well_CompletionId).HasName("PK_Initial_Well_Completion");

            entity.ToTable("Initial_Well_Completion_Job");

            entity.Property(e => e.Actual_No_Current_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_No_Proposed_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budget_Allocation_Proposed_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Do_you_have_approval_to_complete_the_well)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Remark).IsUnicode(false);
            entity.Property(e => e.Year_of_WorkProgram)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LEGAL_ARBITRATION>(entity =>
        {
            entity.ToTable("LEGAL_ARBITRATION");

            entity.Property(e => e.AnyLitigation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Any_orders_made_so_far_by_the_court)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Case_Number)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Jurisdiction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Court)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Names_of_Parties)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Potential_outcome)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Summary_of_the_case)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LEGAL_LITIGATION>(entity =>
        {
            entity.ToTable("LEGAL_LITIGATION");

            entity.Property(e => e.AnyLitigation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Any_orders_made_so_far_by_the_court)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Case_Number)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Jurisdiction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Court)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Names_of_Parties)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Potential_outcome)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Summary_of_the_case)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMME>(entity =>
        {
            entity.ToTable("LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES");

            entity.Property(e => e.Actual_Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Current_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate>(entity =>
        {
            entity.ToTable("LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Expatriate_Quota_projection_for_proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.List_of_Expatriate_positions_that_will_expire)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.List_of_Understudies_that_had_successfully_taken_over_from_expatriates_in_the_last_4_years)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training>(entity =>
        {
            entity.ToTable("LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Foreign_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Local_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Training_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training>(entity =>
        {
            entity.ToTable("LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Foreign_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Local_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Training_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Legal>(entity =>
        {
            entity.HasKey(e => e.Legal_Id);

            entity.ToTable("Legal");

            entity.Property(e => e.Company_Fined)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Company_FinedReason).IsUnicode(false);
            entity.Property(e => e.Company_Sanctioned)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LocalContent>(entity =>
        {
            entity.HasKey(e => e.Local_ContentId);

            entity.ToTable("LocalContent");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Expatriate_Quota_Projection).IsUnicode(false);
            entity.Property(e => e.List_of_Expiry_Expatriate).IsUnicode(false);
            entity.Property(e => e.List_of_Understudies).IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.MenuId)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IconName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.UserType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.content).IsUnicode(false);
            entity.Property(e => e.sender_id).HasMaxLength(200);
            entity.Property(e => e.subject)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MyDesk>(entity =>
        {
            entity.HasKey(e => e.DeskID).HasName("PK_MyDesk_UT");

            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FromSBU)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<NDPR_SUBSCRIPTION_FEE>(entity =>
        {
            entity.ToTable("NDPR_SUBSCRIPTION_FEE");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Data_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Did_you_process_data_for_current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_annual_NDR_subscription_fee_been_paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Volume_of_data_processed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NDR>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NDR");

            entity.Property(e => e.Are_you_up_to_date_with_your_NDR_data_submission)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Has_annual_NDR_subscription_fee_been_paid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NDRFilename)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Upload_NDR_payment_receipt)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.When_was_the_date_of_your_last_NDR_submission).HasColumnType("date");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NDR_DATA_POPULATION_ON_BLOCK_BASI>(entity =>
        {
            entity.ToTable("NDR_DATA_POPULATION_ON_BLOCK_BASIS");

            entity.Property(e => e.Actual_YEAR_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NDR_Data_Population>(entity =>
        {
            entity.HasKey(e => e.NDRDataId);

            entity.ToTable("NDR_Data_Population");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Annual_Sub_Fee)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Data_Type)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Processed_Data)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Reason_For_Non_Payment).IsUnicode(false);
            entity.Property(e => e.Reason_Non_Processed_Data).IsUnicode(false);
            entity.Property(e => e.Subscription_Fee_Upload).IsUnicode(false);
        });

        modelBuilder.Entity<NIGERIA_CONTENT>(entity =>
        {
            entity.ToTable("NIGERIA_CONTENT");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Do_you_have_a_valid_Expatriate_Quota_for_your_foreign_staff)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_why)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_succession_plan_in_place)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_staff_released_within_the_year_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NIGERIA_CONTENT_QUESTION>(entity =>
        {
            entity.ToTable("NIGERIA_CONTENT_QUESTION");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Do_you_have_a_valid_Expatriate_Quota_for_your_foreign_staff)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.If_NO_why)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_succession_plan_in_place)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_staff_released_within_the_year_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.total_no_of_nigeria_senior_staff)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.total_no_of_senior_staff)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.total_no_of_top_management_staff)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.total_no_of_top_nigerian_management_staff)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NIGERIA_CONTENT_Training>(entity =>
        {
            entity.ToTable("NIGERIA_CONTENT_Training");

            entity.Property(e => e.Actual_Proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Proposed_Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Expatriate_quota_positions)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Foreign_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Local_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Management_Foriegn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Management_Local)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nigerian_Understudies)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Staff_Foriegn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Staff_Local)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Training_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Utilized_EQ)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NIGERIA_CONTENT_Upload_Succession_Plan>(entity =>
        {
            entity.ToTable("NIGERIA_CONTENT_Upload_Succession_Plan");

            entity.Property(e => e.Actual_Proposed_Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Name_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Position_Occupied_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Timeline_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Understudy_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NigerianContent>(entity =>
        {
            entity.HasKey(e => e.Nigerian_ContentId);

            entity.ToTable("NigerianContent");

            entity.Property(e => e.Position_Occupied)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reason_For_NonExpatriate).IsUnicode(false);
            entity.Property(e => e.Succession_PlanName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Succession_PlanTimeLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Succession_PlanUnderStudy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Succession_Plan_in_Place)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Valid_Expatriate)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_AND_GAS_FACILITY_MAINTENANCE>(entity =>
        {
            entity.ToTable("OIL_AND_GAS_FACILITY_MAINTENANCE");

            entity.Property(e => e.Actual_capital_expenditure_Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Approval_License_Permits)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_Performance)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CAPEX_Oversight)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Challenges)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Comment_).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Completion_Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Conceptual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Conformity_Assessment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Construction_Commissioning_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Detailed_Engineering)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FEED)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_it_been_adopted_by_DPR_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Major_Projects)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.New_Technology_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Objective_Drivers_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Planned_ongoing_and_routine_maintenance)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Production_Product_Offtakers)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Project_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Capital_Expenditure)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE>(entity =>
        {
            entity.ToTable("OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE");

            entity.Property(e => e.Actual_capital_expenditure_Current_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_capital_expenditure_Current_year_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_capital_expenditure_Current_year_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Capital_Expenditure)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Capital_Expenditure_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Capital_Expenditure_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT>(entity =>
        {
            entity.ToTable("OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS");

            entity.Property(e => e.Actual_Proposed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_Proposed_year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Actual_capital_expenditure_Current_year_NGN)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_capital_expenditure_Current_year_USD)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Approval_License_Permits)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Budget_Performance)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CAPEX_Oversight)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Challenges)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Comment_).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Completion_Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Conceptual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Conformity_Assessment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Construction_Commissioning_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Detailed_Engineering)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FEED)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_it_been_adopted_by_DPR_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Major_Projects)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.New_Technology_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nigerian_Content_Value)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Objective_Drivers_).IsUnicode(false);
            entity.Property(e => e.Planned_ongoing_and_routine_maintenance)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Product_Off_takers)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Production_Product_Offtakers)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Project_Stage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Project_Timeline_StartDate).HasColumnType("datetime");
            entity.Property(e => e.Project_Timeline_EndDate).HasColumnType("datetime");
            entity.Property(e => e.Proposed_Capital_Expenditure_NGN)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Capital_Expenditure_USD)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION>(entity =>
        {
            entity.ToTable("OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Committees_been_inaugurated)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Name_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost_Barrel)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Daily_Production_)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Deferment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Did_you_carry_out_any_well_test)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_NAG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Forecast)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_DPR_been_notified)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_CA_been_signed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_PUA_been_signed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_UUOA_been_signed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_other_party_been_notified)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.How_many_fields_straddle)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_any_of_your_field_straddling)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_Joint_Development)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Maximum_Efficiency_Rate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Producing_Wells)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Test_Carried_out)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Participation_been_determined)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prod_Status_OC)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prod_Status_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductionOilCondensateAGNAGUFilename).IsUnicode(false);
            entity.Property(e => e.ProductionOilCondensateAGNAGUploadFilePath).IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Straddling_Field_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Straddling_Fields_OC)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Reconciled_National_Crude_Oil_Production)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Test)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment>(entity =>
        {
            entity.ToTable("OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment");

            entity.Property(e => e.Benefits)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Challenges)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DPR_Consent).IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Existing_Alternatives)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Objective)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facility>(entity =>
        {
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Operating_Facilities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION>(entity =>
        {
            entity.ToTable("OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Committees_been_inaugurated)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Name_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost_Barrel)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Daily_Production_)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Deferment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Did_you_carry_out_any_well_test)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_NAG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Forecast)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_DPR_been_notified)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_CA_been_signed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_PUA_been_signed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_UUOA_been_signed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_other_party_been_notified)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.How_many_fields_straddle)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_any_of_your_field_straddling)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_Joint_Development)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Maximum_Efficiency_Rate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Producing_Wells)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Test_Carried_out)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Oil_Royalty_Payment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PUAUploadFilePath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PUAUploadFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Participation_been_determined)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prod_Status_OC)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prod_Status_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Straddling_Field_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Straddling_Fields_OC)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Reconciled_National_Crude_Oil_Production)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Test)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UUOAUploadFilePath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UUOAUploadFilename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.straddle_field_producing)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.what_concession_field_straddling)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED>(entity =>
        {
            entity.ToTable("OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED");

            entity.Property(e => e.Avg_Daily_Production)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Gas_AG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gas_NAG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Production)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Production_month)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity>(entity =>
        {
            entity.Property(e => e.Avg_Daily_Production)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Gas_AG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gas_NAG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Production)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Production_month)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OIL_CONDENSATE_PRODUCTION_ACTIVITy>(entity =>
        {
            entity.ToTable("OIL_CONDENSATE_PRODUCTION_ACTIVITIES");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Committees_been_inaugurated)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Name_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost_Barrel)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Daily_Production_)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Deferment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Did_you_carry_out_any_well_test)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_NAG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Forecast)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gas_AG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gas_NAG)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Has_DPR_been_notified)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_CA_been_signed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_PUA_been_signed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_UUOA_been_signed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Has_the_other_party_been_notified)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.How_many_fields_straddle)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_any_of_your_field_straddling)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Is_there_a_Joint_Development)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Maximum_Efficiency_Rate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Producing_Wells)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Test_Carried_out)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Oil_Royalty_Payment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Participation_been_determined)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prod_Status_OC)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prod_Status_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Straddling_Field_OP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Straddling_Fields_OC)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Reconciled_National_Crude_Oil_Production)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type_of_Test)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.straddle_field_producing)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.what_concession_field_straddling)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OilCondensateProduction>(entity =>
        {
            entity.HasKey(e => e.Oil_Condensate_ProductionId);

            entity.ToTable("OilCondensateProduction");

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Deferment)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Forecast)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<OilSpill_Incident>(entity =>
        {
            entity.HasKey(e => e.Oil_Spill_IncidentId);

            entity.ToTable("OilSpill_Incident");

            entity.Property(e => e.Action_Plan).IsUnicode(false);
            entity.Property(e => e.Effect_on_Operation).IsUnicode(false);
            entity.Property(e => e.Evidence_Of_MOUs_With_CAN)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Evidence_Of_QuaterlySubmissions_Of_OilField_Chemicals)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.InProgress_StartedYr)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Possible_Cost).IsUnicode(false);
            entity.Property(e => e.Pre_Impact)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Proof_Of_Submission_Of_Valid_OSCP)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT>(entity =>
        {
            entity.ToTable("PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTS");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.uploaded_presentation)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PRESENTATION_UPLOAD>(entity =>
        {
            entity.ToTable("PRESENTATION_UPLOAD");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.check_status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.original_filemane)
                .HasMaxLength(2500)
                .IsUnicode(false);
            entity.Property(e => e.upload_extension)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.uploaded_presentation)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PermitApproval>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateExpired).HasPrecision(0);
            entity.Property(e => e.DateIssued).HasPrecision(0);
            entity.Property(e => e.IsRenewed).HasMaxLength(130);
            entity.Property(e => e.PermitNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Planning_MinimumRequirement>(entity =>
        {
            entity.ToTable("Planning_MinimumRequirement");

            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.ReservesRevenue_GrossProduction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReservesRevenue_RemainingReserves)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_REPLACEMENT_RATIO>(entity =>
        {
            entity.ToTable("RESERVES_REPLACEMENT_RATIO");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RESERVES_REPLACEMENT_RATIO_VALUE)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Trend_Year)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_DEPLETION_RATE>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_DEPLETION_RATE");

            entity.Property(e => e.AG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CONDENSATE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NAG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OIL)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_LIFE_INDEX>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_LIFE_INDEX");

            entity.Property(e => e.AG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CONDENSATE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.NAG)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OIL)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE");

            entity.Property(e => e.Additional_Reserves_as_at_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_AnnualOilProduction)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Current_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Current_AnnualOilProduction)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Current_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Current_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Current_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Current_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualOilProduction)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_AnnualOilProduction)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Reason_for_Addition)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Was_there_any_Reserve_Addition)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Reason_for_Decline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Was_there_a_decline_in_reserve)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl).IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl_P1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_GOR)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Reservoir)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Reservoir_Pressure)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Reservoir_Performance_Reservoir Pressure");
            entity.Property(e => e.Reservoir_Performance_Sand_Cut)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_WCT)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Production_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualOilProduction)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Annual_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Fiveyear_Projection_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fiveyear_Projection_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_MMBBL>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_MMBBL");

            entity.Property(e => e.Additional_Reserves_as_at_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl_P1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl_condensate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl_gas)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Production_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_GOR)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Reservoir)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Reservoir_Pressure)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Sand_Cut)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_Timeline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reservoir_Performance_WCT)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Reason_for_Addition)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Addition_Was_there_any_Reserve_Addition)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Reason_for_Decline)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_Decline_Was_there_a_decline_in_reserve)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE>(entity =>
        {
            entity.ToTable("RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE");

            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AG)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualCondensateProduction)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualGasAGProduction)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualGasNAGProduction)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualGasProduction)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_AnnualOilProduction)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Condensate)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_NAG)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Oil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Company_Reserves_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.FLAG1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FLAG2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ROLES_>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROLES_");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SN).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ROLES_SUPER_ADMIN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROLES_SUPER_ADMIN");

            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Deleted_Date)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Deleted_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Deleted_status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email_)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role_)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SN).ValueGeneratedOnAdd();
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserve_Update_Oil_Condensate>(entity =>
        {
            entity.HasKey(e => e.Reserve_UpdateId);

            entity.ToTable("Reserve_Update_Oil_Condensate");

            entity.Property(e => e.Additional_Reserves)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.P1_Reserve)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Reserves)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.id).ValueGeneratedOnAdd();

            entity.HasMany(d => d.Funcs).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleFunctionalityRef",
                    r => r.HasOne<Functionality>().WithMany()
                        .HasForeignKey("FuncId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleFunctionalityRef_Functionality"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleFunctionalityRef_Role"),
                    j =>
                    {
                        j.HasKey("RoleId", "FuncId");
                        j.ToTable("RoleFunctionalityRef");
                    });
        });

        modelBuilder.Entity<Royalty>(entity =>
        {
            entity.HasKey(e => e.Royalty_ID);

            entity.ToTable("Royalty");

            entity.Property(e => e.Concession_Rentals)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Crude_Oil_Royalty)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("date");
            entity.Property(e => e.Gas_Flare_Payment)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gas_Sales_Royalty)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Last_Qntr_Royalty)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Miscellaneous)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SBU_ApplicationComment>(entity =>
        {
            //entity.HasNoKey();

            entity.Property(e => e.ActionStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SBU_Comment).IsUnicode(false);
            entity.Property(e => e.SBU_Tables).IsUnicode(false);
        });

        modelBuilder.Entity<SBU_Record>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Records).IsUnicode(false);
        });

        modelBuilder.Entity<STRATEGIC_PLANS_ON_COMPANY_BASI>(entity =>
        {
            entity.ToTable("STRATEGIC_PLANS_ON_COMPANY_BASIS");

            entity.Property(e => e.ACTIVITIES)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.N_1_Q1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_1_Q2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_1_Q3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_1_Q4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_2_Q1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_2_Q2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_2_Q3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_2_Q4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_3_Q1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_3_Q2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_3_Q3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_3_Q4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_4_Q1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_4_Q2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_4_Q3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_4_Q4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_5_Q1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_5_Q2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_5_Q3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.N_5_Q4)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SafetyManagement>(entity =>
        {
            entity.HasKey(e => e.Safety_ManagementId);

            entity.ToTable("SafetyManagement");

            entity.Property(e => e.Current_Facilities).IsUnicode(false);
            entity.Property(e => e.Current_Year).IsUnicode(false);
            entity.Property(e => e.Design_Safety_Control).IsUnicode(false);
            entity.Property(e => e.Fatalities).IsUnicode(false);
            entity.Property(e => e.Previous_Facilities).IsUnicode(false);
            entity.Property(e => e.Previous_Year).IsUnicode(false);
        });

        modelBuilder.Entity<StrategicBusinessUnit>(entity =>
        {
            entity.Property(e => e.SBU_Code).HasMaxLength(10);
            entity.Property(e => e.SBU_Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubmittedDocument>(entity =>
        {
            entity.HasKey(e => e.SubDocID);

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DocSource).IsUnicode(false);
            entity.Property(e => e.DocumentCategory)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DocumentName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<SubstainableDevelopment>(entity =>
        {
            entity.HasKey(e => e.Substainable_DevelopmentId);

            entity.ToTable("SubstainableDevelopment");

            entity.Property(e => e.Descript_of_Project_Actual).IsUnicode(false);
            entity.Property(e => e.Descript_of_Project_Planned).IsUnicode(false);
        });

        modelBuilder.Entity<Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_Days_to_Total_Depth)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Well_Status_and_Depth)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.spud_date).HasColumnType("date");
            entity.Property(e => e.well_cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.well_name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITION");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Contractor)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sum_GEOPHYSICAL_ACTIVITIES_PROCESSING>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sum_GEOPHYSICAL_ACTIVITIES_PROCESSING");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Type_of_Data_being_Processed)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name_of_Contractor)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table_1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table_1");

            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table_Detail>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.Property(e => e.SBU_ID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TableSchema)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrainingForStaff>(entity =>
        {
            entity.HasKey(e => e.Training_For_StaffId);

            entity.ToTable("TrainingForStaff");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginPk, e.UserId });

            entity.ToTable("UserLogin");

            entity.Property(e => e.LoginPk).ValueGeneratedOnAdd();
            entity.Property(e => e.UserId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Browser).IsUnicode(false);
            entity.Property(e => e.Client)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoginMessage).IsUnicode(false);
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserMaster");

            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT");

            entity.Property(e => e.Appraisal_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Appraisal_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Development_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Development_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Exploration_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Exploration_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover");

            entity.Property(e => e.Appraisal_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Appraisal_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Number)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Number_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Development_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Development_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Exploration_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Exploration_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Expr4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr6)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Expr7)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_name_WORKOVERS_RECOMPLETION_JOBS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.oml_name_INITIAL_WELL_COMPLETION_JOBS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.oml_name_VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover__join_Contracttype>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover _join_Contracttype");

            entity.Property(e => e.Appraisal_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Appraisal_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Number)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Number_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Development_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Development_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Exploration_Actual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Exploration_Proposed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Expr4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr6)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Expr7)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Expr8)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_name_WORKOVERS_RECOMPLETION_JOBS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.oml_name_INITIAL_WELL_COMPLETION_JOBS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.oml_name_VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_companyemail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_companyemail");

            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_contract_type>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_contract_type");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year_companyemail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year_companyemail");

            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_appraisal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_appraisal");

            entity.Property(e => e.Actual_No_Drilled_in_Current_Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.No_of_wells_cored)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_No_Drilled)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_development>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_development");

            entity.Property(e => e.Actual_No_Drilled_in_Current_Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.No_of_wells_cored)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_No_Drilled)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_exploration>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_exploration");

            entity.Property(e => e.Actual_No_Drilled_in_Current_Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.No_of_wells_cored)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_No_Drilled)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_GAS_PRODUCTION_ACTIVITIES_total>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_GAS_PRODUCTION_ACTIVITIES_total");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_GAS_PRODUCTION_ACTIVITIES_total_summed>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_GAS_PRODUCTION_ACTIVITIES_total_summed");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_GAS_PRODUCTION_ACTIVITy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_GAS_PRODUCTION_ACTIVITIES");

            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Current_Actual_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Flared)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Forecast_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Utilized)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_GEOPHYSICAL_ACTIVITIES_PROCESSING>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_GEOPHYSICAL_ACTIVITIES_PROCESSING");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Completion_Status)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Quantum_of_Data)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geo_Type_of_Data_being_Processed)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name_)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.companyemail_)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_GEOPHYSICAL_ACTIVITIES_PROCESSING_SUM_BY_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_GEOPHYSICAL_ACTIVITIES_PROCESSING_SUM_BY_YEAR");

            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_Geophysical_SEISMIC_DATA_old>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Geophysical_SEISMIC_DATA_old");

            entity.Property(e => e.Actual_year_aquired_data_ACQUISITION)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year_aquired_data_PROCESSING)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_ACQUISITION)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_PROCESSING)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.companyemail_ACQUISITION)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.companyemail_PROCESSING)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.companyname_ACQUISITION)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.companyname_PROCESSING)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data_ACQUISITION)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data_PROCESSING)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_Geophysical_SEISMIC_DATA_total>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Geophysical_SEISMIC_DATA_total");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_ACQUISITION)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_Geophysical_SEISMIC_DATA_total_summed>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Geophysical_SEISMIC_DATA_total_summed");

            entity.Property(e => e.Year_ACQUISITION)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_Geophysical_SEISMIC_DATum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Geophysical_SEISMIC_DATA");

            entity.Property(e => e.Actual_year_aquired_data_ACQUISITION)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_year_aquired_data_PROCESSING)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_ACQUISITION)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_PROCESSING)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.companyemail_ACQUISITION)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.companyemail_PROCESSING)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.companyname_ACQUISITION)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.companyname_PROCESSING)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data_ACQUISITION)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data_PROCESSING)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_HSE_OIL_SPILL_REPORTING_NEW>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_HSE_OIL_SPILL_REPORTING_NEW");

            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Volume_of_spill_bbls)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Volume_recovered_bbls)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_HSE_OIL_SPILL_REPORTING_NEW_total>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_HSE_OIL_SPILL_REPORTING_NEW_total");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_HSE_OIL_SPILL_REPORTING_NEW_total_summed>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_HSE_OIL_SPILL_REPORTING_NEW_total_summed");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total_summed>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total_summed");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_OIL_CONDENSATE_PRODUCTION_ACTIVITy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES");

            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Cost_Barrel)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Deferment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Forecast)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL");

            entity.Property(e => e.COMPANY_EMAIL)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Total_Production_)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_PERCENTAGE_CALCULATED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_PERCENTAGE_CALCULATED");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP_percentage)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_total_4_percentage_calculation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_total_4_percentage_calculation");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_SEISMIC_DATA_QUANTUM>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_SEISMIC_DATA_QUANTUM");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Geological_location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name_)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Quantum)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.companyemail_)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_SEISMIC_DATA_QUANTUM_SUM_BY_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_SEISMIC_DATA_QUANTUM_SUM_BY_YEAR");

            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_company_and_contract_type>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_company_and_contract_type");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(3900)
                .IsUnicode(false);
        });

        modelBuilder.Entity<View_2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_2");

            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WORKOVERS_RECOMPLETION_JOB1>(entity =>
        {
            entity.ToTable("WORKOVERS_RECOMPLETION_JOBS");

            entity.Property(e => e.Actual_year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_NGN)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Budeget_Allocation_USD)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.COMPANY_ID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Actual_Number_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_year_Budget_Allocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.DaysForCompletion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Do_you_have_approval_for_the_workover_recompletion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_paid)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_year_data)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.QUATER)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.oil_or_gas_wells)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WORK_PROGRAM_FLOW>(entity =>
        {
            entity.ToTable("WORK_PROGRAM_FLOW");

            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Companyemail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Created_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date_Created).HasColumnType("datetime");
            entity.Property(e => e.Date_Updated).HasColumnType("datetime");
            entity.Property(e => e.Descriptions).IsUnicode(false);
            entity.Property(e => e.Flag1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OML_ID)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OML_Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Updated_by)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLY>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLY");

            entity.Property(e => e.YEAR)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORY>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORY");

            entity.Property(e => e.PRESENTED)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_COMPANYNAME>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_COMPANYNAME");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PRESENTED)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR");

            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_STATUS_COMPANYNAME>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_STATUS_COMPANYNAME");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_old>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_old");

            entity.Property(e => e.Status_)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Cost_Efficiency_Metric_CAPEX_OPEX>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Cost_Efficiency_Metric_CAPEX_OPEX");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.naira).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<WP_Cost_Efficiency_Metric_CAPEX_OPEX_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Cost_Efficiency_Metric_CAPEX_OPEX_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION");

            entity.Property(e => e.CAPEX_PLUS_OPEX).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Production).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Cost_Efficiency_Metric_NET_PRODUCTION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Cost_Efficiency_Metric_NET_PRODUCTION");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Production).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Cost_Efficiency_Metric_NET_PRODUCTION_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Cost_Efficiency_Metric_NET_PRODUCTION_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            entity.Property(e => e.Actual_No_Drilled_in_Current_Year).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_No_Drilled).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type");

            entity.Property(e => e.Actual_Total_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Flared_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Utilized_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_Percentage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_Percentages");

            entity.Property(e => e.Actual_Total_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Flared_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Percentage_Utilized).HasColumnType("decimal(38, 16)");
            entity.Property(e => e.Utilized_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Total_GAS_Production_by_company).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Total_GAS_Production_by_year).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoted");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e._2010)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2010");
            entity.Property(e => e._2011)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2011");
            entity.Property(e => e._2012)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2012");
            entity.Property(e => e._2013)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2013");
            entity.Property(e => e._2014)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2014");
            entity.Property(e => e._2015)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2015");
            entity.Property(e => e._2016)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2016");
            entity.Property(e => e._2017)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2017");
            entity.Property(e => e._2018)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2018");
            entity.Property(e => e._2019)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2019");
            entity.Property(e => e._2020)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2020");
            entity.Property(e => e._2021)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2021");
            entity.Property(e => e._2022)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2022");
            entity.Property(e => e._2023)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2023");
            entity.Property(e => e._2024)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2024");
            entity.Property(e => e._2025)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2025");
            entity.Property(e => e._2026)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2026");
            entity.Property(e => e._2027)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2027");
            entity.Property(e => e._2028)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2028");
            entity.Property(e => e._2029)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2029");
            entity.Property(e => e._2030)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2030");
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoted");

            entity.Property(e => e.Annual_Total_Production_by_CONTRACT_TYPE).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_penalty_payment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_penalty_payment");

            entity.Property(e => e.Amount_Paid).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Flared).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.penaltyfeepaid).HasColumnType("decimal(38, 0)");
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Current_Actual_Year).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Flared).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Percentage_FLARED).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Utilized).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE");

            entity.Property(e => e.Percentage).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.TYPE_)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE_PLANNED");

            entity.Property(e => e.Percentage).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.TYPE_)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_FLARED).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_terrain_pivotted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_terrain_pivotted");

            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e._2010)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2010");
            entity.Property(e => e._2011)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2011");
            entity.Property(e => e._2012)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2012");
            entity.Property(e => e._2013)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2013");
            entity.Property(e => e._2014)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2014");
            entity.Property(e => e._2015)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2015");
            entity.Property(e => e._2016)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2016");
            entity.Property(e => e._2017)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2017");
            entity.Property(e => e._2018)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2018");
            entity.Property(e => e._2019)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2019");
            entity.Property(e => e._2020)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2020");
            entity.Property(e => e._2021)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2021");
            entity.Property(e => e._2022)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2022");
            entity.Property(e => e._2023)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2023");
            entity.Property(e => e._2024)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2024");
            entity.Property(e => e._2025)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2025");
            entity.Property(e => e._2026)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2026");
            entity.Property(e => e._2027)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2027");
            entity.Property(e => e._2028)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2028");
            entity.Property(e => e._2029)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2029");
            entity.Property(e => e._2030)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2030");
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITIES_terrain_tobe_pivotted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES_terrain_tobe_pivotted");

            entity.Property(e => e.Annual_Total_Production_by_Terrain).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GAS_PRODUCTION_ACTIVITy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GAS_PRODUCTION_ACTIVITIES");

            entity.Property(e => e.Actual_Total_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Flared_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Utilized_Gas_Produced).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION");

            entity.Property(e => e.Actual_year_aquired_data).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data).HasColumnType("decimal(38, 0)");
        });

        modelBuilder.Entity<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_count>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_count");

            entity.Property(e => e.Actual_year_aquired_data).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data).HasColumnType("decimal(38, 0)");
        });

        modelBuilder.Entity<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type");

            entity.Property(e => e.Actual_year_aquired_data).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Geo_type_of_data_acquired)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.proposed_year_data).HasColumnType("decimal(38, 0)");
        });

        modelBuilder.Entity<WP_GEOPHYSICAL_ACTIVITIES_PROCESSING>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_GEOPHYSICAL_ACTIVITIES_PROCESSING");

            entity.Property(e => e.Geo_Type_of_Data_being_Processed)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Interpreted_Actual).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Interpreted_Proposed).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Processed_Actual).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Processed_Proposed).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Reprocessed_Actual).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Reprocessed_Proposed).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Gas_Production_Utilisation_And_Flaring_Forecast>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Gas_Production_Utilisation_And_Flaring_Forecast");

            entity.Property(e => e.Percentage_Utilized).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Percentage_flared).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequence>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequences");

            entity.Property(e => e.Consequence)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill");

            entity.Property(e => e.Cause)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Consequence)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill_total>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill_total");

            entity.Property(e => e.Consequence)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accident>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accident");

            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentages");

            entity.Property(e => e.Cause)
                .HasMaxLength(3999)
                .IsUnicode(false);
            entity.Property(e => e.Consequence)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Expr1)
                .HasMaxLength(3900)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Spill).HasColumnType("decimal(38, 16)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP_from_total)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.sum_accident_from_total).HasColumnName("sum_accident_from total");
        });

        modelBuilder.Entity<WP_HSE_FATALITIES_accident_statistic_table>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_HSE_FATALITIES_accident_statistic_table");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fatalities_Type)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.type_of_incidence)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_INITIAL_WELL_COMPLETION_JOB>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_INITIAL_WELL_COMPLETION_JOBS");

            entity.Property(e => e.Current_year_Actual_Number).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Proposed_year_data).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Type>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Type");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Total_Reconciled_National_Crude_Oil_Production).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil");

            entity.Property(e => e.Total_Reconciled_National_Crude_Oil_Production).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year");

            entity.Property(e => e.Annual_Avg_Daily_Production).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Production_month)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED");

            entity.Property(e => e.Annual_Avg_Daily_Production).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Production_month)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Five_Year_Trend_for_Companies_Reserve_Replacement_Ratio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Five_Year_Trend_for_Companies_Reserve_Replacement_Ratio");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e._2010).HasColumnName("2010");
            entity.Property(e => e._2011).HasColumnName("2011");
            entity.Property(e => e._2012).HasColumnName("2012");
            entity.Property(e => e._2013).HasColumnName("2013");
            entity.Property(e => e._2014).HasColumnName("2014");
            entity.Property(e => e._2015).HasColumnName("2015");
            entity.Property(e => e._2016).HasColumnName("2016");
            entity.Property(e => e._2017).HasColumnName("2017");
            entity.Property(e => e._2018).HasColumnName("2018");
            entity.Property(e => e._2019).HasColumnName("2019");
            entity.Property(e => e._2020).HasColumnName("2020");
            entity.Property(e => e._2021).HasColumnName("2021");
            entity.Property(e => e._2022).HasColumnName("2022");
            entity.Property(e => e._2023).HasColumnName("2023");
            entity.Property(e => e._2024).HasColumnName("2024");
            entity.Property(e => e._2025).HasColumnName("2025");
            entity.Property(e => e._2026).HasColumnName("2026");
            entity.Property(e => e._2027).HasColumnName("2027");
            entity.Property(e => e._2028).HasColumnName("2028");
            entity.Property(e => e._2029).HasColumnName("2029");
            entity.Property(e => e._2030).HasColumnName("2030");
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION");

            entity.Property(e => e.Annual_Avg_Daily_Production).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSED");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_chart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_chart");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED");

            entity.Property(e => e.Annual_Avg_Daily_Production).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain");

            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED");

            entity.Property(e => e.Percentage_Production).HasColumnType("decimal(33, 13)");
            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown_PLANNED");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Production_month)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year_PLANNED");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Production_month)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotted");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e._2010).HasColumnName("2010");
            entity.Property(e => e._2011).HasColumnName("2011");
            entity.Property(e => e._2012).HasColumnName("2012");
            entity.Property(e => e._2013).HasColumnName("2013");
            entity.Property(e => e._2014).HasColumnName("2014");
            entity.Property(e => e._2015).HasColumnName("2015");
            entity.Property(e => e._2016).HasColumnName("2016");
            entity.Property(e => e._2017).HasColumnName("2017");
            entity.Property(e => e._2018).HasColumnName("2018");
            entity.Property(e => e._2019).HasColumnName("2019");
            entity.Property(e => e._2020).HasColumnName("2020");
            entity.Property(e => e._2021).HasColumnName("2021");
            entity.Property(e => e._2022).HasColumnName("2022");
            entity.Property(e => e._2023).HasColumnName("2023");
            entity.Property(e => e._2024).HasColumnName("2024");
            entity.Property(e => e._2025).HasColumnName("2025");
            entity.Property(e => e._2026).HasColumnName("2026");
            entity.Property(e => e._2027).HasColumnName("2027");
            entity.Property(e => e._2028).HasColumnName("2028");
            entity.Property(e => e._2029).HasColumnName("2029");
            entity.Property(e => e._2030).HasColumnName("2030");
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_tobe_pivoted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_tobe_pivoted");

            entity.Property(e => e.Contract_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted");

            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e._2010).HasColumnName("2010");
            entity.Property(e => e._2011).HasColumnName("2011");
            entity.Property(e => e._2012).HasColumnName("2012");
            entity.Property(e => e._2013).HasColumnName("2013");
            entity.Property(e => e._2014).HasColumnName("2014");
            entity.Property(e => e._2015).HasColumnName("2015");
            entity.Property(e => e._2016).HasColumnName("2016");
            entity.Property(e => e._2017).HasColumnName("2017");
            entity.Property(e => e._2018).HasColumnName("2018");
            entity.Property(e => e._2019).HasColumnName("2019");
            entity.Property(e => e._2020).HasColumnName("2020");
            entity.Property(e => e._2021).HasColumnName("2021");
            entity.Property(e => e._2022).HasColumnName("2022");
            entity.Property(e => e._2023).HasColumnName("2023");
            entity.Property(e => e._2024).HasColumnName("2024");
            entity.Property(e => e._2025).HasColumnName("2025");
            entity.Property(e => e._2026).HasColumnName("2026");
            entity.Property(e => e._2027).HasColumnName("2027");
            entity.Property(e => e._2028).HasColumnName("2028");
            entity.Property(e => e._2029).HasColumnName("2029");
            entity.Property(e => e._2030).HasColumnName("2030");
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted_PLANNED");

            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e._2010).HasColumnName("2010");
            entity.Property(e => e._2011).HasColumnName("2011");
            entity.Property(e => e._2012).HasColumnName("2012");
            entity.Property(e => e._2013).HasColumnName("2013");
            entity.Property(e => e._2014).HasColumnName("2014");
            entity.Property(e => e._2015).HasColumnName("2015");
            entity.Property(e => e._2016).HasColumnName("2016");
            entity.Property(e => e._2017).HasColumnName("2017");
            entity.Property(e => e._2018).HasColumnName("2018");
            entity.Property(e => e._2019).HasColumnName("2019");
            entity.Property(e => e._2020).HasColumnName("2020");
            entity.Property(e => e._2021).HasColumnName("2021");
            entity.Property(e => e._2022).HasColumnName("2022");
            entity.Property(e => e._2023).HasColumnName("2023");
            entity.Property(e => e._2024).HasColumnName("2024");
            entity.Property(e => e._2025).HasColumnName("2025");
            entity.Property(e => e._2026).HasColumnName("2026");
            entity.Property(e => e._2027).HasColumnName("2027");
            entity.Property(e => e._2028).HasColumnName("2028");
            entity.Property(e => e._2029).HasColumnName("2029");
            entity.Property(e => e._2030).HasColumnName("2030");
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted");

            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted_PLANNED");

            entity.Property(e => e.Terrain)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Quantum_Acquired).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Quantum_Approved).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD2021>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD2021");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_COMPLIANCE_INDEX_CALCULATION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_COMPLIANCE_INDEX_CALCULATIONS");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Total_Sum_All_Division).HasColumnType("decimal(38, 7)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(3000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_COMPLIANCE_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_COMPLIANCE_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(38, 7)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 7)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(3000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_DISCOVERY_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Discovery_Index_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Domestic_Gas_obligation_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Domestic_Gas_obligation_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Domestic_Gas_obligation_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Domestic_Gas_obligation_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(26)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_FATALITY_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_FATALITY_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_FATALITY_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_FATALITY_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Facility_Project_Performance_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Produced).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Utilized).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Facility_Project_Performance_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Produced).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Utilized).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_GAS_Utilisation_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Gas_Sales_Royalty_Payment_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Gas_Sales_Royalty_Payment_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Gas_Sales_Royalty_Payment_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Gas_Sales_Royalty_Payment_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Gas_flare_Royalty_payment_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Gas_flare_Royalty_payment_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(23)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Gas_flare_Royalty_payment_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Gas_flare_Royalty_payment_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_HSE_ACCIDENT_INCIDENCE_REPORTING_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Has_annual_NDR_subscription_fee_been_paid_new_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_INCREMENT_IN_PRODUCTION_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_INCREMENT_IN_PRODUCTION_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 16)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 16)");
        });

        modelBuilder.Entity<WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(36, 19)");
        });

        modelBuilder.Entity<WP_OML_INJURY_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_INJURY_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_INJURY_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_INJURY_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_NDPR_SUBSCRIPTION_FEE_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_NDPR_SUBSCRIPTION_FEE_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_NDPR_SUBSCRIPTION_FEE_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_NDPR_SUBSCRIPTION_FEE_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Oil_spill_reported_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Oil_spill_reported_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Oil_spill_reported_Index_MN_MAX_RGT_by_Year_of_WP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Oil_spill_reported_Index_MN_MAX_RGT_by_Year_of_WP");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Reserves_as_at_MMbbl_P1).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Total_Production_).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 14)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_RESERVE_REPLACEMENT_RATIO_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_RESERVE_REPLACEMENT_RATIO_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 14)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("numeric(38, 14)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 9)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_SIGNATURE_BONUS_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_SIGNATURE_BONUS_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(21)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_SIGNATURE_BONUS_Index_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_SIGNATURE_BONUS_Index_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Produced).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Utilized).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD2021>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE_OLD2021");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Top_Management_Staff_INDEX_MN_MAX_RGT_by_YEAR_OLD2021");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Produced).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Utilized).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD2021>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OML_Top_Management_Staff_INDEX_WEIGHTED_SCORE_OLD2021");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Quantum_Acquired).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Quantum_Approved).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Aggregated_Score_ALL_COMPANIES_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Aggregated_Score_ALL_COMPANIES_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.OPL_Aggregated_Score).HasColumnType("decimal(32, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Aggregated_Score_ALL_COMPANIES_WITHOUT_INDEX_TYPE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Aggregated_Score_ALL_COMPANIES_WITHOUT_INDEX_TYPE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OPL_Aggregated_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index_SUM).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weight_SUM).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weighted_Score_SUM).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Aggregated_Score_ALL_COMPANy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Aggregated_Score_ALL_COMPANIES");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.OPL_Aggregated_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index_SUM).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Weighted_Score_SUM).HasColumnType("numeric(38, 2)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_COMPLIANCE_INDEX_CALCULATION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_COMPLIANCE_INDEX_CALCULATIONS");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.Total_Sum_All_Division).HasColumnType("decimal(38, 7)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(3000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Discovery_Index_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE)
                .HasMaxLength(26)
                .IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_Exploratory_Drilling_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(34, 19)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR");

            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR_OLD");

            entity.Property(e => e.MAX_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.MIN_RGT).HasColumnType("decimal(38, 18)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE");

            entity.Property(e => e.CAPEX_PLUS_OPEX).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Production).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE_OLD>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_OML_Cost_Efficiency_Metric_INDEX_WEIGHTED_SCORE_OLD");

            entity.Property(e => e.CAPEX_PLUS_OPEX).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Production).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Unscaled_Score_sum).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_OPL_WEIGHTED_AND_RECALIBRATED_SCORE_UNION_ALL_COMPANIES");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Consession_Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.INDEX_TYPE).IsUnicode(false);
            entity.Property(e => e.MAX_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.MIN_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Recalibrated_Scaled_Index).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Scaled_by_Reciprocal_GrandTotal_RGT).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Unscaled_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Weight).IsUnicode(false);
            entity.Property(e => e.Weighted_Score).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTED");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e._2010)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2010");
            entity.Property(e => e._2011)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2011");
            entity.Property(e => e._2012)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2012");
            entity.Property(e => e._2013)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2013");
            entity.Property(e => e._2014)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2014");
            entity.Property(e => e._2015)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2015");
            entity.Property(e => e._2016)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2016");
            entity.Property(e => e._2017)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2017");
            entity.Property(e => e._2018)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2018");
            entity.Property(e => e._2019)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2019");
            entity.Property(e => e._2020)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2020");
            entity.Property(e => e._2021)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2021");
            entity.Property(e => e._2022)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2022");
            entity.Property(e => e._2023)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2023");
            entity.Property(e => e._2024)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2024");
            entity.Property(e => e._2025)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2025");
            entity.Property(e => e._2026)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2026");
            entity.Property(e => e._2027)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2027");
            entity.Property(e => e._2028)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2028");
            entity.Property(e => e._2029)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2029");
            entity.Property(e => e._2030)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("2030");
        });

        modelBuilder.Entity<WP_RESERVES_REPLACEMENT_RATIO_VALUE_TO_BE_PIVOTTED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_RESERVES_REPLACEMENT_RATIO_VALUE_TO_BE_PIVOTTED");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RESERVES_REPLACEMENT_RATIO_VALUE).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL");

            entity.Property(e => e.Reserves_as_at_MMbbl).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Reserves_as_at_MMbbl_condensate).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Reserves_as_at_MMbbl_gas).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT");

            entity.Property(e => e.Company_Reserves_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FLAG1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Total_AG_NAG).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_AG).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_Condensate).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_NAG).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_Oil).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_oil_plus_condensate).HasColumnType("decimal(38, 3)");
        });

        modelBuilder.Entity<WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED");

            entity.Property(e => e.Fiveyear_Projection_Year)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Total_AG_NAG).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_AG).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_Condensate).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_NAG).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_Company_Reserves_Oil).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Total_oil_plus_condensate).HasColumnType("decimal(38, 3)");
        });

        modelBuilder.Entity<WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION");

            entity.Property(e => e.Actual_Year).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Proposed_Year).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP_I)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WP_W)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Frequency).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Total_Quantity_Recovered).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Total_Quantity_Spilled).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_TOTAL_NO_OF_INCIDENCE_BY_YEAR_COMPANYNAME>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_TOTAL_NO_OF_INCIDENCE_BY_YEAR_COMPANYNAME");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Frequency).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_TOTAL_NO_OF_OIL_SPILLED_AND_RECOVERED_BY_YEAR_COMPANYNAME>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_TOTAL_NO_OF_OIL_SPILLED_AND_RECOVERED_BY_YEAR_COMPANYNAME");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Total_Quantity_Recovered).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Total_Quantity_Spilled).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Total_E_and_P_companies_old>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Total_E_and_P_companies_old");

            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_Total_E_and_P_company>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_Total_E_and_P_companies");

            entity.Property(e => e.Year)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WP_WORKOVERS_RECOMPLETION_JOB>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("WP_WORKOVERS_RECOMPLETION_JOBS");

            entity.Property(e => e.Current_year_Actual_Number_data).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Proposed_year_data).HasColumnType("decimal(38, 0)");
            entity.Property(e => e.Year_of_WP)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkOverJob>(entity =>
        {
            entity.HasKey(e => e.WorkOver_JobsId);

            entity.Property(e => e.Actual_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Proposed_Year)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<WorkOvers_Recompletion_Job>(entity =>
        {
            entity.ToTable("WorkOvers_Recompletion_Job");

            entity.Property(e => e.Actual_No_Current_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Actual_No_Proposed_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Budget_Allocation_Proposed_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Do_you_have_approval_for_workover_recompletion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Remark).IsUnicode(false);
            entity.Property(e => e.Year_of_WorkProgram)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkOvers_Recompletion_Job_Field_Dvelopment_Plan>(entity =>
        {
            entity.HasKey(e => e.WorkOvers_Recompletion_Job_Field_Dvelopment_PlansId);

            entity.Property(e => e.How_many_fields_have_FDP)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.How_many_fields_have_approved_FDP)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.List_all_the_field_with_FDP).IsUnicode(false);
            entity.Property(e => e.No_of_wells_drilled_in_Current_Year)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Number_of_wells_proposed_in_the_FDP)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Processing_Fees_Paid)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Which_fields_do_you_plan_to_submit_an_FDP)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Year_of_WorkProgram)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.proposed_number_of_wells_for_Proposed_Year_from_Approved_FDP)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<staff>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SignatureName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SignaturePath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.StaffElpsID)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StaffEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<tbl_fruitanalysis>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_fruitanalysis");

            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
