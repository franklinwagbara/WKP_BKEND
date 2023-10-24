using WKP.Domain.DTOs.Application;
using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface ISubmissionRejectionRepository: IBaseRepository<SubmissionRejection>
    {
        Task<int> GetAllRejectionCount();
        Task<int> AddAsync(Application App, ADMIN_COMPANY_INFORMATION Company, string ActorEmail);
        Task<List<RejectionDTO>> GetRejections();

    }
}