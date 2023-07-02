using Backend_UMR_Work_Program.DataModels;
using DocumentFormat.OpenXml.Spreadsheet;
using Swashbuckle.AspNetCore.Swagger;

namespace Backend_UMR_Work_Program.Models
{
	public class GeneralModel
	{
		public static string Company = "Company";
		public static string Admin = "Admin";
		public static string SuperAdmin = "SuperAdmin";
		public static string Presented = "Presented";
		public static string FailedToShow = "Failed to show up";
		public static string NotInvited = "Not invited";
		public static string ShowedButNoPresentation = "Showed up but could not present";
		public static string ThreeD = "3D";
		public static string TwoD = "2D";
		public static string Exploration = "Exploration";
		public static string Development = "Development";
		public static string FirstAppraisal = "1st Appraisal";
		public static string SecondAppraisal = "Second Appraisal";
		public static string Appraisal = "Appraisal";
		public static string OrdinaryAppraisal = "Ordinary Appraisal";
		public static string JV = "JV";
		public static string PSC = "PSC";
		public static string MF = "MF";
		public static string SR = "SR";
		public static string ContinentalShelf = "Continental Shelf";
		public static string DeepOffshore = "Deep Offshore";
		public static string Onshore = "Onshore";
		public static string Fatality = "FATALITIES";
		public static string Sabotage = "SABOTAGE";
		public static string HumanError = "HUMAN ERROR";
		public static string MysterySpills = "MYSTERY SPILLS";
		public static string EquipmentFailure = "EQUIPMENT_FAILURE";
		public static string Insert = "Insert";
		public static string Update = "Update";
		public static string Delete = "Delete";
		public static string New = "New";
		public static string Modification = "MODIFICATION";
		public static string ActualYear = "Actual Year";
		public static string ProposedYear = "Proposed Year";
		public static string OML = "OML";
		public static string OPL = "OPL";
		public static string PLANNING_CODE = "ER&SP";
		public static string HSE_CODE = "HSE&C";
		public static string LEGAL_CODE = "LGL";
		public static string D_AND_P_CODE = "D&P";
		public static string EXPOLRATION_CODE = "E&AM";
		public static string DEVELOPMENT_CODE = "ER&SP";
		public static string CORPORATE_SERVICE_CODE = "ER&SP";
		public static string Activated = "Activated";
		public static string Deactivated = "Deactivated";


        //Application, Payment statuses
        public static class MAIN_APPLICATION_STATUS
        {

            public const string Approved = "Approved";

            public const string Rejected = "Rejected";

            public const string ApprovedByFinalAuthority = "Approved By Final Authority";
            public const string ApprovedByFinalApprovingAuthority = "Approved By Final Approving Authority";

            public const string ReturnedToCompany = "Returned To Company";
            public const string ReturnedToStaff = "Returned To Staff";

            public const string Processing = "Processing";

            public const string SubmittedByCompany = "Submitted By Company";

            public const string NotSubmitted = "Not Submitted";

            //public static string ApprovalByFinalAuthority = "Approval By Final Authority";
            //public static string ApprovalByFinalApprovingAuthority = "Approval By Final Approving Authority";
            //public static string SentBackToCompany = "Sent Back To Company";
            //public static string SubmissionByCompany = "Submission By Company";
            //public static string SentBackToStaff = "Sent Back To Staff";
        }

		public static class APPLICATION_HISTORY_STATUS
		{
            public const string ReviewerApproved = "Reviewer Approved";
            public const string SuppervisorApproved = "Supervisor Approved";
            public const string ManagerApproved = "Manager Approved";
            public const string FinalAuthorityApproved = "Final Authority Approved";
            public const string FinalApprovingAuthorityApproved = "Final Approving Authority Approved";
            public const string DirectorApproved = "Director Approved";
            public const string DeputyDirectorApproved = "Deputy Director Approved";

            public const string ReturnedToCompany = "Returned To Company";
            public const string ReturnedToStaff = "Returned To Staff";

			public const string AddedComment = "Added Comment";
			
			//public static string SentBackToCompany = "Application Sent Back To Company";
			//public static string SentBackToStaff = "Application Sent Back To Staff";
        }

        public static class DESK_PROCESS_STATUS
        {
            public const string FinalAuthorityApproved = "Final Authority Approved";
            public const string FinalApprovingAuthorityApproved = "Final Approving Authority Approved";
            public const string Pushed = "Pushed";
            public const string SubmittedByStaff = "Submitted By Staff";
            public const string Processing = "Processing";
            public const string SubmittedByCompany = "Submitted By Company";
        }

        public static class PAYMENT_STATUS
		{
            public const string PaymentPending = "Payment Confirmation Pending";
            public const string PaymentCompleted = "Payment Completed";
        }

		public static class APPLICATION_ACTION
		{
            public const string ReturnToCompany = "Return To Company";
            public const string ReturnToStaff = "Return To Staff";
			public const string SubmitApplication = "Submit Application";

            public static string Initiate = "Initiate";
            public static string Complete = "Complete";
            public static string Submit = "Submit";
            public static string Push = "Push";
            public static string Approve = "Approve";
            public static string Reject = "Reject";
            public static string Delegate = "Delegate";
            public static string AddAComment = "Add a Comment";
            public static string Move = "Move";

            //public static string SendBackToCompany = "Send Back To Company";
            //public static string SendBackToStaff = "Send Back To Staff";
        }

		public static class PAYMENT_CATEGORY
		{
            public const string MainPayment = "Main Payment";
            public const string OtherPayment = "Other Payment";
            public const string SecondaryPayment = "Secondary Payment";
        }

		public static class TYPE_OF_FEE
		{
			public const string NoFee = "No Fee";
            public const string SubmissionFee = "Submission Fee";
            public const string LateSubmissionFee = "Late Submission Fee";
            public const string ModificationFee = "Modification Fee";
        }

        //public static class APPLICATION_STATUS__OLD
        //{
        //    public static string PaymentPending = "Payment Confirmation Pending";
        //    public static string PaymentCompleted = "Payment Completed";
        //    public static string SubmissionFee = "Submission Fee";
        //    public static string LateSubmissionFee = "Late Submission Fee";
        //    public static string ModificationFee = "Modification Fee";
        //    public static string MainPayment = "Main Payment";
        //    public static string OtherPayment = "Other Payment";
        //    public static string SecondaryPayment = "Secondary Payment";

        //    public static string Approved = "Approved";
        //    public static string SubmissionByCompany = "Submission By Company";

        //    public static string SubmissionByStaff = "Submission By Staff";
        //    public static string ApprovalByFinalAuthority = "Approval By Final Authority";
        //    public static string ApprovalByFinalApprovingAuthority = "Approval By Final Approving Authority";
        //    public static string Pushed = "Pushed";
        //    public static string Processing = "Processing";
        //    public static string Rejected = "Rejected";
        //    public static string SendBackToCompany = "Send Back To Company";
        //    public static string SendBackToStaff = "Send Back To Staff";
        //    public static string NotSubmitted = "Not Submitted";
        //    public static string SentBackToCompany = "Sent Back To Company";
        //    public static string SentBackToStaff = "Sent Back To Staff";

        //    public static string ReviewerApproved = "Reviewer Approved";
        //    public static string SuppervisorApproved = "Supervisor Approved";
        //    public static string ManagerApproved = "Manager Approved";
        //    public static string FinalAuthorityApproved = "Final Authority Approved";
        //    public static string DirectorApproved = "Director Approved";
        //    public static string DeputyDirectorApproved = "Deputy Director Approved";
        //}


        //Process flow constants

        public static class PROCESS_CONSTANTS{
			public static string Initiated = "Initiated";
			public static string Completed = "Completed";
			public static string Submit = "Submit";
			public static string SubmissionByCompany = "Submission By Company";
			public static string Submitted = "Submitted";
			public static string Push = "Push";
			public static string ApprovedByEC = "Approved By EC";
			public static string FinalApproval = "FinalApproval";
			public static string Approve = "Approve";
			public static string Reject = "Reject";
			public static string Delegate = "Delegate";
			public static string Reviewer = "Reviewer";
			public static string Supervisor = "Supervisor";
			public static string Approval = "Approving Authority";
			public static string FinalApprovalAuthority = "Final Approving Authority";
			public static string AddAComment = "Add a Comment";
			public static string Move = "Move";
		}

		public static class ROLE
		{
			public static string AD = "AD";
			public static string Admin = "Admin";
			public static string Company = "Company";
			public static string DD = "DD";
			public static string ExecutiveCommissioner = "Executive Commissioner";
			public static string FinalApproval = "Final Approval";
			public static string Reviewer = "Reviewer";
			public static string SuperAdmin = "SuperAdmin";
			public static string Supervisor = "Supervisor";
			public static string WPAMGR = "WPA MGR";
        }
		

		public static string CurrencyNGN = "NGN";
		public static string CurrencyUSD = "USD";

        //public static object APPLICATION_STATUS { get; internal set; }

        public struct Currency { 
			public static string NGN = "NGN";
			public static string USD = "USD";
		}

		public class ActionModel
		{
			public string[] selectedApps { get; set; }
			public string[] SBU_IDs { get; set; }
			public string[] selectedTables { get; set; }
		}
		public class Concession_Index
		{
			public string companyName { get; set; }
			public string concessionName { get; set; }
			public string concessionType { get; set; }
			public double? acquisition_Index { get; set; }
			public double? exploratory_Index { get; set; }
			public double? discovery_Index { get; set; }
			public double? concessionRentals_Index { get; set; }
			public double? compliance_Index { get; set; }
			public double? NDR_Index { get; set; }
			public double? royaltyPayment_Index { get; set; }
			public double? RRR_Index { get; set; }
			public double? IncrementInProduction_Index { get; set; }
			public double? costEfficiency_Index { get; set; }
			public double? CSR_Index { get; set; }
			public double? statutoryPayment_Index { get; set; }
		}
		public class Field_Index
		{
			public string fieldName { get; set; }
			public string concessionName { get; set; }
			public string concessionType { get; set; }
			public double? acquisition_Index { get; set; }
			public double? exploratory_Index { get; set; }
			public double? discovery_Index { get; set; }
			public double? concessionRentals_Index { get; set; }
			public double? compliance_Index { get; set; }
			public double? NDR_Index { get; set; }
			public double? royaltyPayment_Index { get; set; }
			public double? RRR_Index { get; set; }
			public double? IncrementInProduction_Index { get; set; }
			public double? costEfficiency_Index { get; set; }
			public double? CSR_Index { get; set; }
			public double? statutoryPayment_Index { get; set; }

		}
		public class Company_Index
		{
			public string fieldName { get; set; }
			public string concessionName { get; set; }
			public string concessionType { get; set; }
			public double? acquisition_Index { get; set; }
			public double? exploratory_Index { get; set; }
			public double? discovery_Index { get; set; }
			public double? concessionRentals_Index { get; set; }
			public double? NDR_Index { get; set; }
		}
		public class WorkProgrammeReport_Model
		{
			public object WorkProgrammeReport1_Model { get; set; }
			public object WorkProgrammeReport2_Model { get; set; }
		}
		public class CompanyDashboardModel
		{
			public List<CompanyReportModel>? CompanyReportModels { get; set; }

