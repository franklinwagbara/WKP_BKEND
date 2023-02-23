using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class AuditTrail
{
    public int AuditLogID { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? UserID { get; set; }
}
