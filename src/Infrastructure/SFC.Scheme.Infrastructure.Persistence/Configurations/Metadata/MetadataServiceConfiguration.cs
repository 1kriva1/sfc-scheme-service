using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Metadata;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataServiceConfiguration : EnumEntityConfiguration<MetadataService, MetadataServiceEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataService> builder)
    {
        builder.ToTable("Services", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}