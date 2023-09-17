using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Application.Queries.GetProcessingApplications
{
    public class GetProcessingApplicationsByStaffIdHandler : 
        IRequestHandler<GetProcessingApplicationsByStaffIdQuery, 
        ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProcessingApplicationsByStaffIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(GetProcessingApplicationsByStaffIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ApplicationRepository.GetProcesingAppsByStaffId(request.StaffId);
            return new ApplicationResult(result);
        }
    }
}