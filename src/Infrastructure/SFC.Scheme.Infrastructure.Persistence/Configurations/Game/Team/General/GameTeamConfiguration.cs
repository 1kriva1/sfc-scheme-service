using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Domain.Entities.Game.Team.General;
using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Team.General;
public class GameTeamConfiguration : AuditableReferenceEntityConfiguration<GameTeam, long>
{
    public override void Configure(EntityTypeBuilder<GameTeam> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasIndex(t => new { t.GameId, t.TeamId })
               .IsUnique();

        builder.HasOne<GameTeamStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<GameTeamIndex>()
               .WithMany()
               .HasForeignKey(t => t.Index)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany(e => e.Players)
               .WithOne()
               .HasForeignKey(e => e.GameTeamId)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Teams", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}