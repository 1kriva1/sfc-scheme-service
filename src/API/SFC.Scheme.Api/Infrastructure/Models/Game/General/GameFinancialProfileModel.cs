using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game's **financial** profile model.
/// </summary>
public class GameFinancialProfileModel : IMapFromReverse<GameFinancialProfileDto>
{
    /// <summary>
    /// Game play only on free field and without any extra expansions.
    /// </summary>
    public bool FreeGame { get; set; }

    /// <summary>
    /// How many need to pay for game.
    /// </summary>
    public decimal? PayAmount { get; set; }
}