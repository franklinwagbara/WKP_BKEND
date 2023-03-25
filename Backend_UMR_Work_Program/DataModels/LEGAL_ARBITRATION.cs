using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class LEGAL_ARBITRATION
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? Consession_Type { get; set; }

    public string? AnyLitigation { get; set; }

    public string? Case_Number { get; set; }

    public string? Names_of_Parties { get; set; }

    public string? Jurisdiction { get; set; }

    public string? Name_of_Court { get; set; }

    public string? Summary_of_the_case { get; set; }

    public string? Any_orders_made_so_far_by_the_court { get; set; }

    public string? Potential_outcome { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
