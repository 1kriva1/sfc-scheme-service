using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game.Team;
public class GameTeamSchemeGeneralProfileConfiguration : IEntityTypeConfiguration<GameTeamSchemeGeneralProfile>
{
    public void Configure(EntityTypeBuilder<GameTeamSchemeGeneralProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Name)
               .HasMaxLength(ValidationConstants.NameValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.Comment)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(false);

        builder.ToTable("GameTeamSchemeGeneralProfiles", DatabaseConstants.DefaultSchemaName);
    }
}