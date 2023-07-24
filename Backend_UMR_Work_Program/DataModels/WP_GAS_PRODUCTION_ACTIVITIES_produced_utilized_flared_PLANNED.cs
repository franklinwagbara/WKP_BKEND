using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public int? Current_Actual_Year { get; set; }

    public int? Utilized { get; set; }

    public int? Flared { get; set; }

    public decimal Percentage_FLARED { get; set; }
}