			public int OML_Count { get; set; }
			public int OPL_Count { get; set; }
			public int No_Of_ProducingFields_Count { get; set; }
		}
		public class CompanyReportModel
		{
			public string concessionName { get; set; }
			public string? fieldName { get; set; }
			public double oil_NetProduction { get; set; }
			public double AG_NetProduction { get; set; }
			public double NAG_NetProduction { get; set; }
			public double condensate_NetProduction { get; set; }
			public double totalNetProduction { get; set; }
			public double oil_Reserves { get; set; }
			public double AG_Reserves { get; set; }
			public double NAG_Reserves { get; set; }
			public double condensate_Reserves { get; set; }
			public double totalReserves { get; set; }
		}

		public class WorkProgrammeReport1_Model
		{
			public List<ADMIN_WORK_PROGRAM_REPORT> ADMIN_WORK_PROGRAM_REPORT_Model { get; set; }
			public List<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_TOTAL_COUNT_YEARLY> E_and_P_companies_Model { get; set; }
			public List<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORY> WP_Presentations_Model { get; set; }
			//public List<WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORY> WP_COUNT_ADMIN_DATETIME_PRESENTATION_BY_YEAR_PRESENTED_CATEGORY_Model { get; set; }
			public List<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION> WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model { get; set; }
			public List<WP_GEOPHYSICAL_ACTIVITIES_PROCESSING> WP_GEOPHYSICAL_ACTIVITIES_PROCESSING_Model { get; set; }
			public List<WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELL> WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model { get; set; }
			public List<DRILLING_OPERATIONS_CATEGORIES_OF_WELL> WP_SUM_APPRAISAL_WELL_Model { get; set; }
			public List<WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION> WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION_Model { get; set; }
			public List<WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELL> DRILLING_OPERATIONS_Appraisal_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Type> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITY_Contract_Type_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITY_monthly_ActivitY_OIL_PRODUCTION_by_Terrain_Model { get; set; }
			public List<WP_GAS_PRODUCTION_ACTIVITIES_Percentage> WP_GAS_PRODUCTION_ACTIVITY_Percentage_Model { get; set; }
			public object PY_GAS_ACTIVITIES_Model { get; set; }
			public object CY_GAS_ACTIVITIES_Model { get; set; }
			public object GAS_ACTIVITIES_CONTRACTTYPES_Model { get; set; }
			public List<WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type> WP_GAS_PRODUCTION_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil> WP_GAS_PRODUCTION_ACTIVITY_PreviousYearr_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil> WP_GAS_PRODUCTION_ACTIVITY_CurrentYearr_Model { get; set; }
			public object WP_GAS_PRODUCTION_ACTIVITY_PREVIOUSYEAR_Model { get; set; }
			public object WP_GAS_PRODUCTION_ACTIVITY_CURRENTYEAR_Model { get; set; }
			public List<WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL> WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_Model { get; set; }
			public List<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequence> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_by_consequence_Model { get; set; }
			public List<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accident> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_accident_Model { get; set; }
			public List<WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentage> WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentage_Model { get; set; }
			public List<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_count> WP_GEOPHYSICAL_ACTIVITY_ACQUISITION_sum_and_count_Model { get; set; }
			public List<HSE_OIL_SPILL_REPORTING_NEW> HSE_OIL_SPILL_REPORTING_NEW_Model { get; set; }
			public List<WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_count> GEO_sum_and_count_Model { get; set; }
			public string VOLUME_OF_OILSPILL { get; set; }
			public List<WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED> WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED_Model { get; set; }
			public object OILSPILL_REPORT_Model { get; set; }
			public object TOTAL_PRODUCED_WATER_Model { get; set; }
			public List<HSE_CAUSES_OF_SPILL> HSE_QUANTITY_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITY_monthly_ActivitY_OIL_PRODUCTION_CONTRACT_TYPE_PROPOSED_Model { get; set; }
			//public List<WP_OIL_CONDZENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED> WP_OIL_CONDZENSATE_PRODUCTION_ACTIVITY_monthly_ActivitY_OIL_PRODUCTION_by_Terrain_PLANNED_Model { get; set; }
			public List<WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED> WP_OIL_CONDENSATE_PRODUCTION_ACTIVITY_monthly_ActivitY_OIL_PRODUCTION_by_Terrain_PLANNED_Model { get; set; }
			public List<WP_Gas_Production_Utilisation_And_Flaring_Forecast> WP_Gas_Production_Utilisation_And_Flaring_Forecast_Model { get; set; }
			public string Error { get; set; }

		}
		public class WorkProgrammeReport2_Model
		{
			public List<Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITION> Seismic_Data_Approved_and_Acquired { get; set; }
			public object Seismic_Data_Approved_and_Acquired_PREVIOUS { get; set; }
			public object Seismic_Data_Approved_and_Acquired_PLANNED { get; set; }
			public object Seismic_Data_Approved_and_Acquired_TWO_YEARS_AG0 { get; set; }
			public object Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT { get; set; }
			public object Seismic_Data_Processing_and_Reprocessing_Activities_CURRENT_PLANNED { get; set; }
			public object Seismic_Data_Processing_and_Reprocessing_Activities_PREVIOUS { get; set; }
			public object Seismic_Data_Processing_and_Reprocessing_Activities_TWO_YEARS_AGO { get; set; }
			public object DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration { get; set; }
			public object DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal { get; set; }
			public object DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development { get; set; }
			public object DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Exploration_PY { get; set; }
			public object DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Appraisal_PY { get; set; }
			public object DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_Development_PY { get; set; }
			public object RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_Pivotted { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_contract_type_basis { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_terrain_pivotted { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_contract_type_pivoted { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_penalty_payment { get; set; }
			public object FATALITIES_ACCIDENT_STATISTIC_TABLE { get; set; }
			public object OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS { get; set; }
			public object OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS_PY { get; set; }
			public object NIGERIA_CONTENT_TRAINING { get; set; }
			public object NIGERIA_CONTENT_TRAINING_PY { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_NEW_TECHNOLOGY_CONFORMITY_ASSESSMENT { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_OPERATING_FACILITIES { get; set; }
			public object NIGERIA_CONTENT_UPLOAD_SUCESSION_PLAN { get; set; }
			public object HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW { get; set; }
			public object HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships { get; set; }
			public object HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition { get; set; }
			public object BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES { get; set; }
			public object BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES { get; set; }
			public object BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT { get; set; }
			public object BUDGET_PERFORMANCE_PRODUCTION_COST { get; set; }
			public object OML_Aggregated_Score_ALL_COMPANIES { get; set; }
			public object RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED { get; set; }
			public object STRATEGIC_PLANS_ON_COMPANY_BASIS { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_C_TYPE_PROPOSED { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain_PLANNED { get; set; }
			public object OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_PRODUCTION_BRKDWN_PLANNED { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED { get; set; }
			public object GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED { get; set; }
			public object RESERVES_REPLACEMENT_RATIO_VALUE_PIVOTTED { get; set; }
			public object HSE_CAUSES_OF_SPILL { get; set; }
			public string Error { get; set; }
			public string GEOPHYSICAL_ACTIVITIES_PROCESSING_DESCRIPTION { get; set; }

		}
		public class ADMIN_WORK_PROGRAM_REPORTs_Model
		{
			public List<ADMIN_WORK_PROGRAM_REPORT> ADMIN_WORK_PROGRAM_REPORT_Model { get; set; }
			public object summary_1 { get; set; }
			public object summary_2 { get; set; }
			public object GasFlare_ReportContent { get; set; }
			public object OilContigencyPlan_ReportContent { get; set; }
		}
		public class ApplicationProcessModel
		{
			public int StaffId { get; set; }
			public int FromStaffId { get; set; }
			public int RoleId { get; set; }
			public int? SBU_Id { get; set; }
			public int Sort { get; set; }
			public string TriggeredByRole { get; set; }
			public string TriggeredBySBU { get; set; }
			public string TargetedToRole { get; set; }
			public string TargetedToSBU { get; set; }
			public string ProcessAction { get; set; }
			public string ProcessStatus { get; set; }
			public int ProcessId { get; set; }
			public int DeskCount { get; set; }
			public string RoleName { get; set; }
		}

        public class DeskStaffAppsModel
        {
			public staff Staff { get; set; }
			public MyDesk Desk { get; set; }
			public Application Application { get; set; }
        }

        public class StaffSBURoleModel
        {
            public staff Staff { get; set; }
            public Role Role { get; set; }
			public StrategicBusinessUnit SBU { get; set; }
        }


        public class Application_Model
		{
			public int Id { get; set; }
			public int RejectId { get; set; }
			public string ReferenceNo { get; set; } = null!;
			public int? ConcessionID { get; set; }
			public int CompanyID { get; set; }
			public string? Last_SBU { get; set; }
			public string CompanyName { get; set; }
			public string FieldName { get; set; }
			public string ConcessionName { get; set; }
			public string SBU_Tables { get; set; }
			public string SBU_Comment { get; set; }
			public int? FieldID { get; set; }
			public int CategoryID { get; set; }
			public int YearOfWKP { get; set; }
			public string Status { get; set; } = null!;
			public string PaymentStatus { get; set; } = null!;
			public int? CurrentDesk { get; set; }
			public bool? Submitted { get; set; }
			public string? ApprovalRef { get; set; }
			public DateTime? CreatedAt { get; set; }
			public DateTime? SubmittedAt { get; set; }
			public DateTime? UpdatedAt { get; set; }
			public int? DeletedBy { get; set; }
			public bool? DeleteStatus { get; set; }
			public DateTime? DeletedAt { get; set; }

		}

		public class ApplicationDetailsModel
		{
			public Application Application { get; set; }
			public COMPANY_FIELD Field { get; set; }
			public ADMIN_COMPANY_INFORMATION Company { get; set; }
			public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }
			public List<Staff_Model> Staff { get; set; }
			public List<ApplicationDeskHistory_Model> Application_History { get; set; }
			public List<SubmittedDocument> Document { get; set; }
			public List<StrategicBusinessUnit> SBU { get; set; }
			public List<Table_Detail> SBU_TableDetails { get; set; }
			public List<Staff_Model> currentDesks { get; set; }
			public List<ApplicationSBUApproval> SBUApprovals { get; set; }	
			public List<staff> staffs { get; set; }
		}
		public class Staff_Model
		{
			public string Staff_Name { get; set; }
			public string Staff_Email { get; set; }
			public string Staff_SBU { get; set; }
			public string Staff_Role { get; set; }
			public int Sort { get; set; }
			public int Desk_ID { get; set; }
		}

