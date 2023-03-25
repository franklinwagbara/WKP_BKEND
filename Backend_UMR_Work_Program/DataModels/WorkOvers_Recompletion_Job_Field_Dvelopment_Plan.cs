using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WorkOvers_Recompletion_Job_Field_Dvelopment_Plan
{
    public int WorkOvers_Recompletion_Job_Field_Dvelopment_PlansId { get; set; }

    public string? How_many_fields_have_FDP { get; set; }

    public string? List_all_the_field_with_FDP { get; set; }

    public string? Which_fields_do_you_plan_to_submit_an_FDP { get; set; }

    public string? How_many_fields_have_approved_FDP { get; set; }

    public string? Number_of_wells_proposed_in_the_FDP { get; set; }

    public string? No_of_wells_drilled_in_Current_Year { get; set; }

    public string? proposed_number_of_wells_for_Proposed_Year_from_Approved_FDP { get; set; }

    public string? Processing_Fees_Paid { get; set; }

    public string? Year_of_WorkProgram { get; set; }
}
