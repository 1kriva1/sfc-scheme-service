using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemeFormationConfiguration : IEntityTypeConfiguration<TeamSchemeFormation>
{
    public void Configure(EntityTypeBuilder<TeamSchemeFormation> builder)
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
              .WithOne(e => e.TeamSchemeFormation)
              .HasForeignKey(e => e.TeamSchemeFormationId)
              .OnDelete(DeleteBehavior.ClientCascade)
              .IsRequired(true);

        builder.ToTable("TeamSchemeFormations", DatabaseConstants.DefaultSchemaName);
    }
}