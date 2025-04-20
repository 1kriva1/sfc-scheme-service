using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Domain.Entities.Player;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Player;
public class PlayerStatConfiguration : IEntityTypeConfiguration<PlayerStat>
{
    public void Configure(EntityTypeBuilder<PlayerStat> builder)
    {
        builder.HasOne<StatType>(e => e.Type)
               .WithMany()
               .HasForeignKey(t => t.TypeId)
               .IsRequired(true);

        builder.ToTable("Stats", DatabaseConstants.PlayerSchemaName);
    }
}