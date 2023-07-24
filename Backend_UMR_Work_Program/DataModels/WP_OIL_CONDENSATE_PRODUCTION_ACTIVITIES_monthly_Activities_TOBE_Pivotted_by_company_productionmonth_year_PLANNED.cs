using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year_PLANNED
{
    public string? CompanyName { get; set; }

    public string? Production_month { get; set; }

    public int? Annual_Total_Production_by_company_name { get; set; }

    public string? Year_of_WP { get; set; }
}
