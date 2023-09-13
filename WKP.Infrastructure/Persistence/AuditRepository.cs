using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AuditRepository : BaseRepository<AuditTrail>, IAuditRepository
    {
        public AuditRepository(WKPContext context) : base(context)
        {
        }
    }
}