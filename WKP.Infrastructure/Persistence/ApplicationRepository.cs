using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
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

        public async Task<Domain.Entities.Application?> GetAppByIdWithAll(int AppId)
        {
            return await _context.Applications
                                    .Include(x => x.Concession)
                                    .Include(x => x.Field)
                                    .Include(x => x.Company)
                                    .Where((a) => a.Id == AppId).FirstOrDefaultAsync();
        }

        public async Task<Domain.Entities.Application?> GetApplicationById(int AppId)
        {
            return await _context.Applications.Where(a => a.Id == AppId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<object>> GetProcesingAppsByStaffId(int StaffId)
        {
            var result = await (from dsk in _context.Desks 
                                join app in _context.Applications
                                    .Include(x => x.Concession)
                                    .Include(x => x.Field).Include(x => x.Company)
                                    on dsk.AppId equals app.Id
                                where dsk.StaffID == StaffId && dsk.ProcessStatus == DESK_PROCESS_STATUS.Processing
                                select new
                                {
                                    Id = app.Id,
                                    FieldID = app.FieldID,
                                    ConcessionID = app.ConcessionID,
                                    ConcessionName = app.Concession.ConcessionName,
                                    FieldName = app.Field != null ? app.Field.Field_Name : null,
                                    ReferenceNo = app.ReferenceNo,
                                    CreatedAt = app.CreatedAt,
                                    SubmittedAt = app.SubmittedAt,
                                    CompanyName = app.Company.COMPANY_NAME,
                                    Status = app.Status,
                                    PaymentStatus = app.PaymentStatus,
                                    YearOfWKP = app.YearOfWKP
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Domain.Entities.Application>?> GetAllSubmittedApps()
        {
            return await _context.Applications
                        .Include(x => x.Concession)
                        .Include(x => x.Field)
                        .Include(x => x.Company)
                        .Where( a => 
                            a.DeleteStatus != true && 
                            a.Status != MAIN_APPLICATION_STATUS.NotSubmitted
                        )
                        .ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Application>?> GetAllAppsByCompanyId(int CompanyId)
        {
            return await _context.Applications
                        .Include(x => x.Concession)
                        .Include(x => x.Field)
                        .Include(x => x.Company)
                        .Where( a => 
                            a.DeleteStatus != true && 
                            a.CompanyID == CompanyId
                        )
                        .ToListAsync();
        }

        public async Task<IEnumerable<ReturnedApplication>?> GetReturnedAppsByCompanyId(int CompanyId)
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

        public async Task<IEnumerable<object>> GetAllAppsScopedToSBU(staff Staff)
        {
            var result = await (from app in _context.Applications.Include(x => x.Field).Include(x => x.Concession).Include(x => x.Company)
                                        join dsk in _context.Desks.Include(x => x.Staff) on app.Id equals dsk.AppId
                                        where app.DeleteStatus != true && dsk.Staff.Staff_SBU == Staff.Staff_SBU && dsk.HasWork == true
                                        select new 
                                        {
                                            Id = app.Id,
                                            FieldID = app.FieldID,
                                            ConcessionID = app.ConcessionID,
                                            ConcessionName = app.Concession.ConcessionName,
                                            FieldName = app.Field != null ? app.Field.Field_Name : null,
                                            ReferenceNo = app.ReferenceNo,
                                            CreatedAt = app.CreatedAt,
                                            SubmittedAt = app.SubmittedAt,
                                            CompanyName = app.Company.COMPANY_NAME,
                                            Status = app.Status,
                                            PaymentStatus = app.PaymentStatus,
                                            YearOfWKP = app.YearOfWKP
                                        }).ToListAsync();

            // var result = await _context.AppStatuses
            //     .Include(x => x.AppId).Include(x => x.Concession)
            //     .Include(x => x.Company).Include(x => x.Field)
            //     .Where( x => x.SBUId == Staff.Staff_SBU)
            
            return result;
        }

        public async Task<IEnumerable<object>> GetStaffsAppInfoWithSBURoleId(int SBUId, int RoleId)
        {
            var result = await _context.Desks.Include(x => x.Staff)
                    .Where(x => x.Staff.Staff_SBU == SBUId && x.Staff.RoleID == RoleId)
                    .GroupBy(x => x.StaffID)
                    .Select(x => new
                    {
                        deskCount = x.Count(),
                        processingCount = x.Count(
                            x => x.ProcessStatus != DESK_PROCESS_STATUS.SubmittedByCompany 
                            || x.ProcessStatus != DESK_PROCESS_STATUS.SubmittedByStaff),
                        staff = x.ToList()[0].Staff
                    }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<object>> GetAppsOnMyDeskByStaffID(int StaffId)
        {
            var result = await (from desk in _context.Desks.Include(x => x.Staff)
                                join app in _context.Applications
                                    .Include(x => x.Company)
                                    .Include(x => x.Concession)
                                    .Include(x => x.Field) 
                                    on desk.AppId equals app.Id
                                where desk.StaffID == StaffId && desk.HasWork == true
                                select new 
                                {
                                    Staff = desk.Staff,
                                    Desk = desk,
                                    Application = app
                                }).ToListAsync();
            return result;
        }
    }
}