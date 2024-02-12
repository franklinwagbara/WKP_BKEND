using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels
{
    public class DECOMMISSIONING_ABANDONMENT
    {
        public int Id { get; set; }
        public int? OmlId { get; set; }
        public string? COMPANY_ID { get; set; }
        public string? CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string WpYear { get; set; }
        public int? FieldId { get; set; }
        public string ApprovalStatus { get; set; }
        public double ApprovalCostUsd { get; set; }
        public double AnnualObigationUsd { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        [NotMapped]
        public string? ConcessionName;
        [NotMapped]
        public string FieldName => Field?.Field_Name;
        [NotMapped]
        public string? ConcessionType;

        [NotMapped]
        public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }

        [ForeignKey(nameof(FieldId))]
        public COMPANY_FIELD? Field { get; set; }

            public DECOMMISSIONING_ABANDONMENT()
            {
                OmlId = 0;
                ApprovalCostUsd = 0;
                AnnualObigationUsd = 0;

            }
        }
}
