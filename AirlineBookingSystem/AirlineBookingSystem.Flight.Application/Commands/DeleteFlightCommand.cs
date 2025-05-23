using MediatR;

namespace AirlineBookingSystem.Flight.Application.Commands;

public record DeleteFlightCommand(Guid Id) : IRequest;
