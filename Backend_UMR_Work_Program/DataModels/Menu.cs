using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Menu
{
    public string MenuId { get; set; } = null!;

    public string? Description { get; set; }

    public string? IconName { get; set; }

    public byte? SeqNo { get; set; }

    public string? Status { get; set; }
}
