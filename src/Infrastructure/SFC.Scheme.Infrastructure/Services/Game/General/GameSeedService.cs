using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.General;
using SFC.Scheme.Application.Interfaces.Game.General;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Services.Game.General;
public class GameSeedService(IConfiguration configuration, IBus bus) : IGameSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGamesSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGamesSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}