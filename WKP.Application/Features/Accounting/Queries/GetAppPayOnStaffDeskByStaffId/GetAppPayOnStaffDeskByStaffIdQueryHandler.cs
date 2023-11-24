using ErrorOr;
using MediatR;
using WKP.Application.Features.Accounting.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Accounting.Queries.GetAppPayOnStaffDeskByStaffId
{
    public class GetAppPayOnStaffDeskByStaffIdQueryHandler : IRequestHandler<GetAppPayOnStaffDeskByStaffIdQuery, ErrorOr<AccountingResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAppPayOnStaffDeskByStaffIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AccountingResult>> Handle(GetAppPayOnStaffDeskByStaffIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AccountDeskRepository.GetAppPendingPaymentsOnStaffDesk(request.StaffId);
                return new AccountingResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: $"{e.Message} +++ {e.StackTrace} ~~~ {e.InnerException?.ToString()}");
            }
        }
    }
}