using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ApplicationCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? FriendlyName { get; set; }

    public int? Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? DeleteStatus { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
}
