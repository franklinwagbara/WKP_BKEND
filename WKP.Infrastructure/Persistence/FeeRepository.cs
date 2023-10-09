using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class FeeRepository : BaseRepository<Fee>, IFeeRepository
    {
        public FeeRepository(WKPContext context) : base(context)
        {
        }
    }
}