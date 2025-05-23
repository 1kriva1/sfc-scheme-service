using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Scheme.Team;
using SFC.Scheme.Domain.Events.Team.Player;

namespace SFC.Scheme.Application.Features.Team.Player.Notifications.TeamPlayersCreated;
public class TeamPlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ITeamSchemeSeedService schemeSeedService) : INotificationHandler<TeamPlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ITeamSchemeSeedService _schemeSeedService = schemeSeedService;

    public async Task Handle(TeamPlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.TeamScheme, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _schemeSeedService.SeedTeamSchemesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}