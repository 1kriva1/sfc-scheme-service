using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Identity.Messages.Commands.User;
using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Services.Identity;
public class UserSeedService(IBus bus, IConfiguration configuration) : IUserSeedService
{
    private readonly IBus _bus = bus;
    private readonly IConfiguration _configuration = configuration;

    public async Task SendRequireUsersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireUsersSeed command = new() { Initiator = settings.Exchanges.Scheme.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}