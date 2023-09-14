
using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;

namespace WKP.Application.Fee.Commands.DeleteFee
{
    public record DeleteFeeCommand(int Id): IRequest<ErrorOr<FeeResult>>;
}