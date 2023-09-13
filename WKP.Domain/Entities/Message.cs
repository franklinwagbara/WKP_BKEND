namespace WKP.Domain.Entities
{
    public partial class Message
{
    public int id { get; set; }

    public string? subject { get; set; }

    public string? content { get; set; }

    public int? read { get; set; }

    public int? companyID { get; set; }

    public string? sender_id { get; set; }

    public DateTime? date { get; set; }

    public int? AppId { get; set; }

    public int? staffID { get; set; }

    public string? UserType { get; set; }
}
}