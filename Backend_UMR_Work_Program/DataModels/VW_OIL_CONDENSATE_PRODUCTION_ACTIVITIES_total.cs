using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total
{
    public string? Contract_Type { get; set; }

    public int? Current_year_Actual { get; set; }

    public int? Deferment { get; set; }

    public int? Forecast { get; set; }

    public int? Cost_Barrel { get; set; }

    public string? Year_of_WP { get; set; }
}
