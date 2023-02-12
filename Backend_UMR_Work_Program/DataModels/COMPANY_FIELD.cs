using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels
{
    public partial class COMPANY_FIELD
    {
        public int Field_ID { get; set; }
        public int? CompanyNumber { get; set; }
        public int? Concession_ID { get; set; }
        public string? Field_Name { get; set; }
        public string? Field_Location { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public bool? DeletedStatus { get; set; }

        [NotMapped]
        public bool? isEditable {get; set;}
    }
}
