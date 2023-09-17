using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class PermitApprovalRepository : BaseRepository<PermitApproval>, IPermitApprovalRepository
    {
        private readonly WKPContext _context;
        public PermitApprovalRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetAllApprovalCount()
        {
            return await _context.PermitApprovals.CountAsync();
        }
    }
}