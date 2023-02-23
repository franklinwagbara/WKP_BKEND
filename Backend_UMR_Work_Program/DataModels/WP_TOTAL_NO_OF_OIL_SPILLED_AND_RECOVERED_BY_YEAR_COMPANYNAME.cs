using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_TOTAL_NO_OF_OIL_SPILLED_AND_RECOVERED_BY_YEAR_COMPANYNAME
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Total_Quantity_Spilled { get; set; }

    public decimal? Total_Quantity_Recovered { get; set; }
}
