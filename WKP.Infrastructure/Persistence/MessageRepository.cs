using WKP.Domain.Entities;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(WKPContext context) : base(context)
        {
        }
    }
}