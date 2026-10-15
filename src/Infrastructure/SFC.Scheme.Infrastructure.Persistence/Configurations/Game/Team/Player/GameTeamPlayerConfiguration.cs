using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Player;
using SFC.Scheme.Domain.Entities.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Domain.Entities.Team.Player;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Team.Player;

public class GameTeamPlayerConfiguration : AuditableReferenceEntityConfiguration<GameTeamPlayer, long>
{
    public override void Configure(EntityTypeBuilder<GameTeamPlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasIndex(t => new { t.GameTeamId, t.GamePlayerId, t.TeamPlayerId })
               .IsUnique();

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(t => t.GameTeam)
               .WithMany(t => t.Players)
               .HasForeignKey(t => t.GameTeamId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(t => t.GamePlayer)
               .WithOne(gp => gp.GameTeamPlayer)
               .HasForeignKey<GameTeamPlayer>(t => t.GamePlayerId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(t => t.TeamPlayer)
               .WithMany()
               .HasForeignKey(t => t.TeamPlayerId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.ToTable("TeamPlayers", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}