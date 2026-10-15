using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.Player;
using SFC.Scheme.Application.Interfaces.Game.Player;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Services.Game.Player;
public class GamePlayerSeedService(IConfiguration configuration, IBus bus) : IGamePlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGamePlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGamePlayersSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}