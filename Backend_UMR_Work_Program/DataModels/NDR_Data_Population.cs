using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class NDR_Data_Population
{
    public int NDRDataId { get; set; }

    public string? Actual_Year { get; set; }

    public string? Proposed_Year { get; set; }

    public string? Data_Type { get; set; }

    public string? Processed_Data { get; set; }

    public string? Reason_Non_Processed_Data { get; set; }

    public string? Subscription_Fee_Upload { get; set; }

    public string? Annual_Sub_Fee { get; set; }

    public string? Reason_For_Non_Payment { get; set; }
}
