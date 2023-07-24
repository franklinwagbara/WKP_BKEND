using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class DevelopmentDrilling
{
    public int Development_DrillingId { get; set; }

    public string? Actual_Year { get; set; }

    public string? Proposed_Year { get; set; }

    public long? Budget_Allocation { get; set; }

    public string? Remarks { get; set; }
}
