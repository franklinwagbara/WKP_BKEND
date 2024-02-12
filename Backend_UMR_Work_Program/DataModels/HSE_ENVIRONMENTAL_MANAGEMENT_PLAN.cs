using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_ENVIRONMENTAL_MANAGEMENT_PLAN
{
    public int Id { get; set; }

    public int? Field_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? OmL_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public string? AreThereEMP { get; set; }

    public string? FacilityType { get; set; }

    public string? FacilityLocation { get; set; }

    public string? RemarkIfNoEMP { get; set; }
    public string? eMUploadName { get; set; }
    public string? eMUploadPath { get; set; }
    public string? OSCPUploadName { get; set; }
    public string? OSCPUploadPath { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public string? Created_by { get; set; }


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
