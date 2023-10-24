using WKP.Domain.DTOs.Application;
using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IPermitApprovalRepository: IBaseRepository<PermitApproval>
    {
        Task<int> GetAllApprovalCount();
        Task<int> AddAsync(Application App, ADMIN_COMPANY_INFORMATION Company, string ApproverEmail);
        Task<List<ApprovalDTO>> GetAllApprovals();
    }
}