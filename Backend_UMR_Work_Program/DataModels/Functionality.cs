using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Functionality
{
    public string FuncId { get; set; } = null!;

    public string? Description { get; set; }

    public string? MenuId { get; set; }

    public string? Action { get; set; }

    public byte? SeqNo { get; set; }

    public string? Status { get; set; }

    public string? IconName { get; set; }

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
