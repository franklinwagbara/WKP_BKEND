using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_Gas_Production_Utilisation_And_Flaring_Forecast
{
    public string? Year_of_WP { get; set; }

    public int? Current_Actual_Year { get; set; }

    public int? Utilized { get; set; }

    public int? Flared { get; set; }

    public decimal? Percentage_flared { get; set; }

    public decimal? Percentage_Utilized { get; set; }
}
