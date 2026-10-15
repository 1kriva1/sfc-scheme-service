using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.Data;
using SFC.Scheme.Domain.Entities.Game.Player;
using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.Player;
public class GamePlayerConfiguration : AuditableReferenceEntityConfiguration<GamePlayer, long>
{
    public override void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasIndex(gp => new { gp.GameId, gp.PlayerId })
               .IsUnique();

        builder.HasOne<GamePlayerStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Players", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}