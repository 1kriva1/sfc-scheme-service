using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Domain.Events.Data;

namespace SFC.Scheme.Application.Features.Data.Notifications.DataReseted;
public class DataResetedNotificationHandler(
    IHostEnvironment hostEnvironment,
    IUserSeedService userSeedService,
    IMetadataService metadataService)
    : INotificationHandler<DataResetedEvent>
{
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IUserSeedService _userSeedService = userSeedService;
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(DataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Data, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);

        if (_hostEnvironment.IsDevelopment())
        {
            // require seed users
            await _userSeedService.SendRequireUsersSeedAsync(cancellationToken)
                                  .ConfigureAwait(false);
        }
    }
}