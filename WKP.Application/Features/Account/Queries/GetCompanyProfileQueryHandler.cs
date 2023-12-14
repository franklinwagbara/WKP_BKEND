using ErrorOr;
using MediatR;
using WKP.Application.Account.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Account.Queries
{
    public class GetCompanyProfileQueryHandler : IRequestHandler<GetCompanyProfileQuery, ErrorOr<AccountResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElpsService _elpsService;

        public GetCompanyProfileQueryHandler(IUnitOfWork unitOfWork, IElpsService elpsService)
        {
            _unitOfWork = unitOfWork;
            _elpsService = elpsService;
        }

        public async Task<ErrorOr<AccountResult>> Handle(GetCompanyProfileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var companyProfile = await _unitOfWork.CompanyProfileRepository.GetAsync((c) => c.user_Id.ToLower().Equals(request.Email.ToLower()), null);

                if(companyProfile != null) 
                    return new AccountResult(companyProfile);
                else
                {
                    var result = await _elpsService.GetCompanyProfile(request.Email);
                    return await result.Match(
                        async res =>
                        {
                            res.elps_Id = res.id;
                            res.id = 0;
                            await _unitOfWork.CompanyProfileRepository.AddAsync(res);
                            await _unitOfWork.SaveChangesAsync();
                            return new AccountResult(res);
                        },
                        error => throw new Exception(error.First().ToString())
                    );
                }
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: $"{e.Message} +++ {e.StackTrace} ~~~ {e.InnerException?.ToString()}");
            }
        }
    }
}
