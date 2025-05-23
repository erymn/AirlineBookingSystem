using MediatR;

namespace AirlineBookingSystem.Payment.Application.Commands;

public record RefundPaymentCommand(Guid PaymentId) : IRequest<Guid>;
