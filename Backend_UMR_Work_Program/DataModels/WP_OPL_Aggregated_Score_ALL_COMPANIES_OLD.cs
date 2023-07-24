using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OPL_Aggregated_Score_ALL_COMPANIES_OLD
{
    public string? CompanyName { get; set; }

    public string? Consession_Type { get; set; }

    public string? Year_of_WP { get; set; }

    public string? INDEX_TYPE { get; set; }

    public int? Recalibrated_Scaled_Index_SUM { get; set; }

    public int? Weight_SUM { get; set; }

    public int? Weighted_Score_SUM { get; set; }

    public decimal? OPL_Aggregated_Score { get; set; }
}
