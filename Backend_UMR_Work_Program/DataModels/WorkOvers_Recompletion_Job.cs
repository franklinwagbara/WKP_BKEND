using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WorkOvers_Recompletion_Job
{
    public int WorkOvers_Recompletion_JobId { get; set; }

    public string? Actual_No_Current_Year { get; set; }

    public string? Actual_No_Proposed_Year { get; set; }

    public string? Budget_Allocation_Proposed_Year { get; set; }

    public string? Processing_Fees_Paid { get; set; }

    public string? Do_you_have_approval_for_workover_recompletion { get; set; }

    public string? Remark { get; set; }

    public string? Year_of_WorkProgram { get; set; }
}
