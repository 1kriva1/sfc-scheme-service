using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemeFormationPlayerPositionConfiguration : IEntityTypeConfiguration<TeamSchemeFormationPlayerPosition>
{
    public void Configure(EntityTypeBuilder<TeamSchemeFormationPlayerPosition> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<FormationPosition>()
               .WithMany()
               .HasForeignKey(t => t.FormationPositionId)
               .IsRequired(true);

        builder.ToTable("TeamSchemeFormationPlayerPositions", DatabaseConstants.DefaultSchemaName);
    }
}