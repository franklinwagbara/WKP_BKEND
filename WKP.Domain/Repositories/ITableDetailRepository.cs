using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface ITableDetailRepository: IBaseRepository<Table_Detail>
    {
        Task<Table_Detail?> GetById(int TableId);
    }
}