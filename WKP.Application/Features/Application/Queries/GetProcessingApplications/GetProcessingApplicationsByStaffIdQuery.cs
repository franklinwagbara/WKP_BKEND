using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Application.Queries.GetProcessingApplications
{
    public record GetProcessingApplicationsByStaffIdQuery(int StaffId): IRequest<ErrorOr<ApplicationResult>>;
}