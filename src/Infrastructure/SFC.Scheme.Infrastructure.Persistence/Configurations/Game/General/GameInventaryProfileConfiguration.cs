using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Game.General;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Game.General;
public class GameInventaryProfileConfiguration : IEntityTypeConfiguration<GameInventaryProfile>
{
    public void Configure(EntityTypeBuilder<GameInventaryProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.ShirtsRequired)
            .HasDefaultValue(false);

        builder.ToTable("InventaryProfiles", DatabaseConstants.GameSchemaName);
    }
}