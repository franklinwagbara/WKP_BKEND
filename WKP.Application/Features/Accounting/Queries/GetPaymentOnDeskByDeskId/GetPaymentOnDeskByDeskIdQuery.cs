using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;

namespace WKP.Application.Features.Accounting.Queries.GetPaymentOnDeskByDeskId
{
    public record GetPaymentOnDeskByDeskIdQuery(int DeskId): IRequest<ErrorOr<AccountingResult>>;
}