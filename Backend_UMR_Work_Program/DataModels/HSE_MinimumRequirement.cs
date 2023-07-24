using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_MinimumRequirement
{
    public int Id { get; set; }

    public string? Is_Company_ISO45001_Certified { get; set; }

    public string? Provide_ISO45001_Certification_No { get; set; }

    public int? CompanyNumber { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? ConcessionID { get; set; }

    public int? FieldID { get; set; }

    public int? Year { get; set; }
}
