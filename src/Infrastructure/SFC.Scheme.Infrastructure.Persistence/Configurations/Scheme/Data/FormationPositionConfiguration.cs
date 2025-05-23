using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Data;
public class FormationPositionConfiguration : EnumDataEntityConfiguration<FormationPosition, FormationPositionEnum>
{
    public override void Configure(EntityTypeBuilder<FormationPosition> builder)
    {
        builder.HasOne<FootballPosition>()
               .WithMany()
               .HasForeignKey(e => e.FootballPositionId)
               .IsRequired(true);

        builder.ToTable("FormationPositions", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}