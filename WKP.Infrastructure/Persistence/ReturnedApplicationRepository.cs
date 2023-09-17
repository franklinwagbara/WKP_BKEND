using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class ReturnedApplicationRepository : BaseRepository<ReturnedApplication>, IReturnedApplicationRepository
    {
        private readonly WKPContext _context;

        public ReturnedApplicationRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReturnedApplication>> GetReturnAppsByCompanyId(int CompanyId)
        {
            return await _context.ReturnedApplications
                        .Include(x => x.Application)
                        .ThenInclude(x => x.Concession)
                        .Include(x => x.Application)
                        .ThenInclude(x => x.Field)
                        .Include(x => x.Staff)
                        .ThenInclude(x => x.StrategicBusinessUnit)
                        .Where(x => x.Application.CompanyID == CompanyId)
                        .ToListAsync();
        }
    }
}