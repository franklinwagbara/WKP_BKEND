using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Geophysical_Activity
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Actual_Year_Acquired { get; set; }

    public string? Proposed_Year { get; set; }

    public string? Budget_Allocation { get; set; }

    public string? Any_acquired_geophysical_data { get; set; }

    public string? Area_of_Coverage { get; set; }

    public string? Method_of_Acquisition { get; set; }

    public string? Type_of_Data_Acquired { get; set; }

    public string? Quantum_of_Data { get; set; }

    public string? Quantum_Carry_Forward { get; set; }

    public string? Record_Length_of_Data { get; set; }

    public string? Completion_Status { get; set; }

    public string? Activity_Timeline { get; set; }

    public string? Remarks { get; set; }

    public string? Actual_Processed_Reprocessed_Interpreted_data { get; set; }

    public string? Proposed_year_processing { get; set; }

    public string? Budget_Allocation_pro { get; set; }

    public string? Any_Ongoing_Processing_Project { get; set; }

    public string? Type_of_Data_being_Processed { get; set; }

    public string? Quantum_of_Data_pro { get; set; }

    public string? Quantum_Carry_Forward_pro { get; set; }

    public string? Completion_Status_pro { get; set; }

    public string? Activity_Timeline_pro { get; set; }

    public string? Remarks_pro { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
