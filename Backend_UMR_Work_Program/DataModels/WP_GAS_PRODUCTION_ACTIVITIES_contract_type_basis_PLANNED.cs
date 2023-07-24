using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis_PLANNED
{
    public string? Contract_Type { get; set; }

    public int? Total_GAS_Production_by_company { get; set; }

    public string? Year_of_WP { get; set; }

    public int? Total_GAS_Production_by_year { get; set; }

    public decimal? Percentage_Production { get; set; }
}
