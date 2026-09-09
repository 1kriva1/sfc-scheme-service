using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Data;
public class GameStatusConfiguration : EnumDataEntityConfiguration<GameStatus, GameStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GameStatus> builder)
    {
        builder.ToTable("GameStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}