namespace WKP.Contracts.Features.Account
{
    public sealed class UpdateCompanyDetailsRequest
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
}