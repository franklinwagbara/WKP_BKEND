using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class NIGERIA_CONTENT_QUESTION
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Do_you_have_a_valid_Expatriate_Quota_for_your_foreign_staff { get; set; }

    public string? If_NO_why { get; set; }

    public string? Is_there_a_succession_plan_in_place { get; set; }

    public string? Number_of_staff_released_within_the_year_ { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? total_no_of_nigeria_senior_staff { get; set; }

    public string? total_no_of_senior_staff { get; set; }

    public string? total_no_of_top_nigerian_management_staff { get; set; }

    public string? total_no_of_top_management_staff { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? CompanyOrganogramFilePath { get; set; }
    public string? CompanyOrganogramFileName { get; set; }
}
