using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTUAL_year { get; set; }

    public string? PROPOSED_year { get; set; }

    public string? Possible_causes_ { get; set; }

    public string? Effect_on_your_operations_ { get; set; }

    public string? Cost_involved_ { get; set; }

    public string? Total_days_lost_ { get; set; }

    public string? No_of_casual_Fatality_ { get; set; }

    public string? Action_plan_for_PROPOSED_YEAR { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
