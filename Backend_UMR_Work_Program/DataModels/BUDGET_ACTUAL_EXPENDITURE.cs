using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class BUDGET_ACTUAL_EXPENDITURE
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Budget_for_Direct_Exploration_and_Production_Activities { get; set; }

    public string? Budget_for_other_Activities { get; set; }

    public string? Equivalent_Naira_and_Dollar_Component_ { get; set; }

    public string? Actual_year { get; set; }

    public string? Proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Budget_for_Direct_Exploration_and_Production_Activities_NGN { get; set; }

    public string? Budget_for_Direct_Exploration_and_Production_Activities_USD { get; set; }

    public string? Budget_for_other_Activities_NGN { get; set; }

    public string? Budget_for_other_Activities_USD { get; set; }

    public string? Equivalent_Naira_and_Dollar_Component_NGN { get; set; }

    public string? Equivalent_Naira_and_Dollar_Component_USD { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
