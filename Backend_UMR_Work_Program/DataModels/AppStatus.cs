using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels
{
    public class AppStatus
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int CompanyId { get; set; }
        public int FieldId { get; set; }
        public int ConcessionId { get; set; }
        public int SBUID { get; set; }
        public int DeskId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Navigation properties
        [ForeignKey(nameof(CompanyId))]
        public ADMIN_COMPANY_INFORMATION Company { get; set; }

        [ForeignKey(nameof(ConcessionId))]
        public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }

        [ForeignKey(nameof(FieldId))]
        public COMPANY_FIELD Field { get; set; }

        [ForeignKey(nameof(SBUID))]
        public StrategicBusinessUnit SBU { get; set; }

        [ForeignKey(nameof(DeskId))]
        public MyDesk Desk { get; set; }
    }
}
