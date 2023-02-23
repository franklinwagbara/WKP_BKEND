using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_CONCESSIONS_INFORMATION
{
    public int Consession_Id { get; set; }

    public string? Company_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? COMPANY_EMAIL { get; set; }

    public string? Concession_Unique_ID { get; set; }

    public string? Consession_Type { get; set; }

    public string? Equity_distribution { get; set; }

    public string? Concession_Held { get; set; }

    public string? Area { get; set; }

    public string? Contract_Type { get; set; }

    public string? Year_of_Grant_Award { get; set; }

    public DateTime? Date_of_Expiration { get; set; }

    public string? Geological_location { get; set; }

    public string? Comment { get; set; }

    public string? Status_ { get; set; }

    public string? Flag1 { get; set; }

    public string? Flag2 { get; set; }

    public string? Terrain { get; set; }

    public string? Year { get; set; }

    public string? submitted { get; set; }

    public string? OPEN_DATE { get; set; }

    public string? CLOSE_DATE { get; set; }

    public string? DELETED_STATUS { get; set; }

    public string? DELETED_BY { get; set; }

    public string? DELETED_DATE { get; set; }

    public string? EMAIL_REMARK { get; set; }

    public int? CompanyNumber { get; set; }

    public string? ConcessionName { get; set; }

    public string? Field_Name { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }
}
