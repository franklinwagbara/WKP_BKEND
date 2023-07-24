-- drop current primary key constraint
-- ALTER TABLE dbo.persion 
-- DROP CONSTRAINT PK_persionId;
-- GO

-- -- add new auto incremented field
-- ALTER TABLE dbo.persion 
-- ADD pmid BIGINT IDENTITY;
-- GO

-- -- create new primary key constraint
-- ALTER TABLE dbo.persion 
-- ADD CONSTRAINT PK_persionId PRIMARY KEY NONCLUSTERED (pmid, persionId);
-- GO

                  -- ADD a column on all tables
--SELECT 'ALTER TABLE ' + QUOTENAME(ss.name) + '.' + QUOTENAME(st.name) + ' ADD [DateTime_Table] DATETIME NULL;'
--FROM sys.tables st
--INNER JOIN sys.schemas ss on st.[schema_id] = ss.[schema_id]
--WHERE st.is_ms_shipped = 0
--AND NOT EXISTS (
--    SELECT 1
--    FROM sys.columns sc
--    WHERE sc.[object_id] = st.[object_id]
--    AND sc.name = 'DateTime_Table'
--);

USE [WorkProgrammeDB_]
GO

-- EXEC sp_rename '[dbo].[ADMIN_CONCESSIONS_INFORMATION].[Consession_Id]' , 'Id', 'COLUMN';
-- GO

ALTER TABLE [dbo].[ADMIN_COMPANY_CODE]
ADD CONSTRAINT PK_companycodeid PRIMARY KEY NONCLUSTERED (id);
GO

ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION]
ADD CONSTRAINT PK_consessioninfoid PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[CONCESSIONS_SITUATION]
ADD Field_Name VARCHAR(500) NULL;
GO

ALTER TABLE [dbo].[CONCESSIONS_SITUATION]
ADD AdminConcession_ID int NULL;
GO

ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION]
ADD Field_Name VARCHAR(500) NULL;
GO

ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION]
ADD CONSTRAINT PK_consessioninfoid PRIMARY KEY NONCLUSTERED (Id);
GO

