using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class AppProcessFlowRepo : BaseRepository<ApplicationProccess>, IAppProcessFlowRepo
    {
        private readonly WKPContext _context;
        public AppProcessFlowRepo(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationProccess>> GetAppProcessFlowBySBU_Role_Action(string Action, int TriggeredByRole = 0, int triggeredBySBU = 0)
        {
            return await _context.AppProcessFlow
            .Where(
                x => x.TriggeredByRole==TriggeredByRole 
                && x.TriggeredBySBU==triggeredBySBU 
                && x.ProcessAction==Action 
                && x.DeleteStatus != true ).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationProccess>> GetAppFlowByAction(string Action)
        {
            return await _context.AppProcessFlow
            .Where(
                x => x.ProcessAction==Action 
                && x.DeleteStatus != true ).ToListAsync();
        }
    }
}