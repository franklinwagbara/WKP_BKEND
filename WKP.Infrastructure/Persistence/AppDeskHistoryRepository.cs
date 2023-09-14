using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AppDeskHistoryRepository : BaseRepository<ApplicationDeskHistory>, IAppDeskHistoryRepository
    {
        public AppDeskHistoryRepository(WKPContext context) : base(context)
        {
        }
    }
}