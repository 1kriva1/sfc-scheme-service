using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game.Team;
public class GameTeamSchemeFormationPlayerConfiguration : IEntityTypeConfiguration<GameTeamSchemeFormationPlayer>
{
    public void Configure(EntityTypeBuilder<GameTeamSchemeFormationPlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne(e => e.Player)
               .WithMany()
               .HasForeignKey(t => t.PlayerId)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.HasOne(e => e.Position)
               .WithOne(e => e.Player)
               .HasForeignKey<GameTeamSchemeFormationPlayerPosition>();

        builder.ToTable("GameTeamSchemeFormationPlayers", DatabaseConstants.DefaultSchemaName);
    }
}