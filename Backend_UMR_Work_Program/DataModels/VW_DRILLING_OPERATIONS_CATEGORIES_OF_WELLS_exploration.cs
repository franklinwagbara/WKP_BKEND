using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_exploration
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Category { get; set; }

    public string? Actual_No_Drilled_in_Current_Year { get; set; }

    public string? Proposed_No_Drilled { get; set; }

    public string? Processing_Fees_Paid { get; set; }

    public string? Comments { get; set; }

    public string? No_of_wells_cored { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }
}
