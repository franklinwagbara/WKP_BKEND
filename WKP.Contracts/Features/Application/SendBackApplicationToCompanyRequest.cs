namespace WKP.Contracts.Features.Application
{
    public record SendBackApplicationToCompanyRequest(
        int DeskID, 
        string Comment, 
        string[] SelectedApps, 
        string[] SelectedTables, 
        int TypeOfPaymentId, 
        string AmountNGN, 
        string AmountUSD, 
        int UserId,
        string UserEmail
    );
}