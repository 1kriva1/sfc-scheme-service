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
    /// Team's scheme formation model.
    /// </summary>
    public TeamSchemeFormationModel Formation { get; set; } = null!;
}