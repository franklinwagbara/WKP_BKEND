using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries.GetPaymentOnDeskByDeskId
{
    public class GetPaymentOnDeskByDeskIdQueryCommand : IRequestHandler<GetPaymentOnDeskByDeskIdQuery, ErrorOr<AccountingResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPaymentOnDeskByDeskIdQueryCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AccountingResult>> Handle(GetPaymentOnDeskByDeskIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AccountDeskRepository.GetPaymentOnDeskByDeskId(request.DeskId);
                return new AccountingResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: $"{e.Message} +++ {e.StackTrace} ~~~ {e.InnerException?.ToString()}");
            }
        }
    }
}