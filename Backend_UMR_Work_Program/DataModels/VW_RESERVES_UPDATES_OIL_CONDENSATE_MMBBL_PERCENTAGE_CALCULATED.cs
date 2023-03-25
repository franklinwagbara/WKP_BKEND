using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_PERCENTAGE_CALCULATED
{
    public string? Contract_Type { get; set; }

    public int? Total_Production_ { get; set; }

    public string? Year_of_WP { get; set; }

    public int? Total_Production_percentage { get; set; }

    public string? Year_of_WP_percentage { get; set; }

    public int? Percantage_Production { get; set; }
}
