using MediatR;

namespace AirlineBookingSystem.Flight.Application.Commands;

public record CreateFlightCommand(string FlightNumber, string Origin, string Destination, DateTime DepartureTime, DateTime ArrivalTime): IRequest<Guid>;
