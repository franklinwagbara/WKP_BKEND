using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoted
{
    public string? Contract_Type { get; set; }

    public decimal? Annual_Total_Production_by_CONTRACT_TYPE { get; set; }

    public string? Year_of_WP { get; set; }
}
