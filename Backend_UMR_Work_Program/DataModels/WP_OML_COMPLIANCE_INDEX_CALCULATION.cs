using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OML_COMPLIANCE_INDEX_CALCULATION
{
    public string? CompanyName { get; set; }

    public string? Consession_Type { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Total_Sum_All_Division { get; set; }
}
