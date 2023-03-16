namespace Backend_UMR_Work_Program.DataModels
{
	public partial class Application
	{
		public int Id { get; set; }
		public string ReferenceNo { get; set; } = null!;
		public int CompanyID { get; set; }
		public int? ConcessionID { get; set; }
		public int? FieldID { get; set; }
		public int CategoryID { get; set; }
		public int YearOfWKP { get; set; }
		public string Status { get; set; } = null!;
		public string PaymentStatus { get; set; } = null!;
		public int? CurrentDesk { get; set; }
		public bool? Submitted { get; set; }
		public string? ApprovalRef { get; set; }
		public string? CurrentUserEmail { get; set; }
		public int? FlowStageId { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? SubmittedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public int? DeletedBy { get; set; }
		public bool? DeleteStatus { get; set; }
		public DateTime? DeletedAt { get; set; }

		//To track application processing stages
		//public string ProcessingStage { get; set; } = null!;
	}
}
