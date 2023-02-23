using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class Table_Detail
{
    public int TableId { get; set; }

    public string? TableName { get; set; }

    public string? TableSchema { get; set; }

    public string? SBU_ID { get; set; }
}
