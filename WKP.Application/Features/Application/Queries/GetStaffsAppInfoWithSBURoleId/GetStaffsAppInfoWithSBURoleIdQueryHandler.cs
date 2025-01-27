using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.GetStaffsAppInfoWithSBURoleId
{
    public class GetStaffsAppInfoWithSBURoleIdQueryHandler : IRequestHandler<GetStaffsAppInfoWithSBURoleIdQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStaffsAppInfoWithSBURoleIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(GetStaffsAppInfoWithSBURoleIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sbu = await _unitOfWork.SBURepository.GetAsync((s) => s.Id == request.SBUId, null);
                IEnumerable<object> result = new List<object>();

                if(sbu?.SBU_Code == SBU_CODES.ACCOUNTS)
                    result = await _unitOfWork.AccountDeskRepository.GetDeskSummary();
                else 
                    result = await _unitOfWork.ApplicationRepository.GetStaffsAppInfoWithSBURoleId(request.SBUId, request.RoleId);
                return new ApplicationResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }
    }
}