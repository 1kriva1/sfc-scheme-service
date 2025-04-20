using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Scheme.Application.Interfaces.Team.Player;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team.Player;

namespace SFC.Scheme.Infrastructure.Services.Team.Player;
public class TeamPlayerSeedService(IConfiguration configuration, IBus bus) : ITeamPlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamPlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamPlayersSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}