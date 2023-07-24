namespace Backend_UMR_Work_Program.RawQueries
{
	public class AppHistoryQuery
	{
		public static string GetAppHistoryScript()
		{
			var query = "select apDesk.Id as ID,stf.FirstName + ' ' + stf.LastName as Staff_Name, stf.StaffEmail as Staff_Email, sbu.SBU_Name as Staff_SBU, rol.RoleName as Staff_Role,  apDesk.Comment as Comment from ApplicationDeskHistories apDesk join staff stf on apDesk.StaffID=stf.StaffID join ADMIN_COMPANY_INFORMATION adm on stf.AdminCompanyInfo_ID = adm.Id join [Role] rol on stf.RoleID = rol.Id join StrategicBusinessUnits sbu on stf.Staff_SBU = sbu.Id;";

			return query;
		}
	}
}
