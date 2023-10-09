using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class StaffRepository : BaseRepository<staff>, IStaffRepository
    {
        private readonly WKPContext _context;
        public StaffRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<staff?> GetStaffByCompanyEmail(string companyEmail)
        {
            return await _context.Staffs.Where(s => s.StaffEmail == companyEmail && s.DeleteStatus != true).FirstOrDefaultAsync();
        }

        public async Task<staff?> GetStaffByCompanyNumber(int companyNumber)
        {
            var staff = await (from stf in _context.Staffs
                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                where stf.AdminCompanyInfo_ID == companyNumber && stf.DeleteStatus != true
                                select stf).FirstOrDefaultAsync();
            
            return staff;
        }

        public async Task<staff?> GetStaffByCompanyNumberWithSBU(int companyNumber)
        {
            var staff = await (from stf in _context.Staffs.Include(x => x.StrategicBusinessUnit)
                                join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
                                where stf.AdminCompanyInfo_ID == companyNumber && stf.DeleteStatus != true
                                select stf).FirstOrDefaultAsync();
            
            return staff;
        }

        public async Task<staff?> GetStaffByDeskId(int deskId)
        {
            var result = await (from stf in _context.Staffs
                                join dsk in _context.Desks 
                                        on stf.StaffID equals dsk.StaffID
                                where dsk.DeskID == deskId
                                select stf).FirstOrDefaultAsync();
            return result;
        }

        public async Task<staff?> GetStaffByIdWithSBU(int StaffId)
        {
            return await _context.Staffs.Include(x => x.StrategicBusinessUnit).Where(x => x.StaffID == StaffId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<int>?> GetStaffIdsByRoleSBU(int? RoleId, int? SBUId)
        {
           return await _context.Staffs.Where(x => x.RoleID==RoleId && x.Staff_SBU==SBUId && x.DeleteStatus !=true).Select(x => x.StaffID).ToListAsync();
        }

        // public Task<staff?> GetStaffByDeskAppIdWithAll(int DeskId, int AppId)
        // {
        //     return await _context.Staffs
        //             .Include(x => x.StrategicBusinessUnit)
        //             .Include(x => x.Role)
        //             .Where(x => x.De)
        // }
    }
}