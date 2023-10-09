using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IStaffRepository: IBaseRepository<staff>
    {
        Task<staff?> GetStaffByCompanyNumber(int companyNumber);
        Task<staff?> GetStaffByCompanyEmail(string companyEmail);
        Task<staff?> GetStaffByDeskId(int deskId);
        Task<IEnumerable<int>?> GetStaffIdsByRoleSBU(int? RoleId, int? SBUId);
        Task<staff?> GetStaffByIdWithSBU(int StaffId);
        public Task<staff?> GetStaffByCompanyNumberWithSBU(int companyNumber);
        // Task<staff?> GetStaffByDeskAppIdWithAll(int DeskId, int AppId);
    }
}