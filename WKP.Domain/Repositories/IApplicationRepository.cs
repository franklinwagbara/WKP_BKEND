using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IApplicationRepository: IBaseRepository<Application>
    {
        Task<IEnumerable<Application>?> GetAsync(int Year, int ConcessionId, int FieldId);
        Task<int> GetAllSubAppCountBySBU(int SBUId);
        Task<int> GetAllSubAppCount();
        Task<int> GetAllRejectedAppCount();
        Task<IEnumerable<object>> GetProcesingAppsByStaffId(int StaffId);
        Task<IEnumerable<object>> GetAllAppsScopedToSBU(staff Staff);
        Task<Application?> GetApplicationById(int AppId);
        Task<Application?> GetAppByIdWithAll(int AppId);
        Task<IEnumerable<Application>?> GetAllSubmittedApps();
        Task<IEnumerable<Application>?> GetAllAppsByCompanyId(int CompanyId);
        Task<IEnumerable<ReturnedApplication>?> GetReturnedAppsByCompanyId(int CompanyId);
        Task<IEnumerable<object>> GetStaffsAppInfoWithSBURoleId(int SBUId, int RoleId);
        Task<IEnumerable<object>> GetAppsOnMyDeskByStaffID(int StaffId);
    }
}