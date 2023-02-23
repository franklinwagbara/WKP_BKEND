using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_SAFETY_STUDIES_NEW
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? ACTUAL_year { get; set; }

    public string? PROPOSED_year { get; set; }

    public string? Did_you_carry_out_safety_studies { get; set; }

    public string? State_Project_Name_for_which_studies_was_carried_out { get; set; }

    public string? List_the_studies { get; set; }

    public string? List_identified_Major_Accident_Hazards_for_the_study { get; set; }

    public string? List_the_Safeguards_based_on_the_identified_Major_Accident_Hazards { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? SMSFileUploadPath { get; set; }

    public string? DoyouhaveSMSinPlace { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
