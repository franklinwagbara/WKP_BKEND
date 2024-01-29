using ErrorOr;
using MediatR;
using WKP.Application.Common.Interfaces;
using WKP.Application.Features.Admin.Common;
using WKP.Domain.Enums_Contants;

namespace WKP.Application.Features.Admin.Queries.GetCompanyElpsDetails
{
    public class GetCompanyElpsDetailsQueryHandler : IRequestHandler<GetCompanyElpsDetailsQuery, ErrorOr<AdminResult>>
    {
        private readonly IElpsService _elpsService;
        public GetCompanyElpsDetailsQueryHandler(IElpsService elpsService)
        {
            _elpsService = elpsService;
        }

        public async Task<ErrorOr<AdminResult>> Handle(GetCompanyElpsDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _elpsService.GetCompanyDetailsByEmail(request.Email);
                return new AdminResult(result);
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: $"{e.Message} --- {e.StackTrace?.ToString()} ~~~ {e.InnerException?.ToString()}");
            }
        }
    }
}
