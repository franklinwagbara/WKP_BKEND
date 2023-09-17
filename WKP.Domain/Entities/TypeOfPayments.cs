namespace WKP.Domain.Entities
{
    public class TypeOfPayments
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }
    }
}