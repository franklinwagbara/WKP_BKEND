namespace WKP.Application.Features.Accounting.Common
{
    public record AccountingResult(object Result, string? Message = null, string? ResponseCode = null);
}