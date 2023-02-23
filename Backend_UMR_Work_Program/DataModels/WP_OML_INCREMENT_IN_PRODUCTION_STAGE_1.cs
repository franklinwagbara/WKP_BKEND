using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1
{
    public string? CompanyName { get; set; }

    public int? Year_of_WP_PREVIOUS { get; set; }

    public string? Consession_Type { get; set; }

    public int? Production_SUM_PREVIOUS_YEAR { get; set; }

    public int? Production_SUM_CURRENT_YEAR { get; set; }

    public int? Year_of_WP { get; set; }

    public decimal? Unscaled_Score { get; set; }
}
