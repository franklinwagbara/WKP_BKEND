namespace WKP.Domain.Entities
{
    public class Application
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

		public ADMIN_CONCESSIONS_INFORMATION? Concession { get; set; }
		public ADMIN_COMPANY_INFORMATION? Company { get; set; }
		public COMPANY_FIELD? Field { get; set; }

		public static class NavigationProperty
        {
            public static string Concession = "Concession";
            public static string Company = "Company";
            public static string Field = "Field";
        }

		//To track application processing stages
		//public string ProcessingStage { get; set; } = null!;
	}
}