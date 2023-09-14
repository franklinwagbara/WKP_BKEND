using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IApplicationRepository: IBaseRepository<Application>
    {
        Task<int> GetAllSubAppCountBySBU(int SBUId);
        Task<int> GetAllSubAppCount();
        Task<int> GetAllRejectedAppCount();
        Task<IEnumerable<object>> GetProcesingAppsByStaffId(int StaffId);
        Task<Application?> GetApplicationById(int AppId);
        Task<Application?> GetAppByIdWithAll(int AppId);
    }
}