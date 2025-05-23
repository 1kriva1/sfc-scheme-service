using SFC.Scheme.Api.Infrastructure.Models.Player.Result;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;

/// <summary>
/// Team's scheme **player** model.
/// </summary>
public class TeamSchemePlayerModel : IMapFromReverse<TeamSchemePlayerDto>
{
    /// <summary>
    /// Player model.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Player's position in formation.
    /// </summary>
    public required TeamSchemePlayerPositionModel Position { get; set; }
}