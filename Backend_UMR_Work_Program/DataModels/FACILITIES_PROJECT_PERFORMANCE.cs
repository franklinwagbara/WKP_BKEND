﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class FACILITIES_PROJECT_PERFORMANCE
    {
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? List_of_Projects { get; set; }
        public string? Planned_completion { get; set; }
        public string? Actual_completion { get; set; }
        public string? FLAG { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Contract_Type { get; set; }
        public string? Terrain { get; set; }
        public string? Consession_Type { get; set; }
        public string? COMPANY_ID { get; set; }
        public int? CompanyNumber { get; set; }
        public int? Field_ID { get; set; }
        public string? reasonForNoEvidence { get; set; }
        public string? areThereEvidenceOfDesignSafetyCaseApproval { get; set; }
        public string? evidenceOfDesignSafetyCaseApprovalPath { get; set; }
        public string? evidenceOfDesignSafetyCaseApprovalFilename { get; set; }
    }
}
