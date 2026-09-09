using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game.Team;
public class GameTeamSchemeFormationConfiguration : IEntityTypeConfiguration<GameTeamSchemeFormation>
{
    public void Configure(EntityTypeBuilder<GameTeamSchemeFormation> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<SchemeType>()
               .WithMany()
               .HasForeignKey(t => t.TypeId)
               .IsRequired(true);

        builder.HasOne<Formation>()
               .WithMany()
               .HasForeignKey(t => t.FormationId)
               .IsRequired(true);

        builder.HasMany(e => e.Players)
              .WithOne(e => e.Formation)
              .HasForeignKey(e => e.GameTeamSchemeFormationId)
              .OnDelete(DeleteBehavior.ClientCascade)
              .IsRequired(true);

        builder.ToTable("GameTeamSchemeFormations", DatabaseConstants.DefaultSchemaName);
    }
}