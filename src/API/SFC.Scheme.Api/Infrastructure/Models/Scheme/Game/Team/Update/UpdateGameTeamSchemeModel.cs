using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Update;

/// <summary>
/// **Update** team scheme model.
/// </summary>
public class UpdateGameTeamSchemeModel : IMapTo<UpdateGameTeamSchemeDto>
{
    /// <summary>
    /// Team's scheme profile model.
    /// </summary>
    public GameTeamSchemeProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Team's scheme formation model.
    /// </summary>
    public UpdateGameTeamSchemeFormationModel Formation { get; set; } = null!;
}