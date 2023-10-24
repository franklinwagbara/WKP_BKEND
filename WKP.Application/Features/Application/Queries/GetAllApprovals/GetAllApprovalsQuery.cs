using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetAllApprovals
{
    public record GetAllApprovalsQuery(): IRequest<ErrorOr<ApplicationResult>>;
}