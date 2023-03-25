using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Drilling_Operation
{
    public int Drilling_OperationsId { get; set; }

    public string? Do_you_have_approval_to_drill { get; set; }

    public string? Comment_drill_approval { get; set; }

    public string? Category_of_wells_drilled { get; set; }

    public string? Actual_no_drilled_current_year { get; set; }

    public string? Actual_no_drilled_next_year { get; set; }

    public string? Processing_field_paid { get; set; }

    public string? No_of_wells_cored { get; set; }

    public string? Comment { get; set; }

    public string? Any_new_discoveries { get; set; }

    public string? Any_new_discoveries_comment { get; set; }

    public string? Hydrocarbon_counts { get; set; }

    public string? Number_of_exploration_wells_drilled { get; set; }

    public string? Status { get; set; }

    public string? Net_Oil_Gas_Sand { get; set; }

    public string? Cost_of_drilling_foot { get; set; }

    public string? Year_of_WorkProgram { get; set; }
}
