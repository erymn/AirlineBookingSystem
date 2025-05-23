using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Handlers;

public class CreateFlightHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IFlightRepository _flightRepository;

    public CreateFlightHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    
    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Core.Entities.Flight()
        {
            Id = Guid.NewGuid(),
            FlightNumber = request.FlightNumber,
            Origin = request.Origin,
            Destination = request.Destination,
            DepartureTime = request.DepartureTime,
            ArrivalTime = request.ArrivalTime,
        };
        
        await _flightRepository.AddFlightAsync(flight);
        return flight.Id;
    }
}