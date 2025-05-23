using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payment.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Handlers;

public class RefundPaymentHandler: IRequestHandler<RefundPaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;

    public RefundPaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Guid> Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await _paymentRepository.RefundPaymentAsync(request.PaymentId);
        return request.PaymentId;
    }
}