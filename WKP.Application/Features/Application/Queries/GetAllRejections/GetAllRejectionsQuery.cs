using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetAllRejections
{
    public record GetAllRejectionsQuery(): IRequest<ErrorOr<ApplicationResult>>;
}