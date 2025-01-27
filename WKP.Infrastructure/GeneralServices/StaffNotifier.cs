using System.Runtime.CompilerServices;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Infrastructure.GeneralServices.Interfaces;

namespace WKP.Infrastructure.GeneralServices
{
    public class StaffNotifier : IStaffNotifier
    {
        private Domain.Entities.Application App { get; set; }
        private staff Staff { get; set; }
        private ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }
        private COMPANY_FIELD Field { get; set; }   
        private bool _isInitialized = false;
        private IEmailAuditMessage _emailAuditMessage;

        public StaffNotifier(IEmailAuditMessage emailAuditMessage)
        {
            _isInitialized = false;
            _emailAuditMessage = emailAuditMessage;
        }
        public void Init(staff staff, Domain.Entities.Application app, ADMIN_CONCESSIONS_INFORMATION concession, COMPANY_FIELD field)
        {
            Staff = staff;
            App = app;
            Concession = concession;
            Field = field;

            _isInitialized = true;
        }

        public Task SendMoveNotification(bool? isSource = false)
        {
            CheckInit();
            
            string subject = $"Re-assignment for WORK PROGRAM application with ref: {App.ReferenceNo} ({App.Concession.Concession_Held} - {App.YearOfWKP}).";
            string content = $"Application with REF : {App.ReferenceNo} has been moved to your desk from {Staff.LastName}, {Staff.FirstName} desk";

            if(isSource == true) content = $"Application with REF : {App.ReferenceNo} has been moved from your desk to {Staff.LastName}, {Staff.FirstName} desk";
        
            SendNotification(subject, content);
            return Task.CompletedTask;
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

            string subject = $"Approval from Final Athority for WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}).";
            string content = $"WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}) has been approved by Final Authority to the next processing level.";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        public Task SendFinalApprovalNotification()
        {
            CheckInit();

            string subject = $"Approval from Final Approving Athority for WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}).";
            string content = $"WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}) has been approved by Final Approving Authority.";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        public Task SendFinalRejectionNotification(string comment)
        {
            CheckInit();

            string subject = $"Rejection from Final Approving Athority for WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}).";
            string content = $"WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}) has been approved by Final Approving Authority."
                + $"Reason: {comment}";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        public Task SendPushNotification()
        {
            CheckInit();

            string subject = $"A Push action was taken for WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession.Concession_Held} - {App.YearOfWKP}).";
            string content = $"WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}) has been pushed by a staff to the next processing level.";

            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        public Task SendRejectNotification()
        {
            CheckInit();

            throw new NotImplementedException();
        }

        public Task SendReturnNotification()
        {
            CheckInit();

            string subject = $"Returned WORK PROGRAM application with ref: {App.ReferenceNo} ({Concession?.Concession_Held} - {App.YearOfWKP}).";
            string content = $"{Staff.Name} returned WORK PROGRAM application for year {App.YearOfWKP}.";
            
            SendNotification(subject, content);
            return Task.CompletedTask;
        }

        private void SendNotification(string subject, string content)
        {
            var msg = GetMessage(subject, content);

            _emailAuditMessage.SendMessage(true, App.Id, Staff.StaffID, subject, content, UserTypes.Staff);
            _emailAuditMessage.SendEmailAndAudit(Staff.StaffEmail, Staff.Name, msg, subject, null);
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
                Field = Field?.Field_Name ?? "---",
                Concession = Concession.ConcessionName ?? "---",
                DateSubmitted = DateTime.Now,
                Year = App.YearOfWKP
            };
        }
    }
}