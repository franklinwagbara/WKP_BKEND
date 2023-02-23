using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_OCCUPATIONAL_HEALTH_MANAGEMENT
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? OHMplanFilePath { get; set; }

    public string? OHMplanCommunicationFilePath { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Consession_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Contract_Type { get; set; }

    public string? OHMplanFilename { get; set; }

    public string? OHMplanCommunicationFilename { get; set; }

    public string? SMSFileUploadname { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public string? ReasonWhyOhmWasNotCommunicatedToStaff { get; set; }

    public string? WasOhmPolicyCommunicatedToStaff { get; set; }

    public string? ReasonForNoOhm { get; set; }

    public string? DoYouHaveAnOhm { get; set; }
}
