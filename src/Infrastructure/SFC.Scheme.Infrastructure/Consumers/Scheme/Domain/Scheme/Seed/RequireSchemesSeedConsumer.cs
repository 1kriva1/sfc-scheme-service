using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Scheme.Messages.Commands.Scheme;

namespace SFC.Scheme.Infrastructure.Consumers.Scheme.Domain.Scheme.Seed;
public class RequireSchemesSeedConsumer(
    ILogger<RequireSchemesSeedConsumer> logger,
    IMapper mapper,
    ISchemeSeedService ganeralTemplateSeedService) : IConsumer<RequireSchemesSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireSchemesSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ISchemeSeedService _ganeralTemplateSeedService = ganeralTemplateSeedService;

    public async Task Consume(ConsumeContext<RequireSchemesSeed> context)
    {
        RequireSchemesSeed message = context.Message;

        IEnumerable<SchemeEntity> schemes = await _ganeralTemplateSeedService.GetSeedSchemesAsync().ConfigureAwait(true);

        SeedSchemes command = _mapper.Map<SeedSchemes>(schemes)
                                                     .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireSchemesSeedDefinition : ConsumerDefinition<RequireSchemesSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Scheme.Value.Domain.Scheme.Seed.RequireSeed; } }

    public RequireSchemesSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.schemes.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireSchemesSeedConsumer> consumerConfigurator,
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