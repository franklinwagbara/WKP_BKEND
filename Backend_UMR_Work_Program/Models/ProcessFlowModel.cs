namespace Backend_UMR_Work_Program.Models
{
	public class ProcessFlowModel
	{
		public List<int?> TriggeredBySUBId { get; set; }
		public List<int?> TriggeredByRoleId { get; set; }
		public List<int?> TargetedBySUBId { get; set; }
		public List<int?> TargetedByRoleId { get; set; }


	}
}
