using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class DecommissioningAbandonment
{
    public int Id { get; set; }

    public string? Decommissioning { get; set; }

    public string? Abandonment { get; set; }

    public string? Cumulative_DA_Annual_Payment { get; set; }

    public string? Accrued_DA_Annual_Payment { get; set; }

    public string? CAPEX { get; set; }

    public string? OPEX { get; set; }

    public int? CompanyNumber { get; set; }

    public int? ConcessionID { get; set; }

    public int? FieldID { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? Year { get; set; }
}
