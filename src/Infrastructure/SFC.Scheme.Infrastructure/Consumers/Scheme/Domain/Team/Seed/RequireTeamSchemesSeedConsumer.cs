using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Scheme.Application.Interfaces.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Scheme.Messages.Commands.Scheme.Team;

namespace SFC.Scheme.Infrastructure.Consumers.Scheme.Domain.Team.Seed;
public class RequireTeamSchemesSeedConsumer(IMapper mapper, ITeamSchemeSeedService teamSchemeSeedService)
    : IConsumer<RequireTeamSchemesSeed>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamSchemeSeedService _teamSchemeSeedService = teamSchemeSeedService;

    public async Task Consume(ConsumeContext<RequireTeamSchemesSeed> context)
    {
        RequireTeamSchemesSeed message = context.Message;

        IEnumerable<TeamScheme> schemes = await _teamSchemeSeedService.GetSeedTeamSchemesAsync().ConfigureAwait(true);

        SeedTeamSchemes command = _mapper.Map<SeedTeamSchemes>(schemes)
                                         .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireTeamSchemesSeedDefinition : ConsumerDefinition<RequireTeamSchemesSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Scheme.Value.Domain.Team.Seed.RequireSeed; } }

    public RequireTeamSchemesSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.team.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireTeamSchemesSeedConsumer> consumerConfigurator,
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