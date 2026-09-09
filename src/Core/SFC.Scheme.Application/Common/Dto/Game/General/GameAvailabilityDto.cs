using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.General;

namespace SFC.Scheme.Application.Common.Dto.Game.General;
public class GameAvailabilityDto : IMapFromReverse<GameAvailability>
{
    public DateOnly Date { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}