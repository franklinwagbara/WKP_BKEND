using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class INITIAL_WELL_COMPLETION_JOB1
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Do_you_have_approval_to_complete_the_well { get; set; }

    public string? Current_year_Actual_Number { get; set; }

    public string? Current_year_Budget_Allocation { get; set; }

    public string? Proposed_year_data { get; set; }

    public string? Processing_Fees_paid { get; set; }

    public string? Remarks { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Budeget_Allocation_NGN { get; set; }

    public string? Budeget_Allocation_USD { get; set; }

    public string? Consession_Type { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? QUATER { get; set; }

    public string? oil_or_gas_wells { get; set; }

    public DateTime? Actual_Completion_Date { get; set; }

    public DateTime? Proposed_Completion_Date { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? Proposed_Completion_Days { get; set; }

    public string? Proposed_Initial_Name { get; set; }

    public int Proposed_Well_Number { get; set; }
}
