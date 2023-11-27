namespace WKP.Contracts.Features.Application
{
    public record AddCommentByStaffRequest(int appId, int? staffId, string comment, string? selectedTables, bool? isPublic);
}