namespace WKP.Domain.Entities
{
    public class FormLock
    {
        public bool disableSubmission { get; set; }
        public bool enableReSubmission { get; set; }
        public List<string>? formsToBeEnabled { get; set; }
    }
}