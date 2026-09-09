using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.Data.Messages.Events;
using SFC.Game.Messages.Commands.Game.General;
using SFC.Game.Messages.Commands.Game.Player;
using SFC.Game.Messages.Commands.Game.Team.General;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Scheme.Messages.Commands.Common;
using SFC.Scheme.Messages.Commands.Scheme.Game.Team;
using SFC.Scheme.Messages.Commands.Scheme.Team;
using SFC.Scheme.Messages.Events.Scheme.Data;
using SFC.Scheme.Messages.Events.Scheme.Game.Team;
using SFC.Scheme.Messages.Events.Scheme.Team;

namespace SFC.Scheme.Infrastructure.Extensions;
public static class MassTransitExtensions
{
    private const string EXCHANGE_ENDPOINT_SHORT_ADDRESS = "exchange";
    private const string EXCHANGE_ENDPOINT_AUTO_DELETE_PART = "autodelete";

    #region Public

    public static IServiceCollection AddMassTransit(this WebApplicationBuilder builder)
    {
        return builder.Services.AddMassTransit(masTransitConfigure =>
        {
            masTransitConfigure.AddConsumers(Assembly.GetExecutingAssembly());

            masTransitConfigure.UsingRabbitMq((context, rabbitMqConfigure) =>
            {
                RabbitMqSettings settings = builder.Configuration.GetRabbitMqSettings();

                string rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMq")!;

                rabbitMqConfigure.Host(new Uri(rabbitMqConnectionString), settings.Name, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                rabbitMqConfigure.UseRetries(settings.Retry);

                rabbitMqConfigure.AddExchanges(builder.Environment, settings.Exchanges);

                rabbitMqConfigure.ConfigureEndpoints(context);

                MapEndpoints(settings.Exchanges, builder.Environment);
            });
        });
    }

    public static string BuildExchangeRoutingKey(this string initiator, string key)
        => $"{key.ToLower(System.Globalization.CultureInfo.CurrentCulture)}.{initiator.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)}";

    #endregion Public

    #region Private

    private static void AddExchanges(
        this IRabbitMqBusFactoryConfigurator configure,
        IWebHostEnvironment environment,
        RabbitMqExchangesSettings exchangesSettings)
    {
        // "sfc.scheme.data.initialized"
        configure.AddExchange<DataInitialized>(exchangesSettings.Scheme.Value.Data.Source.Initialized);

        configure.AddExchange<TeamSchemeCreated>(exchangesSettings.Scheme.Value.Domain.Team.Events.Created);

        configure.AddExchange<TeamSchemeUpdated>(exchangesSettings.Scheme.Value.Domain.Team.Events.Updated);

        configure.AddExchange<GameTeamSchemeCreated>(exchangesSettings.Scheme.Value.Domain.Game.Team.Events.Created);

        configure.AddExchange<GameTeamSchemeUpdated>(exchangesSettings.Scheme.Value.Domain.Game.Team.Events.Updated);

        if (environment.IsDevelopment())
        {
            configure.AddExchange<SeedTeamSchemes>(exchangesSettings.Scheme.Value.Domain.Team.Seed.Seed, exchangesSettings.Scheme.Key);

            configure.AddExchange<SeedGameTeamSchemes>(exchangesSettings.Scheme.Value.Domain.Game.Team.Seed.Seed, exchangesSettings.Scheme.Key);
        }
    }

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings, IWebHostEnvironment environment)
    {
        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Data.RequireData>(exchangesSettings.Scheme.Value.Data.Dependent.Data.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Team.Data.RequireData>(exchangesSettings.Scheme.Value.Data.Dependent.Team.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Game.Data.RequireData>(exchangesSettings.Scheme.Value.Data.Dependent.Game.RequireInitialize.GetExchangeEndpointUri());

        if (environment.IsDevelopment())
        {
            // "sfc.identity.users.seed.require"
            EndpointConvention.Map<SFC.Identity.Messages.Commands.User.RequireUsersSeed>(exchangesSettings.Identity.Value.Domain.User.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.player.players.seed.require"
            EndpointConvention.Map<SFC.Player.Messages.Commands.Player.RequirePlayersSeed>(exchangesSettings.Player.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.team.teams.seed.require"
            EndpointConvention.Map<SFC.Team.Messages.Commands.Team.General.RequireTeamsSeed>(exchangesSettings.Team.Value.Domain.Team.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.team.player.seed.require"
            EndpointConvention.Map<SFC.Team.Messages.Commands.Team.Player.RequireTeamPlayersSeed>(exchangesSettings.Team.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.game.games.seed.require"
            EndpointConvention.Map<RequireGamesSeed>(exchangesSettings.Game.Value.Domain.Game.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.game.team.seed.require"
            EndpointConvention.Map<RequireGameTeamsSeed>(exchangesSettings.Game.Value.Domain.Team.Team.Seed.RequireSeed.GetExchangeEndpointUri());
        }
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange)
        where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, Func<SendContext<T>, string?> formatter)
        where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(formatter));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, string key)
        where T : InitiatorCommand
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(context => context.Message.Initiator.BuildExchangeRoutingKey(key)));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void UseRetries(this IRabbitMqBusFactoryConfigurator configure, RabbitMqRetrySettings settings)
    {
        configure.UseDelayedRedelivery(r =>
            r.Intervals(settings.Intervals.Select(i => TimeSpan.FromMinutes(i)).ToArray()));
        configure.UseMessageRetry(r => r.Immediate(settings.Limit));
    }

    private static Uri GetExchangeEndpointUri(this Message exchange) =>
       new($"{EXCHANGE_ENDPOINT_SHORT_ADDRESS}:{exchange.Name}?{EXCHANGE_ENDPOINT_AUTO_DELETE_PART}={true}");

    #endregion Private
}