﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW
    {
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? facility { get; set; }
        public string? study_type { get; set; }
        public string? facility_location { get; set; }
        public string? approval_status { get; set; }
        public string? remarks { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Contract_Type { get; set; }
        public string? Terrain { get; set; }
        public string? Consession_Type { get; set; }
        public string? COMPANY_ID { get; set; }
    }
}
