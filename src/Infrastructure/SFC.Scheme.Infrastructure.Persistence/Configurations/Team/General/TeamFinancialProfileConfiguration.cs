using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Team.General;
public class TeamFinancialProfileConfiguration : IEntityTypeConfiguration<TeamFinancialProfile>
{
    public void Configure(EntityTypeBuilder<TeamFinancialProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.FreePlay)
            .HasDefaultValue(false);

        builder.ToTable("FinancialProfiles", DatabaseConstants.TeamSchemaName);
    }
}