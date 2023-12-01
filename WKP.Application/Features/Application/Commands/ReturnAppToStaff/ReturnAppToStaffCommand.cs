using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.ReturnAppToStaff
{
    public record ReturnAppToStaffCommand(
        int DeskID, 
        string Comment, 
        int[] SelectedApps,
        int[] SBU_IDs, 
        int[] SelectedTables, 
        bool FromWPAReviewer, 
        int CompanyId
    ): IRequest<ErrorOr<ApplicationResult>>;
}