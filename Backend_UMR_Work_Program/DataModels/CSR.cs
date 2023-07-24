using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class CSR
{
    public int CSR_Id { get; set; }

    public string? MOU_with_Community { get; set; }

    public string? Reason_WithOut_MOU { get; set; }

    public string? All_MOU_Submitted { get; set; }

    public string? CSR_Projects { get; set; }

    public long? Actual_Spent { get; set; }

    public long? Budget { get; set; }

    public int? Percentage_Completion { get; set; }
}
