using MediatR;

using SFC.Scheme.Application.Interfaces.Scheme.Team;
using SFC.Scheme.Domain.Events.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Notifications.Team.TeamSchemeCreated;
public class TeamSchemeCreatedNotificationHandler(ITeamSchemeService schemeService) : INotificationHandler<TeamSchemeCreatedEvent>
{
    private readonly ITeamSchemeService _schemeService = schemeService;

    public Task Handle(TeamSchemeCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _schemeService.NotifyTeamSchemeCreatedAsync(notification.Scheme, cancellationToken);
    }
}