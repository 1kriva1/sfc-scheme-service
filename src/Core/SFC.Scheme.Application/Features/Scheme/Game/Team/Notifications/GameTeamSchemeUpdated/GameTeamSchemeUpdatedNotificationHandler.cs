using MediatR;

using SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Notifications.GameTeamSchemeUpdated;
public class GameTeamSchemeUpdatedNotificationHandler(IGameTeamSchemeService gameTeamSchemeService) : INotificationHandler<GameTeamSchemeUpdatedEvent>
{
    private readonly IGameTeamSchemeService _gameTeamSchemeService = gameTeamSchemeService;

    public Task Handle(GameTeamSchemeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _gameTeamSchemeService.NotifyGameTeamSchemeUpdatedAsync(notification.Scheme, cancellationToken);
    }
}