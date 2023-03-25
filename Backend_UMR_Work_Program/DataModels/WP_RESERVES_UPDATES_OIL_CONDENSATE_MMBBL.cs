using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL
{
    public string? Year_of_WP { get; set; }

    public decimal? Reserves_as_at_MMbbl { get; set; }

    public decimal? Reserves_as_at_MMbbl_gas { get; set; }

    public decimal? Reserves_as_at_MMbbl_condensate { get; set; }
}
