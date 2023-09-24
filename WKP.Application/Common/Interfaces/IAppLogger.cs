namespace WKP.Application.Common.Interfaces
{
    public interface IAppLogger
    {
        Task<bool> LogAudit(string audit, string? userEmail = null);
    }
}