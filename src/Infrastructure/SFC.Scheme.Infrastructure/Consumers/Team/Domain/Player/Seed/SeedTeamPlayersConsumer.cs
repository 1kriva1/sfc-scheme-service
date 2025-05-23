using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Features.Team.Player.Commands.CreateRange;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team.Player;

namespace SFC.Scheme.Infrastructure.Consumers.Team.Domain.Player.Seed;
public class SeedTeamPlayersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ISender mediator) : IConsumer<SeedTeamPlayers>
{
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<SeedTeamPlayers> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedTeamPlayers message = context.Message;

            CreateTeamPlayersCommand command = _mapper.Map<CreateTeamPlayersCommand>(message.TeamPlayers);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedTeamPlayersConsumerDefinition : ConsumerDefinition<SeedTeamPlayersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Team.Value.Domain.Player.Seed.Seed; } }

    public SeedTeamPlayersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.team.players.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedTeamPlayersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Scheme.Key.BuildExchangeRoutingKey(_settings.Exchanges.Team.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}