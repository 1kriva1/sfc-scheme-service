using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Data;
public class FootballPositionConfiguration : EnumDataEntityConfiguration<FootballPosition, FootballPositionEnum>
{
    public override void Configure(EntityTypeBuilder<FootballPosition> builder)
    {
        builder.ToTable("FootballPositions", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}