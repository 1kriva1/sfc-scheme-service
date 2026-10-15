using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.Team.General;
using SFC.Game.Messages.Events.Game.Team.Player;
using SFC.Scheme.Application.Features.Game.Team.Player.Commands.Delete;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Consumers.Game.Domain.Team.Player.Events;
public class GameTeamPlayerDeletedConsumer(
    IMapper mapper,
    ILogger<GameTeamPlayerDeletedConsumer> logger,
    ISender mediator) : IConsumer<GameTeamPlayerDeleted>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GameTeamPlayerDeletedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GameTeamPlayerDeleted> context)
    {
        GameTeamPlayerDeleted @event = context.Message;

        DeleteGameTeamPlayerCommand command = _mapper.Map<DeleteGameTeamPlayerCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class GameTeamPlayerDeletedConsumerDefinition : ConsumerDefinition<GameTeamPlayerDeletedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Team.Player.Events.Deleted; } }

    public GameTeamPlayerDeletedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.game.team.player.deleted.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GameTeamPlayerDeletedConsumer> consumerConfigurator,
            IRegistrationContext context)
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