using Microsoft.EntityFrameworkCore;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class PermitApprovalRepository : BaseRepository<PermitApproval>, IPermitApprovalRepository
    {
        private readonly WKPContext _context;
        private readonly IRNGenerator RNGenerator;
        public PermitApprovalRepository(WKPContext context, IRNGenerator rNGenerator) : base(context)
        {
            _context = context;
            RNGenerator = rNGenerator;
        }

        public async Task<int> GetAllApprovalCount()
        {
            return await _context.PermitApprovals.CountAsync();
        }

        public async Task<int> AddAsync(Domain.Entities.Application App, ADMIN_COMPANY_INFORMATION Company, string ApproverEmail)
        {
            var PA = new PermitApproval
            {
                PermitNo = RNGenerator.Generate(),
                ApprovalNumber = RNGenerator.Generate(),
                AppID = App.Id,
                CompanyID = Company.Id,
                ElpsID = Company.ELPS_ID,
                DateIssued = DateTime.Now,
                DateExpired = DateTime.Now.AddYears(1),
                IsRenewed = false,
                IsPrinted = true,
                ApprovedBy = ApproverEmail,
                CreatedAt = DateTime.Now
            };
            await _context.AddAsync(PA);
            return await _context.SaveChangesAsync();
        }
    }
}