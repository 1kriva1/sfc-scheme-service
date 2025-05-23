using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Data;
public class SchemeTypeConfiguration : EnumDataEntityConfiguration<SchemeType, SchemeTypeEnum>
{
    public override void Configure(EntityTypeBuilder<SchemeType> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("SchemeTypes", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}