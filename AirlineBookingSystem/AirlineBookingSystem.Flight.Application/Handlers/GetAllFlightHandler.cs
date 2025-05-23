using AirlineBookingSystem.Flight.Application.Queries;
using AirlineBookingSystem.Flight.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Handlers;

public class GetAllFlightHandler : IRequestHandler<GetAllFlightQuery, IEnumerable<Core.Entities.Flight>>
{
    private readonly IFlightRepository _flightRepository;

    public GetAllFlightHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    
    public async Task<IEnumerable<Core.Entities.Flight>> Handle(GetAllFlightQuery request, CancellationToken cancellationToken)
    {
        return await _flightRepository.GetAllFlightsAsync();
    }
}