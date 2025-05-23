using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Features.Team.General.Commands.CreateRange;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team.General;

namespace SFC.Scheme.Infrastructure.Consumers.Team.Domain.Team.Seed;
public class SeedTeamsConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ISender mediator) : IConsumer<SeedTeams>
{
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<SeedTeams> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedTeams message = context.Message;

            CreateTeamsCommand command = _mapper.Map<CreateTeamsCommand>(message.Teams);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedTeamsConsumerDefinition : ConsumerDefinition<SeedTeamsConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Team.Value.Domain.Team.Seed.Seed; } }

    public SeedTeamsConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.team.teams.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedTeamsConsumer> consumerConfigurator, IRegistrationContext context)
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