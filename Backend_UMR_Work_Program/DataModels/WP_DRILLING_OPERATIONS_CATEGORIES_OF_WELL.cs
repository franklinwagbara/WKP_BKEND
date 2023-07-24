using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELL
{
    public decimal? Actual_No_Drilled_in_Current_Year { get; set; }

    public decimal? Proposed_No_Drilled { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Category { get; set; }
}
