using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Data;
public class StatSkillConfiguration : EnumDataEntityConfiguration<StatSkill, StatSkillEnum>
{
    public override void Configure(EntityTypeBuilder<StatSkill> builder)
    {
        builder.HasMany(e => e.Types)
               .WithOne()
               .HasForeignKey(t => t.SkillId)
               .IsRequired(true);

        builder.ToTable("StatSkills", DatabaseConstants.DataSchemaName);

        base.Configure(builder);
    }
}