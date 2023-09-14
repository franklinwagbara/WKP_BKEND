using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;

namespace WKP.Application.Fee.Queries.GetOtherFees
{
    public record GetOtherFeesQuery(): IRequest<ErrorOr<FeeListResult>>;
}