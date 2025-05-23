using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Domain.Entities.Scheme.Game;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game;
public class GameSchemeConfiguration : AuditableEntityConfiguration<GameScheme, long>
{
    public override void Configure(EntityTypeBuilder<GameScheme> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.ToTable("GameSchemes", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}