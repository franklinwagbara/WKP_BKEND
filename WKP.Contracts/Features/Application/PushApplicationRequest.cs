namespace WKP.Contracts.Application
{
    public record PushApplicationRequest(int DeskId, string Comment, string[] SelectedApps);
}