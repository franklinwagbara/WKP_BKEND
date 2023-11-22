using Mapster;
using WKP.Domain.Entities;

namespace WKP.Application.Mapping
{
    public class AdminCompanyInformationConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ElpsCompanyDetail, ADMIN_COMPANY_INFORMATION>()
                .Map(d => d.COMPANY_NAME, s => s.name)
                .Map(d => d.EMAIL, s => s.user_Id)
                .Map(d => d.NAME, s => s.name)
                .Map(d => d.PHONE_NO, s => s.contact_Phone)
                .Map(d => d.ELPS_ID, s => s.id)
                .Map(d => d.CompanyAddress, s => s.address_1);

            config.NewConfig<ElpsStaffDetail, ADMIN_COMPANY_INFORMATION>()
                .Map(d => d.COMPANY_NAME, s => s.firstName + ", " + s.lastName)
                .Map(d => d.EMAIL, s => s.email)
                .Map(d => d.NAME, s => s.firstName + ", " + s.lastName)
                .Map(d => d.PHONE_NO, s => s.phoneNo)
                .Map(d => d.ELPS_ID, s => s.elpsId);
        }
    }
}