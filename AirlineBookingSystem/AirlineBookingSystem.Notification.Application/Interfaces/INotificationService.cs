namespace AirlineBookingSystem.Notification.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Core.Entities.Notification notification);
}