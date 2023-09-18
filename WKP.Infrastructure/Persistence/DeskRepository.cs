using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class DeskRepository : BaseRepository<MyDesk>, IDeskRepository
    {
        private readonly WKPContext _context;
        public DeskRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MyDesk?> GetDeskByDeskId(int DeskId)
        {
            return await _context.Desks.Where(d => d.DeskID == DeskId).FirstOrDefaultAsync();
        }

        public async Task<MyDesk?> GetDeskByDeskIdAppIdWithStaff(int DeskId, int AppId, bool? HasWork = null)
        {
            if(HasWork == null)
                return await _context.Desks.Include(d => d.Staff).Where(
                                (d) => d.DeskID == DeskId && d.AppId == AppId
                            ).FirstOrDefaultAsync();
            else
                return await _context.Desks.Include(d => d.Staff).Where(
                                (d) => d.DeskID == DeskId && d.AppId == AppId && d.HasWork == HasWork
                            ).FirstOrDefaultAsync();
        }

        public async Task<MyDesk?> GetDeskByStaffIdAppIdWithStaff(int StaffId, int AppId, bool? HasWork = null)
        {
            if(HasWork is null)
                return await _context.Desks.Include(d => d.Staff).Where(
                                (d) => d.StaffID == StaffId && d.AppId == AppId
                            ).FirstOrDefaultAsync();
            else
                return await _context.Desks.Include(d => d.Staff).Where(
                                (d) => d.StaffID == StaffId && d.AppId == AppId && d.HasWork == HasWork
                            ).FirstOrDefaultAsync();
        }

        public async Task<MyDesk?> GetDeskByStaffTierAppIdWithStaffSBU(int Tier, int AppId, bool? HasWork = null)
        {
            if(HasWork is null)
                return await _context.Desks.Include(x => x.Staff).ThenInclude(s => s.StrategicBusinessUnit)
                        .Where(
                            x => x.AppId == AppId && 
                            x.Staff.StrategicBusinessUnit.Tier == Tier).FirstOrDefaultAsync();
            else
                return await _context.Desks.Include(x => x.Staff).ThenInclude(s => s.StrategicBusinessUnit)
                        .Where(
                            x => x.AppId == AppId && 
                            x.Staff.StrategicBusinessUnit.Tier == Tier
                            && x.HasWork == HasWork).FirstOrDefaultAsync();
        }

        public async Task<int> GetStaffAppProcessingDeskCount(int StaffId)
        {
            return await _context.Desks.Where(
                x => x.StaffID == StaffId && x.HasWork == true 
                && x.ProcessStatus == DESK_PROCESS_STATUS.Processing).CountAsync();
        }

        public async Task<int> GetStaffDeskCount(int StaffId)
        {
            return await _context.Desks.Where(d => d.StaffID == StaffId && d.HasWork == true).CountAsync();
        }
    }
}