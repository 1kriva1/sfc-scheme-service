﻿using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Domain.Events.Team.Data;

namespace SFC.Scheme.Application.Features.Team.Data.Notifications.DataReseted;
public class TeamDataResetedNotificationHandler(
    IHostEnvironment hostEnvironment,
    IUserSeedService userSeedService,
    IMetadataService metadataService)
    : INotificationHandler<TeamDataResetedEvent>
{
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IUserSeedService _userSeedService = userSeedService;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(TeamDataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);

        if (_hostEnvironment.IsDevelopment())
        {
        }
    }
}