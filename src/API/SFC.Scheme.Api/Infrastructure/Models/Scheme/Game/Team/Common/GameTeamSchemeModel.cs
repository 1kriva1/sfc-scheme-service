using SFC.Scheme.Api.Infrastructure.Models.Game.General;
using SFC.Scheme.Api.Infrastructure.Models.Team.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;

/// <summary>
/// Team scheme model.
/// </summary>
public class GameTeamSchemeModel : IMapFrom<GameTeamSchemeDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game scheme related to this team.
    /// </summary>
    public required GameModel Game { get; set; }

    /// <summary>
    /// Team scheme related to this team.
    /// </summary>
    public required TeamModel Team { get; set; }

    /// <summary>
    /// Team's scheme profile model.
    /// </summary>
    public GameTeamSchemeProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Team's scheme formation model.
    /// </summary>
    public GameTeamSchemeFormationModel Formation { get; set; } = null!;
}