using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_SUBMISSION_WINDOW
{
    public int Id { get; set; }

    public DateTime? OPEN_DATE { get; set; }

    public DateTime? CLOSE_DATE { get; set; }

    public string? Open_date_only { get; set; }

    public string? Open_time_only { get; set; }

    public string? Close_date_only { get; set; }

    public string? Close_time_only { get; set; }

    public string? Year { get; set; }

    public string? Created_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? LAST_LOGIN_DATE { get; set; }

    public string? STATUS_ { get; set; }

    public string? FLAG_PASSWORD_CHANGE { get; set; }
}
