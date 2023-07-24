using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class UserLogin
{
    public long LoginPk { get; set; }

    public string UserId { get; set; } = null!;

    public string? UserType { get; set; }

    public string? Browser { get; set; }

    public string? Client { get; set; }

    public DateTime? LoginTime { get; set; }

    public string? Status { get; set; }

    public string? LoginMessage { get; set; }
}
