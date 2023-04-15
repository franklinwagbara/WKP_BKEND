namespace Backend_UMR_Work_Program.DataModels
{
    public class DECOMMISSIONING_ABANDONMENT
    {
        public int Id { get; set; }
        public int? OmlId { get; set; }
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

        public DECOMMISSIONING_ABANDONMENT()
        {
            OmlId = 0;
            ApprovalCostUsd = 0;
            AnnualObigationUsd = 0;

        }
    }
}
