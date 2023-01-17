﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels
{
    public partial class WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type
    {
        public string? Year_of_WP { get; set; }
        public string? Contract_Type { get; set; }
        public decimal? Actual_Total_Gas_Produced { get; set; }
        public decimal? Utilized_Gas_Produced { get; set; }
        public decimal? Flared_Gas_Produced { get; set; }
    }
}
