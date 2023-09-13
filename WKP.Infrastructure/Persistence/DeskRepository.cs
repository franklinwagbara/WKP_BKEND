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