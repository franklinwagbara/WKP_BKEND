using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;

namespace WKP.Application.Features.Accounting.Queries.GetAppPayOnStaffDeskByStaffId
{
    public record GetAppPayOnStaffDeskByStaffIdQuery(int StaffId): IRequest<ErrorOr<AccountingResult>>;
}