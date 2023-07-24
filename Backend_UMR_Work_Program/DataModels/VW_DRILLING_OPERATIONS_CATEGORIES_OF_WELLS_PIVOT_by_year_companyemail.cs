using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year_companyemail
{
    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public int? Exploration_Actual { get; set; }

    public int? Development_Actual { get; set; }

    public int? Appraisal_Actual { get; set; }

    public int? Exploration_Proposed { get; set; }

    public int? Development_Proposed { get; set; }

    public int? Appraisal_Proposed { get; set; }
}
