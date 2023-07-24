using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_by_Terrain
{
    public string? Terrain { get; set; }

    public int? Annual_Total_Production_by_company { get; set; }

    public string? Year_of_WP { get; set; }

    public int? Annual_Total_Production_by_year { get; set; }

    public decimal? Percentage_Production { get; set; }
}
