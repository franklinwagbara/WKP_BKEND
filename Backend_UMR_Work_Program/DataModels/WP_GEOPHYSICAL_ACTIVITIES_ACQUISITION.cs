﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION
    {
        public string? Geo_type_of_data_acquired { get; set; }
        public decimal Actual_year_aquired_data { get; set; }
        public decimal? proposed_year_data { get; set; }
        public string? Year_of_WP { get; set; }
    }
}
