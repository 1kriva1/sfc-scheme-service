using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Scheme.Application.Interfaces.Team.General;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team;
using SFC.Team.Messages.Commands.Team.General;

namespace SFC.Scheme.Infrastructure.Services.Team.General;
public class TeamSeedService(IConfiguration configuration, IBus bus) : ITeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamsSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}