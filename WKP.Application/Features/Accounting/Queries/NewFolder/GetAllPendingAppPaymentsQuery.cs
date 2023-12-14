using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;

namespace WKP.Application.Features.Accounting.Queries.NewFolder
{
    public record GetAllPendingAppPaymentsQuery(): IRequest<ErrorOr<AccountingResult>>;
}
