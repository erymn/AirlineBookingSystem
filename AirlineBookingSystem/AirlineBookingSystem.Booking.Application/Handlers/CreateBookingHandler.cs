using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Booking.Application.Handlers;

public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingRepository _bookingRepository;

    public CreateBookingHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Core.Entities.Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow,
        };
        
        await _bookingRepository.AddBookingAsync(booking);
        return booking.Id;
    }
}