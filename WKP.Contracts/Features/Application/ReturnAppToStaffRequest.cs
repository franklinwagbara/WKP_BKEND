namespace WKP.Contracts.Features.Application
{
    public record ReturnAppToStaffRequest(
        int DeskID, 
        string Comment, 
        int[] SelectedApps,
        int[] SBU_IDs, 
        int[] SelectedTables, 
        bool FromWPAReviewer, 
        int CompanyId
    );
}