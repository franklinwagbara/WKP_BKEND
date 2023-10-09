using WKP.Domain.Entities;

namespace WKP.Domain.DTOs.AccountDesk
{
    public class AccountDeskDTO
    {
        public int Year { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string ConcessionName { get; set;} = string.Empty;
        public string? FieldName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string? EvidenceFilePath { get; set; } = string.Empty;
        public string? EvidenceFileName { get; set; } = string.Empty;
        public Domain.Entities.AccountDesk? Desk { get; set; }
        public Payments? Payment { get; set; }
        public Domain.Entities.Application? Application { get; set; }
        public staff? Staff { get; set; } 
        public ADMIN_CONCESSIONS_INFORMATION? Concession { get; set; } 
        public COMPANY_FIELD? Field { get; set; } 
        public string? PaymentStatus { get; set; } = string.Empty;
        public DateTime? SubmittedAt { get; set; }
    }
}