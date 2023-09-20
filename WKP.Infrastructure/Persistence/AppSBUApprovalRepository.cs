using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AppSBUApprovalRepository : BaseRepository<ApplicationSBUApproval>, IAppSBUApprovalRepository
    {
        private readonly WKPContext _context;

        public AppSBUApprovalRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationSBUApproval?> GetByAppIdIncludeStaff(int AppId)
        {
            return await _context.ApplicationSBUApprovals
                            .Include(x => x.Staff)
                            .Where(x => x.AppId == AppId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApplicationSBUApproval>?> GetListByAppIdIncludeStaff(int AppId)
        {
            return await _context.ApplicationSBUApprovals
                            .Include(x => x.Staff)
                            .Where(x => x.AppId == AppId)
                            .ToListAsync();
        }
    }
}