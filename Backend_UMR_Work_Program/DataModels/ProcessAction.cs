using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ProcessAction
{
    public int Id { get; set; }

    public string? ActionName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreateOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }
}
