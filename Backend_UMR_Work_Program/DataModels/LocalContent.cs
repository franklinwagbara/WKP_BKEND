using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class LocalContent
{
    public int Local_ContentId { get; set; }

    public string? Actual_Year { get; set; }

    public string? Proposed_Year { get; set; }

    public string? List_of_Expiry_Expatriate { get; set; }

    public string? List_of_Understudies { get; set; }

    public string? Expatriate_Quota_Projection { get; set; }
}
