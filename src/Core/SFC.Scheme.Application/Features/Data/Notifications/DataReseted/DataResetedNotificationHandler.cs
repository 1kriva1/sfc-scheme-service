using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Scheme.Data;
using SFC.Scheme.Domain.Events.Data;

namespace SFC.Scheme.Application.Features.Data.Notifications.DataReseted;
public class DataResetedNotificationHandler(
    IHostEnvironment hostEnvironment,
    IUserSeedService userSeedService,
    IMetadataService metadataService,
    ISchemeDataSeedService schemeDataSeedService,
    ISchemeDataService schemeDataService)
    : INotificationHandler<DataResetedEvent>
{
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IUserSeedService _userSeedService = userSeedService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly ISchemeDataSeedService _schemeDataSeedService = schemeDataSeedService;
    private readonly ISchemeDataService _schemeDataService = schemeDataService;

    public async Task Handle(DataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Data, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);

        if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(true))
        {
            await _schemeDataSeedService.SeedDataAsync(cancellationToken).ConfigureAwait(false);

            await _schemeDataService.PublishDataInitializedEventAsync(cancellationToken).ConfigureAwait(false);
        }

        if (_hostEnvironment.IsDevelopment())
        {
            // require seed users
            await _userSeedService.SendRequireUsersSeedAsync(cancellationToken)
                                  .ConfigureAwait(false);
        }
    }
}