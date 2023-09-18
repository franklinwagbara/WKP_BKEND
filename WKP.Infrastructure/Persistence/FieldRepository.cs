using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class FieldRepository : BaseRepository<COMPANY_FIELD>, IFieldRepository
    {
        public FieldRepository(WKPContext context) : base(context)
        {
        }
    }
}