using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Team;
public class TeamSchemeConfiguration : AuditableEntityConfiguration<TeamScheme, long>
{
    public override void Configure(EntityTypeBuilder<TeamScheme> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne(e => e.GeneralProfile)
               .WithOne(e => e.Scheme)
               .HasForeignKey<TeamSchemeGeneralProfile>()
               .IsRequired(true);

        builder.HasMany(e => e.Players)
               .WithOne()
               .HasForeignKey(e => e.TeamSchemeId)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.ToTable("TeamSchemes", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}