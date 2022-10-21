﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR
    {
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? ACTUAL_year { get; set; }
        public string? PROPOSED_year { get; set; }
        public string? CSR_ { get; set; }
        public string? Budget_ { get; set; }
        public string? Actual_Spent_ { get; set; }
        public string? Percentage_Completion_ { get; set; }
        public string? Consession_Type { get; set; }
        public string? Terrain { get; set; }
        public string? Contract_Type { get; set; }
        public int? CompanyNumber { get; set; }
        public int? Field_ID { get; set; }
    }
}
