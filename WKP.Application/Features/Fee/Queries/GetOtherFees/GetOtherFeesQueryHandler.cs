using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Fee.Queries.GetOtherFees
{
    public class GetOtherFeesQueryHandler : IRequestHandler<GetOtherFeesQuery, ErrorOr<FeeListResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOtherFeesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<FeeListResult>> Handle(GetOtherFeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.FeeRepository.GetAsync(
                (x) => x.TypeOfPayment.Category == PAYMENT_CATEGORY.OtherPayment, null,
                new[] { Domain.Entities.Fee.NavigationProperty.TypeOfPayments });

            return new FeeListResult(result);
        }
    }
}