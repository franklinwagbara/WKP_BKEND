using ErrorOr;
using MapsterMapper;
using MediatR;
using WKP.Application.Application.Common;
using WKP.Domain.DTOs.Application;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Application.Queries.GetReturnedApplications
{
    public class GetReturnedApplicationsQueryHandler :
        IRequestHandler<GetReturnedApplicationsQuery, ErrorOr<ApplicationResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReturnedApplicationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<ApplicationResult>> Handle(GetReturnedApplicationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var apps = await _unitOfWork.ApplicationRepository
                    .GetReturnedAppsByCompanyId(request.CompanyId);
                var result = _mapper.Map<IEnumerable<ApplicationDTO>>(apps);
                return new ApplicationResult(result);
            }
            catch (Exception e){
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message);
            }
        }
    }
}