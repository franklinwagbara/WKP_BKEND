using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class GAS_PRODUCTION_ACTIVITy
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

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

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

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

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? AnnualForecastCondensate { get; set; }

    public string? AnnualForecastGasAg { get; set; }

    public string? AnnualForecastGasNag { get; set; }

    public string? AnnualForecastOil { get; set; }

    [NotMapped]
    public string? ConcessionName;
    [NotMapped]
    public string FieldName => Field?.Field_Name;
    [NotMapped]
    public string? ConcessionType;

    [NotMapped]
    public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }

    [ForeignKey(nameof(Field_ID))]
    public COMPANY_FIELD? Field { get; set; }
}
