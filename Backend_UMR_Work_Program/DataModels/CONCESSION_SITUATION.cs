using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class CONCESSION_SITUATION
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year { get; set; }

    public string? Concession_Held { get; set; }

    public string? Area { get; set; }

    public string? No_of_discovered_field { get; set; }

    public string? No_of_field_producing { get; set; }

    public string? Name_of_Company { get; set; }

    public string? Equity_distribution { get; set; }

    public string? Contract_Type { get; set; }

    public string? Geological_location { get; set; }

    public string? Has_Signature_Bonus_been_paid { get; set; }

    public string? If_No_why_sig { get; set; }

    public string? Has_the_Concession_Rentals_been_paid { get; set; }

    public string? If_No_why_concession { get; set; }

    public string? Is_there_an_application_for_renewal { get; set; }

    public string? If_No_why_renewal { get; set; }

    public string? Budget_actual_for_license_or_lease { get; set; }

    public string? proposed_budget_for_each_license_lease { get; set; }

    public string? Five_year_proposal { get; set; }

    public string? Did_you_meet_the_minimum_work_programme { get; set; }

    public string? Comment { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public DateTime? Date_of_Grant_Expiration { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public DateTime? Date_of_Expiration { get; set; }

    public string? How_Much_Signature_Bonus_have_been_paid_USD { get; set; }

    public string? How_Much_Concession_Rental_have_been_paid_USD { get; set; }

    public string? How_Much_Renewal_Bonus_have_been_paid_USD { get; set; }

    public string? Has_Assignment_of_Interest_Fee_been_paid { get; set; }

    public string? relinquishment_retention { get; set; }

    public string? area_in_square_meter_based_on_company_records { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public string? Field_Name { get; set; }

    public int? AdminConcession_ID { get; set; }

    public int? Field_ID { get; set; }
}