------New------
ALTER TABLE [dbo].[LEGAL_LITIGATION]
ADD CONSTRAINT PK_LEGAL_LITIGATION_Id PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[LEGAL_ARBITRATION]
ADD CONSTRAINT PK_LEGAL_ARBITRATION_Id PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[RESERVES_UPDATES_LIFE_INDEX]
ADD CONSTRAINT PK_RESERVES_UPDATES_LIFE_INDEX_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES]
ADD CONSTRAINT PK_FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[RESERVES_UPDATES_DEPLETION_RATE]
ADD CONSTRAINT PK_RESERVES_UPDATES_DEPLETION_RATE_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[LEGAL_LITIGATION]
ADD CONSTRAINT PK_LEGAL_LITIGATION_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[LEGAL_ARBITRATION]
ADD CONSTRAINT PK_LEGAL_ARBITRATION_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[HSE_SAFETY_CULTURE_TRAINING]
ADD CONSTRAINT PK_HSE_SAFETY_CULTURE_TRAINING_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[HSE_CLIMATE_CHANGE_AND_AIR_QUALITY]
ADD CONSTRAINT PK_HSE_CLIMATE_CHANGE_AND_AIR_QUALITY_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[HSE_WASTE_MANAGEMENT_SYSTEM]
ADD CONSTRAINT PK_HSE_WASTE_MANAGEMENT_SYSTEM_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU]
ADD CONSTRAINT PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME]
ADD CONSTRAINT PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME_ID PRIMARY KEY NONCLUSTERED (Id);
GO

ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WELL_CATEGORIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WELL_Trajectory] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WELL_TYPE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WORK_PROGRAM_REPORT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NDPR_SUBSCRIPTION_FEE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WORK_PROGRAM_REPORT_History] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WP_PENALTIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ACCIDENT_INCIDENCE_REPORTING_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WP_PENALTIES_AUDIT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WP_START_END_DATE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_WASTE_MANAGEMENT_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_DATETIME_PRESENTATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WP_START_END_DATE_AUDIT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_COMPLIANCE_INDEX_TABLE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_WASTE_MANAGEMENT_SYSTEM] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WP_START_END_DATE_DATA_UPLOAD] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Initial_Well_Completion_Job] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Legal] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_YEAR] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LEGAL_ARBITRATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_YES_NO] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ActualExpenditure] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LEGAL_LITIGATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Appraisal_Drilling] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ActualProposed_Year] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_ACTUAL_EXPENDITURE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_BUDGET_CAPEX_OPEX] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[LocalContent] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CATEGORIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Menu] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_PERFORMANCE_PRODUCTION_COST] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CHAIRPERSON] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_CAPEX_OPEX] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NDR] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_COMPANY_CODE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NDR_Data_Population] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_COMPANY_DETAILS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[DRILLING_OPERATIONS_] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[BudgetProposal] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NDR_DATA_POPULATION_ON_BLOCK_BASIS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_COMPANY_INFORMATION_AUDIT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Class_Table] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NIGERIA_CONTENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_COMPANY_INFORMATION_old_18052020] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[GAS_PRODUCTION_ACTIVITIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[CompletionJobs] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NIGERIA_CONTENT_Training] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CONCESSION_STATUS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ConcessionSituation] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NIGERIA_CONTENT_Upload_Succession_Plan] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION_AUDIT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ConcessionSituationTwo] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NigerianContent] ADD [CompanyNumber] int NULL;
--- ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION_BK_23112021] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Contract_Type] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_AND_GAS_FACILITY_MAINTENANCE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION_HISTORY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[CSR] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[FACILITIES_PROJECT_PERFORMANCE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION_old_18052020] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_OIL_SPILL_REPORTING_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Data_Type] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_DEVELOPMENT_PLAN_STATUS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[DevelopmentDrilling] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_DIVISION_REP] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Divisions] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_DIVISION_REP_LIST] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PERFOMANCE_INDEX] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_DIVISIONAL_REPRESENTATIVE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[DRILLING_EACH_WELL_COST] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[DRILLING_EACH_WELL_COST_PROPOSED] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_DIVISIONAL_REPS_PRESENTATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Drilling_Operations] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_EMAIL_DAYS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Exploration_Drilling] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ENVIROMENTAL_STUDIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OilCondensateProduction] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_CAUSES_OF_SPILL] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[FacilityConstruction] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_MMBBL] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OilSpill_Incident] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[FIELD_DEVELOPMENT_FIELDS_AND_STATUS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_COMPANY_INFORMATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[FIELD_DEVELOPMENT_PLAN] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ENVIRONMENTAL_STUDY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[PRESENTATION_UPLOAD] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[GEOPHYSICAL_ACTIVITIES_PROCESSING] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI ] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Reserve_Update_Oil_Condensate] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Functionality] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[GEOPHYSICAL_ACTIVITIES_ACQUISITION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_FEILDDEVELOPMENTPLAN_WELLORGAS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_DEPLETION_RATE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_FIVE_YEAR_TREND] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_LIFE_INDEX] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Gas_Production_Activity] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_GASPRODUCTION_UTILIZED_MMSCF] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Gas_Reserve_Update] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_HSE_CONDITION_OF_EQUIPMENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Table_1] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[GeographicalActivity] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_HSE_OSP REGISTRATIONS_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Geophysical_Activities] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_HSE_OSP_REGISTRATIONS_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[NIGERIA_CONTENT_QUESTION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_INSPECTION_MAINTENANCE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_LIST_OF_OMLS_OPLS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[INITIAL_WELL_COMPLETION_JOBS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_LITIGATION_JURISDICTION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[DRILLING_OPERATIONS_CATEGORIES_OF_WELLS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[Role] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_MEETING_ROOM] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_CLIMATE_CHANGE_AND_AIR_QUALITY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RoleFunctionalityRef] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_MONTHS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[WORKOVERS_RECOMPLETION_JOBS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ROLES_] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ROLES_SUPER_ADMIN] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[SafetyManagement] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_DESIGNS_SAFETY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_ONGOING_COMPLETED] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PRESENTATION_CATEGORIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[STRATEGIC_PLANS_ON_COMPANY_BASIS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PRESENTATION_TIME] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[SubstainableDevelopment] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[tbl_fruitanalysis] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[TrainingForStaff] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[UserLogin] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_FATALITIES] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[UserMaster] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[WORK_PROGRAM_FLOW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_STUDIES_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_PUBLIC_HOLIDAY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[WorkOverJobs] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_QUARTER] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[WorkOvers_Recompletion_Job] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_REASON_FOR_ADDITION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[CONCESSION_SITUATION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[WorkOvers_Recompletion_Job_Field_Dvelopment_Plans] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_INSPECTION_AND_MAINTENANCE_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_REASON_FOR_DECLINE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_MANAGEMENT_POSITION] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_SCHEDULED_STATUS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_OCCUPATIONAL_HEALTH_MANAGEMENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_OIL_SPILL_INCIDENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_SCRIBE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_OSP_REGISTRATIONS_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASIS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_PRODUCED_WATER_MANAGEMENT_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_SUBMISSION_WINDOW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_Terrain] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_QUALITY_CONTROL] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_TRAINING_LOCAL_CONTENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_QUESTIONS] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_TRAINING_NIGERIA_CONTENT] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SAFETY_CULTURE_TRAINING] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SAFETY_STUDIES_NEW] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_TYPE_OF_TEST] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[ADMIN_WASTE_MANAGEMENT_FACILITY] ADD [CompanyNumber] int NULL;
ALTER TABLE [dbo].[RESERVES_REPLACEMENT_RATIO] ADD [CompanyNumber] int NULL;


