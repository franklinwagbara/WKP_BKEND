namespace WKP.Contracts.Features.Application
{
    public record AddCommentByCompanyRequest(int appId, int? staffId, string comment, string? selectedTables);
}
