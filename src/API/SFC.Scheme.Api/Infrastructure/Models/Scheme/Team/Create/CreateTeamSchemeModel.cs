using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Create;

/// <summary>
/// **Create** team scheme model.
/// </summary>
public class CreateTeamSchemeModel : IMapTo<CreateTeamSchemeDto>
{
    /// <summary>
    /// Team's scheme profile model.
    /// </summary>
    public TeamSchemeProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Team's scheme linked players.
    /// </summary>
    public IEnumerable<CreateTeamSchemePlayerModel> Players { get; set; } = null!;
}