using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;
public class UpdateTeamSchemeDto : TeamSchemeDto, IMapTo<TeamScheme>
{
    public long Id { get; set; }
}