using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Reservoir_Performance_Timeline { get; set; }

    public string? Reservoir_Performance_Reservoir { get; set; }

    public string? Reservoir_Performance_Reservoir_Pressure { get; set; }

    public string? Reservoir_Performance_WCT { get; set; }

    public string? Reservoir_Performance_GOR { get; set; }

    public string? Reservoir_Performance_Sand_Cut { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
