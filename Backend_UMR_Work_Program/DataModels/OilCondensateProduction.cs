using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class OilCondensateProduction
{
    public int Oil_Condensate_ProductionId { get; set; }

    public string? Actual_Year { get; set; }

    public string? Deferment { get; set; }

    public string? Forecast { get; set; }

    public int? Cost_Barrel { get; set; }

    public string? Remarks { get; set; }
}
