using Backend_UMR_Work_Program.Models;

namespace Backend_UMR_Work_Program.DTOs
{
    public class FeeDTO
    {
        public int Id { get; set; }
        public string AmountNGN { get; set; }
        public string AmountUSD { get; set; }
        public int TypeOfPaymentId { get; set; }
    }
}
