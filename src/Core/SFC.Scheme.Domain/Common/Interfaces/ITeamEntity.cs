namespace SFC.Scheme.Domain.Common.Interfaces;
public interface ITeamEntity
{
    long TeamId { get; set; }

    TeamEntity Team { get; set; }
}