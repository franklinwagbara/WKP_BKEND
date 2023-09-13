using WKP.Domain.Enums_Contants;

namespace WKP.Infrastructure.GeneralServices.Interfaces
{
    public interface IEmailAuditMessage
    {
        Task<bool> LogAudit(string audit, string? userEmail = null);
        Task<bool> SendMessage(bool isStaff, int AppId, int userId, string subject, string content, UserTypes type);
        Task SendEmail(string RecipientEmail, string RecipientName, AppMessage AppMessage, byte[]? attachment);
        Task SendEmailAndAudit(string RecipientEmail, string RecipientName, AppMessage AppMessage, string audit, byte[]? attachment);
        // Task SendEmailAuditMessage();
        // Task SendMessageAudit();
    }
}