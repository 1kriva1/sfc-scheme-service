using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Data;
public class WorkingFootConfiguration : EnumDataEntityConfiguration<WorkingFoot, WorkingFootEnum>
{
    public override void Configure(EntityTypeBuilder<WorkingFoot> builder)
    {
        builder.ToTable("WorkingFoots", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}