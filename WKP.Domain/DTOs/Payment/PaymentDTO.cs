namespace WKP.Domain.DTOs.Payment
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int CompanyNumber { get; set; }
        public int ConcessionId { get; set; }
        public int? FieldId { get; set; }
        public int TypeOfPayment { get; set; }
        public string AmountNGN { get; set; } = string.Empty;
        public string AmountUSD { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string? ServiceCharge { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}