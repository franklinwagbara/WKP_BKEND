using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT
{
    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Exploration_Actual { get; set; }

    public string? Development_Actual { get; set; }

    public string? Appraisal_Actual { get; set; }

    public string? Exploration_Proposed { get; set; }

    public string? Development_Proposed { get; set; }

    public string? Appraisal_Proposed { get; set; }
}
