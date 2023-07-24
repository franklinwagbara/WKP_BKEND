using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED
{
    public int? Production_month_id { get; set; }

    public string? Production_month { get; set; }

    public int? Annual_Total_Production_by_company { get; set; }

    public decimal? Annual_Avg_Daily_Production { get; set; }

    public string? Year_of_WP { get; set; }
}
