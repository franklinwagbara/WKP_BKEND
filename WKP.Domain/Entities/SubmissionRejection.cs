using System.ComponentModel.DataAnnotations.Schema;

namespace WKP.Domain.Entities
{
    public class SubmissionRejection
    {
        public int Id { get; set; }
        public string PermitNo { get; set; } = null!;
        public string RejectionNumber { get; set; } = null!;
        public int AppId { get; set; }
        public int CompanyId { get; set; }
        public int? ElpsID { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpired { get; set; }
        public bool? IsRenewed { get; set; }
        public bool IsPrinted { get; set; }
        public string? RejectedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public ADMIN_COMPANY_INFORMATION? Company { get; set; }

        [ForeignKey(nameof(AppId))]
        public Application? Application { get; set; }

    }
}