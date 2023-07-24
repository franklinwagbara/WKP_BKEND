using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_GAS_PRODUCTION_ACTIVITIES_total
{
    public string? Contract_Type { get; set; }

    public int? Current_Actual_Year { get; set; }

    public int? Utilized { get; set; }

    public int? Flared { get; set; }

    public int? Forecast_ { get; set; }

    public string? Year_of_WP { get; set; }
}
