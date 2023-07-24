using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? CONCEPT_planned { get; set; }

    public string? CONCEPT_Actual { get; set; }

    public string? FEED_planned { get; set; }

    public string? FEED_COST_Actual { get; set; }

    public string? DETAILED_ENGINEERING_planned { get; set; }

    public string? DETAILED_ENGINEERING_Actual { get; set; }

    public string? PROCUREMENT_planned { get; set; }

    public string? PROCUREMENT_Actual { get; set; }

    public string? CONSTRUCTION_FABRICATION_planned { get; set; }

    public string? CONSTRUCTION_FABRICATION_Actual { get; set; }

    public string? INSTALLATION_planned { get; set; }

    public string? INSTALLATION_Actual { get; set; }

    public string? UPGRADE_MAINTENANCE_planned { get; set; }

    public string? UPGRADE_MAINTENANCE_Actual { get; set; }

    public string? DECOMMISSIONING_ABANDONMENT { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
