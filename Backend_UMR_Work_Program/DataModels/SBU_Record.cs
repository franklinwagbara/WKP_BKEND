using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class SBU_Record
{
    public int Id { get; set; }

    public int? SBU_Id { get; set; }

    public string? Records { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
}
