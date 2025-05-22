using System.Data;
using AirlineBookingSystem.Flight.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Flight.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly IDbConnection _connection;

    public FlightRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<IEnumerable<Core.Entities.Flight>> GetAllFlightsAsync()
    {
        const string sql = "select * from Flights";

        return await _connection.QueryAsync<Core.Entities.Flight>(sql);
    }

    public async Task AddFlightAsync(Core.Entities.Flight flight)
    {
        const string sql = @"
                insert into Flights(Id, FlightNumber, Origin, Destination, DepartureTime, ArrivalTime)
                values (newId(), @FlightNumber, @Origin, @Destination, @DepartureTime, @ArrivalTime)
            ";
        
        await _connection.ExecuteAsync(sql, flight);
    }

    public async Task DeleteFlightAsync(Guid id)
    {
        const string sql = "delete from Flights where Id = @Id";
        
        await _connection.ExecuteAsync(sql, new { Id = id });
    }
}