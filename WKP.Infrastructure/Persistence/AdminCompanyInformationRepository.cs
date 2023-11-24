using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AdminCompanyInformationRepository : BaseRepository<ADMIN_COMPANY_INFORMATION>, IAdminCompanyInformationRepository
    {
        private readonly WKPContext _context;
        public AdminCompanyInformationRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ADMIN_COMPANY_INFORMATION?> GetActiveCompanyByEmail(string Email)
        {
            return await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.EMAIL!.ToLower().Equals(Email.ToLower()) && x.STATUS_ == USER_STATUS.Activated);
        }

        public async Task<ADMIN_COMPANY_INFORMATION?> GetCompanyByEmail(string Email)
        {
            return await _context.ADMIN_COMPANY_INFORMATIONs.FirstOrDefaultAsync(x => x.EMAIL!.ToLower().Equals(Email.ToLower()));
        }
    }
}