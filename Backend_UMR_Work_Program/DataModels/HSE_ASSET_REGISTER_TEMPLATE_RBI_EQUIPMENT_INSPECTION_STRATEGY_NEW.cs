using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? facility { get; set; }

    public string? Equipment_type { get; set; }

    public string? Equipment_description { get; set; }

    public string? Equipment_serial_number { get; set; }

    public string? Equipment_tag_number { get; set; }

    public string? Equipment_manufacturer { get; set; }

    public DateTime? Equipment_Installation_date { get; set; }

    public DateTime? Last_inspection_date { get; set; }

    public string? Last_Inspection_Type_Performed { get; set; }

    public string? Likelihood_of_Failure { get; set; }

    public string? Consequence_of_Failure { get; set; }

    public string? Maximum_Inspection_Interval { get; set; }

    public DateTime? Next_Inspection_Date { get; set; }

    public string? Proposed_Inspection_Type { get; set; }

    public DateTime? RBI_Assessment_Date { get; set; }

    public string? Equipment_Inspected_as_and_when_due { get; set; }

    public string? State_reason { get; set; }

    public string? Condition_of_Equipment { get; set; }

    public string? Function_Test_Result { get; set; }

    public string? Inspection_Report_Review { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
