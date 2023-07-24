using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE
{
    public int HSE_Id { get; set; }

    public int? Qty_Spilled { get; set; }

    public long? Accident_Stat { get; set; }

    public string? Relevant_Certificate { get; set; }
}
