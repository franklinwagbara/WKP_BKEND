using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.DataModels
{
    public class ReturnedApplication
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string Comment { get; set; }

        [ForeignKey("AppId")]
        public Application Application { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StaffId { get; set; }
        public staff Staff { get; set; }
        public string SelectedTables { get; set; }

        public ReturnedApplication()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
