using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IStaffRepository: IBaseRepository<staff>
    {
        Task<staff?> GetStaffByCompanyNumber(int companyNumber);
        Task<staff?> GetStaffByCompanyEmail(string companyEmail);
    }
}