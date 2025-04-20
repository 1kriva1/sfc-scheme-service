using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Metadata;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataStateConfiguration : EnumEntityConfiguration<MetadataState, MetadataStateEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataState> builder)
    {
        builder.ToTable("States", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}