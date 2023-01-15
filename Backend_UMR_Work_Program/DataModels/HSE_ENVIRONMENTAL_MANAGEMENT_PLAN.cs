﻿namespace Backend_UMR_Work_Program.DataModels
{
	public class HSE_ENVIRONMENTAL_MANAGEMENT_PLAN
	{
		public int Id { get; set; }
		public int? Field_ID { get; set; }
		public string? OML_Name { get; set; }
		public string? OmL_ID { get; set; }
		public string? CompanyName { get; set; }
		public string? Companyemail { get; set; }
		public string? Year_of_WP { get; set; }
		public string? COMPANY_ID { get; set; }
		public int? CompanyNumber { get; set; }
		public string? AreThereEMP { get; set; }
		public string? FacilityType { get; set; }
		public string? FacilityLocation { get; set; }
		public string? RemarkIfNoEMP { get; set; }
		public DateTime? Date_Updated { get; set; }
		public string? Updated_by { get; set; }
		public DateTime? Date_Created { get; set; }
		public string? Created_by { get; set; }


	}
}
