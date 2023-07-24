using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_QUALITY_CONTROL
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? DoyouhaveQualityControl { get; set; }

    public string? QualityControlFilePath { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? QualityControlFilename { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? Valid_Accreditation_Letter_For_QualityControl { get; set; }
}
