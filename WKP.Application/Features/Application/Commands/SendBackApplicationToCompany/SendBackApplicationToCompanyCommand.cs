using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Commands.SendBackApplicationToCompany
{
    public record SendBackApplicationToCompanyCommand(
        int DeskID, 
        string Comment, 
        string[] SelectedApps, 
        string[] SelectedTables, 
        int TypeOfPaymentId, 
        string AmountNGN, 
        string AmountUSD, 
        int UserId,
        string UserEmail
    ): IRequest<ErrorOr<ApplicationResult>>;
}