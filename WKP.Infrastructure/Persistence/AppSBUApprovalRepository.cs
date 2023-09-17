using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AppSBUApprovalRepository : BaseRepository<ApplicationSBUApproval>, IAppSBUApprovalRepository
    {
        public AppSBUApprovalRepository(WKPContext context) : base(context)
        {
        }
    }
}