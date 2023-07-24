using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class TrainingForStaff
{
    public int Training_For_StaffId { get; set; }

    public int? Mgt_Staff_Local { get; set; }

    public int? Mgt_Staff_Foreign { get; set; }

    public int? Senior_Staff_Local { get; set; }

    public int? Senior_Staff_Foreign { get; set; }

    public int? Junior_Staff_Local { get; set; }

    public int? Junior_Staff_Foreign { get; set; }

    public int? Partner_Staff_Local { get; set; }

    public int? Partner_Staff_Foreign { get; set; }

    public int? Regulator_Staff_Local { get; set; }

    public int? Regulator_Staff_Foreign { get; set; }
}
