using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.GetAllApprovals
{
    public class GetAllApprovalsQueryHandler : IRequestHandler<GetAllApprovalsQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllApprovalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(GetAllApprovalsQuery request, CancellationToken cancellationToken)
        {
            try
            {
               var result = await _unitOfWork.PermitApprovalRepository.GetAllApprovals();
               return new ApplicationResult(result, "Success");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + "\n" + e.StackTrace.ToString());
            }
        }
    }
}