using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

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

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? Consession_Type { get; set; }

    public string? Oil_spill_reported { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
