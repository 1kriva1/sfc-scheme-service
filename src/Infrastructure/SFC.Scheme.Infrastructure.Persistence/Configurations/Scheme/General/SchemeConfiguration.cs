using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.General;
public class SchemeConfiguration : AuditableEntityConfiguration<SchemeEntity, long>
{
    public override void Configure(EntityTypeBuilder<SchemeEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("Schemes");

        base.Configure(builder);
    }
}