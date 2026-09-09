using SFC.Scheme.Api.Infrastructure.Models.Game.General;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Create;

/// <summary>
/// **Create** team scheme model.
/// </summary>
public class CreateGameTeamSchemeModel : IMapTo<CreateGameTeamSchemeDto>
{
    /// <summary>
    /// Team's scheme profile model.
    /// </summary>
    public GameTeamSchemeProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Team's scheme formation model.
    /// </summary>
    public CreateGameTeamSchemeFormationModel Formation { get; set; } = null!;
}