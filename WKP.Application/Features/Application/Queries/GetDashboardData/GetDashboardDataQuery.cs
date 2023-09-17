using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Application.Queries.GetDashboardData
{
    public record GetDashboardDataQuery(int CompanyNumber): IRequest<ErrorOr<DashboardResult>>;
}