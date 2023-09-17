using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AppStatusRepository : BaseRepository<AppStatus>, IAppStatusRepository
    {
        private readonly WKPContext _context;
        public AppStatusRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AppStatus?> GetByAppIdSBUId(int appId, int SBUId)
        {
            return await _context.AppStatuses.Where(x => x.AppId == appId && x.SBUId == SBUId).FirstOrDefaultAsync();
        }

        public async Task<AppStatus?> GetByAppIdSBUIdWithAll(int appId, int SBUId)
        {
            return await _context.AppStatuses
                    .Include(x => x.Company)
                    .Include(x => x.Concession)
                    .Include(x => x.Field)
                    .Include(x => x.SBU)
                    .Include(x => x.Desk)
                    .Where(x => x.AppId == appId && x.SBUId == SBUId).FirstOrDefaultAsync();
        }

        public Task<AppStatus?> GetByFieldSBUCompanyId(int companyId, int concessionId, int fieldId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppStatus?> GetByFieldSBUCompanyIdWithAll(int companyId, int concessionId, int fieldId)
        {
            return await _context.AppStatuses
                    .Include(x => x.Company)
                    .Include(x => x.Concession)
                    .Include(x => x.Field)
                    .Include(x => x.SBU)
                    .Include(x => x.Desk)
                    .Where(x => x.CompanyId == companyId 
                        && x.ConcessionId == concessionId 
                        && x.FieldId == fieldId).FirstOrDefaultAsync();
        }

        public Task<AppStatus?> GetByFieldSBUConcessionId(int SBUId, int concessionId, int fieldId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppStatus?> GetByFieldSBUConcessionIdWithAll(int SBUId, int concessionId, int fieldId)
        {
            return await _context.AppStatuses
                    .Include(x => x.Company)
                    .Include(x => x.Concession)
                    .Include(x => x.Field)
                    .Include(x => x.SBU)
                    .Include(x => x.Desk)
                    .Where(x => x.SBUId == SBUId 
                        && x.ConcessionId == concessionId 
                        && x.FieldId == fieldId).FirstOrDefaultAsync();
        }
    }
}