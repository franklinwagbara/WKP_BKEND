using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_WASTE_MANAGEMENT_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTUAL_year { get; set; }

    public string? PROPOSED_year { get; set; }

    public string? Do_you_have_Waste_Management_facilities { get; set; }

    public string? If_YES_is_the_facility_registered { get; set; }

    public string? If_NO_give_reasons_for_not_being_registered { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? Commitment_To_Waste_Management { get; set; }

    public double? How_Much_Is_Budgeted_For_Waste_MGT_Plan { get; set; }

    public string? Evidence_Of_Submission_Of_Journey_MGT_Plan { get; set; }

    public string? Are_Registered_Point_Sources_Valid { get; set; }

    public string? Evidence_Of_Submission_Of_PreviousYears_Waste_Release { get; set; }
}
