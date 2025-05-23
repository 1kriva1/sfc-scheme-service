using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemePlayerConfiguration : IEntityTypeConfiguration<TeamSchemePlayer>
{
    public void Configure(EntityTypeBuilder<TeamSchemePlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne(e => e.Player)
               .WithMany()
               .HasForeignKey(t => t.PlayerId)
               .IsRequired(true);

        builder.HasOne(e => e.Position)
               .WithOne(e => e.Player)
               .HasForeignKey<TeamSchemePlayerPosition>();

        builder.ToTable("TeamSchemePlayers", DatabaseConstants.DefaultSchemaName);
    }
}