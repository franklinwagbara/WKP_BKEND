using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AdminCompanyDetailsRepository : BaseRepository<ADMIN_COMPANY_DETAIL>, IAdminCompanyDetailsRepository
    {
        public AdminCompanyDetailsRepository(WKPContext context) : base(context)
        {
        }
    }
}