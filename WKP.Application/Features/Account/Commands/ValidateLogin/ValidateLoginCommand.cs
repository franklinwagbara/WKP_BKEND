using ErrorOr;
using MediatR;
using WKP.Application.Account.Common;

namespace WKP.Application.Features.Account.Commands.ValidateLogin
{
    public record ValidateLoginCommand(string Email, string Code): IRequest<ErrorOr<AccountResult>>;
}