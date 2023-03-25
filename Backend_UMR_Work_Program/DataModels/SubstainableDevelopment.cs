using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class SubstainableDevelopment
{
    public int Substainable_DevelopmentId { get; set; }

    public string? Descript_of_Project_Planned { get; set; }

    public string? Descript_of_Project_Actual { get; set; }
}
