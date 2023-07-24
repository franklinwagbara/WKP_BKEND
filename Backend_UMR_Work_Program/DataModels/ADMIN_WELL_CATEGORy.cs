using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_WELL_CATEGORy
{
    public int Id { get; set; }

    public string? welltype { get; set; }

    public string? categories_Desc { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public int? CompanyNumber { get; set; }
}
