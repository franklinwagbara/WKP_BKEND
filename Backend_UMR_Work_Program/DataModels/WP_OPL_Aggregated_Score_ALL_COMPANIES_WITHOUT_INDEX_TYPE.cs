using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OPL_Aggregated_Score_ALL_COMPANIES_WITHOUT_INDEX_TYPE
{
    public string? CompanyName { get; set; }

    public string? Consession_Type { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Recalibrated_Scaled_Index_SUM { get; set; }

    public decimal? Weight_SUM { get; set; }

    public decimal? Weighted_Score_SUM { get; set; }

    public decimal OPL_Aggregated_Score { get; set; }
}
