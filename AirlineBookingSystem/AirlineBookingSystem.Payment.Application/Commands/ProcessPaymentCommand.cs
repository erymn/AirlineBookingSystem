using MediatR;

namespace AirlineBookingSystem.Payment.Application.Commands;

public record ProcessPaymentCommand(Guid BookingId, decimal Amount): IRequest<Guid>;
