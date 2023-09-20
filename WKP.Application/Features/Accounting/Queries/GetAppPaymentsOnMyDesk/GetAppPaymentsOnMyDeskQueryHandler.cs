using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries
{
    public class GetAppPaymentsOnMyDeskQueryHandler : IRequestHandler<GetAppPaymentsOnMyDeskQuery, ErrorOr<AccountingResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppPaymentsOnMyDeskQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AccountingResult>> Handle(GetAppPaymentsOnMyDeskQuery request, CancellationToken cancellationToken)
        {
            var payments = await _unitOfWork.AccountDeskRepository.GetAppPaymentsOnStaffDesk(request.StaffEmail);
            return new AccountingResult(payments, "Success");
        }
    }
}