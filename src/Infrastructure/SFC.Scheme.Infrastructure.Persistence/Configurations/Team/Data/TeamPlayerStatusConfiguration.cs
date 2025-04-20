using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Team.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Team.Data;
public class TeamPlayerStatusConfiguration : EnumDataEntityConfiguration<TeamPlayerStatus, TeamPlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<TeamPlayerStatus> builder)
    {
        builder.ToTable("PlayerStatuses", DatabaseConstants.TeamSchemaName);
        base.Configure(builder);
    }
}