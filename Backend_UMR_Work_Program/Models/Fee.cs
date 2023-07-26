using Backend_UMR_Work_Program.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_UMR_Work_Program.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public string AmountNGN { get; set; }
        public string AmountUSD { get; set; }
        public int TypeOfPaymentId { get; set; }
        public TypeOfPayments TypeOfPayment { get; set; }
    }
}
