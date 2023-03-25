using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_Geophysical_SEISMIC_DATA_total_summed
{
    public string? Year_ACQUISITION { get; set; }

    public int? Actual_year_aquired_data_ACQUISITION { get; set; }

    public int? proposed_year_data_ACQUISITION { get; set; }

    public int? Actual_year_aquired_data_PROCESSING { get; set; }

    public int? proposed_year_data_PROCESSING { get; set; }
}
