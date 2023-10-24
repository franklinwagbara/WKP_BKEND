using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.RejectApplication
{
    public record RejectApplicationCommand(int AppId, string StaffEmail, string Comment): IRequest<ErrorOr<ApplicationResult>>;
}