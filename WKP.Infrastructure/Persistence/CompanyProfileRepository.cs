using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class CompanyProfileRepository : BaseRepository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(WKPContext context) : base(context)
        {
        }
    }
}