using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class STRATEGIC_PLANS_ON_COMPANY_BASI
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTIVITIES { get; set; }

    public string? N_1_Q1 { get; set; }

    public string? N_1_Q2 { get; set; }

    public string? N_1_Q3 { get; set; }

    public string? N_1_Q4 { get; set; }

    public string? N_2_Q1 { get; set; }

    public string? N_2_Q2 { get; set; }

    public string? N_2_Q3 { get; set; }

    public string? N_2_Q4 { get; set; }

    public string? N_3_Q1 { get; set; }

    public string? N_3_Q2 { get; set; }

    public string? N_3_Q3 { get; set; }

    public string? N_3_Q4 { get; set; }

    public string? N_4_Q1 { get; set; }

    public string? N_4_Q2 { get; set; }

    public string? N_4_Q3 { get; set; }

    public string? N_4_Q4 { get; set; }

    public string? N_5_Q1 { get; set; }

    public string? N_5_Q2 { get; set; }

    public string? N_5_Q3 { get; set; }

    public string? N_5_Q4 { get; set; }

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
