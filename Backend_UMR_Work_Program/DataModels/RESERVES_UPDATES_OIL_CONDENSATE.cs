using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class RESERVES_UPDATES_OIL_CONDENSATE
{
    public int Id { get; set; }

    public string? OML_ID { get; set; }

    public string? OML_Name { get; set; }

    public string? CompanyName { get; set; }

    public string? Companyemail { get; set; }

    public string? Year_of_WP { get; set; }

    public string? Reserves_as_at_MMbbl_P1 { get; set; }

    public string? Additional_Reserves_as_at_ { get; set; }

    public string? Total_Production_ { get; set; }

    public string? Reserves_as_at_MMbbl { get; set; }

    public string? Company_Reserves_Year { get; set; }

    public string? Company_Reserves_Oil { get; set; }

    public string? Company_Reserves_Condensate { get; set; }

    public string? Company_Reserves_AG { get; set; }

    public string? Company_Reserves_NAG { get; set; }

    public string? Company_Reserves_AnnualOilProduction { get; set; }

    public string? Company_Current_Year { get; set; }

    public string? Company_Current_Oil { get; set; }

    public string? Company_Current_Condensate { get; set; }

    public string? Company_Current_AG { get; set; }

    public string? Company_Current_NAG { get; set; }

    public string? Company_Current_AnnualOilProduction { get; set; }

    public string? Fiveyear_Projection_Year { get; set; }

    public string? Fiveyear_Projection_Oil { get; set; }

    public string? Fiveyear_Projection_Condensate { get; set; }

    public string? Fiveyear_Projection_AG { get; set; }

    public string? Fiveyear_Projection_NAG { get; set; }

    public string? Fiveyear_Projection_AnnualOilProduction { get; set; }

    public string? Company_Annual_Year { get; set; }

    public string? Company_Annual_Oil { get; set; }

    public string? Company_Annual_Condensate { get; set; }

    public string? Company_Annual_AG { get; set; }

    public string? Company_Annual_NAG { get; set; }

    public string? Company_Annual_AnnualOilProduction { get; set; }

    public string? Reserves_Addition_Was_there_any_Reserve_Addition { get; set; }

    public string? Reserves_Addition_Reason_for_Addition { get; set; }

    public string? Reserves_Addition_Condensate { get; set; }

    public string? Reserves_Addition_AG { get; set; }

    public string? Reserves_Addition_NAG { get; set; }

    public string? Reserves_Addition_Oil { get; set; }

    public string? Reserves_Decline_Was_there_a_decline_in_reserve { get; set; }

    public string? Reserves_Decline_Reason_for_Decline { get; set; }

    public string? Reserves_Decline_Condensate { get; set; }

    public string? Reserves_Decline_AG { get; set; }

    public string? Reserves_Decline_NAG { get; set; }

    public string? Reserves_Decline_Oil { get; set; }

    public string? Reservoir_Performance_Timeline { get; set; }

    public string? Reservoir_Performance_Reservoir { get; set; }

    public string? Reservoir_Performance_Reservoir_Pressure { get; set; }

    public string? Reservoir_Performance_WCT { get; set; }

    public string? Reservoir_Performance_GOR { get; set; }

    public string? Reservoir_Performance_Sand_Cut { get; set; }

    public string? Consession_Type { get; set; }

    public string? Contract_Type { get; set; }

    public string? Terrain { get; set; }

    public int? CompanyNumber { get; set; }

    public int? Field_ID { get; set; }
}
