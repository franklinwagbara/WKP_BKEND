using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Application.Commands.PushApplicationCommand
{
    public record PushApplicationCommand(int DeskId, string Comment, int[] SelectedApps): IRequest<ErrorOr<ApplicationResult>>;
}