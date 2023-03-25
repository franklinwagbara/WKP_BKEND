using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_HSE_FATALITIES_accident_statistic_table
{
    public string? CompanyName { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Fatalities_Type { get; set; }

    public int? Fatalities_Proposed_year { get; set; }

    public int? Fatalities_Current_year { get; set; }

    public string? type_of_incidence { get; set; }
}
