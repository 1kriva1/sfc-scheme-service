using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemeGeneralProfileConfiguration : IEntityTypeConfiguration<TeamSchemeGeneralProfile>
{
    public void Configure(EntityTypeBuilder<TeamSchemeGeneralProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Name)
               .HasMaxLength(ValidationConstants.NameValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.Comment)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(false);

        builder.HasOne<SchemeType>()
               .WithMany()
               .HasForeignKey(t => t.TypeId)
               .IsRequired(true);

        builder.HasOne<Formation>()
               .WithMany()
               .HasForeignKey(t => t.FormationId)
               .IsRequired(true);

        builder.ToTable("TeamSchemeGeneralProfiles", DatabaseConstants.DefaultSchemaName);
    }
}