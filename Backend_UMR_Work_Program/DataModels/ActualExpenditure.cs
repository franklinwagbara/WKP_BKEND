using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ActualExpenditure
{
    public int Actual_ExpenditureId { get; set; }

    public string? Direct_Exploration_Budget { get; set; }

    public string? Equivalent_Naira_Dollar_Component { get; set; }

    public string? Other_Activity_Budget { get; set; }

    public string? UserEmail { get; set; }

    public int? UserNumber { get; set; }
}
