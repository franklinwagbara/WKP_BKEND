using Backend_UMR_Work_Program.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int CompanyNumber { get; set; }
        public int? ConcessionId { get; set; }
        public int? FieldId { get; set; }
        public int TypeOfPaymentId { get; set; }
        public string? AmountNGN { get; set; }
        public string? AmountUSD { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionId { get; set; }
        public string? RRR { get; set; }
        public string? Description { get; set; }
        public string? AppReceiptId { get; set; }
        public string? TXNMessage { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankCode { get; set; }
        public string? Status { get; set; }
        public string? Currency { get; set; }
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("TypeOfPaymentId")]
        public TypeOfPayments PaymentType { get; set; }
        public string? RemitaResponse { get; set; }
        public string? RemitaRequest { get; set; }

        public string? OrderId { get; set; }

        public string? ServiceCharge { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public bool? IsConfirmed { get; set; }

        public string? PaymentEvidenceFilePath { get; set; }
        public string? PaymentEvidenceFileName { get; set; }

        public Payments()
        {
            IsConfirmed = false;
        }
    }
}
