using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_TOTAL_INCIDENCE_AND_OIL_SPILL_AND_RECOVERED
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Frequency { get; set; }

    public decimal? Total_Quantity_Spilled { get; set; }

    public decimal? Total_Quantity_Recovered { get; set; }
}
