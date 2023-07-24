using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ADMIN_DIVISIONAL_REPRESENTATIVE
{
    public int Id { get; set; }

    public string? COMPANYNAME { get; set; }

    public string? COMPANY_ID { get; set; }

    public string? PRESENTED { get; set; }

    public string? COMPANYEMAIL { get; set; }

    public string? MEETINGROOM { get; set; }

    public string? CHAIRPERSON { get; set; }

    public string? SCRIBE { get; set; }

    public string? STATUS { get; set; }

    public string? YEAR { get; set; }

    public DateTime? DATETIME_PRESENTATION { get; set; }

    public DateTime? CLOSE_DATE { get; set; }

    public string? CREATED_BY { get; set; }

    public string? Updated_by { get; set; }

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }

    public string? Submitted { get; set; }

    public string? wp_date { get; set; }

    public string? wp_time { get; set; }

    public string? CHAIRPERSONEMAIL { get; set; }

    public string? SCRIBEEMAIL { get; set; }

    public DateTime? OPEN_DATE { get; set; }

    public string? DIV_REP_NAME { get; set; }

    public string? DIV_REP_DIV { get; set; }

    public string? DIV_REP_EMAIL { get; set; }

    public int? CompanyNumber { get; set; }
}
