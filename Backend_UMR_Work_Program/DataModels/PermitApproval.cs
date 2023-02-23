using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class PermitApproval
{
    public int Id { get; set; }

    public string PermitNo { get; set; } = null!;

    public int AppID { get; set; }

    public int CompanyID { get; set; }

    public int? ElpsID { get; set; }

    public DateTime DateIssued { get; set; }

    public DateTime DateExpired { get; set; }

    public string? IsRenewed { get; set; }

    public bool Printed { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
}
