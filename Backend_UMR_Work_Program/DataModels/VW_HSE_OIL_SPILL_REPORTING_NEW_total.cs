﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class VW_HSE_OIL_SPILL_REPORTING_NEW_total
    {
        public string? Contract_Type { get; set; }
        public string? Year_of_WP { get; set; }
        public int? Volume_of_spill_bbls { get; set; }
        public int? Volume_recovered_bbls { get; set; }
    }
}
