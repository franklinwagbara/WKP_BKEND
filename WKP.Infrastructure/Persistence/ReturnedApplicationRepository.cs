using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class ReturnedApplicationRepository : BaseRepository<ReturnedApplication>, IReturnedApplicationRepository
    {
        public ReturnedApplicationRepository(WKPContext context) : base(context)
        {
        }
    }
}