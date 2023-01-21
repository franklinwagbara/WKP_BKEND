﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels
{
    public partial class HSE_GHG_MANAGEMENT_PLAN
    {
        public int Id { get; set; }
        public string? OmL_Name { get; set; }
        public string? OmL_ID { get; set; }
        public string? CompanyName { get; set; }
        public string? companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? CompanY_ID { get; set; }
        public int? CompanyNumber { get; set; }
        public string? DoYouHaveGHG { get; set; }
        public string? GHGApprovalFilename { get; set; }
        public string? GHGApprovalPath { get; set; }
        public string? ReasonForNoGHG { get; set; }
        public string? DoYouHaveLDRCertificate { get; set; }
        public string? LDRCertificateFilename { get; set; }
        public string? LDRCertificatePath { get; set; }
        public string? ReasonForNoLDR { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public string? Created_by { get; set; }
        public int? Field_ID { get; set; }
    }
}
