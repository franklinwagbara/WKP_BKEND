using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;

namespace WKP.Application.Fee.Queries.GetFees
{
    public record GetFeesQuery(): IRequest<ErrorOr<FeeListResult>>;
}