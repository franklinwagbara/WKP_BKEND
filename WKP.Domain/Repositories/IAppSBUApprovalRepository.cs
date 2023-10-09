using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IAppSBUApprovalRepository: IBaseRepository<ApplicationSBUApproval>
    {
        Task<ApplicationSBUApproval?> GetByAppIdIncludeStaff(int AppId);
        Task<IEnumerable<ApplicationSBUApproval>?> GetListByAppIdIncludeStaff(int AppId);
    }
}