namespace WKP.Domain.Entities
{
    public class CompanyProfile
    {
        public string user_Id { get; set; }
        public string name { get; set; }
        public string business_Type { get; set; }
        public int registered_Address_Id { get; set; }
        public int operational_Address_Id { get; set; }
        public string affiliate { get; set; }
        public string nationality { get; set; }
        public string contact_FirstName { get; set; }
        public string contact_LastName { get; set; }
        public string contact_Phone { get; set; }
        public string year_Incorporated { get; set; }
        public string rC_Number { get; set; }
        public string tin_Number { get; set; }
        public int no_Staff { get; set; }
        public int no_Expatriate { get; set; }
        public string total_Asset { get; set; }
        public string yearly_Revenue { get; set; }
        public int accident { get; set; }
        public string accident_Report { get; set; }
        public string training_Program { get; set; }
        public string mission_Vision { get; set; }
        public string hse { get; set; }
        public string hseDoc { get; set; }
        public DateTime date { get; set; }
        public string isCompleted { get; set; }
        public int elps_Id { get; set; }
        public int parentCompanyId { get; set; }
        public bool isAffiliate { get; set; }
        public int id { get; set; }
    }
}