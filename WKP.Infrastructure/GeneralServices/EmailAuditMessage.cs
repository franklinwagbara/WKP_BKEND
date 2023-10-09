using System.Net;
using System.Net.Mail;
using Hangfire;
using Microsoft.Extensions.Configuration;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.GeneralServices.Interfaces;

namespace WKP.Infrastructure.GeneralServices.Implementations
{
    public class EmailAuditMessage : IEmailAuditMessage
    {
        private readonly EmailHelper _emailHelper;

        public EmailAuditMessage(EmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
        }

        public async Task<bool> LogAudit(string audit, string? userId = null)
        {
            BackgroundJob.Enqueue(() => _emailHelper.LogAuditInt(audit, userId));
            return await Task.FromResult(true);
        }

        public Task SendEmail(string RecipientEmail, string RecipientName, AppMessage AppMessage, byte[]? attachment)
        {
            BackgroundJob.Enqueue(() => _emailHelper.SendEmailInt(RecipientEmail, RecipientName, AppMessage, attachment));
            return Task.CompletedTask;            
        }

        public async Task SendEmailAndAudit(string RecipientEmail, string RecipientName, AppMessage AppMessage, string audit, byte[]? attachment)
        {
            BackgroundJob.Enqueue(() => LogAudit(audit, RecipientEmail));
            BackgroundJob.Enqueue(() => _emailHelper.SendEmailInt(RecipientEmail, RecipientName, AppMessage, attachment));
            return;   
        }

        public async Task<bool> SendMessage(bool isStaff, int AppId, int userId, string subject, string content, UserTypes type)
        {
            BackgroundJob.Enqueue(() => _emailHelper.SendMessageInt(isStaff, AppId, userId, subject, content, type));
            return await Task.FromResult(true);
        }
   }

   public class EmailHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _username;
        private readonly string _password;
        private readonly string _emailFrom;
        private readonly string _Host; 
        private readonly int _Port;
        private readonly IConfiguration _config;

        public EmailHelper(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _config = configuration;

            //SMTP setup
            _password = _config.GetSection("SmtpSettings").GetSection("Password").Value.ToString();
            _username = _config.GetSection("SmtpSettings").GetSection("Username").Value.ToString();
            _emailFrom = _config.GetSection("SmtpSettings").GetSection("SenderEmail").Value.ToString();
            _Host = _config.GetSection("SmtpSettings").GetSection("Server").Value.ToString();
            _Port = Convert.ToInt16(_config.GetSection("SmtpSettings").GetSection("Port").Value.ToString());
        }

        public async Task<bool> LogAuditInt(string audit, string? userId = null)
        {
            var auditTrail = new AuditTrail()
            {
                CreatedAt = DateTime.Now,
                UserID = userId,
                AuditAction = audit,
            };

            await _unitOfWork.AuditRepository.AddAsync(auditTrail);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task SendEmailInt(string RecipientEmail, string RecipientName, AppMessage AppMessage, byte[]? attachment)
        {
            try
            {
                var result = "";
                var messageBody = GetCompanyMessageTemplate(AppMessage);

                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient(_Host, _Port);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Timeout = 300000;
                client.Credentials = new NetworkCredential(_username, _password); 
                mail.From = new MailAddress(_emailFrom);
                mail.To.Add(new MailAddress(RecipientEmail, RecipientName));
                mail.Subject = AppMessage.Subject.ToString();
                mail.IsBodyHtml = true;
                mail.Body = messageBody;

                if(attachment is not null)
                {
                    string name = "AWKP Letter";
                    Attachment att = new Attachment(new MemoryStream(attachment), name);
                    mail.Attachments.Add(att);
                } 

                client.Send(mail);
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> SendMessageInt(bool isStaff, int AppId, int userId, string subject, string content, UserTypes type)
        {
            var messages = new Message()
            {
                companyID = !isStaff ? userId : 0,
                staffID = isStaff ? userId : 0,
                AppId = AppId,
                subject = subject,
                content = content,
                read = 0,
                UserType = type == UserTypes.Staff? UserType.Staff: UserType.Company,
                date = DateTime.UtcNow.AddHours(1)
            };
            await _unitOfWork.MessageRepository.AddAsync(messages);
            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        public static string GetCompanyMessageTemplate(AppMessage AppMessages)
        {
            var msg = AppMessages;
            string body = "<div>";

            body += "<div style='width: 800px; background-color: #ece8d4; padding: 5px 0 5px 0;'><img style='width: 98%; height: 120px; display: block; margin: 0 auto;' src='~/images/NUPRC Logo.JPG' alt='Logo'/></div>";
            body += "<div class='text-left' style='background-color: #ece8d4; width: 800px; min-height: 200px;'>";
            body += "<div style='padding: 10px 30px 30px 30px;'>";
            body += "<h5 style='text-align: center; font-weight: 300; padding-bottom: 10px; border-bottom: 1px solid #ddd;'>" + msg.Subject.ToString() + "</h5>";
            body += "<p>Dear Sir/Madam,</p>";
            body += "<p style='line-height: 30px; text-align: justify;'>" + msg.Content.ToString() + "</p>";
            body += "<p style='line-height: 30px; text-align: justify;'> Kindly find application details below.</p>";
            body += "<table style = 'width: 100%;'><tbody>";
            body += "<tr><td style='width: 200px;'><strong>Company Name:</strong></td><td> " + msg.CompanyName.ToString() + " </td></tr>";
            body += "<tr><td style='width: 200px;'><strong>Year:</strong></td><td> " + msg.Year.ToString() + " </td></tr>";
            body += "<tr><td style='width: 200px;'><strong>Concession:</strong></td><td> " + msg.Concession.ToString() + " </td></tr>";
            body += "<tr><td style='width: 200px;'><strong>Field:</strong></td><td> " + msg.Field.ToString() + " </td></tr>";
            body += "</tbody></table><br/>";

            body += "<p> </p>";
            body += "&copy; " + DateTime.Now.Year.ToString() + "<p>  Powered by NUPRC Work Program Team. </p>";
            body += "<div style='padding:10px 0 10px; 10px; background-color:#888; color:#f9f9f9; width:800px;'> &copy; " 
                + DateTime.UtcNow.AddHours(1).Year.ToString() 
                + " Nigerian Upstream Petroleum Regulatory Commission &minus; NUPRC Nigeria</div></div></div>";

            return body;
        }
    }
}