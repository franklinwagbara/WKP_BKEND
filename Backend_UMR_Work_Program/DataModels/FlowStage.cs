namespace Backend_UMR_Work_Program.DataModels
{
	public class FlowStage
	{
		public int Id { get; set; }
		public string? Action { get; set; }
		public int? SBUId { get; set; }
		public string? Status { get; set; }
		public int? TargetedRole { get; set; }
		public int? TargetedSBU { get; set; }
		public bool? IsArchived { get; set; }
		public int? TriggeredByRole { get; set; }
		public int? TriggeredBySBU { get; set; }
	}
}
