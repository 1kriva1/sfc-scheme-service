using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Game;
public class GameTeamScheme : BaseEntity<long>
{
    public long GameId { get; set; }

    public long TeamId { get; set; }
}