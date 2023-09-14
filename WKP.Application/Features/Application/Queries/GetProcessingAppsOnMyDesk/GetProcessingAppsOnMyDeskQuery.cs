using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Application.Queries.GetProcessingAppsOnMyDesk
{
    public record GetProcessingAppsOnMyDeskQuery(string CompanyEmail): IRequest<ErrorOr<ApplicationResult>>;
}