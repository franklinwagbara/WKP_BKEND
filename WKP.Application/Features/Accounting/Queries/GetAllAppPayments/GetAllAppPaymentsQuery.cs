using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;

namespace WKP.Application.Features.Accounting.Queries
{
    public record GetAllAppPaymentsQuery(): IRequest<ErrorOr<AccountingResult>>;
}