using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries.GetAllAppPayments
{
    public class GetAllAppPaymentsQueryHandler : IRequestHandler<GetAllAppPaymentsQuery, ErrorOr<AccountingResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAppPaymentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<AccountingResult>> Handle(GetAllAppPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _unitOfWork.AccountDeskRepository.GetAllAppPayments();
            return new AccountingResult(payments, "Success");
        }
    }
}