using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetAllApplicationsCompany
{
    public record GetAllApplicationsCompanyQuery(int CompanyId): IRequest<ErrorOr<ApplicationResult>>;
}