		public class ApplicationDeskHistory_Model
		{
			public int ID { get; set; }
			public string Staff_Name { get; set; }
			public string Staff_Email { get; set; }
			public string Staff_SBU { get; set; }
			public string Staff_Role { get; set; }
			public string Comment { get; set; }
			public string Status { get; set; }
			public DateTime Date { get; set; }
		}

		public class HSE_ACCIDENT_INCIDENCE_MODEL
		{
			public int id { get; set; }
			public string? Was_there_any_accident_incidence { get; set; }
			public string? If_YES_were_they_reported { get; set; }
			public string? Type_of_Accident_Incidence { get; set; }
			public string? Location { get; set; }
			public string? Investigation { get; set; }
			public string? Date_ { get; set; }
			public string? Cause { get; set; }
			public string? Consequence { get; set; }
			public string? Lesson_Learnt { get; set; }
			public string? Frequency { get; set; }

		}

		public class FileReturn
		{
			public string fileId { get; set; }
			public long? fileSize { get; set; }
			public string path { get; set; }
		}

		public class DownReturn
		{
			public Stream stream { get; set; }
			public string contentType { get; set; }
			public string name { get; set; }
		}

		public class ConcessionField
		{
			public int? Field_ID { get; set; }
			public int? Concession_ID { get; set; }
			public string Concession_Name { get; set; }
			public string Consession_Type { get; set; }
			public string? Field_Name { get; set; }
			public string? Terrain { get; set; }
		}
		public class ADMIN_COMPANY_INFORMATION_Model
		{
			public int? Id { get; set; }
			public string? COMPANY_NAME { get; set; }
			public string? EMAIL { get; set; }
			public string? PASSWORDS { get; set; }
			public string? STATUS_ { get; set; }
			public string? FLAG_PASSWORD_CHANGE { get; set; }
			public string? CATEGORY { get; set; }
			public string? Created_by { get; set; }
			public DateTime? Date_Created { get; set; }
			public string? NAME { get; set; }
			public string? DESIGNATION { get; set; }
			public string? PHONE_NO { get; set; }
			public string? COMPANY_ID { get; set; }
			public string? DELETED_STATUS { get; set; }
			public string? DELETED_BY { get; set; }
			public string? DELETED_DATE { get; set; }
			public string? FLAG1 { get; set; }
			public string? FLAG2 { get; set; }
			public string? EMAIL_REMARK { get; set; }
			public int? ROLE_ID { get; set; }
			public int? SBU_ID { get; set; }
			public int? ELPS_ID { get; set; }
		}
		public partial class ADMIN_CONCESSIONS_INFORMATION_Model
		{
			public int Consession_Id { get; set; }
			public string? Company_ID { get; set; }
			public string? CompanyName { get; set; }
			public string? Equity_distribution { get; set; }
			public string? Concession_Held { get; set; }
			public string? Area { get; set; }
			public string? Contract_Type { get; set; }
			public string? Year_of_Grant_Award { get; set; }
			public DateTime? Date_of_Expiration { get; set; }
			public string? Geological_location { get; set; }
			public string? Comment { get; set; }
			public string? Status_ { get; set; }
			public string? Flag1 { get; set; }
			public string? Flag2 { get; set; }
			public string? COMPANY_EMAIL { get; set; }
			public string? Terrain { get; set; }
			public string? Year { get; set; }
			public string? submitted { get; set; }
			public string? Consession_Type { get; set; }
			public string? Concession_Unique_ID { get; set; }
			public string? OPEN_DATE { get; set; }
			public string? CLOSE_DATE { get; set; }
			public string? EMAIL_REMARK { get; set; }
			public int? CompanyNumber { get; set; }
		}
		public class UserModel
		{
			public List<ADMIN_COMPANY_INFORMATION> companiesList { get; set; }
			public List<ADMIN_COMPANY_INFORMATION> staffList { get; set; }
			public List<ROLES_> roles { get; set; }
			public List<StrategicBusinessUnit> sbus { get; set; }
		}
		public class parameterConfigModel
		{
			public List<ADMIN_CATEGORy> adminCategories { get; set; }
			public List<Data_Type> dataTypes { get; set; }
			public List<ADMIN_WELL_CATEGORy> wellCategories { get; set; }
			public List<ADMIN_WP_START_END_DATE> startEndDate { get; set; }
			public List<ADMIN_WP_START_END_DATE_DATA_UPLOAD> startEndDateUpload { get; set; }
			public List<ADMIN_WP_PENALTy> penalties { get; set; }
			public List<ADMIN_EMAIL_DAY> emailDays { get; set; }
			public List<ROLES_SUPER_ADMIN> superAdmins { get; set; }
			public List<ADMIN_PRESENTATION_CATEGORy> presentationCategories { get; set; }
			public List<ADMIN_MEETING_ROOM> meetingRooms { get; set; }
		}
		public class PermitAPIModel
		{
			public int Id { get; set; }
			public string Permit_No { get; set; }

			public string OrderId { get; set; }

			public int Company_Id { get; set; }

			public DateTime Date_Issued { get; set; }

			public DateTime Date_Expire { get; set; }
			public string CategoryName { get; set; }
			public string Is_Renewed { get; set; }
			public int LicenseId { get; set; }
		}

		public class WorkProgramme_Model_1
		{
			public CONCESSION_SITUATION_Model CONCESSION_SITUATION { get; set; }
			public GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model GEOPHYSICAL_ACTIVITIES_ACQUISITIONs { get; set; }
			public GEOPHYSICAL_ACTIVITIES_PROCESSING_Model GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }
			public DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }
			public DRILLING_EACH_WELL_COST_Model DRILLING_EACH_WELL_COSTs { get; set; }
			public DRILLING_EACH_WELL_COST_PROPOSED_Model DRILLING_EACH_WELL_COST_PROPOSEDs { get; set; }

