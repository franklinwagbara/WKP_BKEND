namespace Backend_UMR_Work_Program.DataModels
{
    public class AppStatus
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int CompanyId { get; set; }
        public int FieldId { get; set; }
        public int ConcessionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
