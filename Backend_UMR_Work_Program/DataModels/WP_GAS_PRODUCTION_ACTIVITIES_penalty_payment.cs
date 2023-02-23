using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_GAS_PRODUCTION_ACTIVITIES_penalty_payment
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Flared { get; set; }

    public decimal? penaltyfeepaid { get; set; }

    public decimal? Amount_Paid { get; set; }
}
