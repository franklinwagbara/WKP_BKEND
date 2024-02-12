using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_OIL_SPILL_REPORTING_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Incident_Oil_Spill_Ref_No { get; set; }

    public string? Facility_Equipment { get; set; }

    public string? Location { get; set; }

    public string? LGA { get; set; }

    public string? State_ { get; set; }

    public DateTime? Date_of_Spill { get; set; }

    public string? Type_of_operation_at_spill_site { get; set; }

    public string? Cause_of_spill { get; set; }

    public string? Volume_of_spill_bbls { get; set; }

    public string? Volume_recovered_bbls { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? Contract_Type { get; set; }

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
