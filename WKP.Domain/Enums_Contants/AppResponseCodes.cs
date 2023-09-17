namespace WKP.Domain.Enums_Contants
{
    public class AppResponseCodes
    {
        public const string Success = "00";
        public const string InternalError = "02";
        public const string Failed = "03";
        public const string DuplicateEmail = "04";
        public const string RecordNotFound = "05";
        public const string InvalidLogin = "06";
        public const string UserAlreadyExist = "07";
        public const string DuplicateUserDetails = "08";
        public const string InvalidAccountNo = "09";
        public const string UserNotFound = "10";
        public const string TransactionFailed = "11";
        public const string TransactionProcessed = "12";
        public const string AccountIsLocked = "13";
        public const string DuplicatePassword = "14";
        public const string OtpExpired = "15";
        public const string ExtraPaymentAlreadyExist = "16";
        public const string MissingParameter = "17";
        public const string InvalidParameterPassed = "18";
        public const string PaymentAlreadyExists = "19";
        public const string PaymentDoesNotExist = "20";
    }
}