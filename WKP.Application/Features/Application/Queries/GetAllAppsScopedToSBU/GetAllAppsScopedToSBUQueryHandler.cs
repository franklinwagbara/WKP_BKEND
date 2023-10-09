using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.GetAllAppsScopedToSBU
{
    public class GetAllAppsScopedToSBUQueryHandler : IRequestHandler<GetAllAppsScopedToSBUQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAppsScopedToSBUQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(GetAllAppsScopedToSBUQuery request, CancellationToken cancellationToken)
        {
            var actingStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyNumberWithSBU(request.UserId);
            var result = await _unitOfWork.ApplicationRepository
                    .GetAllAppsScopedToSBU(actingStaff);
            return new ApplicationResult(result, "Success");
        }
    }
}