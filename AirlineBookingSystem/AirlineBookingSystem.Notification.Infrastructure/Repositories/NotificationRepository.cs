using System.Data;
using AirlineBookingSystem.Notification.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Notification.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly IDbConnection _connection;

    public NotificationRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task LogNotificationAsync(Core.Entities.Notification notification)
    {
        const string sql = @"
                insert into Notifications(Id, Recipient, Message, Type, SentAt)
                values (newId(), @Recipient, @Message, @Type, @SentAt)
            ";
        await _connection.ExecuteAsync(sql, notification);    
    }
}