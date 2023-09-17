namespace WKP.Domain.Entities
{
    public class AuditTrail
{
    public int AuditLogID { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? UserID { get; set; }
}
}