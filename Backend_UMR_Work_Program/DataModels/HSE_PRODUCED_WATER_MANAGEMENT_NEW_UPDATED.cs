using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? FIELD_NAME { get; set; }

    public string? Concession { get; set; }

    public string? facilities { get; set; }

    public string? DEPTH_AND_DISTANCE_FROM_SHORELINE { get; set; }

    public string? Produced_water_volumes { get; set; }

    public string? Disposal_philosophy { get; set; }

    public string? DPR_APPROVAL_STATUS { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
