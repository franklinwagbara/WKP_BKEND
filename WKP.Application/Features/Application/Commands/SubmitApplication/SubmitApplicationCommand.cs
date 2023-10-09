using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.SubmitApplication
{
    public record SubmitApplicationCommand(int AppId): IRequest<ErrorOr<ApplicationResult>>;
}