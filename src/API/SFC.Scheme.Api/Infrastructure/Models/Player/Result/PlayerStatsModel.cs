using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player stats model.
/// </summary>
public class PlayerStatsModel : IMapFrom<PlayerStatsDto>
{
    /// <summary>
    /// Stats.
    /// </summary>
    public IEnumerable<PlayerStatValueModel> Values { get; set; } = [];
}