using Microsoft.EntityFrameworkCore;
using WKP.Domain.DTOs.Payment;
using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;

namespace WKP.Infrastructure.Persistence
{
    public class PaymentRepository : BaseRepository<Payments>, IPaymentRepository
    {
        private readonly WKPContext _context;
        public PaymentRepository(WKPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payments> AddAsync(PaymentDTO model, string AccountNumber)
        {
            var payment = new Payments
                {
                    AppId = model.AppId,
                    AmountNGN = $"{model.AmountNGN}",
                    ConcessionId = model.ConcessionId,
                    AmountUSD = $"{model.AmountUSD}",
                    CompanyNumber = model.CompanyNumber,
                    FieldId = model.FieldId,
                    Status = PAYMENT_STATUS.PaymentPending,
                    TransactionDate = DateTime.UtcNow.AddHours(1),
                    TypeOfPaymentId = model.TypeOfPayment,
                    AccountNumber = AccountNumber,
                    ServiceCharge = model.ServiceCharge,
                    OrderId = model.OrderId,
                    Currency= model.Currency,
                };
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}