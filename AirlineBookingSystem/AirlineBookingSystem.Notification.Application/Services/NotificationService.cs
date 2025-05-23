using AirlineBookingSystem.Notification.Application.Interfaces;

namespace AirlineBookingSystem.Notification.Application.Services;

public class NotificationService : INotificationService
{
    public async Task SendNotificationAsync(Core.Entities.Notification notification)
    {
        // simulate sending a notification
        Console.WriteLine($"Notification send to {notification.Recipient}: {notification.Message}");
    }
}