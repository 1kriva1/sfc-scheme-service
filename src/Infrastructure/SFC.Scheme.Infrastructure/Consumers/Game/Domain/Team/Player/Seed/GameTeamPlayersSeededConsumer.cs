using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.Team.Player;
using SFC.Scheme.Application.Features.Game.Team.General.Commands.Creates;
using SFC.Scheme.Application.Features.Game.Team.Player.Commands.Creates;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Consumers.Game.Domain.Team.Player.Seed;
public class GameTeamPlayersSeededConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<GameTeamPlayersSeededConsumer> logger,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<GameTeamPlayersSeeded>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<GameTeamPlayersSeededConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GameTeamPlayersSeeded> context)
    {
        if (_environment.IsDevelopment())
        {
            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                GameTeamPlayersSeeded @event = context.Message;

                CreatesGameTeamPlayerCommand command = _mapper.Map<CreatesGameTeamPlayerCommand>(@event.GameTeamPlayers);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class GameTeamPlayersSeededConsumerDefinition : ConsumerDefinition<GameTeamPlayersSeededConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Team.Player.Seed.Seeded; } }

    public GameTeamPlayersSeededConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.game.team.players.seeded.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GameTeamPlayersSeededConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}