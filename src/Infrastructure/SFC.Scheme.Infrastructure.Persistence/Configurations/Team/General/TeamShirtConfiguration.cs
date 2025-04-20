using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Domain.Entities.Team.General;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Team.General;
public class TeamShirtConfiguration : IEntityTypeConfiguration<TeamShirt>
{
    public void Configure(EntityTypeBuilder<TeamShirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<Shirt>()
               .WithMany()
               .HasForeignKey(t => t.ShirtId)
               .IsRequired(true);

        builder.ToTable("Shirts", DatabaseConstants.TeamSchemaName);
    }
}