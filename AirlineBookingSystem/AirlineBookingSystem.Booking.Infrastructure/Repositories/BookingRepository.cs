using System.Data;
using AirlineBookingSystem.Booking.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Booking.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly IDbConnection _connection;

    public BookingRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<Core.Entities.Booking?> GetBookingByIdAsync(Guid id)
    {
        const string sql = "select * from Bookings where Id = @Id";
        
        return await _connection.QuerySingleOrDefaultAsync<Core.Entities.Booking>(sql, new { Id = id });
    }

    public async Task AddBookingAsync(Core.Entities.Booking booking)
    {
        string sql = @"
                insert into Bookings(Id, FlightId, PassengerName, SeatNumber, BookingDate)
                    values (newId(), @FlightId, @PassengerName, @SeatNumber, @BookingDate)
            ";
        
        await _connection.ExecuteAsync(sql, booking);
    }
}