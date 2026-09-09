using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.General;
using SFC.Scheme.Application.Features.Game.General.Commands.Create;
using SFC.Scheme.Application.Features.Game.General.Commands.Update;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

namespace SFC.Scheme.Infrastructure.Consumers.Game.Domain.Game.Events;
public class GameUpdatedConsumer(
    IMapper mapper,
    ILogger<GameUpdatedConsumer> logger,
    ISender mediator,
    IGameRepository gameRepository) : IConsumer<GameUpdated>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GameUpdatedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IGameRepository _gameRepository = gameRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GameUpdated> context)
    {
        GameUpdated @event = context.Message;

        bool gameExist = await _gameRepository.AnyAsync(@event.Game.Id)
                                                  .ConfigureAwait(true);

        if (gameExist)
            await UpdateGameAsync(@event).ConfigureAwait(false);
        else
            await CreateGameAsync(@event).ConfigureAwait(false);
    }

    private Task UpdateGameAsync(GameUpdated @event)
    {
        UpdateGameCommand command = _mapper.Map<UpdateGameCommand>(@event);
        return _mediator.Send(command);
    }

    private Task CreateGameAsync(GameUpdated @event)
    {
        CreateGameCommand command = _mapper.Map<CreateGameCommand>(@event);
        return _mediator.Send(command);
    }
}

public class GameUpdatedConsumerDefinition : ConsumerDefinition<GameUpdatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Game.Events.Updated; } }

    public GameUpdatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.game.updated.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GameUpdatedConsumer> consumerConfigurator,
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