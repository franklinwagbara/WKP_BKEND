using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class FacilityConstruction
{
    public int Facility_ConstructionId { get; set; }

    public long? Actual_Capital_Expenditure { get; set; }

    public long? Proposed_Capital_Expenditure { get; set; }

    public string? Remarks { get; set; }

    public string? Facility_Calibration { get; set; }
}
