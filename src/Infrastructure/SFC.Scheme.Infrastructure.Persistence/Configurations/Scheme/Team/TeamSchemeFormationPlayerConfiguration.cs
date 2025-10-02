using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemeFormationPlayerConfiguration : IEntityTypeConfiguration<TeamSchemeFormationPlayer>
{
    public void Configure(EntityTypeBuilder<TeamSchemeFormationPlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne(e => e.Player)
               .WithMany()
               .HasForeignKey(t => t.PlayerId)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.HasOne(e => e.Position)
               .WithOne(e => e.Player)
               .HasForeignKey<TeamSchemeFormationPlayerPosition>();

        builder.ToTable("TeamSchemeFormationPlayers", DatabaseConstants.DefaultSchemaName);
    }
}