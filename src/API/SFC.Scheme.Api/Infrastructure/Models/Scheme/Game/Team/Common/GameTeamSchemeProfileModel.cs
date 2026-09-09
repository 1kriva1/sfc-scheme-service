using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;

/// <summary>
/// Team scheme **profile** model.
/// </summary>
public class GameTeamSchemeProfileModel : IMapFromReverse<GameTeamSchemeProfileDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public required GameTeamSchemeGeneralProfileModel General { get; set; }
}