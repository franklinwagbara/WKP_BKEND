using ErrorOr;
using MapsterMapper;
using MediatR;
using WKP.Application.Account.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Account.Commands.UpdateCompanyDetails
{
    public class UpdateCompanyDetailsCommandHandler : IRequestHandler<UpdateCompanyDetailsCommand, ErrorOr<AccountResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElpsService _elpsService;
        private readonly IMapper _mapper;
        public UpdateCompanyDetailsCommandHandler(IUnitOfWork unitOfWork, IElpsService elpsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _elpsService = elpsService;
            _mapper = mapper;
        }

        public async Task<ErrorOr<AccountResult>> Handle(UpdateCompanyDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _unitOfWork.AdminCompanyDetailsRepository.GetAsync((d) => d.EMAIL.ToLower() == request.CompanyEmail, null);
                if(company == null) return Error.NotFound(code: ErrorCodes.NotFound, description: "Unable to find company details");

                var companyModel = new ElpsCompanyModel
                {
                    user_Id = company.CompanyId
                };

                _elpsService.UpdateCompanyNameAndEmail(_mapper.Map<ElpsCompanyModel>(company), company.EMAIL);

                if (company != null)
                {
                    company.Address_of_Company = request.Address_of_Company;
                    company.Phone_NO_of_MD_CEO = request.Phone_NO_of_MD_CEO;
                    company.Name_of_MD_CEO = request.Name_of_MD_CEO;
                    company.Contact_Person = request.Contact_Person;
                    company.Email_Address = request.Email_Address;
                    company.Phone_No = request.Phone_No;

                }
                else
                {
                    var companyDetail = new ADMIN_COMPANY_DETAIL
                    {
                        Address_of_Company = request.Address_of_Company,
                        //companyDetail.CompanyNumber=request.CompanyId;
                        Phone_NO_of_MD_CEO = request.Phone_NO_of_MD_CEO,
                        Name_of_MD_CEO = request.Name_of_MD_CEO,
                        Contact_Person = request.Contact_Person,
                        Email_Address = request.Email_Address,
                        Phone_No = request.Phone_No,
                        Phone_No_alt = request.Phone_No_alt,
                        COMPANY_NAME = request.CompanyName,
                        Created_by = request.CreatedByEmail,
                        Date_Created = DateTime.Now.ToLongDateString(),
                        EMAIL = request.CompanyEmail,
                        CompanyId = request.CompanyId
                    };

                    await _unitOfWork.AdminCompanyDetailsRepository.AddAsync(companyDetail);
                }

                await _unitOfWork.SaveChangesAsync();

                return new AccountResult(null, "Company detail was successfully updated.");
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message.ToString());
            }
        }
    }
}