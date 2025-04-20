using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Player;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Player;
public class PlayerGeneralProfileConfiguration : IEntityTypeConfiguration<PlayerGeneralProfile>
{
    public void Configure(EntityTypeBuilder<PlayerGeneralProfile> builder)
    {
        builder.Property(e => e.FirstName)
               .HasMaxLength(ValidationConstants.NameValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.LastName)
               .HasMaxLength(ValidationConstants.NameValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.Biography)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(false);

        builder.Property(e => e.Birthday)
               .HasColumnType("date")
               .IsRequired(false);

        builder.Property(e => e.City)
               .HasMaxLength(ValidationConstants.CityValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.FreePlay)
               .HasDefaultValue(false);

        builder.ToTable("GeneralProfiles", DatabaseConstants.PlayerSchemaName);
    }
}