using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries.NewFolder
{
    public class GetAllPendingAppPaymentsQueryHandler : IRequestHandler<GetAllPendingAppPaymentsQuery, ErrorOr<AccountingResult>>
    {
        public IUnitOfWork _unitOfWork;

        public GetAllPendingAppPaymentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AccountingResult>> Handle(GetAllPendingAppPaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AccountDeskRepository.GetAllPendingAppPayments();
                return new AccountingResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: $"{e.Message} +++ {e.StackTrace} ~~~ {e.InnerException.ToString()}");
            }
        }
    }
}
