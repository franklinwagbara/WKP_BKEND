using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WORKOVERS_RECOMPLETION_JOB1
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Current_year_Actual_Number_data { get; set; }

    public string? Proposed_year_data { get; set; }

    public string? Current_year_Budget_Allocation { get; set; }

    public string? Remarks { get; set; }

    public string? Processing_Fees_paid { get; set; }

    public string? Do_you_have_approval_for_the_workover_recompletion { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Budeget_Allocation_NGN { get; set; }

    public string? Budeget_Allocation_USD { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? QUATER { get; set; }

    public string? oil_or_gas_wells { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? DaysForCompletion { get; set; }

    public string? CompletionWellName { get; set; }

    public DateTime? Proposed_Workover_Date { get; set; }

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
