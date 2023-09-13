using System.ComponentModel.DataAnnotations;

namespace WKP.Domain.Entities
{
    public class MyDesk
	{
		[Key]
		public int DeskID { get; set; }
		public int? ProcessID { get; set; }
		public int AppId { get; set; }
		public int? Sort { get; set; }
		public bool HasWork { get; set; }
		public bool HasPushed { get; set; }
		public int? FromStaffID { get; set; }
		public int FromSBU { get; set; }
		public int? FromRoleId { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string? Comment { get; set; }
		public DateTime LastJobDate { get; set; }

		public string? ProcessStatus { get; set; }

		public int StaffID { get; set; }
    	public staff Staff {get; set;}

		public static class NavigationProperty
        {
            public static string Staff = "Staff";
        }
	}
}