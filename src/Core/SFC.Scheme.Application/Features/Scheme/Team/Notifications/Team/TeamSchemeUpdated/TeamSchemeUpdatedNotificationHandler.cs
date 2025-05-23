using MediatR;

using SFC.Scheme.Application.Interfaces.Scheme.Team;
using SFC.Scheme.Domain.Events.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Notifications.Team.TeamSchemeUpdated;
public class TeamSchemeUpdatedNotificationHandler(ITeamSchemeService schemeService) : INotificationHandler<TeamSchemeUpdatedEvent>
{
    private readonly ITeamSchemeService _schemeService = schemeService;

    public Task Handle(TeamSchemeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _schemeService.NotifyTeamSchemeUpdatedAsync(notification.Scheme, cancellationToken);
    }
}