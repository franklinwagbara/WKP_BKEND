using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class StrategicBusinessUnit
{
    public int Id { get; set; }

    public string? SBU_Name { get; set; }

    public string? SBU_Code { get; set; }

    public int? Tier { get; set; }
}
