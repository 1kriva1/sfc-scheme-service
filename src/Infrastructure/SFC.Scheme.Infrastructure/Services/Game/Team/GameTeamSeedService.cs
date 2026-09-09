using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.Team.General;
using SFC.Scheme.Application.Interfaces.Game.Team;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Services.Game.Team;
public class GameTeamSeedService(IConfiguration configuration, IBus bus) : IGameTeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGameTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGameTeamsSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}