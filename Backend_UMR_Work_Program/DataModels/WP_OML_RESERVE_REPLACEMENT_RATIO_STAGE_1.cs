using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Consession_Type { get; set; }

    public int? Reserves_as_at_MMbbl { get; set; }

    public decimal? Reserves_as_at_MMbbl_P1 { get; set; }

    public decimal? Total_Production_ { get; set; }

    public decimal? Unscaled_Score { get; set; }
}
