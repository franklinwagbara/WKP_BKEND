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
    }
}