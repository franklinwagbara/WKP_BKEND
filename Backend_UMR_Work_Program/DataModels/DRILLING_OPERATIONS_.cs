using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class DRILLING_OPERATIONS_
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Well_Name { get; set; }

    public string? Current_year_Actual_Status_data { get; set; }

    public string? Current_year_Actual_Net_Oil_Gas_sand_data { get; set; }

    public string? Proposed_year_data { get; set; }

    public string? Proposed_Budget_Allocation { get; set; }

    public string? Remarks { get; set; }

    public string? Do_you_have_approval_to_drill { get; set; }

    public string? Give_reasons { get; set; }

    public string? Category { get; set; }

    public string? Actual_No_Drilled_in_Current_Year { get; set; }

    public string? Proposed_No_Drilled { get; set; }

    public string? Processing_Fees_Paid { get; set; }

    public string? Comments { get; set; }

    public string? No_of_wells_cored { get; set; }

    public string? State_the_field_where_Discovery_was_made { get; set; }

    public string? Any_New_Discoveries { get; set; }

    public string? Hydrocarbon_Counts { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Budeget_Allocation_NGN { get; set; }

    public string? Budeget_Allocation_USD { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
