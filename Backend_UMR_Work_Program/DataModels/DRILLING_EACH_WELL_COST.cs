using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class DRILLING_EACH_WELL_COST
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? well_name { get; set; }

    public string? well_cost { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? QUATER { get; set; }

    public string? Surface_cordinates_for_each_well_in_degrees { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
