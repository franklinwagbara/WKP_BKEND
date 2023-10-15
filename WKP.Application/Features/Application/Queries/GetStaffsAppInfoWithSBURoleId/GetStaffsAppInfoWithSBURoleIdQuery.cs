using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetStaffsAppInfoWithSBURoleId
{
    public record GetStaffsAppInfoWithSBURoleIdQuery(int SBUId, int RoleId): IRequest<ErrorOr<ApplicationResult>>;
}