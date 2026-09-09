using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
using SFC.Scheme.Domain.Events.Game.Team;

namespace SFC.Scheme.Application.Features.Game.Team.Notifications.GameTeamsCreated;
public class GameTeamsCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGameTeamSchemeSeedService gameTeamSchemeSeedService) : INotificationHandler<GameTeamsCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGameTeamSchemeSeedService _gameTeamSchemeSeedService = gameTeamSchemeSeedService;

    public async Task Handle(GameTeamsCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeam, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.GameTeamScheme, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _gameTeamSchemeSeedService.SeedGameTeamSchemesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}