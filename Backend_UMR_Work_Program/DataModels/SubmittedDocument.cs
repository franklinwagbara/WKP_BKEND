using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class SubmittedDocument
{
    public int SubDocID { get; set; }

    public int? AppID { get; set; }

    public int? LocalDocID { get; set; }

    public int? ElpsDocID { get; set; }

    public int? YearOfWKP { get; set; }

    public string? DocSource { get; set; }

    public string? DocumentCategory { get; set; }

    public string? DocumentName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
