using ErrorOr;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.GetAllRejections
{
    public class GetAllRejectionsQueryHandler : IRequestHandler<GetAllRejectionsQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllRejectionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ApplicationResult>> Handle(GetAllRejectionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
               var result = await _unitOfWork.SubmissionRejectionRepository.GetRejections();
               return new ApplicationResult(result, "Success");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message + "\n" + e.StackTrace.ToString());
            }
        }
    }
}