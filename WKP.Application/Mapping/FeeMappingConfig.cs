using Mapster;
using WKP.Application.Fee.Commands;

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