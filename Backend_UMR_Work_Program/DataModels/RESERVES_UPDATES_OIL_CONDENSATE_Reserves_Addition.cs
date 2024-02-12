using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Reserves_Addition_Was_there_any_Reserve_Addition { get; set; }

    public string? Reserves_Addition_Reason_for_Addition { get; set; }

    public string? Reserves_Addition_Oil { get; set; }

    public string? Reserves_Addition_Condensate { get; set; }

    public string? Reserves_Addition_AG { get; set; }

    public string? Reserves_Addition_NAG { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }


    [NotMapped]
    public string? ConcessionName;
    [NotMapped]
    public string FieldName => Field?.Field_Name;
    [NotMapped]
    public string? ConcessionType;

    [NotMapped]
    public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }

    [ForeignKey(nameof(Field_ID))]
    public COMPANY_FIELD? Field { get; set; }
}
