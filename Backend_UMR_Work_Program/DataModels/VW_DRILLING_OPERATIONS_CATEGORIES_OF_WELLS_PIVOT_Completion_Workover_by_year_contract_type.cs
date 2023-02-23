using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_contract_type
{
    public string? Contract_Type { get; set; }

    public string? Year_of_WP { get; set; }

    public int? Exploration_Actual { get; set; }

    public int? Development_Actual { get; set; }

    public int? Appraisal_Actual { get; set; }

    public int? Exploration_Proposed { get; set; }

    public int? Development_Proposed { get; set; }

    public int? Appraisal_Proposed { get; set; }

    public int? Current_year_Actual_Number_INITIAL_WELL_COMPLETION_JOBS { get; set; }

    public int? Proposed_year_data_INITIAL_WELL_COMPLETION_JOBS { get; set; }

    public int? Current_year_Actual_Number_data_WORKOVERS_RECOMPLETION_JOBS { get; set; }

    public int? Proposed_WORKOVERS_RECOMPLETION_JOBS { get; set; }
}
