using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Gas_Production_Activity1
{
    public int Gas_Production_ActivityId { get; set; }

    public string? Actual_Year { get; set; }

    public string? Utilized { get; set; }

    public string? Forecast { get; set; }

    public string? Flared { get; set; }

    public string? Remarks { get; set; }
}
