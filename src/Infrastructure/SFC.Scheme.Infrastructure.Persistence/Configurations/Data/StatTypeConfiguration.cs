using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Data;
public class StatTypeConfiguration : EnumDataEntityConfiguration<StatType, StatTypeEnum>
{
    public override void Configure(EntityTypeBuilder<StatType> builder)
    {
        builder.ToTable("StatTypes", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}