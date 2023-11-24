using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries.GetAccountPaymentInfoWithSBURoleId
{
    public class GetAccountPaymentInfoWithSBURoleIdQueryHandler : IRequestHandler<GetAccountPaymentInfoWithSBURoleIdQuery, ErrorOr<AccountingResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAccountPaymentInfoWithSBURoleIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AccountingResult>> Handle(GetAccountPaymentInfoWithSBURoleIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AccountDeskRepository.GetDeskSummary();
                return new AccountingResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + " +++ " + e.StackTrace + " ~~~ "+ e.InnerException?.ToString());
            }
        }
    }
}