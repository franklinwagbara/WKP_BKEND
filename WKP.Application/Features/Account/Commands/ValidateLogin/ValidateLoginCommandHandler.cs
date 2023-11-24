using ErrorOr;
using MapsterMapper;
using MediatR;
using WKP.Application.Account.Common;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Features.Account.Commands.ValidateLogin
{
    public class ValidateLoginCommandHandler : IRequestHandler<ValidateLoginCommand, ErrorOr<AccountResult>>
    {
        private readonly IElpsService _elpsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUtilsInjectable _utils;

        public ValidateLoginCommandHandler(IElpsService elpsService, IUnitOfWork unitOfWork, IMapper mapper, IUtilsInjectable utilsInjectable)
        {
            _elpsService = elpsService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _utils = utilsInjectable;
        }

        public async Task<ErrorOr<AccountResult>> Handle(ValidateLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Email))
                {
                    var result = await _elpsService.GetCompanyDetailsByEmail(request.Email);
                    
                    if(!result.IsError)
                    {
                        //It is company that is loging in
                        var elpsCompanyDetail = result.Value;
                        var wkpCompanyInfo = await _unitOfWork.AdminCompanyInformationRepository.GetActiveCompanyByEmail(request.Email);

                        if(wkpCompanyInfo == null)
                        {
                            ErrorOr<ADMIN_COMPANY_INFORMATION> res = Error.Failure();

                            await _unitOfWork.ExecuteTransaction(async () => 
                            {
                                res = await AddCompanyToWKP(elpsCompanyDetail, request.Email);
                            });
                            
                            if(res.IsError)
                                return Error.Failure(code: ErrorCodes.InternalFailure, description: res.FirstError.Description);
                            
                            wkpCompanyInfo = res.Value;
                        }

                        return new AccountResult(wkpCompanyInfo);
                    }
                    else
                    {
                        //Might be a staff loging in
                        var res = await _elpsService.GetStaffDetailByEmail(request.Email);
                        
                        if(!res.IsError)
                        {
                            var elpsStaffDetail = res.Value;
                            var wkpStaffInfo = await _unitOfWork.StaffRepository.GetStaffByCompanyEmail(request.Email);

                            if(wkpStaffInfo == null)
                            {
                                ErrorOr<ADMIN_COMPANY_INFORMATION> rs = Error.Failure();

                                await _unitOfWork.ExecuteTransaction(async () => 
                                {
                                    rs = await AddStaffToWKP(elpsStaffDetail);
                                });

                                if(rs.IsError)
                                    return Error.Failure(code: ErrorCodes.InternalFailure, description: res.FirstError.Description);

                                return new AccountResult(rs.Value);
                            }

                            return new AccountResult(wkpStaffInfo);
                        }
                        else
                            return Error.Failure(code: ErrorCodes.InternalFailure, description: res.FirstError.Description);
                    }
                }
                else
                {
                    var wkpCompanyDetail = await _unitOfWork.AdminCompanyInformationRepository.GetActiveCompanyByEmail(request.Email);

                    if(wkpCompanyDetail != null)
                        return new AccountResult(wkpCompanyDetail);
                    return Error.NotFound(code: ErrorCodes.NotFound, description: "User was not found!");
                }
            }
            catch (Exception e)
            {
                return Error.Failure(code: ErrorCodes.InternalFailure, description: e.Message.ToString() + "+++" + e.StackTrace?.ToString());
            }
        }

        private async Task<ErrorOr<ADMIN_COMPANY_INFORMATION>> AddCompanyToWKP(ElpsCompanyDetail CompanyInfo, string Email)
        {
            var companyFound = await _unitOfWork.AdminCompanyInformationRepository.GetCompanyByEmail(Email);

            if(companyFound != null)
            {
                if(companyFound.DELETED_STATUS == DELETE_STATUS.Deleted)
                    return Error.Failure(code: ErrorCodes.NotFound, description: "This user was deleted. Kindly restore account information.");

                if(companyFound.STATUS_ == USER_STATUS.Deactivated)
                    return Error.Failure(code: ErrorCodes.InternalFailure, description: "This user was deactivated. Kindly reactivate the user.");
                return Error.Failure(code: ErrorCodes.InternalFailure, description: "Something went wrong. User was not created.");
            }
            else
            {
                var wkpCompany = _mapper.Map<ADMIN_COMPANY_INFORMATION>(CompanyInfo);

                wkpCompany.STATUS_ = USER_STATUS.Activated;
                wkpCompany.Date_Created = DateTime.Now;
                wkpCompany.Created_by = Email;

                var companyCode = await GenerateCompanyCode(wkpCompany);
                wkpCompany.COMPANY_ID = companyCode;

                await _unitOfWork.AdminCompanyInformationRepository.AddAsync(wkpCompany);
                await _unitOfWork.SaveChangesAsync();

                return wkpCompany;
            }
        }

        private async Task<ErrorOr<ADMIN_COMPANY_INFORMATION>> AddStaffToWKP(ElpsStaffDetail staffInfo)
        {
            var staffFound = await _unitOfWork.AdminCompanyInformationRepository
                    .GetAsync(c => c.EMAIL.ToLower().Equals(staffInfo.email) && c.COMPANY_NAME.Equals("Admin"), null);

            if(staffFound != null)
            {
                if(staffFound.DELETED_STATUS == DELETE_STATUS.Deleted)
                    return Error.Failure(code: ErrorCodes.NotFound, description: "This user was deleted. Kindly restore account information.");

                if(staffFound.STATUS_ == USER_STATUS.Deactivated)
                    return Error.Failure(code: ErrorCodes.InternalFailure, description: "This user was deactivated. Kindly reactivate the user.");
                return Error.Failure(code: ErrorCodes.InternalFailure, description: "Something went wrong. User was not created.");
            }
            else
            {
                
                var wkpStaff = _mapper.Map<ADMIN_COMPANY_INFORMATION>(staffInfo);

                wkpStaff.COMPANY_NAME = "Admin";
                wkpStaff.STATUS_ = USER_STATUS.Activated;
                wkpStaff.Date_Created = DateTime.Now;
                wkpStaff.Created_by = staffInfo.email;

                var companyCode = await GenerateCompanyCode(wkpStaff);
                wkpStaff.COMPANY_ID = companyCode;
                
                await _unitOfWork.AdminCompanyInformationRepository.AddAsync(wkpStaff);

                var newStaff = new staff()
                {
                    AdminCompanyInfo_ID = wkpStaff.Id,
                    StaffElpsID = wkpStaff.ELPS_ID.ToString(),
                    Staff_SBU = 0,
                    RoleID = 1,
                    LocationID = 1,
                    StaffEmail = wkpStaff.EMAIL,
                    FirstName = staffInfo.firstName,
                    LastName = staffInfo.lastName,
                    CreatedAt = DateTime.Now,
                    ActiveStatus = true,
                    DeleteStatus = false
                };
                await _unitOfWork.StaffRepository.AddAsync(newStaff);
                await _unitOfWork.SaveChangesAsync();

                return wkpStaff;
            }
        }

        private async Task<string> GenerateCompanyCode(ADMIN_COMPANY_INFORMATION wkpStaff)
        {
            if(wkpStaff == null)
                throw new Exception("Passed a null value as staff info.");
            string companyCode = string.Empty;

            do
            {
                 companyCode = _utils.GenerateCompanyCode(wkpStaff.COMPANY_NAME ?? "Admin");
            }while(await _unitOfWork.AdminCompanyInformationRepository.GetAsync((a) => a.COMPANY_ID == companyCode, null) != null);

            return companyCode;
        }
    }
}