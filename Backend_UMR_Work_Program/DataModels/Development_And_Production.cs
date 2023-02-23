using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Development_And_Production
{
    public int Id { get; set; }

    public string? FieldHistory { get; set; }

    public string? Do_You_Have_Any_SubsurfacePlan { get; set; }

    public string? Type_Of_SubsurfacePlan { get; set; }

    public string? FiveYears_Projection_Of_Anticipated_Dev_Schemes { get; set; }

    public string? Have_You_Submitted_AnnualReseves_BookingStatus { get; set; }

    public string? Do_You_Have_Reserves_Growth_Strategy_Plan { get; set; }

    public int? Number_Of_Shut_In_Wells { get; set; }

    public int? How_Many_ShutIn_Wells_Are_Planned_To_Reactivate { get; set; }

    public int? How_Many_Wells_Do_You_Plan_To_Complete { get; set; }

    public int? How_Many_Wells_Do_You_Plan_To_Abandon { get; set; }

    public int? Number_Of_Well_Interventions_Planned_For_The_Year { get; set; }

    public int? CompanyNumber { get; set; }

    public int? ConcessionID { get; set; }

    public int? FieldID { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? Year { get; set; }
}
