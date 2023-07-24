using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Initial_Well_Completion_Job
{
    public int Initial_Well_CompletionId { get; set; }

    public string? Actual_No_Current_Year { get; set; }

    public string? Actual_No_Proposed_Year { get; set; }

    public string? Budget_Allocation_Proposed_Year { get; set; }

    public string? Processing_Fees_Paid { get; set; }

    public string? Do_you_have_approval_to_complete_the_well { get; set; }

    public string? Remark { get; set; }

    public string? Year_of_WorkProgram { get; set; }
}
