using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.ApproveApplication
{
    public record ApproveApplicationCommand(int AppId, string StaffEmail): IRequest<ErrorOr<ApplicationResult>>;
}