using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class FIELD_DEVELOPMENT_PLAN
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? How_many_fields_have_FDP { get; set; }

    public string? List_all_the_field_with_FDP { get; set; }

    public string? Which_fields_do_you_plan_to_submit_an_FDP { get; set; }

    public string? How_many_fields_have_approved_FDP { get; set; }

    public string? Number_of_wells_proposed_in_the_FDP { get; set; }

    public string? No_of_wells_drilled_in_current_year { get; set; }

    public string? Proposed_number_of_wells_from_approved_FDP { get; set; }

    public string? Processing_Fees_paid { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? how_many_fields_in_concession { get; set; }

    public string? Noof_Producing_Fields { get; set; }

    public string? Uploaded_approved_FDP_Document { get; set; }

    public string? Are_they_oil_or_gas_wells { get; set; }

    public string? FDPDocumentFilename { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? Status { get; set; }
}
