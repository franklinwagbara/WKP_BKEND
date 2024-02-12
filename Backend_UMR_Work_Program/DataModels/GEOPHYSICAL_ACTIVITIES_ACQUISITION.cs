using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class GEOPHYSICAL_ACTIVITIES_ACQUISITION
{
    public int Geophysical_ActivitiesId { get; set; }

    public string? Geo_acquired_geophysical_data { get; set; }

    public string? Geo_area_of_coverage { get; set; }

    public string? Geo_method_of_acquisition { get; set; }

    public string? Geo_type_of_data_acquired { get; set; }

    public string? Geo_Record_Length_of_Data { get; set; }

    public string? Geo_Completion_Status { get; set; }

    public string? Quantum { get; set; }

    public string? Quantum_carry_forward { get; set; }

    public string? Geo_Activity_Timeline { get; set; }

    public string? Remarks { get; set; }

    public string? Actual_year_aquired_data { get; set; }

    public string? proposed_year_data { get; set; }

    public string? Budeget_Allocation { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Budeget_Allocation_NGN { get; set; }

    public string? Budeget_Allocation_USD { get; set; }

    public string? Name_of_Contractor { get; set; }

    public string? Quantum_Approved { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? Quantum_Planned { get; set; }

    public string? Gas_flare_Royalty_payment { get; set; }

    public string? Gas_Sales_Royalty_Payment { get; set; }

    public string? QUATER { get; set; }

    public string? COMPANY_ID { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }

    public int? No_of_Folds { get; set; }


    ///
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
