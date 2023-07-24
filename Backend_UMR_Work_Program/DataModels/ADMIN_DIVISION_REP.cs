using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_DIVISION_REP
{
    public int Id { get; set; }

    public string? NAME { get; set; }

    public string? DIVISION { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? DIVISIONEMAIL { get; set; }
}