ALTER TABLE FIELD_DEVELOPMENT_PLAN ADD Status varchar(50)
ALTER TABLE [dbo].[HSE_QUALITY_CONTROL] ADD [Valid_Accreditation_Letter_For_QualityControl] varchar(max) NULL;

ALTER TABLE dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION ADD
	No_of_Folds int NULL


CREATE TABLE [dbo].[HSE_EFFLUENT_MONITORING_COMPLIANCE](
	[Id] [int] NOT NULL,
	[Field_ID] [int] NULL,
	[OML_Name] [varchar](200) NULL,
	[OmL_ID] [varchar](100) NULL,
	[CompanyName] [varchar](300) NULL,
	[Companyemail] [varchar](100) NULL,
	[Year_of_WP] [varchar](10) NULL,
	[COMPANY_ID] [varchar](50) NULL,
	[CompanyNumber] [varchar](50) NULL,
	[AreThereEvidentOfSampling] [varchar](10) NULL,
	[EvidenceOfSamplingFilename] [varchar](1000) NULL,
	[EvidenceOfSamplingPath] [varchar](5000) NULL,
	[ReasonForNoEvidenceSampling] [varchar](1000) NULL,
	[Date_Updated] [datetime] NULL,
	[Updated_by] [varchar](1000) NULL,
	[Date_Created] [datetime] NULL,
	[Created_by] [varchar](1000) NULL,
 CONSTRAINT [PK_HSE_EFFLUENT_MONITORING_COMPLIANCE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_MANAGEMENT_PLAN](
	[Id] [int] NOT NULL,
	[Field_ID] [int] NULL,
	[OML_Name] [varchar](1000) NULL,
	[OmL_ID] [varchar](100) NULL,
	[CompanyName] [varchar](200) NULL,
	[Companyemail] [varchar](100) NULL,
	[Year_of_WP] [varchar](30) NULL,
	[COMPANY_ID] [varchar](30) NULL,
	[CompanyNumber] [int] NULL,
	[AreThereEMP] [varchar](10) NULL,
	[FacilityType] [varchar](100) NULL,
	[FacilityLocation] [varchar](200) NULL,
	[RemarkIfNoEMP] [varchar](500) NULL,
	[Date_Updated] [datetime] NULL,
	[Updated_by] [varchar](100) NULL,
	[Date_Created] [datetime] NULL,
	[Created_by] [varchar](100) NULL,
 CONSTRAINT [PK_HSE_ENVIRONMENTAL_MANAGEMENT_PLAN] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[HSE_GHG_MANAGEMENT_PLAN](
	[Id] [int] NULL,
	[OmL_Name] [varchar](100) NULL,
	[OmL_ID] [varchar](100) NULL,
	[CompanyName] [varchar](1000) NULL,
	[companyemail] [varchar](100) NULL,
	[Year_of_WP] [varchar](50) NULL,
	[CompanY_ID] [varchar](50) NULL,
	[CompanyNumber] [int] NULL,
	[DoYouHaveGHG] [varchar](10) NULL,
	[GHGApprovalFilename] [varchar](1000) NULL,
	[GHGApprovalPath] [varchar](5000) NULL,
	[ReasonForNoGHG] [varchar](5000) NULL,
	[DoYouHaveLDRCertificate] [varchar](10) NULL,
	[LDRCertificateFilename] [varchar](1000) NULL,
	[LDRCertificatePath] [varchar](5000) NULL,
	[ReasonForNoLDR] [varchar](3000) NULL,
	[Date_Updated] [datetime] NULL,
	[Updated_by] [varchar](100) NULL,
	[Date_Created] [datetime] NULL,
	[Created_by] [varchar](100) NULL
) ON [PRIMARY]


CREATE TABLE [dbo].[HSE_HOST_COMMUNITIES_DEVELOPMENT](
	[DoYouHaveEvidenceOfReg] [varchar](10) NULL,
	[EvidenceOfRegTrustFundFilename] [varchar](2000) NULL,
	[EvidenceOfRegTrustFundPath] [varchar](5000) NULL,
	[ReasonForNoEvidenceOfRegTF] [varchar](2000) NULL,
	[DoYouHaveEvidenceOfPay] [varchar](10) NULL,
	[EvidenceOfPayTrustFundFilename] [varchar](1000) NULL,
	[EvidenceOfPayTrustFundPath] [varchar](3000) NULL,
	[ReasonForNoEvidenceOfPayTF] [varchar](2000) NULL,
	[UploadCommDevPlanApprovalFilename] [varchar](1000) NULL,
	[UploadCommDevPlanApprovalPath] [varchar](3000) NULL,
	[Date_Updated] [datetime] NULL,
	[Updated_by] [varchar](50) NULL,
	[Date_Created] [datetime] NULL,
	[Created_by] [varchar](50) NULL,
	[Id] [int] NOT NULL,
	[Field_ID] [int] NULL,
	[OML_Name] [varchar](1000) NULL,
	[OmL_ID] [varchar](1000) NULL,
	[CompanyName] [varchar](200) NULL,
	[Companyemail] [varchar](100) NULL,
	[Year_of_WP] [varchar](30) NULL,
	[COMPANY_ID] [varchar](50) NULL,
	[CompanyNumber] [varchar](50) NULL,
 CONSTRAINT [PK_HSE_HOST_COMMUNITIES_DEVELOPMENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.HSE_ACCIDENT_INCIDENCE_REPORTING_NEW ADD
	UploadIncidentStatisticsFilename varchar(1000) NULL,
	UploadIncidentStatisticsPath varchar(3000) NULL


ALTER TABLE dbo.HSE_OCCUPATIONAL_HEALTH_MANAGEMENT ADD
	ReasonWhyOhmWasNotCommunicatedToStaffPath varchar(3000) NULL,
	ReasonWhyOhmWasNotCommunicatedToStaffFileName varchar(1000) NULL,
	WasOhmPolicyCommunicatedToStaff varchar(10) NULL,
	ReasonForNoOhm varchar(1000) NULL,
	DoYouHaveAnOhm varchar(10) NULL

CREATE TABLE [dbo].[HSE_OPERATIONS_SAFETY_CASE](
	[Id] [int] NULL,
	[OML_ID] [varchar](50) NULL,
	[OML_Name] [varchar](500) NULL,
	[CompanyName] [varchar](500) NULL,
	[Companyemail] [varchar](500) NULL,
	[Year_of_WP] [varchar](30) NULL,
	[Reason_If_No_Evidence] [varchar](2000) NULL,
	[Evidence_of_Operations_Safety_Case_Approval] [varchar](3000) NULL,
	[Does_the_Facility_Have_a_Valid_Safety_Case] [varchar](10) NULL,
	[Type_of_Facility] [varchar](100) NULL,
	[Location_of_Facility] [varchar](1000) NULL,
	[Name_Of_Facility] [varchar](1000) NULL,
	[Number_of_Facilities] [varchar](10) NULL,
	[Date_Created] [datetime] NULL,
	[Created_by] [varchar](100) NULL,
	[Updated_by] [varchar](100) NULL,
	[Date_Updated] [datetime] NULL,
	[COMPANY_ID] [varchar](1000) NULL,
	[CompanyNumber] [int] NULL,
	[Field_ID] [int] NULL
) ON [PRIMARY]

ALTER TABLE dbo.HSE_SAFETY_CULTURE_TRAINING ADD
	AreThereTrainingPlansForHSE varchar(10) NULL,
	EvidenceOfTrainingPlanFilename varchar(100) NULL,
	EvidenceOfTrainingPlanPath varchar(3000) NULL


	ALTER TABLE dbo.HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW ADD
	Type_Of_Facility varchar(100) NULL,
	Number_of_Facilities varchar(100) NULL
GO

ALTER TABLE dbo.HSE_SAFETY_CULTURE_TRAINING ADD
	AreThereTrainingPlansForHSE varchar(10) NULL,
	EvidenceOfTrainingPlanFilename varchar(100) NULL,
	EvidenceOfTrainingPlanPath varchar(3000) NULL


ALTER TABLE dbo.INITIAL_WELL_COMPLETION_JOBS ADD
	Proposed_Initial_Name varchar(100) NULL,
	Proposed_Completion_Days varchar(100) NULL

ALTER TABLE dbo.WORKOVERS_RECOMPLETION_JOBS ADD
	CompletionWellName varchar(500) NULL,
	Proposed_Workover_Date datetime NULL

ALTER TABLE dbo.GAS_PRODUCTION_ACTIVITIES ADD
	AnnualForecastOil varchar(1000) NULL,
	AnnualForecastCondensate varchar(1000) NULL,
	AnnualForecastGasAg varchar(1000) NULL,
	AnnualForecastGasNag varchar(1000) NULL

	ALTER TABLE dbo.HSE_SAFETY_CULTURE_TRAINING ADD
	Remark varchar(600) NULL


ALTER TABLE dbo.ADMIN_COMPANY_DETAILS ADD
	CompanyId varchar(50) NULL


ALTER TABLE dbo.Royalty ADD
	Last_Qntr_Royalty varchar(1000) NULL
ALTER TABLE dbo.NIGERIA_CONTENT_Upload_Succession_Plan ADD
	[Year] varchar(1000) NULL

	CREATE TABLE [dbo].[BUDGET_CAPEX](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OmL_Name] [varchar](1000) NULL,
	[OmL_ID] [varchar](400) NULL,
	[CompanyName] [varchar](2000) NULL,
	[Companyemail] [varchar](200) NULL,
	[Year_of_WP] [varchar](300) NULL,
	[Company_ID] [varchar](200) NULL,
	[CompanyNumber] [int] NULL,
	[Acquisition] [varchar](3000) NULL,
	[Processing] [varchar](3000) NULL,
	[Reprocessing] [varchar](2000) NULL,
	[Exploratory_Well_Drilling] [varchar](1000) NULL,
	[Appraisal_Well_Drilling] [varchar](1000) NULL,
	[Development_Well_Drilling] [varchar](1000) NULL,
	[Workover_Operations] [varchar](1000) NULL,
	[Completions] [varchar](1000) NULL,
	[Flowlines] [varchar](1000) NULL,
	[Pipelines] [varchar](1000) NULL,
	[Generators] [varchar](1000) NULL,
	[Turbines_Compressors] [varchar](1000) NULL,
	[Buildings] [varchar](1000) NULL,
	[Other_Equipment] [varchar](1000) NULL,
	[Civil_Works] [varchar](1000) NULL,
	[Other_Costs] [varchar](1000) NULL,
	[Created_by] [varchar](3000) NULL,
	[Updated_by] [varchar](300) NULL,
	[Date_Created] [datetime] NULL,
	[Date_Updated] [datetime] NULL,
 CONSTRAINT [PK_BUDGET_CAPEX] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.GEOPHYSICAL_ACTIVITIES_PROCESSING ADD
	Type_of_Processing varchar(500) NULL


ALTER TABLE dbo.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE ADD
	Year varchar(100) NULL

CREATE TABLE [dbo].[BUDGET_OPEX](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OmL_Name] [varchar](1000) NULL,
	[OmL_ID] [varchar](1000) NULL,
	[CompanyName] [varchar](1000) NULL,
	[Companyemail] [varchar](1000) NULL,
	[Year_of_WP] [varchar](1000) NULL,
	[Company_ID] [varchar](1000) NULL,
	[CompanyNumber] [int] NULL,
	[Variable_Cost] [varchar](1000) NULL,
	[Fixed_Cost] [varchar](1000) NULL,
	[Overheads] [varchar](1000) NULL,
	[Repairs_and_Maintenance_Cost] [varchar](1000) NULL,
	[General_Expenses] [varchar](1000) NULL,
	[Created_by] [varchar](1000) NULL,
	[Updated_by] [varchar](1000) NULL,
	[Date_Created] [datetime] NULL,
	[Date_Updated] [datetime] NULL,
 CONSTRAINT [PK_BUDGET_OPEX] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.ApplicationProccesses ADD
	TriggeredBy nvarchar(500) NULL,
	TargetTo nvarchar(500) NULL

ALTER TABLE dbo.ApplicationProccesses ADD
	TriggeredByRole nvarchar(500) NULL,
	TargetedToRole nvarchar(500) NULL




CREATE TABLE [dbo].[FlowStages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](100) NULL,
	[SBUId] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[TargetedRole] [nvarchar](50) NULL,
	[TargetedSBU] [nvarchar](50) NULL,
	[IsArchived] [smallint] NULL,
	[TriggeredByRole] [nvarchar](50) NULL,
	[TriggeredBySBU] [nvarchar](50) NULL,
 CONSTRAINT [PK_FlowStages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE dbo.MyDesks ADD
	LastJobDate datetime NULL
