using MediatR;

using SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Notifications.GameTeamSchemeCreated;
public class GameTeamSchemeCreatedNotificationHandler(IGameTeamSchemeService gameTeamSchemeService) : INotificationHandler<GameTeamSchemeCreatedEvent>
{
    private readonly IGameTeamSchemeService _gameTeamSchemeService = gameTeamSchemeService;

    public Task Handle(GameTeamSchemeCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _gameTeamSchemeService.NotifyGameTeamSchemeCreatedAsync(notification.Scheme, cancellationToken);
    }
}