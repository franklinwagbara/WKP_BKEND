using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_TOTAL_NO_OF_INCIDENCE_BY_YEAR_COMPANYNAME
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Frequency { get; set; }
}
