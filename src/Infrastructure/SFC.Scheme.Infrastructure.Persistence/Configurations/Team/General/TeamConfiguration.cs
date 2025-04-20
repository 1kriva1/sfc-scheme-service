using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Domain.Entities.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Team.General;
public class TeamConfiguration : AuditableReferenceEntityConfiguration<TeamEntity, long>
{
    public override void Configure(EntityTypeBuilder<TeamEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne(e => e.GeneralProfile)
               .WithOne(e => e.Team)
               .HasForeignKey<TeamGeneralProfile>()
               .IsRequired(true);

        builder.HasOne(e => e.FinancialProfile)
               .WithOne(e => e.Team)
               .HasForeignKey<TeamFinancialProfile>()
               .IsRequired(true);

        builder.HasMany(e => e.Availability)
               .WithOne(e => e.Team)
               .HasForeignKey(DatabaseConstants.TeamForeignKey);

        builder.HasOne(e => e.Logo)
               .WithOne(e => e.Team)
               .HasForeignKey<TeamLogo>()
               .IsRequired(true);

        builder.HasMany(e => e.Tags)
               .WithOne(e => e.Team)
               .HasForeignKey(DatabaseConstants.TeamForeignKey);

        builder.HasMany(e => e.Shirts)
               .WithOne(e => e.Team)
               .HasForeignKey(DatabaseConstants.TeamForeignKey);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("Teams", DatabaseConstants.TeamSchemaName);

        base.Configure(builder);
    }
}