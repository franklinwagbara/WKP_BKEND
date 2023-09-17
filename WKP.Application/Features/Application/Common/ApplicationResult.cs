namespace WKP.Application.Application.Common
{
    public record ApplicationResult(object Result, string? Message = null, string? ResponseCode = null);
}