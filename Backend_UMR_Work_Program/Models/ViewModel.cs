namespace Backend_UMR_Work_Program.Models
{
	public class ViewModel
	{
		public class UserToken
		{
			public string? CompanyId { get; set; }
			public string? CompanyName { get; set; }
			public string? CompanyEmail { get; set; }
			public int? CompanyNumber { get; set; }
			public string? Name { get; set; }
			public string? ContractType { get; set; }
			public string? token { get; set; }
			public int code { get; set; }
			public string? pass { get; set; }
		}

		public class CompanyDetail
		{
			public string? CompanyId { get; set; }
			public string? CompanyName { get; set; }
			public string? CompanyEmail { get; set; }
			public string? OPEN_DATE { get; set; }
			public string? CLOSE_DATE { get; set; }
			public string? my_open_date { get; set; }
			public string? my_close_date { get; set; }
			public string? Address_of_Company { get; set; }
			public string? Contact_Person { get; set; }
			public string? Phone_No { get; set; }
			public string? Email_Address { get; set; }
			public string? Name_of_MD_CEO { get; set; }
			public string? Phone_NO_of_MD_CEO { get; set; }
			public string? Alternate_Contact_Person { get; set; }
			public string? Phone_No_alt { get; set; }
			public string? Email_Address_alt { get; set; }
			public string? system_date_year { get; set; }
			public string? system_date { get; set; }
			public string? system_date_proposed_year { get; set; }
			public int? tin_Number { get; set; }
			public string? rC_Number { get; set; }
			public string? year_Incorporated { get; set; }
			public string? contact_LastName { get; set; }
			public string? contact_FirstName { get; set; }
		}

		public class Logine
		{
			public string? email { get; set; }
			public string? code { get; set; }
			public string? password { get; set; }
		}

		public class CreateUser
		{
			public string? companyName { get; set; }
			public string? companyCode { get; set; }
			public string? name { get; set; }
			public string? designation { get; set; }
			public string? phone { get; set; }
			public string? email { get; set; }
			public string? password { get; set; }
		}
		public class Admin_Reps
		{
			public DateTime? Date_Updated { get; set; }
			public string? REPRESENTATIVE { get; set; }
			public string? REPRESENTATIVE_EMAIL { get; set; }
		}
	}
}
