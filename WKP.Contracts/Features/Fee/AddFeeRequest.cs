namespace WKP.Contracts.Fee
{
    public record AddFeeRequest(
        int Id,
        string AmountNGN,
        string AmountUSD, 
        int TypeOfPaymentId
    );
}
