using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;

/// <summary>
/// Team scheme **profile** model.
/// </summary>
public class TeamSchemeProfileModel : IMapFromReverse<TeamSchemeProfileDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public required TeamSchemeGeneralProfileModel General { get; set; }
}