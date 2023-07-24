using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_OPERATIONS_SAFETY_CASE
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Reason_If_No_Evidence { get; set; }

    public string? Evidence_of_Operations_Safety_Case_Approval { get; set; }

    public string? Does_the_Facility_Have_a_Valid_Safety_Case { get; set; }

    public string? Type_of_Facility { get; set; }

    public string? Location_of_Facility { get; set; }

    public string? Name_Of_Facility { get; set; }

    public string? Number_of_Facilities { get; set; }

    public DateTime? Date_Created { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
