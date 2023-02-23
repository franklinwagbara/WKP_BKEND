using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Legal
{
    public int Legal_Id { get; set; }

    public string? Company_Sanctioned { get; set; }

    public string? Company_Fined { get; set; }

    public string? Company_FinedReason { get; set; }
}
