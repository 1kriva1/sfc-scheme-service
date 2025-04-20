﻿using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Data;
using SFC.Scheme.Infrastructure.Persistence.Constants;
using SFC.Scheme.Infrastructure.Persistence.Interceptors;

namespace SFC.Scheme.Infrastructure.Persistence.Contexts;
public class DataDbContext(
    DbContextOptions<DataDbContext> options,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<DataDbContext>(options, eventsInterceptor), IDataDbContext
{
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;

    public IQueryable<GameStyle> GameStyles => Set<GameStyle>();

    public IQueryable<FootballPosition> FootballPositions => Set<FootballPosition>();

    public IQueryable<StatCategory> StatCategories => Set<StatCategory>();

    public IQueryable<StatSkill> StatSkills => Set<StatSkill>();

    public IQueryable<StatType> StatTypes => Set<StatType>();

    public IQueryable<WorkingFoot> WorkingFoots => Set<WorkingFoot>();

    public IQueryable<Shirt> Shirts => Set<Shirt>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DataSchemaName);

        // data
        ApplyDataConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Example:
    /// modelBuilder.ApplyConfiguration(new ShirtConfiguration());
    /// </summary>
    /// <param name="modelBuilder">Model builder</param>
    public static void ApplyDataConfigurations(ModelBuilder modelBuilder)
    {
        // add data configurations
        modelBuilder.ApplyConfiguration(new GameStyleConfiguration());

        modelBuilder.ApplyConfiguration(new FootballPositionConfiguration());

        modelBuilder.ApplyConfiguration(new StatCategoryConfiguration());

        modelBuilder.ApplyConfiguration(new StatSkillConfiguration());

        modelBuilder.ApplyConfiguration(new StatTypeConfiguration());

        modelBuilder.ApplyConfiguration(new WorkingFootConfiguration());

        modelBuilder.ApplyConfiguration(new ShirtConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}