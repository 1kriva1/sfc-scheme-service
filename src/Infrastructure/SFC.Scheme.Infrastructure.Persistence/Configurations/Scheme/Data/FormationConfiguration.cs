using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Data;
public class FormationConfiguration : EnumDataEntityConfiguration<Formation, FormationEnum>
{
    public override void Configure(EntityTypeBuilder<Formation> builder)
    {
        builder.HasMany(e => e.Values)
               .WithOne()
               .HasForeignKey(e => e.FormationId)
               .IsRequired(true);

        builder.ToTable("Formations", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}