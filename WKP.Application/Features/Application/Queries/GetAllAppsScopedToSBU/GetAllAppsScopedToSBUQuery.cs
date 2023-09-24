using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetAllAppsScopedToSBU
{
    public record GetAllAppsScopedToSBUQuery(int UserId): IRequest<ErrorOr<ApplicationResult>>;
}