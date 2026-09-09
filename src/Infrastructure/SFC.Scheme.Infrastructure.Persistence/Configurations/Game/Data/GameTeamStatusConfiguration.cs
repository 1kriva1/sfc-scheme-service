using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Data;
public class GameTeamStatusConfiguration : EnumDataEntityConfiguration<GameTeamStatus, GameTeamStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GameTeamStatus> builder)
    {
        builder.ToTable("TeamStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}