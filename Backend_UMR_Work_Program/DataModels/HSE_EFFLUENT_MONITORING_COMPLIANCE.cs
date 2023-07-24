using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_EFFLUENT_MONITORING_COMPLIANCE
{
    public int Id { get; set; }

    public int? Field_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? OmL_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? COMPANY_ID { get; set; }

    public string? CompanyNumber { get; set; }

    public string? AreThereEvidentOfSampling { get; set; }

    public string? EvidenceOfSamplingFilename { get; set; }

    public string? EvidenceOfSamplingPath { get; set; }

    public string? ReasonForNoEvidenceSampling { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public string? Created_by { get; set; }
}
