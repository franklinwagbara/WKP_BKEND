using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;

namespace WKP.Application.Features.Accounting.Queries.GetAllUSDPaymentApprovals
{
    public record GetAllUSDPaymentApprovalsQuery(): IRequest<ErrorOr<AccountingResult>>;
}