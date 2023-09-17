using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IReturnedApplicationRepository: IBaseRepository<ReturnedApplication>
    {
        Task<IEnumerable<ReturnedApplication>> GetReturnAppsByCompanyId(int CompanyId);
    }
}