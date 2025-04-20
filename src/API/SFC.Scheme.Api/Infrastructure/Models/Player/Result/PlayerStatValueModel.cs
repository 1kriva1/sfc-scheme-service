using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player stat value model.
/// </summary>
public class PlayerStatValueModel : IMapFromReverse<PlayerStatValueDto>
{
    /// <summary>
    /// Type of stat
    /// </summary>
    public int Type { get; set; } = default!;

    /// <summary>
    /// Stat value.
    /// </summary>
    public byte Value { get; set; }
}