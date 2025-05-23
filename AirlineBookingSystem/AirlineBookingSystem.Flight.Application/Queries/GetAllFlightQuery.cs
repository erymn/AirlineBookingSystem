using MediatR;

namespace AirlineBookingSystem.Flight.Application.Queries;

public record GetAllFlightQuery() : IRequest<IEnumerable<Core.Entities.Flight>>;
