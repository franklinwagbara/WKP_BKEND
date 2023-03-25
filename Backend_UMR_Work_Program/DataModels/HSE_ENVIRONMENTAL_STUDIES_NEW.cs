using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_ENVIRONMENTAL_STUDIES_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTUAL_year { get; set; }

    public string? PROPOSED_year { get; set; }

    public string? Any_Environmental_Studies { get; set; }

    public string? If_YES_state_Project_Name { get; set; }

    public string? Status_ { get; set; }

    public string? Field_Name { get; set; }

    public string? NUPRC_Approval_Status { get; set; }

    public string? If_Ongoing { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? Consession_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
