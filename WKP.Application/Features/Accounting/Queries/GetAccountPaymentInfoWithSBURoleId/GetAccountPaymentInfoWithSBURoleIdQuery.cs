using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;

namespace WKP.Application.Features.Accounting.Queries.GetAccountPaymentInfoWithSBURoleId
{
    public record GetAccountPaymentInfoWithSBURoleIdQuery(): IRequest<ErrorOr<AccountingResult>>;
}