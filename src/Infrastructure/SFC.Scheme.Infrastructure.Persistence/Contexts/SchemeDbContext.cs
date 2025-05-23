using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Common;
using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Game;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

using SFC.Scheme.Infrastructure.Persistence.Interceptors;
using SFC.Scheme.Infrastructure.Persistence.Seeds;

namespace SFC.Scheme.Infrastructure.Persistence.Contexts;
public class SchemeDbContext(
    IDateTimeService dateTimeService,
    IHostEnvironment hostEnvironment,
    DbContextOptions<SchemeDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    PlayerEntitySaveChangesInterceptor playerEntityInterceptor,
    TeamEntitySaveChangesInterceptor teamEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<SchemeDbContext>(options, eventsInterceptor), ISchemeDbContext
{
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;
    private readonly PlayerEntitySaveChangesInterceptor _playerEntityInterceptor = playerEntityInterceptor;
    private readonly TeamEntitySaveChangesInterceptor _teamEntityInterceptor = teamEntityInterceptor;

    #region General

    public IQueryable<TeamScheme> TeamSchemes => Set<TeamScheme>();

    public IQueryable<GameScheme> GameSchemes => Set<GameScheme>();

    #endregion General

    #region Data

    public IQueryable<Formation> Formations => Set<Formation>();

    public IQueryable<FormationPosition> FormationPositions => Set<FormationPosition>();

    public IQueryable<FormationValue> FormationValues => Set<FormationValue>();

    public IQueryable<SchemeType> SchemeTypes => Set<SchemeType>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DefaultSchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // seed data
        modelBuilder.SeedSchemeData(_dateTimeService);

        // metadata
        MetadataDbContext.ApplyMetadataConfigurations(modelBuilder, _hostEnvironment.IsDevelopment());

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        optionsBuilder.AddInterceptors(_playerEntityInterceptor);
        optionsBuilder.AddInterceptors(_teamEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}