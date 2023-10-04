using WKP.Domain.DTOs.Payment;
using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IPaymentRepository: IBaseRepository<Payments>
    {
        Task<Payments> AddAsync(PaymentDTO payment, string AccountNumber);
    }
}