using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class SBURepository : BaseRepository<StrategicBusinessUnit>, ISBURepository
    {
        public SBURepository(WKPContext context) : base(context)
        {
        }
    }
}