using Mapster;
using WKP.Domain.Entities;

namespace WKP.Application.Mapping
{
    public class AdminCompanyDetailsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // config.NewConfig<ADMIN_COMPANY_DETAIL, ElpsCompanyModel>()
            //     .Map(d => d.user_Id, s => s.Id)
            //     .Map(d => d.name, s => s.COMPANY_NAME)
            //     // .Map(d => d.business_Type, s => s.)
            //     // .Map(d => d.registered_Address_Id, s => s.)
            //     // .Map(d => d.operational_Address_Id)
            //     // .Map(d => d.contact_FirstName, s => s.)
            //     .Map(d => d.rC_Number, s => s.)
        }
    }
}