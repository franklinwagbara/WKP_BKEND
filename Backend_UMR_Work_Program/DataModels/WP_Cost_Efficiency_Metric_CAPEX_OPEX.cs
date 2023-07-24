using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_Cost_Efficiency_Metric_CAPEX_OPEX
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? naira { get; set; }

    public string? Consession_Type { get; set; }
}
