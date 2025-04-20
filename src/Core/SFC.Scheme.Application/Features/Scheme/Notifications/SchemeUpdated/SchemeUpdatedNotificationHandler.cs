using MediatR;

using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Domain.Events.Scheme;

namespace SFC.Scheme.Application.Features.Scheme.Notifications.SchemeUpdated;
public class SchemeUpdatedNotificationHandler(ISchemeService schemeService) : INotificationHandler<SchemeUpdatedEvent>
{
    private readonly ISchemeService _schemeService = schemeService;

    public Task Handle(SchemeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _schemeService.NotifySchemeUpdatedAsync(notification.Scheme, cancellationToken);
    }
}