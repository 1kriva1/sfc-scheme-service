using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Configurations.Base;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Data;
public class ShirtConfiguration : EnumDataEntityConfiguration<Shirt, ShirtEnum>
{
    public override void Configure(EntityTypeBuilder<Shirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Shirts", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}