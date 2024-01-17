using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;

namespace WKP.Application.Features.Application.Queries.LockForms
{
    public record LockFormsQuery(int Year, int ConcessionId, int FieldId): IRequest<ErrorOr<ApplicationResult>>;
}