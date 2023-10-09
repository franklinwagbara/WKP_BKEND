namespace WKP.Contracts.Features.Application
{
    public record ReturnAppToStaffRequest(
        int DeskID, 
        string Comment, 
        string[] SelectedApps,
        string[] SBU_IDs, 
        string[] SelectedTables, 
        bool FromWPAReviewer, 
        int CompanyId
    );
}