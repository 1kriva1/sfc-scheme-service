﻿using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.Data.Messages.Events;
using SFC.Identity.Messages.Commands;
using SFC.Player.Messages.Commands.Player;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings.RabbitMq;
using SFC.Scheme.Messages.Commands.Common;
using SFC.Scheme.Messages.Commands.Data;
using SFC.Scheme.Messages.Commands.Scheme;
using SFC.Scheme.Messages.Events.Scheme;
using SFC.Team.Messages.Commands.Team.General;
using SFC.Team.Messages.Commands.Team.Player;

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
        // "sfc.scheme.scheme.created"
        configure.AddExchange<SchemeCreated>(exchangesSettings.Scheme.Value.Domain.Scheme.Events.Created);

        // "sfc.scheme.scheme.updated"
        configure.AddExchange<SchemeUpdated>(exchangesSettings.Scheme.Value.Domain.Scheme.Events.Updated);

        if (environment.IsDevelopment())
        {
            // "sfc.scheme.schemes.seed"
            configure.AddExchange<SeedSchemes>(exchangesSettings.Scheme.Value.Domain.Scheme.Seed.Seed, exchangesSettings.Scheme.Key);
        }
    }

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings, IWebHostEnvironment environment)
    {
        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Data.RequireData>(exchangesSettings.Scheme.Value.Data.Dependent.Data.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Team.Data.RequireData>(exchangesSettings.Scheme.Value.Data.Dependent.Team.RequireInitialize.GetExchangeEndpointUri());

        // need extend team service before use it here
        //EndpointConvention.Map<SFC.Team.Messages.Commands.Scheme.InitializeData>(exchangesSettings.Team.Value.Data.Dependent.Scheme.Initialize.GetExchangeEndpointUri());

        if (environment.IsDevelopment())
        {
            // "sfc.identity.users.seed.require"
            EndpointConvention.Map<SFC.Identity.Messages.Commands.RequireUsersSeed>(exchangesSettings.Identity.Value.Domain.User.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.player.players.seed.require"
            EndpointConvention.Map<SFC.Player.Messages.Commands.Player.RequirePlayersSeed>(exchangesSettings.Player.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.team.teams.seed.require"
            EndpointConvention.Map<SFC.Team.Messages.Commands.Team.General.RequireTeamsSeed>(exchangesSettings.Team.Value.Domain.Team.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.team.player.seed.require"
            EndpointConvention.Map<SFC.Team.Messages.Commands.Team.Player.RequireTeamPlayersSeed>(exchangesSettings.Team.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());
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