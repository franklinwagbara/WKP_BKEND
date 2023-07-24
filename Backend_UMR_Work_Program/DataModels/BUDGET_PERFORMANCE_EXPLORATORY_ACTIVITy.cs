using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACQUISITION_planned { get; set; }

    public string? ACQUISITION_Actual { get; set; }

    public string? PROCESSING_planned { get; set; }

    public string? PROCESSING_Actual { get; set; }

    public string? REPROCESSING_planned { get; set; }

    public string? REPROCESSING_Actual { get; set; }

    public string? EXPLORATION_planned { get; set; }

    public string? EXPLORATION_Actual { get; set; }

    public string? APPRAISAL_planned { get; set; }

    public string? APPRAISAL_Actual { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
