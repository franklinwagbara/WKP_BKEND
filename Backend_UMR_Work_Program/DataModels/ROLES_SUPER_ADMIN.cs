﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class ROLES_SUPER_ADMIN
    {
        public int SN { get; set; }
        public string? Role_ { get; set; }
        public string? Email_ { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public string? Deleted_by { get; set; }
        public string? Deleted_Date { get; set; }
        public string? Deleted_status { get; set; }
        public string? Description { get; set; }
    }
}
