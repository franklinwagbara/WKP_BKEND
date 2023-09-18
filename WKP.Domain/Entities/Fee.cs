namespace WKP.Domain.Entities
{
    public class Fee
    {
        public int Id { get; set; }
        public string AmountNGN { get; set; } = string.Empty;
        public string AmountUSD { get; set; } = string.Empty;
        public int TypeOfPaymentId { get; set; } 
        public TypeOfPayments? TypeOfPayment { get; set; }

        public static class NavigationProperty
        {
            public static string TypeOfPayments = "TypeOfPayment";
        }
    }
}