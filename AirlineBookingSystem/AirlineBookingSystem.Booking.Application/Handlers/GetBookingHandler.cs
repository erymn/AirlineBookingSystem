using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.Booking.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Booking.Application.Handlers;

public class GetBookingHandler : IRequestHandler<GetBookingQuery, Core.Entities.Booking>
{
    private readonly IBookingRepository _bookingRepository;

    public GetBookingHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    
    public async Task<Core.Entities.Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetBookingByIdAsync(request.id);
    }
}