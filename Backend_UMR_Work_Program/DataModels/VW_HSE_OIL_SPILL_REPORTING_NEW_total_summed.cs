using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_HSE_OIL_SPILL_REPORTING_NEW_total_summed
{
    public string? Year_of_WP { get; set; }

    public int? Volume_of_spill_bbls { get; set; }

    public int? Volume_recovered_bbls { get; set; }
}
