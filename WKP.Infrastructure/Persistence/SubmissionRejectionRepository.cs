using Mapster;
using Microsoft.EntityFrameworkCore;
using WKP.Application.Common.Interfaces;
using WKP.Domain.DTOs.Application;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;
using WKP.Infrastructure.GeneralServices;

namespace WKP.Infrastructure.Persistence
{
    public class SubmissionRejectionRepository : BaseRepository<SubmissionRejection>, ISubmissionRejectionRepository
    {
        private readonly WKPContext _context;
        private readonly IRNGenerator RNGenerator;
        public SubmissionRejectionRepository(WKPContext context) : base(context)
        {
            _context = context;
            RNGenerator = new RNGenerator();
        }

        public async Task<int> GetAllRejectionCount()
        {
            return await _context.SubmissionRejections.CountAsync();
        }

        public async Task<int> AddAsync(Domain.Entities.Application App, ADMIN_COMPANY_INFORMATION Company, string ActorEmail)
        {
            var PA = new SubmissionRejection
            {
                PermitNo = RNGenerator.Generate(),
                RejectionNumber = RNGenerator.Generate(),
                AppId = App.Id,
                CompanyId = Company.Id,
                ElpsID = Company.ELPS_ID,
                DateIssued = DateTime.Now,
                DateExpired = DateTime.Now.AddYears(1),
                IsRenewed = false,
                IsPrinted = true,
                RejectedBy = ActorEmail,
                CreatedAt = DateTime.Now
            };
            await _context.AddAsync(PA);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<RejectionDTO>> GetRejections()
        {
            var result = await _context.SubmissionRejections
                .Include(x => x.Application)
                    .ThenInclude(x => x.Concession)
                .Include(x => x.Application)
                    .ThenInclude(x => x.Field)
                .Include(x => x.Company).ToListAsync();
            return result.Adapt<List<RejectionDTO>>();
        }
    }
}