using ErrorOr;
using MediatR;
using WKP.Application.Features.Admin.Common;

namespace WKP.Application.Features.Admin.Queries.GetCompanyElpsDetails
{
    public record GetCompanyElpsDetailsQuery(string Email): IRequest<ErrorOr<AdminResult>>;
}
