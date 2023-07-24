using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Year_of_Proposal { get; set; }

    public string? Budget_for_Direct_Exploration_and_Production_Activities_Naira { get; set; }

    public string? Budget_for_Direct_Exploration_and_Production_Activities_Dollars { get; set; }

    public string? Budget_for_other_Activities_Naira { get; set; }

    public string? Budget_for_other_Activities_Dollars { get; set; }

    public string? Total_Company_Expenditure_Dollars { get; set; }

    public string? Actual_year { get; set; }

    public string? Proposed_year { get; set; }

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
