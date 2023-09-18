using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(WKPContext context) : base(context)
        {
        }
    }
}