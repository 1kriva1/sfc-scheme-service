using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Game.Team.Player;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Notifications.GameTeamPlayersCreated;
public class GameTeamPlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGameTeamSchemeSeedService gameTeamSchemeSeedService) : INotificationHandler<GameTeamPlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGameTeamSchemeSeedService _gameTeamSchemeSeedService = gameTeamSchemeSeedService;

    public async Task Handle(GameTeamPlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.GameTeamScheme, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _gameTeamSchemeSeedService.SeedGameTeamSchemesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}