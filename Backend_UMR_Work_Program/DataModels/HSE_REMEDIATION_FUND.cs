using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_REMEDIATION_FUND
{
    public int Id { get; set; }

    public string? OML_Name { get; set; }

    public string? OML_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Company_Email { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Company_Number { get; set; }

    public string? Company_ID { get; set; }

    public string? evidenceOfPaymentFilename { get; set; }

    public string? evidenceOfPaymentPath { get; set; }

    public string? reasonForNoRemediation { get; set; }

    public string? areThereRemediationFund { get; set; }

    public string? Created_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public int? Field_ID { get; set; }

    public string? Updated_by { get; set; }
}
