using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries.GetAllUSDPaymentApprovals
{
    public class GetAllUSDPaymentApprovalsQueryHandler : IRequestHandler<GetAllUSDPaymentApprovalsQuery, ErrorOr<AccountingResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUSDPaymentApprovalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AccountingResult>> Handle(GetAllUSDPaymentApprovalsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AccountDeskRepository.GetAllAppPaymentApprovals();
            return new AccountingResult(result, "Success");
        }
    }
}