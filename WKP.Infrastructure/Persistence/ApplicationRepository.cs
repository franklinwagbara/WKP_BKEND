using Microsoft.EntityFrameworkCore;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class ApplicationRepository : BaseRepository<Domain.Entities.Application>, IApplicationRepository
    {
        private readonly WKPContext _context;
        public ApplicationRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetAllRejectedAppCount()
        {
            return await _context.Applications.Where(
                x => x.Status == MAIN_APPLICATION_STATUS.Rejected).CountAsync();
        }

        public async Task<int> GetAllSubAppCount()
        {
            return await _context.Applications.Where(
                x => x.Status != MAIN_APPLICATION_STATUS.NotSubmitted).CountAsync();
        }

        public async Task<int> GetAllSubAppCountBySBU(int SBUId)
        {
            var result = await (from app in _context.Applications
                                .Include(x => x.Field)
                                .Include(x => x.Concession).Include(x => x.Company)
                                join dsk in _context.Desks on app.Id equals dsk.AppId
                                where app.DeleteStatus != true && dsk.Staff.Staff_SBU == SBUId
                                && dsk.HasWork == true && app.Status != MAIN_APPLICATION_STATUS.NotSubmitted
                                select new
                                {
                                    app = app
                                }
                                ).CountAsync();
            return result;
        }

        public async Task<Domain.Entities.Application?> GetApplicationById(int AppId)
        {
            return await _context.Applications.Where(a => a.Id == AppId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<object>> GetProcesingAppsByStaffId(int StaffId)
        {
            var result = await (from app in _context.Applications
                                          join comp in _context.ADMIN_COMPANY_INFORMATIONs on app.CompanyID equals comp.Id
                                          join dsk in _context.Desks on app.Id equals dsk.AppId
                                          join field in _context.Fields on app.FieldID equals field.Field_ID
                                          join con in _context.Concessions on app.ConcessionID equals con.Consession_Id
                                          where dsk.StaffID == StaffId && dsk.ProcessStatus == DESK_PROCESS_STATUS.Processing
                                          select new 
                                          {
                                              Id = app.Id,
                                              FieldID = app.FieldID,
                                              ConcessionID = app.ConcessionID,
                                              ConcessionName = con.ConcessionName,
                                              FieldName = field != null ? field.Field_Name : null,
                                              ReferenceNo = app.ReferenceNo,
                                              CreatedAt = app.CreatedAt,
                                              SubmittedAt = app.SubmittedAt,
                                              CompanyName = comp.COMPANY_NAME,
                                              Status = app.Status,
                                              PaymentStatus = app.PaymentStatus,
                                              YearOfWKP = app.YearOfWKP
                                          }).ToListAsync();
            
            return result;
        }
    }
}