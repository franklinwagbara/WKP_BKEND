using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year
{
    public string? Year_of_WP { get; set; }

    public int? Exploration_Actual { get; set; }

    public int? Development_Actual { get; set; }

    public int? Appraisal_Actual { get; set; }

    public int? Exploration_Proposed { get; set; }

    public int? Development_Proposed { get; set; }

    public int? Appraisal_Proposed { get; set; }

    public int? Current_year_Actual_Number_well_completion { get; set; }

    public int? Proposed_year_data_well_completion { get; set; }

    public int? Current_year_Actual_Number_data_workover { get; set; }

    public int? Expr7_Proposed_workover { get; set; }
}
