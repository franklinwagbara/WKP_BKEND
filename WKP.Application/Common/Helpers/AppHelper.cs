using WKP.Domain.Enums_Contants;

namespace WKP.Application.Common.Helpers
{
    public class AppHelper
    {
        public bool IsIncomingDeskStatus(string status) => GetListOfIncomingDeskStatuses().Contains(status);
        
        
        public List<string> GetListOfIncomingDeskStatuses()
            => new List<string> {
                DESK_PROCESS_STATUS.FinalAuthorityApproved,
                DESK_PROCESS_STATUS.SubmittedByCompany,
                DESK_PROCESS_STATUS.SubmittedByStaff
            };
    }
}