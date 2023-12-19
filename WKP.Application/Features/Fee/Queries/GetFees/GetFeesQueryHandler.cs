using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Fee.Queries.GetFees
{
    public class GetFeesQueryHandler : IRequestHandler<GetFeesQuery, ErrorOr<FeeListResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFeesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<FeeListResult>> Handle(GetFeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.FeeRepository.GetAsync(
                    null, null,
                    new[] { Domain.Entities.Fee.NavigationProperty.TypeOfPayments }
                );
                return new FeeListResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + " +++ " + e.StackTrace + " ~~~ " + e.InnerException?.ToString());
            }
        }
    }
}