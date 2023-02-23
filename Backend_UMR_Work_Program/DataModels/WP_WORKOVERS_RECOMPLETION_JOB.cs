using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_WORKOVERS_RECOMPLETION_JOB
{
    public decimal? Current_year_Actual_Number_data { get; set; }

    public decimal? Proposed_year_data { get; set; }

    public string? Year_of_WP { get; set; }
}
