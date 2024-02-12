using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_HOST_COMMUNITIES_DEVELOPMENT
{
    public int Id { get; set; }

    public string? DoYouHaveEvidenceOfReg { get; set; }

    public string? EvidenceOfRegTrustFundFilename { get; set; }

    public string? EvidenceOfRegTrustFundPath { get; set; }

    public string? ReasonForNoEvidenceOfRegTF { get; set; }

    public string? DoYouHaveEvidenceOfPay { get; set; }

    public string? EvidenceOfPayTrustFundFilename { get; set; }

    public string? EvidenceOfPayTrustFundPath { get; set; }

    public string? ReasonForNoEvidenceOfPayTF { get; set; }

    public string? UploadCommDevPlanApprovalFilename { get; set; }

    public string? UploadCommDevPlanApprovalPath { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public string? Created_by { get; set; }

    public int? Field_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? OmL_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? COMPANY_ID { get; set; }

    public string? CompanyNumber { get; set; }


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
