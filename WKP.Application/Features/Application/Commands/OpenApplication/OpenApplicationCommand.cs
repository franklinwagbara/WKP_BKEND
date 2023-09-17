using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Application.Commands.OpenApplication
{
    public record OpenApplicationCommand(int DeskId): IRequest<ErrorOr<ApplicationResult>>;
}