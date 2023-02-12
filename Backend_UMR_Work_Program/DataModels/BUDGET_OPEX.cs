using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels
{
    public partial class BUDGET_OPEX
    {
        public int Id { get; set; }
        public string? OmL_Name { get; set; }
        public string? OmL_ID { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? Company_ID { get; set; }
        public int? CompanyNumber { get; set; }
        public string? Variable_Cost { get; set; }
        public string? Fixed_Cost { get; set; }
        public string? Overheads { get; set; }
        public string? Repairs_and_Maintenance_Cost { get; set; }
        public string? General_Expenses { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public int? Field_ID {get; set;}
    }
}
