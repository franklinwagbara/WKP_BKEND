﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class ADMIN_WORK_PROGRAM_REPORT
    {
        public int Id { get; set; }
        public string? Report_Content { get; set; }
        public string? Report_Content_ { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
    }
}
