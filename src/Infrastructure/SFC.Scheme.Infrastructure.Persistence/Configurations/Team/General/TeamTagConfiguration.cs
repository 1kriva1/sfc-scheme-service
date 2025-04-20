using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Team.General;
public class TeamTagConfiguration : IEntityTypeConfiguration<TeamTag>
{
    public void Configure(EntityTypeBuilder<TeamTag> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.TeamSchemaName);
    }
}