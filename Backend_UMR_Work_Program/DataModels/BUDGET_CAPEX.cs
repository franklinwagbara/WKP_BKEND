using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class BUDGET_CAPEX
{
    public int ID { get; set; }

    public string? OmL_Name { get; set; }

    public string? OmL_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Company_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public string? Acquisition { get; set; }

    public string? Processing { get; set; }

    public string? Reprocessing { get; set; }

    public string? Exploratory_Well_Drilling { get; set; }

    public string? Appraisal_Well_Drilling { get; set; }

    public string? Development_Well_Drilling { get; set; }

    public string? Workover_Operations { get; set; }

    public string? Completions { get; set; }

    public string? Flowlines { get; set; }

    public string? Pipelines { get; set; }

    public string? Generators { get; set; }

    public string? Turbines_Compressors { get; set; }

    public string? Buildings { get; set; }

    public string? Other_Equipment { get; set; }

    public string? Civil_Works { get; set; }

    public string? Other_Costs { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public int? Field_ID { get; set; }
}
