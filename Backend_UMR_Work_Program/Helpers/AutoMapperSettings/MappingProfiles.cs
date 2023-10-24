
using Backend_UMR_Work_Program.Models;
using AutoMapper;
using static Backend_UMR_Work_Program.Models.GeneralModel;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.DTOs;
using WKP.Contracts.Fee;
using WKP.Application.Fee.Commands;
using WKP.Contracts.Application;
using WKP.Application.Application.Queries.GetDashboardData;
using WKP.Application.Application.Commands.OpenApplication;
using WKP.Application.Application.Commands.PushApplicationCommand;
using WKP.Application.Fee.Queries.GetOtherFees;
using WKP.Contracts.Features.Application;
using WKP.Application.Features.Application.Queries.GetAllApplications;
using WKP.Application.Features.Application.Queries.GetAllApplicationsCompany;
using WKP.Application.Features.Application.Queries.GetReturnedApplications;
using WKP.Application.Features.Application.Commands.SubmitApplication;
using WKP.Application.Features.Application.Commands.ReturnAppToStaff;
using WKP.Contracts.Features.Accounting;
using WKP.Application.Features.Accounting.Queries;
using WKP.Application.Features.Accounting.Queries.GetAllUSDPaymentApprovals;
using WKP.Application.Features.Application.Commands.SendBackApplicationToCompany;
using WKP.Application.Features.Application.Queries.GetAllAppsScopedToSBU;
using WKP.Application.Features.Application.Commands.ApproveApplication;
using WKP.Application.Features.Application.Queries.GetStaffsAppInfoWithSBURoleId;
using WKP.Application.Features.Application.Queries.GetStaffDesksByStaffID;
using WKP.Application.Features.Application.Commands.MoveApplication;
using WKP.Application.Features.Application.Commands.RejectApplication;
using WKP.Application.Features.Application.Queries.GetAllApprovals;
using WKP.Application.Features.Application.Queries.GetAllRejections;

