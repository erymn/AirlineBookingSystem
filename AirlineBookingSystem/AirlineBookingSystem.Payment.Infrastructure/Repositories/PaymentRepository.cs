using AirlineBookingSystem.Payment.Core.Repositories;

namespace AirlineBookingSystem.Payment.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    public async Task ProcessPaymentAsync(Core.Entities.Payment payment)
    {
        throw new NotImplementedException();
    }

    public async Task RefundPaymentAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}