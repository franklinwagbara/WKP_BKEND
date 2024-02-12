using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class NIGERIA_CONTENT_Training
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Training_ { get; set; }

    public string? Local_ { get; set; }

    public string? Foreign_ { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Expatriate_quota_positions { get; set; }

    public string? Utilized_EQ { get; set; }

    public string? Nigerian_Understudies { get; set; }

    public string? Management_Foriegn { get; set; }

    public string? Management_Local { get; set; }

    public string? Staff_Foriegn { get; set; }

    public string? Staff_Local { get; set; }

    public string? Actual_Proposed { get; set; }

    public string? Actual_Proposed_Year { get; set; }

    public string? Consession_Type { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
    public string? UploadAdditionalDocumentFileName { get; set; }
    public string? UploadAdditionalDocumentFilePath { get; set; }


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
