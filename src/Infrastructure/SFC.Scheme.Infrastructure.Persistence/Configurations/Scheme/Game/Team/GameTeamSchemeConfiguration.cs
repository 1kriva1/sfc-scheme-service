using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Configurations.Scheme.Game.Team;
public class GameTeamSchemeConfiguration : IEntityTypeConfiguration<GameTeamScheme>
{
    public void Configure(EntityTypeBuilder<GameTeamScheme> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne(e => e.Team)
               .WithMany(e => e.GameSchemes)
               .HasForeignKey(e => e.TeamId)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(e => e.Game)
               .WithMany(e => e.TeamSchemes)
               .HasForeignKey(e => e.GameId)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(e => e.GeneralProfile)
               .WithOne(e => e.Scheme)
               .HasForeignKey<GameTeamSchemeGeneralProfile>(e => e.Id)
               .IsRequired(true);

        builder.HasOne(e => e.Formation)
               .WithOne(e => e.Scheme)
               .HasForeignKey<GameTeamSchemeFormation>(e => e.Id)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.ToTable("GameTeamSchemes", DatabaseConstants.DefaultSchemaName);
    }
}