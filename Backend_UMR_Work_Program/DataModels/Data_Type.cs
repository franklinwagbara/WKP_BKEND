using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Data_Type
{
    public int DataTypeId { get; set; }

    public string? DataType { get; set; }

    public string? Created_by { get; set; }

    public DateTime? Date_Created { get; set; }
}
