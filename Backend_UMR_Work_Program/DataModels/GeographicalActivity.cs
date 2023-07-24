using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class GeographicalActivity
{
    public int Geographical_ActivityId { get; set; }

    public string? Actual_Year_A { get; set; }

    public string? Proposed_Year_A { get; set; }

    public long? Budget_Allocation_A { get; set; }

    public string? Remark_A { get; set; }

    public string? Actual_Year_B { get; set; }

    public string? Proposed_Year_B { get; set; }

    public long? Budget_Allocation_B { get; set; }

    public string? Remark_B { get; set; }
}
