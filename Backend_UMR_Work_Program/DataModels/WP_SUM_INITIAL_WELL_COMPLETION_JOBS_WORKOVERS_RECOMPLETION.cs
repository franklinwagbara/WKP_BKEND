using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION
{
    public decimal? Actual_Year { get; set; }

    public decimal? Proposed_Year { get; set; }

    public string? Year_of_WP_W { get; set; }

    public string? Year_of_WP_I { get; set; }
}
