using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetAllApplications
{
    public record GetAllApplicationsQuery: IRequest<ErrorOr<ApplicationResult>>;
}