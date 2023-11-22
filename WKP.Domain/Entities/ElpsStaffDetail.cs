namespace WKP.Domain.Entities
{
    public class ElpsStaffDetail
    {
        public int Id { get; set; }
		public int? elpsId { get; set; }
		public string? phoneNo { get; set; }
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		public string? email { get; set; }
    }
}