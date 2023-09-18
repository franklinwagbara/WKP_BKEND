using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IAppProcessFlowRepo: IBaseRepository<ApplicationProccess>
    {
        Task<IEnumerable<ApplicationProccess>> GetAppProcessFlowBySBU_Role_Action(string ProcessStatus, int TriggeredByRole = 0, int triggeredBySBU = 0);
        public Task<IEnumerable<ApplicationProccess>> GetAppFlowByAction(string Action);
    }
}