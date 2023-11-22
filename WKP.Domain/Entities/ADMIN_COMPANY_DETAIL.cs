namespace WKP.Domain.Entities
{
    public class ADMIN_COMPANY_DETAIL
    {
        public int Id { get; set; }
        public string? COMPANY_NAME { get; set; }
        public string? EMAIL { get; set; }
        public string? Address_of_Company { get; set; }
        public string? Name_of_MD_CEO { get; set; }
        public string? Phone_NO_of_MD_CEO { get; set; }
        public string? Contact_Person { get; set; }
        public string? Phone_No { get; set; }
        public string? Email_Address { get; set; }
        public string? Alternate_Contact_Person { get; set; }
        public string? Phone_No_alt { get; set; }
        public string? Email_Address_alt { get; set; }
        public string? FLAG { get; set; }
        public string? Created_by { get; set; }
        public string? Date_Created { get; set; }
        public string? check_status { get; set; }
        public int? CompanyNumber { get; set; }
        public string? CompanyId { get; set; }
    }
}