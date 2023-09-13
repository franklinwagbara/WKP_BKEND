using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class ConcessionRepository : BaseRepository<ADMIN_CONCESSIONS_INFORMATION>, IConcessionRepository
    {
        public ConcessionRepository(WKPContext context) : base(context)
        {
        }
    }
}