namespace WKP.Application.Features.Admin.Common
{
    public record AdminResult(object Result, string? Message = null, string? ResponseCode = null);
}
