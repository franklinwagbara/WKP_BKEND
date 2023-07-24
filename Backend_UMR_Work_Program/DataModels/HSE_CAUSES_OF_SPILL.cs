using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_CAUSES_OF_SPILL
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? no_of_spills_reported { get; set; }

    public string? Total_Quantity_Spilled { get; set; }

    public string? Total_Quantity_Recovered { get; set; }

    public string? Corrosion { get; set; }

    public string? Equipment_Failure { get; set; }

    public string? Erossion_waves_sand { get; set; }

    public string? Human_Error { get; set; }

    public string? Mystery { get; set; }

    public string? Operational_Maintenance_Error { get; set; }

    public string? Sabotage { get; set; }

    public string? YTBD { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? Created_by { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
