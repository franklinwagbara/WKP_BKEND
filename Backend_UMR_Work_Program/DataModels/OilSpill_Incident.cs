using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class OilSpill_Incident
{
    public int Oil_Spill_IncidentId { get; set; }

    public int? Number_Qty_Spilled { get; set; }

    public int? Qty_Recovered { get; set; }

    public string? Pre_Impact { get; set; }

    public string? Proposed_Year { get; set; }

    public string? InProgress_StartedYr { get; set; }

    public string? Possible_Cost { get; set; }

    public int? Total_Days_Lost { get; set; }

    public string? Effect_on_Operation { get; set; }

    public int? Nbr_of_Fatality { get; set; }

    public int? Cost_Involved { get; set; }

    public string? Action_Plan { get; set; }

    public string? Proof_Of_Submission_Of_Valid_OSCP { get; set; }

    public string? Evidence_Of_QuaterlySubmissions_Of_OilField_Chemicals { get; set; }

    public string? Evidence_Of_MOUs_With_CAN { get; set; }
}
