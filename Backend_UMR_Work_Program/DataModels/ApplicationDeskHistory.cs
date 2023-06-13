namespace Backend_UMR_Work_Program.DataModels
{
	public partial class ApplicationDeskHistory
	{
		public int Id { get; set; }
		public int AppId { get; set; }
		public int? StaffID { get; set; }
		public string Comment { get; set; } = null!;
		public string Status { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public string? AppAction { get; set; }
		public DateTime ActionDate { get; set; }
		public string? SelectedTables { get; set; }
		public int? TriggeredBySBU { get; set; }
		public int? TriggeredByRole { get; set; }
		public string? Message { get; set; }
		public int? TargetedToSBU { get; set; }
		public int? TargetedToRole { get; }
		public int? FlowStageId { get; }

		public bool? ActionByCompany { get; set; }
		public int? CompanyId { get; set; }
	}
}
