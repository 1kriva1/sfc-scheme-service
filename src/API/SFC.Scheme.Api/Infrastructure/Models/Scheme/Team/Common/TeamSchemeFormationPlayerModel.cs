using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Player;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;

/// <summary>
/// Team's scheme formation **player** model.
/// </summary>
public class TeamSchemeFormationPlayerModel : IMapFromReverse<TeamSchemeFormationPlayerDto>
{
    /// <summary>
    /// Player model.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Player's position in formation.
    /// </summary>
    public required TeamSchemeFormationPlayerPositionModel Position { get; set; }
}