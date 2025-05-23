using MediatR;

namespace AirlineBookingSystem.Notification.Application.Commands;

public record SendNotificationCommand(string Recipient, string Message, string Type, DateTime SentAt): IRequest<Guid>;
