using System.Reflection;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Common;
using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Player;
using SFC.Scheme.Application.Interfaces.Reference;
using SFC.Scheme.Application.Interfaces.Scheme;
using SFC.Scheme.Application.Interfaces.Team.General;
using SFC.Scheme.Application.Interfaces.Team.Player;
using SFC.Scheme.Contracts.Services;
using SFC.Scheme.Infrastructure.Authorization.OwnPlayer;
using SFC.Scheme.Infrastructure.Authorization.OwnScheme;
using SFC.Scheme.Infrastructure.Authorization.OwnTeam;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Extensions.Grpc;
using SFC.Scheme.Infrastructure.Services.Common;
using SFC.Scheme.Infrastructure.Services.Hosted;
using SFC.Scheme.Infrastructure.Services.Identity;
using SFC.Scheme.Infrastructure.Services.Metadata;
using SFC.Scheme.Infrastructure.Services.Player;
using SFC.Scheme.Infrastructure.Services.Reference;
using SFC.Scheme.Infrastructure.Services.Scheme;
using SFC.Scheme.Infrastructure.Services.Team.General;
using SFC.Scheme.Infrastructure.Services.Team.Player;

namespace SFC.Scheme.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAccessTokenManagement();

        builder.Services.AddRedis(builder.Configuration);

        builder.AddMassTransit();

        builder.Services.AddCache(builder.Configuration);

        builder.Services.AddGrpc(builder.Configuration, builder.Environment);

        builder.Services.AddSingleton<IUriService>(o =>
        {
            IHttpContextAccessor accessor = o.GetRequiredService<IHttpContextAccessor>();
            HttpRequest request = accessor.HttpContext!.Request;
            return new UriService(string.Concat(request.Scheme, "://", request.Host.ToUriComponent()));
        });

        // custom services
        builder.Services.AddTransient<IMetadataService, MetadataService>();
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserSeedService, UserSeedService>();
        builder.Services.AddTransient<IPlayerSeedService, PlayerSeedService>();
        builder.Services.AddTransient<ITeamSeedService, TeamSeedService>();
        builder.Services.AddTransient<ITeamPlayerSeedService, TeamPlayerSeedService>();
        builder.Services.AddTransient<ISchemeService, SFC.Scheme.Infrastructure.Services.Scheme.SchemeService>();
        builder.Services.AddTransient<ISchemeSeedService, SchemeSeedService>();

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
        builder.Services.AddTransient<IPlayerService, PlayerService>();
        builder.Services.AddTransient<ITeamService, TeamService>();

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();
        builder.Services.AddScoped<ITeamReference, TeamReference>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
        builder.Services.AddScoped<IAuthorizationHandler, OwnSchemeHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnPlayerHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnTeamHandler>();
    }
}