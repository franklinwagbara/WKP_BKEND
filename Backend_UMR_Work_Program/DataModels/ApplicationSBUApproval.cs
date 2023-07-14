using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_UMR_Work_Program.DataModels
{
    public partial class ApplicationSBUApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AppId { get; set; }
        public int? StaffID { get; set; } 
        public string? Comment { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; } = default(DateTime?);
        public DateTime? UpdatedDate { get; set; }  
        public string? AppAction { get; set; }
        public int? DeskID { get; set; }
        public int? SBUID { get; set; }

        public staff Staff { get; set; }

        [ForeignKey(nameof(SBUID))]
        public StrategicBusinessUnit SBU { get; set; }
    }
}
