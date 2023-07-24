using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Have_you_submitted_all_MoUs_to_DPR { get; set; }

    public string? If_NO_why { get; set; }

    public string? Do_you_have_an_MOU_with_the_communities_for_all_your_assets { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? Contract_Type { get; set; }

    public string? MOUResponderFilePath { get; set; }

    public string? MOUOSCPFilePath { get; set; }

    public string? MOUResponderFilename { get; set; }

    public string? MOUOSCPFilename { get; set; }

    public string? MOUResponderInPlace { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
