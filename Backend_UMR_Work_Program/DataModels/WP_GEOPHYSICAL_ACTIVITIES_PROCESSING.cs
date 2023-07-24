using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_GEOPHYSICAL_ACTIVITIES_PROCESSING
{
    public string? Geo_Type_of_Data_being_Processed { get; set; }

    public string? Year_of_WP { get; set; }

    public decimal? Processed_Actual { get; set; }

    public decimal? Processed_Proposed { get; set; }

    public decimal? Reprocessed_Actual { get; set; }

    public decimal? Reprocessed_Proposed { get; set; }

    public decimal? Interpreted_Actual { get; set; }

    public decimal? Interpreted_Proposed { get; set; }
}
