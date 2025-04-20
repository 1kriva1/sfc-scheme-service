using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Domain.Events.Team.Player;

namespace SFC.Scheme.Application.Features.Team.Player.Notifications.TeamPlayersCreated;
public class TeamPlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ISchemeSeedService schemeSeedService) : INotificationHandler<TeamPlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ISchemeSeedService _schemeSeedService = schemeSeedService;

    public async Task Handle(TeamPlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.Scheme, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _schemeSeedService.SeedSchemesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}