using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Domain.Entities.Player;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Player;
public class PlayerTagConfiguration : IEntityTypeConfiguration<PlayerTag>
{
    public void Configure(EntityTypeBuilder<PlayerTag> builder)
    {
        builder.Property(e => e.Value)
               .HasMaxLength(ValidationConstants.TagValueMaxLength)
               .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.PlayerSchemaName);
    }
}