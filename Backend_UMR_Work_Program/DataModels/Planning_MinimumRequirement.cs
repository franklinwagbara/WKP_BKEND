using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Planning_MinimumRequirement
{
    public int Id { get; set; }

    public string? ReservesRevenue_GrossProduction { get; set; }

    public string? ReservesRevenue_RemainingReserves { get; set; }

    public int? CompanyNumber { get; set; }

    public int? ConcessionID { get; set; }

    public int? FieldID { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? Year { get; set; }
}
