using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class TableDetailRepository : BaseRepository<Table_Detail>, ITableDetailRepository
    {
        private readonly WKPContext _context;

        public TableDetailRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Table_Detail?> GetById(int TableId)
        {
            return await _context.TableDetails.Where(x => x.TableId == TableId).FirstOrDefaultAsync();
        }
    }
}