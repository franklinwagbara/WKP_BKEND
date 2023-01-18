﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels
{
    public partial class OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE
    {
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? Actual_capital_expenditure_Current_year { get; set; }
        public string? Proposed_Capital_Expenditure { get; set; }
        public string? Remarks { get; set; }
        public string? Actual_year { get; set; }
        public string? Proposed_year { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Actual_capital_expenditure_Current_year_NGN { get; set; }
        public string? Actual_capital_expenditure_Current_year_USD { get; set; }
        public string? Proposed_Capital_Expenditure_NGN { get; set; }
        public string? Proposed_Capital_Expenditure_USD { get; set; }
        public string? Contract_Type { get; set; }
        public string? Terrain { get; set; }
        public string? Consession_Type { get; set; }
        public string? COMPANY_ID { get; set; }
        public int? CompanyNumber { get; set; }
        public int? Field_ID { get; set; }
    }
}
