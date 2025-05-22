namespace AirlineBookingSystem.Booking.Core.Repositories;

public interface IBookingRepository
{
    Task<Entities.Booking?> GetBookingByIdAsync(Guid id);
    Task AddBookingAsync(Entities.Booking booking);
}