			public string WorkProgramme_Year { get; set; }

		}
		public class WorkProgramme_Model_2
		{
			public string WorkProgramme_Year { get; set; }
			public INITIAL_WELL_COMPLETION_JOB1_Model Initial_Well_Completion_Job { get; set; }
			public WORKOVERS_RECOMPLETION_JOB1_Model WORKOVERS_RECOMPLETION_JOB1 { get; set; }
			public FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf_Model FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVE { get; set; }
			public FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP_Model FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP { get; set; }
			public FIELD_DEVELOPMENT_FIELDS_AND_STATUS_Model FIELD_DEVELOPMENT_FIELDS_AND_STATUS { get; set; }
			public RESERVES_UPDATES_LIFE_INDEX_Model RESERVES_UPDATES_LIFE_INDEX { get; set; }
			public FIELD_DEVELOPMENT_PLAN_Model FIELD_DEVELOPMENT_PLAN { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITy_Model OIL_CONDENSATE_PRODUCTION_ACTIVITy { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION { get; set; }
			public GAS_PRODUCTION_ACTIVITy_Model GAS_PRODUCTION_ACTIVITy { get; set; }
			public NDR_Model NDR { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_Model RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection_Model RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION_Model RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE_Model RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition_Model RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity { get; set; }
			public RESERVES_REPLACEMENT_RATIO_Model RESERVES_REPLACEMENT_RATIO { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED { get; set; }
			public GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY_Model GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY { get; set; }

		}

		public class WorkProgramme_Model_3
		{
			public string WorkProgramme_Year { get; set; }
			public CONCESSION_SITUATION_Model CONCESSION_SITUATION { get; set; }
			public GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model GEOPHYSICAL_ACTIVITIES_ACQUISITIONs { get; set; }
			public GEOPHYSICAL_ACTIVITIES_PROCESSING_Model GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }
			public DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }
			public DRILLING_EACH_WELL_COST_Model DRILLING_EACH_WELL_COSTs { get; set; }
			public DRILLING_EACH_WELL_COST_PROPOSED_Model DRILLING_EACH_WELL_COST_PROPOSEDs { get; set; }


		}

		#region FORM 1

		public class CONCESSION_SITUATION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year { get; set; }
			public string? Concession_Held { get; set; }
			public string? Area { get; set; }
			public string? No_of_discovered_field { get; set; }
			public string? No_of_field_producing { get; set; }
			public string? Name_of_Company { get; set; }
			public string? Equity_distribution { get; set; }
			public string? Contract_Type { get; set; }
			public string? Geological_location { get; set; }
			public string? Has_Signature_Bonus_been_paid { get; set; }
			public string? If_No_why_sig { get; set; }
			public string? Has_the_Concession_Rentals_been_paid { get; set; }
			public string? If_No_why_concession { get; set; }
			public string? Is_there_an_application_for_renewal { get; set; }
			public string? If_No_why_renewal { get; set; }
			public string? Budget_actual_for_license_or_lease { get; set; }
			public string? proposed_budget_for_each_license_lease { get; set; }
			public string? Five_year_proposal { get; set; }
			public string? Did_you_meet_the_minimum_work_programme { get; set; }
			public string? Comment { get; set; }
			public DateTime? Date_of_Grant_Expiration { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public DateTime? Date_of_Expiration { get; set; }
			public string? How_Much_Signature_Bonus_have_been_paid_USD { get; set; }
			public string? How_Much_Concession_Rental_have_been_paid_USD { get; set; }
			public string? How_Much_Renewal_Bonus_have_been_paid_USD { get; set; }
			public string? Has_Assignment_of_Interest_Fee_been_paid { get; set; }
			public string? relinquishment_retention { get; set; }
			public string? area_in_square_meter_based_on_company_records { get; set; }
		}

		public class GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model
		{
			public string? Geo_acquired_geophysical_data { get; set; }
			public string? Geo_area_of_coverage { get; set; }
			public string? Geo_method_of_acquisition { get; set; }
			public string? Geo_type_of_data_acquired { get; set; }
			public string? Geo_Record_Length_of_Data { get; set; }
			public string? Geo_Completion_Status { get; set; }
			public string? Quantum { get; set; }
			public string? Quantum_carry_forward { get; set; }
			public string? Geo_Activity_Timeline { get; set; }
			public string? Remarks { get; set; }
			public string? Actual_year_aquired_data { get; set; }
			public string? proposed_year_data { get; set; }
			public string? Budeget_Allocation { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Budeget_Allocation_NGN { get; set; }
			public string? Budeget_Allocation_USD { get; set; }
			public string? Name_of_Contractor { get; set; }
			public string? Quantum_Approved { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Quantum_Planned { get; set; }
			public string? Gas_flare_Royalty_payment { get; set; }
			public string? Gas_Sales_Royalty_Payment { get; set; }
			public string? QUATER { get; set; }
		}

		public class GEOPHYSICAL_ACTIVITIES_PROCESSING_Model
		{
			public string? Geo_Any_Ongoing_Processing_Project { get; set; }
			public string? Geo_Type_of_Data_being_Processed { get; set; }
			public string? Geo_Quantum_of_Data { get; set; }
			public string? Geo_Quantum_of_Data_carry_over { get; set; }
			public string? Geo_Completion_Status { get; set; }
			public string? Geo_Activity_Timeline { get; set; }
			public string? Remarks { get; set; }
			public string? Actual_year_aquired_data { get; set; }
			public string? proposed_year_data { get; set; }
			public string? Budeget_Allocation { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Budeget_Allocation_USD { get; set; }
			public string? Budeget_Allocation_NGN { get; set; }
			public string? Processed_Actual { get; set; }
			public string? Processed_Proposed { get; set; }
			public string? Reprocessed_Actual { get; set; }
			public string? Reprocessed_Proposed { get; set; }
			public string? Interpreted_Actual { get; set; }
			public string? Interpreted_Proposed { get; set; }
			public string? Name_of_Contractor { get; set; }
			public string? Quantum_Approved { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Quantum_Planned { get; set; }
			public string? Consession_Type { get; set; }
			public string? QUATER { get; set; }
		}

		public class DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Category { get; set; }
			public string? Actual_No_Drilled_in_Current_Year { get; set; }
			public string? Proposed_No_Drilled { get; set; }
			public string? Processing_Fees_Paid { get; set; }
			public string? Comments { get; set; }
			public string? No_of_wells_cored { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? well_type { get; set; }
			public string? well_trajectory { get; set; }
			public DateTime? spud_date { get; set; }
			public string? well_cost { get; set; }
			public string? Number_of_Days_to_Total_Depth { get; set; }
			public string? Well_Status_and_Depth { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? well_name { get; set; }
			public string? Consession_Type { get; set; }
			public string? QUATER { get; set; }
			public string? Any_New_Discoveries { get; set; }
			public string? Hydrocarbon_Counts { get; set; }
			public string? State_the_field_where_Discovery_was_made { get; set; }
			public string? Core_Cost_USD { get; set; }
			public string? Core_Depth_Interval { get; set; }
			public string? Propose_well_names { get; set; }
			public string? Actual_wells_name { get; set; }
			public string? Terrain_Drill { get; set; }
			public string? Water_depth { get; set; }
			public string? True_vertical_depth { get; set; }
			public string? Depth_refrence { get; set; }
			public string? Rig_type { get; set; }
			public string? Rig_Name { get; set; }
			public string? Target_reservoir { get; set; }
			public string? Surface_cordinates_for_each_well_in_degrees { get; set; }
			public string? Location_name { get; set; }
			public string? Proposed_cost_per_well { get; set; }
			public string? Basin { get; set; }
			public string? Measured_depth { get; set; }
			public string? FieldDiscoveryUploadFilePath { get; set; }
			public string? HydrocarbonCountUploadFilePath { get; set; }
			public string? Cored { get; set; }
			public string? Actual_Proposed { get; set; }
			public string? WellName { get; set; }
		}

		public class DRILLING_EACH_WELL_COST_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? well_name { get; set; }
			public string? well_cost { get; set; }
			public string? Consession_Type { get; set; }
			public string? QUATER { get; set; }
			public string? Surface_cordinates_for_each_well_in_degrees { get; set; }
		}

		public class DRILLING_EACH_WELL_COST_PROPOSED_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? well_name { get; set; }
			public string? well_cost { get; set; }
			public string? Surface_cordinates_for_each_well_in_degrees { get; set; }
			public string? Consession_Type { get; set; }
			public string? QUATER { get; set; }
		}
		#endregion

		#region FORM 2
		public class INITIAL_WELL_COMPLETION_JOB1_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Do_you_have_approval_to_complete_the_well { get; set; }
			public string? Current_year_Actual_Number { get; set; }
			public string? Current_year_Budget_Allocation { get; set; }
			public string? Proposed_year_data { get; set; }
			public string? Processing_Fees_paid { get; set; }
			public string? Remarks { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Budeget_Allocation_NGN { get; set; }
			public string? Budeget_Allocation_USD { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? QUATER { get; set; }
			public string? oil_or_gas_wells { get; set; }
			public DateTime? Actual_Completion_Date { get; set; }
			public DateTime? Proposed_Completion_Date { get; set; }
		}
		public class WORKOVERS_RECOMPLETION_JOB1_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_year_Actual_Number_data { get; set; }
			public string? Proposed_year_data { get; set; }
			public string? Current_year_Budget_Allocation { get; set; }
			public string? Remarks { get; set; }
			public string? Processing_Fees_paid { get; set; }
			public string? Do_you_have_approval_for_the_workover_recompletion { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Budeget_Allocation_NGN { get; set; }
			public string? Budeget_Allocation_USD { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? QUATER { get; set; }
			public string? oil_or_gas_wells { get; set; }
		}
		public class FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Proposed_Development_well_name { get; set; }
			public string? Field_Name { get; set; }
			public string? Oil { get; set; }
			public string? Gas { get; set; }
			public string? Condensate { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Field_Name { get; set; }
			public string? Development_Plan_Status { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class FIELD_DEVELOPMENT_FIELDS_AND_STATUS_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Field_Name { get; set; }
			public string? Development_Plan_Status { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class RESERVES_UPDATES_LIFE_INDEX_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year_of_WP { get; set; }
			public string? OIL { get; set; }
			public string? CONDENSATE { get; set; }
			public string? NAG { get; set; }
			public string? AG { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class FIELD_DEVELOPMENT_PLAN_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? How_many_fields_have_FDP { get; set; }
			public string? List_all_the_field_with_FDP { get; set; }
			public string? Which_fields_do_you_plan_to_submit_an_FDP { get; set; }
			public string? How_many_fields_have_approved_FDP { get; set; }
			public string? Number_of_wells_proposed_in_the_FDP { get; set; }
			public string? No_of_wells_drilled_in_current_year { get; set; }
			public string? Proposed_number_of_wells_from_approved_FDP { get; set; }
			public string? Processing_Fees_paid { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? how_many_fields_in_concession { get; set; }
			public string? Noof_Producing_Fields { get; set; }
			public string? Uploaded_approved_FDP_Document { get; set; }
			public string? Are_they_oil_or_gas_wells { get; set; }
			public string? FDPDocumentFilename { get; set; }
		}
		public class OIL_CONDENSATE_PRODUCTION_ACTIVITy_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_year_Actual { get; set; }
			public string? Deferment { get; set; }
			public string? Forecast { get; set; }
			public string? Remarks { get; set; }
			public string? Cost_Barrel { get; set; }
			public string? Company_Timeline { get; set; }
			public string? Company_Oil { get; set; }
			public string? Company_Condensate { get; set; }
			public string? Company_AG { get; set; }
			public string? Company_NAG { get; set; }
			public string? Fiveyear_Timeline { get; set; }
			public string? Fiveyear_Oil { get; set; }
			public string? Fiveyear_Condensate { get; set; }
			public string? Fiveyear_AG { get; set; }
			public string? Fiveyear_NAG { get; set; }
			public string? Did_you_carry_out_any_well_test { get; set; }
			public string? Type_of_Test { get; set; }
			public string? Maximum_Efficiency_Rate { get; set; }
			public string? Number_of_Test_Carried_out { get; set; }
			public string? Number_of_Producing_Wells { get; set; }
			public string? Daily_Production_ { get; set; }
			public string? Is_any_of_your_field_straddling { get; set; }
			public string? How_many_fields_straddle { get; set; }
			public string? Straddling_Fields_OC { get; set; }
			public string? Prod_Status_OC { get; set; }
			public string? Straddling_Field_OP { get; set; }
			public string? Company_Name_OP { get; set; }
			public string? Prod_Status_OP { get; set; }
			public string? Has_DPR_been_notified { get; set; }
			public string? Has_the_other_party_been_notified { get; set; }
			public string? Has_the_CA_been_signed { get; set; }
			public string? Committees_been_inaugurated { get; set; }
			public string? Participation_been_determined { get; set; }
			public string? Has_the_PUA_been_signed { get; set; }
			public string? Is_there_a_Joint_Development { get; set; }
			public string? Has_the_UUOA_been_signed { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Total_Reconciled_National_Crude_Oil_Production { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Oil_Royalty_Payment { get; set; }
			public string? straddle_field_producing { get; set; }
			public string? what_concession_field_straddling { get; set; }
			public string? Gas_AG { get; set; }
			public string? Gas_NAG { get; set; }
		}
		public class OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_year_Actual { get; set; }
			public string? Deferment { get; set; }
			public string? Forecast { get; set; }
			public string? Remarks { get; set; }
			public string? Cost_Barrel { get; set; }
			public string? Company_Timeline { get; set; }
			public string? Company_Oil { get; set; }
			public string? Company_Condensate { get; set; }
			public string? Company_AG { get; set; }
			public string? Company_NAG { get; set; }
			public string? Fiveyear_Timeline { get; set; }
			public string? Fiveyear_Oil { get; set; }
			public string? Fiveyear_Condensate { get; set; }
			public string? Fiveyear_AG { get; set; }
			public string? Fiveyear_NAG { get; set; }
			public string? Did_you_carry_out_any_well_test { get; set; }
			public string? Type_of_Test { get; set; }
			public string? Maximum_Efficiency_Rate { get; set; }
			public string? Number_of_Test_Carried_out { get; set; }
			public string? Number_of_Producing_Wells { get; set; }
			public string? Daily_Production_ { get; set; }
			public string? Is_any_of_your_field_straddling { get; set; }
			public string? How_many_fields_straddle { get; set; }
			public string? Straddling_Fields_OC { get; set; }
			public string? Prod_Status_OC { get; set; }
			public string? Straddling_Field_OP { get; set; }
			public string? Company_Name_OP { get; set; }
			public string? Prod_Status_OP { get; set; }
			public string? Has_DPR_been_notified { get; set; }
			public string? Has_the_other_party_been_notified { get; set; }
			public string? Has_the_CA_been_signed { get; set; }
			public string? Committees_been_inaugurated { get; set; }
			public string? Participation_been_determined { get; set; }
			public string? Has_the_PUA_been_signed { get; set; }
			public string? Is_there_a_Joint_Development { get; set; }
			public string? Has_the_UUOA_been_signed { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Total_Reconciled_National_Crude_Oil_Production { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Oil_Royalty_Payment { get; set; }
			public string? straddle_field_producing { get; set; }
			public string? what_concession_field_straddling { get; set; }
			public string? PUAUploadFilePath { get; set; }
			public string? UUOAUploadFilePath { get; set; }
			public string? PUAUploadFilename { get; set; }
			public string? UUOAUploadFilename { get; set; }
		}
		public class GAS_PRODUCTION_ACTIVITy_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_Actual_Year { get; set; }
			public string? Utilized { get; set; }
			public string? Flared { get; set; }
			public string? Forecast_ { get; set; }
			public string? Remarks_ { get; set; }
			public string? How_many_NAG_fields_have_approved_Gas_FDP { get; set; }
			public string? Gas_wells_drilled_and_planned { get; set; }
			public string? Gas_production_and_flare_historical_performance { get; set; }
			public string? Gas_plant_capacity { get; set; }
			public string? Ongoing_and_planned_Gas_plant_projects { get; set; }
			public string? Domestic_gas_obligation { get; set; }
			public string? Planned_projects_for_domestic_supply { get; set; }
			public string? Gas_Field_Development_Plan_Approval { get; set; }
			public string? Gas_wells_drilled_and_wells_planned { get; set; }
			public string? AG_NAG_and_Condensate_in_place_volumes_and_Reserves_Reserves_for_reservoirs_and_Fields { get; set; }
			public string? Maturation_plans_for_leads_and_prospects_leading_to_reserves_growth { get; set; }
			public string? Current_production_status_for_all_Gas_and_condensate_Reservoirs { get; set; }
			public string? Current_gas_production_utilisation_and_Flare_volumes { get; set; }
			public string? Sources_of_Gas_utilisation_should_be_clearly_stated { get; set; }
			public string? Gas_Production_and_flare_historical_Performance_5_years_Performance_and_Plan { get; set; }
			public string? Substantiate_flare_reduction_methods_with_projects { get; set; }
			public string? Annotate_clearly_reasons_for_increase_or_reduction_in_Gas_production_utilisation_and_flare_profiles { get; set; }
			public string? Current_pressures_for_Gas_and_condensate_Reservoirs { get; set; }
			public string? Production_forecast_for_all_Gas_and_condensate_reservoirs { get; set; }
			public string? Gas_compositional_Analysis { get; set; }
			public string? Feed_gas_Volumes_into_the_Processing_Facility { get; set; }
			public string? Gas_Plant_Capacity_NEW { get; set; }
			public string? Plant_Utilization_Capacity { get; set; }
			public string? Plant_maintenance_activities { get; set; }
			public string? ongoing_and_planned_Gas_plant_projects_NEW { get; set; }
			public string? LNG_and_NGLs_Production_forecast { get; set; }
			public string? Custody_Transfer_status { get; set; }
			public string? License_Renewal_Status_for_all_Gas_plants { get; set; }
			public string? Pipeline_license_renewal_staus { get; set; }
			public string? Domestic_Gas_Supply_DSO { get; set; }
			public string? Projects_planned_for_Domestic_supply_Gas_to_power_industries_etc { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? penaltyfeepaid { get; set; }
			public string? Amount_Paid { get; set; }
			public string? Consession_Type { get; set; }
			public string? proposed_production { get; set; }
			public string? proposed_utilization { get; set; }
			public string? proposed_flaring { get; set; }
			public string? Gas_flare_Royalty_payment { get; set; }
			public string? Gas_Sales_Royalty_Payment { get; set; }
			public string? No_of_gas_well_planned { get; set; }
			public string? No_of_gas_well_drilled { get; set; }
			public string? Is_there_a_gas_plant { get; set; }
			public string? No_of_ongoing_projects { get; set; }
			public string? No_of_plannned_projects { get; set; }
			public string? Is_there_a_license_to_operate_a_gas_plant { get; set; }
			public string? Domestic_Gas_obligation_met { get; set; }
			public string? Has_annual_NDR_subscription_fee_been_paid { get; set; }
			public DateTime? When_was_the_date_of_your_last_NDR_submission { get; set; }
			public string? Upload_NDR_payment_receipt { get; set; }
			public string? Are_you_up_to_date_with_your_NDR_data_submission { get; set; }
			public string? NDRFilename { get; set; }
			public string? number_of_gas_wells_completed { get; set; }
			public string? number_of_gas_wells_tested { get; set; }
		}
		public class NDR_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Has_annual_NDR_subscription_fee_been_paid { get; set; }
			public DateTime? When_was_the_date_of_your_last_NDR_submission { get; set; }
			public string? Upload_NDR_payment_receipt { get; set; }
			public string? Are_you_up_to_date_with_your_NDR_data_submission { get; set; }
			public string? NDRFilename { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Company_Reserves_Year { get; set; }
			public string? Company_Reserves_Oil { get; set; }
			public string? Company_Reserves_Condensate { get; set; }
			public string? Company_Reserves_AG { get; set; }
			public string? Company_Reserves_NAG { get; set; }
			public string? Company_Reserves_AnnualOilProduction { get; set; }
			public string? FLAG1 { get; set; }
			public string? FLAG2 { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Company_Reserves_AnnualGasProduction { get; set; }
			public string? Company_Reserves_AnnualCondensateProduction { get; set; }
			public string? Company_Reserves_AnnualGasAGProduction { get; set; }
			public string? Company_Reserves_AnnualGasNAGProduction { get; set; }
		}
		public class RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Fiveyear_Projection_Year { get; set; }
			public string? Fiveyear_Projection_Oil { get; set; }
			public string? Fiveyear_Projection_Condensate { get; set; }
			public string? Fiveyear_Projection_AG { get; set; }
			public string? Fiveyear_Projection_NAG { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_year_Actual { get; set; }
			public string? Deferment { get; set; }
			public string? Forecast { get; set; }
			public string? Remarks { get; set; }
			public string? Cost_Barrel { get; set; }
			public string? Company_Timeline { get; set; }
			public string? Company_Oil { get; set; }
			public string? Company_Condensate { get; set; }
			public string? Company_AG { get; set; }
			public string? Company_NAG { get; set; }
			public string? Fiveyear_Timeline { get; set; }
			public string? Fiveyear_Oil { get; set; }
			public string? Fiveyear_Condensate { get; set; }
			public string? Fiveyear_AG { get; set; }
			public string? Fiveyear_NAG { get; set; }
			public string? Did_you_carry_out_any_well_test { get; set; }
			public string? Type_of_Test { get; set; }
			public string? Maximum_Efficiency_Rate { get; set; }
			public string? Number_of_Test_Carried_out { get; set; }
			public string? Number_of_Producing_Wells { get; set; }
			public string? Daily_Production_ { get; set; }
			public string? Is_any_of_your_field_straddling { get; set; }
			public string? How_many_fields_straddle { get; set; }
			public string? Straddling_Fields_OC { get; set; }
			public string? Prod_Status_OC { get; set; }
			public string? Straddling_Field_OP { get; set; }
			public string? Company_Name_OP { get; set; }
			public string? Prod_Status_OP { get; set; }
			public string? Has_DPR_been_notified { get; set; }
			public string? Has_the_other_party_been_notified { get; set; }
			public string? Has_the_CA_been_signed { get; set; }
			public string? Committees_been_inaugurated { get; set; }
			public string? Participation_been_determined { get; set; }
			public string? Has_the_PUA_been_signed { get; set; }
			public string? Is_there_a_Joint_Development { get; set; }
			public string? Has_the_UUOA_been_signed { get; set; }
			public string? Actual_year { get; set; }
			public string? proposed_year { get; set; }
			public string? Total_Reconciled_National_Crude_Oil_Production { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? ProductionOilCondensateAGNAGUploadFilePath { get; set; }
			public string? ProductionOilCondensateAGNAGUFilename { get; set; }
		}
		public class RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Company_Annual_Year { get; set; }
			public string? Company_Annual_Oil { get; set; }
			public string? Company_Annual_Condensate { get; set; }
			public string? Company_Annual_AG { get; set; }
			public string? Company_Annual_NAG { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}
		public class RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Reserves_Decline_Was_there_a_decline_in_reserve { get; set; }
			public string? Reserves_Decline_Reason_for_Decline { get; set; }
			public string? Reserves_Decline_Oil { get; set; }
			public string? Reserves_Decline_Condensate { get; set; }
			public string? Reserves_Decline_AG { get; set; }
			public string? Reserves_Decline_NAG { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
		}
		public class RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Reserves_Addition_Was_there_any_Reserve_Addition { get; set; }
			public string? Reserves_Addition_Reason_for_Addition { get; set; }
			public string? Reserves_Addition_Oil { get; set; }
			public string? Reserves_Addition_Condensate { get; set; }
			public string? Reserves_Addition_AG { get; set; }
			public string? Reserves_Addition_NAG { get; set; }

			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
		}
		public class OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public int? Production_month_id { get; set; }
			public string? Production_month { get; set; }
			public string? Production { get; set; }
			public string? Avg_Daily_Production { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Gas_AG { get; set; }
			public string? Gas_NAG { get; set; }
		}
		public class RESERVES_REPLACEMENT_RATIO_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? RESERVES_REPLACEMENT_RATIO_VALUE { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Trend_Year { get; set; }
		}
		public class OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public int? Production_month_id { get; set; }
			public string? Production_month { get; set; }
			public string? Production { get; set; }
			public string? Avg_Daily_Production { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Gas_AG { get; set; }
			public string? Gas_NAG { get; set; }
		}
		public class GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ProjectName { get; set; }
			public string? Description { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}
		#endregion

		#region Form 3
		public class WorkProgramme_Model3
		{
			public string WorkProgramme_Year { get; set; }
			public BUDGET_ACTUAL_EXPENDITURE_Model BUDGET_ACTUAL_EXPENDITURE { get; set; }
			public BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT_Model BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT { get; set; }
			public BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy_Model BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy { get; set; }
			public BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy_Model BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy { get; set; }
			public BUDGET_PERFORMANCE_PRODUCTION_COST_Model BUDGET_PERFORMANCE_PRODUCTION_COST { get; set; }
			public BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT_Model BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT { get; set; }
			public OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE_Model OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment { get; set; }
			public OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT_Model OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT { get; set; }
			public FACILITIES_PROJECT_PERFORMANCE_Model FACILITIES_PROJECT_PERFORMANCE { get; set; }
			public BUDGET_CAPEX_OPEX_Model BUDGET_CAPEX_OPEX { get; set; }
		}
		public class BUDGET_ACTUAL_EXPENDITURE_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Budget_for_Direct_Exploration_and_Production_Activities { get; set; }
			public string? Budget_for_other_Activities { get; set; }
			public string? Equivalent_Naira_and_Dollar_Component_ { get; set; }
			public string? Actual_year { get; set; }
			public string? Proposed_year { get; set; }
			public string? Budget_for_Direct_Exploration_and_Production_Activities_NGN { get; set; }
			public string? Budget_for_Direct_Exploration_and_Production_Activities_USD { get; set; }
			public string? Budget_for_other_Activities_NGN { get; set; }
			public string? Budget_for_other_Activities_USD { get; set; }
			public string? Equivalent_Naira_and_Dollar_Component_NGN { get; set; }
			public string? Equivalent_Naira_and_Dollar_Component_USD { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Year_of_Proposal { get; set; }
			public string? Budget_for_Direct_Exploration_and_Production_Activities_Naira { get; set; }
			public string? Budget_for_Direct_Exploration_and_Production_Activities_Dollars { get; set; }
			public string? Budget_for_other_Activities_Naira { get; set; }
			public string? Budget_for_other_Activities_Dollars { get; set; }
			public string? Total_Company_Expenditure_Dollars { get; set; }
			public string? Actual_year { get; set; }
			public string? Proposed_year { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? ACQUISITION_planned { get; set; }
			public string? ACQUISITION_Actual { get; set; }
			public string? PROCESSING_planned { get; set; }
			public string? PROCESSING_Actual { get; set; }
			public string? REPROCESSING_planned { get; set; }
			public string? REPROCESSING_Actual { get; set; }
			public string? EXPLORATION_planned { get; set; }
			public string? EXPLORATION_Actual { get; set; }
			public string? APPRAISAL_planned { get; set; }
			public string? APPRAISAL_Actual { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}
		public class BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? DEVELOPMENT_planned { get; set; }
			public string? DEVELOPMENT_Actual { get; set; }
			public string? WORKOVER_planned { get; set; }
			public string? WORKOVER_Actual { get; set; }
			public string? COMPLETION_planned { get; set; }
			public string? COMPLETION_Actual { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class BUDGET_PERFORMANCE_PRODUCTION_COST_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? DIRECT_COST_planned { get; set; }
			public string? DIRECT_COST_Actual { get; set; }
			public string? INDIRECT_COST_planned { get; set; }
			public string? INDIRECT_COST_Actual { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? CONCEPT_planned { get; set; }
			public string? CONCEPT_Actual { get; set; }
			public string? FEED_planned { get; set; }
			public string? FEED_COST_Actual { get; set; }
			public string? DETAILED_ENGINEERING_planned { get; set; }
			public string? DETAILED_ENGINEERING_Actual { get; set; }
			public string? PROCUREMENT_planned { get; set; }
			public string? PROCUREMENT_Actual { get; set; }
			public string? CONSTRUCTION_FABRICATION_planned { get; set; }
			public string? CONSTRUCTION_FABRICATION_Actual { get; set; }
			public string? INSTALLATION_planned { get; set; }
			public string? INSTALLATION_Actual { get; set; }
			public string? UPGRADE_MAINTENANCE_planned { get; set; }
			public string? UPGRADE_MAINTENANCE_Actual { get; set; }
			public string? DECOMMISSIONING_ABANDONMENT { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Actual_capital_expenditure_Current_year { get; set; }
			public string? Proposed_Capital_Expenditure { get; set; }
			public string? Remarks { get; set; }
			public string? Actual_year { get; set; }
			public string? Proposed_year { get; set; }
			public string? Created_by { get; set; }
			public string? Updated_by { get; set; }
			public DateTime? Date_Created { get; set; }
			public DateTime? Date_Updated { get; set; }
			public string? Actual_capital_expenditure_Current_year_NGN { get; set; }
			public string? Actual_capital_expenditure_Current_year_USD { get; set; }
			public string? Proposed_Capital_Expenditure_NGN { get; set; }
			public string? Proposed_Capital_Expenditure_USD { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Name { get; set; }
			public string? Objective { get; set; }
			public string? Existing_Alternatives { get; set; }
			public string? DPR_Consent { get; set; }
			public string? Cost { get; set; }
			public string? Benefits { get; set; }
			public string? Challenges { get; set; }
			public string? Timeline { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Major_Projects { get; set; }
			public string? Name { get; set; }
			public string? Objective_Drivers_ { get; set; }
			public string? Approval_License_Permits { get; set; }
			public string? CAPEX_Oversight { get; set; }
			public string? Budget_Performance { get; set; }
			public string? Completion_Status { get; set; }
			public string? Conceptual { get; set; }
			public string? FEED { get; set; }
			public string? Detailed_Engineering { get; set; }
			public string? Construction_Commissioning_ { get; set; }
			public string? Production_Product_Offtakers { get; set; }
			public string? Challenges { get; set; }
			public string? Project_Timeline { get; set; }
			public string? Conformity_Assessment { get; set; }
			public string? New_Technology_ { get; set; }
			public string? Has_it_been_adopted_by_DPR_ { get; set; }
			public string? Comment_ { get; set; }
			public string? Planned_ongoing_and_routine_maintenance { get; set; }
			public string? Actual_year { get; set; }
			public string? Proposed_year { get; set; }
			public string? Actual_capital_expenditure_Current_year_NGN { get; set; }
			public string? Actual_capital_expenditure_Current_year_USD { get; set; }
			public string? Proposed_Capital_Expenditure_NGN { get; set; }
			public string? Proposed_Capital_Expenditure_USD { get; set; }
			public string? Project_Stage { get; set; }
			public string? Nigerian_Content_Value { get; set; }
			public string? Product_Off_takers { get; set; }
			public string? Actual_Proposed_year { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Actual_Proposed { get; set; }
		}

		public class FACILITIES_PROJECT_PERFORMANCE_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? List_of_Projects { get; set; }
			public string? Planned_completion { get; set; }
			public string? Actual_completion { get; set; }
			public string? FLAG { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class BUDGET_CAPEX_OPEX_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Item_Type { get; set; }
			public string? Item_Description { get; set; }
			public string? naira { get; set; }
			public string? dollar { get; set; }
			public string? Dollar_equivalent { get; set; }
			public string? remarks { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		#endregion
		public class WorkProgramme_Model
		{
			public string WorkProgramme_Year { get; set; }
			public CONCESSION_SITUATION_Model CONCESSION_SITUATION { get; set; }
			public GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model GEOPHYSICAL_ACTIVITIES_ACQUISITIONs { get; set; }
			public GEOPHYSICAL_ACTIVITIES_PROCESSING_Model GEOPHYSICAL_ACTIVITIES_PROCESSINGs { get; set; }
			public DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model DRILLING_OPERATIONS_CATEGORIES_OF_WELLs { get; set; }
			public DRILLING_EACH_WELL_COST_Model DRILLING_EACH_WELL_COSTs { get; set; }
			public DRILLING_EACH_WELL_COST_PROPOSED_Model DRILLING_EACH_WELL_COST_PROPOSEDs { get; set; }

			//For Form 2
			public INITIAL_WELL_COMPLETION_JOB1 Initial_Well_Completion_Job { get; set; }
			public WORKOVERS_RECOMPLETION_JOB1_Model WORKOVERS_RECOMPLETION_JOB1 { get; set; }
			public FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf_Model FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVE { get; set; }

			public FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP_Model FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP { get; set; }

			public FIELD_DEVELOPMENT_FIELDS_AND_STATUS_Model FIELD_DEVELOPMENT_FIELDS_AND_STATUS { get; set; }

			public RESERVES_UPDATES_LIFE_INDEX_Model RESERVES_UPDATES_LIFE_INDEX { get; set; }

			public FIELD_DEVELOPMENT_PLAN_Model FIELD_DEVELOPMENT_PLAN { get; set; }

			public OIL_CONDENSATE_PRODUCTION_ACTIVITy_Model OIL_CONDENSATE_PRODUCTION_ACTIVITy { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION { get; set; }
			public GAS_PRODUCTION_ACTIVITy_Model GAS_PRODUCTION_ACTIVITy { get; set; }
			public NDR_Model NDR { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_Model RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection_Model RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION_Model RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE_Model RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE { get; set; }
			public RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition_Model RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity { get; set; }
			public RESERVES_REPLACEMENT_RATIO_Model RESERVES_REPLACEMENT_RATIO { get; set; }
			public OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED_Model OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED { get; set; }
			public GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY_Model GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY { get; set; }

		}

		#region Form 4

		public class WorkProgramme_Model4
		{
			public string WorkProgramme_Year { get; set; }
			public NIGERIA_CONTENT_Training_Model NIGERIA_CONTENT_Training { get; set; }
			public NIGERIA_CONTENT_Upload_Succession_Plan_Model NIGERIA_CONTENT_Upload_Succession_Plan { get; set; }
			public NIGERIA_CONTENT_QUESTION_Model NIGERIA_CONTENT_QUESTION { get; set; }
			public LEGAL_LITIGATION_Model LEGAL_LITIGATION { get; set; }
			public LEGAL_ARBITRATION_Model LEGAL_ARBITRATION { get; set; }
			public STRATEGIC_PLANS_ON_COMPANY_BASI_Model STRATEGIC_PLANS_ON_COMPANY_BASI { get; set; }
		}

		public class NIGERIA_CONTENT_Training_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Training_ { get; set; }
			public string? Local_ { get; set; }
			public string? Foreign_ { get; set; }
			public string? Expatriate_quota_positions { get; set; }
			public string? Utilized_EQ { get; set; }
			public string? Nigerian_Understudies { get; set; }
			public string? Management_Foriegn { get; set; }
			public string? Management_Local { get; set; }
			public string? Staff_Foriegn { get; set; }
			public string? Staff_Local { get; set; }
			public string? Actual_Proposed { get; set; }
			public string? Actual_Proposed_Year { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
		}

		public class NIGERIA_CONTENT_Upload_Succession_Plan_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Name_ { get; set; }
			public string? Understudy_ { get; set; }
			public string? Timeline_ { get; set; }
			public string? Position_Occupied_ { get; set; }
			public string? Actual_proposed { get; set; }
			public string? Actual_Proposed_Year { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class NIGERIA_CONTENT_QUESTION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Do_you_have_a_valid_Expatriate_Quota_for_your_foreign_staff { get; set; }
			public string? If_NO_why { get; set; }
			public string? Is_there_a_succession_plan_in_place { get; set; }
			public string? Number_of_staff_released_within_the_year_ { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? total_no_of_nigeria_senior_staff { get; set; }
			public string? total_no_of_senior_staff { get; set; }
			public string? total_no_of_top_nigerian_management_staff { get; set; }
			public string? total_no_of_top_management_staff { get; set; }
		}

		public class LEGAL_LITIGATION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
			public string? AnyLitigation { get; set; }
			public string? Case_Number { get; set; }
			public string? Names_of_Parties { get; set; }
			public string? Jurisdiction { get; set; }
			public string? Name_of_Court { get; set; }
			public string? Summary_of_the_case { get; set; }
			public string? Any_orders_made_so_far_by_the_court { get; set; }
			public string? Potential_outcome { get; set; }
		}

		public class LEGAL_ARBITRATION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
			public string? AnyLitigation { get; set; }
			public string? Case_Number { get; set; }
			public string? Names_of_Parties { get; set; }
			public string? Jurisdiction { get; set; }
			public string? Name_of_Court { get; set; }
			public string? Summary_of_the_case { get; set; }
			public string? Any_orders_made_so_far_by_the_court { get; set; }
			public string? Potential_outcome { get; set; }
		}

		public class STRATEGIC_PLANS_ON_COMPANY_BASI_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTIVITIES { get; set; }
			public string? N_1_Q1 { get; set; }
			public string? N_1_Q2 { get; set; }
			public string? N_1_Q3 { get; set; }
			public string? N_1_Q4 { get; set; }
			public string? N_2_Q1 { get; set; }
			public string? N_2_Q2 { get; set; }
			public string? N_2_Q3 { get; set; }
			public string? N_2_Q4 { get; set; }
			public string? N_3_Q1 { get; set; }
			public string? N_3_Q2 { get; set; }
			public string? N_3_Q3 { get; set; }
			public string? N_3_Q4 { get; set; }
			public string? N_4_Q1 { get; set; }
			public string? N_4_Q2 { get; set; }
			public string? N_4_Q3 { get; set; }
			public string? N_4_Q4 { get; set; }
			public string? N_5_Q1 { get; set; }
			public string? N_5_Q2 { get; set; }
			public string? N_5_Q3 { get; set; }
			public string? N_5_Q4 { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		#endregion

		#region Form 5
		public class WorkProgramme_Model5
		{
			public string WorkProgramme_Year { get; set; }
			public HSE_QUESTION_Model HSE_QUESTION { get; set; }
			public HSE_FATALITy_Model HSE_FATALITy { get; set; }
			public HSE_DESIGNS_SAFETY_Model HSE_DESIGNS_SAFETY { get; set; }
			public HSE_SAFETY_STUDIES_NEW_Model HSE_SAFETY_STUDIES_NEW { get; set; }
			public HSE_INSPECTION_AND_MAINTENANCE_NEW_Model HSE_INSPECTION_AND_MAINTENANCE_NEW { get; set; }
			public HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW_Model HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW { get; set; }
			public HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW_Model HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW { get; set; }
			public HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW_Model HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW { get; set; }
			public HSE_OIL_SPILL_REPORTING_NEW_Model HSE_OIL_SPILL_REPORTING_NEW { get; set; }
			public HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW_Model HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW { get; set; }
			public HSE_ACCIDENT_INCIDENCE_REPORTING_NEW_Model HSE_ACCIDENT_INCIDENCE_REPORTING_NEW { get; set; }
			public HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_Model HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW { get; set; }
			public HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW_Model HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW { get; set; }
			public HSE_ENVIRONMENTAL_STUDIES_NEW_Model HSE_ENVIRONMENTAL_STUDIES_NEW { get; set; }
			public HSE_WASTE_MANAGEMENT_NEW_Model HSE_WASTE_MANAGEMENT_NEW { get; set; }
			public HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW_Model HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW { get; set; }
			public HSE_PRODUCED_WATER_MANAGEMENT_NEW_Model HSE_PRODUCED_WATER_MANAGEMENT_NEW { get; set; }
			public HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW_Model HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW { get; set; }
			public HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW_Model HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW { get; set; }
			public HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL_Model HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL { get; set; }
			public HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED_Model HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED { get; set; }
			public HSE_OSP_REGISTRATIONS_NEW_Model HSE_OSP_REGISTRATIONS_NEW { get; set; }
			public HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED_Model HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED { get; set; }
			public HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW_Model HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW { get; set; }
			public HSE_CAUSES_OF_SPILL_Model HSE_CAUSES_OF_SPILL { get; set; }
			public HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU_Model HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU { get; set; }
			public HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME_Model HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME { get; set; }
			public HSE_MANAGEMENT_POSITION_Model HSE_MANAGEMENT_POSITION { get; set; }
			public HSE_QUALITY_CONTROL_Model HSE_QUALITY_CONTROL { get; set; }
			public HSE_CLIMATE_CHANGE_AND_AIR_QUALITY_Model HSE_CLIMATE_CHANGE_AND_AIR_QUALITY { get; set; }
			public HSE_SAFETY_CULTURE_TRAINING_Model HSE_SAFETY_CULTURE_TRAINING { get; set; }
			public HSE_OCCUPATIONAL_HEALTH_MANAGEMENT_Model HSE_OCCUPATIONAL_HEALTH_MANAGEMENT { get; set; }
			public HSE_WASTE_MANAGEMENT_SYSTEM_Model HSE_WASTE_MANAGEMENT_SYSTEM { get; set; }
			public HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM_Model HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM { get; set; }
			public PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT_Model PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT { get; set; }
		}

		#region
		public class HSE_QUESTION_Model
		{
			public string? Qty_Spilled { get; set; }
			public string? Accident_Stat { get; set; }
			public string? Relevant_Certificate { get; set; }
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class HSE_FATALITy_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_year_DATA { get; set; }
			public string? Proposed_year_DATA { get; set; }
			public string? Current_year { get; set; }
			public string? Proposed_year { get; set; }
			public string? Fatalities_Type { get; set; }
			public string? Fatalities_Proposed_year { get; set; }
			public string? Fatalities_Current_year { get; set; }
			public string? type_of_incidence { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_DESIGNS_SAFETY_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Current_year { get; set; }
			public string? Proposed_year { get; set; }
			public string? DESIGNS_SAFETY_Type { get; set; }
			public string? DESIGNS_SAFETY_Proposed_year { get; set; }
			public string? DESIGNS_SAFETY_Current_year { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class HSE_SAFETY_STUDIES_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Did_you_carry_out_safety_studies { get; set; }
			public string? State_Project_Name_for_which_studies_was_carried_out { get; set; }
			public string? List_the_studies { get; set; }
			public string? List_identified_Major_Accident_Hazards_for_the_study { get; set; }
			public string? List_the_Safeguards_based_on_the_identified_Major_Accident_Hazards { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? SMSFileUploadPath { get; set; }
			public string? DoyouhaveSMSinPlace { get; set; }
		}

		public class HSE_INSPECTION_AND_MAINTENANCE_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Was_Inspection_and_Maintenance_of_each_of_your_facility_carried_out { get; set; }
			public string? Is_the_inspection_philosophy_Prescriptive_or_RBI_for_each_facility { get; set; }
			public string? If_RBI_was_approval_granted { get; set; }
			public string? If_No_Give_reasonS { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Facility_Type { get; set; }
			public string? Type_of_Inspection_and_Maintenance { get; set; }
			public string? When_was_it_carried_out { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Name_of_facility { get; set; }
			public string? was_the_inspection_and_maintenemce { get; set; }
			public string? If_RBI_was_approval_granted { get; set; }
			public string? If_No_Give_reasonS { get; set; }
		}

		public class HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? facility { get; set; }
			public string? study_type { get; set; }
			public string? facility_location { get; set; }
			public string? approval_status { get; set; }
			public string? remarks { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? facility { get; set; }
			public string? Equipment_type { get; set; }
			public string? Equipment_description { get; set; }
			public string? Equipment_serial_number { get; set; }
			public string? Equipment_tag_number { get; set; }
			public string? Equipment_manufacturer { get; set; }
			public DateTime? Equipment_Installation_date { get; set; }
			public DateTime? Last_inspection_date { get; set; }
			public string? Last_Inspection_Type_Performed { get; set; }
			public DateTime? Next_Inspection_Date { get; set; }
			public string? Proposed_Inspection_Type { get; set; }
			public string? Equipment_Inspected_as_and_when_due { get; set; }
			public string? State_reason { get; set; }
			public string? Condition_of_Equipment { get; set; }
			public string? Function_Test_Result { get; set; }
			public string? Inspection_Report_Review { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class HSE_OIL_SPILL_REPORTING_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Incident_Oil_Spill_Ref_No { get; set; }
			public string? Facility_Equipment { get; set; }
			public string? Location { get; set; }
			public string? LGA { get; set; }
			public string? State_ { get; set; }
			public DateTime? Date_of_Spill { get; set; }
			public string? Type_of_operation_at_spill_site { get; set; }
			public string? Cause_of_spill { get; set; }
			public string? Volume_of_spill_bbls { get; set; }
			public string? Volume_recovered_bbls { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? facility { get; set; }
			public string? Equipment_type { get; set; }
			public string? Equipment_description { get; set; }
			public string? Equipment_serial_number { get; set; }
			public string? Equipment_tag_number { get; set; }
			public string? Equipment_manufacturer { get; set; }
			public DateTime? Equipment_Installation_date { get; set; }
			public DateTime? Last_inspection_date { get; set; }
			public string? Last_Inspection_Type_Performed { get; set; }
			public string? Likelihood_of_Failure { get; set; }
			public string? Consequence_of_Failure { get; set; }
			public string? Maximum_Inspection_Interval { get; set; }
			public DateTime? Next_Inspection_Date { get; set; }
			public string? Proposed_Inspection_Type { get; set; }
			public DateTime? RBI_Assessment_Date { get; set; }
			public string? Equipment_Inspected_as_and_when_due { get; set; }
			public string? State_reason { get; set; }
			public string? Condition_of_Equipment { get; set; }
			public string? Function_Test_Result { get; set; }
			public string? Inspection_Report_Review { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_ACCIDENT_INCIDENCE_REPORTING_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Was_there_any_accident_incidence { get; set; }
			public string? If_YES_were_they_reported { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Type_of_Accident_Incidence { get; set; }
			public string? Location { get; set; }
			public string? Investigation { get; set; }
			public string? Date_ { get; set; }
			public string? Cause { get; set; }
			public string? Consequence { get; set; }
			public string? Lesson_Learnt { get; set; }
			public string? Frequency { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
		}

		public class HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Was_there_any_Community_Related_Disturbances_within_your_operational_area { get; set; }
			public string? If_YES_Give_details_on_Community_Related_Disturbances_within_your_operational_area { get; set; }
			public string? Was_any_Oil_Spill_recorded_within_your_operational_area { get; set; }
			public string? Possible_causes { get; set; }
			public string? Effect_on_your_operations { get; set; }
			public string? Cost_involved { get; set; }
			public string? Total_days_lost { get; set; }
			public string? No_of_casual_Fatality { get; set; }
			public string? Action_Plan_for_ { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
			public string? Oil_spill_reported { get; set; }
		}
		public class HSE_ENVIRONMENTAL_STUDIES_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Any_Environmental_Studies { get; set; }
			public string? If_YES_state_Project_Name { get; set; }
			public string? Status_ { get; set; }
			public string? If_Ongoing { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_WASTE_MANAGEMENT_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Do_you_have_Waste_Management_facilities { get; set; }
			public string? If_YES_is_the_facility_registered { get; set; }
			public string? If_NO_give_reasons_for_not_being_registered { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW_Model
		{
			public int Id { get; set; }
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Type_of_Facility { get; set; }
			public string? Approved_or_Not_Approve { get; set; }
			public string? Created_by { get; set; }
			public string? Updated_by { get; set; }
			public DateTime? Date_Created { get; set; }
			public DateTime? Date_Updated { get; set; }
			public string? LOCATION { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? COMPANY_ID { get; set; }
		}

		public class HSE_PRODUCED_WATER_MANAGEMENT_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? CompanyName { get; set; }
			public string? Companyemail { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Within_which_zone_are_you_operating { get; set; }
			public string? how_do_you_handle_your_produced_water { get; set; }
			public string? Export_to_Terminal_with_fluid { get; set; }
			public string? Created_by { get; set; }
			public string? Updated_by { get; set; }
			public DateTime? Date_Created { get; set; }
			public DateTime? Date_Updated { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? COMPANY_ID { get; set; }
		}

		public class HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Are_you_a_Producing_or_Non_Producing_Company { get; set; }
			public string? If_YES_have_you_registered_your_Point_Sources { get; set; }
			public string? If_NO_give_reasons_for_not_registering_your_Point_Sources { get; set; }
			public string? Have_you_submitted_your_Environmental_Compliance_Report { get; set; }
			public string? If_NO_Give_reasons_for_non_SUBMISSION { get; set; }
			public string? Have_you_submitted_your_Chemical_Usage_Inventorization_Report { get; set; }
			public string? If_NO_Give_reasons_for_non_submission_2 { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? YEAR_ { get; set; }
			public string? Type_of_Study_IA_or_EES { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Description_of_Projects_Planned { get; set; }
			public string? Description_of_Projects_Actual { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Have_you_submitted_all_MoUs_to_DPR { get; set; }
			public string? If_NO_why { get; set; }
			public string? Do_you_have_an_MOU_with_the_communities_for_all_your_assets { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? MOUResponderFilePath { get; set; }
			public string? MOUOSCPFilePath { get; set; }
			public string? MOUResponderFilename { get; set; }
			public string? MOUOSCPFilename { get; set; }
			public string? MOUResponderInPlace { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? CSR_ { get; set; }
			public string? Budget_ { get; set; }
			public string? Actual_Spent { get; set; }
			public string? Percentage_Completion_ { get; set; }
			public string? Beneficiary_Communities { get; set; }
			public string? Actual_proposed { get; set; }
			public string? Actual_Proposed_Year { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarship_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? CSR_ { get; set; }
			public string? Budget_ { get; set; }
			public string? Actual_Spent { get; set; }
			public string? Percentage_Completion_ { get; set; }
			public string? Beneficiary_Communities_host { get; set; }
			public string? Beneficiary_Communities_National { get; set; }
			public string? Actual_proposed { get; set; }
			public string? Actual_Proposed_Year { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? CSR_ { get; set; }
			public string? Budget_ { get; set; }
			public string? Actual_Spent { get; set; }
			public string? Percentage_Completion_ { get; set; }
			public string? Beneficiary_Communities_host { get; set; }
			public string? Beneficiary_Communities_National { get; set; }
			public string? Actual_proposed { get; set; }
			public string? Actual_Proposed_Year { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? field_name { get; set; }
			public string? type_of_study { get; set; }
			public string? study_title { get; set; }
			public string? current_study_status { get; set; }
			public string? DPR_approval_Status { get; set; }
			public string? Consession_Type { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
		}

		public class HSE_OSP_REGISTRATIONS_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? DESCRIPTION_ { get; set; }
			public string? VALUES_ { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }

		}

		public class HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? FIELD_NAME { get; set; }
			public string? Concession { get; set; }
			public string? facilities { get; set; }
			public string? DEPTH_AND_DISTANCE_FROM_SHORELINE { get; set; }
			public string? Produced_water_volumes { get; set; }
			public string? Disposal_philosophy { get; set; }
			public string? DPR_APPROVAL_STATUS { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? ACTUAL_year { get; set; }
			public string? PROPOSED_year { get; set; }
			public string? Name_of_Chemical { get; set; }
			public string? DPR_Approved { get; set; }
			public string? Quarter_1 { get; set; }
			public string? Quarter_2 { get; set; }
			public string? Quarter_3 { get; set; }
			public string? Quarter_4 { get; set; }
			public string? Contract_Type { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
		}

		public class HSE_CAUSES_OF_SPILL_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? no_of_spills_reported { get; set; }
			public string? Total_Quantity_Spilled { get; set; }
			public string? Total_Quantity_Recovered { get; set; }
			public string? Corrosion { get; set; }
			public string? Equipment_Failure { get; set; }
			public string? Erossion_waves_sand { get; set; }
			public string? Human_Error { get; set; }
			public string? Mystery { get; set; }
			public string? Operational_Maintenance_Error { get; set; }
			public string? Sabotage { get; set; }
			public string? YTBD { get; set; }
			public string? Contract_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Consession_Type { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? Type_of_project_excuted { get; set; }
			public string? Year_GMou_was_signed { get; set; }
			public string? Project_Location { get; set; }
			public string? Component_of_project { get; set; }
			public string? Actual_Budget_Total_Dollars { get; set; }
			public string? Beneficiary_Community { get; set; }
			public string? Status_Of_Project { get; set; }
			public string? MOUUploadFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? MOUUploadFilename { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? NameOfCommunity { get; set; }
			public string? Year_GMou_was_signed { get; set; }
			public string? ScholarshipYear { get; set; }
			public string? ComponentOfScholarship { get; set; }
			public string? Actual_Budget_Total_Dollars { get; set; }
			public string? SSUploadFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? SSUploadFilename { get; set; }
		}

		public class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? NameOfCommunity { get; set; }
			public string? Year_GMou_was_signed { get; set; }
			public string? TrainingYear { get; set; }
			public string? ComponentOfTraining { get; set; }
			public string? Actual_Budget_Total_Dollars { get; set; }
			public string? StatusOfTraining { get; set; }
			public string? TSUploadFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? TSUploadFilename { get; set; }
		}
		public class HSE_MANAGEMENT_POSITION_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? OrganogramrFilePath { get; set; }
			public string? PromotionLetterFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? OrganogramrFilename { get; set; }
			public string? PromotionLetterFilename { get; set; }
		}

		public class HSE_QUALITY_CONTROL_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? DoyouhaveQualityControl { get; set; }
			public string? QualityControlFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? QualityControlFilename { get; set; }
		}

		public class HSE_CLIMATE_CHANGE_AND_AIR_QUALITY_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? DoyouhaveGHG { get; set; }
			public string? GHGFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? GHGFilename { get; set; }
		}

		public class HSE_SAFETY_CULTURE_TRAINING_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? SafetyCurrentYearFilePath { get; set; }
			public string? SafetyLast2YearsFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? SafetyCurrentYearFilename { get; set; }
			public string? SafetyLast2YearsFilename { get; set; }
		}

		public class HSE_OCCUPATIONAL_HEALTH_MANAGEMENT_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? OHMplanFilePath { get; set; }
			public string? OHMplanCommunicationFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? OHMplanFilename { get; set; }
			public string? OHMplanCommunicationFilename { get; set; }
			public string? SMSFileUploadname { get; set; }
		}

		public class HSE_WASTE_MANAGEMENT_SYSTEM_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? WasteManagementPlanFilePath { get; set; }
			public string? DecomCertificateFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? WasteManagementPlanFilename { get; set; }
			public string? DecomCertificateFilename { get; set; }
		}

		public class HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? EMSFilePath { get; set; }
			public string? AUDITFilePath { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
			public string? EMSFilename { get; set; }
			public string? AUDITFilename { get; set; }
		}

		public class PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT_Model
		{
			public string? OML_ID { get; set; }
			public string? OML_Name { get; set; }
			public string? Year_of_WP { get; set; }
			public string? uploaded_presentation { get; set; }
			public string? Consession_Type { get; set; }
			public string? Terrain { get; set; }
			public string? Contract_Type { get; set; }
		}

		#endregion
		#endregion
		public class UploadedDocument
		{
			public string filePath { get; set; }
			public string fileName { get; set; }
		}
		public class UserMasterModel
		{
			public int UserId { get; set; }
			public string? UserEmail { get; set; }
			public string? UserType { get; set; }
			public string? FirstName { get; set; }
			public string? LastName { get; set; }
			public string? UserRole { get; set; }
			public string? Status { get; set; }
			public int? LoginCount { get; set; }
			public string? PasswordHash { get; set; }
			public string? PhoneNumber { get; set; }
			public string? CompanyName { get; set; }
			public int? DivisionId { get; set; }
			public string? Comment { get; set; }

		}


		public class CompanyCodeModel
		{

			public int Id { get; set; }
			public string CompanyCode { get; set; }
			public string CompanyName { get; set; }
			public string IsActive { get; set; }
			public string Created_by { get; set; }
			public DateTime Date_Created { get; set; }
			//public string? Updated_by { get; set; }
			//public DateTime? Date_Updated { get; set; }

		}

		public class PresentationSchedules_Model
		{
			public List<ADMIN_DATETIME_PRESENTATION> presentationSchedules { get; set; }
			public List<ADMIN_DIVISIONAL_REPS_PRESENTATION> Divisionpresentations { get; set; }
			public List<string> Years { get; set; }
		}
		public class AppMessage
		{
			public object Subject { get; set; }
			public object Content { get; set; }
			public object RefNo { get; set; }
			public object Year { get; set; }
			public object Concession { get; set; }
			public object Field { get; set; }
			public object Status { get; set; }
			public object Stage { get; set; }
			public object TotalAmount { get; set; }
			public object Seen { get; set; }
			public string GeneratedNo { get; set; }
			public object CompanyName { get; set; }
			public object CategoryName { get; set; }
			public object PhaseName { get; set; }
			public object FacilityName { get; set; }
			public object StatutoryLicenceFee { get; set; }
			public object ServiceCharge { get; set; }
			public object TotalAmountDue { get; set; }
			public object ApplicationPeriod { get; set; }
			public object DateSubmitted { get; set; }

		}

		public class WebApiResponse
		{
			public string ResponseCode { get; set; }
			public string UserStatus { get; set; }
			public string Message { get; set; }
			public int StatusCode { get; set; }
			public Object Data { get; set; }
		}

		public class AppResponseCodes
		{
			public const string Success = "00";
			public const string InternalError = "02";
			public const string Failed = "03";
			public const string DuplicateEmail = "04";
			public const string RecordNotFound = "05";
			public const string InvalidLogin = "06";
			public const string UserAlreadyExist = "07";
			public const string DuplicateUserDetails = "08";
			public const string InvalidAccountNo = "09";
			public const string UserNotFound = "10";
			public const string TransactionFailed = "11";
			public const string TransactionProcessed = "12";
			public const string AccountIsLocked = "13";
			public const string DuplicatePassword = "14";
			public const string OtpExpired = "15";
			public const string ExtraPaymentAlreadyExist = "16";
			public const string MissingParameter = "17";
			public const string InvalidParameterPassed = "18";
			public const string PaymentAlreadyExists = "19";
			public const string PaymentDoesNotExist = "20";
		}
		public class ResponseCodes
		{
			public const int Success = 200;
			public const int Failure = 300;
			public const int Badrequest = 400;
			public const int RecordNotFound = 404;
			public const int Duplicate = 409;
			public const int InternalError = 500;
		}
	}
}
