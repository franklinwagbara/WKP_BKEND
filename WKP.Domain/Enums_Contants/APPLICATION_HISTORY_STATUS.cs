namespace WKP.Domain.Enums_Contants
{
    public static class APPLICATION_HISTORY_STATUS
    {
        public const string ReviewerApproved = "Reviewer Approved";
        public const string SuppervisorApproved = "Supervisor Approved";
        public const string ManagerApproved = "Manager Approved";
        public const string FinalAuthorityApproved = "Final Authority Approved";
        public const string FinalApprovingAuthorityApproved = "Final Approving Authority Approved";
        public const string FinalApprovingAuthorityRejected = "Final Approving Authority Rejected";
        public const string DirectorApproved = "Director Approved";
        public const string DeputyDirectorApproved = "Deputy Director Approved";

        public const string ReturnedToCompany = "Returned To Company";
        public const string ReturnedToStaff = "Returned To Staff";

        public const string AddedComment = "Added Comment";
        public const string CompanyReSubmitted = "Company Resubmitted";
        
        //public static string SentBackToCompany = "Application Sent Back To Company";
        //public static string SentBackToStaff = "Application Sent Back To Staff";
    }
}