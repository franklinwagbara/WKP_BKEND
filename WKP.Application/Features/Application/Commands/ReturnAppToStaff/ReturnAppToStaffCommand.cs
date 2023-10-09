using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.ReturnAppToStaff
{
    public record ReturnAppToStaffCommand(
        int DeskID, 
        string Comment, 
        string[] SelectedApps,
        string[] SBU_IDs, 
        string[] SelectedTables, 
        bool FromWPAReviewer, 
        int CompanyId
    ): IRequest<ErrorOr<ApplicationResult>>;
}