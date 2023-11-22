using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IAdminCompanyInformationRepository: IBaseRepository<ADMIN_COMPANY_INFORMATION>
    {
        Task<ADMIN_COMPANY_INFORMATION?> GetActiveCompanyByEmail(string Email);
        Task<ADMIN_COMPANY_INFORMATION?> GetCompanyByEmail(string Email);
    }
}