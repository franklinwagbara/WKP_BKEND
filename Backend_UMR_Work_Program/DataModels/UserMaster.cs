using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class UserMaster
{
    public int UserId { get; set; }

    public string? UserEmail { get; set; }

    public string? UserType { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserRole { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }

    public DateTime? LastLogin { get; set; }

    public int? LoginCount { get; set; }

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CompanyName { get; set; }

    public int? DivisionId { get; set; }

    public string? Comment { get; set; }
}
