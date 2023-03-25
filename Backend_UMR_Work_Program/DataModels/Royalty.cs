using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Royalty
{
    public int Royalty_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Concession_ID { get; set; }

    public int? Field_ID { get; set; }

    public string? Crude_Oil_Royalty { get; set; }

    public string? Gas_Sales_Royalty { get; set; }

    public string? Gas_Flare_Payment { get; set; }

    public string? Concession_Rentals { get; set; }

    public string? Miscellaneous { get; set; }

    public string? Year { get; set; }

    public string? Status { get; set; }

    public DateTime? Date_Created { get; set; }

    public string? Last_Qntr_Royalty { get; set; }

    public string? OmlName { get; set; }
}
