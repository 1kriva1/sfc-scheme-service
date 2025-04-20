using MediatR;

using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Domain.Events.Scheme;

namespace SFC.Scheme.Application.Features.Scheme.Notifications.SchemeCreated;
public class SchemeCreatedNotificationHandler(ISchemeService schemeService) : INotificationHandler<SchemeCreatedEvent>
{
    private readonly ISchemeService _schemeService = schemeService;

    public Task Handle(SchemeCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _schemeService.NotifySchemeCreatedAsync(notification.Scheme, cancellationToken);
    }
}