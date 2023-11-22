namespace WKP.Application.Account.Common
{
    public record AccountResult(object Result, string? Message = null, string? ResponseCode = null);
}