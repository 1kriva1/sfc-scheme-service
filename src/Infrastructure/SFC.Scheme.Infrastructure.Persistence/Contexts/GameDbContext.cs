using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Domain.Entities.Game.General;
using SFC.Scheme.Domain.Entities.Game.Player;
using SFC.Scheme.Domain.Entities.Game.Team.General;
using SFC.Scheme.Domain.Entities.Game.Team.Player;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Game.General;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Player;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Team.Player;
using SFC.Scheme.Infrastructure.Persistence.Constants;
using SFC.Scheme.Infrastructure.Persistence.Interceptors;

namespace SFC.Scheme.Infrastructure.Persistence.Contexts;
public class GameDbContext(
    DbContextOptions<GameDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    PlayerEntitySaveChangesInterceptor playerEntityInterceptor,
    TeamEntitySaveChangesInterceptor teamEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<GameDbContext>(options, eventsInterceptor), IGameDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;
    private readonly PlayerEntitySaveChangesInterceptor _playerEntityInterceptor = playerEntityInterceptor;
    private readonly TeamEntitySaveChangesInterceptor _teamEntityInterceptor = teamEntityInterceptor;

    #region General

    public IQueryable<GameEntity> Games => Set<GameEntity>();

    public IQueryable<GameGeneralProfile> GeneralProfiles => Set<GameGeneralProfile>();

    public IQueryable<GameFinancialProfile> FinancialProfiles => Set<GameFinancialProfile>();

    public IQueryable<GameInventaryProfile> InventaryProfiles => Set<GameInventaryProfile>();

    public IQueryable<GameAvailability> Availabilities => Set<GameAvailability>();

    public IQueryable<GameTag> Tags => Set<GameTag>();

    public IQueryable<GameTeam> GameTeams => Set<GameTeam>();

    public IQueryable<GamePlayer> GamePlayers => Set<GamePlayer>();

    public IQueryable<GameTeamPlayer> GameTeamPlayers => Set<GameTeamPlayer>();

    #endregion General

    #region Data

    public IQueryable<GameStatus> GameStatuses => Set<GameStatus>();

    public IQueryable<GameTeamStatus> GameTeamStatuses => Set<GameTeamStatus>();

    public IQueryable<GameTeamIndex> GameTeamIndexes => Set<GameTeamIndex>();

    public IQueryable<GamePlayerStatus> GamePlayerStatuses => Set<GamePlayerStatus>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.GameSchemaName);

        // data
        DataDbContext.ApplyDataConfigurations(modelBuilder);

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        // player
        PlayerDbContext.ApplyPlayerConfigurations(modelBuilder);

        // team
        TeamDbContext.ApplyTeamConfigurations(modelBuilder);

        // game
        ApplyGameConfigurations(modelBuilder);

        // scheme
        SchemeDbContext.ApplySchemeConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        optionsBuilder.AddInterceptors(_playerEntityInterceptor);
        optionsBuilder.AddInterceptors(_teamEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public static void ApplyGameConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameStatusConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamStatusConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamIndexConfiguration());

        modelBuilder.ApplyConfiguration(new GamePlayerStatusConfiguration());

        modelBuilder.ApplyConfiguration(new GameAvailabilityConfiguration());

        modelBuilder.ApplyConfiguration(new GameConfiguration());

        modelBuilder.ApplyConfiguration(new GameFinancialProfileConfiguration());

        modelBuilder.ApplyConfiguration(new GameGeneralProfileConfiguration());

        modelBuilder.ApplyConfiguration(new GameInventaryProfileConfiguration());

        modelBuilder.ApplyConfiguration(new GameTagConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamConfiguration());

        modelBuilder.ApplyConfiguration(new GamePlayerConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamPlayerConfiguration());
    }
}