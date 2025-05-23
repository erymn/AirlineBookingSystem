using MediatR;

namespace AirlineBookingSystem.Booking.Application.Commands;

public record CreateBookingCommand(Guid FlightId, string PassengerName, string SeatNumber): IRequest<Guid>;