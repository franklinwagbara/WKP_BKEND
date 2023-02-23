using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_COMPLIANCE_INDEX_TABLE
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? Consession_Type { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Divisions { get; set; }

    public string? Penalty_Factor_for_Warning { get; set; }

    public string? Number_of_Occurrence_of_Warnings { get; set; }

    public string? Penalty_Factor_for_Sanction { get; set; }

    public string? Number_of_Occurrence_of_Sanctions { get; set; }

    public string? Penalty_Factor_for_Waivers { get; set; }

    public string? Number_of_Occurrence_of_Waivers { get; set; }

    public string? Compliance_index_for_each_division { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public int? CompanyNumber { get; set; }
}
