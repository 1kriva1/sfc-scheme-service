using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.General;

namespace SFC.Scheme.Application.Common.Dto.Game.General;
public class GameInventaryProfileDto : IMapFromReverse<GameInventaryProfile>
{
    public bool ShirtsRequired { get; set; }

    public int? ShirtsCount { get; set; }
}