﻿using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Messages.Commands.Data;

namespace SFC.Scheme.Infrastructure.Services.Hosted;
public class DataInitializationHostedService(
    ILogger<DataInitializationHostedService> logger,
    IServiceProvider services) : BaseInitializationService(logger)
{
    private readonly IServiceProvider _services = services;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        EventId eventId = new((int)RequestId.InitData, Enum.GetName(RequestId.InitData));
        Action<ILogger, Exception?> logStartExecution = LoggerMessage.Define(LogLevel.Information, eventId,
            "Data Initialization Hosted Service running.");
        logStartExecution(Logger, null);

        using IServiceScope scope = _services.CreateScope();

        // send require data
        await SendRequireDataAsync(scope, cancellationToken).ConfigureAwait(false);
    }

    private static Task SendRequireDataAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        // use bus because it is Initiator (reference to mass transit documentation)
        IBus bus = scope.ServiceProvider.GetRequiredService<IBus>();

        bus.Send(new SFC.Scheme.Messages.Commands.Data.RequireData(), cancellationToken);

        bus.Send(new SFC.Scheme.Messages.Commands.Team.Data.RequireData(), cancellationToken);

        return Task.CompletedTask;
    }
}