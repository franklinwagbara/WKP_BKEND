﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU
    {
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? Type_of_project_excuted { get; set; }
        public string? Year_GMou_was_signed { get; set; }
        public string? Project_Location { get; set; }
        public string? Component_of_project { get; set; }
        public string? Actual_Budget_Total_Dollars { get; set; }
        public string? Beneficiary_Community { get; set; }
        public string? Status_Of_Project { get; set; }
        public string? MOUUploadFilePath { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Consession_Type { get; set; }
        public string? Terrain { get; set; }
        public string? Contract_Type { get; set; }
        public string? MOUUploadFilename { get; set; }
        public string? COMPANY_ID { get; set; }
    }
}
