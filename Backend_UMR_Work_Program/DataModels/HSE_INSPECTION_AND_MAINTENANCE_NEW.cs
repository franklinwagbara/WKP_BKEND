using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_INSPECTION_AND_MAINTENANCE_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTUAL_year { get; set; }

    public string? PROPOSED_year { get; set; }

    public string? Was_Inspection_and_Maintenance_of_each_of_your_facility_carried_out { get; set; }

    public string? Is_the_inspection_philosophy_Prescriptive_or_RBI_for_each_facility { get; set; }

    public string? If_RBI_was_approval_granted { get; set; }

    public string? If_No_Give_reasonS { get; set; }

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
