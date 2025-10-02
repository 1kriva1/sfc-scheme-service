using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Events.Team.Player;

namespace SFC.Scheme.Application.Features.Team.Player.Notifications.TeamPlayerUpdated;
public class TeamPlayerUpdatedNotificationHandler(ITeamSchemePlayerRepository teamSchemePlayerRepository) : INotificationHandler<TeamPlayerUpdatedEvent>
{
    private readonly ITeamSchemePlayerRepository _teamSchemePlayerRepository = teamSchemePlayerRepository;

    public async Task Handle(TeamPlayerUpdatedEvent notification, CancellationToken cancellationToken)
    {
        switch (notification.TeamPlayer.StatusId)
        {
            case TeamPlayerStatusEnum.Active:
                break;
            case TeamPlayerStatusEnum.Injured:
                break;
            case TeamPlayerStatusEnum.Retired:
                break;
            case TeamPlayerStatusEnum.Unavailable:
                break;
            case TeamPlayerStatusEnum.Removed:
                await DeleteTeamSchemePlayersAsync(notification).ConfigureAwait(false);
                break;
            default:
                break;
        }
    }

    private async Task DeleteTeamSchemePlayersAsync(TeamPlayerUpdatedEvent notification)
    {
        IReadOnlyList<Domain.Entities.Scheme.Team.TeamSchemeFormationPlayer> teamSchemePlayers = await _teamSchemePlayerRepository
            .ListAllAsync(notification.TeamPlayer.TeamId, notification.TeamPlayer.PlayerId)
            .ConfigureAwait(true);

        await _teamSchemePlayerRepository.DeleteAsync(teamSchemePlayers).ConfigureAwait(false);
    }
}