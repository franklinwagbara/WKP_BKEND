namespace Backend_UMR_Work_Program.DataModels
{
	public partial class SBU_Submission
	{
		public int Id { get; set; }
		public int AppId { get; set; }
		public int StaffID { get; set; }
		public int SBU_ID { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string? Comment { get; set; }
		public string? ProcessStatus { get; set; }
	}
}
