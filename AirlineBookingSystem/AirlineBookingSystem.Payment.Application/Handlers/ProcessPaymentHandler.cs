using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payment.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Handlers;

public class ProcessPaymentHandler : IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;

    public ProcessPaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    
    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Core.Entities.Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow
        };
        
        await _paymentRepository.ProcessPaymentAsync(payment);
        return payment.Id;
    }
}