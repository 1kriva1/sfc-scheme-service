using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Metadata;
using SFC.Scheme.Infrastructure.Persistence.Constants;
using SFC.Scheme.Infrastructure.Persistence.Interceptors;
using SFC.Scheme.Infrastructure.Persistence.Seeds;

namespace SFC.Scheme.Infrastructure.Persistence.Contexts;
public class MetadataDbContext(
    DbContextOptions<MetadataDbContext> options,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor,
    IHostEnvironment hostEnvironment)
    : BaseDbContext<MetadataDbContext>(options, eventsInterceptor), IMetadataDbContext
{
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public IQueryable<MetadataEntity> Metadata => Set<MetadataEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.MetadataSchemaName);

        ApplyMetadataConfigurations(modelBuilder, _hostEnvironment.IsDevelopment());

        base.OnModelCreating(modelBuilder);
    }

    public static void ApplyMetadataConfigurations(ModelBuilder modelBuilder, bool isDevelopment)
    {
        modelBuilder.ApplyConfiguration(new MetadataServiceConfiguration());
        modelBuilder.ApplyConfiguration(new MetadataStateConfiguration());
        modelBuilder.ApplyConfiguration(new MetadataTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MetadataConfiguration());
        modelBuilder.ApplyConfiguration(new MetadataDomainConfiguration());

        // seed data
        modelBuilder.SeedMetadata(isDevelopment);
    }
}