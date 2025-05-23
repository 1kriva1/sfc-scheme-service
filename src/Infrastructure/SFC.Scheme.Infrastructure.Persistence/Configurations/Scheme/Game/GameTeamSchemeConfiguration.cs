using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Game;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game;
public class GameTeamSchemeConfiguration : IEntityTypeConfiguration<GameTeamScheme>
{
    public void Configure(EntityTypeBuilder<GameTeamScheme> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // it's for skip exception during update db (sql server only related)
        builder.HasOne<TeamEntity>()
               .WithMany()
               .HasForeignKey(e => e.TeamId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // it's for skip exception during update db (sql server only related)
        //builder.HasOne<GameEntity>()
        //       .WithMany()
        //       .HasForeignKey(e => e.GameId)
        //       .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("GameTeamSchemes", DatabaseConstants.DefaultSchemaName);
    }
}