namespace Backend_UMR_Work_Program.DataModels
{
    public class EnagementScheduledHistory
    {
        public int Id { get; set; }
        public string? wp_date { get; set; }

        public string? wp_time { get; set; }

        public string action { get; set; }

        public string actionBy { get; set; }

        public string comment { get; set; }

        public DateTime createdTime { get; set; }

        public int PresentationId { get;set; }
        public virtual ADMIN_DATETIME_PRESENTATION Presentation { get; set; }

        public EnagementScheduledHistory()
        {
            createdTime = DateTime.Now;
            action = "Scheduled Engagement";
            comment = "Request for an engangement";
        }

    }
}
