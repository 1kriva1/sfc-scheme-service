using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Data;
public class GamePlayerStatusConfiguration : EnumDataEntityConfiguration<GamePlayerStatus, GamePlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GamePlayerStatus> builder)
    {
        builder.ToTable("PlayerStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}