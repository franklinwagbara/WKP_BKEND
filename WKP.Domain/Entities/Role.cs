namespace WKP.Domain.Entities
{
    public partial class Role
    {
        public int id { get; set; }
        public string RoleId { get; set; } = null!;
        public string? Description { get; set; }
        public string? RoleName { get; set; }
        public int? Rank { get; set; }

        // public virtual ICollection<Functionality> Funcs { get; } = new List<Functionality>();
    }
}