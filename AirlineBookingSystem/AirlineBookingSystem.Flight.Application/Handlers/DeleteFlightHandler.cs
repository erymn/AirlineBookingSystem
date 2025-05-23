using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Handlers;

public class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlightRepository _flightRepository;

    public DeleteFlightHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    
    public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        await _flightRepository.DeleteFlightAsync(request.Id);
        return default;
    }
}