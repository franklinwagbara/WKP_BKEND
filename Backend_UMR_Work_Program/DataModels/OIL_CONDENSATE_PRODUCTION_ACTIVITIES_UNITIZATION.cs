using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Current_year_Actual { get; set; }

    public string? Deferment { get; set; }

    public string? Forecast { get; set; }

    public string? Remarks { get; set; }

    public string? Cost_Barrel { get; set; }

    public string? Company_Timeline { get; set; }

    public string? Company_Oil { get; set; }

    public string? Company_Condensate { get; set; }

    public string? Company_AG { get; set; }

    public string? Company_NAG { get; set; }

    public string? Fiveyear_Timeline { get; set; }

    public string? Fiveyear_Oil { get; set; }

    public string? Fiveyear_Condensate { get; set; }

    public string? Fiveyear_AG { get; set; }

    public string? Fiveyear_NAG { get; set; }

    public string? Did_you_carry_out_any_well_test { get; set; }

    public string? Type_of_Test { get; set; }

    public string? Maximum_Efficiency_Rate { get; set; }

    public string? Number_of_Test_Carried_out { get; set; }

    public string? Number_of_Producing_Wells { get; set; }

    public string? Daily_Production_ { get; set; }

    public string? Is_any_of_your_field_straddling { get; set; }

    public string? How_many_fields_straddle { get; set; }

    public string? Straddling_Fields_OC { get; set; }

    public string? Prod_Status_OC { get; set; }

    public string? Straddling_Field_OP { get; set; }

    public string? Company_Name_OP { get; set; }

    public string? Prod_Status_OP { get; set; }

    public string? Has_DPR_been_notified { get; set; }

    public string? Has_the_other_party_been_notified { get; set; }

    public string? Has_the_CA_been_signed { get; set; }

    public string? Committees_been_inaugurated { get; set; }

    public string? Participation_been_determined { get; set; }

    public string? Has_the_PUA_been_signed { get; set; }

    public string? Is_there_a_Joint_Development { get; set; }

    public string? Has_the_UUOA_been_signed { get; set; }

    public string? Actual_year { get; set; }

    public string? proposed_year { get; set; }

    public string? Created_by { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Total_Reconciled_National_Crude_Oil_Production { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public string? Consession_Type { get; set; }

    public string? Oil_Royalty_Payment { get; set; }

    public string? straddle_field_producing { get; set; }

    public string? what_concession_field_straddling { get; set; }

    public string? PUAUploadFilePath { get; set; }

    public string? UUOAUploadFilePath { get; set; }

    public string? PUAUploadFilename { get; set; }

    public string? UUOAUploadFilename { get; set; }

    public string? COMPANY_ID { get; set; }

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
