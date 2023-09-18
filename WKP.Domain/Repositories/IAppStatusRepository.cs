using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IAppStatusRepository: IBaseRepository<AppStatus>
    {
        Task<AppStatus?> GetByAppIdSBUId(int appId, int SBUId);
        Task<AppStatus?> GetByAppIdSBUIdWithAll(int appId, int SBUId);
        Task<AppStatus?> GetByFieldSBUCompanyId(int companyId, int concessionId, int fieldId);
        Task<AppStatus?> GetByFieldSBUCompanyIdWithAll(int companyId, int concessionId, int fieldId);
        Task<AppStatus?> GetByFieldSBUConcessionId(int SBUId, int concessionId, int fieldId);
        Task<AppStatus?> GetByFieldSBUConcessionIdWithAll(int SBUId, int concessionId, int fieldId);
    }
}