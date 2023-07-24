using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? CAPEX_PLUS_OPEX { get; set; }

    public decimal? Production { get; set; }
}
