using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Current_Actual_Year { get; set; }

    public decimal? Utilized { get; set; }

    public decimal? Flared { get; set; }

    public decimal? Percentage_FLARED { get; set; }
}
