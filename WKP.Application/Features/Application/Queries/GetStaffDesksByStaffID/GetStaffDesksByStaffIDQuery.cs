using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.GetStaffDesksByStaffID
{
    public record GetStaffDesksByStaffIDQuery(int StaffId): IRequest<ErrorOr<ApplicationResult>>;
}