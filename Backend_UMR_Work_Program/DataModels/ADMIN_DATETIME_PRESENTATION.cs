﻿using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.Models
{
    public partial class ADMIN_DATETIME_PRESENTATION
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
        public string? MOM { get; set; }
        public DateTime? MOM_UPLOAD_DATE { get; set; }
        public string? MOM_UPLOADED_BY { get; set; }
        public string? DATE_TIME_TEXT { get; set; }
        public string? DIVISION { get; set; }
        public string? PHONE_NO { get; set; }
        public string? LAST_RUN_DATE { get; set; }
        public string? EMAIL_REMARK { get; set; }
        public string? DAYS_TO_GO { get; set; }
        public DateTime? LAST_RUN_TIME { get; set; }
        public string? Date_Created_BY_COMPANY { get; set; }
        public int? CompanyNumber { get; set; }
    }
}
