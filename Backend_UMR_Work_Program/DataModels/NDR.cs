using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class NDR
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? COMPANY_ID { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Has_annual_NDR_subscription_fee_been_paid { get; set; }

    public DateTime? When_was_the_date_of_your_last_NDR_submission { get; set; }

    public string? Upload_NDR_payment_receipt { get; set; }

    public string? Are_you_up_to_date_with_your_NDR_data_submission { get; set; }

    public string? NDRFilename { get; set; }

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
