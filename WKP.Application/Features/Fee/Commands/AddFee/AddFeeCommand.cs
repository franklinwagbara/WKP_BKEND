using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;

namespace WKP.Application.Fee.Commands
{
    public record AddFeeCommand(
        int Id,
        string AmountNGN,
        string AmountUSD, 
        int TypeOfPaymentId
    ): IRequest<ErrorOr<FeeResult>>;
}