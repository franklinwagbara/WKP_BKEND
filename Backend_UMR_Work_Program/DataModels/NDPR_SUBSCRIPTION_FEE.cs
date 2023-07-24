using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class NDPR_SUBSCRIPTION_FEE
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Has_annual_NDR_subscription_fee_been_paid { get; set; }

    public string? Did_you_process_data_for_current_year { get; set; }

    public string? Data_Type { get; set; }

    public string? Volume_of_data_processed { get; set; }

    public string? Actual_year { get; set; }

    public string? Proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
