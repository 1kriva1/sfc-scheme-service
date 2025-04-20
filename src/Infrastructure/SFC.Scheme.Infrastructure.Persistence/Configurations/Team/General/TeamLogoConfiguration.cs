using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Team.General;
public class TeamLogoConfiguration : IEntityTypeConfiguration<TeamLogo>
{
    public void Configure(EntityTypeBuilder<TeamLogo> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Source)
               .HasColumnType("image")
               .IsRequired(true);

        builder.Property(e => e.Extension)
               .HasConversion<string>()
               .HasMaxLength(ValidationConstants.ExtensionValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.Name)
               .HasMaxLength(ValidationConstants.NameValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.Size)
               .HasMaxLength(ValidationConstants.FileMaxSizeInBytes)
               .IsRequired(true);

        builder.ToTable("Logos", DatabaseConstants.TeamSchemaName);
    }
}