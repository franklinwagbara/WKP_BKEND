using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_COMPANY_CODE
{
    public int Id { get; set; }

    public string? CompanyCode { get; set; }

    public string? CompanyName { get; set; }

    public string? Email { get; set; }

    public string? GUID { get; set; }

    public string? IsActive { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public int? UserNumber { get; set; }

    public int? CompanyNumber { get; set; }
}
