﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels;

public partial class staff
{
    public int StaffID { get; set; }

    public string? StaffElpsID { get; set; }

    public int? Staff_SBU { get; set; }

    public int? RoleID { get; set; }

    public int? LocationID { get; set; }

    public string? StaffEmail { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? ActiveStatus { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? DeleteStatus { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public string? SignaturePath { get; set; }

    public string? SignatureName { get; set; }

    public int? AdminCompanyInfo_ID { get; set; }

    [ForeignKey("Staff_SBU")]
    public StrategicBusinessUnit? StrategicBusinessUnit { get; set; }

    [NotMapped]
    private string _name;

    [NotMapped]
    public string? Name { get { return LastName + ", " + FirstName; } set { _name = value; } }

    //[ForeignKey("Id")]
    //public Role? Role { get; set; }
}
