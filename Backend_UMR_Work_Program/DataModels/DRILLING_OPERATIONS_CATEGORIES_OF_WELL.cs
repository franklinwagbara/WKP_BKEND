using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class DRILLING_OPERATIONS_CATEGORIES_OF_WELL
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Category { get; set; }

    public string? Actual_No_Drilled_in_Current_Year { get; set; }

    public string? Proposed_No_Drilled { get; set; }

    public string? Processing_Fees_Paid { get; set; }

    public string? Comments { get; set; }

    public string? No_of_wells_cored { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? well_type { get; set; }

    public string? well_trajectory { get; set; }

    public DateTime? spud_date { get; set; }

    public string? well_cost { get; set; }
    public string? well_cost_currency { get; set; }

    public string? Number_of_Days_to_Total_Depth { get; set; }

    public string? Well_Status_and_Depth { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? well_name { get; set; }

    public string? Consession_Type { get; set; }

    public string? QUATER { get; set; }

    public string? Any_New_Discoveries { get; set; }

    public string? Hydrocarbon_Counts { get; set; }

    public string? State_the_field_where_Discovery_was_made { get; set; }

    public string? Core_Cost_USD { get; set; }

    public string? Core_Cost_Currency { get; set; }

    public string? Core_Depth_Interval { get; set; }

    public string? Propose_well_names { get; set; }

    public string? Actual_wells_name { get; set; }

    public string? Terrain_Drill { get; set; }

    public string? Water_depth { get; set; }

    public string? True_vertical_depth { get; set; }

    public string? Depth_refrence { get; set; }

    public string? Rig_type { get; set; }

    public string? Rig_Name { get; set; }

    public string? Target_reservoir { get; set; }

    public string? Surface_cordinates_for_each_well_in_degrees { get; set; }

    public string? Location_name { get; set; }

    public string? Proposed_cost_per_well { get; set; }

    public string? Basin { get; set; }

    public string? Measured_depth { get; set; }

    public string? FieldDiscoveryUploadFilePath { get; set; }

    public string? HydrocarbonCountUploadFilePath { get; set; }

    public string? COMPANY_ID { get; set; }

    public string? Cored { get; set; }

    public string? Actual_Proposed { get; set; }

    public string? WellName { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    [NotMapped]
    public string? ConcessionName;
    [NotMapped]
    public string FieldName => Field?.Field_Name;
    [NotMapped]
    public string? ConcessionType;

    [NotMapped]
    public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }

    [ForeignKey(nameof(Field_ID))]
    public COMPANY_FIELD? Field { get; set; }
}
