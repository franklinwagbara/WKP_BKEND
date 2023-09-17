using Mapster;
using WKP.Application.Fee.Commands;
using WKP.Domain.DTOs.Application;

namespace WKP.Application.Fee
{
    public class FeeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddFeeCommand, Domain.Entities.Fee>();
        }
    }
}