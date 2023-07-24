using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_SAFETY_CULTURE_TRAINING
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? SafetyCurrentYearFilePath { get; set; }

    public string? SafetyLast2YearsFilePath { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? SafetyCurrentYearFilename { get; set; }

    public string? SafetyLast2YearsFilename { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? AreThereTrainingPlansForHSE { get; set; }

    public string? EvidenceOfTrainingPlanFilename { get; set; }

    public string? EvidenceOfTrainingPlanPath { get; set; }

    public string? Remark { get; set; }
}
