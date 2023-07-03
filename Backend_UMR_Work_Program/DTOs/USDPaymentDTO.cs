namespace Backend_UMR_Work_Program.DTOs
{
    public class USDPaymentDTO
    {
        public string CompanyEmail { get; set; }
        public int CompanyNumber { get; set; }
        public int ConcessionId { get; set; }
        public int? FieldId { get; set; }
        public string? AmountUSD { get; set; }
        public int Year { get; set; }
        public string? PaymentEvidenceFilePath { get; set; }
        public string? PaymentEvidenceFileName { get; set; }
    }
}
