using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Delete;
public class DeleteGameTeamSchemeDto : IMapTo<GameTeamScheme>
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }
}