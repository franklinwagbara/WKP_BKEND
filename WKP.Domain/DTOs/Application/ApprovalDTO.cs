using WKP.Domain.Entities;

namespace WKP.Domain.DTOs.Application
{
    public class ApprovalDTO
    {
        public string PermitNo { get; set; } = null!;
        public string ApprovalNumber { get; set; } = null!;
        public int AppID { get; set; }
        public int CompanyID { get; set; }
        public int? ElpsID { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpired { get; set; }
        public bool? IsRenewed { get; set; }
        public bool IsPrinted { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Domain.Entities.Application? Application { get; set; }
        public ADMIN_COMPANY_INFORMATION? Company { get; set; }
    }
}