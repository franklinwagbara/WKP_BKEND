using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class NigerianContent
{
    public int Nigerian_ContentId { get; set; }

    public int? Mgt_Local { get; set; }

    public int? Mgt_Expatriates { get; set; }

    public int? Staff_Local { get; set; }

    public int? Staff_Expatriates { get; set; }

    public string? Valid_Expatriate { get; set; }

    public int? Nbr_of_Released_Staff { get; set; }

    public string? Reason_For_NonExpatriate { get; set; }

    public string? Succession_Plan_in_Place { get; set; }

    public string? Succession_PlanName { get; set; }

    public string? Succession_PlanTimeLine { get; set; }

    public string? Succession_PlanUnderStudy { get; set; }

    public string? Position_Occupied { get; set; }
}
