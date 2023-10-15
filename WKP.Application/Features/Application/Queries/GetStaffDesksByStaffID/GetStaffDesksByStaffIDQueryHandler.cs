using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.GetStaffDesksByStaffID
{
    public class GetStaffDesksByStaffIDQueryHandler : IRequestHandler<GetStaffDesksByStaffIDQuery, ErrorOr<ApplicationResult>>
    {
        private IUnitOfWork _unitOfWork;

        public GetStaffDesksByStaffIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   

        public async Task<ErrorOr<ApplicationResult>> Handle(GetStaffDesksByStaffIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.ApplicationRepository.GetAppsOnMyDeskByStaffID(request.StaffId);
                return new ApplicationResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }
    }
}