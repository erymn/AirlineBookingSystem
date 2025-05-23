using AirlineBookingSystem.Notification.Application.Commands;
using AirlineBookingSystem.Notification.Application.Interfaces;
using AirlineBookingSystem.Notification.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Notification.Application.Handlers;

public class SendNotificationHandler : IRequestHandler<SendNotificationCommand, Guid>
{
    //private readonly INotificationRepository _notificationRepository;
    private INotificationService _notificationService;

    public SendNotificationHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public async Task<Guid> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Core.Entities.Notification()
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type,
            SentAt = request.SentAt,
        };

        await _notificationService.SendNotificationAsync(notification);
        return notification.Id;
    }
}