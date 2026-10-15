using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Game.Team.Player;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Domain.Events.Game.Team.General;

namespace SFC.Scheme.Application.Features.Game.Team.General.Notifications.GameTeamsCreated;

public class GameTeamsCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGameTeamPlayerSeedService gameTeamPlayerSeedServicev) : INotificationHandler<GameTeamsCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGameTeamPlayerSeedService _gameTeamPlayerSeedServicev = gameTeamPlayerSeedServicev;

    public async Task Handle(GameTeamsCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeam, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                await _gameTeamPlayerSeedServicev.SendRequireGameTeamPlayersSeedAsync(cancellationToken)
                                                 .ConfigureAwait(false);
            }
        }
    }
}