using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemePlayerPositionConfiguration : IEntityTypeConfiguration<TeamSchemePlayerPosition>
{
    public void Configure(EntityTypeBuilder<TeamSchemePlayerPosition> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<FormationPosition>()
               .WithMany()
               .HasForeignKey(t => t.FormationPositionId)
               .IsRequired(true);

        builder.ToTable("TeamSchemePlayerPositions", DatabaseConstants.DefaultSchemaName);
    }
}