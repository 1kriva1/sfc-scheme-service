using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Data;
public class GameTeamIndexConfiguration : EnumDataEntityConfiguration<GameTeamIndex, GameTeamIndexEnum>
{
    public override void Configure(EntityTypeBuilder<GameTeamIndex> builder)
    {
        builder.ToTable("TeamIndexes", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}