namespace Backend_UMR_Work_Program.Helpers.AutoMapperSettings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddFeeRequest, AddFeeCommand>().ReverseMap();
            CreateMap<GetDashboardDataRequest, GetDashboardDataQuery>()
            .ForMember(x => x.CompanyNumber, opt => opt.MapFrom(src => src.CompanyNumber))
            .ReverseMap();
            CreateMap<OpenApplicationRequest, OpenApplicationCommand>()
            .ForMember(x => x.DeskId, opt => opt.MapFrom(src => src.DeskId))
            .ReverseMap();
            CreateMap<PushApplicationRequest, PushApplicationCommand>().ReverseMap();
            CreateMap<GetAllApplicationsRequest, GetAllApplicationsQuery>().ReverseMap();
            CreateMap<GetAllApplicationsCompanyRequest, GetAllApplicationsCompanyQuery>();
            CreateMap<GetReturnedApplicationsRequest, GetReturnedApplicationsQuery>();
            CreateMap<SubmitApplicationRequest, SubmitApplicationCommand>();
            CreateMap<ReturnAppToStaffRequest, ReturnAppToStaffCommand>();
            CreateMap<GetAppPaymentsOnMyDeskRequest, GetAppPaymentsOnMyDeskQuery>();
            CreateMap<GetAllAppPaymentsRequest, GetAllAppPaymentsQuery>();
            CreateMap<GetAllUSDPaymentApprovalsRequest, GetAllUSDPaymentApprovalsQuery>();
            CreateMap<SendBackApplicationToCompanyRequest, SendBackApplicationToCompanyCommand>();
            CreateMap<GetAllAppsScopedToSBURequest, GetAllAppsScopedToSBUQuery>();
            CreateMap<ApproveApplicationRequest, ApproveApplicationCommand>();
            CreateMap<GetStaffsAppInfoWithSBURoleIdRequest, GetStaffsAppInfoWithSBURoleIdQuery>();
            CreateMap<GetStaffDesksByStaffIDRequest, GetStaffDesksByStaffIDQuery>();
            CreateMap<MoveApplicationRequest, MoveApplicationCommand>();
            CreateMap<RejectApplicationRequest, RejectApplicationCommand>();
            CreateMap<GetAllApprovalsRequest, GetAllApprovalsQuery>();
            CreateMap<GetAllRejectionsRequest, GetAllRejectionsQuery>();

            CreateMap<Fee, FeeDTO>().ReverseMap();
            CreateMap<FeeDTO, Fee>().ReverseMap();
            CreateMap<GetOtherFeesRequest, GetOtherFeesQuery>().ReverseMap();

            CreateMap<UserMaster, UserMasterModel>().ReverseMap();
            CreateMap<CONCESSION_SITUATION, CONCESSION_SITUATION_Model>().ReverseMap();
            CreateMap<GEOPHYSICAL_ACTIVITIES_ACQUISITION, GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model>().ReverseMap();
            CreateMap<GEOPHYSICAL_ACTIVITIES_PROCESSING, GEOPHYSICAL_ACTIVITIES_PROCESSING_Model>().ReverseMap();
            CreateMap<DRILLING_OPERATIONS_CATEGORIES_OF_WELL, DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model>().ReverseMap();
            CreateMap<DRILLING_EACH_WELL_COST, DRILLING_EACH_WELL_COST_Model>().ReverseMap();
            CreateMap<DRILLING_EACH_WELL_COST_PROPOSED, DRILLING_EACH_WELL_COST_PROPOSED_Model>().ReverseMap();
            CreateMap<INITIAL_WELL_COMPLETION_JOB1, INITIAL_WELL_COMPLETION_JOB1_Model>().ReverseMap();
            CreateMap<WORKOVERS_RECOMPLETION_JOB1, WORKOVERS_RECOMPLETION_JOB1_Model>().ReverseMap();
            CreateMap<FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf, FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf_Model>().ReverseMap();
            CreateMap<FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP, FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP_Model>().ReverseMap();
            CreateMap<FIELD_DEVELOPMENT_FIELDS_AND_STATUS, FIELD_DEVELOPMENT_FIELDS_AND_STATUS_Model>().ReverseMap();
            CreateMap<RESERVES_UPDATES_LIFE_INDEX, RESERVES_UPDATES_LIFE_INDEX_Model>().ReverseMap();
            CreateMap<FIELD_DEVELOPMENT_PLAN, FIELD_DEVELOPMENT_PLAN_Model>().ReverseMap();
            CreateMap<OIL_CONDENSATE_PRODUCTION_ACTIVITy, OIL_CONDENSATE_PRODUCTION_ACTIVITy_Model>().ReverseMap();
            CreateMap<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION, OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION_Model>().ReverseMap();
            CreateMap<GAS_PRODUCTION_ACTIVITy, GAS_PRODUCTION_ACTIVITy_Model>().ReverseMap();
            CreateMap<NDR, NDR_Model>().ReverseMap();
            CreateMap<RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE, RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_Model>().ReverseMap();
            CreateMap<RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection, RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection_Model>().ReverseMap();
            CreateMap<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION, OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION_Model>().ReverseMap();
            CreateMap<RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION, RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION_Model>().ReverseMap();
            CreateMap<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE, RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE_Model>().ReverseMap();
            CreateMap<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition, RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition_Model>().ReverseMap();
            CreateMap<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity, OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity_Model>().ReverseMap();
            CreateMap<RESERVES_REPLACEMENT_RATIO, RESERVES_REPLACEMENT_RATIO_Model>().ReverseMap();
            CreateMap<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity, OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED_Model>().ReverseMap();
            CreateMap<GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY, GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY_Model>().ReverseMap();
            CreateMap<CONCESSION_SITUATION, CONCESSION_SITUATION_Model>().ReverseMap();
            CreateMap<GEOPHYSICAL_ACTIVITIES_ACQUISITION, GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model>().ReverseMap();
            CreateMap<GEOPHYSICAL_ACTIVITIES_PROCESSING, GEOPHYSICAL_ACTIVITIES_PROCESSING_Model>().ReverseMap();
            CreateMap<DRILLING_OPERATIONS_CATEGORIES_OF_WELL, DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model>().ReverseMap();
            CreateMap<DRILLING_EACH_WELL_COST, DRILLING_EACH_WELL_COST_Model>().ReverseMap();
            CreateMap<DRILLING_EACH_WELL_COST_PROPOSED, DRILLING_EACH_WELL_COST_PROPOSED_Model>().ReverseMap();
            CreateMap<NIGERIA_CONTENT_Training, NIGERIA_CONTENT_Training_Model>().ReverseMap();
            CreateMap<NIGERIA_CONTENT_Upload_Succession_Plan, NIGERIA_CONTENT_Upload_Succession_Plan_Model>().ReverseMap();
            CreateMap<NIGERIA_CONTENT_QUESTION, NIGERIA_CONTENT_QUESTION_Model>().ReverseMap();
            CreateMap<LEGAL_LITIGATION, LEGAL_LITIGATION_Model>().ReverseMap();
            CreateMap<LEGAL_ARBITRATION, LEGAL_ARBITRATION_Model>().ReverseMap();
            CreateMap<STRATEGIC_PLANS_ON_COMPANY_BASI, STRATEGIC_PLANS_ON_COMPANY_BASI_Model>().ReverseMap();
            CreateMap<HSE_QUESTION, HSE_QUESTION_Model>().ReverseMap();
            CreateMap<HSE_FATALITy, HSE_FATALITy_Model>().ReverseMap();
            CreateMap<HSE_DESIGNS_SAFETY, HSE_DESIGNS_SAFETY_Model>().ReverseMap();
            CreateMap<HSE_SAFETY_STUDIES_NEW, HSE_SAFETY_STUDIES_NEW_Model>().ReverseMap();
            CreateMap<HSE_INSPECTION_AND_MAINTENANCE_NEW, HSE_INSPECTION_AND_MAINTENANCE_NEW_Model>().ReverseMap();
            CreateMap<HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW, HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW_Model>().ReverseMap();
            CreateMap<HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW, HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW_Model>().ReverseMap();
            CreateMap<HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW, HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW_Model>().ReverseMap();
            CreateMap<HSE_OIL_SPILL_REPORTING_NEW, HSE_OIL_SPILL_REPORTING_NEW_Model>().ReverseMap();
            CreateMap<HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW, HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW_Model>().ReverseMap();
            CreateMap<HSE_ACCIDENT_INCIDENCE_REPORTING_NEW, HSE_ACCIDENT_INCIDENCE_REPORTING_NEW_Model>().ReverseMap();
            CreateMap<HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW, HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_Model>().ReverseMap();
            CreateMap<HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW, HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW_Model>().ReverseMap();
            CreateMap<HSE_ENVIRONMENTAL_STUDIES_NEW, HSE_ENVIRONMENTAL_STUDIES_NEW_Model>().ReverseMap();
            CreateMap<HSE_WASTE_MANAGEMENT_NEW, HSE_WASTE_MANAGEMENT_NEW_Model>().ReverseMap();
            CreateMap<HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW, HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW_Model>().ReverseMap();
            CreateMap<HSE_PRODUCED_WATER_MANAGEMENT_NEW, HSE_PRODUCED_WATER_MANAGEMENT_NEW_Model>().ReverseMap();
            CreateMap<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW, HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW_Model>().ReverseMap();
            CreateMap<HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW, HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW_Model>().ReverseMap();
            CreateMap<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL, HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL_Model>().ReverseMap();
            CreateMap<HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED, HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED_Model>().ReverseMap();
            CreateMap<HSE_OSP_REGISTRATIONS_NEW, HSE_OSP_REGISTRATIONS_NEW_Model>().ReverseMap();
            CreateMap<HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED, HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED_Model>().ReverseMap();
            CreateMap<HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW, HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW_Model>().ReverseMap();
            CreateMap<HSE_CAUSES_OF_SPILL, HSE_CAUSES_OF_SPILL_Model>().ReverseMap();
            CreateMap<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU, HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU_Model>().ReverseMap();
            CreateMap<HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME, HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME_Model>().ReverseMap();
            CreateMap<HSE_MANAGEMENT_POSITION, HSE_MANAGEMENT_POSITION_Model>().ReverseMap();
            CreateMap<HSE_QUALITY_CONTROL, HSE_QUALITY_CONTROL_Model>().ReverseMap();
            CreateMap<HSE_CLIMATE_CHANGE_AND_AIR_QUALITY, HSE_CLIMATE_CHANGE_AND_AIR_QUALITY_Model>().ReverseMap();
            CreateMap<HSE_SAFETY_CULTURE_TRAINING, HSE_SAFETY_CULTURE_TRAINING_Model>().ReverseMap();
            CreateMap<HSE_OCCUPATIONAL_HEALTH_MANAGEMENT, HSE_OCCUPATIONAL_HEALTH_MANAGEMENT_Model>().ReverseMap();
            CreateMap<HSE_WASTE_MANAGEMENT_SYSTEM, HSE_WASTE_MANAGEMENT_SYSTEM_Model>().ReverseMap();
            CreateMap<HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM, HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM_Model>().ReverseMap();
            CreateMap<PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT, PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECT_Model>().ReverseMap();
            CreateMap<ADMIN_COMPANY_INFORMATION, ADMIN_COMPANY_INFORMATION_Model>().ReverseMap();
            CreateMap<ADMIN_CONCESSIONS_INFORMATION_Model, ADMIN_CONCESSIONS_INFORMATION>().ReverseMap();
            CreateMap<ADMIN_COMPANY_CODE, CompanyCodeModel>().ReverseMap();

        }
    }
}

