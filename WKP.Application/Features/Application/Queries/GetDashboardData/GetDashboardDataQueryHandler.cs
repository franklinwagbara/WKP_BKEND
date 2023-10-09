using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Entities;
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
                var currentStaff = await _unitOfWork.StaffRepository.GetStaffByCompanyNumberWithSBU(request.CompanyNumber);

                if(currentStaff is null) throw new Exception("Staff can not be null.");

                object result;

                if(currentStaff.StrategicBusinessUnit.SBU_Code == SBU_CODES.ACCOUNTS)
                    result = await GetDashBoardInfoForAccounts(currentStaff);
                else result = await GetDashBoardInfoForStaff(currentStaff);

                return new DashboardResult(result);
            }
            catch (System.Exception ex)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: ex.Message);
            }
        }
        
        private async Task<object> GetDashBoardInfoForStaff(staff CurrentStaff)
        {
            var deskCount = await _unitOfWork.DeskRepository.GetStaffDeskCount(CurrentStaff.StaffID);
            var allProcessingCount = await _unitOfWork.DeskRepository.GetStaffAppProcessingDeskCount(CurrentStaff.StaffID);
            var allApplicationsCountSBU = await _unitOfWork.ApplicationRepository.GetAllSubAppCountBySBU((int)CurrentStaff.Staff_SBU);
            var allApplicationsCount = await _unitOfWork.ApplicationRepository.GetAllSubAppCount();

            var allRejectionsCount = await _unitOfWork.ApplicationRepository.GetAllRejectedAppCount();
            var allApprovalsCount = await _unitOfWork.PermitApprovalRepository.GetAllApprovalCount();

            var result = new {
                deskCount = deskCount,
                allApplicationsCountSBU,
                allApplicationsCount = allApplicationsCount,
                allProcessingCount = allProcessingCount,
                allApprovalsCount = allApprovalsCount,
                allRejectionsCount = allRejectionsCount
            };

            return result;
        }

        private async Task<object> GetDashBoardInfoForAccounts(staff CurrentStaff)
        {
            var deskCount = await _unitOfWork.AccountDeskRepository.GetDeskCount(CurrentStaff.StaffID);
            var allProcessingCount = await _unitOfWork.AccountDeskRepository.GetProcessingCount(CurrentStaff.StaffID);
            var allApplicationsCountSBU = await _unitOfWork.AccountDeskRepository.GetAllPaymentCounts();
            var allApplicationsCount = await _unitOfWork.AccountDeskRepository.GetAllPaymentCounts();

            var allRejectionsCount = await _unitOfWork.AccountDeskRepository.GetPaymentRejectionCount();
            var allApprovalsCount = await _unitOfWork.AccountDeskRepository.GetPaymentApprovalCount();

            var result = new {
                deskCount = deskCount,
                allApplicationsCountSBU,
                allApplicationsCount = allApplicationsCount,
                allProcessingCount = allProcessingCount,
                allApprovalsCount = allApprovalsCount,
                allRejectionsCount = allRejectionsCount
            };

            return result;
        }
    }
}