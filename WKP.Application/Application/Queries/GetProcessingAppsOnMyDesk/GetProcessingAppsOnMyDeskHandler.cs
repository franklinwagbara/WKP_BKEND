using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Application.Queries.GetProcessingAppsOnMyDesk
{
    public class GetProcessingAppsOnMyDeskHandler : IRequestHandler<GetProcessingAppsOnMyDeskQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProcessingAppsOnMyDeskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<ApplicationResult>> Handle(GetProcessingAppsOnMyDeskQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var curStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyEmail(request.CompanyEmail);
                var apps = await _unitOfWork.ApplicationRepository.GetProcesingAppsByStaffId(StaffId: curStaff.StaffID);
                
                return new ApplicationResult(apps);
            }
            catch (Exception ex)
            {
                return Error.Failure(ErrorCodes.InternalFailure, description: ex.Message);
            }
            
        }
    }
}