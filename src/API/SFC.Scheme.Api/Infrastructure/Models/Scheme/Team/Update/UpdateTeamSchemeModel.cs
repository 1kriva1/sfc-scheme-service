using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Update;

/// <summary>
/// **Update** team scheme model.
/// </summary>
public class UpdateTeamSchemeModel : IMapTo<UpdateTeamSchemeDto>
{
    /// <summary>
    /// Team's scheme profile model.
    /// </summary>
    public TeamSchemeProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Team's scheme linked players.
    /// </summary>
    public IEnumerable<UpdateTeamSchemePlayerModel> Players { get; set; } = null!;
}