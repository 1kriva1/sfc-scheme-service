using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Scheme.Messages.Commands.Scheme.Game.Team;

namespace SFC.Scheme.Infrastructure.Consumers.Scheme.Domain.Game.Team.Seed;
public class RequireGameTeamSchemesSeedConsumer(IMapper mapper, IGameTeamSchemeSeedService gameTeamSchemeSeedService)
    : IConsumer<RequireGameTeamSchemesSeed>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamSchemeSeedService _gameTeamSchemeSeedService = gameTeamSchemeSeedService;

    public async Task Consume(ConsumeContext<RequireGameTeamSchemesSeed> context)
    {
        RequireGameTeamSchemesSeed message = context.Message;

        IEnumerable<GameTeamScheme> schemes = await _gameTeamSchemeSeedService.GetSeedGameTeamSchemesAsync().ConfigureAwait(true);

        SeedGameTeamSchemes command = _mapper.Map<SeedGameTeamSchemes>(schemes)
                                         .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireGameTeamSchemesSeedDefinition : ConsumerDefinition<RequireGameTeamSchemesSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Scheme.Value.Domain.Game.Team.Seed.RequireSeed; } }

    public RequireGameTeamSchemesSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.game.team.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireGameTeamSchemesSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}