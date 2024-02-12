using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTUAL_year { get; set; }

    public string? PROPOSED_year { get; set; }

    public string? Are_you_a_Producing_or_Non_Producing_Company { get; set; }

    public string? If_YES_have_you_registered_your_Point_Sources { get; set; }

    public string? If_NO_give_reasons_for_not_registering_your_Point_Sources { get; set; }

    public string? Have_you_submitted_your_Environmental_Compliance_Report { get; set; }

    public string? If_NO_Give_reasons_for_non_SUBMISSION { get; set; }

    public string? Have_you_submitted_your_Chemical_Usage_Inventorization_Report { get; set; }

    public string? If_NO_Give_reasons_for_non_submission_2 { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

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
