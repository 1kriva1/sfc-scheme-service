using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.General;

namespace SFC.Scheme.Application.Common.Dto.Game.General;
public class GameFinancialProfileDto : IMapFromReverse<GameFinancialProfile>
{
    public bool FreeGame { get; set; }

    public decimal? PayAmount { get; set; }
}