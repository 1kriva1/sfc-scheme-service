using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Common.Settings;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Player;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Data;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Identity;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Metadata;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Player;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data.Cache;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Game;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Data;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Data.Cache;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Player;

namespace SFC.Scheme.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IMetadataRepository, MetadataRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITeamPlayerRepository, TeamPlayerRepository>();
        services.AddScoped<ITeamSchemeRepository, TeamSchemeRepository>();
        services.AddScoped<IGameSchemeRepository, GameSchemeRepository>();

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
            services.AddScoped<FootballPositionRepository>();
            services.AddScoped<IFootballPositionRepository, FootballPositionCacheRepository>();
            services.AddScoped<GameStyleRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleCacheRepository>();
            services.AddScoped<StatCategoryRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryCacheRepository>();
            services.AddScoped<StatSkillRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillCacheRepository>();
            services.AddScoped<StatTypeRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeCacheRepository>();
            services.AddScoped<WorkingFootRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootCacheRepository>();
            services.AddScoped<ShirtRepository>();
            services.AddScoped<IShirtRepository, ShirtCacheRepository>();

            // team
            services.AddScoped<TeamPlayerStatusRepository>();
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusCacheRepository>();

            // scheme
            services.AddScoped<FormationRepository>();
            services.AddScoped<IFormationRepository, FormationCacheRepository>();
            services.AddScoped<FormationPositionRepository>();
            services.AddScoped<IFormationPositionRepository, FormationPositionCacheRepository>();
            services.AddScoped<SchemeTypeRepository>();
            services.AddScoped<ISchemeTypeRepository, SchemeTypeCacheRepository>();
        }
        else
        {
            // data
            services.AddScoped<IFootballPositionRepository, FootballPositionRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootRepository>();
            services.AddScoped<IShirtRepository, ShirtRepository>();

            // team
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusRepository>();

            // scheme
            services.AddScoped<IFormationRepository, FormationRepository>();
            services.AddScoped<IFormationPositionRepository, FormationPositionRepository>();
            services.AddScoped<ISchemeTypeRepository, SchemeTypeRepository>();
        }

        return services;
    }
}