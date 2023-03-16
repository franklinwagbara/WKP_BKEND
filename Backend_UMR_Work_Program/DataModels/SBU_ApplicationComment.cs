using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class SBU_ApplicationComment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? SBU_ID { get; set; }

    public int? AppID { get; set; }

    public string? SBU_Comment { get; set; }

    public string? ActionStatus { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? Staff_ID { get; set; }

    public string? SBU_Tables { get; set; }
}
