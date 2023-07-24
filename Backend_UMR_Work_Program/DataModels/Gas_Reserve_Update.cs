using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Gas_Reserve_Update
{
    public int Gas_ReserveId { get; set; }

    public string? Reserve1 { get; set; }

    public string? Reserve2 { get; set; }

    public string? Additional_Reserve { get; set; }

    public long? Total_Production { get; set; }
}
