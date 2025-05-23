using MediatR;

using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Domain.Events.Team.Data;

namespace SFC.Scheme.Application.Features.Team.Data.Notifications.DataReseted;
public class TeamDataResetedNotificationHandler(IMetadataService metadataService)
    : INotificationHandler<TeamDataResetedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(TeamDataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }
}