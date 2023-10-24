namespace WKP.Contracts.Features.Application
{
    public record RejectApplicationRequest(int AppId, string StaffEmail, string Comment);
}