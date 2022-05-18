﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE
    {
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? Company_Reserves_Year { get; set; }
        public string? Company_Reserves_Oil { get; set; }
        public string? Company_Reserves_Condensate { get; set; }
        public string? Company_Reserves_AG { get; set; }
        public string? Company_Reserves_NAG { get; set; }
        public string? Company_Reserves_AnnualOilProduction { get; set; }
        public string? Consession_Type { get; set; }
        public string? Contract_Type { get; set; }
        public string? Terrain { get; set; }
    }
}
