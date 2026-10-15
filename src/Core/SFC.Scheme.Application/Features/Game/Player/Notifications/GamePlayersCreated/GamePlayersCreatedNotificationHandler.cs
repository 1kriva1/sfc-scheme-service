using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Game.Team.General;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Domain.Events.Game.Player;

namespace SFC.Scheme.Application.Features.Game.Player.Notifications.GamePlayersCreated;
public class GamePlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGameTeamSeedService gameTeamSeedService) : INotificationHandler<GamePlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGameTeamSeedService _gameTeamSeedService = gameTeamSeedService;

    public async Task Handle(GamePlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GamePlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeam, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                await _gameTeamSeedService.SendRequireGameTeamsSeedAsync(cancellationToken)
                                              .ConfigureAwait(false);
            }
        }
    }
}