using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Scheme.Application.Features.Team.Data.Commands.Reset;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Scheme.Messages.Commands.Team.Data;

namespace SFC.Scheme.Infrastructure.Consumers.Scheme.Data.Team;
public class InitializeDataConsumer(IMapper mapper, ISender mediator) : IConsumer<InitializeData>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<InitializeData> context)
    {
        InitializeData message = context.Message;

        ResetTeamDataCommand command = _mapper.Map<ResetTeamDataCommand>(message);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<InitializeDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Scheme.Value.Data.Dependent.Team.Initialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.team.data.initialize.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<InitializeDataConsumer> consumerConfigurator, IRegistrationContext context)
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