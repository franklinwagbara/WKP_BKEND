using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class COMPANY_CONCESSIONS_FIELD
{
    public int Id { get; set; }

    public int? CompanyNumber { get; set; }

    public string? Concession_Name { get; set; }

    public string? Field_Name { get; set; }

    public DateTime? Created_On { get; set; }
}
