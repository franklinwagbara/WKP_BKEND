using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELL
{
    public string? CompanyName { get; set; }

    public string? OML_Name { get; set; }

    public string? well_name { get; set; }

    public DateTime? spud_date { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Category { get; set; }

    public string? well_cost { get; set; }

    public string? Number_of_Days_to_Total_Depth { get; set; }

    public string? Well_Status_and_Depth { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }
}
