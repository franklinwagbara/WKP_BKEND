using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ApplicationDocument
{
    public int? CategoryId { get; set; }

    public int AppDocID { get; set; }

    public int ElpsDocTypeID { get; set; }

    public string DocName { get; set; } = null!;

    public string DocType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool DeleteStatus { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
}
