using System.ComponentModel.DataAnnotations.Schema;

namespace WKP.Domain.Entities
{
    public class AppStatus
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int CompanyId { get; set; }
        public int? FieldId { get; set; }
        public int ConcessionId { get; set; }
        public int? SBUId { get; set; }
        public int? DeskId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? InternalStatus {get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        //Navigation properties
        [ForeignKey(nameof(CompanyId))]
        public ADMIN_COMPANY_INFORMATION? Company { get; set; }

        [ForeignKey(nameof(ConcessionId))]
        public ADMIN_CONCESSIONS_INFORMATION? Concession { get; set; }

        [ForeignKey(nameof(FieldId))]
        public COMPANY_FIELD? Field { get; set; }

        [ForeignKey(nameof(SBUId))]
        public StrategicBusinessUnit? SBU { get; set; }

        [ForeignKey(nameof(DeskId))]
        public MyDesk? Desk { get; set; }
    }
}