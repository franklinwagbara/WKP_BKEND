using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class BudgetProposal
{
    public int Budget_ProposalId { get; set; }

    public long? Direct_Exploration_Budget { get; set; }

    public long? Other_Activity_Budget { get; set; }

    public long? Total_Company_Expenditure { get; set; }

    public string? Oil_Gas_Facility_Maintenance { get; set; }
}
