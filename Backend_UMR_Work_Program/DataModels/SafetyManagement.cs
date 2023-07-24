using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class SafetyManagement
{
    public int Safety_ManagementId { get; set; }

    public string? Fatalities { get; set; }

    public string? Current_Facilities { get; set; }

    public string? Previous_Facilities { get; set; }

    public string? Design_Safety_Control { get; set; }

    public string? Current_Year { get; set; }

    public string? Previous_Year { get; set; }
}
