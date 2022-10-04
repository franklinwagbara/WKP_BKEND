﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class ADMIN_PERFOMANCE_INDEX
    {
        public int Id { get; set; }
        public string? INDICATOR { get; set; }
        public string? INDEX_TYPE { get; set; }
        public string? Graduation_Scale { get; set; }
        public string? Weight { get; set; }
        public string? CONCESSIONTYPE { get; set; }
        public string? Created_by { get; set; }
        public string? Updated_by { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
    }
}