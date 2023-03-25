using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class HSE_POINT_SOURCE_REGISTRATION
{
    public int Id { get; set; }

    public string? OML_Name { get; set; }

    public string? OML_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Company_Email { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Company_Number { get; set; }

    public string? Company_ID { get; set; }

    public string? are_there_point_source_permit { get; set; }

    public string? evidence_of_PSP_filename { get; set; }

    public string? evidence_of_PSP_path { get; set; }

    public string? reason_for_no_PSP { get; set; }

    public int? Field_ID { get; set; }
}
