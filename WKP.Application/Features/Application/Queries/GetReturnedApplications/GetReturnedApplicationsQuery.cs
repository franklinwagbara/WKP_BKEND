using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetReturnedApplications
{
    public record GetReturnedApplicationsQuery(int CompanyId): IRequest<ErrorOr<ApplicationResult>>;
}