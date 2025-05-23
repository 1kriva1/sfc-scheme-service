using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Data;
public class FormationValueConfiguration : DataEntityConfiguration<FormationValue, int>
{
    public override void Configure(EntityTypeBuilder<FormationValue> builder)
    {
        builder.HasOne<FormationPosition>()
               .WithMany()
               .HasForeignKey(e => e.FormationPositionId)
               .IsRequired(true);

        builder.ToTable("FormationValues", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}