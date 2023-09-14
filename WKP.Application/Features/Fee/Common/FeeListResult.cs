using WKP.Application.Common;

namespace WKP.Application.Fee.Common
{
    public record FeeListResult(IEnumerable<Domain.Entities.Fee> Fees);

    // public class FeeListResult : IRequestResult
    // {
    //     private readonly IEnumerable<Domain.Entities.Fee> _fees;

    //     public FeeListResult(IEnumerable<Domain.Entities.Fee> fees)
    //     {
    //         _fees = fees;
    //     }

    //     public IEnumerable<Domain.Entities.Fee> GetValue()
    //     {
    //         return _fees;
    //     }

    //     IEnumerable<object> IRequestResult.GetValue()
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}