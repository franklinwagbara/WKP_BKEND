using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AdminCompanyInformationRepository : BaseRepository<ADMIN_COMPANY_INFORMATION>, IAdminCompanyInformationRepository
    {
        public AdminCompanyInformationRepository(WKPContext context) : base(context)
        {
        }
    }
}