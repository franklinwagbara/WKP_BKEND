namespace WKP.Domain.DTOs.Application
{
    public class ApplicationDTO
    {
        public int Id {get; set;}
        public int? FieldID { get; set; }
        public int ConcessionID { get; set; }
        public string ConcessionName { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public string ReferenceNo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime SubmittedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int YearOfWKP { get; set; }
        public string? Last_SBU { get; set; }
        public string? SBU_Comment { get; set; }
        public string? Comment { get; set; }
        public string? SBU_Tables { get; set; }
    }
}