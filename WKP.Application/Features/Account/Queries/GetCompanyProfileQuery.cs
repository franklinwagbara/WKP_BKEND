using ErrorOr;
using MediatR;
using WKP.Application.Account.Common;

namespace WKP.Application.Features.Account.Queries
{
    public record GetCompanyProfileQuery(string Email): IRequest<ErrorOr<AccountResult>>;
}
