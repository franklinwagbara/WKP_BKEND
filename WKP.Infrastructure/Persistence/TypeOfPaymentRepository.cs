using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class TypeOfPaymentRepository : BaseRepository<TypeOfPayments>, ITypeOfPaymentRepository
    {
        public TypeOfPaymentRepository(WKPContext context) : base(context)
        {
        }
    }
}