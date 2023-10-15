namespace WKP.Contracts.Features.Application
{
    public record MoveApplicationRequest(int SourceStaffID, int TargetStaffID, string[] SelectedApps);
}