using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Infrastructure.GeneralServices.Interfaces;

namespace WKP.Infrastructure.GeneralServices
{
    public class CompanyNotifier : ICompanyNotifier
    {
        private Domain.Entities.Application App { get; set; }
        private ADMIN_COMPANY_INFORMATION Company { get; set; }
        private ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }
        private COMPANY_FIELD Field { get; set; }   
        private bool _isInitialized = false;
        private IEmailAuditMessage _emailAuditMessage;

        public CompanyNotifier(IEmailAuditMessage emailAuditMessage)
        {
            _isInitialized = false;
            _emailAuditMessage = emailAuditMessage;
        }

        public void Init(ADMIN_COMPANY_INFORMATION company, Domain.Entities.Application app, ADMIN_CONCESSIONS_INFORMATION concession, COMPANY_FIELD field)
        {
            Company = company;
            App = app;
            Concession = concession;
            Field = field;

            _isInitialized = true;
        }

        public Task SendSubmitNotification()
        {
            CheckInit();
            
            string subject = $"{App.YearOfWKP} submission of WORK PROGRAM application for {App.Company.COMPANY_NAME} field - {App.Field?.Field_Name} : {App.ReferenceNo}";
            string content = $"{App.Company.COMPANY_NAME} have submitted their WORK PROGRAM application for year {App.YearOfWKP}.";
        
            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        public Task SendApprovalNotification()
        {
            CheckInit();
            throw new NotImplementedException();
        }

        public Task SendPushNotification()
        {
            CheckInit();

            throw new NotImplementedException();
        }

        public Task SendRejectNotification()
        {
            CheckInit();

            throw new NotImplementedException();
        }

        public Task SendReturnNotification()
        {
            CheckInit();

            string subject = $"WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession.Concession_Held} - {App.YearOfWKP}) was returned.";
            string content = $"Your WORK PROGRAM application for year {App.YearOfWKP} was returned.";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        private void SendNotification(string subject, string content)
        {
            var msg = GetMessage(subject, content);

            _emailAuditMessage.SendMessage(false, App.Id, Company.Id, subject, content, UserTypes.Company);
            _emailAuditMessage.SendEmail(Company.EMAIL, Company.NAME, msg, null);
        }

        public Task SendFinalApprovalNotification()
        {
            CheckInit();

            string subject = $"Approval from Final Approving Athority for WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}).";
            string content = $"DUMMY CONDITIONAL APPROVAL FOR YOUR 2023 ANNUAL WORK PROGRAMME SUBMISSION";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        public Task SendFinalRejectionNotification(string comment)
        {
            CheckInit();

            string subject = $"Rejection from Final Approving Athority for WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}).";
            string content = $"DUMMY REJECTION FOR YOUR 2023 ANNUAL WORK PROGRAMME SUBMISSION"
                + $"Reason: {comment}";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        private void CheckInit()
        {
            if(!_isInitialized) throw new Exception("Values not initialized - The 'Init()' was not invoked.");
        }

        private AppMessage GetMessage(string subject, string content)
        {
            return new AppMessage
            {
                Subject = subject,
                Content = content,
                RefNo = App.ReferenceNo,
                Status = App.Status,
                Seen = false,
                CompanyName = App?.Company.COMPANY_NAME ?? "---",
                CategoryName = "New",
                Field = Field != null? Field.Field_Name: "---",
                Concession = Concession?.Concession_Held ?? "---",
                DateSubmitted = DateTime.Now,
                Year = App?.YearOfWKP
            };
        }
    }
}