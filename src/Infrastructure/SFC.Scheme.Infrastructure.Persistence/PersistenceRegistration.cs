using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Interceptors;

namespace SFC.Scheme.Infrastructure.Persistence;
public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this WebApplicationBuilder builder)
    {
        // contexts
        builder.Services.AddDbContext<MetadataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<DataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<IdentityDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<SchemeDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<PlayerDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<TeamDbContext>(builder.Configuration, builder.Environment);

        // interceptors
        builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<DispatchDomainEventsSaveChangesInterceptor>();
        builder.Services.AddScoped<DataEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<UserEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<PlayerEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<TeamEntitySaveChangesInterceptor>();

        // contexts by interfaces
        builder.Services.AddScoped<IMetadataDbContext, MetadataDbContext>();
        builder.Services.AddScoped<IDataDbContext, DataDbContext>();
        builder.Services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        builder.Services.AddScoped<ISchemeDbContext, SchemeDbContext>();
        builder.Services.AddScoped<IPlayerDbContext, PlayerDbContext>();
        builder.Services.AddScoped<ITeamDbContext, TeamDbContext>();

        // repositories
        builder.Services.AddRepositories(builder.Configuration);
    }
}