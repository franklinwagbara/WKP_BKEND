using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.MoveApplication
{
    public record MoveApplicationCommand(int SourceStaffID, int TargetStaffID, string[] SelectedApps): IRequest<ErrorOr<ApplicationResult>>;
}