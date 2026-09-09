using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game.Team;
public class GameTeamSchemeFormationPlayerPositionConfiguration : IEntityTypeConfiguration<GameTeamSchemeFormationPlayerPosition>
{
    public void Configure(EntityTypeBuilder<GameTeamSchemeFormationPlayerPosition> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<FormationPosition>()
               .WithMany()
               .HasForeignKey(t => t.FormationPositionId)
               .IsRequired(true);

        builder.ToTable("GameTeamSchemeFormationPlayerPositions", DatabaseConstants.DefaultSchemaName);
    }
}