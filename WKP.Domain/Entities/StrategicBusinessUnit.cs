namespace WKP.Domain.Entities
{
    public class StrategicBusinessUnit
    {
        public int Id { get; set; }
        public string? SBU_Name { get; set; }
        public string? SBU_Code { get; set; }
        public int? Tier { get; set; }
    }
}