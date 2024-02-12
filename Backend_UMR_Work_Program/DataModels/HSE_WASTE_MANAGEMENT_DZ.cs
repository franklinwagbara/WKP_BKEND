using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_WASTE_MANAGEMENT_DZ
{
        public int Id { get; set; }
        public string? OML_ID { get; set; }
        public string? OML_Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Companyemail { get; set; }
        public string? Year_of_WP { get; set; }
        public string? COMPANY_ID { get; set; }
        public int? CompanyNumber { get; set; }
        public string? Evidence_of_pay_of_DDCFilename { get; set; }
        public string? Evidence_of_pay_of_DDCPath { get; set; }
        public string? Waste_Contractor_Names { get; set; }
        public string? Produce_Water_Manegent_Plan { get; set; }
        public string? Evidence_of_Reinjection_Permit_Filename { get; set; }
        public string? Evidence_of_Reinjection_Permit_Path { get; set; }
        public string? Reason_for_No_Evidence_of_Reinjection { get; set; }
        public string? Do_You_Have_Previous_Year_Waste_Inventory_Report { get; set; }
        public string? Evidence_of_EWD_Filename { get; set; }
        public string? Evidence_of_EWD_Path { get; set; }
        public string? Reason_for_No_Evidence_of_EWD { get; set; }
        public string? ACTUAL_year { get; set; }
        public string? PROPOSED_year { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Waste_Service_Permit_Filename { get; set; }
        public string? Waste_Service_Permit_Path { get; set; }
        public string? Field_Name { get; set; }
        public int? Field_ID { get; set; }


        [NotMapped]
        public string? ConcessionName;
        [NotMapped]
        public string FieldName => Field?.Field_Name;
        [NotMapped]
        public string? ConcessionType;

        [NotMapped]
        public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }

        [ForeignKey(nameof(Field_ID))]
        public COMPANY_FIELD? Field { get; set; }

}
