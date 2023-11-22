
using ErrorOr;
using WKP.Domain.Entities;

namespace WKP.Application.Common.Interfaces
{
    public interface IElpsService
    {
        public Task UpdateCompanyDetails(ElpsCompanyModel model, string email);
        public Task UpdateCompanyNameAndEmail(ElpsCompanyModel model, string email);
        public Task<ErrorOr<ElpsCompanyDetail>> GetCompanyDetailsByEmail(string Email);
        public Task<ErrorOr<ElpsStaffDetail>> GetStaffDetailByEmail(string Email);
    }
}