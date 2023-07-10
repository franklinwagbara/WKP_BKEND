using Backend_UMR_Work_Program.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.Models
{
    public class AccountDesk
    {
        public int AccountDeskID { get; set; }
        public int? ProcessID { get; set; }
        public int AppId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Comment { get; set; }
        public DateTime LastJobDate { get; set; }
        public string? ProcessStatus { get; set; }
        public int StaffID { get; set; }
        public int PaymentId { get; set; }
        public bool isApproved { get; set; }


        public staff Staff { get; set; }

        [ForeignKey("PaymentId")]
        public Payments Payment { get; set; }

        public AccountDesk()
        {
            isApproved = false;
            CreatedAt= DateTime.Now;
            AppId = 0;
        }
    }
}
