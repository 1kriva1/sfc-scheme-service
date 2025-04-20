using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Player.Messages.Commands.Player;
using SFC.Scheme.Application.Interfaces.Player;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Services.Player;
public class PlayerSeedService(IConfiguration configuration, IBus bus) : IPlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequirePlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequirePlayersSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send<RequirePlayersSeed>(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}