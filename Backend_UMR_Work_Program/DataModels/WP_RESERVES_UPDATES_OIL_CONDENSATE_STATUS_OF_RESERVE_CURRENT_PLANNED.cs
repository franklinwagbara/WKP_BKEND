using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED
{
    public decimal? Total_Company_Reserves_Oil { get; set; }

    public decimal? Total_Company_Reserves_Condensate { get; set; }

    public decimal? Total_oil_plus_condensate { get; set; }

    public decimal? Total_Company_Reserves_AG { get; set; }

    public decimal? Total_Company_Reserves_NAG { get; set; }

    public decimal? Total_AG_NAG { get; set; }

    public string? Fiveyear_Projection_Year { get; set; }
}
