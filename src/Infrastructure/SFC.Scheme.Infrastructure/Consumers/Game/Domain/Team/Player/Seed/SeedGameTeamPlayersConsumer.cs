using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Commands.Game.Team.Player;
using SFC.Scheme.Application.Features.Game.Team.Player.Commands.Creates;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Consumers.Game.Domain.Team.Player.Seed;
public class SeedGameTeamPlayersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedGameTeamPlayersConsumer> logger,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<SeedGameTeamPlayers>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedGameTeamPlayersConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedGameTeamPlayers> context)
    {
        if (_environment.IsDevelopment())
        {
            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                SeedGameTeamPlayers message = context.Message;

                CreatesGameTeamPlayerCommand command = _mapper.Map<CreatesGameTeamPlayerCommand>(message.GameTeamPlayers);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class SeedGameTeamPlayersConsumerDefinition : ConsumerDefinition<SeedGameTeamPlayersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Team.Player.Seed.Seed; } }

    public SeedGameTeamPlayersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.game.team.players.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedGameTeamPlayersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Scheme.Key.BuildExchangeRoutingKey(_settings.Exchanges.Game.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}