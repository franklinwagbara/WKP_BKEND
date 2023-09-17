using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Application.Queries.GetDashboardData
{
    public class GetDashboardDataQueryHandler : IRequestHandler<GetDashboardDataQuery, ErrorOr<DashboardResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDashboardDataQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<DashboardResult>> Handle(GetDashboardDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var deskCount = 0;
                var allApplicationsCountSBU = 0;
                var allApplicationsCount = 0;
                var allProcessingCount = 0;
                var allApprovalsCount = 0;
                var allRejectionsCount = 0;

                var currentStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyNumber(request.CompanyNumber);

                if (currentStaff != null)
                {
                    deskCount = await _unitOfWork.DeskRepository.GetStaffDeskCount(currentStaff.StaffID);
                    allProcessingCount = await _unitOfWork.DeskRepository.GetStaffAppProcessingDeskCount(currentStaff.StaffID);
                    allApplicationsCountSBU = await _unitOfWork.ApplicationRepository.GetAllSubAppCountBySBU(currentStaff.StaffID);
                    allApplicationsCount = await _unitOfWork.ApplicationRepository.GetAllSubAppCount();
                }

                allApplicationsCount = await _unitOfWork.ApplicationRepository.GetAllRejectedAppCount();
                allApprovalsCount = await _unitOfWork.PermitApprovalRepository.GetAllApprovalCount(); 

                var result = new {
                    deskCount = deskCount,
                    allApplicationsCountSBU = allApplicationsCountSBU,
                    allApplicationsCount = allApplicationsCount,
                    allProcessingCount = allProcessingCount,
                    allApprovalsCount = allApprovalsCount,
                    allRejectionsCount = allRejectionsCount
                };

                return new DashboardResult(result);
            }
            catch (System.Exception ex)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: ex.Message);
            }
        }
    }
}