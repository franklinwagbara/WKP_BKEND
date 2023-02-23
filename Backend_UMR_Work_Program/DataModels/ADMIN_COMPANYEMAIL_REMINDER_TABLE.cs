using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_COMPANYEMAIL_REMINDER_TABLE
{
    public int Id { get; set; }

    public string? COMPANY_NAME { get; set; }

    public string? EMAIL { get; set; }

    public string? COMPANY_ID { get; set; }

    public string? OPEN_DATE { get; set; }

    public string? CLOSE_DATE { get; set; }

    public string? EMAIL_REMARK { get; set; }

    public string? Expr1 { get; set; }
}
