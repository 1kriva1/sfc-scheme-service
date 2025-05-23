using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Delete;
public class DeleteTeamSchemeDto : IMapTo<TeamScheme>
{
    public long Id { get; set; }

    public long TeamId { get; set; }
}