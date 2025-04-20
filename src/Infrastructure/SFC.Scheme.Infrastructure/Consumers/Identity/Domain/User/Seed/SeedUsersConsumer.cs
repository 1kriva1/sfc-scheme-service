using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Identity.Messages.Commands;
using SFC.Scheme.Application.Features.Identity.Commands.CreateRange;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;

using Exchange = SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchange;

namespace SFC.Scheme.Infrastructure.Consumers.Identity.Domain.User.Seed;
public class SeedUsersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedUsersConsumer> logger,
    ISender mediator,
    IUserRepository userRepository) : IConsumer<SeedUsers>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedUsersConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IUserRepository _userRepository = userRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedUsers> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedUsers message = context.Message;

            CreateUsersCommand command = _mapper.Map<CreateUsersCommand>(message.Users);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedUsersConsumerDefinition : ConsumerDefinition<SeedUsersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Identity.Value.Domain.User.Seed.Seed; } }

    public SeedUsersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.scheme.identity.users.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedUsersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Scheme.Key.BuildExchangeRoutingKey(_settings.Exchanges.Identity.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}