using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Sum_GEOPHYSICAL_ACTIVITIES_PROCESSING
{
    public string? CompanyName { get; set; }

    public string? OML_Name { get; set; }

    public string? Terrain { get; set; }

    public string? Name_of_Contractor { get; set; }

    public double? Quantum_Approved { get; set; }

    public double? Quantum_Processed { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Geo_Type_of_Data_being_Processed { get; set; }
}
