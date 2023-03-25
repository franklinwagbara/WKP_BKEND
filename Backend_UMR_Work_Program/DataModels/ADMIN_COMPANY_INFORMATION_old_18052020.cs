using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_COMPANY_INFORMATION_old_18052020
{
    public int Id { get; set; }

    public string? COMPANY_NAME { get; set; }

    public string? EMAIL { get; set; }

    public string? PASSWORDS { get; set; }

    public string? Created_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? LAST_LOGIN_DATE { get; set; }

    public string? STATUS_ { get; set; }

    public string? FLAG_PASSWORD_CHANGE { get; set; }

    public string? CATEGORY { get; set; }

    public string? NAME { get; set; }

    public string? DESIGNATION { get; set; }

    public string? PHONE_NO { get; set; }

    public int? CompanyNumber { get; set; }
}
