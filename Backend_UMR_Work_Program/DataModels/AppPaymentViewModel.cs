namespace Backend_UMR_Work_Program.DataModels
{
    public class AppPaymentViewModel
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int CompanyNumber { get; set; }
        public int? ConcessionId { get; set; }
        public int? FieldId { get; set; }
        public int TypeOfPayment { get; set; }
        public string AmountNGN { get; set; }
        public string AmountUSD { get; set; }
    }
}
