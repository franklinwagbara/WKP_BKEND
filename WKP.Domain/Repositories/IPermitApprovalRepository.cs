using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IPermitApprovalRepository: IBaseRepository<PermitApproval>
    {
        Task<int> GetAllApprovalCount();
    }
}