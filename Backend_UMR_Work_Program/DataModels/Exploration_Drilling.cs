using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Exploration_Drilling
{
    public int Exploration_DrillingId { get; set; }

    public string? Actual_Year { get; set; }

    public string? Proposed_Year { get; set; }

    public long? Budget_Allocation { get; set; }

    public string? Net_Oil_Gas_Sand { get; set; }

    public string? Well_Name { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }
}
