namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;

/// <summary>
/// **Base** team scheme model.
/// </summary>
public class BaseTeamSchemeModel
{
    /// <summary>
    /// Team's scheme profile model.
    /// </summary>
    public TeamSchemeProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Team's scheme linked players.
    /// </summary>
    public IEnumerable<TeamSchemePlayerModel> Players { get; set; } = null!;
}