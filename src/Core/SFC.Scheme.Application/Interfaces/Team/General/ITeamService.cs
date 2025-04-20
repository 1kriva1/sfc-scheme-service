using SFC.Scheme.Application.Common.Dto.Team.General;

namespace SFC.Scheme.Application.Interfaces.Team.General;
public interface ITeamService
{
    Task<TeamDto?> GetTeamAsync(long id, CancellationToken cancellationToken = default);
}