using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Reserve_Update_Oil_Condensate
{
    public int Reserve_UpdateId { get; set; }

    public string? P1_Reserve { get; set; }

    public string? Reserves { get; set; }

    public string? Additional_Reserves { get; set; }

    public long? Total_Production { get; set; }
}
